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
    [BindIndex("IX_PointHistory_MemberId", false, "MemberId")]
    [BindIndex("PK_PointHistory", true, "ID")]
    [BindRelation("MemberId", false, "member", "ID")]
    [BindTable("PointHistory", Description = "", ConnName = "CommonBilling", DbType = DatabaseType.SqlServer)]
    public partial class PointHistory : IPointHistory
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

        private Int32 _MemberId;
        /// <summary>会员ID</summary>
        [DisplayName("会员ID")]
        [Description("会员ID")]
        [DataObjectField(false, false, true, 10)]
        [BindColumn(2, "MemberId", "会员ID", null, "int", 10, 0, false)]
        public virtual Int32 MemberId
        {
            get { return _MemberId; }
            set { if (OnPropertyChanging(__.MemberId, value)) { _MemberId = value; OnPropertyChanged(__.MemberId); } }
        }

        private Int32 _Point;
        /// <summary>使用的积分</summary>
        [DisplayName("使用的积分")]
        [Description("使用的积分")]
        [DataObjectField(false, false, true, 10)]
        [BindColumn(3, "Point", "使用的积分", null, "int", 10, 0, false)]
        public virtual Int32 Point
        {
            get { return _Point; }
            set { if (OnPropertyChanging(__.Point, value)) { _Point = value; OnPropertyChanged(__.Point); } }
        }

        private DateTime _UseTime;
        /// <summary>使用时间</summary>
        [DisplayName("使用时间")]
        [Description("使用时间")]
        [DataObjectField(false, false, true, 7)]
        [BindColumn(4, "UseTime", "使用时间", null, "datetime2", 7, 0, false)]
        public virtual DateTime UseTime
        {
            get { return _UseTime; }
            set { if (OnPropertyChanging(__.UseTime, value)) { _UseTime = value; OnPropertyChanged(__.UseTime); } }
        }

        private String _ItemName;
        /// <summary>使用项目</summary>
        [DisplayName("使用项目")]
        [Description("使用项目")]
        [DataObjectField(false, false, true, 50)]
        [BindColumn(5, "ItemName", "使用项目", null, "varchar(50)", 0, 0, false)]
        public virtual String ItemName
        {
            get { return _ItemName; }
            set { if (OnPropertyChanging(__.ItemName, value)) { _ItemName = value; OnPropertyChanged(__.ItemName); } }
        }

        private Int32 _CurrentPointCount;
        /// <summary></summary>
        [DisplayName("CurrentPointCount")]
        [Description("")]
        [DataObjectField(false, false, true, 10)]
        [BindColumn(6, "CurrentPointCount", "", null, "int", 10, 0, false)]
        public virtual Int32 CurrentPointCount
        {
            get { return _CurrentPointCount; }
            set { if (OnPropertyChanging(__.CurrentPointCount, value)) { _CurrentPointCount = value; OnPropertyChanged(__.CurrentPointCount); } }
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
                    case __.MemberId : return _MemberId;
                    case __.Point : return _Point;
                    case __.UseTime : return _UseTime;
                    case __.ItemName : return _ItemName;
                    case __.CurrentPointCount : return _CurrentPointCount;
                    default: return base[name];
                }
            }
            set
            {
                switch (name)
                {
                    case __.ID : _ID = Convert.ToInt32(value); break;
                    case __.MemberId : _MemberId = Convert.ToInt32(value); break;
                    case __.Point : _Point = Convert.ToInt32(value); break;
                    case __.UseTime : _UseTime = Convert.ToDateTime(value); break;
                    case __.ItemName : _ItemName = Convert.ToString(value); break;
                    case __.CurrentPointCount : _CurrentPointCount = Convert.ToInt32(value); break;
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

            ///<summary>会员ID</summary>
            public static readonly Field MemberId = FindByName(__.MemberId);

            ///<summary>使用的积分</summary>
            public static readonly Field Point = FindByName(__.Point);

            ///<summary>使用时间</summary>
            public static readonly Field UseTime = FindByName(__.UseTime);

            ///<summary>使用项目</summary>
            public static readonly Field ItemName = FindByName(__.ItemName);

            ///<summary></summary>
            public static readonly Field CurrentPointCount = FindByName(__.CurrentPointCount);

            static Field FindByName(String name) { return Meta.Table.FindByName(name); }
        }

        /// <summary>取得字段名称的快捷方式</summary>
        public partial class __
        {
            ///<summary></summary>
            public const String ID = "ID";

            ///<summary>会员ID</summary>
            public const String MemberId = "MemberId";

            ///<summary>使用的积分</summary>
            public const String Point = "Point";

            ///<summary>使用时间</summary>
            public const String UseTime = "UseTime";

            ///<summary>使用项目</summary>
            public const String ItemName = "ItemName";

            ///<summary></summary>
            public const String CurrentPointCount = "CurrentPointCount";

        }
        #endregion
    }

    /// <summary>接口</summary>
    public partial interface IPointHistory
    {
        #region 属性
        /// <summary></summary>
        Int32 ID { get; set; }

        /// <summary>会员ID</summary>
        Int32 MemberId { get; set; }

        /// <summary>使用的积分</summary>
        Int32 Point { get; set; }

        /// <summary>使用时间</summary>
        DateTime UseTime { get; set; }

        /// <summary>使用项目</summary>
        String ItemName { get; set; }

        /// <summary></summary>
        Int32 CurrentPointCount { get; set; }
        #endregion

        #region 获取/设置 字段值
        /// <summary>获取/设置 字段值。</summary>
        /// <param name="name">字段名</param>
        /// <returns></returns>
        Object this[String name] { get; set; }
        #endregion
    }
}