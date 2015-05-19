var TopMenuOffsetX=0;
var TopMenuOffsetY=0;
var LeftMenuOffsetX=0;
var LeftMenuOffsetY=0;
var LanguageMenuOffsetX = 0;
var LanguageMenuOffsetY = 0;

function DIY_Browser() {
 d=document;
 this.agent=navigator.userAgent.toLowerCase();
 this.major = parseInt(navigator.appVersion);
 this.dom=(d.getElementById)?1:0; // true for ie6, ns6
 this.ns=(d.layers);
 this.ns4up=(this.ns && this.major >=4);
 this.ns6=(this.dom&&navigator.appName=="Netscape");
 this.op=(this.agent.indexOf('opera')!=-1&&this.major<7);
 this.opera5=(this.agent.indexOf("Opera 5")>-1);
 this.ie=(d.all);
 this.ie4=(d.all&&!this.dom)?1:0;
 this.ie4up=(this.ie && this.major >= 4);
 this.ie5=(d.all&&this.dom);
 this.ie6=(this.agent.indexOf("msie 6")>-1 && this.dom && !this.opera5)?1:0;
 this.win=((this.agent.indexOf("win")!=-1) || (this.agent.indexOf("16bit")!=-1));
 this.mac=(this.agent.indexOf("mac")!=-1);
}

var oBw = new DIY_Browser();

function getH(o) { var h=0; if (oBw.ns) { h=(o.height)? o.height:o.clip.height; return h; } h=(oBw.op)? o.style.pixelHeight:o.offsetHeight; return h; }
function setH(o,h) { if(oBw.ns) {if(o.clip) o.clip.bottom=h;}else if(oBw.op)o.style.pixelHeight=h;else o.style.height=h; }

function getW(o) { var w=0; if(oBw.ns) { w=(o.width)? o.width:o.clip.width; return w; } w=(oBw.op)? o.style.pixelWidth:o.offsetWidth; return w; }
function setW(o,w) { if(oBw.ns) {if(o.clip) o.clip.right=w;}else if(oBw.op)o.style.pixelWidth=w;else o.style.width=w; }

function getX(o) { var x=(oBw.ns)? o.left:(oBw.op)? o.style.pixelLeft:o.offsetLeft; return x;}
function setX(o,x) { (oBw.ns)? o.left=x:(oBw.op)? o.style.pixelLeft=x:o.style.left=x; }

function getY(o) {  var y=(oBw.ns)? o.top:(oBw.op)? o.style.pixelTop:o.offsetTop; return y;}
function setY(o,y) { (oBw.ie||oBw.dom)? o.style.top=y:(oBw.ns)? o.top=y:o.style.pixelTop=y; }

function getPageX(o) { if(oBw.ns) { var x=(o.pageX)? o.pageX:o.x; return x; } else if (oBw.op) {  var x=0; while(eval(o)) { x+=o.stylo.pixelLeft; e=o.offsetParent; } return x; } else { var x=0; while(eval(o)) { x+=o.offsetLeft; o=o.offsetParent; } return x; } }

function getPageY(o) { if(oBw.ns) { var y=(o.pageY)? o.pageY:o.y; return y; } else if (oBw.op) {  var y=0; while(eval(o)) { y+=o.stylo.pixelTop; o=o.offsetParent; } return y; }  else { var y=0; while(eval(o)) { y+=o.offsetTop; o=o.offsetParent; } return y; } }

function mpageX(element){
  var x = 0;
  do{
    if (element.style.position == 'absolute'){
      return x + element.offsetLeft;
    }else{
      x += element.offsetLeft;
      if (element.offsetParent)
        if (element.offsetParent.tagName == 'TABLE')
          if (parseInt(element.offsetParent.border) > 0){
            x += 1;
          }
    }
  }
  while ((element = element.offsetParent));
  return x;
}

// Calculates the absolute page y coordinate of any element
function mpageY(element){
  var y = 0;
  do{
    if (element.style.position == 'absolute'){
      return y + element.offsetTop;
    }else{
      y += element.offsetTop;
      if (element.offsetParent)
        if (element.offsetParent.tagName == 'TABLE')
          if (parseInt(element.offsetParent.border) > 0){
            y += 1;
          }
    }
  }
  while ((element = element.offsetParent));
  return y;
}

function _MyMenuItemOut(){
	 var args=_MyMenuItemOut.arguments;
   _MyShowHideLayers(args[0],args[1],args[2],args[3],args[4],args[5]);
}

function _MyMenuItemOver(){
   var args=_MyMenuItemOver.arguments;
	 _MyShowHideLayers(args[0],args[1],args[2],args[3],args[4],args[5]);
}

function _MyInitDivPosition(){
  //0--src id,1-div id,2-direct,3-offset
  var args=_MyInitDivPosition.arguments;
  var objSrc = getObject(args[0]);
  var obj = getObject(args[1]);
  obj = obj.style;
  if (args[2]=="MAIN_TOP"){
     obj.top = getPageY(objSrc) + objSrc.offsetHeight + TopMenuOffsetY;
     obj.left = getPageX(objSrc) + TopMenuOffsetX;
  }else if (args[2]=="MAIN_LEFT"){
     obj.top = getPageY(objSrc) + LeftMenuOffsetY;
     obj.left = getPageX(objSrc) + objSrc.offsetWidth + LeftMenuOffsetX;
  }else if (args[2]=="LANGUAGE"){
     obj.top = getPageY(objSrc) + objSrc.offsetHeight + LanguageMenuOffsetY;
     obj.left = getPageX(objSrc) + LanguageMenuOffsetX;
  }
}

function _MyShowHideLayers() { //v3.0
  var i,p,v,vt,obj,args=_MyShowHideLayers.arguments;
  i = 0;
	if ((obj=getObject(args[i]))!=null) {
		 v=args[i+2];
		 if (obj.style) { obj=obj.style; vt=(v=='show')?'visible':(v=='hide')?'hidden':v; }
		 obj.display = "block";
		 obj.visibility=vt;
	}
}

function MyOpenWindowPos(url,name,width,height,options){
	//var appVer = parseInt(navigator.appVersion);
	var top = 0;
	var left = 0;
	var srcWidth=screen.width-10;
	var srcHeight=screen.height - 57;
	var other="";
	if (options==1){//Left Top
		other="top=0, left=0, screenX=0, screenY=0,";//Netscape
	}else if (options==2){//Right Top
		other="top=0, left=" + (srcWidth-width) + ", screenX=" + (srcWidth-width) + ", screenY=0,";//Netscape
	}else if (options==0){//Center
		other="";
	}else if (options==3){//Left Buttom
		other="top=" + (srcHeight-height) + ", left=0, screenX=0, screenY=" + (srcHeight-height) + ",";//Netscape
	}else if (options==5){//Right Buttom
		other="top=" + (srcHeight-height) + ", left=" + (srcWidth-width) + ", screenX=" + (srcWidth-width) + ", screenY=" + (srcHeight-height) + ",";//Netscape
	}
	openwindow(url, name,width ,height,other);
}

/**
 * Open window function
 * @param url -- The open object
 * @param name -- The window name
 * @param width -- The window width
 * @param height -- The window height
 * @param options -- The window options
 */
function MyOpenWindow(url,name,width,height,options){
    openwindow(url, name,width ,height,options);
}

function openwindow( url, winName,width,height,otherproperty)
{
  //width,height
  //otherproperty
  xposition=0; yposition=0;
  if ((parseInt(navigator.appVersion) >= 4 )){
		if (width==1){
			width=screen.width - 10;xposition = 0;
		}else{
			xposition = (screen.width - width) / 2;
		}
		if (height==1){
			height=screen.height - 57;yposition = 0;
		}else{
			yposition = (screen.height - height) / 2 - 15;
		}
		if (yposition < 0 ) yposition = 0;
	}
	theproperty= "width=" + width + ", " + "height=" + height + ", ";
	if (otherproperty.toLowerCase().indexOf("screenx")==-1) theproperty += "screenX=" + xposition + ", "; //Netscape
	if (otherproperty.toLowerCase().indexOf("screenY")==-1) theproperty += "screenY=" + yposition + ", "; //Netscape
	if (otherproperty.toLowerCase().indexOf("left")==-1) theproperty += "left=" + xposition + ", "; //IE
	if (otherproperty.toLowerCase().indexOf("top")==-1) theproperty += "top=" + yposition + ", "; //IE

	if (otherproperty.toLowerCase().indexOf("location")==-1) theproperty += "location=0, ";
	if (otherproperty.toLowerCase().indexOf("menubar")==-1) theproperty += "menubar=0, ";
	if (otherproperty.toLowerCase().indexOf("resizable")==-1) theproperty += "resizable=0, ";
	if (otherproperty.toLowerCase().indexOf("scrollbars")==-1) theproperty += "scrollbars=1, ";
	if (otherproperty.toLowerCase().indexOf("status")==-1) theproperty += "status=0, ";
	if (otherproperty.toLowerCase().indexOf("toolbar")==-1) theproperty += "toolbar=0, ";
	if (otherproperty.toLowerCase().indexOf("hotkeys")==-1) theproperty += "hotkeys=0, ";
	theproperty = theproperty + ', ' + otherproperty;
	return window.open( url,winName,theproperty );
}

/*-------------------------------------------------------------*/

function toDate(objYear,objMonth,objDay,dayNum){
  if (objYear.value=='-1' || objMonth.value=='-1'){
	  objMonth.options[0].selected=true;
    objDay.options[0].selected=true;
	  return;
	}
  //with(document.all){
    vYear=parseInt(objYear.options[objYear.selectedIndex].value)
    vMonth=parseInt(objMonth.options[objMonth.selectedIndex].value)
    objDay.length=1;
    for(i=0;i<(new Date(vYear,vMonth,0)).getDate();i++){
      objDay.options[objDay.length++].value=objDay.length-1;
			objDay.options[objDay.length-1].text=objDay.length-1;
		}
		if (dayNum>0){
		  objDay.options[dayNum].selected=true;
		}
  //}
}

/**
*** 校验字符串是否为日期型(yyyy-MM-dd)
*** 输入参数: 字符串
*** 返回值true: 日期型字符串
*** 返回值false:日期格式不正确
**/
function isDate(str){
  if(trim(str) == "") return false;
  var pattern = /^((\d{4})|(\d{2}))-(\d{1,2})-(\d{1,2})$/g;
  if(!pattern.test(str))
    return false;
  var arrDate = str.split("-");
  //if(parseInt(arrDate[0],10) < 100) arrDate[0] = 1900 + parseInt(arrDate[0],10) + "";
  if(parseInt(arrDate[0],10) < 1900)
    return false;
  var date = new Date(arrDate[0],(parseInt(arrDate[1],10)-1)+"", arrDate[2]);
  if( date.getMonth() == (parseInt(arrDate[1],10)-1)+"" && date.getDate() == arrDate[2])
	return true;
  else
	return false;
}
function GetCookieVal(offset){
  //获得Cookie解码后的值
	var endstr = document.cookie.indexOf (";", offset);
	if (endstr == -1)
		endstr = document.cookie.length;
	return unescape(document.cookie.substring(offset, endstr));
}

function SetCookie(name, value){
	//设定Cookie值
	var expdate = new Date();
	var argv = SetCookie.arguments;
	var argc = SetCookie.arguments.length;
	var expires = (argc > 2) ? argv[2] : null;
	var path = (argc > 3) ? argv[3] : null;
	var domain = (argc > 4) ? argv[4] : null;
	var secure = (argc > 5) ? argv[5] : false;
	if(expires!=null) expdate.setTime(expdate.getTime() + ( expires * 1000 ));
	document.cookie = name + "=" + escape (value) +((expires == null) ? "" : ("; expires="+ expdate.toGMTString()))
	+((path == null) ? "" : ("; path=" + path)) +((domain == null) ? "" : ("; domain=" + domain))
	+((secure == true) ? "; secure" : "");
}

function DelCookie(name){
	//删除Cookie
	var exp = new Date();
	exp.setTime (exp.getTime() - 1);
	var cval = GetCookie (name);
	document.cookie = name + "=" + cval + "; expires="+ exp.toGMTString();
}

function GetCookie(name){
	//获得Cookie的原始值
	var arg = name + "=";
	var alen = arg.length;
	var clen = document.cookie.length;
	var i = 0;
	while (i < clen)
	{
	var j = i + alen;
	if (document.cookie.substring(i, j) == arg)
	return GetCookieVal (j);
	i = document.cookie.indexOf(" ", i) + 1;
	if (i == 0) break;
	}
	return null;
}

//sme js
function getObject(n, d) { //v4.01
	var p,i,x; if(!d) d=document; if((p=n.indexOf("?"))>0&&parent.frames.length) {
	d=parent.frames[n.substring(p+1)].document; n=n.substring(0,p);}
	if(!(x=d[n])&&d.all) x=d.all[n]; for (i=0;!x&&i<d.forms.length;i++) x=d.forms[i][n];
	for(i=0;!x&&d.layers&&i<d.layers.length;i++) x=getObject(n,d.layers[i].document);
	if(!x && d.getElementById) x=d.getElementById(n); return x;
}

function convertBytesToSize(bytes) {
  var unit = "B";
  var k = bytes / 1024.0;
  var m = k / 1024.0;
  var g = m / 1024.0;
  var s = "0";
  if (g > 1.0) {
    unit = "Gb";
    s = MyStr2Float(g, 3, "str");
  } else if (m > 1.0) {
    unit = "Mb";
    s = MyStr2Float(m, 3, "str");
  } else if (k > 1.0) {
    unit = "Kb";
    s = MyStr2Float(k, 3, "str");
  } else {
    unit = "Bytes";
    s = MyStr2Float(bytes, 3, "str");
  }
  return s + unit;
}

//清除字符串左右空格
function trim(str) {
	regExp1 = /^ */;
	regExp2 = / *$/;
	return str.replace(regExp1,'').replace(regExp2,'');
}

//关闭当前窗口
function MyWindowClose(){
    opener = null;
    window.close();
}

//获取键盘keyCode
function MyGetKeyCode(e){
	var code;
	if (!e) var e = window.event;
	if (e.keyCode){
    code = e.keyCode;
	}else if (e.which){
    code = e.which;
	}
  return code;
}

//校验是否是数字（带小数）-2.36onkeypress
function MyCheckNum(obj,e)
{
  var code = MyGetKeyCode(e);
  if ((code<45 || code>57 || code==47) && code!=45 && code!=9 && code!=8) return false;
  if(code==46 && obj.value.indexOf(".")>-1) return false;
  return true;
}

//校验是否是整数 325onkeypress
function MyCheckInt(obj,e)
{
  var code = MyGetKeyCode(e);
  if ((code<48 || code>57) && code!=45 && code!=9 && code!=8) return false;
  return true;
}

// onkeypress
function CheckNum(obj)
{
	if ((window.event.keyCode<45 || window.event.keyCode>57 || window.event.keyCode==47) && window.event.keyCode!=45 && window.event.keyCode!=9)  window.event.returnValue=false;
	if( window.event.keyCode==46 && obj.value.indexOf(".")>-1) window.event.returnValue=false;
}

// onkeypress
function CheckInt(obj)
{
	if ((window.event.keyCode<48 || window.event.keyCode>57) && window.event.keyCode!=45 && window.event.keyCode!=9) window.event.returnValue=false;
}

//获取焦点
function MyOnfocusSelect(obj){
	if (obj.type=="text"){
		obj.select();
	}
}

//校验是否是EMAIL
function isEmail(mail) { 
  return(new RegExp(/^\w+((-\w+)|(\.\w+))*\@[A-Za-z0-9]+((\.|-)[A-Za-z0-9]+)*\.[A-Za-z0-9]+$/).test(mail)); 
} 
//返回链接，绝对路径的文件名称
//c:\\a\\bbb.jpg return bbb.jpg
function getFullName(path){
  var tmp = path;
	var pos = -1;
	pos = tmp.lastIndexOf("\\");
	if (pos==-1){
	  pos = tmp.lastIndexOf("/");
	}
	if (pos==-1){
	  return path;
	}else{
	  return tmp.substring(pos+1);
	}
}

//返回文件名称
//c:\\a\\bbb.jpg return bbb
function getName(path){
  var tmp = path;
	var pos = -1;
	var endPos = -1;
	pos = tmp.lastIndexOf("\\");
	if (pos==-1){
	  pos = tmp.lastIndexOf("/");
	}
	endPos = tmp.indexOf(".",pos);
	if (endPos==-1){
	  return tmp.substring(pos+1);
	}else{
	  return tmp.substring(pos+1,endPos);
	}
}

/**
 返回文件扩展名 
 Get file's extends
 */
function getFileExt(path){
  var tmp = path;
  tmp = tmp.substring(tmp.lastIndexOf(".")+1);
  return tmp.toUpperCase();
}

/**
 检查文件是否符合扩展名列表 
 Check file's extends name in extList
 */
function MyCheckExt(path,extList){
  var ext = getFileExt(path);
  extList = "," + extList.toUpperCase() + ",";
  var cExt = extList.indexOf("," + ext + ",");
  if (ext == "") return -1;
  if (cExt==-1){
    return 0;
  }else{
    return 1;
  }
}

function getFullPath(name){
	var tmp = name;
	var pos = -1;
	pos = tmp.lastIndexOf("\\");
	if (pos==-1){
		pos = tmp.lastIndexOf("/");
	}
	if (pos==-1){
		return "";
	}else{
		return tmp.substring(0,pos+1);
	}
}

/**
 * Clear the object in the form
 * @param obj -- The object in the form
 */
function MyClearObject(obj){
  obj.value = "";
}

//格式化或者转换数字
function MyStr2Float(as_str,ai_digit,as_type)
{
   var fdb_tmp = 0;
   var fi_digit = 0;
   var fs_digit = "1";
   var fs_str = "" + as_str;
   var fs_tmp1 = "";
   var fs_tmp2 = "";
   var fi_pos = 0;
   var fi_len = 0;
   fdb_tmp = parseFloat(isNaN(parseFloat(fs_str))?0:fs_str);

   switch (true)
   {
      case (ai_digit==null)://
         fdb_tmp = fdb_tmp;
         break;
      case (ai_digit==0)://
         fdb_tmp = Math.round(fdb_tmp);
         break;
      case (ai_digit>0)://
         for (var i=0;i<ai_digit;i++) fs_digit +="0";
         fi_digit = parseInt(fs_digit);
         fdb_tmp = Math.round(fdb_tmp * fi_digit) / fi_digit;
         if (as_type=="str")
         {
            fs_tmp1 = fdb_tmp.toString();
            fs_tmp1 +=((fs_tmp1.indexOf(".")!=-1)?"":".") + fs_digit.substr(1);
            fi_pos = fs_tmp1.indexOf(".") + 1 + ai_digit;
            fdb_tmp = fs_tmp1.substr(0,fi_pos);
         }
         break;
   }
   return fdb_tmp;
}

//返回传入的表单类型，text,textarea,radio,checkbox,select
function checkFormType(obj){
  if (obj.length){
    return obj[0].type;
  }else{
    return obj.type;
  }
}

//清除多选框，排除index索引的检查框
function ClearSelected(obj,index){
  if (obj != null){
    if(obj.length==null){
		  if (index==-1) obj.checked = false;
    }else{
      for (i = 0 ; i< obj.length ; i++){
			  if (index!=-1 && index==i){
				  obj[i].checked = true;
				}else{
          obj[i].checked = false;
				}
      }
    }
  }
}

//全选检查框
function SelectedAll(obj){
  if (obj != null){
    if(obj.length==null){
		  obj.checked = true;
    }else{
      for (i = 0 ; i< obj.length ; i++){
			  obj[i].checked = true;
      }
    }
  }
}

//反相选择检查框
function InverseSelected(obj){
  if (obj != null){
    if(obj.length==null){
		  obj.checked = !obj.checked;
    }else{
      for (i = 0 ; i< obj.length ; i++){
			  obj[i].checked = !obj[i].checked;
      }
    }
  }
}

//定位焦点到检查框
function FocusOptions(obj){
	if (obj != null){
		if(obj.length==null){
			obj.focus();
		}else{
			obj[0].focus();
		}
	}	
}

//检查检查框是否选中
function CheckIsSelected(obj){
	var ischeck = false;
	if (obj != null){
		if(obj.length==null){
			if (obj.checked == true) ischeck = true;
		}else{
			for (var i = 0 ; i< obj.length ; i++){
				if (obj[i].checked == true){ischeck = true;break;}
			}
		}
	}
	return ischeck;
}

//
function SetSelected(obj,index){
  if (obj!=null){
    if (obj.length==null){
      if (index==0) obj.checked = true;
    }else{
      obj[index].checked = true;
    }
  }
}

function getSelectedValue(obj){
	var v = "";
	if (obj != null){
		if(obj.length==null){
			if (obj.checked == true) v = obj.value;
		}else{
			for (i = 0 ; i< obj.length ; i++){
				if (obj[i].checked == true){v = obj[i].value;break;}
			}
		}
	}
	return v;
}

function OperateSelect(sel,ddl){
	var selectType;
	var obj=sel;
	try{
		selectType = ddl.value;
		ddl.options[0].selected=true;
	}catch(e){
		selectType = ddl;
	}
	if(obj){
		if(obj.length==null){
			if (!obj.disabled){
				switch (selectType){
					case "all":obj.checked=true;break;
					case "invert":obj.checked=!obj.checked;break;
					case "none":obj.checked=false;break;
				}
			}
		}else{
			for (var i = 0 ; i< obj.length ; i++){
				if (!obj[i].disabled){
					switch (selectType){
						case "all":obj[i].checked=true;break;
						case "invert":obj[i].checked=!obj[i].checked;break;
						case "none":obj[i].checked=false;break;
					}
			  }
			}
		}
	}
}

function OperateSelectCustom(frmName,selPrefix,stuffix,ddl){
	var selectType;
	var obj=stuffix;
	var objSel = null;
	try{
		selectType = ddl.value;
		ddl.options[0].selected=true;
	}catch(e){
		selectType = ddl;
	}
	if(obj){
		if(obj.length==null){
			if (!obj.disabled){
				objSel = eval("document." + frmName + "." + selPrefix + obj.value);
				switch (selectType){
					case "all":objSel.checked=true;break;
					case "invert":objSel.checked=!objSel.checked;break;
					case "none":objSel.checked=false;break;
				}
			}
		}else{
			for (var i = 0 ; i< obj.length ; i++){
				if (!obj[i].disabled){
					objSel = eval("document." + frmName + "." + selPrefix + obj[i].value);

					switch (selectType){
						case "all":objSel.checked=true;break;
						case "invert":objSel.checked=!objSel.checked;break;
						case "none":objSel.checked=false;break;
					}
			  }
			}
		}
	}
}

//按值选中下拉框中某个值
function SetSelectItem(ddl,v){
	for (var i = 0 ; i<ddl.options.length;i++){
		if (ddl.options[i].value==v){
			ddl.options[i].selected = true;
			break;
		}
	}
}

//检查文字是否超出长度限制
function checkLength(obj,num){
	var inputLength=obj.replace(/[^\x00-\xff]/g,'**').length;
	if (inputLength>num){
	  return true;
	}else{
	  return false;
	}
}

function getPath(obj){
	if(obj){
		if (window.navigator.userAgent.indexOf("MSIE")>=1){
			obj.select();
			return document.selection.createRange().text;
		}else if(window.navigator.userAgent.indexOf("Firefox")>=1){
			if(obj.files){
			  return obj.files.item(0).getAsDatUrl();
			}
			return obj.value;
		}
		return obj.value;
	}
}

function PreviewPic(path){
	path = getPath(path);
  if (path == ""){
		alert("Please select a image!");
  }else{
		window.open("previewImage.asp?img=" + path,"preImg","");
  }
}

/*function PreviewPic(path){
  if (path == ""){
		alert("Please select a pic");
  }else{
		window.open("previewImage.asp?img=" + path,"preImg","");
  }
}*/

function AddToFavorite(title,url,desc)
{
	if ((typeof window.sidebar == 'object') && (typeof window.sidebar.addPanel == 'function'))//Gecko
	{
		window.sidebar.addPanel(title,url,desc);
	}
	else//IE
	{
		window.external.AddFavorite(url,title);
	}
}

function isRegisterUserName(s)
{
	var patrn=/^[a-zA-Z]{1}([a-zA-Z0-9_]){5,19}$/;
	if (!patrn.exec(s)) return false
	return true
}

function high(which2){
  theobject=which2
  highlighting=setInterval("highlightit(theobject)",50)
}

function low(which2){
  clearInterval(highlighting)
  which2.filters.alpha.opacity=50
}

function highlightit(cur2){
  if (cur2.filters.alpha.opacity<100)
    cur2.filters.alpha.opacity+=5
  else if (window.highlighting)
    clearInterval(highlighting)
}

function hidDiv(o){
	o.style.display = "none";	
}

function showDiv(o){
	o.style.display = "";
}

/**
 * Tempate used
 */
function getRadio(w,h,mw,mh){
	var rw = mw/w;
	var rh = mh/h;
	var r = Math.min(rw,rh);
	if ((mw ==0 && mh == 0) || r>1){
		r = 1;
	}else if (mw == 0){
		r = rh<1?rh:1;
	}else if (mh == 0){
		r = rw<1?rw:1;
	}
	//Debug("(" + w + ":" + h + ")-(" + mw + ":" + mh + ")" + r);
	w = w*r;
	h = h*r;
	return [w,h];
}
/**
 自动按比例压缩图片
 */
function AutoResizeImage(maxWidth,maxHeight,objImg){
	if (typeof(objImg)=='string'){
		objImg = $(objImg);
	}
	if (objImg.src.indexOf("blank.gif")!=-1) return;
	var img = new Image();
	img.onload = function(){
		this.onload = function(){}
		var wh = getRadio(img.width,img.height,maxWidth,maxHeight);
		objImg.width = wh[0];
		objImg.height = wh[1];
		AlphaImageLoader(objImg);
	}
	img.src = objImg.src;
}

function AutoResizeImage1(maxWidth,maxHeight,objImgTmp){
	var hRatio;
	var wRatio;
	var Ratio = 1;
	var isKernel = true;
	var objImg = getObject(objImgTmp);
	if (objImg==null) {isKernel = false};
	if (isKernel && objImg.width==0) {isKernel = false};
	var width = 0;
	var height = 0;
	if (isKernel){
		var imgTmp = new Image();
		imgTmp.src = objImg.src;
		width = imgTmp.width;
		height = imgTmp.height;
		if (width==0){
			var timer=window.setTimeout("AutoResizeImage(" + maxWidth + "," + maxHeight + ",'" + objImgTmp + "')",500);
		}else{
			wRatio = maxWidth / width;
			hRatio = maxHeight / height;
			//alert(wRatio + "--" + hRatio);
			if (maxWidth==0){//
					if (hRatio<1) Ratio = hRatio;
			}else if (maxHeight==0){
					if (wRatio<1) Ratio = wRatio;
			}else if (wRatio<1 || hRatio<1){
					Ratio = (wRatio<=hRatio?wRatio:hRatio);
			}
			if (Ratio<1){
			 objImg.width = width * Ratio;
			 objImg.height = height * Ratio;
			}else{
			 objImg.width = width;
			 objImg.height = height;
			}
		}
	}else{
		var timer=window.setTimeout("AutoResizeImage(" + maxWidth + "," + maxHeight + ",'" + objImgTmp + "')",500);
	}
}

function AlphaImageLoader(img){
  if (is_ie6down){
		var imgName = img.src.toUpperCase();
		if (imgName.substring(imgName.length-3, imgName.length) == "PNG"){
			var imgID = (img.id) ? "id='" + img.id + "' " : "";
			var imgClass = (img.className) ? "class='" + img.className + " ' " : " ";
			var imgTitle = (img.title) ? "title='" + img.title + "' " : "title='" + img.alt + "' ";
			var imgStyle = "display:inline-block;" + img.style.cssText;
			if (img.align == "left") imgStyle = "float:left;" + imgStyle;
			if (img.align == "right") imgStyle = "float:right;" + imgStyle;
			if (img.parentElement.href) imgStyle = "cursor:hand;" + imgStyle; 
			
			var strNewHTML = "<img src=\"../images/blank.gif\" " + imgID + imgClass + imgTitle
			+ " style=\"" + "width:" + img.width + "px; height:" + img.height + "px;" + imgStyle + ";"
			+ "filter:progid:DXImageTransform.Microsoft.AlphaImageLoader"
			+ "(src=\'" + img.src + "\', sizingMethod='scale');\">";
			img.outerHTML = strNewHTML;
		}
	}
}

function getBigImage(name){
  if (name=="") return "";
  var ext = getFileExt(name);
  if (ext=="GIF" || ext=="PNG"){
    return name;
  }else if (ext=="JPG" || ext=="JPEG"){
    return name.replace("-s.","-b.");
  }else{
    return name;
  }
}

function getSmallImage(name){
  if (name=="") return "";
  var ext = getFileExt(name);
  if (ext=="GIF" || ext=="PNG"){
    return name;
  }else if (ext=="JPG" || ext=="JPEG"){
    return name.replace("-b.","-s.");
  }else{
    return name;
  }
}

function createWebEditor(formName,formNameValue,toolbarRows,shopAdminId,languageId,autosubmit){
	var wp = new WebPage();
	return wp.createWebEditor(formName,formNameValue,toolbarRows,shopAdminId,languageId,autosubmit);
}

function writeWebEditor(formName,formNameValue,toolbarRows,shopAdminId,languageId,autosubmit){
	document.write(createWebEditor(formName,formNameValue,toolbarRows,shopAdminId,languageId,autosubmit));
}

function writeModule(){
	document.write(createModule.apply(this,arguments));
}

function createModule(){
	var imageFilesSelector = new ImageFilesSelector(_WebPageInfo);
  var args = $A(arguments);
  var path = args[0];
  var name = args[1];
  var w = args[2];
  var h = args[3];
  var isPreviewImage = 0;
  if (args.length>4){
  	isPreviewImage = args[4];
  }
  var href = "";
  if (args.length>5){
    href = args[5];
  }
  var target = "";
  if (args.length>6){
 	  target = args[6];
  }
  var prop = "";
  if (args.length>7){
 	  prop = args[7];
  }
  var noiconpic = "";
  if (args.length>8){
    noiconpic = args[8];
  }
  if (name==""){
    return createImage("","",0,0,0,href,target,prop);
  }else if (imageFilesSelector.CheckExt(name,imageFilesSelector.WebPageInfo.ImageInfo.exts)!=0){
    if (path=='' && name.indexOf('/')==-1) {
    	path = _WebPageInfo.UserPath + "gallery/";
    }else if (path!=''){
    	//path += "gallery/";
    }
  	return createImage(path,name,w,h,isPreviewImage,href,target,prop);
  }else if(imageFilesSelector.CheckExt(name,imageFilesSelector.WebPageInfo.DigitalMediaInfo.exts)!=0){
    if (path=='' && name.indexOf('/')==-1) {
    	path = _WebPageInfo.UserPath + "files/";
    }else if (path!=''){
    	path += "files/";
    }
  	return createMdeia(path,name,w,h,href,target,prop,noiconpic);
  }else if(imageFilesSelector.CheckExt(name,imageFilesSelector.WebPageInfo.FlashInfo.exts)!=0){
    if (path=='' && name.indexOf('/')==-1) {
    	path = _WebPageInfo.UserPath + "files/";
    }else if (path!=''){
    	path += "files/";
    }
  	return createFlash(path,name,w,h,href,target,prop,noiconpic);
  }else if (imageFilesSelector.CheckExt(name,imageFilesSelector.WebPageInfo.ThreeDInfo.exts)!=0){
  	if (path=='' && name.indexOf('/')==-1) {
    	path = _WebPageInfo.UserPath + "files/";
    }else if (path!=''){
    	path += "files/";
    }
    return create3D(path,name);
  }
}

function writeImage(path,name,w,h,isPreviewImage,href,target,prop){
	if (!isPreviewImage) isPreviewImage = 0;
	if (!href) href = "";
	if (!target) target = "";
	if (!prop) prop = "";
  document.write(createImage(path,name,w,h,isPreviewImage,href,target,prop));
}
function createImage(path,name,w,h,isPreviewImage,href,target,prop){
  var c = "";
  if (!href) href="";
  if (!target) target="";
  if (!prop) prop = "";
  //if (name=="") return "";
  var bi = getBigImage(name);
  var maxw = 450;
  var maxh = 450;
  if (href!=""){
    c +='<a href="' + href + '" target="' + target + '">';
  }
  if (name==""){
    c +='<i class="defaultPic"></i>';
  }else{ 
	  c +='<img width="0" height="0" src="' + path + name + '" \
	       onload="AutoResizeImage(' + w + ',' + h + ',this)" ' + prop + ' ';
	  c +='onerror="loadImageError(this);" ';
	  if (isPreviewImage==1){
	    c +=' onmouseover="SmePreviewBigImage.mouseenter(event,\'' + path + bi + '\',' + maxw + ',' + maxh + ')" ';
	  }
	  c +='/>';
  }
  if (href!=""){
    c +="</a>";
  }
  return c;
}

function loadImageError(o){
	o.onload=function(){};
	if ($(o.parentNode)){
		//$(o.parentNode).addClassName("noPic");
	}
	o.outerHTML = '<i class="defaultPic"></i>';	
}

var SmePreviewBigImage = {
	initialize: false,
	id:'previewimagediv',
	imageId:'previewBigImageUid',
	zoommaskdiv:'previewzoommaskid',
	zoomdiv:'previewzoomdivid',
	viewimg:'previewviewimageid',
	className:'previewImg',
	imageSrc: null,
	imageContainer:null,
	image:null,
	loadingimg:null,
	imageLoadEvent:null,
	isimage:true,
	
	mouseEvent: null,
	zoomEvent: null,
	x:0,
  y:0,
  width:450,
  height:450,
	currentEffect:null,
	ps:null,
	scrollsize:null,
	documentbody:null,
	init: function(){
		this.documentbody = document.body;
	  this.imageContainer = $(document.createElement("div"));
		this.imageContainer.writeAttribute({"id":this.id,"class":this.className});
	  this.imageContainer.setStyle({display:'none',background: '#fff',padding: '1px',border: '#666666 solid 5px',position: 'absolute', zIndex: 10000});

	  this.documentbody.insertBefore(this.imageContainer,this.documentbody.firstChild);

		this.mouseEvent = this.mouseleave.bindAsEventListener(this);		
		Event.observe(this.imageContainer,"mouseout",this.mouseEvent);
		
		this.clickEvent = this.documentClick.bindAsEventListener(this);
		Event.observe(document,"click",this.clickEvent);
		
		this.imageLoadEvent = this.imageload.bindAsEventListener(this);
		
		this.loadingimg = $(document.createElement("img"));
    this.loadingimg.writeAttribute({"id":"previewloadingimg","class":"img","src":IMPORTJS.path + 'loading.gif'});
		//this.zoomEvent = this.zoom.bindAsEventListener(this);
		this.initialize = true;
  },
	zoom:function(event){
  	return ;
		if (!this.image) return ;
		var orgradiox = 1/parseFloat(this.image.readAttribute("radio"));
		if (orgradiox<1) return ;
		if (this.imageContainer.getOpacity()<1.0) return ;
		var multiple = 1.0;
		var orgradio = orgradiox*multiple;
		var viewWidth = 300;
		var viewHeight = 300;
		var maskWidth = viewWidth/orgradio;
		var maskHeight = viewHeight/orgradio;
		var container = this.imageContainer;
		var mask = $(this.zoommaskdiv);
		var radio = orgradio;
		if (!mask){
			mask = $(document.createElement("div"));
			mask.writeAttribute({"id":this.zoommaskdiv,"class":""});
			mask.setStyle({position: 'absolute', zIndex: 10005,opacity:0.2,width:maskWidth+'px',height:maskHeight+'px',background:'#ffffff'});	
			container.appendChild(mask);
			Event.observe(mask,"mousemove",this.zoomEvent);
		}
		var scrollsize = document.viewport.getScrollOffsets();
		var pos = Element.viewportOffset(container);
		var x = event.clientX + scrollsize.left;
		var y = event.clientY + scrollsize.top;
		var borderWidth = this.imageContainer.getStyle('border-left-width').replace('px','');
		var offset = 2*borderWidth+2;
		var crop = new Object();
		if (x - this.x < maskWidth/2){
			x = this.x;
			crop.x = 0;
		}else if (x > this.x + container.getWidth()-maskWidth/2-offset){
			x = this.x + container.getWidth()-maskWidth-offset;
			crop.x = container.getWidth()-maskWidth-offset;
		}else{
			x = x - maskWidth / 2;
			crop.x = x - this.x;
		}
		if (y - this.y < maskHeight/2){
			y = this.y;
			crop.y = 0;
		}else if (y > this.y + container.getHeight()-maskHeight/2-offset){
			y = this.y + container.getHeight() - maskHeight-offset;
			crop.y = container.getHeight() - maskHeight-offset;
		}else{
			y = y - maskHeight / 2;
			crop.y = y - this.y;
		}
		x = x - this.x;
		y = y - this.y;
		mask.setStyle({top:y+'px',left:x+'px'});
		
		var zoomdiv = $(this.zoomdiv);
		var viewimg = $(this.viewimg);
		if (!zoomdiv){
		  zoomdiv = $(document.createElement("div"));
			zoomdiv.writeAttribute({"id":this.zoomdiv});
			zoomdiv.setStyle({position: 'absolute', zIndex: 10005,overflow:'hidden',border: '#666666 solid 5px',width:viewWidth + 'px',height:viewHeight+'px',background:'#ffffff'});
			
			viewimg = $(document.createElement("img"));
	  	viewimg.writeAttribute({"id":this.viewimg,"class":"img","radio":1});
			//viewimg.setStyle({display: 'block',width:this.image.width * orgradio+'px',height:this.image.height * orgradio+'px'});
			zoomdiv.appendChild(viewimg);
			this.documentbody.appendChild(zoomdiv);
		}
		//var r = getRadio(this.image.width,this.image.height,viewWidth,viewHeight);
		//zoomdiv.setStyle({width:r.width + 'px',height:r.height+'px'});
		viewimg.writeAttribute({"src":this.image.src});
		viewimg.setStyle({display: 'block',width:this.image.width * orgradio+'px',height:this.image.height * orgradio+'px'});
		$(this.zoomdiv).show();
		zoomdiv.setStyle({top:this.y +'px',left:this.x + container.getWidth() +'px'});
		if (this.x+container.getWidth() + viewWidth > this.scrollsize.left + this.ps[0] && this.x - viewWidth - offset > 0){
			zoomdiv.setStyle({left:this.x - viewWidth - offset+2 +'px'});
		}
		
		viewimg.setStyle({"margin":(-crop.y * radio)+'px 0px 0px ' + (-crop.x * radio)+'px'});
		//viewimg.setStyle({"margin-top":(-crop.y * radio)+'px','margin-left':(-crop.x * radio)+'px'});
		//Debug(viewimg.getStyle("margin"));
		Event.observe($(this.zoomdiv),"mouseout",this.mouseEvent);
		//Debug("margin: " + viewimg.getStyle("margin-top") + "x" + viewimg.getStyle("margin-left"));
	},
	documentClick: function(event){
		var e = event.srcElement || event.target;
		if (!$(e).descendantOf(this.id) && e!=this.imageSrc){
			$(this.id).hide();
		}
	},
  imageload: function(event){
		this.imageContainer.hide();
  	var e = event.srcElement || event.target;
  	var wh = getRadio(e.width,e.height,this.width,this.height);
  	Event.stopObserving(this.image,"load",this.imageLoadEvent);
  	this.image.writeAttribute({"radio":wh.radio});
		this.image.setStyle({display: 'block',width:wh[0]+'px',height:wh[1]+'px'});
		this.imageContainer.update('');
		this.imageContainer.appendChild(this.image);
		var borderWidth = this.imageContainer.getStyle('border-left-width').replace('px','');
		var offset = 2*borderWidth;
		if (this.x + wh[0]+offset>this.ps[0]){
			this.x = this.x-wh[0]-offset;
		}
		if (this.x < 0) this.x = 0;
		if (this.y + wh[1]+offset>this.ps[1]){
			this.y = this.y-wh[1]-offset;
		}
		if (this.y <0) this.y = 0;
  	this.imageContainer.setStyle({top:this.y+'px',left:this.x+'px'});
  	this.currentEffect = Effect.Appear(this.imageContainer);
		//Event.observe(this.imageContainer,"mousemove",this.zoomEvent);
  },
	mouseenter: function(event,src,w,h){
  	var e = event.fromElement || event.relatedTarget;
		var srcElement = $(event.srcElement || event.target);		
  	if (e && srcElement!=this.imageSrc){
	  	if (!this.initialize) this.init();
		  	if (srcElement.src && (src==null || src=='')){
	  		src = getBigImage(srcElement.src);
	  	}
			this.imageContainer.update(this.loadingimg.outerHTML);
	  	if (objInvalid.checkExt(src,_WebPageInfo.ImageInfo.exts)==0 && objInvalid.checkExt(src,_WebPageInfo.FlashInfo.exts)==0 && objInvalid.checkExt(src,_WebPageInfo.ThreeDInfo.exts)==0){
	  		return false;
	  	}
	  	if (w) this.width = w;
	  	if (h) this.height = h;
	  	this.imageSrc = srcElement;//$(event.srcElement || event.target);
	  	if (this.imageSrc.tagName.toUpperCase()!='IMG'){
	  		this.isimage = false;
	  	}
			this.ps = document.viewport.getPage();
		  this.scrollsize = document.viewport.getScrollOffsets();
			var pos = Element.viewportOffset(this.imageSrc);
			if (this.isimage){
				this.x = pos.left + this.imageSrc.width/2+this.scrollsize.left;
				this.y = pos.top + this.imageSrc.height/2+this.scrollsize.top;
			}else{				
				this.x = pos.left + this.imageSrc.getWidth()/2 + this.scrollsize.left;
				this.y = pos.top + this.imageSrc.getHeight()/2 + this.scrollsize.top;
			}
			this.imageContainer.setStyle({top:this.y+'px',left:this.x+'px'});
			
			this.imageContainer.show();
			
			if (this.image){
				Event.stopObserving(this.image,"load",this.imageLoadEvent);
				this.image = null;
			}
			this.image = $(document.createElement("img"));
		  this.image.writeAttribute({"id":this.imageId,"class":"img"});
			Event.observe(this.image,"load",this.imageLoadEvent);
			this.image.src = src;
			Event.observe(this.imageSrc,"mouseout",this.mouseEvent);
  	}
  },
  mouseleave: function(event){
  	var e = event.toElement || event.relatedTarget;
  	if (e && e!=this.imageSrc && e.id!=this.id && e.id!=this.imageId && e.id!=this.zoommaskdiv && e.id!=this.zoomdiv && e.id!=this.viewimg && e.id!='previewloadingimg'){
			//Debug('leave');
			if (this.currentEffect){
				this.currentEffect.cancel();
			}
			Event.stopObserving(this.imageSrc,"mouseout",this.mouseEvent);
			Event.stopObserving(this.image,"load",this.imageLoadEvent);
			//Event.stopObserving(this.imageContainer,"mousemove",this.zoomEvent);
			//if ($(this.zoomdiv)) {
			//	Event.stopObserving($(this.zoomdiv),"mouseout",this.mouseEvent);
			//	$(this.zoomdiv).hide();
			//}
			this.image = null;
			this.imageSrc = null;
  		this.imageContainer.hide();
		}
  }
}

function writeFlash(filePath,name,w,h,href,target,prop,noiconpic){
  document.write(createFlash(filePath,name,w,h,href,target,prop,noiconpic));
}
function createFlash(filePath,name,w,h,href,target,prop,noiconpic){
  if (noiconpic!=""){
    return createImage(noiconpic,"icon_swf.png",w,h,0,href,target,prop + ' class="fswficon" ');
  }else{
	  var s = getFileSize(name);
	  var os = getRadio(s[0],s[1],w,h);
	  var so = new SWFObject(filePath + name, "smeshopswfflash", os[0], os[1], "9", "#FF6600");
	  so.addVariable("auto", "0");
	  html = so.getSWFHTML();
	  return html;
  }
}

function writeMedia(filePath,name,w,h,href,target,prop,noiconpic){
	document.write(createMedia(filePath,name,w,h,href,target,prop,noiconpic));
}

function createMedia(filePath,name,w,h,href,target,prop,noiconpic){
  if (!noiconpic) noiconpic="";
  if (noiconpic!=""){
    return createImage(noiconpic,"icon_video.png",w,h,0,href,target,prop);
  }else{
		var html = "";
		var s = getFileSize(name);
	  var os;
	  if (s){
	    os = getRadio(s[0],s[1],w,h);
	    os[1] +=50;
	  }else if (w && h){
	    os = [w,h];
	  }else{
	    os = [130,100];
	  }
	  html +='<embed ' +
	  		'src=' + (filePath + name) + ' ' +
	  		'width=' + os[0] + ' ' +
	  		'height=' + (os[1]) + ' ' +
	  		'autostart=false ' +
	  		'controls="controlpanel/playbutton" ' +
	  		'loop=false>' +
	  		'</embed>';
	  return html;
	}
}
function writeLink(name,url,target,prop){
	document.write(createLink(name,url,target,prop));
}
function createLink(name,url,target,prop){
	var h = "";
	if (name!="" && url!=""){
		h +='<a href="' + url + '" target="'+target+'">' + name + '</a>';
		return h;
	}else	if (name=="" && url!=""){
		h +='<a href="' + url + '" target="'+target+'">' + url + '</a>';
		return h;
	}else{
	  return "";
	}
}

function getFileSize(name){
  var fileName = name.split("\\.");
  var tmp = fileName[0].split("_");
  if (tmp.length!=3){
  	return [0,0];
  }else{
    var w = parseInt(isNaN(parseInt(tmp[1]))?0:tmp[1]);
    var h = parseInt(isNaN(parseInt(tmp[2]))?0:tmp[2]);
    return [w,h];
  }
}
function getRandom(digit){
  return Math.round(Math.random()*Math.pow(10,digit));
}
function getEffectRand(){
  var e = Math.round(Math.random() * 30);
  if (e>23){
    return this.getEffectRand();
  }else{
    return e;
  }
}
var Ads = Class.create();
Ads.prototype = {
  initialize: function() {
	  if (arguments!=null){
			if (arguments[0]!=null){
			  this.id = arguments[0];
			  this.parent = $(arguments[0]);
				this.numberTab = "number" + this.id;
				this.contentTab = "content" + this.id;
			}
			if (arguments[1]!=null){
        this.height = arguments[1];
			}
		  if (arguments[2]!=null){
        this.path = arguments[2];
			}
			if (arguments[3]!=null){
        this.adsData = arguments[3];
			}
			if (arguments[4]!=null){
        this.objectAds = arguments[4];
			}
			if (arguments[5]!=null){
			  this.isAutoScroll = arguments[5];
			}
		}
		this.adsWidth = 200;
		this.currentId = "";
		this.currentIndex = 0;
		this.firstRand = "";
		this.totalAds = this.adsData.length;
		this.adsHander = this;
		this.numbers = [];
		this.interval = null;
		this._createAdsModule();
		this.startTime = new Date().getTime();
		this.switchAds($("l" + this.currentId));
		if (this.isAutoScroll){
		  this.interval = window.setInterval(this.objectAds + ".autoScroll()",4000);
		}
  },
	_createAdsModule: function(){
	  var content = '<div class="tpbnbox">\
			<div class="tpbntabs">\
				<div class="tpbntabsbg">\
					<span class="tabCell" id="' + this.numberTab + '">\
					</span>\
				</div>\
			</div>\
			<ol class="tpbnpans" id="' + this.contentTab + '">\
			</ol>\
		</div>';
		this.parent.innerHTML = content;
		var box = $($(this.numberTab).parentNode.parentNode.parentNode);
		box.setStyle({height:this.height + "px"});
		this.adsWidth = box.getWidth();
		this._createAds();
	},
	_createAds: function(){
	  //Debug(this.adsData.length);
		var objectAds = this.objectAds;
		var adsHander = this.adsHander;
		for(var i=0;i<this.adsData.length;i++){
		  //if (i>0) break;
			var rand = this.getRandom(5);
			var data = this.adsData[i];
			var a = document.createElement("a");
			a = $(a);
			
			a.setAttribute("id","l" + rand);
			a.setAttribute("href","javascript:void(0);");
			a.setAttribute("title",data.name.encodeToHtml());
			a.index = i;
			a.rand = rand;
			var linkText=document.createTextNode(i+1);
			//a.innerText = i+1
			//a.textContent = i+1;
			a.appendChild(linkText);
			if (i==0) {
				this.currentId = rand;
				this.currentIndex = i;
				a.addClassName("current");
			}

			a.onclick=function(){
			  if (adsHander.currentId!=this.rand){
					adsHander.switchAds(this);
				}
				if (adsHander.isAutoScroll){
					window.clearInterval(eval(objectAds + ".interval"));
					adsHander.interval = window.setInterval(objectAds + ".autoScroll()",4000);
				}
				return false;
			}
			this.numbers[i] = a;
			$(this.numberTab).appendChild(a);
			
			var li = document.createElement("li");
			li = $(li);
			li.setAttribute("id","li" + rand);
			li.addClassName("pan");

			li.style.display = "";
			li.style.visibility = "hidden";
			var url = "";
			var target = "";
			if (url!=null && url != undefined && url!=""){
				url = data.url;
				target = "_blank";
			}
			if (data.image==""){
			  li.isImage = false;
			  li.addClassName("hover");
			  if (url==''){
				  li.innerHTML = '<div class="contentBox"><div class="contentBoxBg"><h4>' + data.name + '</h4>' + data.text.encodeToHtml() + '</div></div>';
			  }else{
			  	li.innerHTML = '<div class="contentBox"><div class="contentBoxBg"><h4><a href="' + url + '" target="_blank">' + data.name + '</a></h4><a href="' + url + '" target="_blank">' + data.text.encodeToHtml() + '</a></div></div>';
			  }
			}else{
			  li.isImage = true;
			  li.removeClassName("hover");
				li.onmouseover = function(){
					$(this).addClassName("hover");
				}
				li.onmouseout = function(){
					$(this).removeClassName("hover");
				}

				li.innerHTML = '<div>' + createModule(this.path,data.image,this.adsWidth,this.height,0,url,target,' alt="" ') + '</div>';
				if (url==''){
				  li.innerHTML += '<div class="contentBox"><div class="contentBoxBg"><h4>' + data.name + '</h4>' + data.text.encodeToHtml() + '</div></div>';
			  }else{
			  	li.innerHTML += '<div class="contentBox"><div class="contentBoxBg"><h4><a href="' + url + '" target="_blank" hidefocus="true">' + data.name + '</a></h4><a href="' + url + '" target="_blank" hidefocus="true">' + data.text.encodeToHtml() + '</a></div></div>';
			  }
			}
			
			if (i==0){
			  var rand = this.getRandom(5);
			  this.firstRand = rand;
				var lifirst = document.createElement("li");
				lifirst = $(lifirst);
				lifirst.setAttribute("id","li" + rand);
				lifirst.addClassName("pan");
				lifirst.style.display = "";
				lifirst.style.visibility = "visible";
				if (li.isImage){
				  lifirst.removeClassName("hover");
					lifirst.onmouseover = function(){
						$(this).addClassName("hover");
					}
					lifirst.onmouseout = function(){
						$(this).removeClassName("hover");
					}
				}else{
				  lifirst.addClassName("hover");
				}
				lifirst.innerHTML = li.innerHTML;
				
				$(this.contentTab).appendChild(lifirst);
		  }
		  $(this.contentTab).appendChild(li);
		}
		if (this.adsData.length<=1){
		  $($(this.numberTab).parentNode.parentNode).hide();
		}
	},
	switchAds: function(onum){
	  if (this.isIE5Up()){
	    var currentLi = $("li" + onum.rand);
	    var firstLi = $("li" + this.firstRand);
			firstLi.style.filter="blendTrans(duration=1.5) revealTrans(duration=1.0,transition=" + this.getEffectRand() + ")";
			firstLi.filters(0).apply();
			firstLi.filters(1).apply();
			
			if (currentLi.isImage){
			  firstLi.removeClassName("hover");
				firstLi.onmouseover = function(){
					$(this).addClassName("hover");
				}
				firstLi.onmouseout = function(){
					$(this).removeClassName("hover");
				}
			}else{
			  firstLi.addClassName("hover");
				firstLi.onmouseover = function(){}
				firstLi.onmouseout = function(){}
			}
			firstLi.innerHTML = currentLi.innerHTML;
			firstLi.filters(0).play();
			firstLi.filters(1).play();			
	  }else{
			if (this.currentId!=onum.rand){
			  this.fadeOut(this.currentId,99.999);
			}
			this.fadeIn(onum.rand,0);
    }
		$("l" + onum.rand).addClassName("current");
		if (this.currentId!=onum.rand){
		  $("l" + this.currentId).removeClassName("current");
		}
		this.currentId = onum.rand;
		this.currentIndex = onum.index;
		var nowTime = new Date().getTime();
		//Debug((nowTime-this.startTime)/1000 + "s");
		this.startTime = nowTime;
	},
	autoScroll: function(){
	  if (this.currentIndex + 1 < this.totalAds){
		  this.switchAds(this.numbers[this.currentIndex+1]);
		}else{
		  this.switchAds(this.numbers[0]);
		}
	},
	
	getRandom: function(digit){
    return Math.round(Math.random()*Math.pow(10,digit));
  },
  getEffectRand: function(){
    var e = Math.round(Math.random() * 30);
    if (e>23){
      return this.getEffectRand();
    }else{
      return e;
    }
  },
  isIE5Up: function(){
		var browser = navigator.userAgent;
		var startPos = browser.indexOf("MSIE");
		if (startPos < 0)return false;
		var IEversion = parseInt(browser.substring(startPos+5, browser.indexOf(".", startPos)));
		return (IEversion >= 5)
  },
  setOpacity:function(obj, opacity){
		if (obj != null){
			opacity = (opacity == 100)?99.999:opacity;
			// IE/Win
			obj.style.filter = "alpha(opacity:"+opacity+")";
			// Safari<1.2, Konqueror
			obj.style.KHTMLOpacity = opacity/100;
			// Older Mozilla and Firefox
			obj.style.MozOpacity = opacity/100;
			// Safari 1.2, newer Firefox and Mozilla, CSS3
			obj.style.opacity = opacity/100;
		}
	},
	fadeOut:function(rand,opacity){
		var adObj = $("li" + rand);
		if (adObj != null){
			if (opacity > -1){
				this.setOpacity(adObj, opacity);
				opacity -= 10;
				window.setTimeout(this.objectAds + ".fadeOut('"+rand+"',"+opacity+")", 100);
			}else{
				adObj.style.visibility = "hidden";
				adObj.style.zIndex=1;
			}
		}
	},
  fadeIn:function(rand,opacity){
		var adObj = $("li" + rand);
		if (adObj != null){
			if (opacity <= 99.999){
				adObj.style.visibility = "visible";
				adObj.style.zIndex=9999;
				this.setOpacity(adObj, opacity);
				opacity += 10;
				window.setTimeout(this.objectAds + ".fadeIn('"+rand+"',"+opacity+")", 100);
			}
		}
	}
}

Object.extend(String.prototype, {
  encodeToHtml: function() {
    return this.gsub(/\n/,'<br/>');
  },
  escapeQuot: function(isQuot){
  	if (isQuot){
      return this.gsub(/"/,'&quot;');
  	}else{
  		return this.escapeHTML().gsub(/"/,'&quot;'); 
  	}
  },
  unescapeQuot: function(isQuot){
  	if (isQuot){
      return this.gsub(/"/,'&quot;');
  	}else{
  		return this.unescapeHTML().gsub(/"/,'&quot;');
  	}
  },
  escapeSpecialChar: function (){
	  var t = this.replace(/'/g,"&#39;");
	  t = t.replace(/"/g,"&#34");
	  return t;
  }
});

	function getPageScroll() {

		var xScroll, yScroll;

		if (self.pageYOffset) {
			yScroll = self.pageYOffset;
			xScroll = self.pageXOffset;
		} else if (document.documentElement && (document.documentElement.scrollTop != undefined || document.documentElement.scrollTop != null)) {	 // Explorer 6 Strict
			yScroll = document.documentElement.scrollTop;
			xScroll = document.documentElement.scrollLeft;
		} else if (document.body) {// all other Explorers
			yScroll = document.body.scrollTop;
			xScroll = document.body.scrollLeft;
		}

		arrayPageScroll = new Array(xScroll, yScroll)
		return arrayPageScroll;
	}

	function getPageSize() {

		var xScroll, yScroll;

		if (window.innerHeight && window.scrollMaxY) {
			xScroll = window.innerWidth + window.scrollMaxX;
			yScroll = window.innerHeight + window.scrollMaxY;
		} else if (document.body.scrollHeight > document.body.offsetHeight) { // all but Explorer Mac
			xScroll = document.body.scrollWidth;
			yScroll = document.body.scrollHeight;
		} else { // Explorer Mac...would also work in Explorer 6 Strict, Mozilla and Safari
			xScroll = document.body.offsetWidth;
			yScroll = document.body.offsetHeight;
		}

		var windowWidth, windowHeight;

		//	console.log(self.innerWidth);
		//	console.log(document.documentElement.clientWidth);

		if (self.innerHeight) {	// all except Explorer
			if (document.documentElement.clientWidth) {
				windowWidth = document.documentElement.clientWidth;
			} else {
				windowWidth = self.innerWidth;
			}
			windowHeight = self.innerHeight;
		} else if (document.documentElement && document.documentElement.clientHeight) { // Explorer 6 Strict Mode
			windowWidth = document.documentElement.clientWidth;
			windowHeight = document.documentElement.clientHeight;
		} else if (document.body) { // other Explorers
			windowWidth = document.body.clientWidth;
			windowHeight = document.body.clientHeight;
		}

		// for small pages with total height less then height of the viewport
		if (yScroll < windowHeight) {
			pageHeight = windowHeight;
		} else {
			pageHeight = yScroll;
		}

		//	console.log("xScroll " + xScroll)
		//	console.log("windowWidth " + windowWidth)

		// for small pages with total width less then width of the viewport
		if (xScroll < windowWidth) {
			pageWidth = xScroll;
		} else {
			pageWidth = windowWidth;
		}
		//	console.log("pageWidth " + pageWidth)
		arrayPageSize = new Array(pageWidth, pageHeight, windowWidth, windowHeight, xScroll, yScroll)
		return arrayPageSize;
	}

	function showSelectBoxes() {
		var selects = document.getElementsByTagName("select");
		for (i = 0; i != selects.length; i++) {
			selects[i].style.visibility = "visible";
		}
	}

function showSelectBoxes(){
	var selects = document.getElementsByTagName("select");
	for (i = 0; i != selects.length; i++) {
		selects[i].style.visibility = "visible";
	}
}

// ---------------------------------------------------

function hideSelectBoxes(){
	var selects = document.getElementsByTagName("select");
	for (i = 0; i != selects.length; i++) {
		selects[i].style.visibility = "hidden";
	}
}

// ---------------------------------------------------

function showFlash(){
	var flashObjects = document.getElementsByTagName("object");
	for (i = 0; i < flashObjects.length; i++) {
		flashObjects[i].style.visibility = "visible";
	}

	var flashEmbeds = document.getElementsByTagName("embed");
	for (i = 0; i < flashEmbeds.length; i++) {
		flashEmbeds[i].style.visibility = "visible";
	}
}

// ---------------------------------------------------

function hideFlash(){
	var flashObjects = document.getElementsByTagName("object");
	for (i = 0; i < flashObjects.length; i++) {
		flashObjects[i].style.visibility = "hidden";
	}

	var flashEmbeds = document.getElementsByTagName("embed");
	for (i = 0; i < flashEmbeds.length; i++) {
		flashEmbeds[i].style.visibility = "hidden";
	}

}

var TEMPLATE_STATUS_BAR_TEXT ="Welecome to our website !";
var TEMPLATE_PLACE=1;
function windowStatusScrollIn() {
   window.status=TEMPLATE_STATUS_BAR_TEXT.substring(0, TEMPLATE_PLACE);
   if (TEMPLATE_PLACE >= TEMPLATE_STATUS_BAR_TEXT.length) {
     TEMPLATE_PLACE=1;
     window.setTimeout("windowStatusScroll()",200);
   } else {
     TEMPLATE_PLACE++;
     window.setTimeout("windowStatusScrollIn()",100);
   }
}
function windowStatusScroll() {
  window.status=TEMPLATE_STATUS_BAR_TEXT.substring(TEMPLATE_PLACE, TEMPLATE_STATUS_BAR_TEXT.length);
  if (TEMPLATE_PLACE >= TEMPLATE_STATUS_BAR_TEXT.length) {
    TEMPLATE_PLACE=1;
    window.setTimeout("windowStatusScrollIn()", 200);
  } else {
    TEMPLATE_PLACE++;
    window.setTimeout("windowStatusScroll()", 100);
  }
}

var switchTimer = null;
function switchTab(tabsize,prefix,index,style){
	var style = style;
	if (!$(prefix + index)) return ;
	if (switchTimer) clearTimeout(switchTimer);
	var isloaded = true;
  for (var i=0;i<tabsize;i++){
  	if (!$(prefix + i) || !$(prefix + 'btn' + i)){
  		isloaded = false;
  		break;
  	}
  }
  if (!isloaded){
  	if (style==null || style=='undefined') {
	  	var tab0 = $(prefix + 'btn0');
	  	var tab1 = $(prefix + 'btn1');
	  	if(tab0 && tab1){
	  		pos0 = tab0.viewportOffset();
	  		pos1 = tab1.viewportOffset();
	  		if (pos1.top - pos0.top <4){
	  			style = "TC";
	  		}else{
	  			style = "TL";
	  		}
	  	}else{
	  		style="TL";
	  	}
  	}
  	//SmePosition.tip($(prefix + 'btn' + index),$("adminTipBox"),_WebPageInfo.TabLoadWait,false,style,['rBox3Position'],'loadingMsg',false);
  	switchTimer = setTimeout(switchTab.bind(this,tabsize,prefix,index,style),2500);
  	return ;
  }
  //SmePosition.closeTip();
  for (var i=0;i<tabsize;i++){
  	var tab = $(prefix + i);
  	var tabbtn = $(prefix + 'btn' + i);
  	if (tab && tabbtn){
  		if (index==i){
		    tab.removeClassName('eleHid');
		    tabbtn.addClassName('select');
	  	}else{
		    tab.addClassName('eleHid');
		    tabbtn.removeClassName('select');
	  	}
  	}
  }
}

function switchBlind(id,css){
	var div = $(id).up('div.subFunctionLi');	
	div.toggleClassName(css);
}

function selectCategoryTree(treeId,current){
	$$("#" + treeId + " div.treeLink").each(function(obj){
	  $(obj).removeClassName("current");
	});
	var openSub = $(current).up(0).down("ul.treeSub");
	if ($(current).hasClassName("open")){
	  if (openSub) openSub.toggleClassName("openSub");
		$(current).removeClassName("open");
		$(current).addClassName("close");							
	}else{
	  if (openSub) openSub.toggleClassName("openSub");
		$(current).removeClassName("close");
		$(current).addClassName("open");
	}
	$(current).addClassName("current");
}

function selectMoveCategoryTree(treeId,current){
	$$("#" + treeId + " div.treeLink").each(function(obj){
	  $(obj).removeClassName("current");
	});
	$(current).addClassName("current");
}
Browser = {
	agent: function(){ return window.navigator.userAgent; },
	agentContains: function(s){ return Browser.agent().indexOf(s) != -1; },
	ie: function(){ return Browser.agentContains('MSIE') },
	gecko: function(){ return Browser.agentContains('Gecko')},
	firefox: function(){ throw 'Use Browser.gecko() instead'; },
	version: function(){
		var agent = Browser.agent();
		if(Browser.ie()){
			return parseFloat(agent.split('MSIE')[1])
		}else{
			return parseFloat(agent.split('/')[1])
		}
	},
	ie5_up: function(){ return Browser.ie() && (Browser.version() >= 5.0) },
	ie5_5up: function(){ return Browser.ie() && (Browser.version() >= 5.5) }
}

SmePosition = {
  button:null,
  objDiv:null,
  classNamePrefix:'rBox3Position',
  className:'BC',
  buttonPosition:null,
  divPosition:null,
  scrollOffset:null,
  pageSize:null,
  offset:{x:0,y:0},
  tipNoFix:function(btn,div,content,isMouseEvent,className,skinClassName,tipType){
  	this.tip(btn,div,content,isMouseEvent,className,skinClassName,tipType,true);
  },
  tip: function(btn,div,content,isMouseEvent,className,skinClassName,tipType,isfix){
	  if (!btn || !div){
		  alert('SmePosition.tip() parameters error , btn is not null, div is not null');
	  }
  	var isfix = isfix;
  	var skinClassName = skinClassName;
  	var tipType = (tipType==null || tipType==undefined)?'noteMsg':tipType;
		this.button = $(btn);
	  this.objDiv = $(div);	  
	  if (skinClassName==null || skinClassName=='undefined'){
	  	skinClassName = ["productTagTipBox","tipPopBox1"];
	  }
	  alert(btn);
  	for (var i=0;i<skinClassName.length;i++){
    	this.objDiv.addClassName(skinClassName[i]);
    }
  	this.classNamePrefix = skinClassName[skinClassName.length-1];
	  
	  if(className){
	    this.className = className;
	  }else{
	  	this.className = "TL";
	  }
	  if (isMouseEvent==null || isMouseEvent=='undefined'){
	  	isMouseEvent = true;
	  }else{
	  	isMouseEvent = false;
	  }
    this.mouseEvent = this.mouseleave.bindAsEventListener(this);
    if (isMouseEvent){
	    Event.observe(this.button,"mouseout",this.mouseEvent);
			Event.observe(this.objDiv,"mouseout",this.mouseEvent);
    }    
    
		this.objDiv.removeClassName("eleHid");
	  this.objDiv.show();
	  var tipdiv = this.objDiv.down('div.tipPopContentUpdate'); 
	  if (tipdiv){
	  	tipdiv.update(content);
	  }
	  tipdiv = this.objDiv.down('div.msgContent');	  
	  if (tipdiv){
	  	$w("noteMsg loadingMsg okMsg errorMsg warningMsg").each(function(id){tipdiv.removeClassName(id);});
	  	tipdiv.addClassName(tipType);	  	
	  }
	  this.setPosition(this.button,this.objDiv,this.className,this.classNamePrefix,isfix);
	},
	mouseleave:function(event){
		var e = event.toElement || event.relatedTarget;
		if (e!=this.objDiv && e!=this.button && !this.inContainer(this.objDiv,e)){
			this.objDiv.addClassName("eleHid");
		}
	},
	inContainer: function(id,obj){
	  var childs = $(id).childElements();
	  if ($(id)==obj) return true;
	  for (var i=0;i<childs.length;i++){
	    if (obj==childs[i]) {return true;}
	    if (this.inContainer(childs[i],obj)){
	      return true;
	    }
	  }
	  return false;
	},
  setPosition : function(btn,div,className,classNamePrefix,isfix){
		var isfix = (isfix==null || isfix=='undefined' || !isfix)?false:true;
	  this.button = $(btn);
	  this.objDiv = $(div);
	  if (classNamePrefix){
	  	this.classNamePrefix = classNamePrefix;
	  }
	  if (className){
	    this.className = className;
	  }
	  this.scrollOffset = document.viewport.getScrollOffsets();
	  this.pageSize = document.viewport.getPage();
	  this.buttonPosition = this.getPosition(this.button);
	  this.divPosition = this.getPosition(this.objDiv);
	  var autoPosition = null;
    
  	var cn = this.className.toArray();
  	var top = cn[0];
  	var left = cn[1];
  	var t = 0;
  	var l = 0;
  	
  	var pos = this.getLeft(left,isfix); 
  	l = pos.left;
  	left = pos.css;
  	pos = this.getTop(top,isfix);
  	t = pos.top;
  	top = pos.css;
  	
  	autoPosition = [l,t];
  	autoPosition.left = l;
  	autoPosition.top = t;
  	autoPosition.className = this.classNamePrefix + top + left;

	  $w("TL TC TR BL BC BR ML MR").each(function(id){
	  	this.objDiv.removeClassName(this.classNamePrefix +id);
		}.bindAsEventListener(this));
	  this.objDiv.removeClassName("eleHid");
	  this.objDiv.show();
	  this.objDiv.addClassName(autoPosition.className);
	  this.objDiv.setStyle({left:(autoPosition.left+ + this.scrollOffset.left)+'px',top:(autoPosition.top + this.scrollOffset.top)+'px'});	  
  },
  getLeft:function(posCss,isfix){
  	var left = "R";
  	var l = -1;
  	var lc = -1;
  	var lr = -1;
  	var ll = this.buttonPosition.left - this.divPosition.width;
  	if (!isfix){
		  ll+=this.buttonPosition.width / 2;
		}else{
			ll+=this.buttonPosition.width;
		}
  	l = ll;  	
  	if (ll<0 || (posCss && (posCss=='C' || posCss=='L'))){
  		lc = this.buttonPosition.left - this.divPosition.width/2 + this.buttonPosition.width/2;
  		l = lc;
  		if (lc<0 || (posCss && posCss=='L')){
  			lr = this.buttonPosition.left;
  			if (!isfix){
  			  lr+=this.buttonPosition.width / 2;
  			}
  			l = lr;
  			left = "L";
  			if (lr + this.divPosition.width > this.scrollOffset.left + this.pageSize[0]){
  				l = lc;
  				left = "C";
  			}
  		}else{
  			left = "C";
  			if (lc + this.divPosition.width > this.scrollOffset.left + this.pageSize[0]){
  				l = ll;
  				left = "R";
  			}
  		}
  	}
  	var result = [l,left];
  	result.left = l;
  	result.css = left;
  	return result;
  },
  getTop:function(posCss){
  	var top = "B";
  	var t = -1;
  	var tt = -1;
  	var tm = -1;
  	var tb = this.buttonPosition.top - this.divPosition.height;
  	//Debug("btnTop:" +this.buttonPosition.top)
  	t = tb;
  	if (tb<0 || (posCss && (posCss=='M' || posCss=='T'))){
  		tm = this.buttonPosition.top - this.divPosition.height / 2 + this.buttonPosition.height/2;
  		t = tm;
  		if (tm<0 || (posCss && posCss=='T')){
  			tt = this.buttonPosition.top + this.buttonPosition.height;
  			t = tt;
  			top = "T";
  			if (tt + this.divPosition.height > this.scrollOffset.top + this.pageSize[1]){
  				t = tm;
  				top = "M";
  			}
  		}else{
  			top = "M";
  			if (tm + this.divPosition.height > this.scrollOffset.top + this.pageSize[1]){
  				t = tb;
  				top = "B";
  			}
  		}
  	}
  	var result = [t,top];
  	result.top = t;
  	result.css = top;
  	return result;
  },
  getT:function(){
  	return this.buttonPosition.top + this.buttonPosition.height;
  },
  getM:function(){
  	return this.buttonPosition.top - this.divPosition.height / 2 + this.buttonPosition.height/2;
  },
  getB:function(){
  	return this.buttonPosition.top - this.divPosition.height;
  },
  getL:function(){
  	return this.buttonPosition.left + this.buttonPosition.width;
  },
  getC:function(){
  	return this.buttonPosition.left - this.divPosition.width/2 + this.buttonPosition.width/2;
  },
  getR:function(){
  	return this.buttonPosition.left - this.divPosition.width;
  },
  getFixL:function(){
  	return this.buttonPosition.left;
  },
  getFixR:function(){
  	return this.buttonPosition.left - this.divPosition.width + this.buttonPosition.width;
  },
  getPosition: function(element){
  	element = $(element);
  	var originalDisplay = element.getStyle('display')=='none' || element.hasClassName('eleHid');
    if (originalDisplay){
    	element.removeClassName('eleHid');
  	  element.show();
  	}
  	var size = element.getDimensions();
  	var position = element.viewportOffset();
  	var result = [size.width,size.height,position.left,position.top];//width,height,left,top
  	result.width = size.width;
  	result.height = size.height;
  	result.left = position.left;
  	result.top = position.top;
  	if (originalDisplay){
  		element.addClassName('eleHid');
  		element.hide();	
  	}
  	return result;
  },
  closeTip:function(){
  	if (this.objDiv){
  		this.objDiv.addClassName('eleHid');
  		this.objDiv.hide();
  	}else if($('tip')){
  		$('tip').addClassName('eleHid');
  		$('tip').hide();
  	}else if ($('adminTipBox')){
  		$('adminTipBox').addClassName('eleHid');
  		$('adminTipBox').hide();
  	}
  }
};

function addParams(url,params){
	var params = params;
	if (url==null || url=='undefined' || url=='') {
		alert("url is undefined or null or ''.");
		return ;
	}
	var url = url.gsub("&amp;","&");
	if (params==null || params=='undefined'){
		params = {};
	}
	var oldhash = {};
	var urltmp = url;
	var baseurl = url;
	var pos = url.indexOf("?");
	if (pos==-1){
		urltmp = url + "?";
	}else{
		baseurl = url.substr(0,pos);
	}
	oldhash = $H(urltmp.toQueryParams());
	var hash = $H(params);
	hash.update({rnd:Math.random()});
	oldhash.update(hash);

	var u = baseurl + "?" + oldhash.toQueryString();
	return u;
}

function addParamsJson(url,params,isrnd){
	var params = params;
	if (url==null || url=='undefined' || url=='') {
		alert("url is undefined or null or ''.");
		return ;
	}
	var url = url.gsub("&amp;","&");
	if (params==null || params=='undefined'){
		params = [];
	}else{
		for (var i=0;i<params.length;i++){
			if (url.indexOf('?' + params[i].name + '=')==-1 && url.indexOf('&' + params[i].name + '=')==-1){
		    url += (url.indexOf('?')!=-1 ? '&' : '?') + params[i].name + "=" + escape(params[i].value); 
		  }
		}
	}
	if (isrnd){
		if (url.indexOf('?rnd=')==-1 && url.indexOf('&rnd=')==-1){
			url = url + (url.indexOf('?')!=-1?('&rnd=' + Math.random()):('?rnd=' + Math.random()));
		}
	}
	return url;
}

function encode(s) {
	var unencoded = s;
	return encodeURIComponent(unencoded);
}
function decode(s) {
	var encoded = s;
	return decodeURIComponent(encoded.replace(/\+/g,  " "));
}

var parseCssJson = {
	effects:['dropshadow','shadow','glow'],
	oldcss:'',
	oldjson:{},
	css:'',
	json:{},
	setCss:function(css){
		parseCssJson.css = css.gsub(/@charset "utf\-8";/ig,'');
		parseCssJson.oldcss = parseCssJson.css;
		parseCssJson.json = parseCssJson.toJSON();
		parseCssJson.oldjson = parseCssJson.json;
	},
	getStyle:function(attr){
		var ats = attr.split("[");
		var attrs = 'parseCssJson.json';
		for (var i = 0 ;i <ats.length; i ++){
			if (ats[i]!=''){
				attrs +='[' + ats[i];
			  var v = eval(attrs);
			  if (v==undefined) return '';
			}
		}
		var value = eval('parseCssJson.json' + attr);
		if (value){
			return value;
		}else{
		  return '';
		}
	},
	setStyle:function(attr,value){
		var attr = attr.substr(2,attr.length - 4);
		var ats = attr.split('"]["');		
		var attrs = 'parseCssJson.json';
		for (var i = 0 ;i <ats.length; i ++){
			var v = (eval(attrs))[ats[i]];
		  if (v==undefined && i < ats.length -1){
		  	(eval(attrs))[ats[i]] = {};
		  }
		  if (i==ats.length-1){
		  	(eval(attrs))[ats[i]] = value;
		  }
		  attrs += '["' + ats[i]+ '"]';		  
		}
		parseCssJson.css = parseCssJson.toCSS();
	},
	toCSS:function(json,name,effects){//[".companyName"]["filter"]["dropshadow"],[".companyName"]["filter"]["dropshadow"]
		if (!json) json = parseCssJson.json;
		var css = '';
		for (var i in json){
			var styleStr = '';
			css +=i + " {\n";
			for (var j in json[i]){
				if (j.indexOf("filter")!=-1){
					styleStr += "\t" + j + ":";
					for (var k in json[i][j]){
						if (("," + effects + ",").indexOf(',["' + i + '"]["' + j +'"]["' + k + '"],')==-1) continue;
						var n = 0;
						styleStr +=k + "(";
						for(var l in json[i][j][k]){
							if (n>0){
								styleStr +=", ";
							}
							styleStr += l + "=" + json[i][j][k][l];
							n ++;
						}
						styleStr +=")";
					}
					styleStr +=";\n";
				}else{
					styleStr += "\t" + j + ":" + json[i][j] + ";\n";
				}
			}
			if (i==name || '["' + i + '"]'==name){
				return styleStr;
			}
			css +=styleStr + "}\n";
		}
		
		return css;
	},
	toJSON:function(css){
		if (!css) css = parseCssJson.css;
		var json = parseCssJson.parseCssToJSON(0,css);
		return eval('('+json+')');
	},
	parseCssToJSON:function(pos,css){
		if (!css) css = parseCssJson.css;
		var json = '';
		var pos = (!pos || pos==0)?0:pos;
		var p = css.indexOf("{",pos);
		if (p==-1) return '}';
		if (pos==0) json+="{";
		if (pos>0) json +=",";
		tag = css.substr(pos,p-pos);
		json += parseCssJson.clearCssTag(tag).inspect(true) + ":{";
		var endPos = css.indexOf("}",p);
		var content = "";
		if (endPos!=-1){
			content = css.substring(p+1,endPos);
		}else{
			content = css.substr(p+1);
		}
		json +=parseCssJson.parseAttribute(content) + "}";
		json +=parseCssJson.parseCssToJSON(endPos+1,css);
		return json;
	},
	parseAttribute:function(css){
		if (!css) css = parseCssJson.css; 
		var json = '';
		var attrs = css.split(";");
		for (var i = 0;i<attrs.length; i++){//font-family:Arial;
			if (attrs[i].strip()=='') continue;
			if (i>0){
				json +=",";
			}
			if (attrs[i].indexOf("(")!=-1){//filter:shadow( color=#0111125,direction=135 );
				var filters = attrs[i].split(":");
				json +=parseCssJson.clearCssTag(filters[0]).inspect(true) + ":{";
				filters = filters[1].split("(");
				json +=parseCssJson.clearCssTag(filters[0]).inspect(true) + ":{";
				filters = filters[1].split(",");
				for (var j = 0 ; j<filters.length;j++){
					var fs = filters[j].split("=");
					if (j>0){
						 json +=",";
					}
					if (j==filters.length-1){
						fs[1] = fs[1].gsub(/\)/,'');
					}
					json +=parseCssJson.clearCssTag(fs[0]).inspect(true) + ":" + parseCssJson.clearCssValue(fs[1]).inspect(true);
				}
				json +="}}";
			}else{
				var attr = attrs[i].split(":");
				json +=parseCssJson.clearCssTag(attr[0]).inspect(true) + ":" + parseCssJson.clearCssValue(attr[1]).inspect(true);
			}
		}
		return json;
	},
	clearCssValue:function(v){
		var v = (''+v).strip();
		return v;
		if (v.length > 0 ){
			if (v.substring(0,1)=='"'){
				v = v.substr(1);
			}
		}
		if (v.length > 1){
			if (v.substring(v.length-1)=='"'){
				v = v.substring(0,v.length-1);
			}
		}
		return v.strip();
	},
	clearCssTag:function(tag){
		return tag.gsub(/\r/,'')
			 .gsub(/\n/,'')
			 .gsub('"','').strip();
			 //.gsub(/\s/,'');
	},
	getEffectName:function (attr){
		for (var i=0;i<parseCssJson.effects.length;i++){
			var effect = parseCssJson.effects[i];
			var value = eval('parseCssJson.json' + attr + '["' + effect + '"]');
			if (value){
				return effect;
			}
		}
		return "";
	},
	getFontStyle: function (style,weight){
	  var style = style==''?'normal':style;
	  var weight = weight==''?'normal':weight;
	  if (style!='normal' && weight=='normal'){
	  	return 'bold&italic';
	  }else if (style!='normal'){
	  	return style;
	  }else if (weight!='normal'){
	  	return weight;
	  }else{
	  	return 'normal';
	  }
	},
	parseFontStyle: function (style){
		var result = [];
	  var style = style.split("&");
	  if (style.length>1){
	  	result = [style[0],style[1]];
	  	result.style = style[1];
	  	result.weight = style[0];
	  	return result;
	  }else{
	  	if (style[0]=='normal'){
	  		result = ['normal','normal'];
	  		result.style = 'normal';
	    	result.weight = 'normal';
	  	  return result;
	  	}else if (style[0]=='bold'){
	  		result = ['normal','bold'];
	  		result.style = 'normal';
	  		result.weight = 'bold';
	  		return result;
	  	}else if (style[0]=='italic'){
	  		result = ['italic','normal'];
	  		result.style = 'italic';
	  		result.weight = 'normal';
	  		return result;
	  	}
	  }
	}
};
