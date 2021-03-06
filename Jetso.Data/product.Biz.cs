﻿﻿using System;
using System.ComponentModel;
using System.Xml.Serialization;
using DmFramework.Data;

namespace Jetso.Data
{
	/// <summary></summary>
	public partial class product : Entity<product>
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
		//    HmTrace.WriteDebug("开始初始化{0}[{1}]数据……", typeof(product).Name, Meta.Table.DataTable.DisplayName);

		//    var entity = new product();
		//    entity.typeId = 0;
		//    entity.provideId = 0;
		//    entity.productName = "abc";
		//    entity.productInfo = "abc";
		//    entity.productImgB = "abc";
		//    entity.productImgS = "abc";
		//    entity.couponImgB = "abc";
		//    entity.couponImgS = "abc";
		//    entity.productLink = "abc";
		//    entity.couponShortName = "abc";
		//    entity.modifiedTime = DateTime.Now;
		//    entity.createTime = DateTime.Now;
		//    entity.commission = "abc";
		//    entity.Insert();

		//    HmTrace.WriteDebug("完成初始化{0}[{1}]数据！", typeof(product).Name, Meta.Table.DataTable.DisplayName);
		//}

		/// <summary>已重载。删除关联数据</summary>
		/// <returns></returns>
		protected override int OnDelete()
		{
			if (adviews != null) adviews.Delete();
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
		private EntityList<adview> _adviews;

		/// <summary>该product所拥有的adview集合</summary>
		[XmlIgnore]
		public EntityList<adview> adviews
		{
			get
			{
				if (_adviews == null && ID > 0 && !Dirtys.ContainsKey("adviews"))
				{
					_adviews = adview.FindAllByproductId(ID);
					Dirtys["adviews"] = true;
				}
				return _adviews;
			}
			set { _adviews = value; }
		}

		[NonSerialized]
		private EntityList<coupon> _coupons;

		/// <summary>该product所拥有的coupon集合</summary>
		[XmlIgnore]
		public EntityList<coupon> coupons
		{
			get
			{
				if (_coupons == null && ID > 0 && !Dirtys.ContainsKey("coupons"))
				{
					_coupons = coupon.FindAllByproductId(ID);
					Dirtys["coupons"] = true;
				}
				return _coupons;
			}
			set { _coupons = value; }
		}

		[NonSerialized]
		private provide _provide;

		/// <summary>该product所对应的provide</summary>
		[XmlIgnore]
		public provide provide
		{
			get
			{
				if (_provide == null && provideId > 0 && !Dirtys.ContainsKey("provide"))
				{
					_provide = provide.FindByID(provideId);
					Dirtys["provide"] = true;
				}
				return _provide;
			}
			set { _provide = value; }
		}

		/// <summary>该product所对应的providename</summary>
		[XmlIgnore]
		public String provideName { get { return provide != null ? provide.name : null; } }

		#endregion

		#region 扩展查询﻿

		/// <summary>根据ID查找</summary>
		/// <param name="id"></param>
		/// <returns></returns>
		[DataObjectMethod(DataObjectMethodType.Select, false)]
		public static product FindByID(Int32 id)
		{
			if (Meta.Count >= 1000)
				return Find(_.ID, id);
			else // 实体缓存
				return Meta.Cache.Entities.Find(_.ID, id);

			// 单对象缓存
			//return Meta.SingleCache[id];
		}

		/// <summary>根据provideId查找</summary>
		/// <param name="provideid"></param>
		/// <returns></returns>
		[DataObjectMethod(DataObjectMethodType.Select, false)]
		public static EntityList<product> FindAllByprovideId(Int32 provideid)
		{
			if (Meta.Count >= 1000)
				return FindAll(_.provideId, provideid);
			else // 实体缓存
				return Meta.Cache.Entities.FindAll(_.provideId, provideid);
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
		//public static EntityList<product> Search(String key, String orderClause, Int32 startRowIndex, Int32 maximumRows)
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

		#endregion

		#region 扩展操作

		#endregion

		#region 业务

		#endregion
	}
}