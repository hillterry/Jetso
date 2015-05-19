var speed = 5;
var MyMar;

function getObj(n, d) { //v4.01
	var p,i,x; if(!d) d=document; if((p=n.indexOf("?"))>0&&parent.frames.length) {
	d=parent.frames[n.substring(p+1)].document; n=n.substring(0,p);}
	if(!(x=d[n])&&d.all) x=d.all[n]; for (i=0;!x&&i<d.forms.length;i++) x=d.forms[i][n];
	for(i=0;!x&&d.layers&&i<d.layers.length;i++) x=getObj(n,d.layers[i].document);
	if(!x && d.getElementById) x=d.getElementById(n); return x;
}

function cStartScroll(dir){
	var objDiv = $("divContent");
	var objTab = $("tabContent");
	var offset = 0;
	if (dir=="UP"){
		offset = 1;
		if (objTab.offsetHeight-objDiv.scrollTop>objDiv.offsetHeight){
			objDiv.scrollTop+=offset;
		}
	}else if (dir=="DOWN"){
		offset = -1;
		if (objDiv.scrollTop>0){
			objDiv.scrollTop+=offset;
		}
	}else if (dir=="LEFT"){
		offset = 1;
		if (objTab.offsetWidth-objDiv.scrollLeft >objDiv.offsetWidth){
			objDiv.scrollLeft +=offset;
		}
	}else if (dir=="RIGHT"){
		offset = -1;
		if (objDiv.scrollLeft>0){
			objDiv.scrollLeft +=offset;
		}
	}
}

function cStopScroll(){
	clearInterval(MyMar)
}
function InitScroll(){
	var objDiv = $("divContent");
	if (objDiv){
  	var objTab = $("tabContent");
		if (objTab.offsetWidth > objDiv.offsetWidth){
			$('btnLeft').onmouseover = function(){MyMar=setInterval("cStartScroll('RIGHT')",speed)}
			$('btnLeft').onmouseout = function(){cStopScroll()}
			$('btnRight').onmouseover = function(){MyMar=setInterval("cStartScroll('LEFT')",speed)}
			$('btnRight').onmouseout = function(){cStopScroll()}
		}else{
			//objRollPage.style.display = "none";
		}
	}
	//InitPicScroll();
}

function MenuPosition(){
	var topids = getObj("topId");
	//alert(topids);
	if (topids!=null){
		var top = 0;
		//alert(Element.getHeight(topids[0]));
		for (var i=0;i<topids.length;i++){
			top += Element.getHeight(topids[i]);
		}
		var objDiv = getObj("divContent");
		if (top - 180>0){
			objDiv.scrollTop = top - 180 -5;
		}
	}
}

var picScroll;
//通用上下，左右连续滚动，跑马灯
function MarqueeTest(direct,MainId,contentId,copyId){
  var objMain = getObj(MainId);
	var objContent = getObj(contentId);
	var objCopy = getObj(copyId);
	var mainWidth = objMain.offsetWidth
	var contentWidth = objContent.offsetWidth
	var copyWidth = objCopy.offsetWidth;
	var mainHeight = objMain.offsetHeight;
	var contentHeight = objContent.offsetHeight;
	var copyHeight = objCopy.offsetHeight;
	var debugTxt = "";
	if (direct=="LEFT"){
		debugTxt += "tdPic2 Width :" + copyWidth + "<BR>";
		debugTxt += "divPic scroll Left :" + objMain.scrollLeft + "<BR>";
		debugTxt += "Off Set:" + (copyWidth-objMain.scrollLeft);
		//aaa.innerHTML = debugTxt;
		if (copyWidth-objMain.scrollLeft<=69){
			objMain.scrollLeft-=contentWidth;
		}else{
			objMain.scrollLeft+=2;
		}
	}else if (direct=="RIGHT"){
		if (copyWidth-mainWidth-objMain.scrollLeft>=0){
			objMain.scrollLeft=contentWidth + copyWidth - mainWidth;
		}else{
			objMain.scrollLeft-=2;
		}
	}else if (direct=="UP"){
		if (copyHeight-objMain.scrollTop<=0){
			objMain.scrollTop-=contentHeight;
		}else{
			objMain.scrollTop+=2;
		}
	}else if (direct=="DOWN"){
		if (copyHeight-mainHeight-objMain.scrollTop>=0){
			objMain.scrollTop=contentHeight + copyHeight - mainHeight;
		}else{
			objMain.scrollTop-=2;
		}
	}
}

function InitPicScroll(){
	var objMain = getObj("divPic");
	if (objMain!=null){
		var objCopy = getObj("tdPic2");
		var mainWidth = objMain.offsetWidth
		var copyWidth = objCopy.offsetWidth;
		if (copyWidth > mainWidth){
      picScroll = setInterval("MarqueeTest('LEFT','divPic','tdPic1','tdPic2')",speed);
      objMain.onmouseover=function() {clearInterval(picScroll)}
      objMain.onmouseout=function() {picScroll=setInterval("MarqueeTest('LEFT','divPic','tdPic1','tdPic2')",speed)}
		}else{
			objCopy.style.display = "none";
		}
	}
}