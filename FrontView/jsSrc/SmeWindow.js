// JavaScript Document
var SmeWindows = {
  windows : [],
  maxZIndex : 4000,
  maskWindow : null,

  register: function (objWindow){
    //在一个页面弹出窗口，无论弹出多少个，mask都只有一个。
		if (this.maskWindow==null && objWindow.isMask){
			this.maskWindow = objWindow;
		}
		if (this.windows.length>0){//已经有弹出窗口了，则将之前的窗口mask提升zIndex;
			if (this.maskWindow!=null && objWindow.isMask==true){
			  this.maskWindow.mask.setStyle({zIndex:objWindow.zIndex-1});
			}
		}
		this.windows.push(objWindow);
	},
	unregister: function(objWindow){
		var maskWin = null;
		var lastMaskWin = null;
		var isThis = -1;
		for (var i = 0 ;i<this.windows.length;i++){
			var w = this.windows[i];
			if (w==objWindow){
				isThis = i;break;
			}
			if (maskWin==null && w.isMask){//第一個有遮罩的窗口，這個遮罩會用在同頁面多個窗口來回切換遮罩
				maskWin = w;
			}
			if (w.isMask){//這個是最后一個使用遮罩的窗口
				lastMaskWin = w;
			}			
		}
		if (isThis!=-1){//由于有可能關閉的窗口之上還有其他窗口
			for (var i = this.windows.length-1; i>isThis; i--){
				this.windows[i].closeWin();
			}
		}
		if (maskWin!=null){//設置遮罩到上一個使用遮罩的窗口
			maskWin.mask.setStyle({zIndex:lastMaskWin.zIndex-1});
			this.maxZIndex = lastMaskWin.zIndex-1;
		}
		this.windows.pop();
		if (this.windows.length==0){
			this.maskWindow = null;
			this.maxZIndex = 4000;
		}
	},
	checkMaskWindow: function(objWindow){
		var maskWin = null;
		for (var i = 0 ;i<this.windows.length;i++){
			var w = this.windows[i];
			if (w==objWindow){
				break;
			}
			if (maskWin==null && w.isMask){
				maskWin = w;
			}
		}
		if (maskWin!=null){
			return true;
		}else{
			return false;
		}
	}
};

var SmeWindow = Class.create();
SmeWindow.prototype = {
  initialize: function() {
    var optionIndex = 0;
    this.options = Object.extend({
      id:        null,
      className: null,
      title:     '',
      width:     500,
      height:    400,
      url:       null,
      parent:    document.body,
      position:  0,
      isMask:    false,
      isScroll:  false,
			winmode:   'adv',
      textalign: "left",
      zIndex:    SmeWindows.maxZIndex+5
    }, arguments[optionIndex] || {});
    SmeWindows.maxZIndex+=5;
		
    this.id = this.options.id;
    this.title = this.options.title;
		this.width = this.options.width;
		this.height = this.options.height;
		this.url = this.options.url;
		this.parent = this.options.parent;
		this.position = this.options.position;
		this.isMask = this.options.isMask;
		this.isScroll = this.options.isScroll;
		this.winmode = this.options.winmode;
		this.textalign = this.options.textalign;
		this.zIndex = this.options.zIndex;
		if (!this.zIndex){
		  this.zIndex = SmeWindows.maxZIndex+5;
		}
    if (!this.id)
      this.id = "window_" + new Date().getTime();
      
    if ($(this.id))
      alert("Window " + this.id + " is already registered in the DOM! Make sure you use setDestroyOnClose() or destroyOnClose: true in the constructor");
    if (!this.options.className) {
			this.className = this.winmode=='adv'?'uWin':'uWinSimple';
		}else{
			this.className = (this.winmode=='adv'?'uWin':'uWinSimple') + ' ' + this.options.className;
		}
    if (this.winmode=='adv' && this.title==''){
    	this.className += ' uWinNoHx';
		}
  		if (this.url==null) this.url = '';
		
		this.win = this._createWin();
		if (this.isMask){
		  this.mask = this._createMask();
		}
		
		this.content = $(this.id + '_content');
		this.content.style.textAlign = this.textalign;
		
		this.closeBtn = $(this.id + '_close_btn');
		
		this.eventCloseBtn = this.closeWin.bindAsEventListener(this);
    this.eventScroll = this.scrollWin.bindAsEventListener(this);
    this.eventResize = this.resizeWin.bindAsEventListener(this);
    
    Event.observe(this.closeBtn, "click", this.eventCloseBtn);
    if (this.isScroll){
      Event.observe(window, "scroll", this.eventScroll);
    }
    Event.observe(window, "resize", this.eventResize);
  },
	
	_createWin: function(){
		var wintmp = $(document.createElement("div"));
		wintmp.writeAttribute({'class':this.className});
		wintmp.hide();		
		this.parent.insertBefore(wintmp,this.parent.firstChild);
		var borderWidth = parseFloat(wintmp.getStyle('border-top-width').replace('px',''));
		var padding_top = parseFloat(wintmp.getStyle('padding-top').replace('px',''));
		var padding_bottom = parseFloat(wintmp.getStyle('padding-bottom').replace('px',''));
		var win = $(document.createElement("div"));
    win.writeAttribute({'id':this.id,'class':this.className});
    var width = this.width;
    var height = this.height;
    
    height -=(padding_top+padding_bottom);
		if (this.winmode=='simple'){
			width -= borderWidth * 2;
			height -= borderWidth * 2;
		}
    Element.setStyle(win,{width: width + 'px',height: height + 'px',zIndex:this.zIndex});
		var content = this._createHead() + this._createBody() + this._createFooter();
		win.update(content);
		win.hide();		
		wintmp.remove();
	  this.parent.insertBefore(win,this.parent.firstChild);
		return win;
	},
	_createMask: function(){
	  var win = $(document.createElement("div"));
	  win.setAttribute("id", this.id + "_mask");
	  win.className = "maskDiv";
	  win.style.zIndex=this.zIndex -1 ;
	  this.parent.insertBefore(win,this.parent.firstChild);
	  win.hide();
	  return win;
	},
	_createHead: function(){
		if (this.winmode=='adv'){
			if (this.title==''){
				return '<div class="uWinT"><i class="uWinTL"></i><i class="uWinTC"></i><i class="uWinTR"></i><span class="uWinToolBar"><a hideFocus class="closeBtn" href="javascript:void(0);" id="' + this.id + '_close_btn">Close</a></span></div>';
			}else{
				return '<div class="uWinH">\
					 <i class="uWinHL"></i><h3 class="uWinHC"><strong>' + this.title.escapeHTML() + '</strong><em class="shadow">' + this.title.escapeHTML() + '</em></h3><i class="uWinHR"></i>\
					 <span class="uWinToolBar"><a href="javascript:void(0);" id="' + this.id + '_close_btn" class="closeBtn" hidefocus="true">Close</a></span>\
				 </div>';
			}
		}else{
			return '<div class="uWinToolBar"><a href="javascript:void(0);" id="' + this.id + '_close_btn" class="closeBtn" hidefocus="true">Close</a></div>'			
		}
	},
	_createFooter: function(){
		if (this.winmode=='adv'){
		  return '<div class="uWinB"><i class="uWinBL"></i><i class="uWinBC"></i><i class="uWinBR"></i></div>';
		}else{
			return ''
		}
	},
	_createBody: function(){
		var b = "";
		if (this.winmode=='adv'){
			b +='<div class="uWinContent">';
			if (this.url==''){
				b +='<div class="autoScroll" id="' + this.id + '_content">';
				b +='</div>';
			}else{
				b +='<iframe src="' + this.url + '" id="' + this.id + '_content" name="' + this.id + '_content" allowTransparency="true" frameborder="0"></iframe>';
			}
			b +='<p class="uWinML"></p><p class="uWinMR"></p>';
			b +='</div>';
		}else{
			b +='<div class="uWinContent">';
  		if (this.url==''){
				b +='<div class="autoScroll" id="' + this.id + '_content">';
				b +='</div>';
			}else{
				b +='<iframe src="' + this.url + '" id="' + this.id + '_content" name="' + this.id + '_content" allowTransparency="true" frameborder="0"></iframe>';
			}
			b +='</div>';
		}
		return b;
	},
	
	setAjaxContent: function(url,options){
		options = options || {};
		this.setContent("");
    this.onComplete = options.onComplete;
    if (! this._onCompleteHandler)
      this._onCompleteHandler = this._setAjaxContent.bind(this);
    options.onComplete = this._onCompleteHandler;

    new Ajax.Request(url, options);    
    options.onComplete = this.onComplete;
	},
	
	_setAjaxContent: function(originalRequest) {
    Element.update(this.getContent(), originalRequest.responseText);
    if (this.onComplete)
      this.onComplete(originalRequest);
    this.onComplete = null;
  },
	
	getContent: function(){
		return this.content;
	},
	
	setContent: function(html){
		this.getContent().update(html);
	},
	
	show: function(position){
	  if (this.isMask){
	  	if (SmeWindows.maskWindow==null){
	  		var ps = getPageSize();
		    this.mask.setStyle({width:(ps[4]+20)+'px',height:(ps[5]+20)+'px',left:0+'px',top:0+'px'});
			  this.parent.parentNode.style.overflow = "hidden";
			  hideSelectBoxes();
			  hideFlash();
		    this.mask.show();
	  	}
	  }
	  SmeWindows.register(this);
		if (position)	this.position = position;
		this.isShow = true;
    this.scrollWin();
	},
	resizeWin: function(){
		this.scrollWin();
		if (SmeWindows.maskWindow!=null){
			var ps = getPageSize();
			SmeWindows.maskWindow.mask.setStyle({width:(ps[4]+20)+'px',height:(ps[5]+20)+'px',left:0+'px',top:0+'px'});
		}
	},
	scrollWin: function(){
	  var page = getPageSize();
	  var pageScroll = getPageScroll();
		if (!this.position) this.position = 0;
		var top = 0;
		var left = 0;
		var initTop = 0;
		var initLeft = 0;
		if (this.position==0){//中央
		  left = pageScroll[0] + (page[2] - this.width)/2+1;
		  top = pageScroll[1] + (page[3]-this.height)/2;
		  initTop = top;
		  initLeft = left;
		}else if (this.position==1){//左上方
		  top = pageScroll[1];
		  initTop = top - this.height;
		}else if (this.position==2){//右上方
		  top = pageScroll[1];
		  left = page[2] - this.width - 19;
		  initLeft = left;
		  initTop = top - this.height;
		}else if (this.position==3){//左下方
		  top = pageScroll[1] + page[3] - this.height;
		  initTop = top + this.height;
		}else if (this.position==4){//右下方
		  left = page[2] - this.width - 19
		  top = pageScroll[1] + page[3] - this.height;
		  initLeft = left;
		  initTop = top + this.height;
		}
		if (this.isShow){
		  this.win.setStyle({left:initLeft+'px',top:initTop+'px'});
		}
		this.win.show();
		new Effect.Move(this.win,{x:left,y:top,mode:'absolute'});
		this.isShow = false;
	},
	
	closeWin: function(){
		if (this.isMask) {
			if (!SmeWindows.checkMaskWindow(this)){
			  this.parent.parentNode.style.overflow = "";
	      showSelectBoxes();
			  showFlash();
			}
		  this.mask.hide();
	  }
		SmeWindows.unregister(this);
		Event.stopObserving(this.closeBtn, "click", this.eventCloseBtn);
    if (this.isScroll){
      Event.stopObserving(window, "scroll", this.eventScroll);
    }
    Event.stopObserving(window, "resize", this.eventResize);
    
    if (this.url!=''){
    	this.content.src = "about:blank";
    }    
    Element.remove(this.closeBtn);
    Element.remove(this.mask);
    Element.remove(this.win);
	}
}