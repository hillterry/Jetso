// JavaScript Document
var IMPORTJS = {
	initialize: false,
  path:'',
  param:'',
  init: function() {
	  this.initialize = true;
    var script = document.getElementsByTagName("script");
    for (var i = 0; i<script.length; i++ ){
      var tmp = script[i].src;
      if (tmp.indexOf("/import.js")!=-1){
        this.path = tmp.replace(/import\.js(\?.*)?$/,'');
        var includes = tmp.match(/\?.*param=([a-z,]*)/);
        if (includes){
        	this.param = includes[1];
        }        
        break;
      }
    }
  },
  load: function(scriptname){
  	if (!this.initialize){
  		this.init();
  	}
  	var names = scriptname;
  	if (typeof scriptname=='string'){
  		names = [scriptname];
  	}
  	var path = '';
  	for(var i=0;i<names.length;i++){
  		if (names[i].indexOf("/")==0){
  			this.path = '';
  		}else{
  			path = this.path;
  		}
  		document.write('<script type="text/javascript" src="' + path + names[i] + '"></script>');
  	}
  }
};

IMPORTJS.load(['browser.js',
							 'prototype.js',
							 'prototype_ext.js',
							 'scriptaculous.js',
							 '_webpage.js',
							 'FormInvalid.js',
							 'msclass.js',
							 'js.js',
							 'calendar.js',
							 'date.js',
							 'common.js',
							 'SmeWindow.js',
							 //'SmeDebug.js',
							 'swfobject.js']);
