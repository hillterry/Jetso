﻿using System;
using System.ComponentModel;
using DmFramework.Data;
using DmFramework.Data.Configuration;
using DmFramework.Data.DataAccessLayer;

namespace Jetso.Data
{
	/// <summary></summary>
	[Serializable]
	[DataObject]
	[Description("")]
	[BindIndex("PK_COUPON", true, "ID")]
	[BindIndex("IX_coupon_friendId", false, "friendId")]
	[BindIndex("IX_coupon_friendEmail", false, "friendEmail")]
	[BindIndex("IX_coupon_memberId", false, "memberId")]
	[BindIndex("IX_coupon_productId", false, "productId")]
	[BindRelation("friendId", false, "friend", "id")]
	[BindRelation("friendEmail", false, "friend", "email")]
	[BindRelation("memberId", false, "member", "ID")]
	[BindRelation("productId", false, "product", "ID")]
	[BindRelation("ID", true, "friend", "couponId")]
	[BindTable("coupon", Description = "", ConnName = "CommonBilling", DbType = DatabaseType.SqlServer)]
	public partial class coupon : Icoupon
	{
		#region 属性

		private Int32 _ID;

		/// <summary></summary>
		[DisplayName("ID")]
		[Description("")]
		[DataObjectField(true, true, false, 10)]
		[BindColumn(1, "ID", "", null, "int", 10, 0, false)]
		public virtual Int32 ID
		{
			get { return _ID; }
			set { if (OnPropertyChanging(__.ID, value)) { _ID = value; OnPropertyChanged(__.ID); } }
		}

		private Int32 _productId;

		/// <summary></summary>
		[DisplayName("productId")]
		[Description("")]
		[DataObjectField(false, false, true, 10)]
		[BindColumn(2, "productId", "", null, "int", 10, 0, false)]
		public virtual Int32 productId
		{
			get { return _productId; }
			set { if (OnPropertyChanging(__.productId, value)) { _productId = value; OnPropertyChanged(__.productId); } }
		}

		private Int32 _memberId;

		/// <summary></summary>
		[DisplayName("memberId")]
		[Description("")]
		[DataObjectField(false, false, true, 10)]
		[BindColumn(3, "memberId", "", null, "int", 10, 0, false)]
		public virtual Int32 memberId
		{
			get { return _memberId; }
			set { if (OnPropertyChanging(__.memberId, value)) { _memberId = value; OnPropertyChanged(__.memberId); } }
		}

		private String _cuponNumber;

		/// <summary></summary>
		[DisplayName("cuponNumber")]
		[Description("")]
		[DataObjectField(false, false, true, 20)]
		[BindColumn(4, "cuponNumber", "", null, "varchar(20)", 0, 0, false)]
		public virtual String cuponNumber
		{
			get { return _cuponNumber; }
			set { if (OnPropertyChanging(__.cuponNumber, value)) { _cuponNumber = value; OnPropertyChanged(__.cuponNumber); } }
		}

		private Int32 _isLive;

		/// <summary></summary>
		[DisplayName("isLive")]
		[Description("")]
		[DataObjectField(false, false, true, 10)]
		[BindColumn(5, "isLive", "", null, "int", 10, 0, false)]
		public virtual Int32 isLive
		{
			get { return _isLive; }
			set { if (OnPropertyChanging(__.isLive, value)) { _isLive = value; OnPropertyChanged(__.isLive); } }
		}

		private DateTime _createTime;

		/// <summary></summary>
		[DisplayName("createTime")]
		[Description("")]
		[DataObjectField(false, false, true, 3)]
		[BindColumn(6, "createTime", "", null, "datetime", 3, 0, false)]
		public virtual DateTime createTime
		{
			get { return _createTime; }
			set { if (OnPropertyChanging(__.createTime, value)) { _createTime = value; OnPropertyChanged(__.createTime); } }
		}

		private String _billImg;

		/// <summary></summary>
		[DisplayName("billImg")]
		[Description("")]
		[DataObjectField(false, false, true, 200)]
		[BindColumn(7, "billImg", "", null, "varchar(200)", 0, 0, false)]
		public virtual String billImg
		{
			get { return _billImg; }
			set { if (OnPropertyChanging(__.billImg, value)) { _billImg = value; OnPropertyChanged(__.billImg); } }
		}

		private DateTime _serviceTime;

		/// <summary></summary>
		[DisplayName("serviceTime")]
		[Description("")]
		[DataObjectField(false, false, true, 3)]
		[BindColumn(8, "serviceTime", "", null, "datetime", 3, 0, false)]
		public virtual DateTime serviceTime
		{
			get { return _serviceTime; }
			set { if (OnPropertyChanging(__.serviceTime, value)) { _serviceTime = value; OnPropertyChanged(__.serviceTime); } }
		}

		private Double _serviceMoney;

		/// <summary></summary>
		[DisplayName("serviceMoney")]
		[Description("")]
		[DataObjectField(false, false, true, 53)]
		[BindColumn(9, "serviceMoney", "", null, "float", 53, 0, false)]
		public virtual Double serviceMoney
		{
			get { return _serviceMoney; }
			set { if (OnPropertyChanging(__.serviceMoney, value)) { _serviceMoney = value; OnPropertyChanged(__.serviceMoney); } }
		}

		private Int32 _friendId;

		/// <summary></summary>
		[DisplayName("friendId")]
		[Description("")]
		[DataObjectField(false, false, true, 10)]
		[BindColumn(10, "friendId", "", null, "int", 10, 0, false)]
		public virtual Int32 friendId
		{
			get { return _friendId; }
			set { if (OnPropertyChanging(__.friendId, value)) { _friendId = value; OnPropertyChanged(__.friendId); } }
		}

		private String _friendEmail;

		/// <summary></summary>
		[DisplayName("friendEmail")]
		[Description("")]
		[DataObjectField(false, false, true, 50)]
		[BindColumn(11, "friendEmail", "", null, "varchar(50)", 0, 0, false)]
		public virtual String friendEmail
		{
			get { return _friendEmail; }
			set { if (OnPropertyChanging(__.friendEmail, value)) { _friendEmail = value; OnPropertyChanged(__.friendEmail); } }
		}

		private String _billNumber;

		/// <summary></summary>
		[DisplayName("billNumber")]
		[Description("")]
		[DataObjectField(false, false, true, 100)]
		[BindColumn(12, "billNumber", "", null, "varchar(100)", 0, 0, false)]
		public virtual String billNumber
		{
			get { return _billNumber; }
			set { if (OnPropertyChanging(__.billNumber, value)) { _billNumber = value; OnPropertyChanged(__.billNumber); } }
		}

		private String _friendRegEmail;

		/// <summary></summary>
		[DisplayName("friendRegEmail")]
		[Description("")]
		[DataObjectField(false, false, true, 200)]
		[BindColumn(13, "friendRegEmail", "", null, "varchar(200)", 0, 0, false)]
		public virtual String friendRegEmail
		{
			get { return _friendRegEmail; }
			set { if (OnPropertyChanging(__.friendRegEmail, value)) { _friendRegEmail = value; OnPropertyChanged(__.friendRegEmail); } }
		}

		private Int32 _viewable;

		/// <summary></summary>
		[DisplayName("viewable")]
		[Description("")]
		[DataObjectField(false, false, true, 10)]
		[BindColumn(14, "viewable", "", "1", "int", 10, 0, false)]
		public virtual Int32 viewable
		{
			get { return _viewable; }
			set { if (OnPropertyChanging(__.viewable, value)) { _viewable = value; OnPropertyChanged(__.viewable); } }
		}

		#endregion

		#region 获取/设置 字段值

		/// <summary>
		/// 获取/设置 字段值。
		/// 一个索引，基类使用反射实现。
		/// 派生实体类可重写该索引，以避免反射带来的性能损耗
		/// </summary>
		/// <param name="name">字段名</param>
		/// <returns></returns>
		public override Object this[String name]
		{
			get
			{
				switch (name)
				{
					case __.ID: return _ID;
					case __.productId: return _productId;
					case __.memberId: return _memberId;
					case __.cuponNumber: return _cuponNumber;
					case __.isLive: return _isLive;
					case __.createTime: return _createTime;
					case __.billImg: return _billImg;
					case __.serviceTime: return _serviceTime;
					case __.serviceMoney: return _serviceMoney;
					case __.friendId: return _friendId;
					case __.friendEmail: return _friendEmail;
					case __.billNumber: return _billNumber;
					case __.friendRegEmail: return _friendRegEmail;
					case __.viewable: return _viewable;
					default: return base[name];
				}
			}
			set
			{
				switch (name)
				{
					case __.ID: _ID = Convert.ToInt32(value); break;
					case __.productId: _productId = Convert.ToInt32(value); break;
					case __.memberId: _memberId = Convert.ToInt32(value); break;
					case __.cuponNumber: _cuponNumber = Convert.ToString(value); break;
					case __.isLive: _isLive = Convert.ToInt32(value); break;
					case __.createTime: _createTime = Convert.ToDateTime(value); break;
					case __.billImg: _billImg = Convert.ToString(value); break;
					case __.serviceTime: _serviceTime = Convert.ToDateTime(value); break;
					case __.serviceMoney: _serviceMoney = Convert.ToDouble(value); break;
					case __.friendId: _friendId = Convert.ToInt32(value); break;
					case __.friendEmail: _friendEmail = Convert.ToString(value); break;
					case __.billNumber: _billNumber = Convert.ToString(value); break;
					case __.friendRegEmail: _friendRegEmail = Convert.ToString(value); break;
					case __.viewable: _viewable = Convert.ToInt32(value); break;
					default: base[name] = value; break;
				}
			}
		}

		#endregion

		#region 字段名

		/// <summary>取得字段信息的快捷方式</summary>
		public partial class _
		{
			///<summary></summary>
			public static readonly Field ID = FindByName(__.ID);

			///<summary></summary>
			public static readonly Field productId = FindByName(__.productId);

			///<summary></summary>
			public static readonly Field memberId = FindByName(__.memberId);

			///<summary></summary>
			public static readonly Field cuponNumber = FindByName(__.cuponNumber);

			///<summary></summary>
			public static readonly Field isLive = FindByName(__.isLive);

			///<summary></summary>
			public static readonly Field createTime = FindByName(__.createTime);

			///<summary></summary>
			public static readonly Field billImg = FindByName(__.billImg);

			///<summary></summary>
			public static readonly Field serviceTime = FindByName(__.serviceTime);

			///<summary></summary>
			public static readonly Field serviceMoney = FindByName(__.serviceMoney);

			///<summary></summary>
			public static readonly Field friendId = FindByName(__.friendId);

			///<summary></summary>
			public static readonly Field friendEmail = FindByName(__.friendEmail);

			///<summary></summary>
			public static readonly Field billNumber = FindByName(__.billNumber);

			///<summary></summary>
			public static readonly Field friendRegEmail = FindByName(__.friendRegEmail);

			///<summary></summary>
			public static readonly Field viewable = FindByName(__.viewable);

			private static Field FindByName(String name)
			{
				return Meta.Table.FindByName(name);
			}
		}

		/// <summary>取得字段名称的快捷方式</summary>
		public partial class __
		{
			///<summary></summary>
			public const String ID = "ID";

			///<summary></summary>
			public const String productId = "productId";

			///<summary></summary>
			public const String memberId = "memberId";

			///<summary></summary>
			public const String cuponNumber = "cuponNumber";

			///<summary></summary>
			public const String isLive = "isLive";

			///<summary></summary>
			public const String createTime = "createTime";

			///<summary></summary>
			public const String billImg = "billImg";

			///<summary></summary>
			public const String serviceTime = "serviceTime";

			///<summary></summary>
			public const String serviceMoney = "serviceMoney";

			///<summary></summary>
			public const String friendId = "friendId";

			///<summary></summary>
			public const String friendEmail = "friendEmail";

			///<summary></summary>
			public const String billNumber = "billNumber";

			///<summary></summary>
			public const String friendRegEmail = "friendRegEmail";

			///<summary></summary>
			public const String viewable = "viewable";
		}

		#endregion
	}

	/// <summary>接口</summary>
	public partial interface Icoupon
	{
		#region 属性

		/// <summary></summary>
		Int32 ID { get; set; }

		/// <summary></summary>
		Int32 productId { get; set; }

		/// <summary></summary>
		Int32 memberId { get; set; }

		/// <summary></summary>
		String cuponNumber { get; set; }

		/// <summary></summary>
		Int32 isLive { get; set; }

		/// <summary></summary>
		DateTime createTime { get; set; }

		/// <summary></summary>
		String billImg { get; set; }

		/// <summary></summary>
		DateTime serviceTime { get; set; }

		/// <summary></summary>
		Double serviceMoney { get; set; }

		/// <summary></summary>
		Int32 friendId { get; set; }

		/// <summary></summary>
		String friendEmail { get; set; }

		/// <summary></summary>
		String billNumber { get; set; }

		/// <summary></summary>
		String friendRegEmail { get; set; }

		/// <summary></summary>
		Int32 viewable { get; set; }

		#endregion

		#region 获取/设置 字段值

		/// <summary>获取/设置 字段值。</summary>
		/// <param name="name">字段名</param>
		/// <returns></returns>
		Object this[String name] { get; set; }

		#endregion
	}
}