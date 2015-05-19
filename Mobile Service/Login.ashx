<%@ WebHandler Language="C#" Class="Login" %>

using System;
using System.Web;
using Jetso.Data;
public class Login : IHttpHandler {
    //用户登录
    public void ProcessRequest (HttpContext context) {

        string callback = context.Request.QueryString["callback"];
        string username = context.Request.QueryString["name"];
        string password = context.Request.QueryString["password"];
        string url = context.Request.Url.ToString();
        context.Response.ContentType = "text/javascript";
        System.Web.Script.Serialization.JavaScriptSerializer jss = new System.Web.Script.Serialization.JavaScriptSerializer();
        string jsondata;
        string returnjson;

        if (username == "" || password == "")
        {
            jsondata = jss.Serialize("accountNull");
            
        }
        else
        {

            member findMember = member.FindByUserName(username);



            if (findMember == null)
            {
                jsondata = jss.Serialize("notE");
                
            }
            else
            {
                if (findMember.password == password)
                {
                    //登录成功返回会员的ID
                    jsondata = jss.Serialize(findMember.ID);
                    
                }
                else
                {
                    jsondata = jss.Serialize("pass");
                    
                }
            }
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