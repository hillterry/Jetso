using Jetso.Data;
using System;

public partial class admin_Sys_MemberPointForm : System.Web.UI.Page
{
  public Int32 Point = 0;
  private Int32 id = 0;
  private member newmember = null;

  protected override void OnPreLoad(EventArgs e)
  {
    base.OnPreLoad(e);
		id = Convert.ToInt32(Request.QueryString["MemberID"]);
    newmember = member.FindByID(id);
    Point = newmember.point;
  }

  protected void Page_Load(object sender, EventArgs e)
  {
    if(!IsPostBack){
    if (newmember != null)
    {
      frmnickName.Text = newmember.nickName;
      frmemail.Text = newmember.email;
      frmpoint.Value = newmember.point + "";
    }
    }
  }

  protected void btnSave_Click(object sender, EventArgs e)
  {
    try
    {
			int newPoint = Convert.ToInt32(frmpoint.Value);
			int oldPoint = newmember.point;
			newmember.point = newPoint;
      newmember.Update();
			if (newPoint != oldPoint)
			{
				PointHistory pointhistory = new PointHistory();
				pointhistory.UseTime = DateTime.Now;
				pointhistory.MemberId = id;
				pointhistory.Point = newmember.point - Point;
				pointhistory.CurrentPointCount = newmember.point;
				pointhistory.ItemName = "后台会员管理修改积分";
				pointhistory.Save();
				
			}
			Page.ClientScript.RegisterStartupScript(this.GetType(), "alert", @"alert('成功！');
(function(){
    var load=window.onload;
    window.onload=function(){
        try{
            if(load) load();
            parent.Dialog.CloseAndRefresh(frameElement);
        }catch(e){};
    };
})();
", true);
      
    }
    catch (Exception ex)
    {
    }
  }
}