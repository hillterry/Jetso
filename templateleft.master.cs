using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Jetso.Data;

public partial class Jesto_templateleft : System.Web.UI.MasterPage
{
    public string Url , isLogin = " ";

    protected void Page_Load(object sender, EventArgs e)
    {
        Url = Request.Url.LocalPath.ToString();
        Url = Url.Substring(Url.LastIndexOf("/", Url.Length) + 1);
        if (member.Current != null)
        {
            isLogin = "userExist";
        }
    }
}
