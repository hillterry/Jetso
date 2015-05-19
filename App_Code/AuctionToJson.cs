using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// AuctionToJson 的摘要说明
/// </summary>
public class AuctionToJson
{
	public AuctionToJson()
	{
	}


	public string ProductImage1 { get; set; }
	public string ProductImage2 { get; set; }
	public string ProductImage3 { get; set; }
	public string ProductBrief { get; set; }
	public Decimal MinPrice { get; set; }
	public Decimal MarkPrice { get; set; }
	public Decimal BiddingPriceNow { get; set; }
	public string ProductName { get; set; }
	public string ProductDescription { get; set; }
	public int countTime { get; set; }

}