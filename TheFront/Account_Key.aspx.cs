using Jetso.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class TheFront_Account_Key : System.Web.UI.Page
{
  public String errorMsg = String.Empty;
  public String Email = String.Empty;
  public Int32 ID = 0;
  protected override void OnPreLoad(EventArgs e)
  {
    base.OnPreLoad(e);
    if (member.CheckLogin()) { 
      Email = member.Current.email;
      ID = member.Current.ID;
			
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