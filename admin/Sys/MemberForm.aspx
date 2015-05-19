<%@ Page Title="会员" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="memberForm.aspx.cs" Inherits="Common_memberForm" %>

<asp:Content ID="Content1" runat="server" ContentPlaceHolderID="C">

    <script type="text/javascript">
        function isEmail(mail) {
            return (new RegExp(/^\w+((-\w+)|(\.\w+))*\@[A-Za-z0-9]+((\.|-)[A-Za-z0-9]+)*\.[A-Za-z0-9]+$/).test(mail));
        }
        function isTrue(str) {
            return (new RegExp(/^[A-Za-z0-9]{6,12}$/).test(str));
        }
        $(function () {
            $("#<%=frmnickName.ClientID%>").blur(function () {
                if (!isTrue($("#<%=frmnickName.ClientID%>").val())) { alert("用户名错误!"); }
                $.ajax({
                    type: 'POST',
                    url: 'Validform.asmx/ValidForm',
                    data: '{validstr:"' + $('#<%=frmnickName.ClientID%>').val() + '",isemail:' + '"false"' + '}',
                    contentType: "application/json; charset=utf-8",
                    dataType: "json",

                    success: function (result) {
                        if (result.d) {
                            $("#errormsg").css('color', 'red');
                            $("#errormsg").html('账号已存在');
                        }
                    },

                    error: function () {
                        alert("error");
                    }


                });
            });
            $("#<%=frmnickName.ClientID%>").focus(function () {
                $("#errormsg").html("账号由6-12位数字或者字符组成");
            }
                )
            $("#<%=frmemail.ClientID%>").focus(function () {
                $("#errormsg2").html("");
            }
                )
            $("#<%=frmemail.ClientID%>").blur(function () {
                if (!isEmail($("#<%=frmemail.ClientID%>").val())) {
                    alert("电邮地址不正确");
                }

                $.ajax({
                    type: 'POST',
                    url: 'Validform.asmx/ValidForm',
                    data: '{validstr:"' + $('#<%=frmemail.ClientID%>').val() + '",isemail:' + '"true"' + '}',
                        contentType: "application/json; charset=utf-8",
                        dataType: "json",

                        success: function (result) {
                            if (result.d) {
                                $("#errormsg2").css('color', 'red');
                                $("#errormsg2").html('邮箱地址已存在');
                            }
                        },

                        error: function () {
                            alert("error");
                        }


                    });
            });
        });
    </script>
    <div class="row-filuid">
        <div class="widget-box">
            <div class="widget-content nopadding">
               
                <table class="table table-bordered table-striped">
                    <tr>
                        <th colspan="2">member</th>
                    </tr>
                    <tr>
                        <td align="right">ID：</td>
                        <td>
                            <asp:TextBox ID="frmID" runat="server" Width="150px"></asp:TextBox>
                           
                        </td>
                    </tr>
                    <tr>
                        <td align="right">账号：</td>
                        <td>
                            <asp:TextBox ID="frmnickName" runat="server" Width="150px"></asp:TextBox>
                            <label id="errormsg">账号由6-12位数字或者字符组成</label>
                        </td>
                    </tr>
                    <tr>
                        <td align="right">电邮地址：</td>
                        <td>
                            <asp:TextBox ID="frmemail" runat="server" Width="150px"></asp:TextBox>
                            <label id="errormsg2"></label>
                        </td>

                    </tr>
                    <tr>
                        <td align="right">密码：</td>
                        <td>
                            <asp:TextBox ID="frmpassword" runat="server" ></asp:TextBox></td>
                    </tr>
                    <tr>
                        <td align="right">名称：</td>
                        <td>
                            <asp:TextBox ID="frmname" runat="server" Width="150px"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td align="right">性别：</td>
                        <td>
                            <asp:RadioButtonList ID="frmgender" runat="server" RepeatColumns="2">
                                <asp:ListItem Text="男" Value="男" Selected="True"></asp:ListItem>
                                <asp:ListItem Text="女" Value="女"></asp:ListItem>
                            </asp:RadioButtonList>
                        </td>
                    </tr>
                    <tr>
                       
                        <td align="right">出生日期：</td>
                        <td>
                             <input type="text" id="frmbirthday" name="frmbirthday" runat="server" class="inp" readonly="readonly" onclick="displayCalendar(this, 'yyyy-mm-dd', this ,true, new Date());" />
                        </td>
                    </tr>
                    <tr>
                        <td align="right">学历：</td>
                        <td>
                            <asp:DropDownList ID="frmeducation" runat="server" DataValueField="value" DataTextField="value"></asp:DropDownList>
                        </td>
                    </tr>
                    <tr>
                        <td align="right">电话：</td>
                        <td>
                            <asp:TextBox ID="frmphone" runat="server" Width="120px"></asp:TextBox></td>
                    </tr>
                    <tr>
                        <td align="right">详细地址：</td>
                        <td>
                            <asp:TextBox ID="frmadress" runat="server" Width="200px"></asp:TextBox></td>
                    </tr>
                    <tr>
                        <td align="right">收入情况：</td>
                        <td>
                            <asp:DropDownList ID="frmincome" runat="server" DataValueField="value" DataTextField="value"></asp:DropDownList>
                        </td>
                    </tr>
                    <tr>
                        <td align="right">女儿：</td>
                        <td>
                            <XCL:NumberBox ID="frmgirls" runat="server" Width="80px"></XCL:NumberBox></td>
                    </tr>
                    <tr>
                        <td align="right">儿子：</td>
                        <td>
                            <XCL:NumberBox ID="frmboys" runat="server" Width="80px"></XCL:NumberBox></td>
                    </tr>
                   <%-- <tr>
                        <td align="right">积分：</td>
                        <td>
                            <XCL:NumberBox ID="frmpoint" runat="server" Width="80px"></XCL:NumberBox></td>
                    </tr>--%>
                    <tr style="display: none">
                        <td align="right">是否为虚拟会员：</td>
                        <td>
                            <input type="checkbox" id="frmIsVirtualMember" runat="server" />
                            <label>是否为虚拟会员</label></td>
                    </tr>
                    
                </table>
                <table border="0" align="Center" width="100%">
                    <tr>
                        <td align="center">
                            
                            <asp:Button ID="btnSave" Text="保存" CausesValidation="True" runat="server" />
                            &nbsp;<asp:Button ID="btnCopy" runat="server" CausesValidation="True" Text='另存为新member' />
                            &nbsp;<asp:Button ID="btnReturn" runat="server" OnClientClick="parent.Dialog.CloseSelfDialog(frameElement);return false;" Text="返回" />
                        </td>
                    </tr>
                </table>
            </div>
        </div>
    </div>

</asp:Content>
