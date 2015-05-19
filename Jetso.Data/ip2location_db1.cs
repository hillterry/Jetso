﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Xml.Serialization;
using DmFramework.Data;
using DmFramework.Data.Configuration;
using DmFramework.Data.DataAccessLayer;

namespace Jetso.Data
{
    /// <summary></summary>
    [Serializable]
    [DataObject]
    [Description("")]
    [BindIndex("ip_from", false, "ip_from")]
    [BindIndex("ip_to", false, "ip_to")]
    [BindTable("ip2location_db1", Description = "", ConnName = "CommonBilling", DbType = DatabaseType.SqlServer)]
    public partial class ip2location_db1 : Iip2location_db1
    {
        #region 属性
        private Double _ip_from;
        /// <summary></summary>
        [DisplayName("ip_from")]
        [Description("")]
        [DataObjectField(true, false, false, 53)]
        [BindColumn(1, "ip_from", "", null, "float", 53, 0, false)]
        public virtual Double ip_from
        {
            get { return _ip_from; }
            set { if (OnPropertyChanging(__.ip_from, value)) { _ip_from = value; OnPropertyChanged(__.ip_from); } }
        }

        private Double _ip_to;
        /// <summary></summary>
        [DisplayName("ip_to")]
        [Description("")]
        [DataObjectField(true, false, false, 53)]
        [BindColumn(2, "ip_to", "", null, "float", 53, 0, false)]
        public virtual Double ip_to
        {
            get { return _ip_to; }
            set { if (OnPropertyChanging(__.ip_to, value)) { _ip_to = value; OnPropertyChanged(__.ip_to); } }
        }

        private String _country_code;
        /// <summary></summary>
        [DisplayName("country_code")]
        [Description("")]
        [DataObjectField(false, false, false, 2)]
        [BindColumn(3, "country_code", "", null, "nvarchar(2)", 0, 0, true)]
        public virtual String country_code
        {
            get { return _country_code; }
            set { if (OnPropertyChanging(__.country_code, value)) { _country_code = value; OnPropertyChanged(__.country_code); } }
        }

        private String _country_name;
        /// <summary></summary>
        [DisplayName("country_name")]
        [Description("")]
        [DataObjectField(false, false, false, 64)]
        [BindColumn(4, "country_name", "", null, "nvarchar(64)", 0, 0, true)]
        public virtual String country_name
        {
            get { return _country_name; }
            set { if (OnPropertyChanging(__.country_name, value)) { _country_name = value; OnPropertyChanged(__.country_name); } }
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
                    case __.ip_from : return _ip_from;
                    case __.ip_to : return _ip_to;
                    case __.country_code : return _country_code;
                    case __.country_name : return _country_name;
                    default: return base[name];
                }
            }
            set
            {
                switch (name)
                {
                    case __.ip_from : _ip_from = Convert.ToDouble(value); break;
                    case __.ip_to : _ip_to = Convert.ToDouble(value); break;
                    case __.country_code : _country_code = Convert.ToString(value); break;
                    case __.country_name : _country_name = Convert.ToString(value); break;
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
            public static readonly Field ip_from = FindByName(__.ip_from);

            ///<summary></summary>
            public static readonly Field ip_to = FindByName(__.ip_to);

            ///<summary></summary>
            public static readonly Field country_code = FindByName(__.country_code);

            ///<summary></summary>
            public static readonly Field country_name = FindByName(__.country_name);

            static Field FindByName(String name) { return Meta.Table.FindByName(name); }
        }

        /// <summary>取得字段名称的快捷方式</summary>
        public partial class __
        {
            ///<summary></summary>
            public const String ip_from = "ip_from";

            ///<summary></summary>
            public const String ip_to = "ip_to";

            ///<summary></summary>
            public const String country_code = "country_code";

            ///<summary></summary>
            public const String country_name = "country_name";

        }
        #endregion
    }

    /// <summary>接口</summary>
    public partial interface Iip2location_db1
    {
        #region 属性
        /// <summary></summary>
        Double ip_from { get; set; }

        /// <summary></summary>
        Double ip_to { get; set; }

        /// <summary></summary>
        String country_code { get; set; }

        /// <summary></summary>
        String country_name { get; set; }
        #endregion

        #region 获取/设置 字段值
        /// <summary>获取/设置 字段值。</summary>
        /// <param name="name">字段名</param>
        /// <returns></returns>
        Object this[String name] { get; set; }
        #endregion
    }
}