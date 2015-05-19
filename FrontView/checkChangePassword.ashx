<%@ WebHandler Language="C#" Class="checkChangePassword" %>

using System;
using System.Web;
using Jetso.Data;

public class checkChangePassword : IHttpHandler
{

    public void ProcessRequest(HttpContext context)
    {
        context.Response.ContentType = "text/plain";
        String errorMsg = "";
        context.Response.ContentType = "text/plain";
        var newpass = context.Request.Form["newpassword"];
        var oldPass = context.Request.Form["oldpassword"];
        var ID = context.Request.Form["ID"];
        member membercurrent = member.FindByID(Convert.ToInt32(ID));
        if (membercurrent.password == oldPass)
        {
            membercurrent.password = newpass;
            errorMsg = membercurrent.Save() == 1 ? "修改成功!" : "";

        }
        else
        {
            errorMsg = "密码错误!";
        }
        context.Response.Write(errorMsg);
    }

    public bool IsReusable
    {
        get
        {
            return false;
        }
    }

}