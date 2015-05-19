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
    [BindIndex("PK_PointType", true, "ID")]
    [BindTable("PointType", Description = "", ConnName = "CommonBilling", DbType = DatabaseType.SqlServer)]
    public partial class PointType : IPointType
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

        private Int32 _Type;
        /// <summary></summary>
        [DisplayName("Type")]
        [Description("")]
        [DataObjectField(false, false, true, 10)]
        [BindColumn(2, "Type", "", null, "int", 10, 0, false)]
        public virtual Int32 Type
        {
            get { return _Type; }
            set { if (OnPropertyChanging(__.Type, value)) { _Type = value; OnPropertyChanged(__.Type); } }
        }

        private Int32 _Point;
        /// <summary></summary>
        [DisplayName("Point")]
        [Description("")]
        [DataObjectField(false, false, true, 10)]
        [BindColumn(3, "Point", "", null, "int", 10, 0, false)]
        public virtual Int32 Point
        {
            get { return _Point; }
            set { if (OnPropertyChanging(__.Point, value)) { _Point = value; OnPropertyChanged(__.Point); } }
        }

        private Decimal _Gross;
        /// <summary></summary>
        [DisplayName("Gross")]
        [Description("")]
        [DataObjectField(false, false, true, 18)]
        [BindColumn(4, "Gross", "", null, "decimal", 18, 0, false)]
        public virtual Decimal Gross
        {
            get { return _Gross; }
            set { if (OnPropertyChanging(__.Gross, value)) { _Gross = value; OnPropertyChanged(__.Gross); } }
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
                    case __.Type : return _Type;
                    case __.Point : return _Point;
                    case __.Gross : return _Gross;
                    default: return base[name];
                }
            }
            set
            {
                switch (name)
                {
                    case __.ID : _ID = Convert.ToInt32(value); break;
                    case __.Type : _Type = Convert.ToInt32(value); break;
                    case __.Point : _Point = Convert.ToInt32(value); break;
                    case __.Gross : _Gross = Convert.ToDecimal(value); break;
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
            public static readonly Field Type = FindByName(__.Type);

            ///<summary></summary>
            public static readonly Field Point = FindByName(__.Point);

            ///<summary></summary>
            public static readonly Field Gross = FindByName(__.Gross);

            static Field FindByName(String name) { return Meta.Table.FindByName(name); }
        }

        /// <summary>取得字段名称的快捷方式</summary>
        public partial class __
        {
            ///<summary></summary>
            public const String ID = "ID";

            ///<summary></summary>
            public const String Type = "Type";

            ///<summary></summary>
            public const String Point = "Point";

            ///<summary></summary>
            public const String Gross = "Gross";

        }
        #endregion
    }

    /// <summary>接口</summary>
    public partial interface IPointType
    {
        #region 属性
        /// <summary></summary>
        Int32 ID { get; set; }

        /// <summary></summary>
        Int32 Type { get; set; }

        /// <summary></summary>
        Int32 Point { get; set; }

        /// <summary></summary>
        Decimal Gross { get; set; }
        #endregion

        #region 获取/设置 字段值
        /// <summary>获取/设置 字段值。</summary>
        /// <param name="name">字段名</param>
        /// <returns></returns>
        Object this[String name] { get; set; }
        #endregion
    }
}