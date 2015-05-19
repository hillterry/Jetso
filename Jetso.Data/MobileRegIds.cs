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
    [BindIndex("PK_MobileRegIds", true, "ID")]
		[BindTable("MobileRegIds", Description = "", ConnName = "CommonBilling", DbType = DatabaseType.SqlServer)]
    public partial class MobileRegIds : IMobileRegIds
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

        private Int32 _RegsId;
        /// <summary></summary>
        [DisplayName("RegsId")]
        [Description("")]
        [DataObjectField(false, false, true, 10)]
        [BindColumn(2, "RegsId", "", null, "int", 10, 0, false)]
        public virtual Int32 RegsId
        {
            get { return _RegsId; }
            set { if (OnPropertyChanging(__.RegsId, value)) { _RegsId = value; OnPropertyChanged(__.RegsId); } }
        }

        private Int32 _User;
        /// <summary></summary>
        [DisplayName("User")]
        [Description("")]
        [DataObjectField(false, false, true, 10)]
        [BindColumn(3, "User", "", null, "int", 10, 0, false)]
        public virtual Int32 User
        {
            get { return _User; }
            set { if (OnPropertyChanging(__.User, value)) { _User = value; OnPropertyChanged(__.User); } }
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
                    case __.RegsId : return _RegsId;
                    case __.User : return _User;
                    default: return base[name];
                }
            }
            set
            {
                switch (name)
                {
                    case __.ID : _ID = Convert.ToInt32(value); break;
                    case __.RegsId : _RegsId = Convert.ToInt32(value); break;
                    case __.User : _User = Convert.ToInt32(value); break;
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
            public static readonly Field RegsId = FindByName(__.RegsId);

            ///<summary></summary>
            public static readonly Field User = FindByName(__.User);

            static Field FindByName(String name) { return Meta.Table.FindByName(name); }
        }

        /// <summary>取得字段名称的快捷方式</summary>
        public partial class __
        {
            ///<summary></summary>
            public const String ID = "ID";

            ///<summary></summary>
            public const String RegsId = "RegsId";

            ///<summary></summary>
            public const String User = "User";

        }
        #endregion
    }

    /// <summary>接口</summary>
    public partial interface IMobileRegIds
    {
        #region 属性
        /// <summary></summary>
        Int32 ID { get; set; }

        /// <summary></summary>
        Int32 RegsId { get; set; }

        /// <summary></summary>
        Int32 User { get; set; }
        #endregion

        #region 获取/设置 字段值
        /// <summary>获取/设置 字段值。</summary>
        /// <param name="name">字段名</param>
        /// <returns></returns>
        Object this[String name] { get; set; }
        #endregion
    }
}