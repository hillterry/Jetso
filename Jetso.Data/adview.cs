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
	[BindIndex("PK_ADVIEW", true, "id")]
	[BindIndex("IX_adview_productId", false, "productId")]
	[BindRelation("productId", false, "product", "ID")]
	[BindTable("adview", Description = "", ConnName = "CommonBilling", DbType = DatabaseType.SqlServer)]
	public partial class adview : Iadview
	{
		#region 属性

		private Int32 _id;

		/// <summary></summary>
		[DisplayName("id")]
		[Description("")]
		[DataObjectField(true, true, false, 10)]
		[BindColumn(1, "id", "", null, "int", 10, 0, false)]
		public virtual Int32 id
		{
			get { return _id; }
			set { if (OnPropertyChanging(__.id, value)) { _id = value; OnPropertyChanged(__.id); } }
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

		private String _hostip;

		/// <summary></summary>
		[DisplayName("hostip")]
		[Description("")]
		[DataObjectField(false, false, true, 50)]
		[BindColumn(3, "hostip", "", null, "varchar(50)", 0, 0, false)]
		public virtual String hostip
		{
			get { return _hostip; }
			set { if (OnPropertyChanging(__.hostip, value)) { _hostip = value; OnPropertyChanged(__.hostip); } }
		}

		private DateTime _createTime;

		/// <summary></summary>
		[DisplayName("createTime")]
		[Description("")]
		[DataObjectField(false, false, true, 3)]
		[BindColumn(4, "createTime", "", null, "datetime", 3, 0, false)]
		public virtual DateTime createTime
		{
			get { return _createTime; }
			set { if (OnPropertyChanging(__.createTime, value)) { _createTime = value; OnPropertyChanged(__.createTime); } }
		}

		private String _hostadress;

		/// <summary></summary>
		[DisplayName("hostadress")]
		[Description("")]
		[DataObjectField(false, false, true, 100)]
		[BindColumn(5, "hostadress", "", null, "varchar(100)", 0, 0, false)]
		public virtual String hostadress
		{
			get { return _hostadress; }
			set { if (OnPropertyChanging(__.hostadress, value)) { _hostadress = value; OnPropertyChanged(__.hostadress); } }
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
					case __.id: return _id;
					case __.productId: return _productId;
					case __.hostip: return _hostip;
					case __.createTime: return _createTime;
					case __.hostadress: return _hostadress;
					default: return base[name];
				}
			}
			set
			{
				switch (name)
				{
					case __.id: _id = Convert.ToInt32(value); break;
					case __.productId: _productId = Convert.ToInt32(value); break;
					case __.hostip: _hostip = Convert.ToString(value); break;
					case __.createTime: _createTime = Convert.ToDateTime(value); break;
					case __.hostadress: _hostadress = Convert.ToString(value); break;
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
			public static readonly Field id = FindByName(__.id);

			///<summary></summary>
			public static readonly Field productId = FindByName(__.productId);

			///<summary></summary>
			public static readonly Field hostip = FindByName(__.hostip);

			///<summary></summary>
			public static readonly Field createTime = FindByName(__.createTime);

			///<summary></summary>
			public static readonly Field hostadress = FindByName(__.hostadress);

			private static Field FindByName(String name)
			{
				return Meta.Table.FindByName(name);
			}
		}

		/// <summary>取得字段名称的快捷方式</summary>
		public partial class __
		{
			///<summary></summary>
			public const String id = "id";

			///<summary></summary>
			public const String productId = "productId";

			///<summary></summary>
			public const String hostip = "hostip";

			///<summary></summary>
			public const String createTime = "createTime";

			///<summary></summary>
			public const String hostadress = "hostadress";
		}

		#endregion
	}

	/// <summary>接口</summary>
	public partial interface Iadview
	{
		#region 属性

		/// <summary></summary>
		Int32 id { get; set; }

		/// <summary></summary>
		Int32 productId { get; set; }

		/// <summary></summary>
		String hostip { get; set; }

		/// <summary></summary>
		DateTime createTime { get; set; }

		/// <summary></summary>
		String hostadress { get; set; }

		#endregion

		#region 获取/设置 字段值

		/// <summary>获取/设置 字段值。</summary>
		/// <param name="name">字段名</param>
		/// <returns></returns>
		Object this[String name] { get; set; }

		#endregion
	}
}