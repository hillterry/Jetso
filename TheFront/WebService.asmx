<%@ WebService Language="C#" Class="WebService" %>
using Jetso.Data;
using DmFramework.Data;
using System;
using System.Web;
using System.Web.Services;
using System.Web.Services.Protocols;

[WebService(Namespace = "http://tempuri.org/")]
[WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
// 若要允许使用 ASP.NET AJAX 从脚本中调用此 Web 服务，请取消注释以下行。 
[System.Web.Script.Services.ScriptService]
public class WebService : System.Web.Services.WebService
{

    [WebMethod]
    public EntityList<Auction> Auctions()
    {
        EntityList<Auction> auctions = Auction.FindAll();

        //因为JS对时间格式的2B所以只能在这里转换成字符串格式。
        auctions = auctions.FindAll(n => n.AuctionSatus > 1);
        foreach (Auction aut in auctions)
        {
            if (aut.AuctionSatus != 3 && aut.EndTime <= DateTime.Now && aut.MinPrice <= aut.BiddingPriceNow)
            {
                aut.AuctionSatus = 3;
            }
            aut.ProductNo = Convert.ToString(DateTime.Now);
            String str = Convert.ToString(aut.EndTime);
            aut.ProductBrief = aut.ProductName;
            aut.ProductName = str;
            if (aut.member != null)
            {
                aut.ProductDescription = aut.member.nickName;
            }
            else
            {
                aut.ProductDescription = "  ";
            }
        }
        return auctions;
    }
    [WebMethod]
    public Auction Auctioner(Int32 id)
    {
        Auction auctionner = Auction.FindByID(id);
        //因为JS对时间格式的2B所以只能在这里转换成字符串格式。

        auctionner.ProductNo = Convert.ToString(DateTime.Now);
        String str = Convert.ToString(auctionner.EndTime);
        auctionner.ProductName = str;
        if (auctionner.member != null)
        {
            auctionner.ProductDescription = auctionner.member.nickName;
        }

        return auctionner;
    }
    [WebMethod]
    public EntityList<AuctionHistory> AuctionsHistory(Int32 id)
    {
        EntityList<AuctionHistory> auctionnhistorys = AuctionHistory.FindAllByAuctionID(id);
        //因为JS对时间格式的2B所以只能在这里转换成字符串格式。
        auctionnhistorys = auctionnhistorys.Sort("ID", true);
        return auctionnhistorys;
    }

}