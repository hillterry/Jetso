﻿using System;
using System.ComponentModel;
using DmFramework.Data;
using DmFramework.Data.Configuration;
using DmFramework.Data.DataAccessLayer;

namespace Jetso.Data
{
    /// <summary></summary>
    [Serializable]
    [DataObject]
    [Description("")]
    [BindIndex("IX_friend_email", false, "email")]
    [BindIndex("IX_friend_memberId", false, "memberId")]
    [BindIndex("PK_FRIEND", true, "id")]
    [BindRelation("id", true, "coupon", "friendId")]
    [BindRelation("email", false, "coupon", "friendEmail")]
    [BindRelation("memberId", false, "member", "ID")]
    [BindTable("friend", Description = "", ConnName = "CommonBilling", DbType = DatabaseType.SqlServer)]
    public partial class friend : Ifriend
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

        private Int32 _memberId;
        /// <summary></summary>
        [DisplayName("memberId")]
        [Description("")]
        [DataObjectField(false, false, true, 10)]
        [BindColumn(2, "memberId", "", null, "int", 10, 0, false)]
        public virtual Int32 memberId
        {
            get { return _memberId; }
            set { if (OnPropertyChanging(__.memberId, value)) { _memberId = value; OnPropertyChanged(__.memberId); } }
        }

        private String _name;
        /// <summary></summary>
        [DisplayName("name")]
        [Description("")]
        [DataObjectField(false, false, true, 20)]
        [BindColumn(3, "name", "", null, "varchar(20)", 0, 0, false)]
        public virtual String name
        {
            get { return _name; }
            set { if (OnPropertyChanging(__.name, value)) { _name = value; OnPropertyChanged(__.name); } }
        }

        private String _isJoin;
        /// <summary></summary>
        [DisplayName("isJoin")]
        [Description("")]
        [DataObjectField(false, false, true, 20)]
        [BindColumn(4, "isJoin", "", null, "varchar(20)", 0, 0, false)]
        public virtual String isJoin
        {
            get { return _isJoin; }
            set { if (OnPropertyChanging(__.isJoin, value)) { _isJoin = value; OnPropertyChanged(__.isJoin); } }
        }

        private String _email;
        /// <summary></summary>
        [DisplayName("email")]
        [Description("")]
        [DataObjectField(false, false, true, 50)]
        [BindColumn(5, "email", "", null, "varchar(50)", 0, 0, false)]
        public virtual String email
        {
            get { return _email; }
            set { if (OnPropertyChanging(__.email, value)) { _email = value; OnPropertyChanged(__.email); } }
        }

        private DateTime _inventTime;
        /// <summary></summary>
        [DisplayName("inventTime")]
        [Description("")]
        [DataObjectField(false, false, true, 3)]
        [BindColumn(6, "inventTime", "", null, "datetime", 3, 0, false)]
        public virtual DateTime inventTime
        {
            get { return _inventTime; }
            set { if (OnPropertyChanging(__.inventTime, value)) { _inventTime = value; OnPropertyChanged(__.inventTime); } }
        }

        private DateTime _joinTime;
        /// <summary></summary>
        [DisplayName("joinTime")]
        [Description("")]
        [DataObjectField(false, false, true, 3)]
        [BindColumn(7, "joinTime", "", null, "datetime", 3, 0, false)]
        public virtual DateTime joinTime
        {
            get { return _joinTime; }
            set { if (OnPropertyChanging(__.joinTime, value)) { _joinTime = value; OnPropertyChanged(__.joinTime); } }
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
                    case __.id: return _id;
                    case __.memberId: return _memberId;
                    case __.name: return _name;
                    case __.isJoin: return _isJoin;
                    case __.email: return _email;
                    case __.inventTime: return _inventTime;
                    case __.joinTime: return _joinTime;
                    default: return base[name];
                }
            }
            set
            {
                switch (name)
                {
                    case __.id: _id = Convert.ToInt32(value); break;
                    case __.memberId: _memberId = Convert.ToInt32(value); break;
                    case __.name: _name = Convert.ToString(value); break;
                    case __.isJoin: _isJoin = Convert.ToString(value); break;
                    case __.email: _email = Convert.ToString(value); break;
                    case __.inventTime: _inventTime = Convert.ToDateTime(value); break;
                    case __.joinTime: _joinTime = Convert.ToDateTime(value); break;
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
            public static readonly Field memberId = FindByName(__.memberId);

            ///<summary></summary>
            public static readonly Field name = FindByName(__.name);

            ///<summary></summary>
            public static readonly Field isJoin = FindByName(__.isJoin);

            ///<summary></summary>
            public static readonly Field email = FindByName(__.email);

            ///<summary></summary>
            public static readonly Field inventTime = FindByName(__.inventTime);

            ///<summary></summary>
            public static readonly Field joinTime = FindByName(__.joinTime);

            static Field FindByName(String name) { return Meta.Table.FindByName(name); }
        }

        /// <summary>取得字段名称的快捷方式</summary>
        public partial class __
        {
            ///<summary></summary>
            public const String id = "id";

            ///<summary></summary>
            public const String memberId = "memberId";

            ///<summary></summary>
            public const String name = "name";

            ///<summary></summary>
            public const String isJoin = "isJoin";

            ///<summary></summary>
            public const String email = "email";

            ///<summary></summary>
            public const String inventTime = "inventTime";

            ///<summary></summary>
            public const String joinTime = "joinTime";

        }
        #endregion
    }

    /// <summary>接口</summary>
    public partial interface Ifriend
    {
        #region 属性
        /// <summary></summary>
        Int32 id { get; set; }

        /// <summary></summary>
        Int32 memberId { get; set; }

        /// <summary></summary>
        String name { get; set; }

        /// <summary></summary>
        String isJoin { get; set; }

        /// <summary></summary>
        String email { get; set; }

        /// <summary></summary>
        DateTime inventTime { get; set; }

        /// <summary></summary>
        DateTime joinTime { get; set; }
        #endregion

        #region 获取/设置 字段值
        /// <summary>获取/设置 字段值。</summary>
        /// <param name="name">字段名</param>
        /// <returns></returns>
        Object this[String name] { get; set; }
        #endregion
    }
}