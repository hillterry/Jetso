using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class TheFront_signup : System.Web.UI.Page
{

	public string nickName;
    protected void Page_Load(object sender, EventArgs e)
    {
			if (!IsPostBack)
			{
				Response.Cookies["AccessToken"].Value = "mike";
				Response.Cookies["AccessToken"].Expires = DateTime.Now.AddDays(1);

				nickName = Request.QueryString["name"];
			}
    }
}