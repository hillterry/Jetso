<%@ Page Title="竞投管理" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Auction.aspx.cs" Inherits="Common_Auction" %>

<asp:Content ID="g" ContentPlaceHolderID="H" runat="server">
    <style type="text/css">
        .btn {
            vertical-align: top;
        }
    </style>
</asp:Content>

<asp:Content ID="Content1" runat="server" ContentPlaceHolderID="C">
    <div class="row-fluid">
        <XCL:LinkBox ID="lbAdd" runat="server" BoxHeight="450px" BoxWidth="700px" Url="AuctionForm.aspx"
            IconLeft="~/Admin/images/icons/new.gif" EnableViewState="false" CssClass="btn"><b>添加竞投</b></XCL:LinkBox>
        关键字：<asp:TextBox ID="txtKey" runat="server"></asp:TextBox>
        <asp:Button ID="btnSearch" runat="server" Text="查询" CssClass="btn btn-primary" />
    </div>
    <div class="row-fluid">
        <div class="widget-box">
            <div class="widget-content nopadding">
                <asp:GridView ID="gv" runat="server" AutoGenerateColumns="False" DataKeyNames="ID" DataSourceID="ods" AllowPaging="True" AllowSorting="True" CssClass="table table-bordered table-striped" PageSize="20" CellPadding="0" GridLines="None" EnableModelValidation="True">
                    <Columns>
                        <%--<asp:TemplateField>
                <ItemTemplate>
                    <asp:CheckBox ID="cb" runat="server" />
                </ItemTemplate>
                <HeaderStyle Width="20px" />
                <ItemStyle HorizontalAlign="Center" />
            </asp:TemplateField>--%>
                        <asp:BoundField DataField="ID" HeaderText="竞投ID" SortExpression="ID" DataFormatString="{0:n0}">
                            <ItemStyle HorizontalAlign="Right" Font-Bold="True" />
                        </asp:BoundField>
                        <asp:BoundField DataField="ProductNo" HeaderText="竞投产品编号" SortExpression="ProductNo" />
                        <asp:BoundField DataField="ProductName" HeaderText="竞投商品名称" SortExpression="ProductName" />
                        <asp:BoundField DataField="MarkPrice" HeaderText="市场价格原价" SortExpression="MarkPrice" DataFormatString="{0:c}">
                            <ItemStyle HorizontalAlign="Right" Font-Bold="True" ForeColor="Blue" />
                        </asp:BoundField>
                        <asp:BoundField DataField="BiddingPriceNow" HeaderText="竞投当前价格" SortExpression="BiddingPriceNow" DataFormatString="{0:c}">
                            <ItemStyle HorizontalAlign="Right" Font-Bold="True" ForeColor="Blue" />
                        </asp:BoundField>

                        <asp:BoundField DataField="StarTime" HeaderText="竞投开始时间" SortExpression="StarTime" DataFormatString="{0:yyyy-MM-dd HH:mm:ss}"></asp:BoundField>
                        <asp:BoundField DataField="TimeAddRange" HeaderText="每次增加时间段例如40-70" SortExpression="TimeAddRange">
                            <ItemStyle HorizontalAlign="Right" Font-Bold="True" ForeColor="Blue" Width="120px" />
                        </asp:BoundField>
                        <asp:BoundField DataField="EveryAddPrice" HeaderText="每次增加金额" SortExpression="EveryAddPrice" DataFormatString="{0:c}">
                            <ItemStyle HorizontalAlign="Right" Font-Bold="True" ForeColor="Blue" />
                        </asp:BoundField>
                        <asp:BoundField DataField="EveryNeedPoint" HeaderText="每次竞投所需积分" SortExpression="EveryNeedPoint" DataFormatString="{0:n0}">
                            <ItemStyle HorizontalAlign="Right" Font-Bold="True" ForeColor="Blue" Width="120px" />
                        </asp:BoundField>
                        <asp:BoundField DataField="MinPrice" HeaderText="最低竞投价格" SortExpression="MinPrice" DataFormatString="{0:c}">
                            <ItemStyle HorizontalAlign="Right" Font-Bold="True" ForeColor="Blue" />
                        </asp:BoundField>
                        <asp:BoundField DataField="BiddingLimitTime" HeaderText="竞投限制时间截止时间" SortExpression="BiddingLimitTime" DataFormatString="{0:yyyy-MM-dd HH:mm:ss}">
                            <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="120px" />
                        </asp:BoundField>
                        <asp:BoundField DataField="EndTime" HeaderText="最终竞投成功时间" SortExpression="EndTime" DataFormatString="{0:yyyy-MM-dd HH:mm:ss}">
                            <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="120px" />
                        </asp:BoundField>
                        <asp:TemplateField ShowHeader="False" HeaderText="投标者最终竞投者">
                            <ItemTemplate>
                                <%#Eval("member.nickName") %>
                            </ItemTemplate>
                            <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="30px" />
                        </asp:TemplateField>
                        <asp:BoundField DataField="WinnerBidCount" HeaderText="竞投成功者竞投次数" SortExpression="WinnerBidCount" DataFormatString="{0:n0}">
                            <ItemStyle HorizontalAlign="Right" Font-Bold="True" />
                        </asp:BoundField>
                        <asp:BoundField DataField="BidCount" HeaderText="竞投次数" SortExpression="BidCount" DataFormatString="{0:n0}">
                            <ItemStyle HorizontalAlign="Right" Font-Bold="True" />
                        </asp:BoundField>
                       <asp:TemplateField ShowHeader="False" HeaderText="投标者最终竞投者">
                            <ItemTemplate>
                                <%#Eval("AuctionStatusEnum") %>
                            </ItemTemplate>
                            <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="30px" />
                        </asp:TemplateField>
                        
                        <XCL:LinkBoxField HeaderText="编辑" DataNavigateUrlFields="ID" DataNavigateUrlFormatString="AuctionForm.aspx?ID={0}" Height="400px" Text="编辑" Width="540px" Title="竞投">
                            <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                            <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="30px" />
                        </XCL:LinkBoxField>
                        <asp:TemplateField ShowHeader="False" HeaderText="删除">
                            <ItemTemplate>
                                <asp:LinkButton ID="btnDelete" runat="server" CausesValidation="False" CommandName="Delete" OnClientClick='return confirm("确定删除吗？")' Text="删除"></asp:LinkButton>
                            </ItemTemplate>
                            <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="30px" />
                        </asp:TemplateField>
                    </Columns>
                    <EmptyDataTemplate>
                        没有符合条件的数据！
                    </EmptyDataTemplate>
                </asp:GridView>
            </div>
        </div>
    </div>

    <asp:ObjectDataSource ID="ods" runat="server" EnablePaging="True" SelectCountMethod="SearchCount" SelectMethod="Search" SortParameterName="orderClause" EnableViewState="False" DataObjectTypeName="Jetso.Data.Auction" DeleteMethod="Delete" InsertMethod="Insert" OldValuesParameterFormatString="original_{0}" TypeName="Jetso.Data.Auction" UpdateMethod="Update">
        <SelectParameters>
            <asp:ControlParameter ControlID="txtKey" Name="key" PropertyName="Text" Type="String" />
            <asp:Parameter Name="orderClause" Type="String" />
            <asp:Parameter Name="startRowIndex" Type="Int32" />
            <asp:Parameter Name="maximumRows" Type="Int32" />
        </SelectParameters>
    </asp:ObjectDataSource>
    <XCL:GridViewExtender ID="gvExt" runat="server">
    </XCL:GridViewExtender>
</asp:Content>
