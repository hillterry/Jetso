<%@ Page Language="C#" Title="竞投管理"  MasterPageFile="~/MasterPage.master"  AutoEventWireup="true" CodeFile="MemberAuctionSuccess.aspx.cs" Inherits="admin_Sys_MemberAuctionSuccess" %>


<asp:Content ID="g" ContentPlaceHolderID="H" runat="server">
    <style type="text/css">
        .btn {
            vertical-align: top;
        }
    </style>
</asp:Content>

<asp:Content ID="Content1" runat="server" ContentPlaceHolderID="C">
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
                        <asp:BoundField DataField="BiddingPriceNow" HeaderText="竞投成功价格" SortExpression="BiddingPriceNow" DataFormatString="{0:c}">
                            <ItemStyle HorizontalAlign="Right" Font-Bold="True" ForeColor="Blue" />
                        </asp:BoundField>

                        <asp:BoundField DataField="StarTime" HeaderText="竞投开始时间" SortExpression="StarTime" DataFormatString="{0:yyyy-MM-dd HH:mm:ss}"></asp:BoundField>

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
                        <asp:BoundField DataField="BidCount" HeaderText="竞投总次数" SortExpression="BidCount" DataFormatString="{0:n0}">
                            <ItemStyle HorizontalAlign="Right" Font-Bold="True" />
                        </asp:BoundField>
                        <asp:BoundField DataField="CreatTime" HeaderText="创建时间" SortExpression="CreatTime" DataFormatString="{0:yyyy-MM-dd HH:mm:ss}">
                            <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="120px" />
                        </asp:BoundField>
                        <asp:BoundField DataField="UpdateTime" HeaderText="修改时间" SortExpression="UpdateTime" DataFormatString="{0:yyyy-MM-dd HH:mm:ss}">
                            <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="120px" />
                        </asp:BoundField>
                        <asp:TemplateField ShowHeader="False" HeaderText="删除">
                            <ItemTemplate>
                                <asp:LinkButton ID="btnDelete" runat="server" CausesValidation="False" CommandName="Delete" OnClientClick='return confirm("确定删除吗？")' Text="删除"></asp:LinkButton>
                            </ItemTemplate>
                            <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="30px" />
                        </asp:TemplateField>
                    </Columns>
                    <EmptyDataTemplate>
                        没有完成任何竞投！
                    </EmptyDataTemplate>
                </asp:GridView>
            </div>
        </div>
    </div>

    <asp:ObjectDataSource ID="ods" runat="server" DataObjectTypeName="Jetso.Data.Auction" DeleteMethod="Delete" InsertMethod="Insert" OldValuesParameterFormatString="original_{0}" SelectMethod="FindAllByMemberIDandStatus" TypeName="Jetso.Data.Auction" UpdateMethod="Update">
        <SelectParameters>
            <asp:Parameter DefaultValue="" Name="id" Type="Int32" />
            <asp:Parameter DefaultValue="3" Name="status" Type="Int32" />
        </SelectParameters>
    </asp:ObjectDataSource>
</asp:Content>
