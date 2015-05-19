<%@ WebHandler Language="C#" Class="FindMyProduct" %>

using System;
using System.Web;
using Jetso.Data;
using DmFramework.Data;

public class FindMyProduct : IHttpHandler {
    //查找我已经拍卖到的商品
    public void ProcessRequest (HttpContext context) {
        string memberId = context.Request.QueryString["memberId"];
        string callback = context.Request.QueryString["callback"];

        int id = Convert.ToInt32(memberId);


        EntityList<Auction> myProductList = Auction.FindAllByMemberIDandStatus(id, 3);


        foreach (Jetso.Data.Auction a in myProductList)
        {
            a.ProductImage3 = GetIPAdress.ip + a.ProductImage3;
        }
        
        System.Web.Script.Serialization.JavaScriptSerializer jss = new System.Web.Script.Serialization.JavaScriptSerializer();
        string jsondata;

        if (myProductList.Count > 0)
        {
            jsondata = jss.Serialize(myProductList);
            string returnjson = callback + "(" + jsondata + ")";
            context.Response.ContentType = "text/javascript";

            context.Response.Write(returnjson);
        }
        else
        {
            Auction nullAuction = new Auction();
            jsondata = jss.Serialize(nullAuction);
            string returnjson = callback + "([" + jsondata + "])";
            context.Response.ContentType = "text/javascript";

            context.Response.Write(returnjson);
        }
         

        
        
    }
 
    public bool IsReusable {
        get {
            return false;
        }
    }

}