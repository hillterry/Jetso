<%@ WebService Language="C#" Class="Validform" %>
using Jetso.Data;
using System;
using System.Web;
using System.Web.Services;
using System.Web.Services.Protocols;

[WebService(Namespace = "http://tempuri.org/")]
[WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
// 若要允许使用 ASP.NET AJAX 从脚本中调用此 Web 服务，请取消注释以下行。 
[System.Web.Script.Services.ScriptService]
public class Validform  : System.Web.Services.WebService {

    [WebMethod]
    public bool ValidForm(String validstr,bool isemail)
    {
        if (isemail)
        {
            return member.FindByEmail(validstr) != null ? true : false;
        }
        else
        {
            return member.FindByAccount(validstr) != null ? true : false;
        }

    }
    
    
}