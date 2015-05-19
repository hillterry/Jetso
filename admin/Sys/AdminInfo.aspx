﻿<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true"
    CodeFile="AdminInfo.aspx.cs" Inherits="Pages_AdminInfo" Title="当前用户信息" %>

<asp:Content ID="C" ContentPlaceHolderID="C" runat="server">
    <div class="row-fluid">
        <div class="widget-box">
            <div class="widget-content nopadding">
                <table border="0" class="table table-bordered table-striped" cellspacing="1" cellpadding="0"
                    align="Center">
                    <tr>
                        <th colspan="2">
                            用戶信息
                        </th>
                    </tr>
                    <tr>
                        <td align="right">
                            名稱：
                        </td>
                        <td>
                            <asp:TextBox ID="frmName" runat="server" ReadOnly="true"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td align="right">
                            密碼：
                        </td>
                        <td>
                            <asp:TextBox ID="frmPassword" runat="server" TextMode="Password"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td align="right">
                            顯示名：
                        </td>
                        <td>
                            <asp:TextBox ID="frmDisplayName" runat="server"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td align="right">
                            角色：
                        </td>
                        <td>
                            <asp:Label ID="frmRoleName" runat="server"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td align="right">
                            登錄次數：
                        </td>
                        <td>
                            <asp:Label ID="frmLogins" runat="server"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td align="right">
                            最後登錄：
                        </td>
                        <td>
                            <asp:Label ID="frmLastLogin" runat="server"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td align="right">
                            最後登陸IP：
                        </td>
                        <td>
                            <asp:Label ID="frmLastLoginIP" runat="server"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td align="right">
                            QQ：
                        </td>
                        <td>
                            <asp:TextBox ID="frmQQ" runat="server"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td align="right">
                            MSN：
                        </td>
                        <td>
                            <asp:TextBox ID="frmMSN" runat="server"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td align="right">
                            郵箱：
                        </td>
                        <td>
                            <XCL:MailBox ID="frmEmail" runat="server"></XCL:MailBox>
                        </td>
                    </tr>
                    <tr>
                        <td align="right">
                            電話：
                        </td>
                        <td>
                            <asp:TextBox ID="frmPhone" runat="server"></asp:TextBox>
                        </td>
                    </tr>
                </table>
            </div>
        </div>
    </div>
    <div class="row-fluid">
        <div class="widget-content nopadding">
            <div style="text-align: center">
                <asp:Button ID="btnSave" runat="server" CausesValidation="True" Text='保存' CssClass="btn btn-info" />
            </div>
        </div>
    </div>
</asp:Content>
