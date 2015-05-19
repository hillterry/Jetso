var SmeCalendar = new SmeCalendar();
function SmeCalendar(){
	this.text_prev_year = "Prev Year";
	this.text_prev_month = "Prev Month";
	this.text_next_year = "Next Year";
	this.text_next_month = "Next Month";
	this.text_time = "Time";
	
	this.calendar_class_name = "calendarFrame";
	this.calendar_z_index = 100000;
	this.calendar_day_names = new Array("Su","Mo","Tu","We","Th","Fr","Sa");
	this.calendar_date_reg = /^(\d{1,4})(-|\/)(\d{1,2})\2(\d{1,2})$/;
	this.calendar_date_time_reg = /^(\d{1,4})(-|\/)(\d{1,2})\2(\d{1,2}) (\d{1,2}):(\d{1,2})$/;
	this.calendar_date_time_second_reg = /^(\d{1,4})(-|\/)(\d{1,2})\2(\d{1,2}) (\d{1,2}):(\d{1,2}):(\d{1,2})$/;	
	this.calendar_year_prev_length = 70;
	this.calendar_year_next_length = 10;
	this.calendar_is_time = false;
	
	this.left = 0;
	this.top = 0;
	this.parent = document.body;
	this.current_day = new Date();
	this.id = "_calendar_12345678";// + new Date().getTime();
	this.handle = null;
	this.current_day_string = "";
	this.return_object_type = "input";
	this.return_object = null;
	this.left = 0;
	this.top = 0;
	this.days_container = null;
	this.operation_container = null;
	this.time_container = null;
  this.select_day = null;	
	this._calendar_document_click = false;
	
	this._createDay = function(d){
		var start_offset_day = 0;
		var dd = new Date(d.getFullYear(),d.getMonth(),1);
		var current_month_first_day_week = dd.getDay();
		var current_month_max_day = this.getMonthDays(d);
		var prev_month_max_day = this.getPrevMonthDays(d);
		start_offset_day = -current_month_first_day_week;
		this.days_container.innerHTML = "";
		var h = "";
		var view_days = 0;
		var view_next_month_days = 0;
		var calendar_html = "";
		var day_id = "";
		for(var i=0;i<=6;i++){
		  if (i==0) h += '<dt class="thead">';
			if (i==1) h += '<dt class="tbody">';
			for(var j=0;j<7;j++){
				if (i==0){
					h += '<span>' + this.calendar_day_names[j] + '</span>';
				}else{
					if (i==1 && j==0){
						for(var n=start_offset_day+1;n<=0;n++){
							h += this._createViewDate(d,prev_month_max_day+n,"prev");
							j++;
						}
					}
					view_days ++;
					if (view_days<=current_month_max_day){
						h += this._createViewDate(d,view_days);
					}else{
						view_next_month_days ++;
						h += this._createViewDate(d,view_next_month_days,"next");
					}
				}
			}
			if (i==0) h += '</dt>';
			if (i==6) h += '</dt>';
		}
		this.days_container.innerHTML = h;
	};
	this._viewDate = function(ds){
	  return $(this.id + '_view_date').innerHTML = this.formartDate(Date.parse(ds));
	};
	this._createViewDate = function(d,day,type){
	  var dayView = this.appendZero(day);
		var css = "";
		var viewDate = this.getYearMonth(d) + '-' + dayView;
		var id = this.id + viewDate;
		if (this.current_day.getFullYear()==d.getFullYear()&& this.current_day.getMonth()==d.getMonth() && this.current_day.getDate()==day){
		  css = ' class="select" '
			this.select_day = id;
		}
		var now = new Date();
		if (now.getFullYear()==d.getFullYear() && now.getMonth()==d.getMonth() && now.getDate()==day){
		  css = ' class="current" '
		}

		if (!type){
			return '<a ' + css + ' href="javascript:void(0);" title="' + viewDate + '" id="' + id + '" onclick="SmeCalendar.returnDate(this)" onmouseover="SmeCalendar._viewDate(\'' + viewDate + '\')" hidefocus="true">' + day + '</a> ';
		}else if (type=="prev"){
			return '<span></span>';//<a ' + css + ' href="javascript:void(0);" title="' + this.getPrevYearMonth(d) + "-" + day + '" id="' + id + '" onclick="SmeCalendar.returnDate(this)">' + day + '</a> ';
		}else if (type=="next"){
			return '<span></span>';//'<a ' + css + ' href="javascript:void(0);" title="' + this.getNextYearMonth(d) + "-" + day + '" id="' + id + '" onclick="SmeCalendar.returnDate(this)">' + day + '</a> ';
		}	
	};
	this._createTime = function(d){
  	var hour = '';
  	var minute = '';
  	if (this.calendar_is_time){
	  	for(var i=0;i<24;i++){
	  		hour +='<option value="'+i+'" ' + (i==d.getHours()?'selected':'') + '>'+i+'</option>';
	  	}
	  	for(var i=0;i<60;i++){
	  		minute +='<option value="'+i+'" ' + (i==d.getMinutes()?'selected':'') + '>'+i+'</option>';
	  	}
			var timePanel = document.createElement("p");
			timePanel = $(timePanel);
			timePanel.setAttribute('id', this.id+'_container_time');
			
			timePanel.innerHTML = '<label>' + this.text_time + '\
	    	: <select id="'+this.id + '_time_hour" name="'+this.id + '_time_hour">\
	    	'+ hour + '\
	    	</select></label>:\
	    	<label><select id="'+this.id + '_time_minute" name="'+this.id + '_time_minute">\
	    	'+ minute + '\
	    	</select></label>';
	    this.operation_container.insertBefore(timePanel,this.operation_container.firstChild);
	    this.time_container = $(this.id + '_container_time');
			this.time_hour = $(SmeCalendar.id + '_time_hour');
			this.time_minute = $(SmeCalendar.id + '_time_minute');
  	}
	};
  this._createOperation = function(d){
    this.operation_container.innerHTML = '<dl>\
      <dt class="goUpBox"><a href="#" class="goUpY" id="' + this.id + '_prev_year_handle" title="'+ this.text_prev_year +'" hidefocus="true">&lt;&lt;</a><a href="#" class="goUpM" id="' + this.id + '_prev_month_handle" title="'+ this.text_prev_month +'" hidefocus="true">&lt;</a></dt>\
      <dt class="goSelectBox">' + this._createYear(d) + '\
			  <select id="' + this.id + '_month_list" name="' + this.id + '_month_list"></select>\
      </dt>\
      <dt class="goDownBox"><a href="#" class="goDownM" id="' + this.id + '_next_month_handle" title="'+ this.text_next_month +'" hidefocus="true">&gt;</a><a href="#" class="goDownY" id="' + this.id + '_next_year_handle" title="'+ this.text_next_year +'" hidefocus="true">&gt;&gt;</a></dt>\
    </dl>';

		this.year_list = $(SmeCalendar.id + '_year_list');
		this.month_list = $(SmeCalendar.id + '_month_list');
		
		this.year_list.onchange = function(){
			SmeCalendar._createDay(new Date(this.value,SmeCalendar.month_list.value,1));
		}
		
		this.month_list.onchange = function(){
			SmeCalendar._createDay(new Date(SmeCalendar.year_list.value,this.value,1));
		}
		this.prev_year = $(this.id + '_prev_year_handle');
		this.prev_month = $(this.id + '_prev_month_handle');
		this.next_year = $(this.id + '_next_year_handle');
		this.next_month = $(this.id + '_next_month_handle');
		this.prev_year.onclick = function(){
		  if (SmeCalendar.year_list.selectedIndex+1<=SmeCalendar.year_list.length){
		    SmeCalendar.year_list.options[SmeCalendar.year_list.selectedIndex+1].selected = true;
				SmeCalendar._createDay(new Date(SmeCalendar.year_list.value,SmeCalendar.month_list.value,1));
			}
		  return false;
		}
		this.prev_month.onclick = function(){
		  if (SmeCalendar.month_list.selectedIndex==0){
			  SmeCalendar.month_list.options[SmeCalendar.month_list.length-1].selected = true;
				SmeCalendar.year_list.options[SmeCalendar.year_list.selectedIndex+1].selected = true;
			}else{
		    SmeCalendar.month_list.options[SmeCalendar.month_list.selectedIndex-1].selected = true;
			}
			SmeCalendar._createDay(new Date(SmeCalendar.year_list.value,SmeCalendar.month_list.value,1));
			return false;
		}
		this.next_year.onclick = function(){
		  if (SmeCalendar.year_list.selectedIndex-1>=0){
		    SmeCalendar.year_list.options[SmeCalendar.year_list.selectedIndex-1].selected = true;
				SmeCalendar._createDay(new Date(SmeCalendar.year_list.value,SmeCalendar.month_list.value,1));
			}
		  return false;
		}
		this.next_month.onclick = function(){
		  if (SmeCalendar.month_list.selectedIndex==SmeCalendar.month_list.length-1){
			  SmeCalendar.month_list.options[0].selected = true;
				SmeCalendar.year_list.options[SmeCalendar.year_list.selectedIndex-1].selected = true;
			}else{
		    SmeCalendar.month_list.options[SmeCalendar.month_list.selectedIndex+1].selected = true;
			}
			SmeCalendar._createDay(new Date(SmeCalendar.year_list.value,SmeCalendar.month_list.value,1));
			return false;
		}
	};
	this._createMonth = function (d){
		var objMonth = this.month_list;
		for(i=0;i<=11;i++){
			objMonth.options[objMonth.length++].value=i;
			objMonth.options[i].text=i+1;
		}
		objMonth.options[d.getMonth()].selected=true;
	};
	
	this._createYear = function(d){
		var h = '<select id="' + this.id + '_year_list" name="' + this.id + '_year_list">';
		var y = new Date().getFullYear();
		for (var i=y+this.calendar_year_next_length;i>=y-this.calendar_year_prev_length;i--){
			h +='<option value="' + i + '" ' + (i==d.getFullYear()?"selected":"") + '>' +  i + '</option>';
		}
		h +='</select>';
		return h;
	};
	
	this.returnDate = function(obj){
	  var dateString = obj.title;
		var ds = dateString.split("-");
		ds[1]=this.appendZero(ds[1]);
		ds[2]=this.appendZero(ds[2]);
		dateString = ds[0] + "-" + ds[1] + "-" + ds[2];
		
		this.current_day = new Date(ds[0],parseInt(ds[1],10)-1,ds[2]);
		if (this.select_day){
		  if ($(this.select_day)){
		    $(this.select_day).removeClassName("select");
			}
		}
		this.select_day = obj.id;
		$(obj).addClassName("select");
		if (this.calendar_is_time){
			dateString += " " + this.appendZero(this.time_hour.value) + ":" + this.appendZero(this.time_minute.value);
		}
		if (this.return_object_type=='input'){
		  this.return_object.value = dateString;
		}else if (this.return_object_type=='container'){
			this.return_object.innerHTML=dateString;
		}else{
		  return dateString;
		}
		this.closeCalendar();
	};
	
	this.closeCalendar = function(){
	  this.select_day = null;
		this.current_day_string = "";
		this.return_object_type = "input";
		this.return_object = null;
		this.left = 0;
		this.top = 0;
		if (this.handle){
		  this.handle.hide();
		}
	};

  this.appendZero = function (n){return(("00"+ n).substr(("00"+ n).length-2));};

	this.getMonthDays = function(d){
		return new Date(d.getFullYear(),d.getMonth()+1,0).getDate();
	};
	this.getPrevMonthDays = function(d){
		return new Date(d.getFullYear(),d.getMonth(),0).getDate();
	};
	this.getYearMonth = function(d){
		return d.getFullYear() + "-" + (d.getMonth()+1);
	};
	this.getPrevYearMonth = function(d){
		if (d.getMonth()==0){
			return (d.getFullYear()-1) + "-" + 12;
		}else{
			return d.getFullYear() + "-" + d.getMonth();
		}
	};
	this.getNextYearMonth = function(d){
		if (d.getMonth()==11){
			return (d.getFullYear()+1) + "-" + 1;
		}else{
			return d.getFullYear() + "-" + (d.getMonth()+2);
		}
	};
	this.formartDate = function(d){
	  return d.toString('yyyy-MM-dd dddd');
	  return d.getFullYear() + '-' + this.appendZero(d.getMonth()) + '-' + d.getDate();
	};
	this.InitSetting = function(){
	  if (typeof text_prev_year!='undefined') this.text_prev_year = text_prev_year;
	  if (typeof text_prev_month!='undefined') this.text_prev_month = text_prev_month;
	  if (typeof text_next_year!='undefined') this.text_next_year = text_next_year;
	  if (typeof text_next_month!='undefined') this.text_next_month = text_next_month;
	  if (typeof text_time!='undefined') this.text_time = text_time;
		if (typeof calendar_class_name!='undefined') this.calendar_class_name = calendar_class_name;
		if (typeof calendar_day_names!='undefined') this.calendar_day_names = calendar_day_names;
		if (typeof calendar_date_reg!='undefined') this.calendar_date_reg = calendar_date_reg;
		if (typeof calendar_year_prev_length!='undefined') this.calendar_year_prev_length = calendar_year_prev_length;
		if (typeof calendar_year_next_length!='undefined') this.calendar_year_next_length = calendar_year_next_length;
	}
}
	
function calendar(){
	SmeCalendar._calendar_document_click = true;
	SmeCalendar.InitSetting();
	var options = Object.extend({className:SmeCalendar.calendar_class_name,
		zIndex:SmeCalendar.calendar_z_index,
		istime:SmeCalendar.calendar_is_time}, arguments[1] || {});
	if (arguments[0]){
		var object = arguments[0];
		if (typeof object=="object"){
			object = $(object);
			if (object.tagName){
				if (object.tagName == "INPUT"){
					SmeCalendar.current_day_string = object.value;
					SmeCalendar.return_object_type = "input";
				}else{
					SmeCalendar.current_day_string = object.innerHTML;
					SmeCalendar.return_object_type = "container";
				}
				var scroll = document.viewport.getScrollOffsets();
				SmeCalendar.left = object.viewportOffset()[0]+scroll[0];
				SmeCalendar.top = object.viewportOffset()[1] + object.getHeight() + scroll[1];
				//Debug(scrollTop);
				//Debug(object.tagName + ";" + SmeCalendar.return_object_type + ";[" + object.viewportOffset()[0] + "," + object.viewportOffset()[1] + "]");
			}
			SmeCalendar.return_object = object;
		}else{
			SmeCalendar.current_day_string = object;
		}
		//SmeCalendar.return_object.innerHTML='2008-07-05';
		if (!SmeCalendar.current_day_string) SmeCalendar.current_day_string = "";
		
		if (options.istime){
			var current_date_style = SmeCalendar.current_day_string.match(SmeCalendar.calendar_date_time_reg);
			if (current_date_style!=null){
				SmeCalendar.current_day = new Date(parseInt(current_date_style[1],10),parseInt(current_date_style[3],10)-1,parseInt(current_date_style[4],10),parseInt(current_date_style[5],10),parseInt(current_date_style[6],10));
			}else{
				current_date_style = SmeCalendar.current_day_string.match(SmeCalendar.calendar_date_reg);
				if (current_date_style!=null){
					SmeCalendar.current_day = new Date(parseInt(current_date_style[1],10),parseInt(current_date_style[3],10)-1,parseInt(current_date_style[4],10),0,0);
				}else{
				  SmeCalendar.current_day = new Date();
				}
			}
		}else{
			var current_date_style = SmeCalendar.current_day_string.match(SmeCalendar.calendar_date_reg);
			if (current_date_style!=null){
				SmeCalendar.current_day = new Date(parseInt(current_date_style[1],10),parseInt(current_date_style[3],10)-1,parseInt(current_date_style[4],10));
			}else{
			  SmeCalendar.current_day = new Date();
			}
		}
	}
  SmeCalendar.calendar_class_name = options.className;
  SmeCalendar.calendar_z_index = options.zIndex;
  SmeCalendar.calendar_is_time = options.istime;

	if (!SmeCalendar.handle){
		var calendarPanel = document.createElement("div");
		calendarPanel = $(calendarPanel);
		calendarPanel.setAttribute('id', SmeCalendar.id);
		calendarPanel.setStyle({zIndex:SmeCalendar.calendar_z_index});
		calendarPanel.className = SmeCalendar.calendar_class_name;
		if (options.istime){
		  calendarPanel.addClassName("calendarOrTimes");
		}else{
			calendarPanel.addClassName("calendarOnly");
		}
		calendarPanel.innerHTML = '<div class="calendarSkin">\
			<div class="calendarhd"> <strong id="' + SmeCalendar.id + '_view_date">' + (SmeCalendar.formartDate(SmeCalendar.current_day)) + '</strong> <span class="calendarControlBar"><a href="#" class="closeBtn" id="' + SmeCalendar.id + '_close_calendar" onclick="SmeCalendar.closeCalendar();return false;">Close</a></span> </div>\
			<div class="calendarContent">\
				<dl class="calendarDayList" id="' + SmeCalendar.id + '_days_container">\
				</dl>\
			</div>\
			<div class="calendarft" id="' + SmeCalendar.id + '_operation_container">\
			</div>\
		</div>';
		
		
		if (!SmeCalendar.parent){
			SmeCalendar.parent = document.body;
		}
		SmeCalendar.parent.insertBefore(calendarPanel,SmeCalendar.parent.firstChild);
		SmeCalendar.handle = $(SmeCalendar.id);
		SmeCalendar.days_container = $(SmeCalendar.id + '_days_container');
		SmeCalendar.operation_container = $(SmeCalendar.id + '_operation_container');
		
		SmeCalendar._createDay(SmeCalendar.current_day);
		
		SmeCalendar._createOperation(SmeCalendar.current_day);
		if (options.istime){
		  SmeCalendar._createTime(SmeCalendar.current_day);
		}
		SmeCalendar._createMonth(SmeCalendar.current_day);
		SmeCalendar.handle.onclick = function(){
		  SmeCalendar._calendar_document_click = true;
		}
	}else{
		SmeCalendar._createDay(SmeCalendar.current_day);
		SmeCalendar._createOperation(SmeCalendar.current_day);
		SmeCalendar._createMonth(SmeCalendar.current_day);
		if (options.istime){
			SmeCalendar.handle.removeClassName("calendarOnly");
			SmeCalendar.handle.addClassName("calendarOrTimes");
			SmeCalendar._createTime(SmeCalendar.current_day);
		}else{
			SmeCalendar.handle.removeClassName("calendarOrTimes");
			SmeCalendar.handle.addClassName("calendarOnly");
			if (SmeCalendar.time_container){
				SmeCalendar.time_container.remove();
			}
		}
	}

	SmeCalendar.handle.setStyle({left:SmeCalendar.left + 'px',top:SmeCalendar.top + 'px'});
	SmeCalendar.handle.show();
}

function closeCalendarClick(e){
  if (SmeCalendar._calendar_document_click){ 
	  SmeCalendar._calendar_document_click = false; return false;
	}else{
	  SmeCalendar.closeCalendar();
	}
}
Event.observe(document, "click", closeCalendarClick);