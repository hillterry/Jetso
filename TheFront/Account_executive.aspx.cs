using Jetso.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class TheFront_Account_executive : System.Web.UI.Page
{
  public Int32 active;
  public bool isCheck = false;
  protected override void OnPreLoad(EventArgs e)
  {
    base.OnPreLoad(e);
    if (!member.CheckLogin()) { Response.Redirect("MemberLogin.aspx"); }
    active = member.FindByID(member.Current.ID).active;
    member newmem = member.FindByID(member.Current.ID);
    DateTime oldtime = newmem.checkinTime;
    DateTime nowtime = DateTime.Now;
    TimeSpan checktime = nowtime - oldtime;
    if (checktime.Days > 0 || newmem.checkinTime == null) { isCheck = true; }
  }
  protected void Page_Load(object sender, EventArgs e)
  {
  }
 
}