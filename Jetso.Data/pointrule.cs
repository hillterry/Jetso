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
	[BindIndex("PK_POINTRULE", true, "id")]
	[BindTable("pointrule", Description = "", ConnName = "CommonBilling", DbType = DatabaseType.SqlServer)]
	public partial class pointrule : Ipointrule
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

		private Int32 _regpoint;

		/// <summary></summary>
		[DisplayName("regpoint")]
		[Description("")]
		[DataObjectField(false, false, true, 10)]
		[BindColumn(2, "regpoint", "", null, "int", 10, 0, false)]
		public virtual Int32 regpoint
		{
			get { return _regpoint; }
			set { if (OnPropertyChanging(__.regpoint, value)) { _regpoint = value; OnPropertyChanged(__.regpoint); } }
		}

		private Int32 _loginpoint;

		/// <summary></summary>
		[DisplayName("loginpoint")]
		[Description("")]
		[DataObjectField(false, false, true, 10)]
		[BindColumn(3, "loginpoint", "", null, "int", 10, 0, false)]
		public virtual Int32 loginpoint
		{
			get { return _loginpoint; }
			set { if (OnPropertyChanging(__.loginpoint, value)) { _loginpoint = value; OnPropertyChanged(__.loginpoint); } }
		}

		private Int32 _intropoint;

		/// <summary></summary>
		[DisplayName("intropoint")]
		[Description("")]
		[DataObjectField(false, false, true, 10)]
		[BindColumn(4, "intropoint", "", null, "int", 10, 0, false)]
		public virtual Int32 intropoint
		{
			get { return _intropoint; }
			set { if (OnPropertyChanging(__.intropoint, value)) { _intropoint = value; OnPropertyChanged(__.intropoint); } }
		}

		private Int32 _introsucpoint;

		/// <summary></summary>
		[DisplayName("introsucpoint")]
		[Description("")]
		[DataObjectField(false, false, true, 10)]
		[BindColumn(5, "introsucpoint", "", null, "int", 10, 0, false)]
		public virtual Int32 introsucpoint
		{
			get { return _introsucpoint; }
			set { if (OnPropertyChanging(__.introsucpoint, value)) { _introsucpoint = value; OnPropertyChanged(__.introsucpoint); } }
		}

		private Int32 _friendpoint;

		/// <summary></summary>
		[DisplayName("friendpoint")]
		[Description("")]
		[DataObjectField(false, false, true, 10)]
		[BindColumn(6, "friendpoint", "", null, "int", 10, 0, false)]
		public virtual Int32 friendpoint
		{
			get { return _friendpoint; }
			set { if (OnPropertyChanging(__.friendpoint, value)) { _friendpoint = value; OnPropertyChanged(__.friendpoint); } }
		}

		private Int32 _facebookpoint;

		/// <summary></summary>
		[DisplayName("facebookpoint")]
		[Description("")]
		[DataObjectField(false, false, true, 10)]
		[BindColumn(7, "facebookpoint", "", null, "int", 10, 0, false)]
		public virtual Int32 facebookpoint
		{
			get { return _facebookpoint; }
			set { if (OnPropertyChanging(__.facebookpoint, value)) { _facebookpoint = value; OnPropertyChanged(__.facebookpoint); } }
		}

		private Int32 _gradepoint;

		/// <summary></summary>
		[DisplayName("gradepoint")]
		[Description("")]
		[DataObjectField(false, false, true, 10)]
		[BindColumn(8, "gradepoint", "", null, "int", 10, 0, false)]
		public virtual Int32 gradepoint
		{
			get { return _gradepoint; }
			set { if (OnPropertyChanging(__.gradepoint, value)) { _gradepoint = value; OnPropertyChanged(__.gradepoint); } }
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
					case __.regpoint: return _regpoint;
					case __.loginpoint: return _loginpoint;
					case __.intropoint: return _intropoint;
					case __.introsucpoint: return _introsucpoint;
					case __.friendpoint: return _friendpoint;
					case __.facebookpoint: return _facebookpoint;
					case __.gradepoint: return _gradepoint;
					default: return base[name];
				}
			}
			set
			{
				switch (name)
				{
					case __.id: _id = Convert.ToInt32(value); break;
					case __.regpoint: _regpoint = Convert.ToInt32(value); break;
					case __.loginpoint: _loginpoint = Convert.ToInt32(value); break;
					case __.intropoint: _intropoint = Convert.ToInt32(value); break;
					case __.introsucpoint: _introsucpoint = Convert.ToInt32(value); break;
					case __.friendpoint: _friendpoint = Convert.ToInt32(value); break;
					case __.facebookpoint: _facebookpoint = Convert.ToInt32(value); break;
					case __.gradepoint: _gradepoint = Convert.ToInt32(value); break;
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
			public static readonly Field regpoint = FindByName(__.regpoint);

			///<summary></summary>
			public static readonly Field loginpoint = FindByName(__.loginpoint);

			///<summary></summary>
			public static readonly Field intropoint = FindByName(__.intropoint);

			///<summary></summary>
			public static readonly Field introsucpoint = FindByName(__.introsucpoint);

			///<summary></summary>
			public static readonly Field friendpoint = FindByName(__.friendpoint);

			///<summary></summary>
			public static readonly Field facebookpoint = FindByName(__.facebookpoint);

			///<summary></summary>
			public static readonly Field gradepoint = FindByName(__.gradepoint);

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
			public const String regpoint = "regpoint";

			///<summary></summary>
			public const String loginpoint = "loginpoint";

			///<summary></summary>
			public const String intropoint = "intropoint";

			///<summary></summary>
			public const String introsucpoint = "introsucpoint";

			///<summary></summary>
			public const String friendpoint = "friendpoint";

			///<summary></summary>
			public const String facebookpoint = "facebookpoint";

			///<summary></summary>
			public const String gradepoint = "gradepoint";
		}

		#endregion
	}

	/// <summary>接口</summary>
	public partial interface Ipointrule
	{
		#region 属性

		/// <summary></summary>
		Int32 id { get; set; }

		/// <summary></summary>
		Int32 regpoint { get; set; }

		/// <summary></summary>
		Int32 loginpoint { get; set; }

		/// <summary></summary>
		Int32 intropoint { get; set; }

		/// <summary></summary>
		Int32 introsucpoint { get; set; }

		/// <summary></summary>
		Int32 friendpoint { get; set; }

		/// <summary></summary>
		Int32 facebookpoint { get; set; }

		/// <summary></summary>
		Int32 gradepoint { get; set; }

		#endregion

		#region 获取/设置 字段值

		/// <summary>获取/设置 字段值。</summary>
		/// <param name="name">字段名</param>
		/// <returns></returns>
		Object this[String name] { get; set; }

		#endregion
	}
}