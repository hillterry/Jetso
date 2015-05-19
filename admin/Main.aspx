<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Main.aspx.cs" Inherits="Admin_Main"
    MasterPageFile="~/MasterPage.master" %>

<%@ Import Namespace="System.Diagnostics" %>
<%@ Import Namespace="System.Collections.Generic" %>
<%@ Import Namespace="System.Reflection" %>
<%@ Import Namespace="DmFramework" %>
<%@ Import Namespace="DmFramework.Reflection" %>

<asp:Content ID="Content1" ContentPlaceHolderID="H" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="C" runat="server">
    <%if (Request.QueryString == null || Request.QueryString.Count <= 0)
      {  %>
    <div class="row-filuid">
        <div class="widget-box">
            <div class="widget-title">
                <span class="icon"><i class="icon-th"></i></span>
                <h5>
                    伺服器資訊</h5>
            </div>
            <div class="widget-content nopadding">
                <table class="table table-bordered table-striped">
                    <tbody>
                        <tr>
                            <td>
                                應用系統：
                            </td>
                            <td>
                                <%= HttpRuntime.AppDomainAppVirtualPath%>&nbsp;<a href="?Act=Restart" onclick="return confirm('僅重啟ASP.Net應用程式定義域，而不是作業系統！\n確認重啟？')">重啟應用系統</a>
                            </td>
                            <td>
                                目錄：
                            </td>
                            <td>
                                <%= HttpRuntime.AppDomainAppPath%>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                功能變數名稱地址：
                            </td>
                            <td>
                                <%= Request.ServerVariables["SERVER_NAME"]%>，
                                <%= Request.ServerVariables["LOCAl_ADDR"] + ":" + Request.ServerVariables["Server_Port"]%>
                                &nbsp;<=[<%= Request.ServerVariables["REMOTE_HOST"]%>]
                            </td>
                            <td>
                                電腦使用者：
                            </td>
                            <td>
                                <%= Environment.UserName%>/<%= Environment.MachineName%>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                應用程式定義域：
                            </td>
                            <td>
                                <%= AppDomain.CurrentDomain.FriendlyName %>
                                <a href="?Act=Assembly" target="_blank" title="點擊打開進程程式集清單">程式集清單</a>
                            </td>
                            <td>
                                .Net 版本：
                            </td>
                            <td>
                                <%= Environment.Version%>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                作業系統：
                            </td>
                            <td>
                                <%= Runtime.OSName %>
                            </td>
                            <td>
                                Web伺服器：
                            </td>
                            <td>
                                <%= GetWebServerName()%>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                處理器：
                            </td>
                            <td>
                                <%= Environment.ProcessorCount%>
                                核心，
                                <%= Environment.GetEnvironmentVariable("PROCESSOR_IDENTIFIER")%>
                            </td>
                            <td>
                                時間：
                            </td>
                            <td title="這裡使用了伺服器默認的時間格式！後面是開機時間。">
                                <%= DateTime.Now%>，<%= new TimeSpan(Environment.TickCount)%>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                記憶體：
                            </td>
                            <td>
                                <% Process process = Process.GetCurrentProcess(); %>
                                工作集:<%= (process.WorkingSet64 / 1024).ToString("n0") + "KB"%>
                                提交:<%= (process.PrivateMemorySize64 / 1024).ToString("n0") + "KB"%>
                                GC:<%= (GC.GetTotalMemory(false) / 1024).ToString("n0") + "KB"%>
                                <a href="?Act=ProcessModules" target="_blank" title="點擊打開進程模組清單">模組清單</a>
                            </td>
                            <td>
                                進程時間：
                            </td>
                            <td>
                                <%= process.TotalProcessorTime.TotalSeconds.ToString("N2")%>秒 啟動於<%= process.StartTime.ToString("yyyy-MM-dd HH:mm:ss")%>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                Session：
                            </td>
                            <td>
                                <%= Session.Contents.Count%>個，<%= Session.Timeout%>分鐘，SessionID：<%= Session.Contents.SessionID%>
                            </td>
                            <td>
                                Cache：
                            </td>
                            <td>
                                <%= Cache.Count%>個，可用：<%= (Cache.EffectivePrivateBytesLimit / 1024).ToString("n0")%>KB
                            </td>
                        </tr>
                    </tbody>
                </table>
            </div>
        </div>
        <div class="widget-box">
            <div class="widget-content nopadding">
                <asp:GridView ID="gv" runat="server" AllowSorting="True" AutoGenerateColumns="False"
                    CssClass="table table-bordered table-striped" BorderWidth="0px" CellPadding="0"
                    BorderStyle="None" GridLines="None">
                    <Columns>
                        <asp:BoundField DataField="Name" HeaderText="名稱">
                            <HeaderStyle CssClass="widget-title" Font-Size="Small" />
                        </asp:BoundField>
                        <asp:BoundField DataField="Title" HeaderText="標題" HeaderStyle-CssClass="widget-title"
                            HeaderStyle-Font-Size="Small" />
                        <asp:BoundField DataField="FileVersion" HeaderText="檔版本" HeaderStyle-CssClass="widget-title"
                            HeaderStyle-Font-Size="Small" />
                        <asp:BoundField DataField="Version" HeaderText="內部版本" HeaderStyle-CssClass="widget-title"
                            HeaderStyle-Font-Size="Small" />
                        <asp:BoundField DataField="Compile" DataFormatString="{0:yyyy-MM-dd HH:mm:ss}" HeaderText="編譯時間"
                            HeaderStyle-CssClass="widget-title" HeaderStyle-Font-Size="Small" />
                        <asp:TemplateField></asp:TemplateField>
                    </Columns>
                </asp:GridView>
            </div>
        </div>
    </div>

    <%}%>
</asp:Content>
