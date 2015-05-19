﻿using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DmFramework;
using DmFramework.Log;
using DmFramework.Web;
using Jetso.Data;

public partial class Common_memberForm : MyEntityForm<member>
{
	public member memberEditor;
	protected override void OnPreLoad(EventArgs e)
	{
		base.OnPreLoad(e);
				
	}
  protected void Page_Load(object sender, EventArgs e)
  {
    if (!IsPostBack)
    {
      var ID = Convert.ToInt32(Request.QueryString["ID"]);

			if (ID == 0)
			{
				frmbirthday.Value = DateTime.Now.ToString("yyyy-MM-dd");
			}

      memberEditor = member.FindByID(ID);
      frmeducation.DataSource = education.FindAll();
      frmeducation.DataBind();

      frmincome.DataSource = income.FindAll();
      frmincome.DataBind();
      if (memberEditor != null)
      {

        if (memberEditor.education != null)
        {
          frmeducation.SelectedValue = memberEditor.education.ToString();
        }
        
        if (memberEditor.income != null)
        {
          frmincome.SelectedValue = memberEditor.income.ToString();
        }
      }
    }
  }


//	protected void Button1_Click(object sender, EventArgs e)
//	{
//		try
//		{
//			int newPoint = Convert.ToInt32(frmpoint.Value);
//			int oldPoint = memberEditor.point;
//			memberEditor.nickName = frmnickName.Text;
//			memberEditor.email = frmemail.Text;
//			memberEditor.adress = frmadress.Text;
//			memberEditor.password = frmpassword.Text;
//			memberEditor.name = frmname.Text;
//			memberEditor.gender = frmgender.SelectedValue;
//			memberEditor.birthday = frmbirthday.Value;
//			memberEditor.boys = frmboys.Value;
//			memberEditor.girls = frmgirls.Value;
//			memberEditor.income = frmincome.SelectedValue;
//			memberEditor.phone = frmphone.Text;
//			memberEditor.education = frmeducation.SelectedValue;
//			memberEditor.point = newPoint;

//			memberEditor.Update();

//			if (newPoint != oldPoint)
//			{
//				PointHistory pointhistory = new PointHistory();
//				pointhistory.UseTime = DateTime.Now;
//				pointhistory.MemberId = Convert.ToInt32(frmID.Text);
//				pointhistory.Point = memberEditor.point - oldPoint;
//				pointhistory.CurrentPointCount = memberEditor.point;
//				pointhistory.ItemName = "后台会员管理修改积分";
//				pointhistory.Save();

//			}
//			Page.ClientScript.RegisterStartupScript(this.GetType(), "alert", @"alert('成功！');
//(function(){
//    var load=window.onload;
//    window.onload=function(){
//        try{
//            if(load) load();
//            parent.Dialog.CloseAndRefresh(frameElement);
//        }catch(e){};
//    };
//})();
//", true);

//		}
//		catch (Exception ex)
//		{
//		}
//	}
}