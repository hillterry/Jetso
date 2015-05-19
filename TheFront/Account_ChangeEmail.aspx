<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Account_ChangeEmail.aspx.cs" Inherits="TheFront_Account_ChangeEmail" %>

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
    <script>
        //Account 异步提交
        $(document).ready(function () {

            var options = {
                success: function (data) {
                    var msg = data;
                    $("#error").text(msg);
                   // clickAccount('Account_Bids.aspx');
                }
            };

            // ajaxForm
            $("#frmChangeEmail").ajaxForm(options);

        });
        function ChecEmail() {
            var frm = document.getElementById("frmChangeEmail");

            if (trim(frm.NewEmail.value) == "") {
                alert("請輸入會員帳號!");
                frm.NewEmail.focus();
                return false;
            }

            if (trim(frm.Password.value) == "") {
                alert("請輸入會員密碼!");
                frm.Password.focus();
                return false;
            }

            return true;
        }

    </script>

</head>

<body>
    <div class="bai">
        <div class="vessel">
            <div class="head">修改郵箱</div>
            <img src="images/gimg.jpg" height="306" border="0" class="gimg" />
            <nav id="navigation">
                <a href="account_executive.html" class="nav-btn">修改郵箱<span class="arr"></span></a>
                <ul>
                    <li onclick="clickAccount('Account_executive.aspx')"><a href="#">賺取bids點</a></li>
                    <li><a href="account_To_win_the_2.html">勝出拍賣</a></li>
                    <li onclick="clickAccount('Account_Bids.aspx')"><a href="#">我的 BIDS</a></li>
                    <li onclick="clickAccount('Account_infor.aspx')" ><a href="#">設置帳戶資訊</a></li>
                    <li onclick="clickAccount('Account_ChangeEmail.aspx')" class="active"><a href="#">修改郵箱</a></li>
                    <li onclick="clickAccount('Account_Key.aspx')"><a href="#">修改密碼</a></li>
                    <li><a href="account_share_7.html">分享統計</a></li>
                    <li onclick="clickAccount('Account_Friends.aspx')"><a href="#">邀请朋友</a></li>
                    <li><a href="account_marketing_9.html">瀏覽推介歷史</a></li>

                </ul>
            </nav>

            <div class="width770 minHeight1">
                <form id="frmChangeEmail" runat="server" name="frmChangeEmail" method="post" onsubmit="return ChecEmail()" action="../FrontView/checkChangeEmail.ashx">
                    <div class="setting_up">
                        <folatbld class="folatle top20"><img src="images/yyx_03.jpg"/></folatbld>
                        <ul class="Form folatle">
                            <li class="width80">当前邮箱：</li>
                            <li>
                                <input type="text" id="Email" name="Email" value="<%=Email %>" class="width250" /><input type="hidden" name="ID" value="<%=ID %>" />
                            </li>
                            <div class="clar"></div>
                            <li class="width80">新邮箱：</li>
                            <li>
                                <input type="text" id="NewEmail" name="NewEmail" value="" class="width250" /></li>
                            <div class="clar"></div>
                            <li class="width80">登录密码：</li>
                            <li>
                                <input type="password" id="Password" name="Password" class="width250" /></li>
                            <li class="clar" style="color: red" id="error"></li>
                            <div class="clar"></div>

                            <li class="width80"></li>
                            <li class="width80">
                                <input type="submit" class="ba_red-3" id="ajaxChangeEmail" value="提交" /></li>
                            <div class="clar"></div>
                        </ul>
                    </div>
                </form>
            </div>
        </div>
    </div>
</body>
</html>
