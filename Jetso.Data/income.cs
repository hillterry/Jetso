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
	[BindIndex("PK__income__3214EC071BFD2C07", true, "Id")]
	[BindTable("income", Description = "", ConnName = "CommonBilling", DbType = DatabaseType.SqlServer)]
	public partial class income : Iincome
	{
		#region 属性

		private Int32 _Id;

		/// <summary></summary>
		[DisplayName("Id")]
		[Description("")]
		[DataObjectField(true, false, false, 10)]
		[BindColumn(1, "Id", "", null, "int", 10, 0, false)]
		public virtual Int32 Id
		{
			get { return _Id; }
			set { if (OnPropertyChanging(__.Id, value)) { _Id = value; OnPropertyChanged(__.Id); } }
		}

		private String _value;

		/// <summary></summary>
		[DisplayName("value")]
		[Description("")]
		[DataObjectField(false, false, true, 100)]
		[BindColumn(2, "value", "", null, "varchar(100)", 0, 0, false)]
		public virtual String value
		{
			get { return _value; }
			set { if (OnPropertyChanging(__.value, value)) { _value = value; OnPropertyChanged(__.value); } }
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
					case __.Id: return _Id;
					case __.value: return _value;
					default: return base[name];
				}
			}
			set
			{
				switch (name)
				{
					case __.Id: _Id = Convert.ToInt32(value); break;
					case __.value: _value = Convert.ToString(value); break;
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
			public static readonly Field Id = FindByName(__.Id);

			///<summary></summary>
			public static readonly Field value = FindByName(__.value);

			private static Field FindByName(String name)
			{
				return Meta.Table.FindByName(name);
			}
		}

		/// <summary>取得字段名称的快捷方式</summary>
		public partial class __
		{
			///<summary></summary>
			public const String Id = "Id";

			///<summary></summary>
			public const String value = "value";
		}

		#endregion
	}

	/// <summary>接口</summary>
	public partial interface Iincome
	{
		#region 属性

		/// <summary></summary>
		Int32 Id { get; set; }

		/// <summary></summary>
		String value { get; set; }

		#endregion

		#region 获取/设置 字段值

		/// <summary>获取/设置 字段值。</summary>
		/// <param name="name">字段名</param>
		/// <returns></returns>
		Object this[String name] { get; set; }

		#endregion
	}
}