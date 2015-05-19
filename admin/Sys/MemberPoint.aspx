<%@ Page Language="C#" Title="会员积分" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="MemberPoint.aspx.cs" Inherits="admin_Sys_MemberPoint" %>

<asp:Content ID="Content1" runat="server" ContentPlaceHolderID="C">
    <div class="row-fluid">
        關鍵字：<asp:TextBox ID="txtKey" runat="server"></asp:TextBox>
        <asp:Button ID="btnSearch" runat="server" Text="查詢" CssClass="btn btn-primary" />
    </div>
    <div class="row-fluid">
        <div class="widget-box">
            <div class="widget-content nopadding">
                <asp:GridView ID="gv" runat="server" AutoGenerateColumns="False" DataKeyNames="ID" DataSourceID="ObjectDataSource1" AllowPaging="True" AllowSorting="True" CssClass="table table-bordered table-striped" PageSize="20" CellPadding="0" GridLines="None">
                    <Columns>
                        <%--<asp:TemplateField>
                <ItemTemplate>
                    <asp:CheckBox ID="cb" runat="server" />
                </ItemTemplate>
                <HeaderStyle Width="20px" />
                <ItemStyle HorizontalAlign="Center" />
            </asp:TemplateField>--%>
                        <asp:BoundField DataField="ID" HeaderText="ID" SortExpression="ID" />
                        <asp:BoundField DataField="nickName" HeaderText="账号" SortExpression="nickName" />
                        <asp:BoundField DataField="email" HeaderText="电邮地址" SortExpression="email" />
                        <asp:BoundField DataField="name" HeaderText="名称" SortExpression="name" />
                        <asp:BoundField DataField="point" HeaderText="积分" SortExpression="point" />
                        <asp:TemplateField ShowHeader="False" HeaderText="积分历史">
                            <ItemTemplate>
                                <a href="MemberPointHistory.aspx?ID=<%#Eval("ID") %>">查看</a>
                                <itemstyle horizontalalign="Center" verticalalign="Middle" width="40px" />
                            </ItemTemplate>
                            <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="40px" />
                        </asp:TemplateField>
                        <XCL:LinkBoxField HeaderText="编辑" DataNavigateUrlFields="ID" DataNavigateUrlFormatString="MemberPointForm.aspx?MemberID={0}" Height="400px" Text="编辑" Width="540px" Title="编辑Address">
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
                <asp:ObjectDataSource ID="ObjectDataSource1" runat="server" DataObjectTypeName="Jetso.Data.member" DeleteMethod="Delete" InsertMethod="Insert" OldValuesParameterFormatString="original_{0}" SelectMethod="FindByIsVirtual" TypeName="Jetso.Data.member" UpdateMethod="Update">
                    <SelectParameters>
                        <asp:Parameter DefaultValue="false" Name="isvirtual" Type="Boolean" />
                    </SelectParameters>
                </asp:ObjectDataSource>
            </div>
        </div>
    </div>

</asp:Content>
