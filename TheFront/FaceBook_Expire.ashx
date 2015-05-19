<%@ WebHandler Language="C#" Class="FaceBook_Expire" %>

using System;
using System.Web;
using Jetso.Data;

public class FaceBook_Expire : IHttpHandler {
    
    public void ProcessRequest (HttpContext context) {
        var accessToken = context.Request["accessToken"];
        var oldToken = member.Current.AccessToken;
        context.Response.Cookies["AccessToken"].Value = accessToken;
        context.Response.Cookies["AccessToken"].Expires = DateTime.Now.AddDays(1);
        member.Current.AccessToken = accessToken.ToString();
        member.Current.Update();
        if (oldToken != accessToken)
        {
            context.Response.Redirect("facebook_Expire.aspx?para=su");
        }
        else
        {
            context.Response.Redirect("facebook_Expire.aspx");
        }
        
    }
 
    public bool IsReusable {
        get {
            return false;
        }
    }

}