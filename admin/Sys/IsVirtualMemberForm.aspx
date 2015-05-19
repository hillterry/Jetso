<%@ Page Title="虚拟会员" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="IsVirtualMemberForm.aspx.cs" Inherits="admin_Sys_IsVirtualMemberForm" %>

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
        });
    </script>
    <table border="0" class="m_table" cellspacing="1" cellpadding="0" align="Center">
        <tr>
            <th colspan="2">member</th>
        </tr>
        <tr>
            <td align="right">账号：</td>
            <td>
                <asp:TextBox ID="frmnickName" runat="server" Width="150px"></asp:TextBox>
                <label id="errormsg">账号由6-12位数字或者字符组成</label>
            </td>
        </tr>
        <tr style="display: none">
            <td align="right">是否为虚拟会员：</td>
            <td>
                <asp:CheckBox ID="frmIsVirtualMember" Checked="true" runat="server" Text="是否为虚拟会员" />
            </td>
        </tr>
    </table>
    <table border="0" align="Center" width="100%">
        <tr>
            <td align="center">
                <asp:Button ID="btnSave" runat="server" CausesValidation="True" Text='保存' />
                &nbsp;<asp:Button ID="btnCopy" runat="server" CausesValidation="True" Text='另存为新member' />
                &nbsp;<asp:Button ID="btnReturn" runat="server" OnClientClick="parent.Dialog.CloseSelfDialog(frameElement);return false;" Text="返回" />
            </td>
        </tr>
    </table>
</asp:Content>
