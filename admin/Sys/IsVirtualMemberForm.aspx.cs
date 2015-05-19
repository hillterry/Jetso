using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Jetso.Data;
using System.Collections;
using System.IO;


public partial class admin_Sys_IsVirtualMemberForm : MyEntityForm<member>
{
  protected override void OnPreLoad(EventArgs e)
  {
    base.OnPreLoad(e);
    frmIsVirtualMember.Checked = true;
  }
    protected void Page_Load(object sender, EventArgs e)
    {
      
    }

}