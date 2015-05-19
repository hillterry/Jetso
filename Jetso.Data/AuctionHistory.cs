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
    [BindIndex("IX_AuctionHistory_AuctionID", false, "AuctionID")]
    [BindIndex("IX_AuctionHistory_MemberID", false, "MemberID")]
    [BindIndex("PK_AUCTIONHISTORY", true, "ID")]
    [BindRelation("AuctionID", false, "Auction", "ID")]
    [BindRelation("MemberID", false, "member", "ID")]
    [BindTable("AuctionHistory", Description = "", ConnName = "CommonBilling", DbType = DatabaseType.SqlServer)]
    public partial class AuctionHistory : IAuctionHistory
    {
        #region 属性
        private Int32 _ID;
        /// <summary>竞投历史ID</summary>
        [DisplayName("竞投历史ID")]
        [Description("竞投历史ID")]
        [DataObjectField(true, true, false, 10)]
        [BindColumn(1, "ID", "竞投历史ID", null, "int", 10, 0, false)]
        public virtual Int32 ID
        {
            get { return _ID; }
            set { if (OnPropertyChanging(__.ID, value)) { _ID = value; OnPropertyChanged(__.ID); } }
        }

        private Int32 _AuctionID;
        /// <summary>竞投商品ID</summary>
        [DisplayName("竞投商品ID")]
        [Description("竞投商品ID")]
        [DataObjectField(false, false, true, 10)]
        [BindColumn(2, "AuctionID", "竞投商品ID", null, "int", 10, 0, false)]
        public virtual Int32 AuctionID
        {
            get { return _AuctionID; }
            set { if (OnPropertyChanging(__.AuctionID, value)) { _AuctionID = value; OnPropertyChanged(__.AuctionID); } }
        }

        private Int32 _MemberID;
        /// <summary></summary>
        [DisplayName("MemberID")]
        [Description("")]
        [DataObjectField(false, false, true, 10)]
        [BindColumn(3, "MemberID", "", null, "int", 10, 0, false)]
        public virtual Int32 MemberID
        {
            get { return _MemberID; }
            set { if (OnPropertyChanging(__.MemberID, value)) { _MemberID = value; OnPropertyChanged(__.MemberID); } }
        }

        private Decimal _BidEyuan;
        /// <summary>出价e元</summary>
        [DisplayName("出价e元")]
        [Description("出价e元")]
        [DataObjectField(false, false, true, 18)]
        [BindColumn(4, "BidEyuan", "出价e元", null, "decimal", 18, 0, false)]
        public virtual Decimal BidEyuan
        {
            get { return _BidEyuan; }
            set { if (OnPropertyChanging(__.BidEyuan, value)) { _BidEyuan = value; OnPropertyChanged(__.BidEyuan); } }
        }

        private DateTime _BidDate;
        /// <summary>竞标日期</summary>
        [DisplayName("竞标日期")]
        [Description("竞标日期")]
        [DataObjectField(false, false, true, 3)]
        [BindColumn(5, "BidDate", "竞标日期", null, "datetime", 3, 0, false)]
        public virtual DateTime BidDate
        {
            get { return _BidDate; }
            set { if (OnPropertyChanging(__.BidDate, value)) { _BidDate = value; OnPropertyChanged(__.BidDate); } }
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
                    case __.AuctionID : return _AuctionID;
                    case __.MemberID : return _MemberID;
                    case __.BidEyuan : return _BidEyuan;
                    case __.BidDate : return _BidDate;
                    default: return base[name];
                }
            }
            set
            {
                switch (name)
                {
                    case __.ID : _ID = Convert.ToInt32(value); break;
                    case __.AuctionID : _AuctionID = Convert.ToInt32(value); break;
                    case __.MemberID : _MemberID = Convert.ToInt32(value); break;
                    case __.BidEyuan : _BidEyuan = Convert.ToDecimal(value); break;
                    case __.BidDate : _BidDate = Convert.ToDateTime(value); break;
                    default: base[name] = value; break;
                }
            }
        }
        #endregion

        #region 字段名
        /// <summary>取得字段信息的快捷方式</summary>
        public partial class _
        {
            ///<summary>竞投历史ID</summary>
            public static readonly Field ID = FindByName(__.ID);

            ///<summary>竞投商品ID</summary>
            public static readonly Field AuctionID = FindByName(__.AuctionID);

            ///<summary></summary>
            public static readonly Field MemberID = FindByName(__.MemberID);

            ///<summary>出价e元</summary>
            public static readonly Field BidEyuan = FindByName(__.BidEyuan);

            ///<summary>竞标日期</summary>
            public static readonly Field BidDate = FindByName(__.BidDate);

            static Field FindByName(String name) { return Meta.Table.FindByName(name); }
        }

        /// <summary>取得字段名称的快捷方式</summary>
        public partial class __
        {
            ///<summary>竞投历史ID</summary>
            public const String ID = "ID";

            ///<summary>竞投商品ID</summary>
            public const String AuctionID = "AuctionID";

            ///<summary></summary>
            public const String MemberID = "MemberID";

            ///<summary>出价e元</summary>
            public const String BidEyuan = "BidEyuan";

            ///<summary>竞标日期</summary>
            public const String BidDate = "BidDate";

        }
        #endregion
    }

    /// <summary>接口</summary>
    public partial interface IAuctionHistory
    {
        #region 属性
        /// <summary>竞投历史ID</summary>
        Int32 ID { get; set; }

        /// <summary>竞投商品ID</summary>
        Int32 AuctionID { get; set; }

        /// <summary></summary>
        Int32 MemberID { get; set; }

        /// <summary>出价e元</summary>
        Decimal BidEyuan { get; set; }

        /// <summary>竞标日期</summary>
        DateTime BidDate { get; set; }
        #endregion

        #region 获取/设置 字段值
        /// <summary>获取/设置 字段值。</summary>
        /// <param name="name">字段名</param>
        /// <returns></returns>
        Object this[String name] { get; set; }
        #endregion
    }
}