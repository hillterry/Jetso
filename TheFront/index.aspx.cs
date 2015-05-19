using DmFramework.Data;
using Jetso.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class TheFront_css_index : System.Web.UI.Page
{
  public bool islogin = false;
  public Int32 ID = 0;

  protected override void OnPreLoad(EventArgs e)
  {
    base.OnPreLoad(e);
    if (member.CheckLogin()) { ID = member.Current.ID;
    }
    islogin = member.CheckLogin();
   
  }
    protected void Page_Load(object sender, EventArgs e)
    {
			if (!IsPostBack)
			{
				Response.Cookies["AccessToken"].Value = "mike";
				Response.Cookies["AccessToken"].Expires = DateTime.Now.AddDays(1);
			}
    }


		
}