<%@ Page Title="竞投管理" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="AuctionForm.aspx.cs" Inherits="Common_AuctionForm" %>

<asp:Content ID="Content2" runat="server" ContentPlaceHolderID="H">
    <link rel="stylesheet" href="<%= ResolveUrl("~/UI/css/uniform.css")%>" type="text/css" />
    <script src="<%= ResolveUrl("~/UI/js/jquery.uniform.js")%>" type="text/javascript"></script>
    <script src="<%= ResolveUrl("~/UI/js/unicorn.form_common.js")%>" type="text/javascript"></script>
</asp:Content>
<asp:Content ID="Content1" runat="server" ContentPlaceHolderID="C">
    <div class="row-filuid">
        <div class="widget-box">
            <div class="widget-content nopadding">
                <table class="table table-bordered table-striped">
                    <tr>
                        <th colspan="2">竞投</th>
                    </tr>
                    <tr>
                        <td align="right">竞投产品编号：</td>
                        <td>
                            <asp:TextBox ID="frmProductNo" runat="server" Width="150px"></asp:TextBox></td>
                    </tr>
                    <tr>
                        <td align="right">竞投商品名称：</td>
                        <td>
                            <asp:TextBox ID="frmProductName" runat="server" Width="150px"></asp:TextBox></td>
                    </tr>
                    <tr>
                        <td align="right">商品简介：</td>
                        <td>
                            <asp:TextBox ID="frmProductBrief" runat="server" TextMode="MultiLine" Width="300px" Height="80px"></asp:TextBox></td>
                    </tr>
                    <tr>
                        <td align="right">竞投详细介绍(Html内容)：</td>
                        <td>
                            <asp:TextBox ID="frmProductDescription" runat="server" TextMode="MultiLine" Width="300px" Height="80px"></asp:TextBox></td>
                    </tr>
                    <tr>
                        <td align="right">市场价格(原价)：</td>
                        <td>
                            <XCL:DecimalBox ID="frmMarkPrice" runat="server" Width="80px" CurrencySymbol="HK$"></XCL:DecimalBox></td>
                    </tr>
                    <tr>
                        <td align="right">竞投开始时间：</td>
                        <td>
                            <input type="text" id="frmStarTime" name="frmStarTime" runat="server" class="inp" readonly="readonly" onclick="displayCalendar(this, 'yyyy-mm-dd hh:ii', this, true, new Date());" />
                    </tr>
                    <tr>
                        <td align="right">每次增加时间段(例如40-70)：</td>
                        <td>
                            <asp:TextBox ID="frmTimeAddRange" runat="server" Width="150px"></asp:TextBox></td>
                    </tr>
                    <tr>
                        <td align="right">每次增加金额：</td>
                        <td>
                            <XCL:DecimalBox ID="frmEveryAddPrice" runat="server" Width="80px" CurrencySymbol="HK$"></XCL:DecimalBox></td>
                    </tr>
                    <tr>
                        <td align="right">每次竞投所需积分：</td>
                        <td>
                            <XCL:NumberBox ID="frmEveryNeedPoint" runat="server" Width="80px"></XCL:NumberBox></td>
                    </tr>
                    <tr>
                        <td align="right">最低竞投价格：</td>
                        <td>
                            <XCL:DecimalBox ID="frmMinPrice" runat="server" Width="80px" CurrencySymbol="HK$"></XCL:DecimalBox></td>
                    </tr>
                    <tr>
                        <td align="right">竞投限制时间截止时间：</td>
                        <td>
                            <input type="text" id="frmBiddingLimitTime" name="frmBiddingLimitTime" runat="server" class="inp" readonly="readonly" onclick="displayCalendar(this, 'yyyy-mm-dd hh:ii', this, true, '');" />
                            <asp:TextBox ID="frmEndTime" runat="server" Width="300px" Visible="false"></asp:TextBox>
                            <asp:TextBox ID="frmAuctionSatus" runat="server" Width="300px" Visible="false"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td align="right">商品图片：</td>
                        <td>
                            <div class="row-fluid">
                                <asp:FileUpload ID="Img" runat="server" _CssClass="uploader focus" /><asp:Label ID="Label1" CssClass="error" runat="server" Text=""></asp:Label><asp:Button ID="Button1" runat="server" CssClass="aaaa" Text="上传" OnClick="Button1_Click" />
                                <asp:TextBox ID="frmProductImage1" runat="server" Width="300px" Visible="false"></asp:TextBox>
                            </div>
                        </td>
                    </tr>
                    <tr>
                        <td align="right">商品图片2：</td>
                        <td>
                            <div class="row-fluid">
                                <asp:FileUpload ID="Img2" runat="server" _CssClass="uploader focus" /><asp:Label ID="Label2" CssClass="error" runat="server" Text=""></asp:Label><asp:Button ID="Button2" runat="server" Text="上传" OnClick="Button2_Click" />
                                <asp:TextBox ID="frmProductImage2" runat="server" Width="300px" Visible="false"></asp:TextBox>
                            </div>
                        </td>
                    </tr>
                    <tr>
                        <td align="right">商品图片3：</td>
                        <td>
                            <div class="row-fluid">
                                <asp:FileUpload ID="Img3" runat="server" _CssClass="uploader focus" /><asp:Label ID="Label3" CssClass="error" runat="server" Text=""></asp:Label><asp:Button ID="Button3" runat="server" Text="上传" OnClick="Button3_Click" />
                                <asp:TextBox ID="frmProductImage3" runat="server" Width="300px" Visible="false"></asp:TextBox>
                            </div>
                        </td>
                    </tr>
                    <tr>
                        <td align="right">广告名称：</td>
                        <td>
                            <asp:TextBox ID="frmAdv_name" runat="server"></asp:TextBox></td>
                    </tr>
                    <tr>
                        <td align="right">广告简介：</td>
                        <td>
                            <asp:TextBox ID="frmAdv_description" runat="server"></asp:TextBox></td>
                    </tr>
                    <tr>
                        <td align="right">广告内容：</td>
                        <td>
                            <asp:TextBox ID="frmAdv_content" runat="server" TextMode="MultiLine" Width="300px" Height="80px"></asp:TextBox></td>
                    </tr>
                    <tr>
                        <td align="right">广告图片：</td>
                        <td>
                            <div class="row-fluid">
                                <asp:FileUpload ID="Img4" runat="server" _CssClass="uploader focus" /><asp:Label ID="Label4" CssClass="error" runat="server" Text=""></asp:Label><asp:Button ID="Button4" runat="server" Text="上传" OnClick="Button4_Click" />
                                <asp:TextBox ID="frmAdv_image" runat="server" Width="300px" Visible="false"></asp:TextBox>
                            </div>
                        </td>
                    </tr>


                </table>
                <table border="0" align="Center" width="100%">
                    <tr>
                        <td align="center">
                            <asp:Button ID="btnSave" runat="server" CausesValidation="True" Text='保存' CssClass="RealSave" />
                            &nbsp;<asp:Button ID="btnCopy" runat="server" CausesValidation="True" Text='另存为竞投' CssClass="CopySave" />
                        </td>
                    </tr>
                </table>
            </div>
        </div>
    </div>

</asp:Content>
