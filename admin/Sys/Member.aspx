<%@ Page Title="会员" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="member.aspx.cs" Inherits="Common_member" %>

<asp:Content ID="g" ContentPlaceHolderID="H" runat="server">
    <style type="text/css">
        .btn {
            vertical-align: top;
        }
    </style>
</asp:Content>
<asp:Content ID="Content1" runat="server" ContentPlaceHolderID="C">
    <div class="row-fluid">
        <XCL:LinkBox ID="lbAdd" runat="server" BoxHeight="400px" BoxWidth="500px" Url="MemberForm.aspx"
            IconLeft="~/Admin/images/icons/new.gif" EnableViewState="false" CssClass="btn"><b>添加會員</b></XCL:LinkBox>
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
                        <asp:BoundField DataField="gender" HeaderText="性别" SortExpression="gender" />
                        <asp:BoundField DataField="birthday" HeaderText="出生日期" SortExpression="birthday" DataFormatString="{0:yyyy-MM-dd}"></asp:BoundField>
                        <asp:BoundField DataField="marryStatus" HeaderText="婚姻状态" SortExpression="marryStatus" />
                        <asp:BoundField DataField="education" HeaderText="学历" SortExpression="education" />
                        <asp:BoundField DataField="phone" HeaderText="电话" SortExpression="phone" />
                        <asp:BoundField DataField="adress" HeaderText="详细地址" SortExpression="adress" />
                        <asp:BoundField DataField="introduceName" HeaderText="毕业学校" SortExpression="introduceName" />
                        <asp:BoundField DataField="income" HeaderText="收入情况" SortExpression="income" />
                        <asp:BoundField DataField="girls" HeaderText="女儿" SortExpression="girls" DataFormatString="{0:n0}">
                            <ItemStyle HorizontalAlign="Right" Font-Bold="True" />
                        </asp:BoundField>
                        <asp:BoundField DataField="boys" HeaderText="儿子" SortExpression="boys" DataFormatString="{0:n0}">
                            <ItemStyle HorizontalAlign="Right" Font-Bold="True" />
                        </asp:BoundField>
                        <asp:BoundField DataField="active" HeaderText="注册状态" SortExpression="active" DataFormatString="{0:n0}">
                            <ItemStyle HorizontalAlign="Right" Font-Bold="True" />
                        </asp:BoundField>
                        <asp:BoundField DataField="lastLoginDate" HeaderText="最后登录时间" SortExpression="lastLoginDate" DataFormatString="{0:yyyy-MM-dd HH:mm:ss}">
                            <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="120px" />
                        </asp:BoundField>
                        <asp:BoundField DataField="createDateTime" HeaderText="创建时间" SortExpression="createDateTime" DataFormatString="{0:yyyy-MM-dd HH:mm:ss}">
                            <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="120px" />
                        </asp:BoundField>
                        <asp:BoundField DataField="point" HeaderText="积分" SortExpression="point" DataFormatString="{0:n0}">
                            <ItemStyle HorizontalAlign="Right" Font-Bold="True" />
                        </asp:BoundField>
                        <asp:BoundField DataField="checkinTime" HeaderText="签到时间" SortExpression="checkinTime" DataFormatString="{0:yyyy-MM-dd HH:mm:ss}">
                            <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="120px" />
                        </asp:BoundField>
                        <asp:TemplateField ShowHeader="False" HeaderText="竞投成功清单">
                            <ItemTemplate>
                                <a href="MemberAuctionSuccess.aspx?ID=<%#Eval("ID") %>">查看</a>
                                <itemstyle horizontalalign="Center" verticalalign="Middle" width="40px" />
                            </ItemTemplate>
                            <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="40px" />
                        </asp:TemplateField>
                        <XCL:LinkBoxField HeaderText="编辑" DataNavigateUrlFields="ID" DataNavigateUrlFormatString="MemberForm.aspx?ID={0}" Height="400px" Text="编辑" Width="540px" Title="编辑Address">
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
