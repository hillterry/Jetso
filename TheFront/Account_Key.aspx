<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Account_Key.aspx.cs" Inherits="TheFront_Account_Key" %>

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
                }
            };

            // ajaxForm
            $("#frmChangePass").ajaxForm(options);

        });
        function ChecPassword() {
            var frm = document.getElementById("frmChangePass");

            if (trim(frm.oldpassword.value) == "") {
                alert("請輸入原密码!");
                frm.oldpassword.focus();
                return false;
            }
            if (trim(frm.newpassword.value) == "") {
                alert("請輸入會員密碼!");
                frm.newpassword.focus();
                return false;
            }
            if (trim(frm.password2.value) == "" || trim(frm.newpassword.value) != trim(frm.password2.value)) {
                alert("輸入密碼不一致!");
                frm.password2.focus();
                return false;
            }

            return true;
        }

    </script>

</head>

<body>
    <div class="bai">
        <div class="vessel">
            <div class="head">修改密码</div>
            <img src="images/gimg.jpg" height="306" border="0" class="gimg" />
            <nav id="navigation">
                <a href="account_executive.html" class="nav-btn">修改密码<span class="arr"></span></a>
                <ul>
                    <li onclick="clickAccount('Account_executive.aspx')"><a href="#">賺取bids點</a></li>
                    <li><a href="account_To_win_the_2.html">勝出拍賣</a></li>
                    <li onclick="clickAccount('Account_Bids.aspx')"><a href="#">我的 BIDS</a></li>
                    <li onclick="clickAccount('Account_infor.aspx')"><a href="#">設置帳戶資訊</a></li>
                    <li onclick="clickAccount('Account_ChangeEmail.aspx')"><a href="#">修改郵箱</a></li>
                    <li onclick="clickAccount('Account_Key.aspx')" class="active"><a href="#">修改密碼</a></li>
                    <li><a href="account_share_7.html">分享統計</a></li>
                    <li onclick="clickAccount('Account_Friends.aspx')"><a href="#">邀请朋友</a></li>
                    <li><a href="account_marketing_9.html">瀏覽推介歷史</a></li>

                </ul>
            </nav>

            <div class="width770 minHeight1">
                <form id="frmChangePass" name="frmChangePass" method="post" onsubmit="return ChecPassword()" action="../FrontView/checkChangePassword.ashx">

                    <div class="setting_up">
                        <ul class="Form folatle">
                            <li class="width80">電郵</li>
                            <li>
                                <input type="text" name="t2" value="<%=Email %>" class="width250 width2" />
                                <input type="hidden" name="ID" value="<%=ID %>" />
                            </li>
                            <div class="clar"></div>
                            <li class="width80">原密码</li>
                            <li>
                                <input type="password" name="oldpassword" value="" class="width250" /><label id="error" style="color: red;"></label>
                            </li>
                            <div class="clar"></div>
                            <li class="width80">新密码</li>
                            <li>
                                <input name="newpassword" type="password" class="width250" /></li>
                            <div class="clar"></div>
                            <li class="width80">确认新密码</li>
                            <li>
                                <input name="password2" type="password" class="width250" /></li>
                            <div class="clar"></div>
                            <li class="width80"></li>
                            <li class="width80">
                                <input type="submit" value="提交" class="ba_red-3" /></li>
                        </ul>
                    </div>
                </form>
            </div>
        </div>
    </div>
</body>
</html>
