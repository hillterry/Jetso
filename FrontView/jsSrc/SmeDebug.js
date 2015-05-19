var isDebug = true;
var isDebugInit = false;
var tempInfo = [];
var debugCount = 0;
function afterDebug(){
	if (isDebug){
		enableDebug();
		scrollDebug();
		Debug();
	}
}
function Debug(info,displayTime){
	this.formatDate = function(date){
		return this.appendZero(date.getHours()) + ':' + 
		this.appendZero(date.getMinutes()) + ':' + 
		this.appendZero(date.getSeconds()) + ' ' + 
		date.getMilliseconds();
	};
	this.appendZero = function(str){
		if ((''+str).length < 2){
			return '0' + str;
		}else{
			return str;
		}
	};
  if (isDebug){
  	if (!isDebugInit){
  		tempInfo[debugCount] = info;
  		debugCount ++;
  		return ;
  	}
    if (arguments.length<=0){
    	for(var i = 0 ;i<debugCount;i++){
    	  Debug(tempInfo[i]);
    	}
    	tempInfo = [];
    	return ;
    }
    var objdebug = $('JsDebugContent');
    if (!objdebug){
      return;
    }
    displayTime = displayTime?true:false;
    infoType = typeof info;
    if (infoType=="object"){
      if (info){
				if (info.type){
					infoType = '<span style="font-style:italic;">typeof</span> : [' + infoType + ']<br/>\
											<span style="font-style:italic;">type</span> : [' + info.type + ']<br/>\
											<span style="font-style:italic;">len</span> : ['+(info.length?info.length:'')+']<br/>\
											<span style="font-style:italic;">value</span> : [' + (info.value?info.value.escapeHTML():'undefined') +']<br/>';
				}else{
					infoType = '[' + infoType + ']';
				}
				infoType +='<span style="font-style:italic;">toString</span> : ' + info.toString();
				info = infoType;
			}else{
				info = '<span style="font-style:italic;">typeof</span> : [' + infoType + ']<br/><span style="font-style:italic;">value</span> : [null]';
			}
    }else if (infoType=="undefined"){
      info = '<span style="font-style:italic;">typeof</span> : [undefined]';
    }else if (infoType=="string"){
      info = info.escapeHTML();
    }else{
			info = '<span style="font-style:italic;">typeof</span> : [' + infoType + '],value:[' + info.toString() + ']';
		}
    info = info.gsub(/\r\n/,'\n').gsub(/\r/,'\n').gsub(/\n/,'<br/>').gsub(/\t/,'&nbsp;&nbsp;');
	  var div = $(document.createElement("div"));
	  div.setStyle({width:'96%',fontSize:'16px',backgroundColor:objdebug.childNodes.length % 2==0?'#efefef':''});
	  if (!displayTime){
		  div.update('<table border="0" cellspacing="0" cellpadding="2">\
		                   <tr>\
		                   <td style="font-size:9pt;color:#214972;" valign="top">'+this.formatDate(new Date())+'</td>\
		                   <td style="word-break:break-all;">' + info + '</td></tr></table>');
		}else{
		  div.update('<table width="100%"><tr><td style="word-break:break-all;">' + info + '</td></tr></table>');
		}
		if (objdebug.firstChild){
			objdebug.insertBefore(div,objdebug.firstChild);
		}else{
		  objdebug.appendChild(div);
		}
		$('debugHideBut').writeAttribute("isHide","true");
		hideOrShowDebugInfo($('debugHideBut'));
	}	
}

function enableDebug(){
	if (!isDebug) return ; 
	if (isDebugInit) return ;
	isDebugInit = true;
	var div = $("JsDebug");	
	if (!div){
	  div = $(document.createElement("div"));
	  div.setAttribute("id","JsDebug");
	  div.addClassName("Debug");
	  div.setStyle({background: '#fff', position: 'absolute',zIndex: '1000000000', padding: '3px 3px'});
	  div.setStyle({width: '450px',height: '150px',left:'-448px',textAlign:'left',display:isDebug?'':'none',padding:'0px',overflow:'hidden'});
	}else{
		div.addClassName("Debug");
		div.setStyle({width: '450px',height: '150px',left:'-448px',textAlign:'left',display:isDebug?'':'none',padding:'0px',overflow:'hidden'});
	}
  div.update('<div id="JsDebugTitle" style="background-color:#000000;color:#FFFFFF;text-align:left;padding:0px;">\
  <table width="100%" border="0" cellspacing="0" cellpadding="0"><tr>\
  <td style="">Debug Information</td>\
  <td style="width:30px;text-align:right;"><span style="cursor:pointer;" id="clearHander">clear</span></td>\
  <td style="text-align:right;width:20px"><span id="debugHideBut" isHide="true" style="cursor:pointer;">&gt;</span></td>\
  </tr></table></div>\
  <div id="JsDebugContent" style="width:450px; height:135px;text-align:left;padding:0px;overflow-x:hidden;overflow-y:auto;"></div>');
  
  if (!$("JsDebug")){
    document.body.insertBefore(div,document.body.firstChild);
  }
  
  $("JsDebug").onmouseover = function(){
  	hideOrShowDebugInfo($('debugHideBut'),true);
  }
  $("JsDebug").onmouseout = function(){
  	hideOrShowDebugInfo($('debugHideBut'),false);
  }
  $('debugHideBut').onclick = function(){
    hideOrShowDebugInfo(this);
  }
  $('clearHander').onclick = function(){
    $('JsDebugContent').update('');
		hideOrShowDebugInfo($('debugHideBut'));
  }
  Event.observe(window, "scroll", scrollDebug);
  Event.observe(window, "resize", scrollDebug);
  
}
Event.observe(window,'load',afterDebug);
function eventDebugStop(){
	Event.stopObserving(document, "load", afterDebug);
}
function hideOrShowDebugInfo(obj,show){
	if (show){
		obj.writeAttribute("isHide","true");
	}
	var scroll = document.viewport.getScrollOffsets();
	var left = -448;
	if (obj.readAttribute('isHide')=='true'){
		$('JsDebug').setStyle({left:(scroll[0]-1) + 'px'});
		obj.writeAttribute("isHide","false");
		obj.innerHTML = '&lt;';//<<
	}else{
		$('JsDebug').setStyle({left: (scroll[0]+left) + 'px'});
		obj.writeAttribute("isHide","true");
		obj.innerHTML = '&gt;';//>>
	}
}
function scrollDebug(){
	var page = document.viewport.getDimensions();
	var scroll = document.viewport.getScrollOffsets();
	var left = -448;
	if ($('debugHideBut').readAttribute('isHide')=='true'){
		left = left + scroll[0];
	}else{
		left = scroll[0];
	}
	$('JsDebug').setStyle({left:(left)+'px',top:(scroll[1] + page.height - $('JsDebug').getHeight()-0) + 'px'});
}