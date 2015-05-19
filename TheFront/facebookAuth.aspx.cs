using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Billing_facebookAuth : System.Web.UI.Page
{
  protected void Page_Load(object sender, EventArgs e)
  {
    if (!IsPostBack)
    {
      if (Session["AccessToken"] != null)
      {
        Response.Write("<script language='javascript'>alter('asdf');window.opener.location.reload();window.close();</script>");
      }
    }

  }
}