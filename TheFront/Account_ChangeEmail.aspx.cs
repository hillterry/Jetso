using Jetso.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class TheFront_Account_ChangeEmail : System.Web.UI.Page
{
  public string Email = "";
  public Int32 ID = 0;
  protected override void OnPreLoad(EventArgs e)
  {
    base.OnPreLoad(e);
    if (member.CheckLogin()) {
      ID = member.Current.ID;
      Email = member.FindByID(ID).email; 
    }
    else
    {
      Response.Redirect("index.aspx");
    }
  }
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    
}