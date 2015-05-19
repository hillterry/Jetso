using Jetso.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class TheFront_Account_infor : System.Web.UI.Page
{
  public Int32 active = 0;
  public Int32 ID = 0;
  protected override void OnPreLoad(EventArgs e)
  {
    base.OnPreLoad(e);
    active = member.Current.active;
    if (!member.CheckLogin()) { Response.Redirect("memberLogin.aspx"); }
    ID = member.Current.ID;
    member memberinfor = member.FindByID(ID);
    frmemail.Text = memberinfor.email;
    frmboy.Text = memberinfor.boys + "";
    frmgirl.Text = memberinfor.girls + "";
    frmname.Text = memberinfor.name;
    frmnickName.Text = memberinfor.nickName;

    frmeducation.DataSource = education.FindAll();
    frmeducation.DataBind();
    frmeducation.SelectedValue = memberinfor.education;

    frmincome.DataSource = income.FindAll();
    frmincome.DataBind();
    frmincome.SelectedValue = memberinfor.income;

    frmgender.DataSource = gender.FindAll();
    frmgender.DataBind();
    frmgender.SelectedValue = memberinfor.gender;
  }
    protected void Page_Load(object sender, EventArgs e)
    {
     
    }   
}