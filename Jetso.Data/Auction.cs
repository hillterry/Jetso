﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Xml.Serialization;
using DmFramework.Data;
using DmFramework.Data.Configuration;
using DmFramework.Data.DataAccessLayer;

namespace Jetso.Data
{
    /// <summary>竞投</summary>
    [Serializable]
    [DataObject]
    [Description("竞投")]
    [BindIndex("IX_Auction_ProductName", false, "ProductName")]
    [BindIndex("PK__Auction__3214EC27173876EA", true, "ID")]
    [BindRelation("ProductName", false, "product", "productName")]
    [BindRelation("ID", true, "AuctionHistory", "AuctionID")]
    [BindTable("Auction", Description = "竞投", ConnName = "CommonBilling", DbType = DatabaseType.SqlServer)]
    public partial class Auction : IAuction
    {
        #region 属性
        private Int32 _ID;
        /// <summary>竞投ID</summary>
        [DisplayName("竞投ID")]
        [Description("竞投ID")]
        [DataObjectField(true, true, false, 10)]
        [BindColumn(1, "ID", "竞投ID", null, "int", 10, 0, false)]
        public virtual Int32 ID
        {
            get { return _ID; }
            set { if (OnPropertyChanging(__.ID, value)) { _ID = value; OnPropertyChanged(__.ID); } }
        }

        private String _ProductNo;
        /// <summary>竞投产品编号</summary>
        [DisplayName("竞投产品编号")]
        [Description("竞投产品编号")]
        [DataObjectField(false, false, true, 50)]
        [BindColumn(2, "ProductNo", "竞投产品编号", null, "varchar(50)", 0, 0, false)]
        public virtual String ProductNo
        {
            get { return _ProductNo; }
            set { if (OnPropertyChanging(__.ProductNo, value)) { _ProductNo = value; OnPropertyChanged(__.ProductNo); } }
        }

        private String _ProductName;
        /// <summary>竞投商品名称</summary>
        [DisplayName("竞投商品名称")]
        [Description("竞投商品名称")]
        [DataObjectField(false, false, true, 50)]
        [BindColumn(3, "ProductName", "竞投商品名称", null, "varchar(50)", 0, 0, false)]
        public virtual String ProductName
        {
            get { return _ProductName; }
            set { if (OnPropertyChanging(__.ProductName, value)) { _ProductName = value; OnPropertyChanged(__.ProductName); } }
        }

        private String _ProductBrief;
        /// <summary>商品简介</summary>
        [DisplayName("商品简介")]
        [Description("商品简介")]
        [DataObjectField(false, false, true, 2147483647)]
        [BindColumn(4, "ProductBrief", "商品简介", null, "text", 0, 0, false)]
        public virtual String ProductBrief
        {
            get { return _ProductBrief; }
            set { if (OnPropertyChanging(__.ProductBrief, value)) { _ProductBrief = value; OnPropertyChanged(__.ProductBrief); } }
        }

        private String _ProductDescription;
        /// <summary>竞投详细介绍</summary>
        [DisplayName("竞投详细介绍")]
        [Description("竞投详细介绍")]
        [DataObjectField(false, false, true, 2147483647)]
        [BindColumn(5, "ProductDescription", "竞投详细介绍", null, "text", 0, 0, false)]
        public virtual String ProductDescription
        {
            get { return _ProductDescription; }
            set { if (OnPropertyChanging(__.ProductDescription, value)) { _ProductDescription = value; OnPropertyChanged(__.ProductDescription); } }
        }

        private Decimal _MarkPrice;
        /// <summary>市场价格（原价）</summary>
        [DisplayName("市场价格原价")]
        [Description("市场价格（原价）")]
        [DataObjectField(false, false, true, 18)]
        [BindColumn(6, "MarkPrice", "市场价格（原价）", null, "decimal", 18, 2, false)]
        public virtual Decimal MarkPrice
        {
            get { return _MarkPrice; }
            set { if (OnPropertyChanging(__.MarkPrice, value)) { _MarkPrice = value; OnPropertyChanged(__.MarkPrice); } }
        }

        private Decimal _BiddingPriceNow;
        /// <summary>竞投当前价格</summary>
        [DisplayName("竞投当前价格")]
        [Description("竞投当前价格")]
        [DataObjectField(false, false, true, 18)]
        [BindColumn(7, "BiddingPriceNow", "竞投当前价格", null, "decimal", 18, 2, false)]
        public virtual Decimal BiddingPriceNow
        {
            get { return _BiddingPriceNow; }
            set { if (OnPropertyChanging(__.BiddingPriceNow, value)) { _BiddingPriceNow = value; OnPropertyChanged(__.BiddingPriceNow); } }
        }

        private DateTime _StarTime;
        /// <summary>竞投开始时间</summary>
        [DisplayName("竞投开始时间")]
        [Description("竞投开始时间")]
        [DataObjectField(false, false, true, 3)]
        [BindColumn(8, "StarTime", "竞投开始时间", null, "datetime", 3, 0, false)]
        public virtual DateTime StarTime
        {
            get { return _StarTime; }
            set { if (OnPropertyChanging(__.StarTime, value)) { _StarTime = value; OnPropertyChanged(__.StarTime); } }
        }

        private String _TimeAddRange;
        /// <summary>每次增加时间段（例如40-70）</summary>
        [DisplayName("每次增加时间段例如40-70")]
        [Description("每次增加时间段（例如40-70）")]
        [DataObjectField(false, false, true, 50)]
        [BindColumn(9, "TimeAddRange", "每次增加时间段（例如40-70）", null, "char(50)", 0, 0, false)]
        public virtual String TimeAddRange
        {
            get { return _TimeAddRange; }
            set { if (OnPropertyChanging(__.TimeAddRange, value)) { _TimeAddRange = value; OnPropertyChanged(__.TimeAddRange); } }
        }

        private Decimal _EveryAddPrice;
        /// <summary>每次增加金额</summary>
        [DisplayName("每次增加金额")]
        [Description("每次增加金额")]
        [DataObjectField(false, false, true, 18)]
        [BindColumn(10, "EveryAddPrice", "每次增加金额", null, "decimal", 18, 2, false)]
        public virtual Decimal EveryAddPrice
        {
            get { return _EveryAddPrice; }
            set { if (OnPropertyChanging(__.EveryAddPrice, value)) { _EveryAddPrice = value; OnPropertyChanged(__.EveryAddPrice); } }
        }

        private Int32 _EveryNeedPoint;
        /// <summary>每次竞投所需积分</summary>
        [DisplayName("每次竞投所需积分")]
        [Description("每次竞投所需积分")]
        [DataObjectField(false, false, true, 10)]
        [BindColumn(11, "EveryNeedPoint", "每次竞投所需积分", null, "int", 10, 0, false)]
        public virtual Int32 EveryNeedPoint
        {
            get { return _EveryNeedPoint; }
            set { if (OnPropertyChanging(__.EveryNeedPoint, value)) { _EveryNeedPoint = value; OnPropertyChanged(__.EveryNeedPoint); } }
        }

        private Decimal _MinPrice;
        /// <summary>最低竞投价格</summary>
        [DisplayName("最低竞投价格")]
        [Description("最低竞投价格")]
        [DataObjectField(false, false, true, 18)]
        [BindColumn(12, "MinPrice", "最低竞投价格", null, "decimal", 18, 2, false)]
        public virtual Decimal MinPrice
        {
            get { return _MinPrice; }
            set { if (OnPropertyChanging(__.MinPrice, value)) { _MinPrice = value; OnPropertyChanged(__.MinPrice); } }
        }

        private DateTime _BiddingLimitTime;
        /// <summary>竞投限制时间（截止时间）</summary>
        [DisplayName("竞投限制时间截止时间")]
        [Description("竞投限制时间（截止时间）")]
        [DataObjectField(false, false, true, 3)]
        [BindColumn(13, "BiddingLimitTime", "竞投限制时间（截止时间）", null, "datetime", 3, 0, false)]
        public virtual DateTime BiddingLimitTime
        {
            get { return _BiddingLimitTime; }
            set { if (OnPropertyChanging(__.BiddingLimitTime, value)) { _BiddingLimitTime = value; OnPropertyChanged(__.BiddingLimitTime); } }
        }

        private DateTime _EndTime;
        /// <summary>最终竞投成功时间</summary>
        [DisplayName("最终竞投成功时间")]
        [Description("最终竞投成功时间")]
        [DataObjectField(false, false, true, 3)]
        [BindColumn(14, "EndTime", "最终竞投成功时间", null, "datetime", 3, 0, false)]
        public virtual DateTime EndTime
        {
            get { return _EndTime; }
            set { if (OnPropertyChanging(__.EndTime, value)) { _EndTime = value; OnPropertyChanged(__.EndTime); } }
        }

        private Int32 _WinningBidder;
        /// <summary>投标者（最终竞投者）</summary>
        [DisplayName("投标者最终竞投者")]
        [Description("投标者（最终竞投者）")]
        [DataObjectField(false, false, true, 10)]
        [BindColumn(15, "WinningBidder", "投标者（最终竞投者）", null, "int", 10, 0, false)]
        public virtual Int32 WinningBidder
        {
            get { return _WinningBidder; }
            set { if (OnPropertyChanging(__.WinningBidder, value)) { _WinningBidder = value; OnPropertyChanged(__.WinningBidder); } }
        }

        private Int32 _BidCount;
        /// <summary>竞投次数</summary>
        [DisplayName("竞投次数")]
        [Description("竞投次数")]
        [DataObjectField(false, false, true, 10)]
        [BindColumn(16, "BidCount", "竞投次数", null, "int", 10, 0, false)]
        public virtual Int32 BidCount
        {
            get { return _BidCount; }
            set { if (OnPropertyChanging(__.BidCount, value)) { _BidCount = value; OnPropertyChanged(__.BidCount); } }
        }

        private String _ProductImage1;
        /// <summary>商品图片</summary>
        [DisplayName("商品图片")]
        [Description("商品图片")]
        [DataObjectField(false, false, true, 2147483647)]
        [BindColumn(17, "ProductImage1", "商品图片", null, "text", 0, 0, false)]
        public virtual String ProductImage1
        {
            get { return _ProductImage1; }
            set { if (OnPropertyChanging(__.ProductImage1, value)) { _ProductImage1 = value; OnPropertyChanged(__.ProductImage1); } }
        }

        private String _ProductImage2;
        /// <summary>商品图片2</summary>
        [DisplayName("商品图片2")]
        [Description("商品图片2")]
        [DataObjectField(false, false, true, 2147483647)]
        [BindColumn(18, "ProductImage2", "商品图片2", null, "text", 0, 0, false)]
        public virtual String ProductImage2
        {
            get { return _ProductImage2; }
            set { if (OnPropertyChanging(__.ProductImage2, value)) { _ProductImage2 = value; OnPropertyChanged(__.ProductImage2); } }
        }

        private String _ProductImage3;
        /// <summary>商品图片3</summary>
        [DisplayName("商品图片3")]
        [Description("商品图片3")]
        [DataObjectField(false, false, true, 2147483647)]
        [BindColumn(19, "ProductImage3", "商品图片3", null, "text", 0, 0, false)]
        public virtual String ProductImage3
        {
            get { return _ProductImage3; }
            set { if (OnPropertyChanging(__.ProductImage3, value)) { _ProductImage3 = value; OnPropertyChanged(__.ProductImage3); } }
        }

        private DateTime _CreatTime;
        /// <summary>创建时间</summary>
        [DisplayName("创建时间")]
        [Description("创建时间")]
        [DataObjectField(false, false, true, 3)]
        [BindColumn(20, "CreatTime", "创建时间", null, "datetime", 3, 0, false)]
        public virtual DateTime CreatTime
        {
            get { return _CreatTime; }
            set { if (OnPropertyChanging(__.CreatTime, value)) { _CreatTime = value; OnPropertyChanged(__.CreatTime); } }
        }

        private DateTime _UpdateTime;
        /// <summary>修改时间。   </summary>
        [DisplayName("修改时间")]
        [Description("修改时间。   ")]
        [DataObjectField(false, false, true, 3)]
        [BindColumn(21, "UpdateTime", "修改时间。   ", null, "datetime", 3, 0, false)]
        public virtual DateTime UpdateTime
        {
            get { return _UpdateTime; }
            set { if (OnPropertyChanging(__.UpdateTime, value)) { _UpdateTime = value; OnPropertyChanged(__.UpdateTime); } }
        }

        private String _Adv_description;
        /// <summary>广告简介</summary>
        [DisplayName("广告简介")]
        [Description("广告简介")]
        [DataObjectField(false, false, true, 2147483647)]
        [BindColumn(22, "Adv_description", "广告简介", null, "text", 0, 0, false)]
        public virtual String Adv_description
        {
            get { return _Adv_description; }
            set { if (OnPropertyChanging(__.Adv_description, value)) { _Adv_description = value; OnPropertyChanged(__.Adv_description); } }
        }

        private String _Adv_name;
        /// <summary>广告名称</summary>
        [DisplayName("广告名称")]
        [Description("广告名称")]
        [DataObjectField(false, false, true, 50)]
        [BindColumn(23, "Adv_name", "广告名称", null, "varchar(50)", 0, 0, false)]
        public virtual String Adv_name
        {
            get { return _Adv_name; }
            set { if (OnPropertyChanging(__.Adv_name, value)) { _Adv_name = value; OnPropertyChanged(__.Adv_name); } }
        }

        private String _Adv_content;
        /// <summary>广告内容</summary>
        [DisplayName("广告内容")]
        [Description("广告内容")]
        [DataObjectField(false, false, true, 2147483647)]
        [BindColumn(24, "Adv_content", "广告内容", null, "text", 0, 0, false)]
        public virtual String Adv_content
        {
            get { return _Adv_content; }
            set { if (OnPropertyChanging(__.Adv_content, value)) { _Adv_content = value; OnPropertyChanged(__.Adv_content); } }
        }

        private String _Adv_image;
        /// <summary>广告图片</summary>
        [DisplayName("广告图片")]
        [Description("广告图片")]
        [DataObjectField(false, false, true, 2147483647)]
        [BindColumn(25, "Adv_image", "广告图片", null, "text", 0, 0, false)]
        public virtual String Adv_image
        {
            get { return _Adv_image; }
            set { if (OnPropertyChanging(__.Adv_image, value)) { _Adv_image = value; OnPropertyChanged(__.Adv_image); } }
        }

        private Int32 _WinnerBidCount;
        /// <summary></summary>
        [DisplayName("WinnerBidCount")]
        [Description("")]
        [DataObjectField(false, false, true, 10)]
        [BindColumn(26, "WinnerBidCount", "", null, "int", 10, 0, false)]
        public virtual Int32 WinnerBidCount
        {
            get { return _WinnerBidCount; }
            set { if (OnPropertyChanging(__.WinnerBidCount, value)) { _WinnerBidCount = value; OnPropertyChanged(__.WinnerBidCount); } }
        }

        private Int32 _AuctionSatus;
        /// <summary>竞投状态1: 未开始2：进行中3：已结束</summary>
        [DisplayName("竞投状态1:未开始2：进行中3：已结束")]
        [Description("竞投状态1: 未开始2：进行中3：已结束")]
        [DataObjectField(false, false, true, 10)]
        [BindColumn(27, "AuctionSatus", "竞投状态1: 未开始2：进行中3：已结束", null, "int", 10, 0, false)]
        public virtual Int32 AuctionSatus
        {
            get { return _AuctionSatus; }
            set { if (OnPropertyChanging(__.AuctionSatus, value)) { _AuctionSatus = value; OnPropertyChanged(__.AuctionSatus); } }
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
                    case __.ProductNo : return _ProductNo;
                    case __.ProductName : return _ProductName;
                    case __.ProductBrief : return _ProductBrief;
                    case __.ProductDescription : return _ProductDescription;
                    case __.MarkPrice : return _MarkPrice;
                    case __.BiddingPriceNow : return _BiddingPriceNow;
                    case __.StarTime : return _StarTime;
                    case __.TimeAddRange : return _TimeAddRange;
                    case __.EveryAddPrice : return _EveryAddPrice;
                    case __.EveryNeedPoint : return _EveryNeedPoint;
                    case __.MinPrice : return _MinPrice;
                    case __.BiddingLimitTime : return _BiddingLimitTime;
                    case __.EndTime : return _EndTime;
                    case __.WinningBidder : return _WinningBidder;
                    case __.BidCount : return _BidCount;
                    case __.ProductImage1 : return _ProductImage1;
                    case __.ProductImage2 : return _ProductImage2;
                    case __.ProductImage3 : return _ProductImage3;
                    case __.CreatTime : return _CreatTime;
                    case __.UpdateTime : return _UpdateTime;
                    case __.Adv_description : return _Adv_description;
                    case __.Adv_name : return _Adv_name;
                    case __.Adv_content : return _Adv_content;
                    case __.Adv_image : return _Adv_image;
                    case __.WinnerBidCount : return _WinnerBidCount;
                    case __.AuctionSatus : return _AuctionSatus;
                    default: return base[name];
                }
            }
            set
            {
                switch (name)
                {
                    case __.ID : _ID = Convert.ToInt32(value); break;
                    case __.ProductNo : _ProductNo = Convert.ToString(value); break;
                    case __.ProductName : _ProductName = Convert.ToString(value); break;
                    case __.ProductBrief : _ProductBrief = Convert.ToString(value); break;
                    case __.ProductDescription : _ProductDescription = Convert.ToString(value); break;
                    case __.MarkPrice : _MarkPrice = Convert.ToDecimal(value); break;
                    case __.BiddingPriceNow : _BiddingPriceNow = Convert.ToDecimal(value); break;
                    case __.StarTime : _StarTime = Convert.ToDateTime(value); break;
                    case __.TimeAddRange : _TimeAddRange = Convert.ToString(value); break;
                    case __.EveryAddPrice : _EveryAddPrice = Convert.ToDecimal(value); break;
                    case __.EveryNeedPoint : _EveryNeedPoint = Convert.ToInt32(value); break;
                    case __.MinPrice : _MinPrice = Convert.ToDecimal(value); break;
                    case __.BiddingLimitTime : _BiddingLimitTime = Convert.ToDateTime(value); break;
                    case __.EndTime : _EndTime = Convert.ToDateTime(value); break;
                    case __.WinningBidder : _WinningBidder = Convert.ToInt32(value); break;
                    case __.BidCount : _BidCount = Convert.ToInt32(value); break;
                    case __.ProductImage1 : _ProductImage1 = Convert.ToString(value); break;
                    case __.ProductImage2 : _ProductImage2 = Convert.ToString(value); break;
                    case __.ProductImage3 : _ProductImage3 = Convert.ToString(value); break;
                    case __.CreatTime : _CreatTime = Convert.ToDateTime(value); break;
                    case __.UpdateTime : _UpdateTime = Convert.ToDateTime(value); break;
                    case __.Adv_description : _Adv_description = Convert.ToString(value); break;
                    case __.Adv_name : _Adv_name = Convert.ToString(value); break;
                    case __.Adv_content : _Adv_content = Convert.ToString(value); break;
                    case __.Adv_image : _Adv_image = Convert.ToString(value); break;
                    case __.WinnerBidCount : _WinnerBidCount = Convert.ToInt32(value); break;
                    case __.AuctionSatus : _AuctionSatus = Convert.ToInt32(value); break;
                    default: base[name] = value; break;
                }
            }
        }
        #endregion

        #region 字段名
        /// <summary>取得竞投字段信息的快捷方式</summary>
        public partial class _
        {
            ///<summary>竞投ID</summary>
            public static readonly Field ID = FindByName(__.ID);

            ///<summary>竞投产品编号</summary>
            public static readonly Field ProductNo = FindByName(__.ProductNo);

            ///<summary>竞投商品名称</summary>
            public static readonly Field ProductName = FindByName(__.ProductName);

            ///<summary>商品简介</summary>
            public static readonly Field ProductBrief = FindByName(__.ProductBrief);

            ///<summary>竞投详细介绍</summary>
            public static readonly Field ProductDescription = FindByName(__.ProductDescription);

            ///<summary>市场价格（原价）</summary>
            public static readonly Field MarkPrice = FindByName(__.MarkPrice);

            ///<summary>竞投当前价格</summary>
            public static readonly Field BiddingPriceNow = FindByName(__.BiddingPriceNow);

            ///<summary>竞投开始时间</summary>
            public static readonly Field StarTime = FindByName(__.StarTime);

            ///<summary>每次增加时间段（例如40-70）</summary>
            public static readonly Field TimeAddRange = FindByName(__.TimeAddRange);

            ///<summary>每次增加金额</summary>
            public static readonly Field EveryAddPrice = FindByName(__.EveryAddPrice);

            ///<summary>每次竞投所需积分</summary>
            public static readonly Field EveryNeedPoint = FindByName(__.EveryNeedPoint);

            ///<summary>最低竞投价格</summary>
            public static readonly Field MinPrice = FindByName(__.MinPrice);

            ///<summary>竞投限制时间（截止时间）</summary>
            public static readonly Field BiddingLimitTime = FindByName(__.BiddingLimitTime);

            ///<summary>最终竞投成功时间</summary>
            public static readonly Field EndTime = FindByName(__.EndTime);

            ///<summary>投标者（最终竞投者）</summary>
            public static readonly Field WinningBidder = FindByName(__.WinningBidder);

            ///<summary>竞投次数</summary>
            public static readonly Field BidCount = FindByName(__.BidCount);

            ///<summary>商品图片</summary>
            public static readonly Field ProductImage1 = FindByName(__.ProductImage1);

            ///<summary>商品图片2</summary>
            public static readonly Field ProductImage2 = FindByName(__.ProductImage2);

            ///<summary>商品图片3</summary>
            public static readonly Field ProductImage3 = FindByName(__.ProductImage3);

            ///<summary>创建时间</summary>
            public static readonly Field CreatTime = FindByName(__.CreatTime);

            ///<summary>修改时间。   </summary>
            public static readonly Field UpdateTime = FindByName(__.UpdateTime);

            ///<summary>广告简介</summary>
            public static readonly Field Adv_description = FindByName(__.Adv_description);

            ///<summary>广告名称</summary>
            public static readonly Field Adv_name = FindByName(__.Adv_name);

            ///<summary>广告内容</summary>
            public static readonly Field Adv_content = FindByName(__.Adv_content);

            ///<summary>广告图片</summary>
            public static readonly Field Adv_image = FindByName(__.Adv_image);

            ///<summary></summary>
            public static readonly Field WinnerBidCount = FindByName(__.WinnerBidCount);

            ///<summary>竞投状态1: 未开始2：进行中3：已结束</summary>
            public static readonly Field AuctionSatus = FindByName(__.AuctionSatus);

            static Field FindByName(String name) { return Meta.Table.FindByName(name); }
        }

        /// <summary>取得竞投字段名称的快捷方式</summary>
        public partial class __
        {
            ///<summary>竞投ID</summary>
            public const String ID = "ID";

            ///<summary>竞投产品编号</summary>
            public const String ProductNo = "ProductNo";

            ///<summary>竞投商品名称</summary>
            public const String ProductName = "ProductName";

            ///<summary>商品简介</summary>
            public const String ProductBrief = "ProductBrief";

            ///<summary>竞投详细介绍</summary>
            public const String ProductDescription = "ProductDescription";

            ///<summary>市场价格（原价）</summary>
            public const String MarkPrice = "MarkPrice";

            ///<summary>竞投当前价格</summary>
            public const String BiddingPriceNow = "BiddingPriceNow";

            ///<summary>竞投开始时间</summary>
            public const String StarTime = "StarTime";

            ///<summary>每次增加时间段（例如40-70）</summary>
            public const String TimeAddRange = "TimeAddRange";

            ///<summary>每次增加金额</summary>
            public const String EveryAddPrice = "EveryAddPrice";

            ///<summary>每次竞投所需积分</summary>
            public const String EveryNeedPoint = "EveryNeedPoint";

            ///<summary>最低竞投价格</summary>
            public const String MinPrice = "MinPrice";

            ///<summary>竞投限制时间（截止时间）</summary>
            public const String BiddingLimitTime = "BiddingLimitTime";

            ///<summary>最终竞投成功时间</summary>
            public const String EndTime = "EndTime";

            ///<summary>投标者（最终竞投者）</summary>
            public const String WinningBidder = "WinningBidder";

            ///<summary>竞投次数</summary>
            public const String BidCount = "BidCount";

            ///<summary>商品图片</summary>
            public const String ProductImage1 = "ProductImage1";

            ///<summary>商品图片2</summary>
            public const String ProductImage2 = "ProductImage2";

            ///<summary>商品图片3</summary>
            public const String ProductImage3 = "ProductImage3";

            ///<summary>创建时间</summary>
            public const String CreatTime = "CreatTime";

            ///<summary>修改时间。   </summary>
            public const String UpdateTime = "UpdateTime";

            ///<summary>广告简介</summary>
            public const String Adv_description = "Adv_description";

            ///<summary>广告名称</summary>
            public const String Adv_name = "Adv_name";

            ///<summary>广告内容</summary>
            public const String Adv_content = "Adv_content";

            ///<summary>广告图片</summary>
            public const String Adv_image = "Adv_image";

            ///<summary></summary>
            public const String WinnerBidCount = "WinnerBidCount";

            ///<summary>竞投状态1: 未开始2：进行中3：已结束</summary>
            public const String AuctionSatus = "AuctionSatus";

        }
        #endregion
    }

    /// <summary>竞投接口</summary>
    public partial interface IAuction
    {
        #region 属性
        /// <summary>竞投ID</summary>
        Int32 ID { get; set; }

        /// <summary>竞投产品编号</summary>
        String ProductNo { get; set; }

        /// <summary>竞投商品名称</summary>
        String ProductName { get; set; }

        /// <summary>商品简介</summary>
        String ProductBrief { get; set; }

        /// <summary>竞投详细介绍</summary>
        String ProductDescription { get; set; }

        /// <summary>市场价格（原价）</summary>
        Decimal MarkPrice { get; set; }

        /// <summary>竞投当前价格</summary>
        Decimal BiddingPriceNow { get; set; }

        /// <summary>竞投开始时间</summary>
        DateTime StarTime { get; set; }

        /// <summary>每次增加时间段（例如40-70）</summary>
        String TimeAddRange { get; set; }

        /// <summary>每次增加金额</summary>
        Decimal EveryAddPrice { get; set; }

        /// <summary>每次竞投所需积分</summary>
        Int32 EveryNeedPoint { get; set; }

        /// <summary>最低竞投价格</summary>
        Decimal MinPrice { get; set; }

        /// <summary>竞投限制时间（截止时间）</summary>
        DateTime BiddingLimitTime { get; set; }

        /// <summary>最终竞投成功时间</summary>
        DateTime EndTime { get; set; }

        /// <summary>投标者（最终竞投者）</summary>
        Int32 WinningBidder { get; set; }

        /// <summary>竞投次数</summary>
        Int32 BidCount { get; set; }

        /// <summary>商品图片</summary>
        String ProductImage1 { get; set; }

        /// <summary>商品图片2</summary>
        String ProductImage2 { get; set; }

        /// <summary>商品图片3</summary>
        String ProductImage3 { get; set; }

        /// <summary>创建时间</summary>
        DateTime CreatTime { get; set; }

        /// <summary>修改时间。   </summary>
        DateTime UpdateTime { get; set; }

        /// <summary>广告简介</summary>
        String Adv_description { get; set; }

        /// <summary>广告名称</summary>
        String Adv_name { get; set; }

        /// <summary>广告内容</summary>
        String Adv_content { get; set; }

        /// <summary>广告图片</summary>
        String Adv_image { get; set; }

        /// <summary></summary>
        Int32 WinnerBidCount { get; set; }

        /// <summary>竞投状态1: 未开始2：进行中3：已结束</summary>
        Int32 AuctionSatus { get; set; }
        #endregion

        #region 获取/设置 字段值
        /// <summary>获取/设置 字段值。</summary>
        /// <param name="name">字段名</param>
        /// <returns></returns>
        Object this[String name] { get; set; }
        #endregion
    }
}