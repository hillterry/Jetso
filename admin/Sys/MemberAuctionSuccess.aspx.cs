using Jetso.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class admin_Sys_MemberAuctionSuccess : MyEntityList<Auction>
{
    protected void Page_Load(object sender, EventArgs e)
    {
      ods.SelectParameters["id"].DefaultValue = Request.QueryString["ID"];
    }
}