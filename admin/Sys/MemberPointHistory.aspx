<%@ Page Language="C#" Title="会员积分历史" AutoEventWireup="true" MasterPageFile="~/MasterPage.master" CodeFile="MemberPointHistory.aspx.cs" Inherits="admin_Sys_MemberPointHistory" %>

<asp:Content ID="Content1" runat="server" ContentPlaceHolderID="C">
    <style>
        .nonev
        {
            display: none;
        }
       
    </style>
    <div class="row-fluid">

        &nbsp;时间：<XCL:DateTimePicker ID="StartDate" runat="server" LongTime="False">
        </XCL:DateTimePicker>
        &nbsp;至
        <XCL:DateTimePicker ID="EndDate" runat="server" LongTime="False">
        </XCL:DateTimePicker>
        &nbsp;<asp:Button ID="Button4" runat="server" Text="查询" CssClass="btn btn-primary"/>
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
                        <asp:BoundField DataField="MemberID" HeaderText="MemberID" ItemStyle-CssClass="nonev" HeaderStyle-CssClass="nonev"/>
                        <asp:TemplateField ShowHeader="False" HeaderText="会员">
                            <ItemTemplate>
                                <%#Eval("memberName") %>
                            </ItemTemplate>
                            <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="30px" />
                        </asp:TemplateField>
                        
                        <asp:BoundField DataField="UseTime" HeaderText="时间" SortExpression="UseTime" DataFormatString="{0:yyyy-MM-dd HH:mm:ss}"></asp:BoundField>
                        <asp:BoundField DataField="ItemName" HeaderText="動作" SortExpression="ItemName" />
                        <asp:BoundField DataField="Point" HeaderText="操作積分 " SortExpression="Point" />
                        <asp:BoundField DataField="CurrentPointCount" HeaderText="積分餘額" SortExpression="CurrentPointCount" />
                        <XCL:LinkBoxField HeaderText="编辑" DataNavigateUrlFields="MemberID" DataNavigateUrlFormatString="MemberPointForm.aspx?MemberID={0}" Height="400px" Text="编辑" Width="540px" Title="编辑Address">
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
                <asp:ObjectDataSource ID="ObjectDataSource1" runat="server" OldValuesParameterFormatString="original_{0}" SelectMethod="Search_DateTime" TypeName="Jetso.Data.PointHistory" DataObjectTypeName="Jetso.Data.PointHistory" DeleteMethod="Delete" InsertMethod="Insert" UpdateMethod="Update">
                    <SelectParameters>
                        <asp:Parameter Name="key" Type="String" />
                        <asp:ControlParameter ControlID="StartDate" Name="startTime" PropertyName="Value" Type="DateTime" />
                        <asp:ControlParameter ControlID="EndDate" Name="endTime" PropertyName="Value" Type="DateTime" />
                        <asp:Parameter Name="id" Type="Int32" />
                        <asp:Parameter Name="orderClause" Type="String" />
                        <asp:Parameter Name="startRowIndex" Type="Int32" />
                        <asp:Parameter Name="maximumRows" Type="Int32" />
                    </SelectParameters>
                </asp:ObjectDataSource>
            </div>
        </div>
    </div>

</asp:Content>
