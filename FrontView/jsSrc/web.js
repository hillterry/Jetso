var winGalleryFiles;
function openWinSimple(title,w,h,url,className){
  winGalleryFiles = new SmeWindow({title:title,width:w,height:h,isMask:true,isScroll:false,className:className,winmode:'simple'});
  winGalleryFiles.setAjaxContent(url+"?r=" + Math.random(),{
    method: 'get', 
    onComplete:function(){
    }
  });
	winGalleryFiles.show();
}
function openWin(title,w,h,url,className){
  winGalleryFiles = new SmeWindow({title:title,width:w,height:h,isMask:true,isScroll:false,className:className});
  winGalleryFiles.setAjaxContent(url+"?r=" + Math.random(),{
    method: 'get', 
    onComplete:function(){
    }
  });
	winGalleryFiles.show();
}
function openWinFrame(title,w,h,url,className){	
	winGalleryFiles = new SmeWindow({title:title,url:url+"?r=" + Math.random(),width:w,height:h,isMask:true,isScroll:false,className:className});
	winGalleryFiles.show();
}

function testmsg(type){
	alert('aaaaaa');
}

var logonWin;
function openLogonUrl(type){
  title = '會員登錄';
  url = '../../global_login.asp';
  logonWin = new SmeWindow({title:title,width:400,height:255,isMask:true,isScroll:false,className:'uWinLogin'});
  logonWin.setAjaxContent(url,{
    method: 'post', 
    onComplete:function(){
			if(type == 1){
			  document.frmGlobalLogin.Type.value = 1;
			}
    }
  });
  logonWin.show();
}
function GlobalLogin(){
  var frm = document.frmGlobalLogin;
	
	if (trim(frm.Account.value)==""){
	  alert("請輸入會員帳號!");
		frm.Account.focus();
		return;
	}
	
	if (trim(frm.Password.value)==""){
	  alert("請輸入會員密碼!");
		frm.Password.focus();
		return;
	}
	
	$('frmGlobalLogin').request({
    onSuccess: function(transport) {
      var msg = transport.responseText;
      if(msg == 'account_error'){
        alert('您的帳號不正確!');
	    }
	    if(msg == 'pass_error'){
	      alert('您的密碼不正確!');
      }
      if(msg == 'no_confirm_email'){
	      alert('您沒有電郵確認，請電郵確認後再登入網站!');
      }
      if(msg == 'success'){
      window.location = "goods.detail_10.asp";
		   }
    }
  });
}

function MemberLogin(){
  var frm = document.frmMemberLogin;
	if (trim(frm.Account.value)==""){
	  alert("請輸入email或者帳號");
		frm.Account.focus();
	}else if (trim(frm.Password.value)==""){
	  alert("請輸入密碼");
		frm.Password.focus();
	}else{
	  frm.opt.value="login";
	  frm.action = "<%=PageName%>";
	  frm.submit();
	}
}
