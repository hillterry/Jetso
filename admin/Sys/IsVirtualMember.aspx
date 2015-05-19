<%@ Page Title="虚拟会员" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="IsVirtualMember.aspx.cs" Inherits="admin_Sys_IsVirtualMember" %>

<asp:Content ID="g" ContentPlaceHolderID="H" runat="server">
    <style type="text/css">
        .btn {
            vertical-align: top;
        }
    </style>
    <link rel="stylesheet" href="<%= ResolveUrl("~/UI/css/uniform.css")%>" type="text/css" />
    <script src="<%= ResolveUrl("~/UI/js/jquery.uniform.js")%>" type="text/javascript"></script>
    <script src="<%= ResolveUrl("~/UI/js/unicorn.form_common.js")%>" type="text/javascript"></script>
</asp:Content>
<asp:Content ID="Content1" runat="server" ContentPlaceHolderID="C">
    <div class="row-fluid">
        <XCL:LinkBox ID="lbAdd" runat="server" BoxHeight="450px" BoxWidth="540px" Url="IsVirtualMemberForm.aspx"
            IconLeft="~/Admin/images/icons/new.gif" EnableViewState="false" CssClass="btn"><b>添加會員</b></XCL:LinkBox>
        &nbsp;&nbsp;&nbsp;<asp:FileUpload ID="txt" runat="server" _CssClass="uploader focus" />
        &nbsp;&nbsp;&nbsp;<asp:Button ID="Button3" runat="server" Text="导入" OnClick="Button3_Click" CssClass="btn btn-danger" />
<%--        關鍵字：<asp:TextBox ID="txtKey" runat="server"></asp:TextBox>
        <asp:Button ID="btnSearch" runat="server" Text="查詢" CssClass="btn btn-primary" />--%>
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
                        <%--            <asp:TemplateField HeaderText="是否为虚拟会员" SortExpression="IsVirtualMember">
              <ItemStyle HorizontalAlign="Right" Font-Bold="True" ForeColor="Blue"  Width="120px"/>
              <ItemTemplate>
                <asp:Label ID="IsEnable1" runat="server" Text="√" Visible='<%# Eval("isVirtualMember")%>'
                  Font-Bold="True" Font-Size="14pt" ForeColor="Green"></asp:Label>
                <asp:Label ID="IsEnable2" runat="server" Text="×" Visible='<%# !(Boolean)Eval("isVirtualMember")%>'
                  Font-Bold="True" Font-Size="16pt" ForeColor="Red"></asp:Label>
              </ItemTemplate>
              <ItemStyle HorizontalAlign="Center" />
              <HeaderStyle CssClass="widget-title" Font-Size="Small" />
            </asp:TemplateField>--%>
                        <XCL:LinkBoxField HeaderText="编辑" DataNavigateUrlFields="ID" DataNavigateUrlFormatString="IsVirtualMemberForm.aspx?ID={0}" Height="450px" Text="编辑" Width="550px" Title="编辑member">
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
                        <asp:Parameter DefaultValue="true" Name="isvirtual" Type="Boolean" />
                    </SelectParameters>
                </asp:ObjectDataSource>
            </div>
        </div>
    </div>

</asp:Content>

