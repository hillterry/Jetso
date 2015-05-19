using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DmFramework.Log;
using Jetso.Data;

public partial class Billing_IPN : System.Web.UI.Page
{
  protected void Page_Load(object sender, EventArgs e)
  {
    if (VerifyIPN())
    {
      string ppTx = Request.Form["txn_id"].ToString();
      string ppreceiver_email = Request.Form["receiver_email"].ToString();
      string ppmc_gross = Request.Form["mc_gross"].ToString();
      string ppmc_currency = Request.Form["mc_currency"].ToString();
      string pppayment_status = Request.Form["payment_status"].ToString();
      string pppitem_name = Request.Form["item_name"].ToString();
      HmTrace.WriteInfo("No.:" + ppTx);
      HmTrace.WriteInfo("Email:" + ppreceiver_email);
      HmTrace.WriteInfo("gross:" + ppmc_gross);
      HmTrace.WriteInfo("currency:" + ppmc_currency);
      HmTrace.WriteInfo("status:" + pppayment_status);
      HmTrace.WriteInfo("item_name:" + pppitem_name );

      try
      {
        Order order = Order.FindByItemName(pppitem_name);
        if (order != null)
        {
          order.McCurrency = ppmc_currency;
          order.McGross = Convert.ToDecimal(ppmc_gross);
          order.OrderNo = ppTx;
          order.PaymentStatus = pppayment_status;
          order.ReceiverEmail = ppreceiver_email;
          order.Save();
          if (pppayment_status == "Completed") 
          {
            member ordermember = member.FindByID(order.MemberId);
            if (ordermember != null)
            {
              var newpoint = PointType.FindByGross(Convert.ToDecimal(ppmc_gross)).Point;
              HmTrace.WriteInfo("会员：" + order.memberName + "新增积分:" + newpoint);
              ordermember.point = ordermember.point + newpoint;
              ordermember.Save();
              PointHistory pointhistory = new PointHistory();
              pointhistory.UseTime = DateTime.Now;
              pointhistory.MemberId = ordermember.ID;
              pointhistory.Point = newpoint;
              pointhistory.ItemName = "购买积分";
              pointhistory.CurrentPointCount = ordermember.point;
              pointhistory.Save();
              HmTrace.WriteInfo("会员：" + order.memberName + "积分:" + ordermember.point);
            }
            else
            {
              HmTrace.WriteInfo(""+Convert.ToDecimal(ppmc_gross)+"");
            }
          }
        }
        else 
        {
          HmTrace.WriteInfo("找不到此itemName");
        }
      }
      catch (Exception ex)
      {
        HmTrace.WriteDebug(ex.Message);
      }
    }
  }

  bool VerifyIPN()
  {
    string strFormValues = Request.Form.ToString();
    string strNewValue;
    string strResponse;
    string serverURL = "https://www.sandbox.paypal.com/cgi-bin/webscr";
    HttpWebRequest req = (HttpWebRequest)WebRequest.Create(serverURL);
    req.Method = "POST";
    req.ContentType = "application/x-www-form-urlencoded";
    strNewValue = strFormValues + "&cmd=_notify-validate";
    HmTrace.WriteInfo("IPN验证" + strFormValues);
    req.ContentLength = strNewValue.Length;
    StreamWriter stOut = new StreamWriter(req.GetRequestStream(), System.Text.Encoding.ASCII);
    stOut.Write(strNewValue);
    stOut.Close();
    StreamReader stIn = new StreamReader(req.GetResponse().GetResponseStream());
    strResponse = stIn.ReadToEnd();
    stIn.Close();
    return strResponse == "VERIFIED";
  }
}