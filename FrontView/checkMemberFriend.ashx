<%@ WebHandler Language="C#" Class="checkMemberFriend" %>

using System;
using System.Web;
using Jetso.Data;
using System.Text;
using DmFramework.Data;

public class checkMemberFriend : IHttpHandler
{

    public void ProcessRequest(HttpContext context)
    {
        string errorMsg = " ";
        context.Response.ContentType = "text/plain";
        member currentMember = member.Current;
        int memberId = currentMember.ID;

        var email = context.Request.Form["frmEmail"];
        var remark = context.Request.Form["frmMessage"];
        string name = context.Request.Form["frmName"];


        string[] names = { "memberId", "email" };
        object[] values = { memberId, email };

        friend exist = friend.Find(names, values);
        member existEmail = member.FindByEmail(email);


        friend existInvite = friend.Find("email", email);

        if (exist != null)
        {
            errorMsg = "您已經邀請了這個好友，不能重複邀請";
            //Response.Write("<script language=javascript>alert('" + errorMsg + "');</" + "script>");
        }
        else if (existEmail != null)
        {
            errorMsg = "您邀請的電子郵箱" + email + "已經注冊";
            // Response.Write("<script language=javascript>alert('" + errorMsg + "');</" + "script>");
        }
        else if (existInvite != null)
        {
            errorMsg = "您邀請的電子郵箱" + email + "已經被其他人邀請。";
            // Response.Write("<script language=javascript>alert('" + errorMsg + "');</" + "script>");
        }
        else
        {
            friend newFriend = new friend();
            newFriend.memberId = memberId;
            newFriend.inventTime = DateTime.Now;
            newFriend.isJoin = "0";
            newFriend.name = name;
            newFriend.email = email;


            if (newFriend.Insert() != 1)
            {
                errorMsg = "出錯了,請重試.";
                //Response.Write("<script language=javascript>alert('" + errorMsg + "');</" + "script>");
            }
            else
            {
                ///发送邮件
                String WebUrl = HttpContext.Current.Request.Url.Host;
                EntityList<MailServer> mailConfig = MailServer.FindAll();
                MailServer mailServer = mailConfig[0];
                string smtpServer = mailServer.server;
                int port = Convert.ToInt32(mailServer.port);
                string fromMail = mailServer.fromMail;
                string subject = "您的朋友" + currentMember.name + "邀請您加入Bidding！";


                StringBuilder mailbody = new StringBuilder();
                mailbody.Append("<!DOCTYPE HTML>");
                mailbody.Append("<html>");
                mailbody.Append("<body>");
                mailbody.Append("<br/>");
                mailbody.Append("您的朋友" + currentMember.name + "邀請您加入Bidding");
                mailbody.Append("Bidding實現了一個新的網路概念，能更增廣您對網路的運用，並在其中獲得豐富的獎勵。<br/><br/>");

                mailbody.Append(remark + "<br/><br/>");

                mailbody.Append("您注冊的時候請在介紹人欄內輸入我的帳號：" + currentMember.nickName + "<br/><br/>");


                mailbody.Append("<a href=");
                mailbody.Append("http://" + WebUrl + "/TheFront/register.aspx?email=" + email + "&sid=" + context.Session.SessionID + "&name=" + currentMember.nickName + ">");


                mailbody.Append("http://" + WebUrl + "/TheFront/register.aspx?email=" + email + "&sid=" + context.Session.SessionID + "&name=" + currentMember.nickName + "</a>");
                mailbody.Append("<br/>");
                mailbody.Append("如上連結打不開，請將此啟動網址貼入您的網頁瀏覽器中並連結到此網址");

                mailbody.Append("<br/><br/>");


                mailbody.Append("</body>");
                mailbody.Append("</html>");

                string strbody = Convert.ToString(mailbody);


                try
                {
                    SendMail.SendMail.sendMail(smtpServer, port, fromMail, email, subject, strbody, true, 950);
                }
                catch (Exception e)
                {
                    //Response.Write(e.Message);
                }
                                
                errorMsg = "您的邀請已經成功發送。";
                //Response.Write("<script language=javascript>alert('" + errorMsg + "');</" + "script>");
            }
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
