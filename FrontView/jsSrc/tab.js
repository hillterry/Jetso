var MyTabPanel = Class.create();
MyTabPanel.prototype = {
  initialize: function() {
    var optionIndex = 0;
    this.options = Object.extend({
		}, arguments[optionIndex] || {});
		this.tabId = this.options.TabId;
		this.currentIndex = this.options.Index;
		this.id = this.options.Id;
		this.currentChild = null;
		var tab = $(this.tabId).firstChild;
		var child = tab.firstChild;
		this.tabChilds = [];
		this.contentChilds = [];
		var i = 0;
		
		while(child){
			child.id = this.tabId + "tab" + i
			child.tbid = this.id;
			child.index = i;
			this._setClickEvent(child,i);
			if (this.currentIndex==i){
			  this.currentChild = child;
				child.className = "Current";
			}else{
				child.className = "";
			}
			this.tabChilds[i] = child;
			child = child.nextSibling;
			i++;
		}
		this.totalIndex = i;
		
		i = 0;
		//content
		child = tab.nextSibling.firstChild;
		while(child){
			if (child.tagName=="FORM"){
				child1 = child.firstChild;
				while(child1){
					child1.id = this.tabId + "tabcontent" + i;
					if (this.currentIndex == i){
						child1.style.display = "";
					}else{
						child1.style.display = "none";
					}
					this.contentChilds[i] = child1;
					child1 = child1.nextSibling;
					i++;
				}
			}
			//alert("div:" + i + ":" + child.tagName + "," + child.className + ":" + (child.tagName=="DIV" && child.className=="TabPanContent"));
			if (child.tagName=="DIV" && child.className=="TabPanContent"){
				child.id = this.tabId + "tabcontent" + i;
				if (this.currentIndex == i){
					child.style.display = "";
				}else{
					child.style.display = "none";
				}
				//alert(i + ":" + child.tagName);
				this.contentChilds[i] = child;
				child = child.nextSibling;
				i++;
			}else{
				child = child.nextSibling;
			}
		}
  },
	
	_setClickEvent: function(child,i){
	  child.onclick = function(){
		  var tb = eval(this.getAttribute("tbid"));
			if (this==tb.currentChild) return ;
			this.className = "Current";
			tb.currentChild.className = "";
      var index = parseInt(tb.currentChild.getAttribute("index"));
			tb.contentChilds[index].style.display = "none";
			tb.currentChild = this;
			index = parseInt(this.getAttribute("index"));
			tb.contentChilds[index].style.display = "";
		}
	},
	
	showTab: function(index){
		this.tabChilds[index].click();
	}
}

function addListener(element, type, expression, bubbling){	
  bubbling = bubbling || false;		
  if(window.addEventListener)	{ 
    // Standard		
    element.addEventListener(type, expression, bubbling);		
    return true;	
  } else if(window.attachEvent) { 
    // IE		
		element.attachEvent('on' + type, expression);		
    return true;	
  } else 
    return false;
}