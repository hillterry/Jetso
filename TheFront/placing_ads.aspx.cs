using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Jetso.Data;

public partial class Billing_placing_ads : System.Web.UI.Page
{
	public String Description="";
	public String imagepath = "";
	public Int32 id = 0;
	protected override void OnPreLoad(EventArgs e)
	{
		base.OnPreLoad(e);
		id = Convert.ToInt32(Request.QueryString["ID"]);
		Auction auction = Auction.FindByID(id);
		Description	=	auction.Adv_content;
		imagepath = auction.Adv_image;
	}
	protected void Page_Load(object sender, EventArgs e)
	{

	}
}