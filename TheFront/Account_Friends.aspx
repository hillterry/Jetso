<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Account_Friends.aspx.cs" Inherits="TheFront_Account_Friends" %>

<!DOCTYPE html>
<html lang="en" style="-webkit-text-size-adjust: 100%; -ms-text-size-adjust: 100%;">
<head>
    <meta charset="utf-8" />
    <meta name="viewport" content="width=device-width, initial-scale=1, minimum-scale=1, maximum-scale=1, user-scalable=0" />
    <title>拍卖网</title>
    <link href="css/style.css" rel="stylesheet" type="text/css" />
    <link href="css/account_executive.css" rel="stylesheet" type="text/css">
    <link href="css/style_2.css" rel="stylesheet" type="text/css" />
    <link href="css/css2.css" rel="stylesheet" type="text/css" />

    <script type="text/javascript">
        //Account 异步提交
        $(document).ready(function () {
            var options = {
                success: function (data) {
                    var msg = data;
                    clickAccount('Account_Friends.aspx?error=' + msg);
                }
            };

            // ajaxForm
            $("#<%=frmMemberFriend.ClientID%>").ajaxForm(options);

        });

        function isEmail(mail) {
            return (new RegExp(/^\w+((-\w+)|(\.\w+))*\@[A-Za-z0-9]+((\.|-)[A-Za-z0-9]+)*\.[A-Za-z0-9]+$/).test(mail));
        }

        function chkFrm() {
            var frm = document.getElementById("<%=frmMemberFriend.ClientID%>");
            if (trim(frm.frmName.value) == "") {
                alert("請輸入好友姓名");
                frm.frmName.focus();
                return false;
            }


            if (trim(frm.frmEmail.value) == "") {
                alert("請輸入電郵地址！");
                frm.frmEmail.focus();
                return false;
            }

            if (!isEmail(trim(frm.frmEmail.value))) {
                alert("請輸入正確的電郵地址！");
                frm.frmEmail.focus();
                return false;
            }

            return true;
        }


    </script>
</head>

<body>
    <div class="bai">
        <div class="vessel">
            <div class="head">邀请朋友</div>
            <img src="images/gimg.jpg" height="306" border="0" class="gimg" />
            <nav id="navigation">
                <a href="account_executive.html" class="nav-btn">邀请朋友<span class="arr"></span></a>
                <ul>
                    <li onclick="clickAccount('Account_executive.aspx')"><a href="#">賺取bids點</a></li>
                    <li><a href="#">勝出拍賣</a></li>
                    <li onclick="clickAccount('Account_Bids.aspx')"><a href="#">我的 BIDS</a></li>
                    <li onclick="clickAccount('Account_infor.aspx')"><a href="#">設置帳戶資訊</a></li>
                    <li onclick="clickAccount('Account_ChangeEmail.aspx')"><a href="#">修改郵箱</a></li>
                    <li onclick="clickAccount('Account_Key.aspx')"><a href="#">修改密碼</a></li>
                    <li><a href="account_share_7.html">分享統計</a></li>
                    <li onclick="clickAccount('Account_Friends.aspx')" class="active"><a href="#">邀请朋友</a></li>
                    <li><a href="account_marketing_9.html">瀏覽推介歷史</a></li>

                </ul>
            </nav>

            <div class="width770 font14 minHeight1">
                <form id="frmMemberFriend" method="post" runat="server" onsubmit="return chkFrm()" action="../FrontView/checkMemberFriend.ashx">
                    <div class="setting_up">
                        <ul class="Form folatle">
                            <li class="width99">好友姓名 *</li>
                            <li>
                                <input type="text" name="frmName" class="width2" />
                            </li>
                            <div class="clar"></div>
                            <li class="width99">好友電子郵箱 *</li>
                            <li>
                                <input type="text" name="frmEmail" value="" class="width2" />
                            </li>
                            <div class="clar"></div>
                            <li class="width99">留言</li>
                            <li>
                                <input name="Message" type="text" class="width2" /></li>
                            <div class="clar"></div>
                            <li>
                                <label id="error"><%=errorMsg %></label></li>
                            <div class="clar"></div>
                            <li class="width99"></li>
                            <li class="width99">
                                <input type="submit" value="提交" class="ba_red-3" />
                            </li>
                        </ul>
                    </div>
                    <div class="clar"></div>
                    <asp:GridView ID="gv" runat="server" AutoGenerateColumns="False" DataKeyNames="ID" CellSpacing="1" DataSourceID="ObjectDataSource1" BackColor="#DBD6D0" AllowPaging="True"
                        Width="100%" PageSize="20" CellPadding="0" GridLines="None">
                        <HeaderStyle Height="40px" CssClass="green" BackColor="#f5f5f4" />
                        <RowStyle BackColor="#ffffff" />
                        <FooterStyle BackColor="#f5f5f4" />
                        <Columns>
                            <asp:BoundField DataField="inventTime" ItemStyle-Width="33%" HeaderText="邀請時間" ItemStyle-HorizontalAlign="Center" SortExpression="inventTime" />
                            <asp:BoundField DataField="name" ItemStyle-Width="18%" HeaderText="姓名" SortExpression="name" />
                            <asp:BoundField DataField="email" ItemStyle-Width="35%" HeaderText="電子郵箱" ItemStyle-HorizontalAlign="Center" SortExpression="email" />
                            <asp:TemplateField ItemStyle-Width="14%" HeaderText="註冊情況" ItemStyle-HorizontalAlign="Center" SortExpression="isJoin">
                                <ItemTemplate>
                                    <asp:Label ID="IsEnable1" runat="server" Text="√" Visible='<%# Eval("isJoin") == "1" %>'
                                        Font-Bold="True" Font-Size="14pt" ForeColor="Green"></asp:Label>
                                    <asp:Label ID="IsEnable2" runat="server" Text="×" Visible='<%# Eval("isJoin") != "1" %>'
                                        Font-Bold="True" Font-Size="16pt" ForeColor="Red"></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                        </Columns>
                        <EmptyDataTemplate>
                            没有符合条件的数据！
                        </EmptyDataTemplate>
                    </asp:GridView>
                    <asp:ObjectDataSource ID="ObjectDataSource1" runat="server" OldValuesParameterFormatString="original_{0}" SelectMethod="FindAllBymemberId" TypeName="Jetso.Data.friend">
                        <SelectParameters>
                            <asp:Parameter Name="memberid" Type="Int32" />
                        </SelectParameters>
                    </asp:ObjectDataSource>
                </form>

            </div>
        </div>
    </div>
</body>
</html>
