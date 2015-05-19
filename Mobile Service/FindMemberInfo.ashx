<%@ WebHandler Language="C#" Class="FindMemberInfo" %>

using System;
using System.Web;
using Jetso.Data;
public class FindMemberInfo : IHttpHandler
{
    //查找用户的信息
    public void ProcessRequest (HttpContext context) {

        string memberId = context.Request.QueryString["memberId"];
        string callback = context.Request.QueryString["callback"];

        int id = Convert.ToInt32(memberId);

        member findMember = member.FindByID(id);
        

        System.Web.Script.Serialization.JavaScriptSerializer jss = new System.Web.Script.Serialization.JavaScriptSerializer();
        
        string jsondata = jss.Serialize(findMember);


        string returnjson = callback + "([" + jsondata + "])";
        context.Response.ContentType = "text/javascript";

        context.Response.Write(returnjson);
    }
 
    public bool IsReusable {
        get {
            return false;
        }
    }

}