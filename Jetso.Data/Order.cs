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
    [BindIndex("IX_Order_MemberId", false, "MemberId")]
    [BindIndex("PK_Order", true, "ID")]
    [BindRelation("MemberId", false, "member", "ID")]
    [BindTable("Order", Description = "", ConnName = "CommonBilling", DbType = DatabaseType.SqlServer)]
    public partial class Order : IOrder
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
        /// <summary></summary>
        [DisplayName("MemberId")]
        [Description("")]
        [DataObjectField(false, false, true, 10)]
        [BindColumn(2, "MemberId", "", null, "int", 10, 0, false)]
        public virtual Int32 MemberId
        {
            get { return _MemberId; }
            set { if (OnPropertyChanging(__.MemberId, value)) { _MemberId = value; OnPropertyChanged(__.MemberId); } }
        }

        private String _OrderNo;
        /// <summary></summary>
        [DisplayName("OrderNo")]
        [Description("")]
        [DataObjectField(false, false, true, 50)]
        [BindColumn(3, "OrderNo", "", null, "varchar(50)", 0, 0, false)]
        public virtual String OrderNo
        {
            get { return _OrderNo; }
            set { if (OnPropertyChanging(__.OrderNo, value)) { _OrderNo = value; OnPropertyChanged(__.OrderNo); } }
        }

        private String _ReceiverEmail;
        /// <summary></summary>
        [DisplayName("ReceiverEmail")]
        [Description("")]
        [DataObjectField(false, false, true, 50)]
        [BindColumn(4, "ReceiverEmail", "", null, "varchar(50)", 0, 0, false)]
        public virtual String ReceiverEmail
        {
            get { return _ReceiverEmail; }
            set { if (OnPropertyChanging(__.ReceiverEmail, value)) { _ReceiverEmail = value; OnPropertyChanged(__.ReceiverEmail); } }
        }

        private Decimal _McGross;
        /// <summary></summary>
        [DisplayName("McGross")]
        [Description("")]
        [DataObjectField(false, false, true, 18)]
        [BindColumn(5, "McGross", "", null, "decimal", 18, 0, false)]
        public virtual Decimal McGross
        {
            get { return _McGross; }
            set { if (OnPropertyChanging(__.McGross, value)) { _McGross = value; OnPropertyChanged(__.McGross); } }
        }

        private String _PaymentStatus;
        /// <summary></summary>
        [DisplayName("PaymentStatus")]
        [Description("")]
        [DataObjectField(false, false, true, 50)]
        [BindColumn(6, "PaymentStatus", "", null, "varchar(50)", 0, 0, false)]
        public virtual String PaymentStatus
        {
            get { return _PaymentStatus; }
            set { if (OnPropertyChanging(__.PaymentStatus, value)) { _PaymentStatus = value; OnPropertyChanged(__.PaymentStatus); } }
        }

        private String _McCurrency;
        /// <summary></summary>
        [DisplayName("McCurrency")]
        [Description("")]
        [DataObjectField(false, false, true, 50)]
        [BindColumn(7, "McCurrency", "", null, "varchar(50)", 0, 0, false)]
        public virtual String McCurrency
        {
            get { return _McCurrency; }
            set { if (OnPropertyChanging(__.McCurrency, value)) { _McCurrency = value; OnPropertyChanged(__.McCurrency); } }
        }

        private String _ItemName;
        /// <summary></summary>
        [DisplayName("ItemName")]
        [Description("")]
        [DataObjectField(false, false, true, 50)]
        [BindColumn(8, "ItemName", "", null, "varchar(50)", 0, 0, false)]
        public virtual String ItemName
        {
            get { return _ItemName; }
            set { if (OnPropertyChanging(__.ItemName, value)) { _ItemName = value; OnPropertyChanged(__.ItemName); } }
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
                    case __.OrderNo : return _OrderNo;
                    case __.ReceiverEmail : return _ReceiverEmail;
                    case __.McGross : return _McGross;
                    case __.PaymentStatus : return _PaymentStatus;
                    case __.McCurrency : return _McCurrency;
                    case __.ItemName : return _ItemName;
                    default: return base[name];
                }
            }
            set
            {
                switch (name)
                {
                    case __.ID : _ID = Convert.ToInt32(value); break;
                    case __.MemberId : _MemberId = Convert.ToInt32(value); break;
                    case __.OrderNo : _OrderNo = Convert.ToString(value); break;
                    case __.ReceiverEmail : _ReceiverEmail = Convert.ToString(value); break;
                    case __.McGross : _McGross = Convert.ToDecimal(value); break;
                    case __.PaymentStatus : _PaymentStatus = Convert.ToString(value); break;
                    case __.McCurrency : _McCurrency = Convert.ToString(value); break;
                    case __.ItemName : _ItemName = Convert.ToString(value); break;
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
            public static readonly Field MemberId = FindByName(__.MemberId);

            ///<summary></summary>
            public static readonly Field OrderNo = FindByName(__.OrderNo);

            ///<summary></summary>
            public static readonly Field ReceiverEmail = FindByName(__.ReceiverEmail);

            ///<summary></summary>
            public static readonly Field McGross = FindByName(__.McGross);

            ///<summary></summary>
            public static readonly Field PaymentStatus = FindByName(__.PaymentStatus);

            ///<summary></summary>
            public static readonly Field McCurrency = FindByName(__.McCurrency);

            ///<summary></summary>
            public static readonly Field ItemName = FindByName(__.ItemName);

            static Field FindByName(String name) { return Meta.Table.FindByName(name); }
        }

        /// <summary>取得字段名称的快捷方式</summary>
        public partial class __
        {
            ///<summary></summary>
            public const String ID = "ID";

            ///<summary></summary>
            public const String MemberId = "MemberId";

            ///<summary></summary>
            public const String OrderNo = "OrderNo";

            ///<summary></summary>
            public const String ReceiverEmail = "ReceiverEmail";

            ///<summary></summary>
            public const String McGross = "McGross";

            ///<summary></summary>
            public const String PaymentStatus = "PaymentStatus";

            ///<summary></summary>
            public const String McCurrency = "McCurrency";

            ///<summary></summary>
            public const String ItemName = "ItemName";

        }
        #endregion
    }

    /// <summary>接口</summary>
    public partial interface IOrder
    {
        #region 属性
        /// <summary></summary>
        Int32 ID { get; set; }

        /// <summary></summary>
        Int32 MemberId { get; set; }

        /// <summary></summary>
        String OrderNo { get; set; }

        /// <summary></summary>
        String ReceiverEmail { get; set; }

        /// <summary></summary>
        Decimal McGross { get; set; }

        /// <summary></summary>
        String PaymentStatus { get; set; }

        /// <summary></summary>
        String McCurrency { get; set; }

        /// <summary></summary>
        String ItemName { get; set; }
        #endregion

        #region 获取/设置 字段值
        /// <summary>获取/设置 字段值。</summary>
        /// <param name="name">字段名</param>
        /// <returns></returns>
        Object this[String name] { get; set; }
        #endregion
    }
}