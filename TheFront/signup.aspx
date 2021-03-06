﻿<%@ Page Language="C#" AutoEventWireup="true" CodeFile="signup.aspx.cs" Inherits="TheFront_signup" %>
<!DOCTYPE html>
<html lang="en" style="-webkit-text-size-adjust: 100%; -ms-text-size-adjust: 100%;">
<head>
<meta charset="utf-8" />
<meta name="viewport" content="width=device-width, initial-scale=1, minimum-scale=1, maximum-scale=1, user-scalable=0" />
<title>拍卖网</title>
<link href="css/style.css" rel="stylesheet" type="text/css" />
<link href="css/style_2.css" rel="stylesheet" type="text/css" />
<link href="css/css2.css" rel="stylesheet" type="text/css"/>
<link href="css/account_executive.css" rel="stylesheet" type="text/css">
<script src="jsSrc/auction.js" type="text/javascript" charset="utf-8"></script>
    <script type="text/javascript" src="js/jquery.min.js"></script>
    <script type="text/javascript" src="js/jquery.form.js" charset="utf-8"></script>
    <script type="text/javascript" src="js/Getauction.js"></script>
    <script type="text/javascript" src="js/tipswindown.js"></script>
    <script type="text/javascript" src="js/otherJs.js"></script>
    <script type="text/javascript" src="js/jquery.easing.min.js"></script>
</head>
<script type="text/javascript">
    $(function () {

        var scrolltop = 0;
        $('.click').click(function () {
            scrolltop = document.documentElement.scrollTop;
            $(".content222").load('precinct.html');
            $('.bg').fadeIn(200);
            $('.content222').fadeIn(400);
            $('.content_fixed').css("position", "fixed");
        });

        $('.bg').click(function () {
            $('.bg').fadeOut(800);
            $('.content222').fadeOut(800);
            $('.content_fixed').css("position", "");
            //隐藏导航		
            $("#menu").animate({ left: "100%" }, 500, "easeOutQuart", function () {
                $("#menu,#menubutton").hide();
                //隐藏导航end
            })
            //定位滚动条
            document.documentElement.scrollTop = scrolltop;

        });
    });
    $(window).load(function () {
        //alert(document.documentElement.scrollTop);

        //设置和获取一些变量
        var thumbnail = {
            imgIncrease: 100, /* 增加图像像素（变焦） */
            effectDuration: 400, /* 效果的持续时间（变焦和标题） */
            /* 
            获取的图像的宽度和高度。要使用这些
            2件事:
            列表项大小相同
            得到的图像缩放后恢复正常
            */
            imgWidth: $('.thumbnailWrapper ul li').find('img').width(),
            imgHeight: $('.thumbnailWrapper ul li').find('img').height()
        };

        //列表项相同的大小作为图像
        $('.thumbnailWrapper ul li').css({
            'width': thumbnail.imgWidth,
            'height': thumbnail.imgHeight
        });
        var width = document.body.clientWidth;
        if ((1130 <= width && width <= 1300) || (748 <= width && width < 997)) {
            var left = (width - 1000) / 2;
            $('.content222').css({ 'left': left });
        }
        if (748 <= width && width < 997) {
            var left = (width - 760) / 2;
            $('.content222').css({ 'left': left });
        }
        if (width > 1300) {
            var left = (width - 1000) / 2;
            $('.content222').css({ 'left': left });
        }
        if (997 <= width && width <= 1129) {
            var left = (width - 1000) / 2;
            $('.content222').css({ 'left': left });
        }
        if (462 <= width && width <= 747) {
            var left = (width - 470) / 2;
            $('.content222').css({ 'left': left });
        }
        if (300 <= width && width <= 462) {
            var left = (width - 320) / 2;
            $('.content222').css({ 'left': left });
        }

        $(window).resize(function () {
            //alert(width);
            var width = document.body.clientWidth;
            //alert(width);
            if ((1130 < width && width <= 1300) || (748 <= width && width < 997)) {
                //thumbnail.imgWidth=186;
                //alert("高度1: "+width);
                $('.thumbnailWrapper ul li').css({
                    'width': 186,
                    'height': 225
                });
                $('.thumbnailWrapper ul li img').css({
                    'width': 186
                });
                thumbnail.imgHeight = 225;
                thumbnail.imgWidth = 186;
                var left = (width - 1000) / 2;
                $('.content222').css({ 'left': left });
                var Left1 = (width - 1150) / 2;
                $('#menu').css({ 'left': Left1 });
                //alert($('.thumbnailWrapper').width());
                //$('.thumbnailWrapper ul li a img').width(186);
            }
            if (748 <= width && width < 997) {
                var left = (width - 760) / 2;
                $('.content222').css({ 'left': left });
                var Left1 = (width - 767) / 2;
                $('#menu').css({ 'left': Left1 });

            }
            if (width > 1300) {
                //thumbnail.imgWidth=186;
                //alert("高度2: "+width);
                $('.thumbnailWrapper ul li').css({
                    'width': 207,
                    'height': 250
                });
                $('.thumbnailWrapper ul li img').css({
                    'width': 207
                });
                thumbnail.imgHeight = 250;
                thumbnail.imgWidth = 207;
                var Left1 = (width - 1300) / 2;
                var left = (width - 1000) / 2;
                $('.content222').css({ 'left': left });
                var Left1 = (width - 1300) / 2;
                $('#menu').css({ 'left': Left1 });
                //alert($('.thumbnailWrapper').width());
                //$('.thumbnailWrapper ul li a img').width(186);
            }
            if (997 <= width && width <= 1129) {
                //thumbnail.imgWidth=186;
                //alert("高度3: "+width);
                $('.thumbnailWrapper ul li').css({
                    'width': 165,
                    'height': 198
                });
                $('.thumbnailWrapper ul li img').css({
                    'width': 165,
                });
                thumbnail.imgHeight = 198;
                thumbnail.imgWidth = 165;
                var left = (width - 1000) / 2;
                $('.content222').css({ 'left': left });
                var Left1 = (width - 1008) / 2;
                $('#menu').css({ 'left': Left1 });
            }
            if (462 <= width && width <= 747) {
                //thumbnail.imgWidth=186;
                //alert("高度3: "+width);

                $('.thumbnailWrapper ul li').css({
                    'width': 160,
                    'height': 194
                });
                $('.thumbnailWrapper ul li img').css({
                    'width': 160,
                });
                var left = (width - 470) / 2;
                $('.content222').css({ 'left': left });
                var Left1 = (width - 420) / 2;
                $('#menu').css({ 'left': Left1 });
                thumbnail.imgHeight = 194;
                thumbnail.imgWidth = 160;
            }
            if (300 <= width && width <= 462) {
                var left = (width - 320) / 2;
                $('.content222').css({ 'left': left });
                var Left1 = (width - 400) / 2;
                $('#menu').css({ 'left': Left1 });
            }
            //alert("width:"+thumbnail.imgWidth+"--"+"height"+thumbnail.imgHeight);
        });
        //当鼠标移到列表项...
        $('.thumbnailWrapper ul li').hover(function () {
            $(this).find('img').stop().animate({
                /* 变焦效果，提高图像的宽度 */
                width: parseInt(thumbnail.imgWidth) + thumbnail.imgIncrease,
                /* 我们需要改变的左侧和顶部的位置，才能有放大效应，因此我们将它们移动到一个负占据一半的img增加 */
                left: thumbnail.imgIncrease / 2 * (-1),
                top: thumbnail.imgIncrease / 2 * (-1)
            }, {
                "duration": thumbnail.effectDuration,
                "queue": false
            });

            //使用slideDown事件显示的标题
            $(this).find('.caption:not(:animated)').slideDown(thumbnail.effectDuration);

            //当鼠标离开...
        }, function () {

            //发现图像和动画...
            $(this).find('img').animate({
                /* 回原来的尺寸（缩小） */
                width: thumbnail.imgWidth,
                /* 左侧和顶部位置恢复正常 */
                left: 0,
                top: 0

            }, thumbnail.effectDuration);

            //隐藏使用滑块事件的标题
            $(this).find('.caption').slideUp(thumbnail.effectDuration);

        });

    });
    $(document).ready(function () {
        var k = !0;

        $(".loginmask").css("opacity", 0.8);

        if ($.browser.version <= 6) {
            $('#reg_setp1,.loginmask').height($(document).height());
        }

        $(".thirdlogin ul li:odd").css({ marginRight: 0 });

        $(".openlogin").click(function () {
            k && "0px" != $("#loginalert").css("top") && ($("#loginalert").show(), $(".loginmask").fadeIn(500), $("#loginalert").animate({ top: 0 }, 400, "easeOutQuart"))
        });

        $(".loginmask,.closealert").click(function () {
            k && (k = !1, $("#loginalert").animate({ top: -600 }, 400, "easeOutQuart", function () { $("#loginalert").hide(); k = !0 }), $(".loginmask").fadeOut(500))
        });


        $(".menu a").click(function () {
            var width = document.body.clientWidth;
            var Left1 = 0;
            if ((1300 >= width && width >= 1130) || (748 <= width && width < 997)) {
                Left1 = (width - 1145) / 2;
            }
            if (748 <= width && width < 997) {
                Left1 = (width - 760) / 2;
            }
            if (width > 1300) {
                Left1 = (width - 1300) / 2;
                //alert(left);
            }
            if (997 <= width && width <= 1129) {
                Left1 = (width - 1008) / 2;
            }
            if (462 <= width && width <= 747) {
                Left1 = (width - 470) / 2;
            }
            if (300 <= width && width <= 462) {
                Left1 = (width - 320) / 2;
            }
            $("#menu,#menubutton").show();
            $("#menu").animate({ left: Left1 }, 500, "easeOutQuart")
            $('.bg').fadeIn(200);

        });

        $("#back").click(function () {
            $("#menu").animate({ left: "100%" }, 500, "easeOutQuart", function () {
                $("#menu").hide();
            })
            $('.bg').fadeOut(800);
        });
        $("#sigup_now,.reg a").click(function () {
            $("#reg_setp,#setp_quicklogin").show();
            $("#reg_setp").animate({ left: 0 }, 500, "easeOutQuart")
        });

        $(".back_setp").click(function () {
            "block" == $("#setp_quicklogin").css("display") && $("#reg_setp").animate({ left: "100%" }, 500, "easeOutQuart", function () { $("#reg_setp,#setp_quicklogin").hide() })
        });
    });
</script>
<body>
<div class="bg"></div>
<div class="content222"> </div>
<!--页头-->
<div class="header1">
  <div class="header2 width1280 margin_auto">
    <div class="nav float_left menu"> <a href="#">
      <h2 class="white na">導航</h2>
      </a> </div>
 
      <div class="logo float_left" style="float:right; margin-top:10px;"><img src="images/logo_03.png" class="logoimg"/></div>

  </div>
</div>

<div id="menu" class="menu">
  <div class="anv_h">
    <div class="anv_t">
      <div class="anvacharacter">導航</div>
      <a href="#" id="back"><img src="images/jianleft_03.png" class="jianleft"/></a> </div>
    <anv_cent1 class="anv_cent" >
      <ul>
        <li><a href="#">交易記錄</a></li>
        <li><a href="#">賺取bids點</a></li>
        <li><a href="#">勝出拍賣</a></li>
        <li><a href="#">我的 BIDS</a></li>
        <li><a href="#">設置帳戶資訊</a></li>
        <li><a href="#">修改郵箱</a></li>
        <li><a href="#">修改密碼</a></li>
        <li><a href="#">分享統計</a></li>
        <li><a href="#">邀請朋友</a></li>
        <li><a href="#">瀏覽推介歷史</a></li>
      </ul>
    </anv_cent1>
    <fbook class="fbook2" style="display:none">
      <ul>
        <li class="openlogin"><a href="javascript:void(0);"><img src="images/fbook_03.png"/></a></li>
        <li class="reg"><a href="#" ><img src="images/fbook3_06.png"/></a></li>
      </ul>
    </fbook>
    <anv_cent2 class="anv_cent">
      <ul>
        <li><a href="#">即時拍賣</a></li>
        <li><a href="#">新手指南</a></li>
        <li><a href="#">買BIDS</a></li>
        <li><a href="#">常見問題</a></li>
        <li><a href="#">即將推出的拍賣</a></li>
        <li><a href="#">已結束拍賣</a></li>
        <li><a href="#">贏家</a></li>
      </ul>
    </anv_cent2>
  </div>
</div>
</div>
<!--reg_setp end-->

 
<div style="height:70px;"></div>
<div class="content_fixed">
  <div class="content width1280 left5 margin_auto" style=" background-image:url(images/13.jpg); background-repeat:no-repeat; background-position:center; background-color:#e2e2e2; min-height:300px; padding-top:30px; padding-bottom:40px;">

 
  <form id="frmRegister" method="post" runat="server" onsubmit="return chcekFrm()" action="../FrontView/checkRegister.ashx">
                <div class="setting_up wwww500">
                    <h2 style="line-height:50px;">欢 迎 注 册</h2>
                    <ul class="Form folatle">
                        
                        <li class="width80">電郵</li>
                        <li>
                            <input type="text" name="Email" id="email" value="" class="width170" />
                        </li>
                         <div id="error_Emaildiv" style="display:none;">
                            <li class="width80"></li>
                            <p style="text-align: left;color:red;" id="error_Email">
                                
                            </p>
                        </div>
                        <div class="clar"></div>
                        <li class="width80">用戶名 *</li>
                        <li>
                            <input type="text" name="Account" id="user" value="" class="width170" />
                        </li>
                        <div id="error_Accountdiv" style="display:none;">
                            <li class="width80"></li>
                            <p style="text-align: left; color:red;" id="error_Account">
                                
                            </p>
                        </div>
                        <div class="clar"></div>
                        <li class="width80">新密码</li>
                        <li>
                            <input name="password" type="password" class="width170" /></li>
                        <div class="clar"></div>
                        <li class="width80">确认新密码</li>
                        <li>
                            <input name="password2" type="password" class="width170" /></li>
                        <div class="clar"></div>
                        <li class="width80">介绍人</li>
                        <li>
                            <input name="IntroduceName" type="text" class="width170" value="<%=nickName %>"/></li>
                        <div class="clar"></div>
                        <li class="width80"></li>
                        <li class="width80">
                            <input type="submit" value="提交" class="ba_red-3" /></li>
                        <li>
                            <table width="100%" border="0" cellspacing="0" cellpadding="0">
                                <tr>
                                    <td width="10"></td>
                                    <td width="30">
                                        <input type="checkbox" name="facebook" id="facebook" /></td>
                                    <td>
                                        <img src="images/foobk_03.png" /></td>
                                </tr>
                            </table>
                        </li>
                        <div id="error_Authdiv" style="display:none;">
                            <li class="width80"></li>
                            <p style="text-align: left;color:red;" id="error_Auth">
                                
                            </p>
                        </div>
                        <div class="clar"></div>
                    </ul>
                
                <div style="display: none;">
                <div id="simTestContent1" class="simScrollCont">
                    <div class="mainlist">
                        <a href="facebookAuth.aspx" target="_blank">去授权</a>
                        <div class="btnbox">
                        <input type="button" id="confirmTerm1" value="完成" class="ba_red-3-3" onclick="confirmTerm1(1);" />
                        </div>
                    </div>
                </div>
                <!--simTestContent end-->
            </div>
            </form>
            <div class="clear"></div>

            <label>
                <input type="checkbox" name="isread" id="isread" />
            </label>
            我已閱讀並同意
          <label id="isread-text"><span class="red">《Auction用戶註冊協議》</span></label>
            <div style="display: none;">
                <div id="simTestContent" class="simScrollCont">
                    <div class="mainlist">
                        <p class="line-hei">• 免費註冊</p>
                        <p class="line-hei">• 以超低價贏取全新、原廠未拆封的產品</p>
                        <p class="line-hei">• 現在馬上註冊並取得免費試用!!!</p>
                        <p><span class="red">* </span>請留意所有以不實資料註冊或擁有雙重帳戶的用戶均會被封鎖或刪除，而且上述這些帳戶的所有出價均會被視同無效。</p>
                        <p><span class="red">** </span>如我們查證到拍賣是由虛假帳戶所勝出，所有此類拍賣均會重新開始。請於以下方格填寫正確的聯絡資料，並填寫所如我們查證到拍賣是由虛假帳戶所勝出，所有此類拍賣均會重新開始。請於以下方格填寫正確的聯絡資料，並填寫所如我們查證到拍賣是由虛假帳戶所勝出，所有此類拍賣均會重新開始。請於以下方格填寫正確的聯絡資料，並填寫所如我們查證到拍賣是由虛假帳戶所勝出，所有此類拍賣均會重新開始。請於以下方格填寫正確的聯絡資料，並填寫所如我們查證到拍賣是由虛假帳戶所勝出，所有此類拍賣均會重新開始。請於以下方格填寫正確的聯絡資料，並填寫所</p>
                    </div>
                    <div class="btnbox">
                        <input type="button" id="confirmTerm" value="同意協議" class="ba_red-3-3" onclick="confirmTerm(1);" />
                    </div>
                </div>
                <!--simTestContent end-->
            </div>
   </div>
<!--下麵JS是點擊彈出JQ彈出層特效-->
<!--<script type="text/javascript" src="js/jquery.js"></script>-->
<script type="text/javascript" src="js/tipswindown.js"></script>
<script type="text/javascript">
    /*
    *彈出本頁指定ID的內容於窗口
    *id 指定的元素的id
    *title:	window彈出窗的標題
    *width:	窗口的寬,height:窗口的高
    */
    function showTipsWindown(title, id, width, height) {
        tipsWindown(title, "id:" + id, width, height, "true", "", "true", id);
    }

    function confirmTerm(s) {
        parent.closeWindown();
        if (s == 1) {
            parent.document.getElementById("isread").checked = true;
        }
    }

    function confirmTerm1(s) {
        parent.closeWindown();
        if (s == 1) {
            parent.document.getElementById("facebook").checked = true;
        }
    }




    //彈出層調用
    function popTips() {
        showTipsWindown("Auction用戶註冊協議", 'simTestContent', 290, 310);
        $("#isread").attr("checked", false);
    }
    function popTips2() {
        showTipsWindown("facebook授权", 'simTestContent1', 290, 310);

    }

    $(document).ready(function () {

        $("#isread").click(popTips);
        $("#isread-text").click(popTips);
        $("#facebook").click(popTips2);

    });
</script>
</body>
</html>
