using DmFramework.Data;
using Jetso.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class TheFront_precinct : System.Web.UI.Page
{
  public bool isnull = false;
  public bool onlyone = false;
  public DateTime now = DateTime.Now;
  public Int32 ItemPageSize = 15;
  public bool NeedPoint = false;
  public bool islogin = false;
  public bool isWiner = false;
  public Int32 ID = 0;
  public Int32 Index = 0;
  protected override void OnPreLoad(EventArgs e)
  {
    base.OnPreLoad(e);
    EntityList<Auction> auctionlist = Auction.FindAll();
    if (member.CheckLogin()) { ID = member.Current.ID; }
    if (auctionlist.Count == 1) { onlyone = true; }
    Int32 id = Convert.ToInt32(Request.QueryString["ID"]);
    Int32 Index = Convert.ToInt32(Request.QueryString["Index"]);
    Auction auction = Auction.FindByID(id);
    if (auction == null || auction.EndTime.CompareTo(DateTime.Now) <= 0 || Convert.ToDateTime(auction.StarTime).CompareTo(DateTime.Now) >= 0) { isnull = true; }
    if (member.CheckLogin())
    {
      islogin = true;
      if (auction.member != null)
      {
         isWiner = member.Current.nickName.Trim().Equals(auction.member.nickName); 
      }
      //判断会员的积分是否够参与竞投
      NeedPoint = auction.EveryNeedPoint <= member.Current.point;
    }
  }

    protected void Page_Load(object sender, EventArgs e)
    {

    }
}