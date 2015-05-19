<%@ Page Language="C#" Title="会员积分" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="MemberPointForm.aspx.cs" Inherits="admin_Sys_MemberPointForm" %>

<asp:Content ID="Content1" runat="server" ContentPlaceHolderID="C">
    <div class="row-filuid">
        <div class="widget-box">
            <div class="widget-content nopadding">
                <table class="table table-bordered table-striped">
                    <tr>
                        <th colspan="2">member</th>
                    </tr>
                    <tr>
                        <td align="right">账号：</td>
                        <td>
                            <asp:TextBox ID="frmnickName" runat="server" Width="150px" ReadOnly="true"></asp:TextBox>
                            <label id="errormsg">账号由6-12位数字或者字符组成</label>
                        </td>
                    </tr>
                    <tr>
                        <td align="right">电邮地址：</td>
                        <td>
                            <asp:TextBox ID="frmemail" runat="server" Width="150px"  ReadOnly="true"></asp:TextBox>
                            <label id="errormsg2"></label>
                        </td>
                    </tr>
                    <tr>
                        <td align="right">积分：</td>
                        <td>
                            <input type="text" ID="frmpoint" runat="server"  Width="150px"/></td>
                    </tr>
                </table>
                <table border="0" align="Center" width="100%">
                    <tr>
                        <td align="center">
                            <asp:Button ID="btn" runat="server" CausesValidation="True" Text='保存' OnClick="btnSave_Click" />
                        </td>
                    </tr>
                </table>
            </div>
        </div>
    </div>
</asp:Content>