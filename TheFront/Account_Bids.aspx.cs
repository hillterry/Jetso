using Jetso.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class TheFront_Account_Bids : System.Web.UI.Page
{
  public Int32 Bids = 0;
  protected override void OnPreLoad(EventArgs e)
  {
    base.OnPreLoad(e);
    if (member.CheckLogin())
    {
      member memberCurrent = member.FindByID(member.Current.ID);
      Bids = memberCurrent.point;
    }
    else
    {
      Response.Redirect("");
    }

  }
    protected void Page_Load(object sender, EventArgs e)
    {

    }
}