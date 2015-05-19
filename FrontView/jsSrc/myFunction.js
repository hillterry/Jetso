function addClass(){
	Spry.$$("div#BD div dl.BodyNav ul.SubNav li:nth-child(1)").addClassName("FirstRow");
	Spry.$$("div#BD div dl.BodyNav ul.SubNavPop li:nth-of-type(2)").addClassName("FirstRow");
	Spry.$$("div#BD div.Module div.BaseUi:not(div.HotLinks) ul:not{ul.TabbedPanelsTabGroup} li:nth-of-type(1)").addClassName("FirstRow");
	Spry.$$("div#BD div.Module div.BaseUi:not(div.HotLinks) dl:not(dl#PageRoll) dt:not(dt.Head):nth-of-type(1)").addClassName("FirstRow");
	Spry.$$("div#BD div.Module div.Products:not(div.ListHMod) dl:not(dl.PicMod):not(dl#PageRoll) dt:nth-child(2)").addClassName("FirstRow");
	
	//Spry.$$("div#BD div#LeftSide div.Products ul li:nth-of-type(1)").addClassName("First");
	Spry.$$("div#BD div#LeftSide div.Module div.Products dl dt:nth-of-type(2n)").addClassName("Row02");
	Spry.$$("div#BD div#RightSide) div.Module div.Products dl dt:nth-of-type(2n)").addClassName("Row02");
	
	Spry.$$("table#DataList thead tr th:nth-child(1)").addClassName("FirstCol");

	//Spry.$$("div#BD div#CenterBox div.Module ul li:nth-child(3n+2)").addClassName("Center");
	Spry.$$("div#BD div#CenterBox div.Module div.Products:not(div.ListVMod) dl dt:nth-child(2)").addClassName("FirstRow");
	Spry.$$("div#BD div#CenterBox div.Module div.Products:not(div.ListVMod) dl dt:nth-child(3)").addClassName("FirstRow");
	Spry.$$("div#BD div#CenterBox div.Module div.Products:not(div.ListVMod):not(div.HotLinks) dl dt:nth-child(3n+1)").addClassName("NthFirst");
}
//Spry.Utils.addLoadListener(addClass);


var NavTabPan;
function Nav(){
	NavTabPan = new Spry.Widget.TabbedPanels("NavTabPan",{defaultTab: 0,tabHoverClass:"NavTabHover",tabSelectedClass:"NavTabSelected"});
}
//Spry.Utils.addLoadListener(Nav);


/*var sampleAccordion;
// Add a listener that fires after the page is loaded. This runs the actual constructor script.
Spry.Utils.addLoadListener(function()
{
	Spry.$$("#sampleAccordion").forEach(function(n) {  sampleAccordion = new Spry.Widget.Accordion("sampleAccordion");});
});

var cp_options;
function InitPage()
{
	Spry.$$(".CollapsiblePanel:not(#CollapsiblePanel2)").forEach(function(n) { window[n.id] = new Spry.Widget.CollapsiblePanel(n); });
	cp_options = new Spry.Widget.CollapsiblePanel("CollapsiblePanel2", { contentIsOpen: false, enableAnimation: false });
	
	Spry.$$(".open").addEventListener("click", function(e){ CollapsiblePanel4.open(); return false;}, false);

	Spry.$$(".close").addEventListener("click", function(e){ CollapsiblePanel4.close(); return false;}, false);
}

Spry.Utils.addLoadListener(InitPage);


*/