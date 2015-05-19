if (typeof Prototype=='undefined'){
	alert("forminvalid.js requires including prototype.js library");
}

var InvalidForm = Class.create();
InvalidForm.prototype = {
  initialize: function() {
	  if (arguments!=null){
		  if (arguments[0]!=null){
        this.msg = arguments[0].evalJSON();
			}
		}
		this.msgPrefix = "{text:'',textarea:'',radio:'',checkbox:'',select:'',email:'',number_length_rang:'',number_min_length_rang:'',number_max_length_rang:'',length_rang:'',min_length_rang:'',max_length_rang:'',exts:''}".evalJSON();
  },
	initAdvance: function (msg,params){
  	var params = params || {enabledPrefix:false,className:null,form:null};
	  if (Object.isString(msg)){
	    this.advanceMsg = eval('(' + msg + ')');
	  }else{
	    this.advanceMsg = msg;
	  }
	  if (params.enablePrefix){
	  	this.enablePrefix = true;
	  }else{
	  	this.enablePrefix = false;
	  }
	  if (params.className){
	  	this.className = params.className;
	  }else{
	  	this.className = 'utrEm';
	  }
		if (params.form){
			this.form = params.form;
		}else{
			this.form = null;
		}
	},
	setContainer: function(containerclassname,errclassname){
		this.containerclassname = containerclassname;
		this.errclassname = errclassname;
	},	
	setMsgPrefix: function (prefix){
	  this.msgPrefix = prefix.evalJSON();
	},
	getMsgPrefix: function (type){
	  if (type=='text' || type=='password'){
	    return this.msgPrefix.text;
	  }else if (type=='textarea'){
	    return this.msgPrefix.textarea;
	  }else if (type=='radio'){
	    return this.msgPrefix.radio;
	  }else if (type=='checkbox'){
	    return this.msgPrefix.checkbox;
	  }else if (type=='select' || type=='file'){
	    return this.msgPrefix.select;
	  }else if (type=='email'){
	    return this.msgPrefix.email;
	  }else{
	    return this.msgPrefix.text;
	  }
	},
	appendZero:function(n,d){
		var d = (d==null || d==undefined)?2:d;
		var t = ("" + n);
		var add = d-t.length;
		for (var i=0;i<add;i++){
			t = "0" + t;
		}
		return t;
	},
  getObject:function(n, d) { //v4.01
	  if (!d){
			d = this.form;
		}
		var p,i,x; if(!d) d=document; if((p=n.indexOf("?"))>0&&parent.frames.length) {
		d=parent.frames[n.substring(p+1)].document; n=n.substring(0,p);}
		if(!(x=d[n])&&d.all) x=d.all[n]; for (i=0;!x&&i<d.forms.length;i++) x=d.forms[i][n];
		for(i=0;!x&&d.layers&&i<d.layers.length;i++) x=this.getObject(n,d.layers[i].document);
		if(!x && d.getElementById) x=d.getElementById(n); return x;
	},
	_getFormType:function(obj){
		if (obj != null){
			if(obj.length==null){
				return obj.type;
			}else{
			  if(obj.length==0){
			    if(obj.type=='select-one'){
			      return "select";
			    }
			    return obj.type;
			  }else{
				  if (obj[0].parentNode.type=='select-one'){
				    return "select";
				  }
					return obj[0].type;
				}
			}
		}
	},
	getForm:function(obj){
		if (typeof obj == 'string') obj = this.getObject(obj);
		if (obj != null){
			if(obj.length==null){
				return obj;
			}else{
			  if(obj.length==0){
			    return obj;
			  }else{
				  if (obj[0].parentNode.type=='select-one'){
				    return obj[0].parentNode;
				  }
					return obj[0];
				}
			}
		}
		return null;
	},
	getFormLength:function(obj){
		if (typeof obj == 'string') obj = this.getObject(obj);
		if (obj != null){
			if(obj.length==null){
				return null;
			}else{
			  if(obj.length==0){
			    return null;
			  }else{
					return obj.length;;
				}
			}
		}
		return null;
	},
	_length: function(obj){
		return obj.replace(/[^\x00-\xff]/g,'**').length;
	},
	getWordLength: function(s){
		var str = '';
		var tmp = '';
		if (s==null || s=='undefined') {
			str = '';
			return 0;
		}
		str = s;
		tmp = str.replace(/[\u3000-\u3002\u300a\u300b\u300e-\u3011\u2014\u2018\u2019\u201c\u201d\u2026\u203b\u25ce\uff01-\uff5e\uffe5]/gi,' ');
		tmp = tmp.replace(/['"]/gi,'a');
		tmp = tmp.replace(/([^\x00-\xff])/gi,' china ');
		tmp = tmp.replace(/\W/ig,' ');
		tmp = tmp.replace(/\s+/ig,' ');
		tmp = tmp.replace(/^ */,'').replace(/ *$/,'');
		var rs = tmp.split(' ');
		return rs.length;
	},
	_getKeyCode: function(e){
		var code;
		if (!e) var e = window.event;
		if (e.keyCode){
			code = e.keyCode;
		}else if (e.which){
			code = e.which;
		}
		return code;
	},
	//-2.36onkeypress
	checkFloat:function(e)	{
		var code = this._getKeyCode(e);
		if ((code<45 || code>57 || code==47) && code!=45 && code!=9 && code!=8) return false;
		if(code==46 && obj.value.indexOf(".")>-1) return false;
		return true;
	},	
	//325onkeypress
	checkInt: function(e)	{
		var code = this._getKeyCode(e);
		if ((code<48 || code>57) && code!=45 && code!=9 && code!=8) return false;
		return true;
	},
	//tag--int,-int,+int
	isInt:function(n,tag){
	  //if (!isNaN(n)) return false;
		if(!n) return false;
		var tag = tag;
		if (tag==null){
		  tag = 'int';
		}
		var regStr = /^[\+|\-|\d?](\d+)?$/;
		if (tag=='-int'){
		  regStr = /^[\-]\d+$/;
		}else if (tag=='+int'){
		  regStr = /^[\+|\d]\d*$/;
		}
		
		if(!regStr.test(n)) return false;
		try{
			if(parseFloat(n)!=n) return false;
		}catch(ex){
			return false;
		}
	  return true;
	},
	//tag--number,-number,+number
  isNumber:function(n,tag){
		//if (!isNaN(n)) return false;
		if(!n) return false;
		var tag = tag;
		if (tag==null){
		  tag = 'number';
		}
		var regStr=/^[\+|\-]\d+(\.\d+)?$/;
		if (tag=='-number'){
		  regStr = /^[\-]\d+(\.\d+)?$/;
		}else if (tag=='+number'){
		  regStr = /^[\+|\d]\d*(\.\d+)?$/;
		}
		if(!regStr.test(n)) return false;
		try{
			if(parseFloat(n)!=n) return false;
		}catch(ex){
			return false;
		}
		return true;
	},
	checkEmail:function (mail) { 
		return(new RegExp(/^\w+((-\w+)|(\.\w+))*\@[A-Za-z0-9]+((\.|-)[A-Za-z0-9]+)*\.[A-Za-z0-9]+$/).test(mail)); 
	},
	checkSecondaryDomain:function (secondaryDomain){
    var regStr = /^[A-Z|a-z|0-9]+$/;
		return regStr.test(secondaryDomain);
	},
	checkDomain: function(domain){
	  var regStr = /^[a-zA-Z0-9][-a-zA-Z0-9]{0,61}[a-zA-Z0-9](\.[a-zA-Z0-9][-a-zA-Z0-9]{0,61}[a-zA-Z0-9])+\.?$/;
	  return regStr.test(domain);
	},
	checkContain: function(str,cstr){
	  cstr = "," + cstr.toUpperCase() + ",";
    if (str == "") return -1;
    var cExt = cstr.indexOf("," + str + ",");    
    if (cExt==-1){
			return 0;
    }else{
			return 1;
    }
	},
	removeContainItem : function(str,cstr){
		var c = cstr;
		if (c.indexOf(",")!=0) c =','+c;
		if (c.lastIndexOf(",")!=c.length-1) c += ',';
		var c = c.replace(',' + str + ',','');
		if (c.indexOf(",")==0){
			c = c.substr(1,c.length-1);
		}
		if (c.lastIndexOf(",")==c.length-1){
			c = c.substr(0,c.length-1);
		}
		return c;
	},
	addContainItem : function(str,cstr){
		var c = cstr;
		if (c.lastIndexOf(",")!=c.length-1 && c!=''){
			c +=',' + str;
		}else if (c==''){
			c = str;
		}else{
			c +=str + ',';
		}
		return c;
	},
	checkExt:function(path,extList){
    var ext = this.getFileExt(path);
    return (this.checkContain(ext,extList)==1);
  },
	selectText:function(obj){
		if (obj.type=='text' || obj.type=='textarea'){
			obj.select();
		}
	},
	getFullPath: function(name){
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
	},
	getFullName:function (path){
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
	},
	getFileExt:function(path){
    var tmp = path;
    tmp = tmp.substring(tmp.lastIndexOf(".")+1);
    return tmp.toUpperCase();
  },
  getFileSize:function(name){
    var fileName = this.getFullName(name).split("\\.");
    var tmp = fileName[0].split("_");
    if (tmp.length!=3){
    	return [0,0];
    }else{
      var w = parseInt(isNaN(parseInt(tmp[1]))?0:tmp[1]);
      var h = parseInt(isNaN(parseInt(tmp[2]))?0:tmp[2]);
      return [w,h];
    }
  },
	formatNumber:function(as_str,ai_digit,as_type){
		var fdb_tmp = 0;
		var fi_digit = 0;
		var fs_digit = "1";
		var fs_str = "" + as_str;
		var fs_tmp1 = "";
		var fs_tmp2 = "";
		var fi_pos = 0;
		var fi_len = 0;
		fdb_tmp = parseFloat(isNaN(parseFloat(fs_str))?0:fs_str);
		
		switch (true) {
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
				if (as_type=="str"){
					fs_tmp1 = fdb_tmp.toString();
					fs_tmp1 +=((fs_tmp1.indexOf(".")!=-1)?"":".") + fs_digit.substr(1);
					fi_pos = fs_tmp1.indexOf(".") + 1 + ai_digit;
					fdb_tmp = fs_tmp1.substr(0,fi_pos);
				}
				break;
		}
		return fdb_tmp;
	},
	replaceText: function(orgText,strAry){
		var t = orgText;
		var replaceStr = '';
		for(var i=0; i<strAry.length;i++){
			replaceStr = '#' + i + '#'
			r = new RegExp(replaceStr,'ig');
			t = t.replace(r,strAry[i]);
		}
		return t;
	},
	clearSelected:function(obj,index){
		if (obj != null){
			var objs = objs = (obj.length==null)?[obj]:obj;
			for (i = 0 ; i< obj.length ; i++){
				if (index!=-1 && index==i){
					obj[i].checked = true;
				}else{
					obj[i].checked = false;
				}
			}
		}
	},
	selectedAll:function(obj){
		if (obj != null){
			if(obj.length==null){
				obj.checked = true;
			}else{
				for (i = 0 ; i< obj.length ; i++){
					obj[i].checked = true;
				}
			}
		}
	},
	inverseSelected:function(obj){
		if (obj != null){
			if(obj.length==null){
				obj.checked = !obj.checked;
			}else{
				for (i = 0 ; i< obj.length ; i++){
					obj[i].checked = !obj[i].checked;
				}
			}
		}
	},
	getFocus:function(obj){
		if (obj != null){
			if(obj.length==null){
				obj.focus();
			}else{
			  if (obj.length==0){
			    obj.focus();
			  }else{
				  if (obj[0].parentNode.type=='select-one'){
				    obj[0].parentNode.focus();
				  }else{
				  	obj[0].focus();
					}
				}
			}
		}	
	},
	checkSelectedCustom:function(formStr,size){
		var f;
		for(var i=0;i<size;i++){
			var fname = formStr.replace('{index}',i); 
			f = $(fname);
			if (f.checked){
				return true;
			}
		}
		return false;
	},
	checkSelected:function(obj,qty){
		var ischeck = false;
		var qty = qty;
		var qtyCounter = 0;
		if (qty==null) qty = 1;
		if (obj != null){
			if(obj.length==null){
				if (obj.checked == true) ischeck = true;
			}else{
				for (i = 0 ; i< obj.length ; i++){
					if (obj[i].checked == true){
						qtyCounter++;
						if (qtyCounter >=qty){
						  ischeck = true;
						  break;
						}
					}
				}
			}
		}
		return ischeck;
	},
	getSelectedValue: function(obj){
		var v = "";
		if (obj != null){
			if(obj.length==null){
				if (obj.checked == true) v = obj.value;
			}else{
			  if(obj.length==0){
			    return obj.value;
			  }else{
				  if (obj[0].parentNode.type=='select-one'){
				    return obj[0].parentNode.value;
				  }
					for (i = 0 ; i< obj.length ; i++){
						if (obj[i].checked == true){return obj[i].value;;break;}
					}
				}
			}
		}
		return v;
	},
	setSelectOption:function(ddl,v){
	  var t = this._getFormType(ddl);
	  if (t == 'checkbox' || t=='radio'){
	    if (!ddl.length){
	      if (ddl.value==v) ddl.checked = true;
	    }else{
		    for (var i = 0; i< ddl.length;i++){
		      if (ddl[i].value==v){
		        ddl[i].checked = true;
		        break;
		      }
		    }
	    }
	  }else if (t == 'select'){
			for (var i = 0 ; i<ddl.options.length;i++){
				if (ddl.options[i].value==v){
					ddl.options[i].selected = true;
					break;
				}
			}
		}
	},
	operateSelect: function(sel,ddl,imageBox){
		var selectType;
		var obj = this.getObject(sel);
		try{
			selectType = ddl.value;
			ddl.options[0].selected=true;
		}catch(e){
			selectType = ddl;
		}
		if(obj){
			if(obj.length==null){
				if (!obj.disabled){
				  var box = this.getObject(imageBox + '0');
					switch (selectType){
						case "all":obj.checked=true;$(box).addClassName("select");break;
						case "invert":obj.checked=!obj.checked;if (obj.checked){$(box).addClassName("select");}else{$(box).removeClassName("select");}break;
						case "none":obj.checked=false;$(box).removeClassName("select");break;
					}
				}
			}else{
				for (var i = 0 ; i< obj.length ; i++){
					if (!obj[i].disabled){
					  var box = this.getObject(imageBox + i); 
						switch (selectType){
							case "all":obj[i].checked=true;$(box).addClassName("select");break;
							case "invert":obj[i].checked=!obj[i].checked;if (obj[i].checked){$(box).addClassName("select");}else{$(box).removeClassName("select");}break;
							case "none":obj[i].checked=false;$(box).removeClassName("select");break;
						}
				  }
				}
			}
		}
	},
	Null2Space: function (varValue){
	  if (typeof varValue == 'undefined'){
	    return '';
	  }
	  if (varValue==null){
	    return '';
	  }else{
	    return varValue;
	  }
	},
	TrimSep: function(str, sep){
		var tmp = str.strip();
		if (tmp.indexOf(sep)==0){
			tmp = tmp.substring(1);
		}
		if (tmp.lastIndexOf(sep)==tmp.length-1){
			tmp = tmp.substr(0,tmp.length-1);
		}
		return tmp;
	},
	checkNull: function (id){
	  var f = this.getObject(id);
	  var value = f.value.strip();
	  var len = this._length(value);
	  return !(len > 0 );
	},
	initImmeInvalid: function(){
		var obj = null;
		for (var i = 0 ; i<this.advanceMsg.length;i++){
			var tt = this.advanceMsg[i];
			if (tt==undefined || tt==null || tt==''){
				alert('FormInvalid.js warning::::\r\nyou input form element [' + (i+1) + '] setting was wrong, please check you invalid msg string.');
				return ;
			}
			obj = this.getObject(this.advanceMsg[i].id);
			if (obj){
				var t = this._getFormType(obj);
				if (t=='select' && obj.length>1){
					Event.observe(obj,'change',this.immeInvalid.bind(this,tt).bindAsEventListener(this));
				}else if (t=='select'){
					Event.observe(obj,'click',this.immeInvalid.bind(this,tt).bindAsEventListener(this));
				}else if(t=='checkbox' || t=='radio'){
					if (obj.length==null){
					  Event.observe(obj,'click',this.immeInvalid.bind(this,tt).bindAsEventListener(this));
					}else if(obj.length==0){
						Event.observe(obj,'click',this.immeInvalid.bind(this,tt).bindAsEventListener(this));
					}else{
						for (var j = 0 ;j<obj.length;j++){
							Event.observe(obj[j],'click',this.immeInvalid.bind(this,tt).bindAsEventListener(this));
						}
					}
				}else{
					Event.observe(obj,'blur',this.immeInvalid.bind(this,tt).bindAsEventListener(this));
				}
			}else{
				alert('FormInvalid.js warning::::\r\n id = [' + this.advanceMsg[i].id + '] not found object , please checked .');
				return ;
			}
		}
	},
	immeInvalid: function(form){
		var rules = [];
		for (var i=0;i<form.rules.length;i++){
			rules[i] = {type:form.rules[i].type,
			  msg:form.rules[i].msg,
				notNull:form.rules[i].notNull,
				exts:form.rules[i].exts,
				minNumber:form.rules[i].minNumber,
				maxNumber:form.rules[i].maxNumber,
				lenType:form.rules[i].lenType,				
				compareObjectId:form.rules[i].compareObjectId}
		}
		var form = {id:form.id, 
								rules:rules,
								isfocus:false,
								isalert:false,
								containerid:form.containerid,
								errmsgid:form.errmsgid};
		if (this.InvalidCustom(form)){
			this.focusErrorLine(form.id,'success','',form.containerid,form.errmsgid);
			return true;
		}
		return false;
	},
	start: function(){
		for (var i = 0 ; i<this.advanceMsg.length;i++){
			var tt = this.advanceMsg[i];
			if (tt==undefined || tt==null || tt==''){
				alert('FormInvalid.js warning::::\r\nyou input form element [' + (i+1) + '] setting was wrong, please check you invalid msg string.');
				return false;break;
			}else{
				var obj = this.getObject(this.advanceMsg[i].id);
				if (!obj){
					alert('FormInvalid.js warning::::\r\n id = [' + this.advanceMsg[i].id + '] not found object , please checked .');
					return false;break;
				}
			}
			if (!this.InvalidCustom(tt)){
			  return false;break;
			}
		}
		return true;
	},
	InvalidCustom: function(formmsg){
		for (var i = 0 ;i <formmsg.rules.length;i++){
    	if (!this.Invalid(formmsg.id,
												formmsg.rules[i].type,
												formmsg.rules[i].msg,
												formmsg.rules[i].notNull,
												formmsg.rules[i].exts,
												formmsg.rules[i].minNumber,
												formmsg.rules[i].maxNumber,
												formmsg.rules[i].lenType,
												formmsg.isfocus,
												formmsg.isalert,
												formmsg.containerid,
												formmsg.errmsgid,
												formmsg.rules[i].compareObjectId)){
    		var msg = formmsg.rules[i].msg;
  			if (this.enablePrefix){
  				msg = this.getMsgPrefix(this._getFormType(this.getObject(formmsg.id))) + msg;
  			}
				if (formmsg.isalert==null || formmsg.isalert=='undefined' || formmsg.isalert) {
					alert(msg);
				}
				if (formmsg.isfocus==null || formmsg.isfocus=='undefined' || formmsg.isfocus) this.getFocus(this.getObject(formmsg.id));
				this.focusErrorLine(formmsg.id,'error', msg,formmsg.containerid,formmsg.errmsgid);
				return false;
			}
		}
		return true;
	},
	/**
	 * rules:copmare,file,string,int,number,length,email,secondarydomain,domain,
	 */
	Invalid: function(id,invalidType,msg,notNull,exts,minNumber,maxNumber,lenType,isfocus,isalert,containerid,errmsgid,compareObjectId){
		if (id=='null') return true;
		var minNumber = minNumber;
		var maxNumber = maxNumber;
		var notNull = notNull;
		var invalidType = invalidType;
		var isfocus = isfocus;
		var isalert = isalert;
		if (minNumber == null || minNumber=='undefined') minNumber = -1;
		if (maxNumber == null || maxNumber=='undefined') maxNumber = -1;
		if (notNull==null || notNull=='undefined') notNull = false;
		if (invalidType == null || invalidType=='undefined') invalidType = "string";
		if (isfocus==null || isfocus=='undefined') {isfocus = true}else{ isfocus = false;}
		if (isalert==null || isalert=='undefined') {isalert = true}else{ isalert = false;}
		var msg = msg;
		var f = this.getObject(id);
		if (f==null || f==undefined){
		  alert('object not exist for id [' + id + ']');
		  return false;
		}
		
		var t = this._getFormType(f);
		if (this.enablePrefix){
			msg = this.getMsgPrefix(t) + msg;
		}
		var value = "";
		if (t=='file' || t=='password' || t=='text' || t=='textarea' || t=='select'){
		  value = f.value.strip();
		  if (t=='text' || t=='textarea'){
		  	f.value = value;
		  }
			if (notNull && value=='') return true; 
    	if (invalidType=='string'){
				var len = this._length(value);
				if (lenType=='word'){
					len = this.getWordLength(value);
					//alert(len + ',' + minNumber + ','+maxNumber);
				}
				if ((minNumber!=-1 && maxNumber!=-1 && (len < minNumber || len > maxNumber)) || 
						 (minNumber!=-1 && maxNumber==-1 && (len < minNumber)) || 
						 (minNumber==-1 && maxNumber!=-1 && (len > maxNumber)) ||
						 (len == 0)){					
					return false;
				}
    	}else if (invalidType=='compare' && compareObjectId){
    		var obj = this.getObject(compareObjectId);
				if (obj==null || obj==undefined){
					alert('compare object id not exist for id [' + compareObjectId + ']');
					return false;
				}
    		var objt = this._getFormType(obj);
    		var objvalue = this.getForm(compareObjectId).value;
    		if (value!=objvalue){
					return false;
    		}
			}else if (invalidType=='int' || invalidType=='+int' || invalidType=='-int' || invalidType=='number' || invalidType=='+number' || invalidType=='-number'){
				var v = this.formatNumber(value);
				var isTrue = false;
				if (invalidType=='int' || invalidType=='+int' || invalidType=='-int'){
				  isTrue = !this.isInt(value,invalidType);
				}else if (invalidType=='number' || invalidType=='+number' || invalidType=='-number'){
				  isTrue = !this.isNumber(value,invalidType);
				}
				
				if ((minNumber!=-1 && maxNumber!=-1 && (v < minNumber || v > maxNumber)) || 
						 (minNumber!=-1 && maxNumber==-1 && (v < minNumber)) || 
						 (minNumber==-1 && maxNumber!=-1 && (v > maxNumber)) ||
						 (value == '') || isTrue){
					return false;
				}
			}else if (invalidType=='email'){
			  if (!this.checkEmail(value)){
			    return false;
				} 
			}else if (invalidType=='secondarydomain'){
			  var regStr = /^[A-Z|a-z|0-9]+$/;
			  if (!regStr.test(value)){
			    return false;
			  }
			}else if (invalidType=='domain'){
			  var regStr = /^[a-zA-Z0-9][-a-zA-Z0-9]{0,61}[a-zA-Z0-9](\.[a-zA-Z0-9][-a-zA-Z0-9]{0,61}[a-zA-Z0-9])+\.?$/;
			  if (!regStr.test(value)){
			    return false;
			  }
			}else if (invalidType=='file'){
			  if (!this.checkExt(value,exts)){
			    return false;
			  }
			}else if (invalidType=='in'){
			  if (this.checkContain(value,exts)){
			    return false;
			  }
			}else if (invalidType=='notin'){
			  if (!this.checkContain(value,exts)){
			    return false;
			  }
			}
		}else if (t=='checkbox' || t=='radio'){
		  if (notNull && !this.checkSelected(f)) return true;
		  if (minNumber == -1) minNumber = 1;
			if (!this.checkSelected(f,minNumber)){
				return false;
			}
		}
		return true;		
	},
	focusErrorLine:function(id,t,msg,containerid,errmsgid){
		var containerid = containerid;
		var errmsgid = errmsgid;
		var containerclassname = this.containerclassname;
		var errclassname = this.errclassname;
		if (!containerclassname) containerclassname = '.utr';
		if (!errclassname) errclassname = '.msgContent';
		
		var formlineobj = $(id+'_error_div');
		if (!formlineobj && containerclassname) formlineobj = $(this.getForm(id)).up(containerclassname);
		if (containerid && $(containerid)) formlineobj = $(containerid);		
		
		if (formlineobj){
			if (t=='error'){
		    formlineobj.addClassName(this.className);
			}else{
				formlineobj.removeClassName(this.className);
			}
		}
		var errormsgobj = $(id + '_error_msg');
		if (!errormsgobj && errclassname && formlineobj) errormsgobj = $(formlineobj).down(errclassname);
		if (errmsgid && $(errmsgid)) errormsgobj = $(errmsgid);		
		if (errormsgobj){
			errormsgobj.show();
			if (t=='error'){
				errormsgobj.removeClassName('okMsg');
		    errormsgobj.addClassName('errorMsg');
			}else{
				errormsgobj.removeClassName('errorMsg');
				errormsgobj.addClassName('okMsg');
			}
			var msgobj = errormsgobj.down('.msg');
			if (msgobj){
				msgobj.update(msg);
			}
		}		
	}
}
var objInvalid = new InvalidForm();
if (typeof msgPrefix!='undefined'){
  objInvalid.setMsgPrefix(msgPrefix);
}