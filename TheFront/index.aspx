<%@ Page Language="C#" AutoEventWireup="true" CodeFile="index.aspx.cs" Inherits="TheFront_css_index" %>

<!DOCTYPE html>
<html lang="en" style="-webkit-text-size-adjust: 100%; -ms-text-size-adjust: 100%;">
<head>
    <meta charset="utf-8" />
    <meta name="viewport" content="width=device-width, initial-scale=1, minimum-scale=1, maximum-scale=1, user-scalable=0" />
    <title>拍卖网</title>
    <link href="css/style.css" rel="stylesheet" type="text/css" />
    <link href="css/style_2.css" rel="stylesheet" type="text/css" />
    <link href="css/css2.css" rel="stylesheet" type="text/css" />
    <link href="css/account_executive.css" rel="stylesheet" type="text/css">
    <script src="jsSrc/date.js" type="text/javascript" charset="utf-8"></script>
    <script src="jsSrc/auction.js" type="text/javascript" charset="utf-8"></script>
    <script type="text/javascript" src="js/jquery.min.js"></script>
    <script type="text/javascript" src="js/jquery.form.js" charset="utf-8"></script>
    <script type="text/javascript" src="js/Getauction.js"></script>
    <script type="text/javascript" src="js/tipswindown.js"></script>
    <script type="text/javascript" src="js/otherJs.js"></script>
    <script type="text/javascript" src="js/jquery.easing.min.js"></script>

    
   

</head>

<body>
    <div class="bg" onclick="bgclick()"></div>
    <div class="content222"></div>
    <!--页头-->
    <div class="header1">
        <div class="header2 width1280 margin_auto">
            <div class="nav float_left menu">
                <a href="#">
                    <h2 class="white na">導航</h2>
                </a>
            </div>

            <div class="nav_f float_right">
                <div id="header">
                    <%if (!islogin)
                      { %>
                    <ul class="login fr">
                        <li class="openlogin"><a href="javascript:void(0);">登录</a></li>
                        <li class="reg"><a href="javascript:void(0);">注册</a></li>
                    </ul>
                    <%}
                      else
                      { %>
                    <ul class="login fr">
                        <li style="color: white" onclick="clickAccount('Account_infor.aspx')"><a href="#">我的用户</a></li>
                    </ul>
                    <%} %>
                </div>
                <div class="logo float_left">
                    <img src="images/logo_03.png" class="logoimg" />
                </div>
            </div>
        </div>
    </div>
    <div class="loginmask"></div>
    <div id="loginalert">
        <form id="frmLogin" name="frmLogin" method="post" onsubmit="return login()" action="../FrontView/checkMemberLogin.aspx">
            <div class="pd20 loginpd">
                <h3><i class="closealert fr"></i>
                    <div class="clear12"></div>
                </h3>
                <div class="loginwrap">
                    <div class="loginh">
                        <div class="fl">会员登录</div>
                        <div class="fr">还没有账号<a id="sigup_now" href="javascript:void(0);">立即注册</a></div>
                    </div>
                    <h3><span class="fl">邮箱登录</span><span class="login_warning"></span>
                        <div class="clear12"></div>
                    </h3>
                    <div class="logininput">
                        <input id="Account" name="Account" type="text" class="loginusername" placeholder="邮箱/用户名" />
                        <input name="Password" type="Password"  placeholder="密码" class="loginuserpasswordt" />
                    </div>
                    <div class="loginbtn">
                        <div class="loginsubmit fl">
                            <button id="btnAjaxSubmit" class="btn">登入</button>
                        </div>
                        <div class="fr" style="margin: 26px 0 0 0;">
                            <a href="#">忘记密码?</a>
                        </div>
                        <div class="clear12"></div>
                    </div>
                </div>
            </div>
        </form>

    </div>
    <!--loginalert end-->

    <div id="menu" class="menu">
        <div class="anv_h">
            <div class="anv_t">
                <div class="anvacharacter">導航</div>
                <a href="#" id="back">
                    <img src="images/jianleft_03.png" class="jianleft" /></a>
            </div>
            <%if (islogin)
              { %>
            <anv_cent1 class="anv_cent">
      <ul>
        <li><a href="#">交易記錄</a></li>
        <li><a href="#">賺取bids點</a></li>
        <li><a href="#">勝出拍賣</a></li>
        <li><a href="#">我的 BIDS</a></li>
        <li onclick="clickAccount('Account_infor.aspx')"><a href="#">設置帳戶資訊</a></li>
        <li onclick="clickAccount('Account_ChangeEmail.aspx')"><a href="#">修改郵箱</a></li>
        <li onclick="clickAccount('Account_Key.aspx')"><a href="#">修改密碼</a></li>
        <li><a href="#">分享統計</a></li>
        <li><a href="#">邀請朋友</a></li>
        <li><a href="#">瀏覽推介歷史</a></li>
      </ul>
    </anv_cent1>
            <%}
              else
              { %>
            <fbook class="fbook2">
      <ul>
        <li class="openlogin"><a href="javascript:void(0);"><img src="images/fbook_03.png"/></a></li>
        <li class="reg"><a href="#" ><img src="images/fbook3_06.png"/></a></li>
      </ul>
    </fbook>
            <%} %>
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
    <div id="reg_setp">
        <div class="back_setp">返回</div>
        <div class="blogo"></div>
        <div id="setp_quicklogin">
            <form id="frmRegister" method="post" runat="server" onsubmit="return chcekFrm()" action="../FrontView/checkRegister.ashx">
                <div class="setting_up">
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
                            <input name="IntroduceName" type="text" class="width170" /></li>
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
                </div>
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
    </div>
    <div class="content_fixed">
        <div class="content width1280 left5 margin_auto top60">
            <div id="content">
            </div>
            <div class="clear"></div>
        </div>
    </div>


</body>

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

</html>
