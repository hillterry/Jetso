<%@ WebHandler Language="C#" Class="FindUnBidProduct" %>

using System;
using System.Web;

public class FindUnBidProduct : IHttpHandler {
    //用来获取将要推出的拍卖商品
    public void ProcessRequest (HttpContext context) {
        DmFramework.Data.EntityList<Jetso.Data.Auction> AllAuction = Jetso.Data.Auction.FindAll("AuctionSatus", 1);
        foreach (Jetso.Data.Auction a in AllAuction)
        {
            a.ProductImage3 = GetIPAdress.ip + a.ProductImage3;
        }

        System.Web.Script.Serialization.JavaScriptSerializer jss = new System.Web.Script.Serialization.JavaScriptSerializer();

        string jsondata = jss.Serialize(AllAuction);

        string callback = context.Request.QueryString["callback"];

        string returnjson = callback + "(" + jsondata + ")";
        context.Response.ContentType = "text/javascript";

        context.Response.Write(returnjson);
    }
 
    public bool IsReusable {
        get {
            return false;
        }
    }

}