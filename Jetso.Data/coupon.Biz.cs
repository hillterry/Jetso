﻿using System;
using System.ComponentModel;
using System.Xml.Serialization;
using DmFramework.Data;

namespace Jetso.Data
{
	/// <summary></summary>
	public partial class coupon : Entity<coupon>
	{
		#region 对象操作﻿

		/// <summary>验证数据，通过抛出异常的方式提示验证失败。</summary>
		/// <param name="isNew"></param>
		public override void Valid(Boolean isNew)
		{
			// 这里验证参数范围，建议抛出参数异常，指定参数名，前端用户界面可以捕获参数异常并聚焦到对应的参数输入框
			//if (MatchHelper.StrIsNullOrEmpty(Name)) throw new ArgumentNullException(_.Name, _.Name.DisplayName + "无效！");
			//if (!isNew && ID < 1) throw new ArgumentOutOfRangeException(_.ID, _.ID.DisplayName + "必须大于0！");

			// 建议先调用基类方法，基类方法会对唯一索引的数据进行验证
			base.Valid(isNew);

			// 在新插入数据或者修改了指定字段时进行唯一性验证，CheckExist内部抛出参数异常
			//if (isNew || Dirtys[__.Name]) CheckExist(__.Name);

			if (isNew && !Dirtys[__.createTime]) createTime = DateTime.Now;
		}

		///// <summary>首次连接数据库时初始化数据，仅用于实体类重载，用户不应该调用该方法</summary>
		//[EditorBrowsable(EditorBrowsableState.Never)]
		//protected override void InitData()
		//{
		//    base.InitData();

		//    // InitData一般用于当数据表没有数据时添加一些默认数据，该实体类的任何第一次数据库操作都会触发该方法，默认异步调用
		//    // Meta.Count是快速取得表记录数
		//    if (Meta.Count > 0) return;

		//    // 需要注意的是，如果该方法调用了其它实体类的首次数据库操作，目标实体类的数据初始化将会在同一个线程完成
		//    HmTrace.WriteDebug("开始初始化{0}[{1}]数据……", typeof(coupon).Name, Meta.Table.DataTable.DisplayName);

		//    var entity = new coupon();
		//    entity.productId = 0;
		//    entity.memberId = 0;
		//    entity.cuponNumber = "abc";
		//    entity.isLive = 0;
		//    entity.createTime = DateTime.Now;
		//    entity.billImg = "abc";
		//    entity.serviceTime = DateTime.Now;
		//    entity.serviceMoney = 0;
		//    entity.friendId = 0;
		//    entity.friendEmail = "abc";
		//    entity.billNumber = "abc";
		//    entity.friendRegEmail = "abc";
		//    entity.viewable = 0;
		//    entity.Insert();

		//    HmTrace.WriteDebug("完成初始化{0}[{1}]数据！", typeof(coupon).Name, Meta.Table.DataTable.DisplayName);
		//}

		/// <summary>已重载。删除关联数据</summary>
		/// <returns></returns>
		protected override int OnDelete()
		{
			if (friend != null) friend.Delete();

			return base.OnDelete();
		}

		///// <summary>已重载。基类先调用Valid(true)验证数据，然后在事务保护内调用OnInsert</summary>
		///// <returns></returns>
		//public override Int32 Insert()
		//{
		//    return base.Insert();
		//}

		///// <summary>已重载。在事务保护范围内处理业务，位于Valid之后</summary>
		///// <returns></returns>
		//protected override Int32 OnInsert()
		//{
		//    return base.OnInsert();
		//}

		#endregion

		#region 扩展属性﻿

		[NonSerialized]
		private friend _friend;

		/// <summary>该coupon所对应的friend</summary>
		[XmlIgnore]
		public friend friend
		{
			get
			{
				if (_friend == null && friendId > 0 && !Dirtys.ContainsKey("friend"))
				{
					_friend = friend.FindByid(friendId);
					Dirtys["friend"] = true;
				}
				return _friend;
			}
			set { _friend = value; }
		}

		/// <summary>该coupon所对应的friendname</summary>
		[XmlIgnore]
		public String friendName { get { return friend != null ? friend.name : null; } }

		[NonSerialized]
		private member _member;

		/// <summary>该coupon所对应的member</summary>
		[XmlIgnore]
		public member member
		{
			get
			{
				if (_member == null && memberId > 0 && !Dirtys.ContainsKey("member"))
				{
					_member = member.FindByID(memberId);
					Dirtys["member"] = true;
				}
				return _member;
			}
			set { _member = value; }
		}

		/// <summary>该coupon所对应的member姓名</summary>
		[XmlIgnore]
		public String memberName { get { return member != null ? member.name : null; } }

		[NonSerialized]
		private product _product;

		/// <summary>该coupon所对应的product</summary>
		[XmlIgnore]
		public product product
		{
			get
			{
				if (_product == null && productId > 0 && !Dirtys.ContainsKey("product"))
				{
					_product = product.FindByID(productId);
					Dirtys["product"] = true;
				}
				return _product;
			}
			set { _product = value; }
		}

		#endregion

		#region 扩展查询﻿

		/// <summary>根据ID查找</summary>
		/// <param name="id"></param>
		/// <returns></returns>
		[DataObjectMethod(DataObjectMethodType.Select, false)]
		public static coupon FindByID(Int32 id)
		{
			if (Meta.Count >= 1000)
				return Find(_.ID, id);
			else // 实体缓存
				return Meta.Cache.Entities.Find(_.ID, id);

			// 单对象缓存
			//return Meta.SingleCache[id];
		}

		/// <summary>根据friendId查找</summary>
		/// <param name="friendid"></param>
		/// <returns></returns>
		[DataObjectMethod(DataObjectMethodType.Select, false)]
		public static EntityList<coupon> FindAllByfriendId(Int32 friendid)
		{
			if (Meta.Count >= 1000)
				return FindAll(_.friendId, friendid);
			else // 实体缓存
				return Meta.Cache.Entities.FindAll(_.friendId, friendid);
		}

		/// <summary>根据friendEmail查找</summary>
		/// <param name="friendemail"></param>
		/// <returns></returns>
		[DataObjectMethod(DataObjectMethodType.Select, false)]
		public static EntityList<coupon> FindAllByfriendEmail(String friendemail)
		{
			if (Meta.Count >= 1000)
				return FindAll(_.friendEmail, friendemail);
			else // 实体缓存
				return Meta.Cache.Entities.FindAll(_.friendEmail, friendemail);
		}

		/// <summary>根据memberId查找</summary>
		/// <param name="memberid"></param>
		/// <returns></returns>
		[DataObjectMethod(DataObjectMethodType.Select, false)]
		public static EntityList<coupon> FindAllBymemberId(Int32 memberid)
		{
			if (Meta.Count >= 1000)
				return FindAll(_.memberId, memberid);
			else // 实体缓存
				return Meta.Cache.Entities.FindAll(_.memberId, memberid);
		}

		/// <summary>根据productId查找</summary>
		/// <param name="productid"></param>
		/// <returns></returns>
		[DataObjectMethod(DataObjectMethodType.Select, false)]
		public static EntityList<coupon> FindAllByproductId(Int32 productid)
		{
			if (Meta.Count >= 1000)
				return FindAll(_.productId, productid);
			else // 实体缓存
				return Meta.Cache.Entities.FindAll(_.productId, productid);
		}

		#endregion

		#region 高级查询

		// 以下为自定义高级查询的例子

		///// <summary>
		///// 查询满足条件的记录集，分页、排序
		///// </summary>
		///// <param name="key">关键字</param>
		///// <param name="orderClause">排序，不带Order By</param>
		///// <param name="startRowIndex">开始行，0表示第一行</param>
		///// <param name="maximumRows">最大返回行数，0表示所有行</param>
		///// <returns>实体集</returns>
		//[DataObjectMethod(DataObjectMethodType.Select, true)]
		//public static EntityList<coupon> Search(String key, String orderClause, Int32 startRowIndex, Int32 maximumRows)
		//{
		//    return FindAll(SearchWhere(key), orderClause, null, startRowIndex, maximumRows);
		//}

		///// <summary>
		///// 查询满足条件的记录总数，分页和排序无效，带参数是因为ObjectDataSource要求它跟Search统一
		///// </summary>
		///// <param name="key">关键字</param>
		///// <param name="orderClause">排序，不带Order By</param>
		///// <param name="startRowIndex">开始行，0表示第一行</param>
		///// <param name="maximumRows">最大返回行数，0表示所有行</param>
		///// <returns>记录数</returns>
		//public static Int32 SearchCount(String key, String orderClause, Int32 startRowIndex, Int32 maximumRows)
		//{
		//    return FindCount(SearchWhere(key), null, null, 0, 0);
		//}

		

        /// <summary>构造搜索条件</summary>
        /// <param name="key">关键字</param>
        /// <returns></returns>
        private static String SearchWhere(String key)
        {
            // WhereExpression重载&和|运算符，作为And和Or的替代
            // SearchWhereByKeys系列方法用于构建针对字符串字段的模糊搜索
            var exp = SearchWhereByKeys(key, null);
            
            // 以下仅为演示，Field（继承自FieldItem）重载了==、!=、>、<、>=、<=等运算符（第4行）
            //if (userid > 0) exp &= _.OperatorID == userid;
            //if (isSign != null) exp &= _.IsSign == isSign.Value;
            //if (start > DateTime.MinValue) exp &= _.OccurTime >= start;
            //if (end > DateTime.MinValue) exp &= _.OccurTime < end.AddDays(1).Date;

            return exp;
        }



        /// <summary>构造搜索条件</summary>
        /// <param name="key">关键字</param>
        /// <returns></returns>
        private static String SearchWhere_View_Member(String key, Int32 viewable , Int32 memberId)
        {
            // WhereExpression重载&和|运算符，作为And和Or的替代
            // SearchWhereByKeys系列方法用于构建针对字符串字段的模糊搜索
            var exp = SearchWhereByKeys(key, null);
            exp &= _.viewable == viewable;
            exp &= _.memberId == memberId;
            // 以下仅为演示，Field（继承自FieldItem）重载了==、!=、>、<、>=、<=等运算符（第4行）
            //if (userid > 0) exp &= _.OperatorID == userid;
            //if (isSign != null) exp &= _.IsSign == isSign.Value;
            //if (start > DateTime.MinValue) exp &= _.OccurTime >= start;
            //if (end > DateTime.MinValue) exp &= _.OccurTime < end.AddDays(1).Date;

            return exp;
        }


        /// <summary>
        /// 查询满足条件的记录集，分页、排序
        /// </summary>
        /// <param name="key">关键字</param>
        /// <param name="orderClause">排序，不带Order By</param>
        /// <param name="startRowIndex">开始行，0表示第一行</param>
        /// <param name="maximumRows">最大返回行数，0表示所有行</param>
        /// <returns>实体集</returns>
        [DataObjectMethod(DataObjectMethodType.Select, true)]
        public static EntityList<coupon> Search_View_Member(String key, String orderClause, Int32 startRowIndex, Int32 maximumRows, Int32 viewable , Int32 memberId)
        {
            return FindAll(SearchWhere_View_Member(key, viewable , memberId), orderClause, null, startRowIndex, maximumRows);
        }


        private static String SearchWhere_Member_Intro(String key, Int32 friendId)
        {
            // WhereExpression重载&和|运算符，作为And和Or的替代
            // SearchWhereByKeys系列方法用于构建针对字符串字段的模糊搜索
            var exp = SearchWhereByKeys(key, null);
            exp &= _.friendId == friendId;
            // 以下仅为演示，Field（继承自FieldItem）重载了==、!=、>、<、>=、<=等运算符（第4行）
            //if (userid > 0) exp &= _.OperatorID == userid;
            //if (isSign != null) exp &= _.IsSign == isSign.Value;
            //if (start > DateTime.MinValue) exp &= _.OccurTime >= start;
            //if (end > DateTime.MinValue) exp &= _.OccurTime < end.AddDays(1).Date;

            return exp;
        }


        /// <summary>
        /// 查询满足条件的记录集，分页、排序
        /// </summary>
        /// <param name="key">关键字</param>
        /// <param name="orderClause">排序，不带Order By</param>
        /// <param name="startRowIndex">开始行，0表示第一行</param>
        /// <param name="maximumRows">最大返回行数，0表示所有行</param>
        /// <returns>实体集</returns>
        [DataObjectMethod(DataObjectMethodType.Select, true)]
        public static EntityList<coupon> Search_Member_Intro(String key, String orderClause, Int32 startRowIndex, Int32 maximumRows, Int32 friendId)
        {
            return FindAll(SearchWhere_Member_Intro(key, friendId), orderClause, null, startRowIndex, maximumRows);
        }


        private static String SearchWhere_Coupon_Time(String key, string fromdate, string todate, int productId)
        {
            // WhereExpression重载&和|运算符，作为And和Or的替代
            // SearchWhereByKeys系列方法用于构建针对字符串字段的模糊搜索
            var exp = SearchWhereByKeys(key, null);
            exp &= _.createTime >= fromdate;
            exp &= _.createTime <= todate;
            exp &= _.productId == productId;
            // 以下仅为演示，Field（继承自FieldItem）重载了==、!=、>、<、>=、<=等运算符（第4行）
            //if (userid > 0) exp &= _.OperatorID == userid;
            //if (isSign != null) exp &= _.IsSign == isSign.Value;
            //if (start > DateTime.MinValue) exp &= _.OccurTime >= start;
            //if (end > DateTime.MinValue) exp &= _.OccurTime < end.AddDays(1).Date;

            return exp;
        }

        /// <summary>
        /// 查询满足条件的记录集，分页、排序
        /// </summary>
        /// <param name="key">关键字</param>
        /// <param name="orderClause">排序，不带Order By</param>
        /// <param name="startRowIndex">开始行，0表示第一行</param>
        /// <param name="maximumRows">最大返回行数，0表示所有行</param>
        /// <returns>实体集</returns>
        [DataObjectMethod(DataObjectMethodType.Select, true)]
        public static EntityList<coupon> Search_Coupon_Time(String key, String orderClause, Int32 startRowIndex, Int32 maximumRows, string fromdate, string todate, int productId)
        {
            return FindAll(SearchWhere_Coupon_Time(key, fromdate, todate, productId), orderClause, null, startRowIndex, maximumRows);
        }


        /// <summary>
        /// 查询满足条件的记录总数，分页和排序无效，带参数是因为ObjectDataSource要求它跟Search统一
        /// </summary>
        /// <param name="key">关键字</param>
        /// <param name="orderClause">排序，不带Order By</param>
        /// <param name="startRowIndex">开始行，0表示第一行</param>
        /// <param name="maximumRows">最大返回行数，0表示所有行</param>
        /// <returns>记录数</returns>
        public static Int32 SearchCountByDate(String key, string fromdate, string todate, String orderClause, Int32 startRowIndex, Int32 maximumRows, int productId)
        {
            return FindCount(SearchWhere_Coupon_Time(key, fromdate, todate, productId), null, null, 0, 0);
        }




        private static String SearchWhere_Coupon_Product(String key, Int32 productId)
        {
            // WhereExpression重载&和|运算符，作为And和Or的替代
            // SearchWhereByKeys系列方法用于构建针对字符串字段的模糊搜索
            var exp = SearchWhereByKeys(key, null);
            exp &= _.productId == productId;
            // 以下仅为演示，Field（继承自FieldItem）重载了==、!=、>、<、>=、<=等运算符（第4行）
            //if (userid > 0) exp &= _.OperatorID == userid;
            //if (isSign != null) exp &= _.IsSign == isSign.Value;
            //if (start > DateTime.MinValue) exp &= _.OccurTime >= start;
            //if (end > DateTime.MinValue) exp &= _.OccurTime < end.AddDays(1).Date;

            return exp;
        }


        /// <summary>
        /// 查询满足条件的记录集，分页、排序
        /// </summary>
        /// <param name="key">关键字</param>
        /// <param name="orderClause">排序，不带Order By</param>
        /// <param name="startRowIndex">开始行，0表示第一行</param>
        /// <param name="maximumRows">最大返回行数，0表示所有行</param>
        /// <returns>实体集</returns>
        [DataObjectMethod(DataObjectMethodType.Select, true)]
        public static EntityList<coupon> Search_Coupon_Product(String key, String orderClause, Int32 startRowIndex, Int32 maximumRows, Int32 productId)
        {
            return FindAll(SearchWhere_Coupon_Product(key, productId), orderClause, null, startRowIndex, maximumRows);
        }




        private static String SearchWhere_Coupon_Number(String key, string couponNum , int productId)
        {
            // WhereExpression重载&和|运算符，作为And和Or的替代
            // SearchWhereByKeys系列方法用于构建针对字符串字段的模糊搜索
            var exp = SearchWhereByKeys(key, null);
            exp &= _.cuponNumber == couponNum;
            exp &= _.productId == productId;
            // 以下仅为演示，Field（继承自FieldItem）重载了==、!=、>、<、>=、<=等运算符（第4行）
            //if (userid > 0) exp &= _.OperatorID == userid;
            //if (isSign != null) exp &= _.IsSign == isSign.Value;
            //if (start > DateTime.MinValue) exp &= _.OccurTime >= start;
            //if (end > DateTime.MinValue) exp &= _.OccurTime < end.AddDays(1).Date;

            return exp;
        }


        /// <summary>
        /// 查询满足条件的记录集，分页、排序
        /// </summary>
        /// <param name="key">关键字</param>
        /// <param name="orderClause">排序，不带Order By</param>
        /// <param name="startRowIndex">开始行，0表示第一行</param>
        /// <param name="maximumRows">最大返回行数，0表示所有行</param>
        /// <returns>实体集</returns>
        [DataObjectMethod(DataObjectMethodType.Select, true)]
        public static EntityList<coupon> Search_Coupon_Number(String key, String orderClause, Int32 startRowIndex, Int32 maximumRows, string couponNum, int productId)
        {
            return FindAll(SearchWhere_Coupon_Number(key, couponNum, productId), orderClause, null, startRowIndex, maximumRows);
        }



        /// <summary>
        /// 查询满足条件的记录总数，分页和排序无效，带参数是因为ObjectDataSource要求它跟Search统一
        /// </summary>
        /// <param name="key">关键字</param>
        /// <param name="orderClause">排序，不带Order By</param>
        /// <param name="startRowIndex">开始行，0表示第一行</param>
        /// <param name="maximumRows">最大返回行数，0表示所有行</param>
        /// <returns>记录数</returns>
        public static Int32 SearchCountByCouponNum(String key, String orderClause, Int32 startRowIndex, Int32 maximumRows, string couponNum, int productId)
        {
            return FindCount(SearchWhere_Coupon_Number(key, couponNum, productId), null, null, 0, 0);
        }




        private static String SearchWhere_Coupon_Member(String key, string productIds)
        {
            // WhereExpression重载&和|运算符，作为And和Or的替代
            // SearchWhereByKeys系列方法用于构建针对字符串字段的模糊搜索
            var exp = SearchWhereByKeys(key, null);
            string [] sArray = productIds.Split('.');

            for (int i = 0; i < sArray.Length-1; i++)
            {
                exp |= _.productId == sArray[i];
            }

                
            // 以下仅为演示，Field（继承自FieldItem）重载了==、!=、>、<、>=、<=等运算符（第4行）
            //if (userid > 0) exp &= _.OperatorID == userid;
            //if (isSign != null) exp &= _.IsSign == isSign.Value;
            //if (start > DateTime.MinValue) exp &= _.OccurTime >= start;
            //if (end > DateTime.MinValue) exp &= _.OccurTime < end.AddDays(1).Date;

            return exp;
        }


        /// <summary>
        /// 查询满足条件的记录集，分页、排序
        /// </summary>
        /// <param name="key">关键字</param>
        /// <param name="orderClause">排序，不带Order By</param>
        /// <param name="startRowIndex">开始行，0表示第一行</param>
        /// <param name="maximumRows">最大返回行数，0表示所有行</param>
        /// <returns>实体集</returns>
        [DataObjectMethod(DataObjectMethodType.Select, true)]
        public static EntityList<coupon> Search_Coupon_Member(String key, String orderClause, Int32 startRowIndex, Int32 maximumRows, string productIds)
        {
            return FindAll(SearchWhere_Coupon_Member(key,  productIds), orderClause, null, startRowIndex, maximumRows);
        }

		#endregion

		#region 扩展操作

		#endregion

		#region 业务

		#endregion
	}
}