using System;
using System.Collections.Generic;
using System.Threading;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DmFramework.Data.CommonEntity.Exceptions;
using DmFramework.Log;
using Jetso.Data;

public partial class checkMemberLogin : System.Web.UI.Page
{
    public string errorMsg;

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            try
            {
                string account = Request.Form["Account"];
                string password = Request.Form["Password"];
                member loginMember = member.Login(account, password);
                if (loginMember != null)
                {
                    //if (loginMember.active == 2)
                    //{
                    //    errorMsg = "not_active";
                    //}
                    //else
                    if (loginMember.active == 3)
                    {
                        errorMsg = "not_used";
                    }
                    else
                    {
                        loginMember.lastLoginDate = System.DateTime.Now;
                        if (loginMember.Update() != 1)
                        {
                            errorMsg = "error";
                        }
                        else
                        {
                            errorMsg = "success";
                        }
                    }
                    
                }
            }
            catch (ThreadAbortException) { }
            catch (Exception ex)
            {

                errorMsg = "account_error";
            }
            
        }
        Response.Write(errorMsg);
    }
}