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
    [BindIndex("PK_COUPONSHARE", true, "ID")]
    [BindIndex("IX_couponshare_memberId", false, "memberId")]
    [BindIndex("IX_couponshare_productId", false, "productId")]
    [BindRelation("memberId", false, "member", "ID")]
    [BindRelation("productId", false, "product", "ID")]
    [BindTable("couponshare", Description = "", ConnName = "CommonBilling", DbType = DatabaseType.SqlServer)]
    public partial class couponshare : Icouponshare
    {
        #region 属性
        private Int32 _ID;
        /// <summary></summary>
        [DisplayName("ID")]
        [Description("")]
        [DataObjectField(true, false, false, 10)]
        [BindColumn(1, "ID", "", null, "int", 10, 0, false)]
        public virtual Int32 ID
        {
            get { return _ID; }
            set { if (OnPropertyChanging(__.ID, value)) { _ID = value; OnPropertyChanged(__.ID); } }
        }

        private Int32 _memberId;
        /// <summary>会员ID</summary>
        [DisplayName("会员ID")]
        [Description("会员ID")]
        [DataObjectField(false, false, true, 10)]
        [BindColumn(2, "memberId", "会员ID", null, "int", 10, 0, false)]
        public virtual Int32 memberId
        {
            get { return _memberId; }
            set { if (OnPropertyChanging(__.memberId, value)) { _memberId = value; OnPropertyChanged(__.memberId); } }
        }

        private Int32 _productId;
        /// <summary></summary>
        [DisplayName("productId")]
        [Description("")]
        [DataObjectField(false, false, true, 10)]
        [BindColumn(3, "productId", "", null, "int", 10, 0, false)]
        public virtual Int32 productId
        {
            get { return _productId; }
            set { if (OnPropertyChanging(__.productId, value)) { _productId = value; OnPropertyChanged(__.productId); } }
        }

        private Int32 _ShareTimes;
        /// <summary></summary>
        [DisplayName("ShareTimes")]
        [Description("")]
        [DataObjectField(false, false, true, 10)]
        [BindColumn(4, "ShareTimes", "", null, "int", 10, 0, false)]
        public virtual Int32 ShareTimes
        {
            get { return _ShareTimes; }
            set { if (OnPropertyChanging(__.ShareTimes, value)) { _ShareTimes = value; OnPropertyChanged(__.ShareTimes); } }
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
                    case __.memberId : return _memberId;
                    case __.productId : return _productId;
                    case __.ShareTimes : return _ShareTimes;
                    default: return base[name];
                }
            }
            set
            {
                switch (name)
                {
                    case __.ID : _ID = Convert.ToInt32(value); break;
                    case __.memberId : _memberId = Convert.ToInt32(value); break;
                    case __.productId : _productId = Convert.ToInt32(value); break;
                    case __.ShareTimes : _ShareTimes = Convert.ToInt32(value); break;
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
            public static readonly Field memberId = FindByName(__.memberId);

            ///<summary></summary>
            public static readonly Field productId = FindByName(__.productId);

            ///<summary></summary>
            public static readonly Field ShareTimes = FindByName(__.ShareTimes);

            static Field FindByName(String name) { return Meta.Table.FindByName(name); }
        }

        /// <summary>取得字段名称的快捷方式</summary>
        public partial class __
        {
            ///<summary></summary>
            public const String ID = "ID";

            ///<summary>会员ID</summary>
            public const String memberId = "memberId";

            ///<summary></summary>
            public const String productId = "productId";

            ///<summary></summary>
            public const String ShareTimes = "ShareTimes";

        }
        #endregion
    }

    /// <summary>接口</summary>
    public partial interface Icouponshare
    {
        #region 属性
        /// <summary></summary>
        Int32 ID { get; set; }

        /// <summary>会员ID</summary>
        Int32 memberId { get; set; }

        /// <summary></summary>
        Int32 productId { get; set; }

        /// <summary></summary>
        Int32 ShareTimes { get; set; }
        #endregion

        #region 获取/设置 字段值
        /// <summary>获取/设置 字段值。</summary>
        /// <param name="name">字段名</param>
        /// <returns></returns>
        Object this[String name] { get; set; }
        #endregion
    }
}