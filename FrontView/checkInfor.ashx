<%@ WebHandler Language="C#" Class="checkInfor" %>

using System;
using System.Web;
using Jetso.Data;

public class checkInfor : IHttpHandler
{

    public void ProcessRequest(HttpContext context)
    {
        context.Response.ContentType = "text/plain";
        var frmnickName = context.Request.Form["frmnickName"];
        var frmgender = context.Request.QueryString["gd"];
        var frmgirl = context.Request.Form["frmgirl"];
        var frmboy = context.Request.Form["frmboy"];        
        var frmeducation = context.Request.QueryString["ed"];
        var frmincome = context.Request.QueryString["ic"];
        var IntroduceName = context.Request.Form["IntroduceName"];
        var frmbirthday = context.Request.Form["frmbirthday"];
        var ID = context.Request.Form["ID"];
        member membercurrent = member.FindByID(Convert.ToInt32(ID));

        membercurrent.nickName = frmnickName;
        membercurrent.gender = frmgender;
        membercurrent.girls = Convert.ToInt32(frmgirl);
        membercurrent.boys = Convert.ToInt32(frmboy);
        membercurrent.education = frmeducation;
        membercurrent.income = frmincome;
        membercurrent.introduceName = IntroduceName;
        membercurrent.birthday = frmbirthday;
        membercurrent.Save();
        context.Response.Write("succeed");
    }

    public bool IsReusable
    {
        get
        {
            return false;
        }
    }

}