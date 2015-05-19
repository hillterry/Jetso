<%@ WebHandler Language="C#" Class="GetIndexProduct" %>

using System;
using System.Web;

public class GetIndexProduct : IHttpHandler {
    //查找在首页显示的商品
    public void ProcessRequest (HttpContext context) {
        context.Response.ContentType = "text/plain";
        context.Response.Write("Hello World");
    }
 
    public bool IsReusable {
        get {
            return false;
        }
    }

}