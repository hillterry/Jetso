﻿using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Jetso.Data;

public partial class ProvideTemplate : System.Web.UI.MasterPage
{
    public string isLogin = null;
    public string nickName , Url;
    protected void Page_Load(object sender, EventArgs e)
    {
        Url = Request.Url.LocalPath.ToString();
        Url = Url.Substring(Url.LastIndexOf("/", Url.Length) + 1);
        if (provide.Current != null)
        {
            isLogin = "userExist";
            nickName = provide.Current.nickname.ToString();
        }
    }
}
