// JavaScript Document
function DateDemo(){
	var d, day, x, s = "";
	var x = new Array("星期日", "星期一", "星期二");
	var x = x.concat("星期三","星期四", "星期五");
	var x = x.concat("星期六");
	d = new Date();
	day = d.getDay();
	return(s += x[day]);
}

function showNowTime(d,f){
	var dateObj = d;
	var year = dateObj.getFullYear();
	var mouth = dateObj.getMonth();
	var date = dateObj.getDate();
	var hour = dateObj.getHours();
	var minute = dateObj.getMinutes();
	var seconds = dateObj.getSeconds();
	var timeResult = "";
	if (f==1){
		timeResult = year + "-" + addZero(mouth+1) + "-" + addZero(date) + " " + addZero(hour) + ":" + addZero(minute) + ":" + addZero(seconds);
	}else if (f==2){
		timeResult = year + "-" + addZero(mouth+1) + "-" + addZero(date) + " " + addZero(hour) + ":" + addZero(minute)
	}else if (f==3){
		timeResult = year + "-" + addZero(mouth+1) + "-" + addZero(date)
	}
	return timeResult;
}

function addZero(intNum){
	intNum = (intNum<10)?("0"+intNum.toString()):intNum;
	return intNum;
}

function showdatetime(){
	return showNowTime(new Date(),1) + "﹝" + DateDemo() + "﹞";
}

function showtime(){
	return showNowTime(new Date(),2) + "﹝" + DateDemo() + "﹞";
}
