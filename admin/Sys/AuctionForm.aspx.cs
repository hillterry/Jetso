﻿using System;
using System.Collections.Generic;
using System;
using System.Collections.Generic;
using System.IO;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DmFramework.Log;
using DmFramework.Web;
using Jetso.Data;
using DmFramework.Data.CommonEntity;
using System.Web.Services;

public partial class Common_AuctionForm : MyEntityForm<Auction>
{
  protected override void OnPreLoad(EventArgs e)
  {
    base.OnPreLoad(e);
    //frmStarTime.Value = DateTime.Now.ToString("yyyy-MM-dd HH:mm");
    //frmBiddingLimitTime.Value = DateTime.Now.ToString("yyyy-MM-dd HH:mm");
    frmAuctionSatus.Text = "1";
  }
    protected void Page_Load(object sender, EventArgs e)
    {
      EntityForm.OnSaving += new EventHandler<EntityFormEventArgs>(EntityForm_OnSaveSaving);
    }
    void EntityForm_OnSaveSaving(object sender, EntityFormEventArgs e)
    {

      EntityForm.Entity.SetItem("EndTime", frmBiddingLimitTime.Value);

      //Response.Redirect("Menu.aspx"); 
    }
    protected void Button1_Click(object sender, EventArgs e)
		{

			Random rnd = new Random();
			string tiem = DateTime.Now.ToString("yyyyMMdd");

			if (Img.HasFile)
			{
				string imageName = Img.FileName;
				string extension_image = Path.GetExtension(imageName);
				bool extension_type = extension_image.Equals(".jpeg") || extension_image.Equals(".png") || extension_image.Equals(".jpg") || extension_image.Equals(".gif") || extension_image.Equals(".bmt");
				if (extension_type)
				{
					int num = rnd.Next(5000, 10000);
					string path_image = "file/image/" + tiem;
					DmFramework.IO.FileHelper.EnsureDirectory(System.Web.HttpContext.Current.Server.MapPath("../../" + path_image));
					try
					{
						Img.SaveAs(System.Web.HttpContext.Current.Server.MapPath("../../" + path_image + "/" + num.ToString() + extension_image));
						Label1.Text = "上传成功";
					}
					catch (Exception ex)
					{
						Label1.Text = ex.Message;
					}
					frmProductImage1.Text = path_image + "/" + num.ToString() + extension_image;
				}
				else
				{
					Label1.Text = "图片格式为jpeg,png,jpg,gif,bmt";
				}
			}
			else
			{
				Label1.Text = "文件为空,请浏览要上传文件!";
			}
		}
		protected void Button2_Click(object sender, System.EventArgs e)
		{
			Random rnd = new Random();
			string tiem = DateTime.Now.ToString("yyyyMMdd");

			if (Img2.HasFile)
			{
				string imageName = Img2.FileName;
				string extension_image = Path.GetExtension(imageName);
				bool extension_type = extension_image.Equals(".jpeg") || extension_image.Equals(".png") || extension_image.Equals(".jpg") || extension_image.Equals(".gif") || extension_image.Equals(".bmt");
				if (extension_type)
				{
					int num = rnd.Next(5000, 10000);
					string path_image = "file/image/" + tiem;
					DmFramework.IO.FileHelper.EnsureDirectory(System.Web.HttpContext.Current.Server.MapPath("../../" + path_image));
					try
					{
						Img2.SaveAs(System.Web.HttpContext.Current.Server.MapPath("../../" + path_image + "/" + num.ToString() + extension_image));
						Label2.Text = "上传成功";
					}
					catch (Exception ex)
					{
						Label2.Text = ex.Message;
					}
					frmProductImage2.Text = path_image + "/" + num.ToString() + extension_image;
				}
				else
				{
					Label2.Text = "图片格式为jpeg,png,jpg,gif,bmt";
				}
			}
			else
			{
				Label2.Text = "文件为空,请浏览要上传文件!";
			}
		}
		protected void Button3_Click(object sender, System.EventArgs e)
		{
			Random rnd = new Random();
			string tiem = DateTime.Now.ToString("yyyyMMdd");

			if (Img3.HasFile)
			{
				string imageName = Img3.FileName;
				string extension_image = Path.GetExtension(imageName);
				bool extension_type = extension_image.Equals(".jpeg") || extension_image.Equals(".png") || extension_image.Equals(".jpg") || extension_image.Equals(".gif") || extension_image.Equals(".bmt");
				if (extension_type)
				{
					int num = rnd.Next(5000, 10000);
					string path_image = "file/image/" + tiem;
					DmFramework.IO.FileHelper.EnsureDirectory(System.Web.HttpContext.Current.Server.MapPath("../../" + path_image));
					try
					{
						Img3.SaveAs(System.Web.HttpContext.Current.Server.MapPath("../../" + path_image + "/" + num.ToString() + extension_image));
						Label3.Text = "上传成功";
					}
					catch (Exception ex)
					{
						Label3.Text = ex.Message;
					}
					frmProductImage3.Text = path_image + "/" + num.ToString() + extension_image;
				}
				else
				{
					Label3.Text = "图片格式为jpeg,png,jpg,gif,bmt";
				}
			}
			else
			{
				Label3.Text = "文件为空,请浏览要上传文件!";
			}
		}
		protected void Button4_Click(object sender, System.EventArgs e)
		{
			Random rnd = new Random();
			string tiem = DateTime.Now.ToString("yyyyMMdd");

			if (Img4.HasFile)
			{
				string imageName = Img4.FileName;
				string extension_image = Path.GetExtension(imageName);
				bool extension_type = extension_image.Equals(".jpeg") || extension_image.Equals(".png") || extension_image.Equals(".jpg") || extension_image.Equals(".gif") || extension_image.Equals(".bmt");
				if (extension_type)
				{
					int num = rnd.Next(5000, 10000);
					string path_image = "file/image/" + tiem;
					DmFramework.IO.FileHelper.EnsureDirectory(System.Web.HttpContext.Current.Server.MapPath("../../" + path_image));
					try
					{
						Img4.SaveAs(System.Web.HttpContext.Current.Server.MapPath("../../" + path_image + "/" + num.ToString() + extension_image));
						Label4.Text = "上传成功";
					}
					catch (Exception ex)
					{
						Label4.Text = ex.Message;
					}
					frmProductImage3.Text = path_image + "/" + num.ToString() + extension_image;
				}
				else
				{
					Label4.Text = "图片格式为jpeg,png,jpg,gif,bmt";
				}
			}
			else
			{
				Label4.Text = "文件为空,请浏览要上传文件!";
			}
		}

}