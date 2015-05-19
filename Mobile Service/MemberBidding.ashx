<%@ WebHandler Language="C#" Class="MemberBidding" %>

using System;
using System.Web;
using Jetso.Data;
public class MemberBidding : IHttpHandler {
    //用户竞投
    public void ProcessRequest (HttpContext context) {
       
        //取得请求的参数
        string url = context.Request.Url.ToString();
        int memberId = Convert.ToInt32(context.Request.QueryString["memberId[]"]);
        int productId = Convert.ToInt32(context.Request.QueryString["productId"]);
        string callback = context.Request.QueryString["callback"];


        System.Web.Script.Serialization.JavaScriptSerializer jss = new System.Web.Script.Serialization.JavaScriptSerializer();
        //需要返回的数据
        string jsondata;
        string returnjson;
        
        //取得当前竞投的产品
        Auction getNowAuction = Auction.FindByID(productId);
        if (getNowAuction.AuctionSatus != 3 && getNowAuction.EndTime <= DateTime.Now && getNowAuction.MinPrice <= getNowAuction.BiddingPriceNow)
        {
            getNowAuction.AuctionSatus = 3;
        }
        
        
        //找到当前会员
        member getNowMember = member.FindByID(memberId);
        
        //如果竞投结束直接返回数据让前台判断
        if (getNowAuction.AuctionSatus == 3)
        {
            jsondata = jss.Serialize("EndAuction");
        }
        else if (getNowMember == null)
        {
            //还没有登录
            jsondata = jss.Serialize("NotLogin");
            
        }
        else
        {
            int addPoint = getNowAuction.EveryNeedPoint;
            decimal addPrice = getNowAuction.EveryAddPrice;
            decimal nowPrice = getNowAuction.BiddingPriceNow + addPrice;

            DateTime editTime = DateTime.Now;
            
            //获取随机增加的时间
            string timeRandom = getNowAuction.TimeAddRange;
            string[] timeAdd = timeRandom.Split("-");
            int time1 = Convert.ToInt32(timeAdd[0]);
            int time2 = Convert.ToInt32(timeAdd[1]);
            Random time = new Random();
            int getAddTime = Convert.ToInt32(time.Next(time1, time2));
            
            
            if (getNowMember.point < addPoint)
            {
                //积分不够
                jsondata = jss.Serialize("PointLimit");
                
            }
            else
            {

                getNowAuction.BiddingPriceNow = nowPrice;
                getNowAuction.UpdateTime = editTime;
                getNowAuction.WinningBidder = memberId;
                getNowAuction.EndTime = getNowAuction.EndTime.AddSeconds(getAddTime);
                getNowAuction.Update();
                int nowPoint = getNowMember.point - addPoint;
                getNowMember.point = nowPoint;
                getNowMember.Update();

                AuctionHistory newHistory = new AuctionHistory();
                newHistory.AuctionID = productId;
                newHistory.MemberID = memberId;
                newHistory.BidEyuan = nowPrice;
                newHistory.BidDate = editTime;
                newHistory.Save();

                PointHistory newPointHistory = new PointHistory();
                newPointHistory.MemberId = memberId;
                newPointHistory.Point = 0 - addPoint;
                newPointHistory.ItemName = "参与竞投";
                newPointHistory.CurrentPointCount = nowPoint;
                newPointHistory.Save();
                
                
                jsondata = jss.Serialize("Success");
               
            }
        }

        returnjson = callback + "([" + jsondata + "])";
        context.Response.ContentType = "text/javascript";
        context.Response.Write(returnjson);
    }
 
    public bool IsReusable {
        get {
            return false;
        }
    }

}