<%@ WebHandler Language="C#" Class="ChangePassword" %>

using System;
using System.Web;
using Jetso.Data;

public class ChangePassword : IHttpHandler {
    
    public void ProcessRequest (HttpContext context) {

        string url = context.Request.Url.ToString();
        string callback = context.Request.QueryString["callback"];
        int memberId = Convert.ToInt32(context.Request.QueryString["memberId[]"]);
        string oldPwd = context.Request.QueryString["oldPwd"];
        string newPwd = context.Request.QueryString["newPwd"];
        string cofPwd = context.Request.QueryString["cofPwd"];
        context.Response.ContentType = "text/javascript";
        System.Web.Script.Serialization.JavaScriptSerializer jss = new System.Web.Script.Serialization.JavaScriptSerializer();
        string jsondata;
        string returnjson;

        member findMember = member.FindByID(memberId);

        if (oldPwd == "" || newPwd == "" || cofPwd == "")
        {
            jsondata = jss.Serialize("pwdNull");

        }
        else
        {
            if (oldPwd != findMember.password)
            {
                jsondata = jss.Serialize("oldError");
            }
            else
            {
                findMember.password = newPwd;
                findMember.Update();

                jsondata = jss.Serialize("Success");
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