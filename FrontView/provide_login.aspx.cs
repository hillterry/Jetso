using System;
using System.Collections.Generic;
using System.Threading;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DmFramework.Data.CommonEntity.Exceptions;
using DmFramework.Log;
using Jetso.Data;

public partial class FrontView_provide_login : System.Web.UI.Page
{

    public string errorMsg = " ";

    protected void Page_Load(object sender, EventArgs e)
    {
        if (provide.CheckLogin())
        {
            Response.Redirect("../Jesto/provide_info.aspx");
        }
    }
    protected void button1_Click(object sender, EventArgs e)
    {
        try
        {
            string account = Request.Form["Account"];
            string password = Request.Form["Password"];
            provide loginMember = provide.Login(account, password);
            if (loginMember != null)
            {
                loginMember.lastLoginTime = System.DateTime.Now;
                if (loginMember.Update() != 1)
                {
                    Response.Write("error");
                }
                else
                {
                    Response.Redirect("../Jesto/provide_info.aspx");
                }
            }



        }
        catch (ThreadAbortException) { }
        catch (Exception ex)
        {
            String msg = "帳號或者密碼錯誤！";
            msg += "," + ex.Message;
            if (ex is EntityException)
                msg += "," + ex.Message;
            else
                HmTrace.WriteException(ex);
            errorMsg = msg;
        }
    }
}