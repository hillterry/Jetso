// JavaScript Document
function subString(s,v){
	var pos,epos,ss;
	ss = ", " + v + ",";
	pos = s.indexOf(ss);
	if (pos !=-1) {
		epos = s.indexOf(",",pos+ss.length)
		return s.substr(pos+ss.length+1,epos - (pos+ss.length)-1);
	}
	return "";
}
function InitOption(objOption,vars){
  if (objOption != null){
    if(objOption.length==null){
		  objOption.checked = ((", " + vars + ",").indexOf(", " + objOption.value + ",")!=-1);
    }else{
			var otherValue = subString((", " + vars + ","),"other");
      for (i = 0 ; i< objOption.length ; i++){
				if (objOption[i].type=="text"){
					if (otherValue!=""){
			      objOption[i-1].checked = true;
						objOption[i].value = otherValue;
					}else{
			      objOption[i-1].checked = false;
						objOption[i].value = "";
					}
				}else{
					objOption[i].checked = ((", " + vars + ",").indexOf(", " + objOption[i].value + ",")!=-1);
				}
      }
    }
  }
}

function SelectOK(objDiv,objOption,srcText){
  var tmp;
	tmp = "";
  if (objOption != null){
    if(objOption.length==null){
			tmp = (objOption.checked?(", " + objOption.value):"");
			objOption.checked = false;
    }else{
      for (i = 0 ; i< objOption.length ; i++){
				if (objOption[i].type=="text"){
			    tmp +=trim(objOption[i].value)==""?"":", " + trim(objOption[i].value);
				}else{
					tmp +=(objOption[i].checked?(", " + objOption[i].value):"");
				  objOption[i].checked = false;
				}
      }
    }
		if (tmp!=""){
		  tmp = tmp.substr(2);
		}
		srcText.value = tmp;
  }
	objDiv.style.display = "none";
}

function SelectCancel(objDiv,objOption){
  ClearSelected(objOption,-1);
	objDiv.style.display = "none";
}

function ExchangeDiv(divId){
  var objDiv1 = getObject("selectGrade");
	var objDiv2 = getObject("selectSubject");
	var objDiv3 = getObject("selectArea");
	var objDiv4 = getObject("selectTime");
	if (objDiv1.style.display == "" && divId!="selectGrade")SelectCancel(objDiv1,document.frmSearch.GradeOption);
	if (objDiv2.style.display == "" && divId!="selectSubject")SelectCancel(objDiv2,document.frmSearch.GradeOption);
	if (objDiv3.style.display == "" && divId!="selectArea")SelectCancel(objDiv3,document.frmSearch.GradeOption);
	if (objDiv4.style.display == "" && divId!="selectTime")SelectCancel(objDiv4,document.frmSearch.GradeOption);
}

function FunSelect(divId,objBtn,optionName,textName,postion,offsetHeight){
  ExchangeDiv(divId)
  var objFrm = document.frmSearch;
  var objDiv = getObject(divId);
	var x = mpageX(objBtn);
	var y = mpageY(objBtn);
	
	var w = getW(objBtn);
	var h = getH(objBtn);
	var objOption = eval("objFrm." + optionName);
	var objText = eval("objFrm." + textName);

	InitOption(objOption,objText.value);
	objDiv.style.display = "";
	var divw = getW(objDiv);
	if (postion=="left"){
	  x = x + w - divw;
	}
	if (oBw.ie) y = (y+h) - offsetHeight;
	objDiv.style.top = (y + h)+"px";
	objDiv.style.left = x+"px";
}
if (document.all) {
document.attachEvent('onclick', hiddenOption);
document.attachEvent('onclick', hiddenOption);
}
else {
document.addEventListener('click', hiddenOption, false);
document.addEventListener('click', hiddenOption, false);
}
var currentDiv=0;
function setCurrentDiv(tag){
	currentDiv = tag;
}
function hiddenOption(){
  var objDiv1 = getObject("selectGrade");
	if (objDiv1!=null){
		var objDiv2 = getObject("selectSubject");
		var objDiv3 = getObject("selectArea");
		var objDiv4 = getObject("selectTime");
		var objBtn1 = getObject("btnSelectGrade");
		var objBtn2 = getObject("btnSelectSubject");
		var objBtn3 = getObject("btnSelectArea");
		var objBtn4 = getObject("btnSelectTime");
	
		if(objDiv1 != window.event.srcElement && 
			 objDiv2 != window.event.srcElement && 
			 objDiv3 != window.event.srcElement && 
			 objDiv4 != window.event.srcElement &&
			 objBtn1 != window.event.srcElement && 
			 objBtn2 != window.event.srcElement && 
			 objBtn3 != window.event.srcElement && 
			 objBtn4 != window.event.srcElement &&
			 currentDiv == 0
			 ){
			ExchangeDiv('');
		}
	}
}

function InputOtherInfo(objSel,inputFormId){
	var objInputForm = getObject(inputFormId);
	objInputForm.style.display = ((objSel.value=="other")?"":"none");
	if (objSel.value=="other"){	objInputForm.focus();}
}

function CheckIsSelectedOther(obj){
	var ischeck = 0;
	if (obj != null){
		if(obj.length==null){
			if (obj.checked == true) ischeck = true;
		}else{
			for (i = 0 ; i< obj.length ; i++){
				if (obj[i].checked == true){
					if (obj[i].value=="other"){
						if (i+1<=obj.length){
						  if (trim(obj[i+1].value)==""){
							  ischeck = 2;
								obj[i+1].focus();
								break;
							}else{
								ischeck = 1;
								//break;
							}							
						}
					}else{
					  ischeck = 1;
					  //break;
					}
				}
			}
		}
	}
	return ischeck;
}