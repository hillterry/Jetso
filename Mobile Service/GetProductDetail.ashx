<%@ WebHandler Language="C#" Class="GetProductDetail" %>

using System;
using System.Web;
using Jetso.Data;
public class GetProductDetail : IHttpHandler {
    
    //查找当前用户点击的商品的详细信息
    public void ProcessRequest (HttpContext context) {

        string requserUrl = context.Request.Url.ToString();
        string productId = context.Request.QueryString["productId"];
        string callback = context.Request.QueryString["callback"];
        string url = GetIPAdress.ip;
        int id = Convert.ToInt32(productId);

        Auction productDetail = Auction.FindByID(id);
        productDetail.ProductImage1 = url + productDetail.ProductImage1;
        productDetail.ProductImage2 = url + productDetail.ProductImage2;
        productDetail.ProductImage3 = url + productDetail.ProductImage3;
        
        System.Web.Script.Serialization.JavaScriptSerializer jss = new System.Web.Script.Serialization.JavaScriptSerializer();
        string jsondata = jss.Serialize(productDetail);

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