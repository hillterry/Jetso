<%@ WebHandler Language="C#" Class="checkinTime" %>

using System;
using System.Web;
using Jetso.Data;

public class checkinTime : IHttpHandler {
    
    public void ProcessRequest (HttpContext context) {
        context.Response.ContentType = "text/plain";
        
        DmFramework.Data.EntityList<pointrule> pointList = pointrule.FindAll();
        var newpoint = pointList[0].loginpoint;
        member.Current.checkinTime = DateTime.Now;
        member.Current.point = newpoint + member.Current.point;
        member.Current.Update();
        PointHistory pointhistory = new PointHistory();
        pointhistory.UseTime = DateTime.Now;
        pointhistory.MemberId = member.Current.ID;
        pointhistory.Point = newpoint;
        pointhistory.ItemName = "签到";
        pointhistory.CurrentPointCount = member.Current.point;
        pointhistory.Save();
        context.Response.Write("sud");
    }
 
    public bool IsReusable {
        get {
            return false;
        }
    }

}