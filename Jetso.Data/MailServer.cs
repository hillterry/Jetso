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
    [BindIndex("PK_SYSTEM", true, "id")]
    [BindTable("MailServer", Description = "", ConnName = "CommonBilling", DbType = DatabaseType.SqlServer)]
    public partial class MailServer : IMailServer
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

        private String _server;
        /// <summary></summary>
        [DisplayName("server")]
        [Description("")]
        [DataObjectField(false, false, true, 100)]
        [BindColumn(2, "server", "", null, "varchar(100)", 0, 0, false)]
        public virtual String server
        {
            get { return _server; }
            set { if (OnPropertyChanging(__.server, value)) { _server = value; OnPropertyChanged(__.server); } }
        }

        private String _port;
        /// <summary></summary>
        [DisplayName("port")]
        [Description("")]
        [DataObjectField(false, false, true, 100)]
        [BindColumn(3, "port", "", null, "varchar(100)", 0, 0, false)]
        public virtual String port
        {
            get { return _port; }
            set { if (OnPropertyChanging(__.port, value)) { _port = value; OnPropertyChanged(__.port); } }
        }

        private String _fromMail;
        /// <summary>系统邮箱</summary>
        [DisplayName("系统邮箱")]
        [Description("系统邮箱")]
        [DataObjectField(false, false, true, 100)]
        [BindColumn(4, "fromMail", "系统邮箱", null, "varchar(100)", 0, 0, false)]
        public virtual String fromMail
        {
            get { return _fromMail; }
            set { if (OnPropertyChanging(__.fromMail, value)) { _fromMail = value; OnPropertyChanged(__.fromMail); } }
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
                    case __.id : return _id;
                    case __.server : return _server;
                    case __.port : return _port;
                    case __.fromMail : return _fromMail;
                    default: return base[name];
                }
            }
            set
            {
                switch (name)
                {
                    case __.id : _id = Convert.ToInt32(value); break;
                    case __.server : _server = Convert.ToString(value); break;
                    case __.port : _port = Convert.ToString(value); break;
                    case __.fromMail : _fromMail = Convert.ToString(value); break;
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
            public static readonly Field server = FindByName(__.server);

            ///<summary></summary>
            public static readonly Field port = FindByName(__.port);

            ///<summary>系统邮箱</summary>
            public static readonly Field fromMail = FindByName(__.fromMail);

            static Field FindByName(String name) { return Meta.Table.FindByName(name); }
        }

        /// <summary>取得字段名称的快捷方式</summary>
        public partial class __
        {
            ///<summary></summary>
            public const String id = "id";

            ///<summary></summary>
            public const String server = "server";

            ///<summary></summary>
            public const String port = "port";

            ///<summary>系统邮箱</summary>
            public const String fromMail = "fromMail";

        }
        #endregion
    }

    /// <summary>接口</summary>
    public partial interface IMailServer
    {
        #region 属性
        /// <summary></summary>
        Int32 id { get; set; }

        /// <summary></summary>
        String server { get; set; }

        /// <summary></summary>
        String port { get; set; }

        /// <summary>系统邮箱</summary>
        String fromMail { get; set; }
        #endregion

        #region 获取/设置 字段值
        /// <summary>获取/设置 字段值。</summary>
        /// <param name="name">字段名</param>
        /// <returns></returns>
        Object this[String name] { get; set; }
        #endregion
    }
}