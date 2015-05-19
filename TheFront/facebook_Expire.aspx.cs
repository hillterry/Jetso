using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class TheFront_facebook_Expire : System.Web.UI.Page
{
	public bool success = true;
    protected void Page_Load(object sender, EventArgs e)
    {
			if (!IsPostBack)
			{
				string para = Request.QueryString["para"];
				if (para == "su")
				{
					success = false;
					Response.Write("<script language='javascript'>alter('asdf');window.opener.location.reload();window.close();</script>");
				}
			}
    }
}