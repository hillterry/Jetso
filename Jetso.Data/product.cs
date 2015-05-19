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
	[BindIndex("PK_PRODUCT", true, "ID")]
	[BindIndex("IX_product_provideId", false, "provideId")]
	[BindRelation("ID", true, "adview", "productId")]
	[BindRelation("ID", true, "coupon", "productId")]
	[BindRelation("provideId", false, "provide", "ID")]
	[BindTable("product", Description = "", ConnName = "CommonBilling", DbType = DatabaseType.SqlServer)]
	public partial class product : Iproduct
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

		private Int32 _typeId;

		/// <summary></summary>
		[DisplayName("typeId")]
		[Description("")]
		[DataObjectField(false, false, true, 10)]
		[BindColumn(2, "typeId", "", null, "int", 10, 0, false)]
		public virtual Int32 typeId
		{
			get { return _typeId; }
			set { if (OnPropertyChanging(__.typeId, value)) { _typeId = value; OnPropertyChanged(__.typeId); } }
		}

		private Int32 _provideId;

		/// <summary></summary>
		[DisplayName("provideId")]
		[Description("")]
		[DataObjectField(false, false, true, 10)]
		[BindColumn(3, "provideId", "", null, "int", 10, 0, false)]
		public virtual Int32 provideId
		{
			get { return _provideId; }
			set { if (OnPropertyChanging(__.provideId, value)) { _provideId = value; OnPropertyChanged(__.provideId); } }
		}

		private String _productName;

		/// <summary></summary>
		[DisplayName("productName")]
		[Description("")]
		[DataObjectField(false, false, true, 30)]
		[BindColumn(4, "productName", "", null, "varchar(30)", 0, 0, false)]
		public virtual String productName
		{
			get { return _productName; }
			set { if (OnPropertyChanging(__.productName, value)) { _productName = value; OnPropertyChanged(__.productName); } }
		}

		private String _productInfo;

		/// <summary></summary>
		[DisplayName("productInfo")]
		[Description("")]
		[DataObjectField(false, false, true, 500)]
		[BindColumn(5, "productInfo", "", null, "varchar(500)", 0, 0, false)]
		public virtual String productInfo
		{
			get { return _productInfo; }
			set { if (OnPropertyChanging(__.productInfo, value)) { _productInfo = value; OnPropertyChanged(__.productInfo); } }
		}

		private String _productImgB;

		/// <summary></summary>
		[DisplayName("productImgB")]
		[Description("")]
		[DataObjectField(false, false, true, 200)]
		[BindColumn(6, "productImgB", "", null, "varchar(200)", 0, 0, false)]
		public virtual String productImgB
		{
			get { return _productImgB; }
			set { if (OnPropertyChanging(__.productImgB, value)) { _productImgB = value; OnPropertyChanged(__.productImgB); } }
		}

		private String _productImgS;

		/// <summary></summary>
		[DisplayName("productImgS")]
		[Description("")]
		[DataObjectField(false, false, true, 200)]
		[BindColumn(7, "productImgS", "", null, "varchar(200)", 0, 0, false)]
		public virtual String productImgS
		{
			get { return _productImgS; }
			set { if (OnPropertyChanging(__.productImgS, value)) { _productImgS = value; OnPropertyChanged(__.productImgS); } }
		}

		private String _couponImgB;

		/// <summary></summary>
		[DisplayName("couponImgB")]
		[Description("")]
		[DataObjectField(false, false, true, 200)]
		[BindColumn(8, "couponImgB", "", null, "varchar(200)", 0, 0, false)]
		public virtual String couponImgB
		{
			get { return _couponImgB; }
			set { if (OnPropertyChanging(__.couponImgB, value)) { _couponImgB = value; OnPropertyChanged(__.couponImgB); } }
		}

		private String _couponImgS;

		/// <summary></summary>
		[DisplayName("couponImgS")]
		[Description("")]
		[DataObjectField(false, false, true, 200)]
		[BindColumn(9, "couponImgS", "", null, "varchar(200)", 0, 0, false)]
		public virtual String couponImgS
		{
			get { return _couponImgS; }
			set { if (OnPropertyChanging(__.couponImgS, value)) { _couponImgS = value; OnPropertyChanged(__.couponImgS); } }
		}

		private String _productLink;

		/// <summary></summary>
		[DisplayName("productLink")]
		[Description("")]
		[DataObjectField(false, false, true, 100)]
		[BindColumn(10, "productLink", "", null, "varchar(100)", 0, 0, false)]
		public virtual String productLink
		{
			get { return _productLink; }
			set { if (OnPropertyChanging(__.productLink, value)) { _productLink = value; OnPropertyChanged(__.productLink); } }
		}

		private String _couponShortName;

		/// <summary></summary>
		[DisplayName("couponShortName")]
		[Description("")]
		[DataObjectField(false, false, true, 20)]
		[BindColumn(11, "couponShortName", "", null, "varchar(20)", 0, 0, false)]
		public virtual String couponShortName
		{
			get { return _couponShortName; }
			set { if (OnPropertyChanging(__.couponShortName, value)) { _couponShortName = value; OnPropertyChanged(__.couponShortName); } }
		}

		private DateTime _modifiedTime;

		/// <summary></summary>
		[DisplayName("modifiedTime")]
		[Description("")]
		[DataObjectField(false, false, true, 3)]
		[BindColumn(12, "modifiedTime", "", null, "datetime", 3, 0, false)]
		public virtual DateTime modifiedTime
		{
			get { return _modifiedTime; }
			set { if (OnPropertyChanging(__.modifiedTime, value)) { _modifiedTime = value; OnPropertyChanged(__.modifiedTime); } }
		}

		private DateTime _createTime;

		/// <summary></summary>
		[DisplayName("createTime")]
		[Description("")]
		[DataObjectField(false, false, true, 3)]
		[BindColumn(13, "createTime", "", null, "datetime", 3, 0, false)]
		public virtual DateTime createTime
		{
			get { return _createTime; }
			set { if (OnPropertyChanging(__.createTime, value)) { _createTime = value; OnPropertyChanged(__.createTime); } }
		}

		private String _commission;

		/// <summary></summary>
		[DisplayName("commission")]
		[Description("")]
		[DataObjectField(false, false, true, 100)]
		[BindColumn(14, "commission", "", null, "varchar(100)", 0, 0, false)]
		public virtual String commission
		{
			get { return _commission; }
			set { if (OnPropertyChanging(__.commission, value)) { _commission = value; OnPropertyChanged(__.commission); } }
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
					case __.typeId: return _typeId;
					case __.provideId: return _provideId;
					case __.productName: return _productName;
					case __.productInfo: return _productInfo;
					case __.productImgB: return _productImgB;
					case __.productImgS: return _productImgS;
					case __.couponImgB: return _couponImgB;
					case __.couponImgS: return _couponImgS;
					case __.productLink: return _productLink;
					case __.couponShortName: return _couponShortName;
					case __.modifiedTime: return _modifiedTime;
					case __.createTime: return _createTime;
					case __.commission: return _commission;
					default: return base[name];
				}
			}
			set
			{
				switch (name)
				{
					case __.ID: _ID = Convert.ToInt32(value); break;
					case __.typeId: _typeId = Convert.ToInt32(value); break;
					case __.provideId: _provideId = Convert.ToInt32(value); break;
					case __.productName: _productName = Convert.ToString(value); break;
					case __.productInfo: _productInfo = Convert.ToString(value); break;
					case __.productImgB: _productImgB = Convert.ToString(value); break;
					case __.productImgS: _productImgS = Convert.ToString(value); break;
					case __.couponImgB: _couponImgB = Convert.ToString(value); break;
					case __.couponImgS: _couponImgS = Convert.ToString(value); break;
					case __.productLink: _productLink = Convert.ToString(value); break;
					case __.couponShortName: _couponShortName = Convert.ToString(value); break;
					case __.modifiedTime: _modifiedTime = Convert.ToDateTime(value); break;
					case __.createTime: _createTime = Convert.ToDateTime(value); break;
					case __.commission: _commission = Convert.ToString(value); break;
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
			public static readonly Field typeId = FindByName(__.typeId);

			///<summary></summary>
			public static readonly Field provideId = FindByName(__.provideId);

			///<summary></summary>
			public static readonly Field productName = FindByName(__.productName);

			///<summary></summary>
			public static readonly Field productInfo = FindByName(__.productInfo);

			///<summary></summary>
			public static readonly Field productImgB = FindByName(__.productImgB);

			///<summary></summary>
			public static readonly Field productImgS = FindByName(__.productImgS);

			///<summary></summary>
			public static readonly Field couponImgB = FindByName(__.couponImgB);

			///<summary></summary>
			public static readonly Field couponImgS = FindByName(__.couponImgS);

			///<summary></summary>
			public static readonly Field productLink = FindByName(__.productLink);

			///<summary></summary>
			public static readonly Field couponShortName = FindByName(__.couponShortName);

			///<summary></summary>
			public static readonly Field modifiedTime = FindByName(__.modifiedTime);

			///<summary></summary>
			public static readonly Field createTime = FindByName(__.createTime);

			///<summary></summary>
			public static readonly Field commission = FindByName(__.commission);

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
			public const String typeId = "typeId";

			///<summary></summary>
			public const String provideId = "provideId";

			///<summary></summary>
			public const String productName = "productName";

			///<summary></summary>
			public const String productInfo = "productInfo";

			///<summary></summary>
			public const String productImgB = "productImgB";

			///<summary></summary>
			public const String productImgS = "productImgS";

			///<summary></summary>
			public const String couponImgB = "couponImgB";

			///<summary></summary>
			public const String couponImgS = "couponImgS";

			///<summary></summary>
			public const String productLink = "productLink";

			///<summary></summary>
			public const String couponShortName = "couponShortName";

			///<summary></summary>
			public const String modifiedTime = "modifiedTime";

			///<summary></summary>
			public const String createTime = "createTime";

			///<summary></summary>
			public const String commission = "commission";
		}

		#endregion
	}

	/// <summary>接口</summary>
	public partial interface Iproduct
	{
		#region 属性

		/// <summary></summary>
		Int32 ID { get; set; }

		/// <summary></summary>
		Int32 typeId { get; set; }

		/// <summary></summary>
		Int32 provideId { get; set; }

		/// <summary></summary>
		String productName { get; set; }

		/// <summary></summary>
		String productInfo { get; set; }

		/// <summary></summary>
		String productImgB { get; set; }

		/// <summary></summary>
		String productImgS { get; set; }

		/// <summary></summary>
		String couponImgB { get; set; }

		/// <summary></summary>
		String couponImgS { get; set; }

		/// <summary></summary>
		String productLink { get; set; }

		/// <summary></summary>
		String couponShortName { get; set; }

		/// <summary></summary>
		DateTime modifiedTime { get; set; }

		/// <summary></summary>
		DateTime createTime { get; set; }

		/// <summary></summary>
		String commission { get; set; }

		#endregion

		#region 获取/设置 字段值

		/// <summary>获取/设置 字段值。</summary>
		/// <param name="name">字段名</param>
		/// <returns></returns>
		Object this[String name] { get; set; }

		#endregion
	}
}