using Jetso.Data;
using PAGING.Page;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class TheFront_Account_Friends : System.Web.UI.Page
{
  public string errorMsg = " ";
  public string email;
  public string remark;

  //分页所显示的字符串
  public string str;

  protected override void OnPreLoad(EventArgs e)
  {
    base.OnPreLoad(e);
    if (!member.CheckLogin()) { Response.Redirect("memberLogin.aspx"); }
    ObjectDataSource1.SelectParameters["memberid"].DefaultValue = Convert.ToString(member.Current.ID);
    errorMsg = Request.QueryString["error"];
  }
  protected void Page_Load(object sender, EventArgs e)
  {

  } 

 
}