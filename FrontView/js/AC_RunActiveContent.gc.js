var isIE=navigator.appVersion.indexOf("MSIE")!=-1?!0:!1,isWin=navigator.appVersion.toLowerCase().indexOf("win")!=-1?!0:!1,isOpera=navigator.userAgent.indexOf("Opera")!=-1?!0:!1;
function ControlVersion(){var a,c;try{c=new ActiveXObject("ShockwaveFlash.ShockwaveFlash.7"),a=c.GetVariable("$version")}catch(g){}if(!a)try{c=new ActiveXObject("ShockwaveFlash.ShockwaveFlash.6"),a="WIN 6,0,21,0",c.AllowScriptAccess="always",a=c.GetVariable("$version")}catch(b){}if(!a)try{c=new ActiveXObject("ShockwaveFlash.ShockwaveFlash.3"),a=c.GetVariable("$version")}catch(e){}if(!a)try{new ActiveXObject("ShockwaveFlash.ShockwaveFlash.3"),a="WIN 3,0,18,0"}catch(f){}if(!a)try{new ActiveXObject("ShockwaveFlash.ShockwaveFlash"),
a="WIN 2,0,0,11"}catch(d){a=-1}return a}
function GetSwfVer(){var a=-1;if(navigator.plugins!=null&&navigator.plugins.length>0){if(navigator.plugins["Shockwave Flash 2.0"]||navigator.plugins["Shockwave Flash"]){var a=navigator.plugins["Shockwave Flash"+(navigator.plugins["Shockwave Flash 2.0"]?" 2.0":"")].description.split(" "),c=a[2].split("."),g=c[0],c=c[1],b=a[3];b==""&&(b=a[4]);b[0]=="d"?b=b.substring(1):b[0]=="r"&&(b=b.substring(1),b.indexOf("d")>0&&(b=b.substring(0,b.indexOf("d"))));a=g+"."+c+"."+b}}else navigator.userAgent.toLowerCase().indexOf("webtv/2.6")!=
-1?a=4:navigator.userAgent.toLowerCase().indexOf("webtv/2.5")!=-1?a=3:navigator.userAgent.toLowerCase().indexOf("webtv")!=-1?a=2:isIE&&isWin&&!isOpera&&(a=ControlVersion());return a}
function DetectFlashVer(a,c,g){versionStr=GetSwfVer();if(versionStr==-1)return!1;else if(versionStr!=0){isIE&&isWin&&!isOpera?(tempArray=versionStr.split(" "),tempString=tempArray[1],versionArray=tempString.split(",")):versionArray=versionStr.split(".");var b=versionArray[0],e=versionArray[1],f=versionArray[2];if(b>parseFloat(a))return!0;else if(b==parseFloat(a))if(e>parseFloat(c))return!0;else if(e==parseFloat(c)&&f>=parseFloat(g))return!0;return!1}}
function AC_AddExtension(a,c){return a.indexOf("?")!=-1?a.replace(/\?/,c+"?"):a+c}function AC_Generateobj(a,c,g){var b="";if(isIE&&isWin&&!isOpera){b+="<object ";for(var e in a)b+=e+'="'+a[e]+'" ';b+=">";for(e in c)b+='<param name="'+e+'" value="'+c[e]+'" /> ';b+="</object>"}else{b+="<embed ";for(e in g)b+=e+'="'+g[e]+'" ';b+="> </embed>"}document.write(b)}
function AC_FL_RunContent(){var a=AC_GetArgs(arguments,".swf","movie","clsid:d27cdb6e-ae6d-11cf-96b8-444553540000","application/x-shockwave-flash");AC_Generateobj(a.objAttrs,a.params,a.embedAttrs)}function AC_SW_RunContent(){var a=AC_GetArgs(arguments,".dcr","src","clsid:166B1BCA-3F9C-11CF-8075-444553540000",null);AC_Generateobj(a.objAttrs,a.params,a.embedAttrs)}
function AC_GetArgs(a,c,g,b,e){for(var f={embedAttrs:{},params:{},objAttrs:{}},d=0;d<a.length;d+=2)switch(a[d].toLowerCase()){case "classid":break;case "pluginspage":f.embedAttrs[a[d]]=a[d+1];break;case "src":case "movie":a[d+1]=AC_AddExtension(a[d+1],c);f.embedAttrs.src=a[d+1];f.params[g]=a[d+1];break;case "onafterupdate":case "onbeforeupdate":case "onblur":case "oncellchange":case "onclick":case "ondblClick":case "ondrag":case "ondragend":case "ondragenter":case "ondragleave":case "ondragover":case "ondrop":case "onfinish":case "onfocus":case "onhelp":case "onmousedown":case "onmouseup":case "onmouseover":case "onmousemove":case "onmouseout":case "onkeypress":case "onkeydown":case "onkeyup":case "onload":case "onlosecapture":case "onpropertychange":case "onreadystatechange":case "onrowsdelete":case "onrowenter":case "onrowexit":case "onrowsinserted":case "onstart":case "onscroll":case "onbeforeeditfocus":case "onactivate":case "onbeforedeactivate":case "ondeactivate":case "type":case "codebase":case "id":f.objAttrs[a[d]]=
a[d+1];break;case "width":case "height":case "align":case "vspace":case "hspace":case "class":case "title":case "accesskey":case "name":case "tabindex":f.embedAttrs[a[d]]=f.objAttrs[a[d]]=a[d+1];break;default:f.embedAttrs[a[d]]=f.params[a[d]]=a[d+1]}f.objAttrs.classid=b;e&&(f.embedAttrs.type=e);return f};
