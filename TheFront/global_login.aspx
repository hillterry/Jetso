<%@ Page Language="C#" AutoEventWireup="true" CodeFile="global_login.aspx.cs" Inherits="Billing_global_login" %>

<meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
<link href="css/base.css" rel="stylesheet" media="all">
<link href="css/framecss.css" rel="stylesheet" media="all">
<link href="css/calendar.css" rel="stylesheet" type="text/css" />

<!--[if lte IE 6]><link href="css/ie6.css" rel="stylesheet" charset="utf-8"><![endif]-->
<link href="css/print.css" rel="stylesheet" media="print">
<form id="frmGlobalLogin" name="frmGlobalLogin" method="post" action="../checkMemberLogin.aspx">
<input type="hidden" id="Type" name="Type"/>
<div class="uWinContentM uWinContentBg1">
  <div class="rBox rBox0Bg1 rBoxTipMsgBox noteMsg">
		
		<div class="rBoxSkin msgContent icoSmall">
			<p class="msg">如還未成為Net Rewards會員，請先註冊。  [  <a href="" class="textBtn" hidefocus="true">註冊會員</a> ]</p>
		</div>
		
	</div>
  <dl class="utab formBox f2Col">    
    <dt class="utr">
			<strong class="utd1 uLabel" for="inputID">帳號:</strong>
			<span class="utd2 uValue"><input type="text" id="Account" name="Account" size="20" onKeyPress="if(MyGetKeyCode(event)==13) GlobalLogin();"/></span>
		</dt>
		<dt class="utr">
			<strong class="utd1 uLabel" for="inputID">密碼:</strong>
			<span class="utd2 uValue"><input type="password" id="Password" name="Password" size="20" onKeyPress="if(MyGetKeyCode(event)==13) {GlobalLogin();return false;}"/>      <a href="member_forget_password.asp" class="textBtn"><i class="ico defaultBtn"></i>找回密碼</a></span>
		</dt>
  </dl>    		
</div>
<div class="uWinContentB btnLib mBtn alignC borderT2 padTB10">                          
  <span class="uCell">
    <a href="javascript:GlobalLogin();" class="btn btnEm1"><strong class="btnL"><i class="ico defaultBtn"></i>登錄</strong><i class="btnR"></i></a>
    <a href="javascript:logonWin.closeWin();" class="btn btn2"><strong class="btnL"><i class="ico cancelBtn"></i>取消</strong><i class="btnR"></i></a>
  </span>
</div>
</form>