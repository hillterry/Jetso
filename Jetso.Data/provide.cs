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
	[BindIndex("PK_PROVIDE", true, "ID")]
	[BindRelation("ID", true, "product", "provideId")]
	[BindTable("provide", Description = "", ConnName = "CommonBilling", DbType = DatabaseType.SqlServer)]
	public partial class provide : Iprovide
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

		private String _nickname;

		/// <summary></summary>
		[DisplayName("nickname")]
		[Description("")]
		[DataObjectField(false, false, true, 50)]
		[BindColumn(2, "nickname", "", null, "varchar(50)", 0, 0, false)]
		public virtual String nickname
		{
			get { return _nickname; }
			set { if (OnPropertyChanging(__.nickname, value)) { _nickname = value; OnPropertyChanged(__.nickname); } }
		}

		private String _email;

		/// <summary></summary>
		[DisplayName("email")]
		[Description("")]
		[DataObjectField(false, false, true, 50)]
		[BindColumn(3, "email", "", null, "varchar(50)", 0, 0, false)]
		public virtual String email
		{
			get { return _email; }
			set { if (OnPropertyChanging(__.email, value)) { _email = value; OnPropertyChanged(__.email); } }
		}

		private String _password;

		/// <summary></summary>
		[DisplayName("password")]
		[Description("")]
		[DataObjectField(false, false, true, 50)]
		[BindColumn(4, "password", "", null, "varchar(50)", 0, 0, false)]
		public virtual String password
		{
			get { return _password; }
			set { if (OnPropertyChanging(__.password, value)) { _password = value; OnPropertyChanged(__.password); } }
		}

		private String _name;

		/// <summary></summary>
		[DisplayName("name")]
		[Description("")]
		[DataObjectField(false, false, true, 50)]
		[BindColumn(5, "name", "", null, "varchar(50)", 0, 0, false)]
		public virtual String name
		{
			get { return _name; }
			set { if (OnPropertyChanging(__.name, value)) { _name = value; OnPropertyChanged(__.name); } }
		}

		private String _companyName;

		/// <summary></summary>
		[DisplayName("companyName")]
		[Description("")]
		[DataObjectField(false, false, true, 50)]
		[BindColumn(6, "companyName", "", null, "varchar(50)", 0, 0, false)]
		public virtual String companyName
		{
			get { return _companyName; }
			set { if (OnPropertyChanging(__.companyName, value)) { _companyName = value; OnPropertyChanged(__.companyName); } }
		}

		private String _phone;

		/// <summary></summary>
		[DisplayName("phone")]
		[Description("")]
		[DataObjectField(false, false, true, 20)]
		[BindColumn(7, "phone", "", null, "varchar(20)", 0, 0, false)]
		public virtual String phone
		{
			get { return _phone; }
			set { if (OnPropertyChanging(__.phone, value)) { _phone = value; OnPropertyChanged(__.phone); } }
		}

		private Int32 _isMemberInfo;

		/// <summary></summary>
		[DisplayName("isMemberInfo")]
		[Description("")]
		[DataObjectField(false, false, true, 10)]
		[BindColumn(8, "isMemberInfo", "", null, "int", 10, 0, false)]
		public virtual Int32 isMemberInfo
		{
			get { return _isMemberInfo; }
			set { if (OnPropertyChanging(__.isMemberInfo, value)) { _isMemberInfo = value; OnPropertyChanged(__.isMemberInfo); } }
		}

		private Int32 _isCoupon;

		/// <summary></summary>
		[DisplayName("isCoupon")]
		[Description("")]
		[DataObjectField(false, false, true, 10)]
		[BindColumn(9, "isCoupon", "", null, "int", 10, 0, false)]
		public virtual Int32 isCoupon
		{
			get { return _isCoupon; }
			set { if (OnPropertyChanging(__.isCoupon, value)) { _isCoupon = value; OnPropertyChanged(__.isCoupon); } }
		}

		private Int32 _MemberStat;

		/// <summary></summary>
		[DisplayName("MemberStat")]
		[Description("")]
		[DataObjectField(false, false, true, 10)]
		[BindColumn(10, "MemberStat", "", null, "int", 10, 0, false)]
		public virtual Int32 MemberStat
		{
			get { return _MemberStat; }
			set { if (OnPropertyChanging(__.MemberStat, value)) { _MemberStat = value; OnPropertyChanged(__.MemberStat); } }
		}

		private DateTime _createTime;

		/// <summary></summary>
		[DisplayName("createTime")]
		[Description("")]
		[DataObjectField(false, false, true, 3)]
		[BindColumn(11, "createTime", "", null, "datetime", 3, 0, false)]
		public virtual DateTime createTime
		{
			get { return _createTime; }
			set { if (OnPropertyChanging(__.createTime, value)) { _createTime = value; OnPropertyChanged(__.createTime); } }
		}

		private DateTime _lastLoginTime;

		/// <summary></summary>
		[DisplayName("lastLoginTime")]
		[Description("")]
		[DataObjectField(false, false, true, 3)]
		[BindColumn(12, "lastLoginTime", "", null, "datetime", 3, 0, false)]
		public virtual DateTime lastLoginTime
		{
			get { return _lastLoginTime; }
			set { if (OnPropertyChanging(__.lastLoginTime, value)) { _lastLoginTime = value; OnPropertyChanged(__.lastLoginTime); } }
		}

		private String _shopName;

		/// <summary></summary>
		[DisplayName("shopName")]
		[Description("")]
		[DataObjectField(false, false, true, 100)]
		[BindColumn(13, "shopName", "", null, "varchar(100)", 0, 0, false)]
		public virtual String shopName
		{
			get { return _shopName; }
			set { if (OnPropertyChanging(__.shopName, value)) { _shopName = value; OnPropertyChanged(__.shopName); } }
		}

		private String _shopLogo;

		/// <summary></summary>
		[DisplayName("shopLogo")]
		[Description("")]
		[DataObjectField(false, false, true, 200)]
		[BindColumn(14, "shopLogo", "", null, "varchar(200)", 0, 0, false)]
		public virtual String shopLogo
		{
			get { return _shopLogo; }
			set { if (OnPropertyChanging(__.shopLogo, value)) { _shopLogo = value; OnPropertyChanged(__.shopLogo); } }
		}

		private String _shopUrl;

		/// <summary></summary>
		[DisplayName("shopUrl")]
		[Description("")]
		[DataObjectField(false, false, true, 200)]
		[BindColumn(15, "shopUrl", "", null, "varchar(200)", 0, 0, false)]
		public virtual String shopUrl
		{
			get { return _shopUrl; }
			set { if (OnPropertyChanging(__.shopUrl, value)) { _shopUrl = value; OnPropertyChanged(__.shopUrl); } }
		}

		private String _shopShortDesc;

		/// <summary></summary>
		[DisplayName("shopShortDesc")]
		[Description("")]
		[DataObjectField(false, false, true, 300)]
		[BindColumn(16, "shopShortDesc", "", null, "varchar(300)", 0, 0, false)]
		public virtual String shopShortDesc
		{
			get { return _shopShortDesc; }
			set { if (OnPropertyChanging(__.shopShortDesc, value)) { _shopShortDesc = value; OnPropertyChanged(__.shopShortDesc); } }
		}

		private String _money;

		/// <summary></summary>
		[DisplayName("money")]
		[Description("")]
		[DataObjectField(false, false, true, 100)]
		[BindColumn(17, "money", "", null, "varchar(100)", 0, 0, false)]
		public virtual String money
		{
			get { return _money; }
			set { if (OnPropertyChanging(__.money, value)) { _money = value; OnPropertyChanged(__.money); } }
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
					case __.nickname: return _nickname;
					case __.email: return _email;
					case __.password: return _password;
					case __.name: return _name;
					case __.companyName: return _companyName;
					case __.phone: return _phone;
					case __.isMemberInfo: return _isMemberInfo;
					case __.isCoupon: return _isCoupon;
					case __.MemberStat: return _MemberStat;
					case __.createTime: return _createTime;
					case __.lastLoginTime: return _lastLoginTime;
					case __.shopName: return _shopName;
					case __.shopLogo: return _shopLogo;
					case __.shopUrl: return _shopUrl;
					case __.shopShortDesc: return _shopShortDesc;
					case __.money: return _money;
					default: return base[name];
				}
			}
			set
			{
				switch (name)
				{
					case __.ID: _ID = Convert.ToInt32(value); break;
					case __.nickname: _nickname = Convert.ToString(value); break;
					case __.email: _email = Convert.ToString(value); break;
					case __.password: _password = Convert.ToString(value); break;
					case __.name: _name = Convert.ToString(value); break;
					case __.companyName: _companyName = Convert.ToString(value); break;
					case __.phone: _phone = Convert.ToString(value); break;
					case __.isMemberInfo: _isMemberInfo = Convert.ToInt32(value); break;
					case __.isCoupon: _isCoupon = Convert.ToInt32(value); break;
					case __.MemberStat: _MemberStat = Convert.ToInt32(value); break;
					case __.createTime: _createTime = Convert.ToDateTime(value); break;
					case __.lastLoginTime: _lastLoginTime = Convert.ToDateTime(value); break;
					case __.shopName: _shopName = Convert.ToString(value); break;
					case __.shopLogo: _shopLogo = Convert.ToString(value); break;
					case __.shopUrl: _shopUrl = Convert.ToString(value); break;
					case __.shopShortDesc: _shopShortDesc = Convert.ToString(value); break;
					case __.money: _money = Convert.ToString(value); break;
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
			public static readonly Field nickname = FindByName(__.nickname);

			///<summary></summary>
			public static readonly Field email = FindByName(__.email);

			///<summary></summary>
			public static readonly Field password = FindByName(__.password);

			///<summary></summary>
			public static readonly Field name = FindByName(__.name);

			///<summary></summary>
			public static readonly Field companyName = FindByName(__.companyName);

			///<summary></summary>
			public static readonly Field phone = FindByName(__.phone);

			///<summary></summary>
			public static readonly Field isMemberInfo = FindByName(__.isMemberInfo);

			///<summary></summary>
			public static readonly Field isCoupon = FindByName(__.isCoupon);

			///<summary></summary>
			public static readonly Field MemberStat = FindByName(__.MemberStat);

			///<summary></summary>
			public static readonly Field createTime = FindByName(__.createTime);

			///<summary></summary>
			public static readonly Field lastLoginTime = FindByName(__.lastLoginTime);

			///<summary></summary>
			public static readonly Field shopName = FindByName(__.shopName);

			///<summary></summary>
			public static readonly Field shopLogo = FindByName(__.shopLogo);

			///<summary></summary>
			public static readonly Field shopUrl = FindByName(__.shopUrl);

			///<summary></summary>
			public static readonly Field shopShortDesc = FindByName(__.shopShortDesc);

			///<summary></summary>
			public static readonly Field money = FindByName(__.money);

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
			public const String nickname = "nickname";

			///<summary></summary>
			public const String email = "email";

			///<summary></summary>
			public const String password = "password";

			///<summary></summary>
			public const String name = "name";

			///<summary></summary>
			public const String companyName = "companyName";

			///<summary></summary>
			public const String phone = "phone";

			///<summary></summary>
			public const String isMemberInfo = "isMemberInfo";

			///<summary></summary>
			public const String isCoupon = "isCoupon";

			///<summary></summary>
			public const String MemberStat = "MemberStat";

			///<summary></summary>
			public const String createTime = "createTime";

			///<summary></summary>
			public const String lastLoginTime = "lastLoginTime";

			///<summary></summary>
			public const String shopName = "shopName";

			///<summary></summary>
			public const String shopLogo = "shopLogo";

			///<summary></summary>
			public const String shopUrl = "shopUrl";

			///<summary></summary>
			public const String shopShortDesc = "shopShortDesc";

			///<summary></summary>
			public const String money = "money";
		}

		#endregion
	}

	/// <summary>接口</summary>
	public partial interface Iprovide
	{
		#region 属性

		/// <summary></summary>
		Int32 ID { get; set; }

		/// <summary></summary>
		String nickname { get; set; }

		/// <summary></summary>
		String email { get; set; }

		/// <summary></summary>
		String password { get; set; }

		/// <summary></summary>
		String name { get; set; }

		/// <summary></summary>
		String companyName { get; set; }

		/// <summary></summary>
		String phone { get; set; }

		/// <summary></summary>
		Int32 isMemberInfo { get; set; }

		/// <summary></summary>
		Int32 isCoupon { get; set; }

		/// <summary></summary>
		Int32 MemberStat { get; set; }

		/// <summary></summary>
		DateTime createTime { get; set; }

		/// <summary></summary>
		DateTime lastLoginTime { get; set; }

		/// <summary></summary>
		String shopName { get; set; }

		/// <summary></summary>
		String shopLogo { get; set; }

		/// <summary></summary>
		String shopUrl { get; set; }

		/// <summary></summary>
		String shopShortDesc { get; set; }

		/// <summary></summary>
		String money { get; set; }

		#endregion

		#region 获取/设置 字段值

		/// <summary>获取/设置 字段值。</summary>
		/// <param name="name">字段名</param>
		/// <returns></returns>
		Object this[String name] { get; set; }

		#endregion
	}
}