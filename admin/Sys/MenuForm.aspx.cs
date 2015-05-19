using System;
using DmFramework.Data.CommonEntity;
using DmFramework.Web;

public partial class MenuForm : MyEntityForm<DmFramework.Data.CommonEntity.Menu>
{
    protected void Page_Load(object sender, EventArgs e)
    {
       // MasterPage.SetToolBar(false);

        EntityForm.OnSaveSuccess += new EventHandler<EntityFormEventArgs>(EntityForm_OnSaveSuccess);
    }

    void EntityForm_OnSaveSuccess(object sender, EntityFormEventArgs e)
    {
        e.Cancel = true;
        WebHelper.AlertAndRedirect("成功","Menu.aspx");

        //Response.Redirect("Menu.aspx"); 
    }
}