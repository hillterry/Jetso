using Jetso.Data;
using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class admin_Sys_SysConfig : System.Web.UI.Page
{
  protected override void OnPreLoad(EventArgs e)
  {
    base.OnPreLoad(e);

  }
    protected void Page_Load(object sender, EventArgs e)
    {
      if (!IsPostBack)
      {
        MailServer mailsever = MailServer.FindByid(1);
        fmfromMail.Text = mailsever.fromMail;
        fmport.Text = mailsever.port;
        fmserver.Text = mailsever.server;
      }
     
    }
    protected void btnSave_Click(object sender, EventArgs e)
    {
      MailServer mailserver = MailServer.FindByid(1);
      mailserver.fromMail = fmfromMail.Text;
      mailserver.server = fmserver.Text;
      mailserver.port = fmport.Text;
      mailserver.Save();
    }
}