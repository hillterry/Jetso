<%@ Page Language="C#" AutoEventWireup="true" CodeFile="placing_ads.aspx.cs" Inherits="Billing_placing_ads" %>
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
        function c() {
            document.getElementById("uWinContentM").style.display = "block";
            countDown(1000 * 5);

        }
    </script>
</head>

<body>
<div class="bai">
<div class="advertisement">
  <div class="advertisement2">
  <div class="floaight" id="countDown1"></div>
  <div class="ali_center clear">
  <img src="<%=imagepath %>" width="207" height="250" class="auto"/>
  </div>
  <p class="line-hei23"><%=Description %></p>

  </div>
</div>
<div class="clar"></div>

</div>
</body>
</html>