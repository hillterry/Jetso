<%@ WebHandler Language="C#" Class="ShareFacebook" %>

using System;
using System.Web;
using Jetso.Data;
using Facebook;
public class ShareFacebook : IHttpHandler {
    
    public void ProcessRequest (HttpContext context) {
        try
        {
            context.Response.ContentType = "text/plain";
            string id = context.Request.QueryString["id"];
            Auction findAuction = Auction.FindByID(Convert.ToInt32(id));
            string message;
            member findMember = member.FindByID(member.Current.ID);
            var accessToken = findMember.AccessToken;
            if (accessToken == null)
            {
                message = "auth_error";
            }
            else
            {
                var client = new FacebookClient(accessToken);
                dynamic post = client.Post("feed", new { link = "bidding.wowmyweb.com/TheFront/precinct?ID=" + id, message = findAuction.ProductBrief, name = findAuction.ProductName });
                string a = post.id;

                if (a != null)
                {
                    DmFramework.Data.EntityList<pointrule> pointList = pointrule.FindAll();
                    int newpoint = pointList[0].facebookpoint;
                    int oldPoint = member.Current.point;
                    member.Current.point = newpoint + oldPoint;
                    member.Current.Update();

                    PointHistory newHistory = new PointHistory();
                    newHistory.UseTime = DateTime.Now;
                    newHistory.MemberId = member.Current.ID;
                    newHistory.Point = newpoint;
                    newHistory.ItemName = "分享获得积分";
                    newHistory.CurrentPointCount = member.Current.point;
                    newHistory.Save();
                    message = "success";
                }
                else
                {
                    message = "error";
                }

            }
            context.Response.Write(message);
        }
        catch (Exception ee)
        {
            context.Response.Write("auth_error");
        }
        
    }
 
    public bool IsReusable {
        get {
            return false;
        }
    }

}