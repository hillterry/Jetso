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
	[BindIndex("PK_PRODUCETYPE", true, "typeId")]
	[BindTable("producetype", Description = "", ConnName = "CommonBilling", DbType = DatabaseType.SqlServer)]
	public partial class producetype : Iproducetype
	{
		#region 属性

		private Int32 _typeId;

		/// <summary></summary>
		[DisplayName("typeId")]
		[Description("")]
		[DataObjectField(true, true, false, 10)]
		[BindColumn(1, "typeId", "", null, "int", 10, 0, false)]
		public virtual Int32 typeId
		{
			get { return _typeId; }
			set { if (OnPropertyChanging(__.typeId, value)) { _typeId = value; OnPropertyChanged(__.typeId); } }
		}

		private String _typeName;

		/// <summary></summary>
		[DisplayName("typeName")]
		[Description("")]
		[DataObjectField(false, false, true, 20)]
		[BindColumn(2, "typeName", "", null, "varchar(20)", 0, 0, false)]
		public virtual String typeName
		{
			get { return _typeName; }
			set { if (OnPropertyChanging(__.typeName, value)) { _typeName = value; OnPropertyChanged(__.typeName); } }
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
					case __.typeId: return _typeId;
					case __.typeName: return _typeName;
					default: return base[name];
				}
			}
			set
			{
				switch (name)
				{
					case __.typeId: _typeId = Convert.ToInt32(value); break;
					case __.typeName: _typeName = Convert.ToString(value); break;
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
			public static readonly Field typeId = FindByName(__.typeId);

			///<summary></summary>
			public static readonly Field typeName = FindByName(__.typeName);

			private static Field FindByName(String name)
			{
				return Meta.Table.FindByName(name);
			}
		}

		/// <summary>取得字段名称的快捷方式</summary>
		public partial class __
		{
			///<summary></summary>
			public const String typeId = "typeId";

			///<summary></summary>
			public const String typeName = "typeName";
		}

		#endregion
	}

	/// <summary>接口</summary>
	public partial interface Iproducetype
	{
		#region 属性

		/// <summary></summary>
		Int32 typeId { get; set; }

		/// <summary></summary>
		String typeName { get; set; }

		#endregion

		#region 获取/设置 字段值

		/// <summary>获取/设置 字段值。</summary>
		/// <param name="name">字段名</param>
		/// <returns></returns>
		Object this[String name] { get; set; }

		#endregion
	}
}