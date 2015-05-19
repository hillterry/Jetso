using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Jetso.Data;
using System.IO;
using System.Collections;
using DmFramework.Log;
using DmFramework.Data;
using DmFramework.Web;


public partial class admin_Sys_IsVirtualMember : MyEntityList<member>
{
  private Int32 count;
  protected void Page_Load(object sender, EventArgs e)
  {

  }

  //读取properties文件
  public EntityList<member> load(string filePath)
  {
    EntityList<member> hst = new EntityList<member>();
    string line = null;
    
    count = 0;
    using (StreamReader sr = new StreamReader(Server.MapPath("../../") + filePath))
    {
      while (sr.Peek() > -1)
      {
        
        var memberviturl = new member();
        line = sr.ReadLine();
        //判断虚拟会员是否存在
        if (member.FindByAccount(line) == null)
        {
          memberviturl.nickName = line;
          memberviturl.isVirtualMember = true;
          hst.Add(memberviturl);
          count++;
        }
      }
    }
    return hst;
  }

  public string upload()
  {
    Random rnd = new Random();
    string tiem = DateTime.Now.ToString("yyyyMMdd");
    var filepath ="";

    if (txt.HasFile)
    {
      string imageName = txt.FileName;
      string extension_txt = Path.GetExtension(imageName);
      bool extension_type = extension_txt.Equals(".txt");
      if (extension_type)
      {
        int num = rnd.Next(5000, 10000);
        string path_txt = "file/TxT/" + tiem;
        DmFramework.IO.FileHelper.EnsureDirectory(System.Web.HttpContext.Current.Server.MapPath("../../" + path_txt));
        try
        {
          txt.SaveAs(System.Web.HttpContext.Current.Server.MapPath("../../" + path_txt + "/" + num.ToString() + extension_txt));
          HmTrace.WriteDebug("上传成功");
        }
        catch (Exception ex)
        {
          HmTrace.WriteDebug(ex.Message);
        }
        filepath = path_txt + "/" + num.ToString() + extension_txt;
      }
    }
    return filepath;
  }

  private void save()
  {
    try
    {
      if (!txt.HasFile) { return; }
      var hst = load(upload());
      EntityList<member> membervirtuals = hst;
      if (membervirtuals != null)
      {
        membervirtuals.Save();
      }
    }
    catch (Exception ex)
    {
      HmTrace.WriteDebug(ex.Message);
    }
  }
  protected void Button3_Click(object sender, EventArgs e)
  {
    save();
    WebHelper.AlertAndRefresh("扫描完成，共添加虚拟会员" + count + "个！");
    //Response.Redirect("../../Admin/Sys/IsVirtualMember.aspx");
  }
}