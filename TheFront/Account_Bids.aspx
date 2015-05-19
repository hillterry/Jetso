<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Account_Bids.aspx.cs" Inherits="TheFront_Account_Bids" %>

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

</head>

<body>
    <div class="bai">
        <div class="vessel">
            <div class="head">我的余额 </div>
            <img src="images/gimg.jpg" height="306" border="0" class="gimg" />
            <nav id="navigation">
                <a href="account_executive.html" class="nav-btn">我的 BIDS<span class="arr"></span></a>
                <ul>
                    <li onclick="clickAccount('Account_executive.aspx')"><a href="#">賺取bids點</a></li>
                    <li><a href="account_To_win_the_2.html">勝出拍賣</a></li>
                    <li onclick="clickAccount('Account_Bids.aspx')" class="active"><a href="#">我的 BIDS</a></li>
                    <li onclick="clickAccount('Account_infor.aspx')" ><a href="#">設置帳戶資訊</a></li>
                    <li onclick="clickAccount('Account_ChangeEmail.aspx')"><a href="#">修改郵箱</a></li>
                    <li onclick="clickAccount('Account_Key.aspx')"><a href="#">修改密碼</a></li>
                    <li><a href="account_share_7.html">分享統計</a></li>
                    <li onclick="clickAccount('Account_Friends.aspx')"><a href="#">邀请朋友</a></li>
                    <li><a href="account_marketing_9.html">瀏覽推介歷史</a></li>

                </ul>
            </nav>

            <div class="width770 minHeight1">
                您当前的帐户可BIDS余额 <span class="rgb"><%=Bids %></span>
            </div>
        </div>
    </div>
</body>
</html>
