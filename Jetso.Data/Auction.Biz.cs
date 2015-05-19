﻿using System;
using System.ComponentModel;
using DmFramework.Data;
using System.Xml.Serialization;

namespace Jetso.Data
{
	/// <summary>竞投</summary>
	public partial class Auction : Entity<Auction>
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

			// 货币保留6位小数
			if (Dirtys[__.MarkPrice]) MarkPrice = Math.Round(MarkPrice, 6);

			// 货币保留6位小数
			if (Dirtys[__.BiddingPriceNow]) BiddingPriceNow = Math.Round(BiddingPriceNow, 6);

			// 货币保留6位小数
			if (Dirtys[__.EveryAddPrice]) EveryAddPrice = Math.Round(EveryAddPrice, 6);

			// 货币保留6位小数
			if (Dirtys[__.MinPrice]) MinPrice = Math.Round(MinPrice, 6);
			if (!Dirtys[__.UpdateTime]) UpdateTime = DateTime.Now;
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
		//    HmTrace.WriteDebug("开始初始化{0}[{1}]数据……", typeof(Auction).Name, Meta.Table.DataTable.DisplayName);

		//    var entity = new Auction();
		//    entity.ProductNo = "abc";
		//    entity.ProductName = "abc";
		//    entity.ProductBrief = "abc";
		//    entity.ProductDescription = "abc";
		//    entity.MarkPrice = 0;
		//    entity.BiddingPriceNow = 0;
		//    entity.StarTime = DateTime.Now;
		//    entity.TimeAddRange = "abc";
		//    entity.EveryAddPrice = 0;
		//    entity.EveryNeedPoint = 0;
		//    entity.MinPrice = 0;
		//    entity.BiddingLimitTime = DateTime.Now;
		//    entity.EndTime = DateTime.Now;
		//    entity.WinningBidder = "abc";
		//    entity.BidCount = 0;
		//    entity.ProductImage1 = "abc";
		//    entity.ProductImage2 = "abc";
		//    entity.ProductImage3 = "abc";
		//    entity.CreatTime = DateTime.Now;
		//    entity.UpdateTime = DateTime.Now;
		//    entity.Insert();

		//    HmTrace.WriteDebug("完成初始化{0}[{1}]数据！", typeof(Auction).Name, Meta.Table.DataTable.DisplayName);
		//}

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
    private member _member;
    /// <summary>该AuctionHistory所对应的member</summary>
    [XmlIgnore]
    public member member
    {
      get
      {
        if (_member == null && WinningBidder > 0 && !Dirtys.ContainsKey("member"))
        {
          _member = member.FindByID(WinningBidder);
          Dirtys["member"] = true;
        }
        return _member;
      }
      set { _member = value; }
    }

    /// <summary>该AuctionHistory所对应的member姓名</summary>
    [XmlIgnore]
    public String memberName { get { return member != null ? member.name : null; } }


    /// <summary>快件业务类别的枚举扩展属性</summary>
    [XmlIgnore]
    public AuctionStatusEnum AuctionStatusEnum
    {
      get { return (AuctionStatusEnum)AuctionSatus; }
      set { AuctionStatusEnum = value; }
    }
		#endregion

		#region 扩展查询﻿

		/// <summary>根据竞投ID查找</summary>
		/// <param name="id">竞投ID</param>
		/// <returns></returns>
		[DataObjectMethod(DataObjectMethodType.Select, false)]
		public static Auction FindByID(Int32 id)
		{
		//	if (Meta.Count >= 1000)
				return Find(_.ID, id);
      //else // 实体缓存
      //  return Meta.Cache.Entities.Find(_.ID, id);

			// 单对象缓存
			//return Meta.SingleCache[id];
		}

		/// <summary>根据竞投商品名称查找</summary>
		/// <param name="productname">竞投商品名称</param>
		/// <returns></returns>
		[DataObjectMethod(DataObjectMethodType.Select, false)]
		public static EntityList<Auction> FindAllByMemberIDandStatus(Int32 id,Int32 status)
		{
			if (Meta.Count >= 1000)
        return FindAll(new String[] { _.WinningBidder, _.AuctionSatus }, new Object[] { id, status });
			else // 实体缓存
        return Meta.Cache.Entities.FindAll(new String[] { _.WinningBidder, _.AuctionSatus }, new Object[] { id, status });
		}


    /// <summary>根据竞投商品名称查找</summary>
    /// <param name="productname">竞投商品名称</param>
    /// <returns></returns>
    [DataObjectMethod(DataObjectMethodType.Select, false)]
    public static EntityList<Auction> FindAllByProductName(String productname)
    {
      if (Meta.Count >= 1000)
        return FindAll(_.ProductName, productname);
      else // 实体缓存
        return Meta.Cache.Entities.FindAll(_.ProductName, productname);
    }
		#endregion

		#region 高级查询

		// 以下为自定义高级查询的例子

		/// <summary>
		/// 查询满足条件的记录集，分页、排序
		/// </summary>
		/// <param name="key">关键字</param>
		/// <param name="orderClause">排序，不带Order By</param>
		/// <param name="startRowIndex">开始行，0表示第一行</param>
		/// <param name="maximumRows">最大返回行数，0表示所有行</param>
		/// <returns>实体集</returns>
		[DataObjectMethod(DataObjectMethodType.Select, true)]
		public static EntityList<Auction> Search(String key, String orderClause,Int32 ID,bool isback, Int32 startRowIndex, Int32 maximumRows)
		{
			return FindAll(SearchWhere(key,ID,isback), orderClause, null, startRowIndex, maximumRows);
		}

		/// <summary>
		/// 查询满足条件的记录总数，分页和排序无效，带参数是因为ObjectDataSource要求它跟Search统一
		/// </summary>
		/// <param name="key">关键字</param>
		/// <param name="orderClause">排序，不带Order By</param>
		/// <param name="startRowIndex">开始行，0表示第一行</param>
		/// <param name="maximumRows">最大返回行数，0表示所有行</param>
		/// <returns>记录数</returns>
		public static Int32 SearchCount(String key, String orderClause ,Int32 ID,bool isback, Int32 startRowIndex, Int32 maximumRows)
		{
			return FindCount(SearchWhere(key,ID,isback), null, null, 0, 0);
		}

		/// <summary>构造搜索条件</summary>
		/// <param name="key">关键字</param>
		/// <returns></returns>
    private static String SearchWhere(String key, Int32 ID, bool isback)
		{
			// WhereExpression重载&和|运算符，作为And和Or的替代
			// SearchWhereByKeys系列方法用于构建针对字符串字段的模糊搜索
      var exp = new WhereExpression();
      if (ID != 0) 
      { 
			exp = SearchWhereByKeys(key, null);
      exp &= _.StarTime <= DateTime.Now;
      exp &= _.EndTime >= DateTime.Now;
			exp &= _.ID !=ID;
      }
      else
      {
        if (isback)
        {
          exp = SearchWhereByKeys(key, null);
        }
        else
        {
          exp = SearchWhereByKeys(key, null);
          exp &= _.StarTime <= DateTime.Now;
          exp &= _.EndTime >= DateTime.Now;
        }

      }
			//exp &= _.BiddingPriceNow < _.MinPrice;
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
    private static String SearchWhere(String key, bool isback)
    {
      // WhereExpression重载&和|运算符，作为And和Or的替代
      // SearchWhereByKeys系列方法用于构建针对字符串字段的模糊搜索
      var exp = new WhereExpression();
      if (isback)
      {
        exp = SearchWhereByKeys(key, null);
      }
      else
      {
        exp = SearchWhereByKeys(key, null);
        exp &= _.StarTime <= DateTime.Now;
        exp &= _.EndTime >= DateTime.Now;        
      }
      //exp &= _.BiddingPriceNow < _.MinPrice;
      // 以下仅为演示，Field（继承自FieldItem）重载了==、!=、>、<、>=、<=等运算符（第4行）
      //if (userid > 0) exp &= _.OperatorID == userid;
      //if (isSign != null) exp &= _.IsSign == isSign.Value;
      //if (start > DateTime.MinValue) exp &= _.OccurTime >= start;
      //if (end > DateTime.MinValue) exp &= _.OccurTime < end.AddDays(1).Date;

      return exp;
    }

    /// <summary>
    /// 查询满足条件的记录总数，分页和排序无效，带参数是因为ObjectDataSource要求它跟Search统一
    /// </summary>
    /// <param name="key">关键字</param>
    /// <param name="orderClause">排序，不带Order By</param>
    /// <param name="startRowIndex">开始行，0表示第一行</param>
    /// <param name="maximumRows">最大返回行数，0表示所有行</param>
    /// <returns>记录数</returns>
    public static Int32 SearchCount(String key, String orderClause, bool isback, Int32 startRowIndex, Int32 maximumRows)
    {
      return FindCount(SearchWhere(key, isback), null, null, 0, 0);
    }

    // 以下为自定义高级查询的例子

    /// <summary>
    /// 查询满足条件的记录集，分页、排序
    /// </summary>
    /// <param name="key">关键字</param>
    /// <param name="orderClause">排序，不带Order By</param>
    /// <param name="startRowIndex">开始行，0表示第一行</param>
    /// <param name="maximumRows">最大返回行数，0表示所有行</param>
    /// <returns>实体集</returns>
    [DataObjectMethod(DataObjectMethodType.Select, true)]
    public static EntityList<Auction> Search(String key, String orderClause,bool isback, Int32 startRowIndex, Int32 maximumRows)
    {
      return FindAll(SearchWhere(key, isback), orderClause, null, startRowIndex, maximumRows);
    }
		#endregion

		#region 扩展操作

		#endregion

		#region 业务

		#endregion
	}
}