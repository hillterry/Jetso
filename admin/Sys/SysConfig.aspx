<%@ Page Language="C#" AutoEventWireup="true" Title="系统配置" MasterPageFile="~/MasterPage.master" CodeFile="SysConfig.aspx.cs" Inherits="admin_Sys_SysConfig" %>

<asp:Content ID="C" ContentPlaceHolderID="C" runat="server">
  <div class="row-fluid">
        <div class="widget-box">
            <div class="widget-content nopadding">
              <table border="0" class="table table-bordered table-striped" cellspacing="1" cellpadding="0"
                    align="Center">
                    <tr>
                        <th colspan="2">
                            系统配置
                        </th>
                    </tr>
                    <tr>
                        <td align="right">
                            服务器名称
                        </td>
                        <td>
                            <asp:TextBox ID="fmserver" runat="server"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td align="right">
                            端口号
                        </td>
                        <td>
                            <asp:TextBox ID="fmport" runat="server" ></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td align="right">
                           服务器电邮地址
                        </td>
                        <td>
                            <asp:TextBox ID="fmfromMail" runat="server"></asp:TextBox>
                        </td>
                    </tr>
                   
                </table>
              </div>
          </div>
  </div>
     <div class="row-fluid">
        <div class="widget-content nopadding">
            <div style="text-align: center">
                <asp:Button ID="Save" runat="server" CausesValidation="True" Text='保存' CssClass="btn btn-info"  OnClick="btnSave_Click"/>
            </div>
        </div>
    </div>
  </asp:Content>