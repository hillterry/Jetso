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
    [BindIndex("IX_member_AddressID", false, "AddressID")]
    [BindIndex("PK_MEMBER", true, "ID")]
    [BindRelation("ID", true, "Address", "MemberID")]
    [BindRelation("ID", true, "AuctionHistory", "MemberID")]
    [BindRelation("ID", true, "coupon", "memberId")]
    [BindRelation("ID", true, "couponshare", "memberId")]
    [BindRelation("ID", true, "friend", "memberId")]
    [BindRelation("AddressID", false, "Address", "ID")]
    [BindRelation("ID", true, "Order", "MemberId")]
    [BindRelation("ID", true, "PointHistory", "MemberId")]
    [BindTable("member", Description = "", ConnName = "CommonBilling", DbType = DatabaseType.SqlServer)]
    public partial class member : Imember
    {
        #region 属性
        private Int32 _ID;
        /// <summary>会员ID</summary>
        [DisplayName("会员ID")]
        [Description("会员ID")]
        [DataObjectField(true, true, false, 10)]
        [BindColumn(1, "ID", "会员ID", null, "int", 10, 0, false)]
        public virtual Int32 ID
        {
            get { return _ID; }
            set { if (OnPropertyChanging(__.ID, value)) { _ID = value; OnPropertyChanged(__.ID); } }
        }

        private String _name;
        /// <summary>姓名</summary>
        [DisplayName("姓名")]
        [Description("姓名")]
        [DataObjectField(false, false, true, 50)]
        [BindColumn(2, "name", "姓名", null, "varchar(50)", 0, 0, false)]
        public virtual String name
        {
            get { return _name; }
            set { if (OnPropertyChanging(__.name, value)) { _name = value; OnPropertyChanged(__.name); } }
        }

        private String _nickName;
        /// <summary>账号</summary>
        [DisplayName("账号")]
        [Description("账号")]
        [DataObjectField(false, false, true, 50)]
        [BindColumn(3, "nickName", "账号", null, "varchar(50)", 0, 0, false)]
        public virtual String nickName
        {
            get { return _nickName; }
            set { if (OnPropertyChanging(__.nickName, value)) { _nickName = value; OnPropertyChanged(__.nickName); } }
        }

        private String _email;
        /// <summary>电邮地址</summary>
        [DisplayName("电邮地址")]
        [Description("电邮地址")]
        [DataObjectField(false, false, true, 50)]
        [BindColumn(4, "email", "电邮地址", null, "varchar(50)", 0, 0, false)]
        public virtual String email
        {
            get { return _email; }
            set { if (OnPropertyChanging(__.email, value)) { _email = value; OnPropertyChanged(__.email); } }
        }

        private String _password;
        /// <summary>密码</summary>
        [DisplayName("密码")]
        [Description("密码")]
        [DataObjectField(false, false, true, 50)]
        [BindColumn(5, "password", "密码", null, "varchar(50)", 0, 0, false)]
        public virtual String password
        {
            get { return _password; }
            set { if (OnPropertyChanging(__.password, value)) { _password = value; OnPropertyChanged(__.password); } }
        }

        private String _gender;
        /// <summary>性别</summary>
        [DisplayName("性别")]
        [Description("性别")]
        [DataObjectField(false, false, true, 50)]
        [BindColumn(6, "gender", "性别", null, "varchar(50)", 0, 0, false)]
        public virtual String gender
        {
            get { return _gender; }
            set { if (OnPropertyChanging(__.gender, value)) { _gender = value; OnPropertyChanged(__.gender); } }
        }

        private String _birthday;
        /// <summary>出生日期</summary>
        [DisplayName("出生日期")]
        [Description("出生日期")]
        [DataObjectField(false, false, true, 50)]
        [BindColumn(7, "birthday", "出生日期", null, "nvarchar(50)", 0, 0, true)]
        public virtual String birthday
        {
            get { return _birthday; }
            set { if (OnPropertyChanging(__.birthday, value)) { _birthday = value; OnPropertyChanged(__.birthday); } }
        }

        private String _marryStatus;
        /// <summary>婚姻情况</summary>
        [DisplayName("婚姻情况")]
        [Description("婚姻情况")]
        [DataObjectField(false, false, true, 50)]
        [BindColumn(8, "marryStatus", "婚姻情况", null, "varchar(50)", 0, 0, false)]
        public virtual String marryStatus
        {
            get { return _marryStatus; }
            set { if (OnPropertyChanging(__.marryStatus, value)) { _marryStatus = value; OnPropertyChanged(__.marryStatus); } }
        }

        private String _education;
        /// <summary>学历</summary>
        [DisplayName("学历")]
        [Description("学历")]
        [DataObjectField(false, false, true, 50)]
        [BindColumn(9, "education", "学历", null, "varchar(50)", 0, 0, false)]
        public virtual String education
        {
            get { return _education; }
            set { if (OnPropertyChanging(__.education, value)) { _education = value; OnPropertyChanged(__.education); } }
        }

        private String _phone;
        /// <summary>电话号码</summary>
        [DisplayName("电话号码")]
        [Description("电话号码")]
        [DataObjectField(false, false, true, 20)]
        [BindColumn(10, "phone", "电话号码", null, "varchar(20)", 0, 0, false)]
        public virtual String phone
        {
            get { return _phone; }
            set { if (OnPropertyChanging(__.phone, value)) { _phone = value; OnPropertyChanged(__.phone); } }
        }

        private String _adress;
        /// <summary>详细地址</summary>
        [DisplayName("详细地址")]
        [Description("详细地址")]
        [DataObjectField(false, false, true, 100)]
        [BindColumn(11, "adress", "详细地址", null, "varchar(100)", 0, 0, false)]
        public virtual String adress
        {
            get { return _adress; }
            set { if (OnPropertyChanging(__.adress, value)) { _adress = value; OnPropertyChanged(__.adress); } }
        }

        private String _introduceName;
        /// <summary>介绍人名称</summary>
        [DisplayName("介绍人名称")]
        [Description("介绍人名称")]
        [DataObjectField(false, false, true, 50)]
        [BindColumn(12, "introduceName", "介绍人名称", null, "varchar(50)", 0, 0, false)]
        public virtual String introduceName
        {
            get { return _introduceName; }
            set { if (OnPropertyChanging(__.introduceName, value)) { _introduceName = value; OnPropertyChanged(__.introduceName); } }
        }

        private String _income;
        /// <summary>收入</summary>
        [DisplayName("收入")]
        [Description("收入")]
        [DataObjectField(false, false, true, 50)]
        [BindColumn(13, "income", "收入", null, "varchar(50)", 0, 0, false)]
        public virtual String income
        {
            get { return _income; }
            set { if (OnPropertyChanging(__.income, value)) { _income = value; OnPropertyChanged(__.income); } }
        }

        private Int32 _girls;
        /// <summary>女儿</summary>
        [DisplayName("女儿")]
        [Description("女儿")]
        [DataObjectField(false, false, true, 10)]
        [BindColumn(14, "girls", "女儿", null, "int", 10, 0, false)]
        public virtual Int32 girls
        {
            get { return _girls; }
            set { if (OnPropertyChanging(__.girls, value)) { _girls = value; OnPropertyChanged(__.girls); } }
        }

        private Int32 _boys;
        /// <summary>儿子</summary>
        [DisplayName("儿子")]
        [Description("儿子")]
        [DataObjectField(false, false, true, 10)]
        [BindColumn(15, "boys", "儿子", null, "int", 10, 0, false)]
        public virtual Int32 boys
        {
            get { return _boys; }
            set { if (OnPropertyChanging(__.boys, value)) { _boys = value; OnPropertyChanged(__.boys); } }
        }

        private Int32 _active;
        /// <summary>注册状态</summary>
        [DisplayName("注册状态")]
        [Description("注册状态")]
        [DataObjectField(false, false, true, 10)]
        [BindColumn(16, "active", "注册状态", null, "int", 10, 0, false)]
        public virtual Int32 active
        {
            get { return _active; }
            set { if (OnPropertyChanging(__.active, value)) { _active = value; OnPropertyChanged(__.active); } }
        }

        private DateTime _lastLoginDate;
        /// <summary>最后登录时间</summary>
        [DisplayName("最后登录时间")]
        [Description("最后登录时间")]
        [DataObjectField(false, false, true, 3)]
        [BindColumn(17, "lastLoginDate", "最后登录时间", null, "datetime", 3, 0, false)]
        public virtual DateTime lastLoginDate
        {
            get { return _lastLoginDate; }
            set { if (OnPropertyChanging(__.lastLoginDate, value)) { _lastLoginDate = value; OnPropertyChanged(__.lastLoginDate); } }
        }

        private DateTime _createDateTime;
        /// <summary>创建时间</summary>
        [DisplayName("创建时间")]
        [Description("创建时间")]
        [DataObjectField(false, false, true, 3)]
        [BindColumn(18, "createDateTime", "创建时间", null, "datetime", 3, 0, false)]
        public virtual DateTime createDateTime
        {
            get { return _createDateTime; }
            set { if (OnPropertyChanging(__.createDateTime, value)) { _createDateTime = value; OnPropertyChanged(__.createDateTime); } }
        }

        private Int32 _point;
        /// <summary>积分</summary>
        [DisplayName("积分")]
        [Description("积分")]
        [DataObjectField(false, false, true, 10)]
        [BindColumn(19, "point", "积分", "0", "int", 10, 0, false)]
        public virtual Int32 point
        {
            get { return _point; }
            set { if (OnPropertyChanging(__.point, value)) { _point = value; OnPropertyChanged(__.point); } }
        }

        private String _commission;
        /// <summary>佣金</summary>
        [DisplayName("佣金")]
        [Description("佣金")]
        [DataObjectField(false, false, true, 100)]
        [BindColumn(20, "commission", "佣金", "0", "varchar(100)", 0, 0, false)]
        public virtual String commission
        {
            get { return _commission; }
            set { if (OnPropertyChanging(__.commission, value)) { _commission = value; OnPropertyChanged(__.commission); } }
        }

        private DateTime _checkinTime;
        /// <summary>签到时间</summary>
        [DisplayName("签到时间")]
        [Description("签到时间")]
        [DataObjectField(false, false, true, 3)]
        [BindColumn(21, "checkinTime", "签到时间", null, "datetime", 3, 0, false)]
        public virtual DateTime checkinTime
        {
            get { return _checkinTime; }
            set { if (OnPropertyChanging(__.checkinTime, value)) { _checkinTime = value; OnPropertyChanged(__.checkinTime); } }
        }

        private Boolean _isVirtualMember;
        /// <summary>虚拟会员</summary>
        [DisplayName("虚拟会员")]
        [Description("虚拟会员")]
        [DataObjectField(false, false, true, 1)]
        [BindColumn(22, "isVirtualMember", "虚拟会员", null, "bit", 0, 0, false)]
        public virtual Boolean isVirtualMember
        {
            get { return _isVirtualMember; }
            set { if (OnPropertyChanging(__.isVirtualMember, value)) { _isVirtualMember = value; OnPropertyChanged(__.isVirtualMember); } }
        }

        private Int32 _isCmember;
        /// <summary></summary>
        [DisplayName("isCmember")]
        [Description("")]
        [DataObjectField(false, false, true, 10)]
        [BindColumn(23, "isCmember", "", null, "int", 10, 0, false)]
        public virtual Int32 isCmember
        {
            get { return _isCmember; }
            set { if (OnPropertyChanging(__.isCmember, value)) { _isCmember = value; OnPropertyChanged(__.isCmember); } }
        }

        private Int32 _AddressID;
        /// <summary></summary>
        [DisplayName("AddressID")]
        [Description("")]
        [DataObjectField(false, false, true, 10)]
        [BindColumn(24, "AddressID", "", null, "int", 10, 0, false)]
        public virtual Int32 AddressID
        {
            get { return _AddressID; }
            set { if (OnPropertyChanging(__.AddressID, value)) { _AddressID = value; OnPropertyChanged(__.AddressID); } }
        }

        private String _AccessToken;
        /// <summary>FaceBook分享返回值</summary>
        [DisplayName("FaceBook分享返回值")]
        [Description("FaceBook分享返回值")]
        [DataObjectField(false, false, true, 50)]
        [BindColumn(25, "AccessToken", "FaceBook分享返回值", null, "varchar(50)", 0, 0, false)]
        public virtual String AccessToken
        {
            get { return _AccessToken; }
            set { if (OnPropertyChanging(__.AccessToken, value)) { _AccessToken = value; OnPropertyChanged(__.AccessToken); } }
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
                    case __.name : return _name;
                    case __.nickName : return _nickName;
                    case __.email : return _email;
                    case __.password : return _password;
                    case __.gender : return _gender;
                    case __.birthday : return _birthday;
                    case __.marryStatus : return _marryStatus;
                    case __.education : return _education;
                    case __.phone : return _phone;
                    case __.adress : return _adress;
                    case __.introduceName : return _introduceName;
                    case __.income : return _income;
                    case __.girls : return _girls;
                    case __.boys : return _boys;
                    case __.active : return _active;
                    case __.lastLoginDate : return _lastLoginDate;
                    case __.createDateTime : return _createDateTime;
                    case __.point : return _point;
                    case __.commission : return _commission;
                    case __.checkinTime : return _checkinTime;
                    case __.isVirtualMember : return _isVirtualMember;
                    case __.isCmember : return _isCmember;
                    case __.AddressID : return _AddressID;
                    case __.AccessToken : return _AccessToken;
                    default: return base[name];
                }
            }
            set
            {
                switch (name)
                {
                    case __.ID : _ID = Convert.ToInt32(value); break;
                    case __.name : _name = Convert.ToString(value); break;
                    case __.nickName : _nickName = Convert.ToString(value); break;
                    case __.email : _email = Convert.ToString(value); break;
                    case __.password : _password = Convert.ToString(value); break;
                    case __.gender : _gender = Convert.ToString(value); break;
                    case __.birthday : _birthday = Convert.ToString(value); break;
                    case __.marryStatus : _marryStatus = Convert.ToString(value); break;
                    case __.education : _education = Convert.ToString(value); break;
                    case __.phone : _phone = Convert.ToString(value); break;
                    case __.adress : _adress = Convert.ToString(value); break;
                    case __.introduceName : _introduceName = Convert.ToString(value); break;
                    case __.income : _income = Convert.ToString(value); break;
                    case __.girls : _girls = Convert.ToInt32(value); break;
                    case __.boys : _boys = Convert.ToInt32(value); break;
                    case __.active : _active = Convert.ToInt32(value); break;
                    case __.lastLoginDate : _lastLoginDate = Convert.ToDateTime(value); break;
                    case __.createDateTime : _createDateTime = Convert.ToDateTime(value); break;
                    case __.point : _point = Convert.ToInt32(value); break;
                    case __.commission : _commission = Convert.ToString(value); break;
                    case __.checkinTime : _checkinTime = Convert.ToDateTime(value); break;
                    case __.isVirtualMember : _isVirtualMember = Convert.ToBoolean(value); break;
                    case __.isCmember : _isCmember = Convert.ToInt32(value); break;
                    case __.AddressID : _AddressID = Convert.ToInt32(value); break;
                    case __.AccessToken : _AccessToken = Convert.ToString(value); break;
                    default: base[name] = value; break;
                }
            }
        }
        #endregion

        #region 字段名
        /// <summary>取得字段信息的快捷方式</summary>
        public partial class _
        {
            ///<summary>会员ID</summary>
            public static readonly Field ID = FindByName(__.ID);

            ///<summary>姓名</summary>
            public static readonly Field name = FindByName(__.name);

            ///<summary>账号</summary>
            public static readonly Field nickName = FindByName(__.nickName);

            ///<summary>电邮地址</summary>
            public static readonly Field email = FindByName(__.email);

            ///<summary>密码</summary>
            public static readonly Field password = FindByName(__.password);

            ///<summary>性别</summary>
            public static readonly Field gender = FindByName(__.gender);

            ///<summary>出生日期</summary>
            public static readonly Field birthday = FindByName(__.birthday);

            ///<summary>婚姻情况</summary>
            public static readonly Field marryStatus = FindByName(__.marryStatus);

            ///<summary>学历</summary>
            public static readonly Field education = FindByName(__.education);

            ///<summary>电话号码</summary>
            public static readonly Field phone = FindByName(__.phone);

            ///<summary>详细地址</summary>
            public static readonly Field adress = FindByName(__.adress);

            ///<summary>介绍人名称</summary>
            public static readonly Field introduceName = FindByName(__.introduceName);

            ///<summary>收入</summary>
            public static readonly Field income = FindByName(__.income);

            ///<summary>女儿</summary>
            public static readonly Field girls = FindByName(__.girls);

            ///<summary>儿子</summary>
            public static readonly Field boys = FindByName(__.boys);

            ///<summary>注册状态</summary>
            public static readonly Field active = FindByName(__.active);

            ///<summary>最后登录时间</summary>
            public static readonly Field lastLoginDate = FindByName(__.lastLoginDate);

            ///<summary>创建时间</summary>
            public static readonly Field createDateTime = FindByName(__.createDateTime);

            ///<summary>积分</summary>
            public static readonly Field point = FindByName(__.point);

            ///<summary>佣金</summary>
            public static readonly Field commission = FindByName(__.commission);

            ///<summary>签到时间</summary>
            public static readonly Field checkinTime = FindByName(__.checkinTime);

            ///<summary>虚拟会员</summary>
            public static readonly Field isVirtualMember = FindByName(__.isVirtualMember);

            ///<summary></summary>
            public static readonly Field isCmember = FindByName(__.isCmember);

            ///<summary></summary>
            public static readonly Field AddressID = FindByName(__.AddressID);

            ///<summary>FaceBook分享返回值</summary>
            public static readonly Field AccessToken = FindByName(__.AccessToken);

            static Field FindByName(String name) { return Meta.Table.FindByName(name); }
        }

        /// <summary>取得字段名称的快捷方式</summary>
        public partial class __
        {
            ///<summary>会员ID</summary>
            public const String ID = "ID";

            ///<summary>姓名</summary>
            public const String name = "name";

            ///<summary>账号</summary>
            public const String nickName = "nickName";

            ///<summary>电邮地址</summary>
            public const String email = "email";

            ///<summary>密码</summary>
            public const String password = "password";

            ///<summary>性别</summary>
            public const String gender = "gender";

            ///<summary>出生日期</summary>
            public const String birthday = "birthday";

            ///<summary>婚姻情况</summary>
            public const String marryStatus = "marryStatus";

            ///<summary>学历</summary>
            public const String education = "education";

            ///<summary>电话号码</summary>
            public const String phone = "phone";

            ///<summary>详细地址</summary>
            public const String adress = "adress";

            ///<summary>介绍人名称</summary>
            public const String introduceName = "introduceName";

            ///<summary>收入</summary>
            public const String income = "income";

            ///<summary>女儿</summary>
            public const String girls = "girls";

            ///<summary>儿子</summary>
            public const String boys = "boys";

            ///<summary>注册状态</summary>
            public const String active = "active";

            ///<summary>最后登录时间</summary>
            public const String lastLoginDate = "lastLoginDate";

            ///<summary>创建时间</summary>
            public const String createDateTime = "createDateTime";

            ///<summary>积分</summary>
            public const String point = "point";

            ///<summary>佣金</summary>
            public const String commission = "commission";

            ///<summary>签到时间</summary>
            public const String checkinTime = "checkinTime";

            ///<summary>虚拟会员</summary>
            public const String isVirtualMember = "isVirtualMember";

            ///<summary></summary>
            public const String isCmember = "isCmember";

            ///<summary></summary>
            public const String AddressID = "AddressID";

            ///<summary>FaceBook分享返回值</summary>
            public const String AccessToken = "AccessToken";

        }
        #endregion
    }

    /// <summary>接口</summary>
    public partial interface Imember
    {
        #region 属性
        /// <summary>会员ID</summary>
        Int32 ID { get; set; }

        /// <summary>姓名</summary>
        String name { get; set; }

        /// <summary>账号</summary>
        String nickName { get; set; }

        /// <summary>电邮地址</summary>
        String email { get; set; }

        /// <summary>密码</summary>
        String password { get; set; }

        /// <summary>性别</summary>
        String gender { get; set; }

        /// <summary>出生日期</summary>
        String birthday { get; set; }

        /// <summary>婚姻情况</summary>
        String marryStatus { get; set; }

        /// <summary>学历</summary>
        String education { get; set; }

        /// <summary>电话号码</summary>
        String phone { get; set; }

        /// <summary>详细地址</summary>
        String adress { get; set; }

        /// <summary>介绍人名称</summary>
        String introduceName { get; set; }

        /// <summary>收入</summary>
        String income { get; set; }

        /// <summary>女儿</summary>
        Int32 girls { get; set; }

        /// <summary>儿子</summary>
        Int32 boys { get; set; }

        /// <summary>注册状态</summary>
        Int32 active { get; set; }

        /// <summary>最后登录时间</summary>
        DateTime lastLoginDate { get; set; }

        /// <summary>创建时间</summary>
        DateTime createDateTime { get; set; }

        /// <summary>积分</summary>
        Int32 point { get; set; }

        /// <summary>佣金</summary>
        String commission { get; set; }

        /// <summary>签到时间</summary>
        DateTime checkinTime { get; set; }

        /// <summary>虚拟会员</summary>
        Boolean isVirtualMember { get; set; }

        /// <summary></summary>
        Int32 isCmember { get; set; }

        /// <summary></summary>
        Int32 AddressID { get; set; }

        /// <summary>FaceBook分享返回值</summary>
        String AccessToken { get; set; }
        #endregion

        #region 获取/设置 字段值
        /// <summary>获取/设置 字段值。</summary>
        /// <param name="name">字段名</param>
        /// <returns></returns>
        Object this[String name] { get; set; }
        #endregion
    }
}