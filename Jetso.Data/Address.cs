﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Xml.Serialization;
using DmFramework.Data;
using DmFramework.Data.Configuration;
using DmFramework.Data.DataAccessLayer;

namespace Jesto.Data
{
    /// <summary></summary>
    [Serializable]
    [DataObject]
    [Description("")]
    [BindIndex("IX_Address_MemberID", false, "MemberID")]
    [BindIndex("PK_Address_1", true, "ID")]
    [BindRelation("MemberID", false, "member", "ID")]
    [BindRelation("ID", true, "member", "AddressID")]
		[BindTable("Address", Description = "", ConnName = "CommonBilling", DbType = DatabaseType.SqlServer)]
    public partial class Address : IAddress
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

        private Int32 _MemberID;
        /// <summary>用户ID</summary>
        [DisplayName("用户ID")]
        [Description("用户ID")]
        [DataObjectField(false, false, true, 10)]
        [BindColumn(2, "MemberID", "用户ID", null, "int", 10, 0, false)]
        public virtual Int32 MemberID
        {
            get { return _MemberID; }
            set { if (OnPropertyChanging(__.MemberID, value)) { _MemberID = value; OnPropertyChanged(__.MemberID); } }
        }

        private String _Addressee;
        /// <summary>收件人</summary>
        [DisplayName("收件人")]
        [Description("收件人")]
        [DataObjectField(false, false, true, 50)]
        [BindColumn(3, "Addressee", "收件人", null, "varchar(50)", 0, 0, false)]
        public virtual String Addressee
        {
            get { return _Addressee; }
            set { if (OnPropertyChanging(__.Addressee, value)) { _Addressee = value; OnPropertyChanged(__.Addressee); } }
        }

        private String _Addr;
        /// <summary>收件地址</summary>
        [DisplayName("收件地址")]
        [Description("收件地址")]
        [DataObjectField(false, false, true, 2147483647)]
        [BindColumn(4, "Addr", "收件地址", null, "text", 0, 0, false)]
        public virtual String Addr
        {
            get { return _Addr; }
            set { if (OnPropertyChanging(__.Addr, value)) { _Addr = value; OnPropertyChanged(__.Addr); } }
        }

        private String _Phone;
        /// <summary>固定电话</summary>
        [DisplayName("固定电话")]
        [Description("固定电话")]
        [DataObjectField(false, false, true, 50)]
        [BindColumn(5, "Phone", "固定电话", null, "varchar(50)", 0, 0, false)]
        public virtual String Phone
        {
            get { return _Phone; }
            set { if (OnPropertyChanging(__.Phone, value)) { _Phone = value; OnPropertyChanged(__.Phone); } }
        }

        private String _MobilePhone;
        /// <summary>移动电话</summary>
        [DisplayName("移动电话")]
        [Description("移动电话")]
        [DataObjectField(false, false, true, 50)]
        [BindColumn(6, "MobilePhone", "移动电话", null, "varchar(50)", 0, 0, false)]
        public virtual String MobilePhone
        {
            get { return _MobilePhone; }
            set { if (OnPropertyChanging(__.MobilePhone, value)) { _MobilePhone = value; OnPropertyChanged(__.MobilePhone); } }
        }

        private Boolean _IsDefaoult;
        /// <summary></summary>
        [DisplayName("IsDefaoult")]
        [Description("")]
        [DataObjectField(false, false, true, 1)]
        [BindColumn(7, "IsDefaoult", "", null, "bit", 0, 0, false)]
        public virtual Boolean IsDefaoult
        {
            get { return _IsDefaoult; }
            set { if (OnPropertyChanging(__.IsDefaoult, value)) { _IsDefaoult = value; OnPropertyChanged(__.IsDefaoult); } }
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
                    case __.ID : return _ID;
                    case __.MemberID : return _MemberID;
                    case __.Addressee : return _Addressee;
                    case __.Addr : return _Addr;
                    case __.Phone : return _Phone;
                    case __.MobilePhone : return _MobilePhone;
                    case __.IsDefaoult : return _IsDefaoult;
                    default: return base[name];
                }
            }
            set
            {
                switch (name)
                {
                    case __.ID : _ID = Convert.ToInt32(value); break;
                    case __.MemberID : _MemberID = Convert.ToInt32(value); break;
                    case __.Addressee : _Addressee = Convert.ToString(value); break;
                    case __.Addr : _Addr = Convert.ToString(value); break;
                    case __.Phone : _Phone = Convert.ToString(value); break;
                    case __.MobilePhone : _MobilePhone = Convert.ToString(value); break;
                    case __.IsDefaoult : _IsDefaoult = Convert.ToBoolean(value); break;
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

            ///<summary>用户ID</summary>
            public static readonly Field MemberID = FindByName(__.MemberID);

            ///<summary>收件人</summary>
            public static readonly Field Addressee = FindByName(__.Addressee);

            ///<summary>收件地址</summary>
            public static readonly Field Addr = FindByName(__.Addr);

            ///<summary>固定电话</summary>
            public static readonly Field Phone = FindByName(__.Phone);

            ///<summary>移动电话</summary>
            public static readonly Field MobilePhone = FindByName(__.MobilePhone);

            ///<summary></summary>
            public static readonly Field IsDefaoult = FindByName(__.IsDefaoult);

            static Field FindByName(String name) { return Meta.Table.FindByName(name); }
        }

        /// <summary>取得字段名称的快捷方式</summary>
        public partial class __
        {
            ///<summary></summary>
            public const String ID = "ID";

            ///<summary>用户ID</summary>
            public const String MemberID = "MemberID";

            ///<summary>收件人</summary>
            public const String Addressee = "Addressee";

            ///<summary>收件地址</summary>
            public const String Addr = "Addr";

            ///<summary>固定电话</summary>
            public const String Phone = "Phone";

            ///<summary>移动电话</summary>
            public const String MobilePhone = "MobilePhone";

            ///<summary></summary>
            public const String IsDefaoult = "IsDefaoult";

        }
        #endregion
    }

    /// <summary>接口</summary>
    public partial interface IAddress
    {
        #region 属性
        /// <summary></summary>
        Int32 ID { get; set; }

        /// <summary>用户ID</summary>
        Int32 MemberID { get; set; }

        /// <summary>收件人</summary>
        String Addressee { get; set; }

        /// <summary>收件地址</summary>
        String Addr { get; set; }

        /// <summary>固定电话</summary>
        String Phone { get; set; }

        /// <summary>移动电话</summary>
        String MobilePhone { get; set; }

        /// <summary></summary>
        Boolean IsDefaoult { get; set; }
        #endregion

        #region 获取/设置 字段值
        /// <summary>获取/设置 字段值。</summary>
        /// <param name="name">字段名</param>
        /// <returns></returns>
        Object this[String name] { get; set; }
        #endregion
    }
}