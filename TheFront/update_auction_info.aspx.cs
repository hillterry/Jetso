using DmFramework.Log;
using Jetso.Data;
using System;

public partial class Billing_update_auction_info : System.Web.UI.Page
{
  public string msgStr = "";

  protected void Page_Load(object sender, EventArgs e)
  {
    Int32 ID = Convert.ToInt32(Request.QueryString["ID"]);
    Int32 addTime = Convert.ToInt32(Request.QueryString["timeAdd"]);
    //更新竞投时间
    try
    {
      Auction auction = Auction.FindByID(ID);
      if (auction.AuctionSatus != 3 && auction.EndTime <= DateTime.Now && auction.MinPrice <= auction.BiddingPriceNow)
      {
        auction.AuctionSatus = 3;
      }
      auction.EndTime = auction.EndTime.AddSeconds(addTime);
      auction.BiddingPriceNow += auction.EveryAddPrice;
      auction.WinningBidder = member.Current.ID;
      auction.UpdateTime = DateTime.Now;
      auction.BidCount += 1;
      auction.Update();
      //花费积分 竞投
      member.Current.point = member.Current.point - auction.EveryNeedPoint;
      member.Current.Update();
      AuctionHistory history = new AuctionHistory();
      history.MemberID = member.Current.ID;
      history.AuctionID = auction.ID;
      history.BidDate = DateTime.Now;
      history.BidEyuan = auction.BiddingPriceNow;
      history.Insert();
      PointHistory pointhistory = new PointHistory();
      pointhistory.UseTime = DateTime.Now;
      pointhistory.MemberId = member.Current.ID;
      pointhistory.Point = -1 * auction.EveryNeedPoint;
      pointhistory.ItemName = "参与竞投";
      pointhistory.CurrentPointCount = member.Current.point;
      pointhistory.Save();
      msgStr = "success";
    }
    catch (Exception ex)
    {
      msgStr = "fail";
      HmTrace.WriteException(ex.Message);
      //Response.Write(ex.Message);
    }
    Response.Write(msgStr);
  }
}