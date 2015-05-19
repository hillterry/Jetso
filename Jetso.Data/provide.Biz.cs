﻿using System;
using System.ComponentModel;
using System.Data.Common;
using System.Web;
using System.Xml.Serialization;
using DmFramework.Data;
using DmFramework.Data.CommonEntity.Exceptions;
using DmFramework.Security;
using DmFramework.Web;

namespace Jetso.Data
{
	/// <summary></summary>
	public partial class provide : Entity<provide>
	{
		#region 对象操作﻿

		/// <summary>验证数据，通过抛出异常的方式提示验证失败。</summary>
		/// <param name="isNew"></param>
		public override void Valid(Boolean isNew)
		{
			// 这里验证参数范围，建议抛出参数异常，指定参数名，前端用户界面可以捕获参数异常并聚焦到对应的参数输入框
			//if (MatchHelper.StrIsNullOrEmpty(Name)) throw new ArgumentNullException(_.Name, _.Name.DisplayName + "无效！");
			//if (!isNew && ID < 1) throw new ArgumentOutOfRangeException(_.ID, _.ID.DisplayName + "必须大于0！");

			// 建议先调用基类方法，基类方法会对唯一索引的数据进行验证
			base.Valid(isNew);

			// 在新插入数据或者修改了指定字段时进行唯一性验证，CheckExist内部抛出参数异常
			//if (isNew || Dirtys[__.Name]) CheckExist(__.Name);

			if (isNew && !Dirtys[__.createTime]) createTime = DateTime.Now;
		}

		///// <summary>首次连接数据库时初始化数据，仅用于实体类重载，用户不应该调用该方法</summary>
		//[EditorBrowsable(EditorBrowsableState.Never)]
		//protected override void InitData()
		//{
		//    base.InitData();

		//    // InitData一般用于当数据表没有数据时添加一些默认数据，该实体类的任何第一次数据库操作都会触发该方法，默认异步调用
		//    // Meta.Count是快速取得表记录数
		//    if (Meta.Count > 0) return;

		//    // 需要注意的是，如果该方法调用了其它实体类的首次数据库操作，目标实体类的数据初始化将会在同一个线程完成
		//    HmTrace.WriteDebug("开始初始化{0}[{1}]数据……", typeof(provide).Name, Meta.Table.DataTable.DisplayName);

		//    var entity = new provide();
		//    entity.nickname = "abc";
		//    entity.email = "abc";
		//    entity.password = "abc";
		//    entity.name = "abc";
		//    entity.companyName = "abc";
		//    entity.phone = "abc";
		//    entity.isMemberInfo = 0;
		//    entity.isCoupon = 0;
		//    entity.MemberStat = 0;
		//    entity.createTime = DateTime.Now;
		//    entity.lastLoginTime = DateTime.Now;
		//    entity.shopName = "abc";
		//    entity.shopLogo = "abc";
		//    entity.shopUrl = "abc";
		//    entity.shopShortDesc = "abc";
		//    entity.money = "abc";
		//    entity.Insert();

		//    HmTrace.WriteDebug("完成初始化{0}[{1}]数据！", typeof(provide).Name, Meta.Table.DataTable.DisplayName);
		//}

		/// <summary>已重载。删除关联数据</summary>
		/// <returns></returns>
		protected override int OnDelete()
		{
			if (products != null) products.Delete();

			return base.OnDelete();
		}

		///// <summary>已重载。基类先调用Valid(true)验证数据，然后在事务保护内调用OnInsert</summary>
		///// <returns></returns>
		//public override Int32 Insert()
		//{
		//    return base.Insert();
		//}

		///// <summary>已重载。在事务保护范围内处理业务，位于Valid之后</summary>
		///// <returns></returns>
		//protected override Int32 OnInsert()
		//{
		//    return base.OnInsert();
		//}

		#endregion

		#region 扩展属性﻿

		[NonSerialized]
		private EntityList<product> _products;

		/// <summary>该provide所拥有的product集合</summary>
		[XmlIgnore]
		public EntityList<product> products
		{
			get
			{
				if (_products == null && ID > 0 && !Dirtys.ContainsKey("products"))
				{
					_products = product.FindAllByprovideId(ID);
					Dirtys["products"] = true;
				}
				return _products;
			}
			set { _products = value; }
		}

		#endregion

		#region 扩展查询﻿


        /// <summary>根据Email查找</summary>
        /// <param name="email"></param>
        /// <returns></returns>
        [DataObjectMethod(DataObjectMethodType.Select, false)]
        public static provide FindByEmail(String email)
        {
            if (String.IsNullOrEmpty(email)) return null;

            if (Meta.Count >= 1000)
            {
                return Find(_.email, email);
            }
            else
            {// 实体缓存
                return Meta.Cache.Entities.Find(_.email, email);
            }
        }


        /// <summary>根据Account查找</summary>
        /// <param name="Account"></param>
        /// <returns></returns>
        [DataObjectMethod(DataObjectMethodType.Select, false)]
        public static provide FindByAccount(String Account)
        {
            if (String.IsNullOrEmpty(Account)) return null;

            if (Meta.Count >= 1000)
            {
                return Find(_.nickname, Account);
            }
            else
            {// 实体缓存
                return Meta.Cache.Entities.Find(_.nickname, Account);
            }
        }


		/// <summary>根据ID查找</summary>
		/// <param name="id"></param>
		/// <returns></returns>
		[DataObjectMethod(DataObjectMethodType.Select, false)]
		public static provide FindByID(Int32 id)
		{
			if (Meta.Count >= 1000)
				return Find(_.ID, id);
			else // 实体缓存
				return Meta.Cache.Entities.Find(_.ID, id);

			// 单对象缓存
			//return Meta.SingleCache[id];
		}

		#endregion

		#region 高级查询

		// 以下为自定义高级查询的例子

		///// <summary>
		///// 查询满足条件的记录集，分页、排序
		///// </summary>
		///// <param name="key">关键字</param>
		///// <param name="orderClause">排序，不带Order By</param>
		///// <param name="startRowIndex">开始行，0表示第一行</param>
		///// <param name="maximumRows">最大返回行数，0表示所有行</param>
		///// <returns>实体集</returns>
		//[DataObjectMethod(DataObjectMethodType.Select, true)]
		//public static EntityList<provide> Search(String key, String orderClause, Int32 startRowIndex, Int32 maximumRows)
		//{
		//    return FindAll(SearchWhere(key), orderClause, null, startRowIndex, maximumRows);
		//}

		///// <summary>
		///// 查询满足条件的记录总数，分页和排序无效，带参数是因为ObjectDataSource要求它跟Search统一
		///// </summary>
		///// <param name="key">关键字</param>
		///// <param name="orderClause">排序，不带Order By</param>
		///// <param name="startRowIndex">开始行，0表示第一行</param>
		///// <param name="maximumRows">最大返回行数，0表示所有行</param>
		///// <returns>记录数</returns>
		//public static Int32 SearchCount(String key, String orderClause, Int32 startRowIndex, Int32 maximumRows)
		//{
		//    return FindCount(SearchWhere(key), null, null, 0, 0);
		//}

		/// <summary>构造搜索条件</summary>
		/// <param name="key">关键字</param>
		/// <returns></returns>
		private static String SearchWhere(String key)
		{
			// WhereExpression重载&和|运算符，作为And和Or的替代
			// SearchWhereByKeys系列方法用于构建针对字符串字段的模糊搜索
			var exp = SearchWhereByKeys(key, null);

			// 以下仅为演示，Field（继承自FieldItem）重载了==、!=、>、<、>=、<=等运算符（第4行）
			//if (userid > 0) exp &= _.OperatorID == userid;
			//if (isSign != null) exp &= _.IsSign == isSign.Value;
			//if (start > DateTime.MinValue) exp &= _.OccurTime >= start;
			//if (end > DateTime.MinValue) exp &= _.OccurTime < end.AddDays(1).Date;

			return exp;
		}

		#endregion

		#region 扩展操作

        private static HttpState<provide> _httpState;


        public static HttpState<provide> HttpState
        {
            get
            {
                if (_httpState != null) return _httpState;
                _httpState = new HttpState<provide>("Provide");
                _httpState.CookieToEntity = new Converter<HttpCookie, provide>(delegate(HttpCookie cookie)
                {
                    if (cookie == null) return null;

                    var user = HttpUtility.UrlDecode(cookie["m"]);
                    var pass = cookie["pwd"];
                    if (String.IsNullOrEmpty(user) || String.IsNullOrEmpty(pass))
                    {
                        return null;
                    }

                    try
                    {

                        return Login(user, pass, -1);

                    }
                    catch (DbException ex)
                    {
                        return null;
                    }
                    catch (Exception ex)
                    {
                        //WriteLog("登录", user + "登录失败！" + ex.Message);
                        return null;
                    }
                });
                _httpState.EntityToCookie = new Converter<provide, HttpCookie>(delegate(provide entity)
                {
                    var cookie = HttpContext.Current.Response.Cookies[_httpState.Key];
                    if (entity != null)
                    {
                        cookie["m"] = HttpUtility.UrlEncode(entity._email);
                        cookie["pwd"] = !String.IsNullOrEmpty(entity._password) ? DataHelper.Hash(entity._password) : null;
                    }
                    else
                    {
                        cookie.Value = null;
                    }
                    return cookie;
                });

                return _httpState;
            }
            set { _httpState = value; }
        }
        /// <summary>当前登录用户</summary>
        public static provide Current
        {
            get
            {
                provide entity = HttpState.Current;
                if (HttpState.Get(null, null) != entity)
                {
                    HttpState.Current = entity;
                }
                return entity;
            }
            set
            {
                HttpState.Current = value;
            }
        }

        public static provide CurrentNoAutoLogin { get { return HttpState.Get(null, null); } }


        /// <summary>登录</summary>
        /// <param name="username"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        public static provide Login(String username, String password)
        {
            if (String.IsNullOrEmpty(username)) throw new ArgumentNullException("用户名");

            //if (String.IsNullOrEmpty(password)) throw new ArgumentNullException("password");

            try
            {
                return Login(username, password, 1);
            }
            catch (Exception ex)
            {
                //WriteLog("登录", username + "登录失败！" + ex.Message);
                throw;
            }
        }



        private static provide Login(String username, String password, Int32 hashTimes)
        {
            //if (String.IsNullOrEmpty(username)) return null;
            if (String.IsNullOrEmpty(username)) throw new Exception("该帐号不存在！");


            //过滤帐号中的空格，防止出现无操作无法登录的情况
            var account = username.Trim();
            var user = FindByEmail(account);
            var user2 = FindByAccount(account);

            //if (user == null) return null;
            if (user == null && user2 == null) throw new Exception("该帐号错误！");

            //if (!user.IsEnable) throw new EntityException("账号被禁用！");

            // 数据库为空密码，任何密码均可登录
            if (String.IsNullOrEmpty(password)) throw new Exception("密码不能为空！");
            if (user != null) { user = CheckMember(user, hashTimes, password); }
            if (user2 != null) { user2 = CheckMember(user2, hashTimes, password); }


            //user.SaveLoginInfo();
            if (user != null)
            {
                Current = user;
                return user;
            }
            if (user2 != null)
            {
                Current = user2;
                return user2;
            }
            else
            {
                return null;
            }
            //if (hashTimes == -1)
            //	WriteLog("自动登录", username);
            //else
            //	WriteLog("登录", username);


        }

        /// <summary>检查账号是否存在</summary>
        /// <returns></returns>
        public static provide CheckMember(provide user_, Int32 hashTimes, String password)
        {
            provide user = user_;
            if (!String.IsNullOrEmpty(user._password))
            {
                if (hashTimes > 0)
                {
                    if (!user._password.Equals(password))
                    {
                        throw new Exception("密码不正确！");
                    }
                }
                else
                {
                    var p = user._password;

                    for (int i = 0; i > hashTimes; i--)
                    {
                        p = DataHelper.Hash(p);
                    }
                    if (!p.EqualIgnoreCase(password)) throw new EntityException("密码不正确！");
                    //return null;
                }
            }
            return user;
        }

        /// <summary>检查是否已登录</summary>
        /// <returns></returns>
        public static Boolean CheckLogin()
        {
            // 当前管理员

            if (Current == null) { return false; }
            return true;
        }


        static HttpContext Http { get { return HttpContext.Current; } }

        /// <summary>注销</summary>
        public void Logout()
        {
            Current = null;

        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public static Int32 Login_user()
        {
            // 当前管理员
            provide entity = Current;
            if (entity == null) { return 0; }
            return entity._ID;
        }


		#endregion

		#region 业务

		#endregion
	}
}