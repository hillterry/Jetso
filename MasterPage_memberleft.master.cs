using Jetso.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class MasterPage_memberleft : System.Web.UI.MasterPage
{
  public Int32 id = 0;
  public Int32 point = 0;
  public Int32 AddressID = 0;
  public String name = "";
  public string Url = " ";
    protected void Page_Load(object sender, EventArgs e)
    {
      Url = Request.Url.LocalPath.ToString();
      Url = Url.Substring(Url.LastIndexOf("/", Url.Length) + 1);
      id = member.Current.ID;
      name = member.Current.nickName;
      point = member.FindByID(member.Current.ID).point;
      String[] Names = { "MemberID", "IsDefaoult" };
      object[] Values = { member.Current.ID, true };
    }
}
