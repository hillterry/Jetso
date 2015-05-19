using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Jetso.Data;

public partial class Jesto_template : System.Web.UI.MasterPage
{

	public string Url, AUrL;
	public Int32 ItemPageSize = 15;
	public string isLogin = null;
	public string point, com, nickName;
  public Int32 id = 0;
	protected void Page_Load(object sender, EventArgs e)
	{
		AUrL = Request.RawUrl;
		Url = Request.Url.LocalPath.ToString();
		Url = Url.Substring(Url.LastIndexOf("/", Url.Length) + 1);
		if (member.Current != null)
		{
			isLogin = "userExist";
			point = member.FindByID(member.Current.ID).point +"";
			//	com = member.Current.commission.ToString();
			nickName = member.Current.nickName.ToString();
      id = member.Current.ID;
		}
	}

  protected void LinkButton1_Click(object sender, EventArgs e)
  {
    try
    {
      member newmember = member.Current;
      if (newmember != null)
        {
          newmember.Logout();
        }
      Response.Redirect(Url);
    }
    catch (Exception ex)
    {
      Response.Redirect("Auction.aspx");
    }
  }
}
