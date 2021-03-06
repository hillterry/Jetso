﻿using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DmFramework.Data.CommonEntity;
using DmFramework.Data;
using DmFramework.Web;

public partial class Common_RoleMenu : MyEntityList<RoleMenu>
{
    protected override void OnInit(EventArgs e)
    {
        base.OnInit(e);

        ods.DataObjectTypeName = ods.TypeName = CommonManageProvider.Provider.MenuType.FullName;
        odsRole.DataObjectTypeName = odsRole.TypeName = CommonManageProvider.Provider.RoleType.FullName;

        //if (!IsPostBack)
        {
            Int32 roleID = WebHelper.RequestInt("RoleID");
            if (roleID > 0)
            {
                ddlRole.DataBind();

                ddlRole.SelectedValue = roleID.ToString();
            }

            IMenu root = CommonManageProvider.Provider.MenuRoot;
            if (root != null)
            {
                ddlCategory.DataSource = root.Childs;
                ddlCategory.DataBind();
            }
        }
    }

    IEntityOperate Factory { get { return EntityFactory.CreateOperate(EntityType); } }

    protected void Page_Load(object sender, EventArgs e)
    {
    }

    public Int32 RoleID { get { return String.IsNullOrEmpty(ddlRole.SelectedValue) ? 0 : Convert.ToInt32(ddlRole.SelectedValue); } }

    /// <summary>是否使用完整权限。完整权限包括8个自定义权限</summary>
    protected Boolean IsFullPermission { get { return false; } }

    protected void ddlRole_SelectedIndexChanged(object sender, EventArgs e) { gv.DataBind(); }

    protected void gv_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row == null) return;

        IMenu entity = e.Row.DataItem as IMenu;
        if (entity == null) return;

        CheckBox cb = e.Row.FindControl("CheckBox1") as CheckBox;
        CheckBoxList cblist = e.Row.FindControl("CheckBoxList1") as CheckBoxList;

        // 检查权限
        IRoleMenu rm = FindByRoleAndMenu(RoleID, entity.ID);
        cb.Checked = (rm != null);
        if (rm != null) cb.ToolTip = rm.PermissionFlag.ToString();
        //if (rm != null) cb.Text = rm.PermissionFlag.ToString();

        // 如果有子节点，则不显示
        if (entity.Childs != null && entity.Childs.Count > 0)
        {
            //cb.Visible = false;
            cblist.Visible = false;
            return;
        }

        // 检查权限
        Dictionary<PermissionFlags, String> flags = EnumHelper.GetDescriptions<PermissionFlags>();
        cblist.Items.Clear();
        foreach (PermissionFlags item in flags.Keys)
        {
            if (item == PermissionFlags.None) continue;
            if (!IsFullPermission && item >= PermissionFlags.Custom1) continue;

            ListItem li = new ListItem(flags[item], ((Int32)item).ToString());
            if (rm != null && (rm.PermissionFlag & item) == item) li.Selected = true;
            cblist.Items.Add(li);
        }
    }

    protected void CheckBox1_CheckedChanged(object sender, EventArgs e)
    {
        if (RoleID < 1) return;

        CheckBox cb = sender as CheckBox;
        if (cb == null) return;

        GridViewRow row = cb.BindingContainer as GridViewRow;
        if (row == null) return;

        IMenu menu = CommonManageProvider.Provider.MenuRoot.AllChilds[row.DataItemIndex] as IMenu;
        if (menu == null) return;

        // 检查权限
        IRoleMenu rm = FindByRoleAndMenu(RoleID, menu.ID);
        if (cb.Checked)
        {
            // 没有权限，增加
            if (rm == null)
            {
                if (!Manager.Acquire(PermissionFlags.Insert))
                {
                    WebHelper.Alert("没有添加权限！");
                    return;
                }

                rm = Factory.Create(false) as IRoleMenu;
                rm.RoleID = RoleID;
                rm.MenuID = menu.ID;
                rm.PermissionFlag = PermissionFlags.All;
                rm.Save();

                // 如果父级没有授权，则授权
                CheckAndAddParent(RoleID, menu);
            }
        }
        else
        {
            // 如果有权限，删除
            if (rm != null)
            {
                if (!Manager.Acquire(PermissionFlags.Delete))
                {
                    WebHelper.Alert("没有删除权限！");
                    return;
                }

                (rm as IEntity).Delete();
            }
        }

        // 清空缓存，否则一会绑定的时候会绑定旧数据
        _rms = null;
        gv.DataBind();
    }

    protected void CheckBoxList1_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (RoleID < 1) return;

        CheckBoxList cb = sender as CheckBoxList;

        //只需判断cb是否为空，该角色只有“查看”权限时cb.SelectedItem为空。
        //if (cb == null || cb.SelectedItem == null) return;
        if (cb == null) return;

        GridViewRow row = cb.BindingContainer as GridViewRow;
        if (row == null) return;

        IMenu menu = CommonManageProvider.Provider.MenuRoot.AllChilds[row.DataItemIndex] as IMenu;
        if (menu == null) return;

        // 检查权限
        IRoleMenu rm = FindByRoleAndMenu(RoleID, menu.ID);
        // 没有权限，增加
        if (rm == null)
        {
            if (!Manager.Acquire(PermissionFlags.Insert))
            {
                WebHelper.Alert("没有添加权限！");
                return;
            }

            rm = Factory.Create(false) as IRoleMenu;
            rm.RoleID = RoleID;
            rm.MenuID = menu.ID;
        }

        // 遍历权限项
        PermissionFlags flag = PermissionFlags.None;
        foreach (ListItem item in cb.Items)
        {
            if (item.Selected) flag |= (PermissionFlags)(Int32.Parse(item.Value));
        }

        if (rm.PermissionFlag != flag)
        {
            if (!Manager.Acquire(PermissionFlags.Update))
            {
                WebHelper.Alert("没有编辑权限！");
                return;
            }

            rm.PermissionFlag = flag;
            rm.Save();

            // 如果父级没有授权，则授权
            CheckAndAddParent(RoleID, menu);
        }

        // 清空缓存，否则一会绑定的时候会绑定旧数据
        _rms = null;
        gv.DataBind();
    }

    void CheckAndAddParent(Int32 roleid, IMenu menu)
    {
        // 如果父级没有授权，则授权
        while ((menu = menu.Parent) != null)
        {
            IRoleMenu rm = FindByRoleAndMenu(roleid, menu.ID);
            if (rm == null)
            {
                rm = Factory.Create(false) as IRoleMenu;
                rm.RoleID = roleid;
                rm.MenuID = menu.ID;
                rm.PermissionFlag = PermissionFlags.All;
                rm.Save();
            }
        }
    }

    EntityList<IEntity> _rms;
    IRoleMenu FindByRoleAndMenu(Int32 roleID, Int32 menuID)
    {
        if (_rms == null)
        {
            Factory.Cache.Clear(null);
            _rms = Factory.Cache.Entities;
        }
        return _rms.Find(delegate(IEntity e)
        {
            IRoleMenu rm = e as IRoleMenu;
            return rm.RoleID == roleID && rm.MenuID == menuID;
        }) as IRoleMenu;
    }
}