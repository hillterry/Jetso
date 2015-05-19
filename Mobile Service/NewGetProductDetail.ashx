<%@ WebHandler Language="C#" Class="NewGetProductDetail" %>

using System;
using System.Web;
using Jetso.Data;

public class NewGetProductDetail : IHttpHandler {
    
    public void ProcessRequest (HttpContext context) {
        string requserUrl = context.Request.Url.ToString();
        string productId = context.Request.QueryString["productId"];
        string callback = context.Request.QueryString["callback"];
        string url = GetIPAdress.ip;
        int id = Convert.ToInt32(productId);

        Auction productDetail = Auction.FindByID(id);
        AuctionToJson auctionJson = new AuctionToJson();
        if (productDetail.AuctionSatus != 3 && productDetail.EndTime <= DateTime.Now && productDetail.MinPrice <= productDetail.BiddingPriceNow)
        {
            productDetail.AuctionSatus = 3;
            auctionJson.countTime = 0;
        }else
        {
            DateTime nowTime = DateTime.Now;
            DateTime endTime = productDetail.EndTime;

            TimeSpan countTime = endTime - nowTime;
            int toalSeconds = countTime.Days * 24 * 60 * 60 + countTime.Hours * 60 * 60 + countTime.Minutes * 60 + countTime.Seconds;
            auctionJson.countTime = toalSeconds;
        }

        auctionJson.ProductImage1 = url + productDetail.ProductImage1;
        auctionJson.ProductImage2 = url + productDetail.ProductImage2;
        auctionJson.ProductImage3 = url + productDetail.ProductImage3;
        auctionJson.BiddingPriceNow = productDetail.BiddingPriceNow;
        auctionJson.MarkPrice = productDetail.MarkPrice;
        auctionJson.ProductBrief = productDetail.ProductBrief;
        auctionJson.ProductDescription = productDetail.ProductDescription;
        auctionJson.ProductName = productDetail.ProductName;
        auctionJson.MinPrice = productDetail.MinPrice;
        

        System.Web.Script.Serialization.JavaScriptSerializer jss = new System.Web.Script.Serialization.JavaScriptSerializer();
        string jsondata = jss.Serialize(auctionJson);

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