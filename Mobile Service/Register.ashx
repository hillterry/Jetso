<%@ WebHandler Language="C#" Class="Register" %>

using System;
using System.Web;
using Jetso.Data;
public class Register : IHttpHandler {
    
    public void ProcessRequest (HttpContext context) {
        
        context.Response.ContentType = "text/javascript";
        string callback = context.Request.QueryString["callback"];
        var username = context.Request.QueryString["username"];
        var password = context.Request.QueryString["password"];
        var name = context.Request.QueryString["name"];
        var email = context.Request.QueryString["email"];
        var phone = context.Request.QueryString["phone"];
        System.Web.Script.Serialization.JavaScriptSerializer jss = new System.Web.Script.Serialization.JavaScriptSerializer();
        string jsondata;
        string returnjson;
        member newmember = new member();

        if (member.FindByEmail(email) == null)
        {
            if (member.FindByAccount(username) != null)
            {
                jsondata = jss.Serialize("error_Account");
            }
            else
            {
                newmember.email = email;
                newmember.password = password;
                newmember.nickName = username;
                newmember.name = name;
                newmember.active = 1;
                newmember.Save();
                jsondata = jss.Serialize("sud");
            }
        }
        else
        {
            
            jsondata = jss.Serialize("error_Email");
        }
        returnjson = callback + "([" + jsondata + "])";
        context.Response.Write(returnjson);
    }
 
    public bool IsReusable {
        get {
            return false;
        }
    }

}