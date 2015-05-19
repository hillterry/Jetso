<%@ WebHandler Language="C#" Class="GetResId" %>

using System;
using System.Web;
using Jetso.Data;
public class GetResId : IHttpHandler {
    
    public void ProcessRequest (HttpContext context) {
        string userId = context.Request.QueryString["account"];
        string resId = context.Request.QueryString["resId"];
        MobileRegIds newRegId = new MobileRegIds();
        newRegId.RegsId = Convert.ToInt32(resId);
        newRegId.User = Convert.ToInt32(userId);
        newRegId.Save();
    }
 
    public bool IsReusable {
        get {
            return false;
        }
    }

}