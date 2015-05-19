﻿using System;
using System.ComponentModel;
using System.Xml.Serialization;
using DmFramework.Data;

namespace Jetso.Data
{
	/// <summary></summary>
	public partial class friend : Entity<friend>
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
		//    HmTrace.WriteDebug("开始初始化{0}[{1}]数据……", typeof(friend).Name, Meta.Table.DataTable.DisplayName);

		//    var entity = new friend();
		//    entity.memberId = 0;
		//    entity.couponId = 0;
		//    entity.name = "abc";
		//    entity.isJoin = "abc";
		//    entity.email = "abc";
		//    entity.inventTime = DateTime.Now;
		//    entity.joinTime = DateTime.Now;
		//    entity.Insert();

		//    HmTrace.WriteDebug("完成初始化{0}[{1}]数据！", typeof(friend).Name, Meta.Table.DataTable.DisplayName);
		//}

		/// <summary>已重载。删除关联数据</summary>
		/// <returns></returns>
		protected override int OnDelete()
		{
			if (coupons != null) coupons.Delete();

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
		private EntityList<coupon> _coupons;

		/// <summary>该friend所拥有的coupon集合</summary>
		[XmlIgnore]
		public EntityList<coupon> coupons
		{
			get
			{
				if (_coupons == null && id > 0 && !Dirtys.ContainsKey("coupons"))
				{
					_coupons = coupon.FindAllByfriendId(id);
					Dirtys["coupons"] = true;
				}
				return _coupons;
			}
			set { _coupons = value; }
		}

		//[NonSerialized]
		//private member _member;

		///// <summary>该friend所对应的member</summary>
		//[XmlIgnore]
		//public member member
		//{
		//	get
		//	{
		//		if (_member == null && memberId > 0 && !Dirtys.ContainsKey("member"))
		//		{
		//			_member = member.FindByID(memberId);
		//			Dirtys["member"] = true;
		//		}
		//		return _member;
		//	}
		//	set { _member = value; }
		//}

		///// <summary>该friend所对应的member姓名</summary>
		//[XmlIgnore]
		//public String memberName { get { return member != null ? member.name : null; } }

		#endregion

		#region 扩展查询﻿

		/// <summary>根据email查找</summary>
		/// <param name="__email"></param>
		/// <returns></returns>
		[DataObjectMethod(DataObjectMethodType.Select, false)]
		public static friend FindByEmail(string __email)
		{
			if (Meta.Count >= 1000)
				return Find(_.email, __email);
			else // 实体缓存
				return Meta.Cache.Entities.Find(_.email, __email);

			// 单对象缓存
			//return Meta.SingleCache[__id];
		}

		/// <summary>根据id查找</summary>
		/// <param name="__id"></param>
		/// <returns></returns>
		[DataObjectMethod(DataObjectMethodType.Select, false)]
		public static friend FindByid(Int32 __id)
		{
			if (Meta.Count >= 1000)
				return Find(_.id, __id);
			else // 实体缓存
				return Meta.Cache.Entities.Find(_.id, __id);

			// 单对象缓存
			//return Meta.SingleCache[__id];
		}

		/// <summary>根据email查找</summary>
		/// <param name="__email"></param>
		/// <returns></returns>
		[DataObjectMethod(DataObjectMethodType.Select, false)]
		public static EntityList<friend> FindAllByemail(String __email)
		{
			if (Meta.Count >= 1000)
				return FindAll(_.email, __email);
			else // 实体缓存
				return Meta.Cache.Entities.FindAll(_.email, __email);
		}



		/// <summary>根据memberId查找</summary>
		/// <param name="memberid"></param>
		/// <returns></returns>
		[DataObjectMethod(DataObjectMethodType.Select, false)]
		public static EntityList<friend> FindAllBymemberId(Int32 memberid)
		{
			if (Meta.Count >= 1000)
				return FindAll(_.memberId, memberid);
			else // 实体缓存
				return Meta.Cache.Entities.FindAll(_.memberId, memberid);
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
		//public static EntityList<friend> Search(String key, String orderClause, Int32 startRowIndex, Int32 maximumRows)
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


        private static String SearchWhere_Member(String key , Int32 memberId)
        {
            // WhereExpression重载&和|运算符，作为And和Or的替代
            // SearchWhereByKeys系列方法用于构建针对字符串字段的模糊搜索
            var exp = SearchWhereByKeys(key, null);
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
        public static EntityList<friend> Search_Member(String key, String orderClause, Int32 startRowIndex, Int32 maximumRows, Int32 memberId)
        {
            return FindAll(SearchWhere_Member(key, memberId), orderClause, null, startRowIndex, maximumRows);
        }

		#endregion

		#region 扩展操作

		#endregion

		#region 业务

		#endregion
	}
}