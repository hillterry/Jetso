<%@ WebHandler Language="C#" Class="checkRegister" %>

using System;
using System.Web;
using Jetso.Data;

public class checkRegister : IHttpHandler
{

    public void ProcessRequest(HttpContext context)
    {
        var errorMsg = "";
        context.Response.ContentType = "text/plain";
        var pass = context.Request.Form["password"];
        var email2 = context.Request.Form["Email"];
        var IntroduceName = context.Request.Form["IntroduceName"];
        var Account = context.Request.Form["Account"];
        var session = context.Request.Cookies["AccessToken"];
        member newmember = new member();

        DmFramework.Data.EntityList<pointrule> pointList = pointrule.FindAll();
        
        member introduceMember = member.FindByAccount(IntroduceName);
        if (introduceMember != null)
        {
            var newpoint = pointList[0].intropoint;

            introduceMember.point = newpoint + introduceMember.point;
            introduceMember.Update();
            PointHistory pointhistory = new PointHistory();
            pointhistory.UseTime = DateTime.Now;
            pointhistory.MemberId = introduceMember.ID;
            pointhistory.Point = newpoint;
            pointhistory.ItemName = "邀请朋友加分";
            pointhistory.CurrentPointCount = introduceMember.point;
            pointhistory.Save();

            
            friend findFriend = friend.Find("memberId",introduceMember.ID);
            if (findFriend != null)
            {
                findFriend.isJoin = "1";
                findFriend.joinTime = DateTime.Now;
                findFriend.Update();
            }
            
        }
        
        if (member.FindByEmail(email2) == null)
        {
            if (member.FindByAccount(Account) != null)
            {
                errorMsg = "error_Account";
            }
            
            else
            {
                if (session.Value == "mike")
                {
                    errorMsg = "not_Auth";
                }
                else
                {
                    int newpoint2 = pointList[0].regpoint;
                    
                    
                    newmember.email = email2;
                    newmember.password = pass;
                    newmember.introduceName = IntroduceName;
                    newmember.nickName = Account;
                    newmember.active = 0;
                    newmember.point = newpoint2;
                    newmember.AccessToken = session.Value.ToString();
                    newmember.Save();

                    PointHistory newHistory = new PointHistory();
                    newHistory.CurrentPointCount = newpoint2;
                    newHistory.MemberId = newmember.ID;
                    newHistory.Point = newpoint2;
                    newHistory.UseTime = DateTime.Now;
                    newHistory.ItemName = "注册获得积分";
                    newHistory.Save();
                    errorMsg = "sud";
                }
            }
        }
        else
        {
            errorMsg = "error_Email";
        }
        context.Response.Write(errorMsg);

    }

    public bool IsReusable
    {
        get
        {
            return false;
        }
    }

}