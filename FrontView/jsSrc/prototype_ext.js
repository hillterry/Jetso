// JavaScript Document
Element.addMethods({
	ajaxUpdate: function(element, url, options) {
		element = $(element);
		//element.update('<img src="/images/spinner.gif" alt="loading..." />');
		new Ajax.Updater(element, url, options);
		return element;
	}
});
function treeOpen(id){
	var e=$(id).up('li');
	var eAll=$(id).up('li').siblings();
	eAll.invoke('removeClassName','open');
	e.toggleClassName('open');
}
var dropDownMenu = Class.create();
dropDownMenu.prototype = {
    initialize:function(cls){
			this.cls=cls;
			this.init();
			//alert(this.cls);	
    },
    init:function(){
				var menu = $$("'" + this.cls + '> li');
				$$("'" + this.cls + '> li').each(function(o,index){					
						var popMenu = o.down('div.popMenuBox');
						if(popMenu) popMenu.setStyle({display:"none"});
            o.observe("mouseover",function(){
							alert(index)
								o.addClassName('hover');								
								if(popMenu) new Effect.SlideDown(popMenu);								
							});
            o.observe("mouseout",function(){
								o.removeClassName('hover');								
								if(popMenu){
									//new Effect.SlideUp(popMenu);
									//popMenu.setStyle({display:"none"});
								}							
							});
        });
    }
};


var dropliciousMenu = Class.create({
	// Properties
	showingUpDuration: 0.3,
	hidingDuration: 0.1,
	hideDelay: 0,
	
	initialize: function(id){
		this.id=id;
		var menu= $$("'" + this.id + '> li');
		var dropDownMenu = $$("'" + this.id + '> li > a.uA');
		var subMenu = $$("'" + this.id + '> li > div.popMenuBox');
		
		if(subMenu) subMenu.invoke('setStyle',{display:"none"});
		//menu.invoke('observe', 'mousemove', this.menuOver.bind(this));
		//menu.invoke('observe', 'mouseout', this.menuOut.bind(this));
		dropDownMenu.invoke('observe', 'mousemove', this.linkMouseOver.bind(this));
		dropDownMenu.invoke('observe', 'mouseout', this.linkMouseOut.bind(this));		
		subMenu.invoke('observe', 'mousemove', this.submenuMouseOver.bind(this));
		subMenu.invoke('observe', 'mouseout', this.submenuMouseOut.bind(this));
		
		
		//$$("a.drops").invoke('observe', 'mousemove', this.linkMouseOver.bind(this));
//		$$("a.drops").invoke('observe', 'mouseout', this.linkMouseOut.bind(this));
//		
//		$$("ul.licious").invoke('observe', 'mousemove', this.submenuMouseOver.bind(this));
//		$$("ul.licious").invoke('observe', 'mouseout', this.submenuMouseOut.bind(this));
		
	},
	
	// Default Effects
	// It's possible to set user's effects handlers
	// eg: myDropliciousInstance.showUpEffect = function(){ * user's effect * };
	showUpEffect: function(e, effectDuration){		
		if(!e.visible()){
			new Effect.BlindDown(e, {
				duration: effectDuration,
				queue: {
					position: 'end',
					scope: e.identify(),
					limit: 2
				}
			});
		}
	},

	hidingEffect: function(e, effectDuration){
		new Effect.BlindUp(e, {
			duration: effectDuration,
			queue: {
				position: 'end',
				scope: e.identify(),
				limit: 2
			}
		});
	},

	menuOut: function(e){
		var menuElement = e.element();
		menuElement.removeClassName('hover');
	},

	menuOver: function(e){
		var menuElement = e.element();		
		menuElement.addClassName('hover');			
	},
	
	// Mouse event handlers
	linkMouseOut: function(e){
		var dropElement = e.findElement("a").next();
		//dropElement.up('li').removeClassName('hover');
		//var dropElement = e.element().next();		
		if (dropElement && dropElement.hasClassName('active')){
			this.setDelayedHide(dropElement);
		}
	},

	linkMouseOver: function(e){
		var dropElement = e.findElement("a").next();
		//if (dropElement.up('li').hasClassName('hover'))dropElement.up('li').addClassName('hover');
		//alert(dropElement);
		//var dropElement = e.element().next();
		// Additional check if something wrong with menu structure
		if(!dropElement){
			return;
		}

		if (!dropElement.hasClassName('hidding')){
			dropElement.removeClassName('waitingtohide');
		}
		
		if (!dropElement.hasClassName('active')){
			dropElement.addClassName('active');
			this.showUpEffect(dropElement, this.showingUpDuration);
		}
	},

	submenuMouseOut: function(e){
		var dropElement = e.findElement("div.popMenuBox");		
		if (dropElement && dropElement.hasClassName('active')){
			this.setDelayedHide(dropElement);			
		}
	},

	submenuMouseOver: function(e){
		var dropElement = e.findElement("div.popMenuBox");		
		if (dropElement && !dropElement.hasClassName('hidding')){
			dropElement.removeClassName('waitingtohide');			
		}
	},

	// Delayed  methods, needed for smooth subMenu hiding
	setDelayedHide: function(e){
		e.addClassName('waitingtohide')
		if(!e.hasClassName('hidding')){
			if (!e.hasClassName('hiddingtimerset')){	
				e.addClassName('hiddingtimerset');
				(function(obj, e){ obj.delayedHide(e); }).delay(this.hideDelay, this, e);
			}
		}
	},

	delayedHide: function(e){
		e.removeClassName('hiddingtimerset');
		if (e.hasClassName('waitingtohide')){
			this.hidingEffect(e, this.hidingDuration);
			e.addClassName('hidding');
			//Changed to Prototype's API manner
			(function(e){
				e.removeClassName('waitingtohide');
				e.removeClassName('hidding');
				e.removeClassName('active');
			}).delay(this.hidingDuration, e);

		}
	}

});

document.observe("dom:loaded",function(){
	new dropliciousMenu("#mainnav");
 //var newMenu = new dropDownMenu("#mainnav");
 //initev("#mainnav");
});




function topNav(){
	var e=$(id);
	var allNav=$('mainnav').next(li);	
	var index = allNav.indexOf(e);	
	for(var i = 0, l = allNav.length; i< l ; i++){		
		allNav[i].observe('mouseover', function(event){ 
			allNav[i].addClassName(css);
			if(i==index&& $('mainnav').next(li.dropDownMenu) ){
				Effect.toggle(allNav[i].next(div.popMenuBox,0),'Slide');
			}else{
				allSel[i].removeClassName(css);
			}
		})
		allNav[i].observe('mouseout', function(event){ 
			allNav[i].removerClassName(css);
		})		
	}
	Effect.toggle(ele,'Slide');
}
//Event.observe(document,'load',topNav);