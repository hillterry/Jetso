<%@ WebHandler Language="C#" Class="Handler" %>

using System;
using System.Web;
using Facebook;
public class Handler : IHttpHandler, System.Web.SessionState.IRequiresSessionState
{
    
    public void ProcessRequest (HttpContext context) {
        var accessToken = context.Request["accessToken"];
        context.Session["AccessToken"] = accessToken;
        context.Response.Cookies["AccessToken"].Value = accessToken;
        context.Response.Cookies["AccessToken"].Expires = DateTime.Now.AddDays(1);
        context.Response.Redirect("facebookAuth.aspx");
    }
 
    public bool IsReusable {
        get {
            return false;
        }
    }

}