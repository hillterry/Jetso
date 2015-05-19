<%@ WebHandler Language="C#" Class="checkChangeEmail" %>

using System;
using System.Web;
using Jetso.Data;

public class checkChangeEmail : IHttpHandler {
    
    public void ProcessRequest (HttpContext context) {
        String errorMsg = "";
        context.Response.ContentType = "text/plain";
        var pass = context.Request.Form["Password"];
        var email2 = context.Request.Form["NewEmail"];
        var ID = context.Request.Form["ID"];
        member membercurrent = member.FindByID(Convert.ToInt32(ID));
        if (membercurrent.password == pass)
        {
            if (member.FindByEmail(email2) == null)
            {
                var mem = membercurrent;
                mem.email = email2;
                mem.Update();
                errorMsg = "修改成功!";
            }
            else
            {
                errorMsg = "此邮箱已存在!";
            }
        }
        else
        {
            errorMsg = "密码错误!";
        }
        context.Response.Write(errorMsg);

        
    }
 
    public bool IsReusable {
        get {
            return false;
        }
    }

}