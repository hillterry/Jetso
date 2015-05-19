<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Account_executive.aspx.cs" Inherits="TheFront_Account_executive" %>

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
                    if(msg=="sud")
                        clickAccount('Account_executive.aspx');
                }
            };

            // ajaxForm
            $("#frmCheckTime").ajaxForm(options);

        });
    </script>

</head>

<body >
        <div class="vessel" >
            <div class="head">積分與傭金規則如下 </div>
            <img src="images/gimg.jpg" height="306" border="0" class="gimg" />
            <nav id="navigation">
                <a href="account_executive.html" class="nav-btn">賺取bids點<span class="arr"></span></a>
                <ul>
                    <li onclick="clickAccount('Account_executive.aspx')" class="active"><a href="#">賺取bids點</a></li>
                    <li><a href="#">勝出拍賣</a></li>
                    <li onclick="clickAccount('Account_Bids.aspx')"><a href="#">我的 BIDS</a></li>
                    <li onclick="clickAccount('Account_infor.aspx')" class="active"><a href="#">設置帳戶資訊</a></li>
                    <li onclick="clickAccount('Account_ChangeEmail.aspx')"><a href="#">修改郵箱</a></li>
                    <li onclick="clickAccount('Account_Key.aspx')"><a href="#">修改密碼</a></li>
                    <li><a href="account_share_7.html">分享統計</a></li>
                    <li onclick="clickAccount('Account_Friends.aspx')"><a href="#">邀请朋友</a></li>
                    <li><a href="account_marketing_9.html">瀏覽推介歷史</a></li>

                </ul>
            </nav>


            <div class="width770 minHeight1">
                                        <form id="frmCheckTime" name="frmCheckTime" method="post" action="../FrontView/checkinTime.ashx">

                <table width="100%" border="0" cellspacing="1" cellpadding="10" bgcolor="#dbd6d0">
                    <tr bgcolor="#f5f5f4" class="font14">
                        <td width="59%" height="45" align="center"><b class="green">賺取bids项</b></td>
                        <td width="18%" align="center"><b class="green">獲取的bids</b></td>
                        <td width="23%" align="center"><b class="green">確認</b></td>
                    </tr>
                    <tr bgcolor="#FFFFFF">
                        <td height="43" align="center">完成註冊為會員便可獲得積分獎賞</td>
                        <td align="center">3</td>
                        <td align="center"><%if (active == 1)
                                             { %>
                        已完成
                        <%}
                                             else
                                             { %>
                            <a href="ComfirmationLetter.aspx?redirectUrl=MemberInfor.aspx" class="ba_red-4 white finger font13">验证邮箱</a>
                            <%} %>

                        </td>
                    </tr>
                    <tr bgcolor="#FFFFFF">
                        <td height="39" align="center">成功邀請朋友註冊為會員便可獲得積分獎賞</td>
                        <td align="center">0</td>
                        <td align="center">
                            <a href ="#" class ="ba_red-3-3">邀请朋友</a></td>
                    </tr>
                    <tr bgcolor="#FFFFFF">

                            <td height="43" align="center">會員每日首次登入網站簽到便可獲得積分獎賞</td>
                            <td align="center">3</td>
                            <td align="center"><%if (isCheck)
                                                 { %>
                                <input type="submit" value="签到" class="ba_red-3-3" />
                                <%}
                                                 else
                                                 { %>
                        已签到
                        <%} %></td>

                    </tr>
                </table>
                                            
                
                                        </form>

            </div>
            <div class="clar"></div>
        </div>
</body>
</html>
