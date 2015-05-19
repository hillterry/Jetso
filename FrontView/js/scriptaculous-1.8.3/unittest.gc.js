Event.simulateMouse=function(a,c,b){var b=Object.extend({pointerX:0,pointerY:0,buttons:0,ctrlKey:!1,altKey:!1,shiftKey:!1,metaKey:!1},b||{}),d=document.createEvent("MouseEvents");d.initMouseEvent(c,!0,!0,document.defaultView,b.buttons,b.pointerX,b.pointerY,b.pointerX,b.pointerY,b.ctrlKey,b.altKey,b.shiftKey,b.metaKey,0,$(a));this.mark&&Element.remove(this.mark);this.mark=document.createElement("div");this.mark.appendChild(document.createTextNode(" "));document.body.appendChild(this.mark);this.mark.style.position=
"absolute";this.mark.style.top=b.pointerY+"px";this.mark.style.left=b.pointerX+"px";this.mark.style.width="5px";this.mark.style.height="5px;";this.mark.style.borderTop="1px solid red;";this.mark.style.borderLeft="1px solid red;";this.step&&alert("["+(new Date).getTime().toString()+"] "+c+"/"+Test.Unit.inspect(b));$(a).dispatchEvent(d)};
Event.simulateKey=function(a,c,b){var b=Object.extend({ctrlKey:!1,altKey:!1,shiftKey:!1,metaKey:!1,keyCode:0,charCode:0},b||{}),d=document.createEvent("KeyEvents");d.initKeyEvent(c,!0,!0,window,b.ctrlKey,b.altKey,b.shiftKey,b.metaKey,b.keyCode,b.charCode);$(a).dispatchEvent(d)};Event.simulateKeys=function(a,c){for(var b=0;b<c.length;b++)Event.simulateKey(a,"keypress",{charCode:c.charCodeAt(b)})};var Test={Unit:{}};Test.Unit.inspect=Object.inspect;Test.Unit.Logger=Class.create();
Test.Unit.Logger.prototype={initialize:function(a){(this.log=$(a))&&this._createLogTable()},start:function(a){if(this.log)this.testName=a,this.lastLogLine=document.createElement("tr"),this.statusCell=document.createElement("td"),this.nameCell=document.createElement("td"),this.nameCell.className="nameCell",this.nameCell.appendChild(document.createTextNode(a)),this.messageCell=document.createElement("td"),this.lastLogLine.appendChild(this.statusCell),this.lastLogLine.appendChild(this.nameCell),this.lastLogLine.appendChild(this.messageCell),
this.loglines.appendChild(this.lastLogLine)},finish:function(a,c){if(this.log)this.lastLogLine.className=a,this.statusCell.innerHTML=a,this.messageCell.innerHTML=this._toHTML(c),this.addLinksToResults()},message:function(a){if(this.log)this.messageCell.innerHTML=this._toHTML(a)},summary:function(a){if(this.log)this.logsummary.innerHTML=this._toHTML(a)},_createLogTable:function(){this.log.innerHTML='<div id="logsummary"></div><table id="logtable"><thead><tr><th>Status</th><th>Test</th><th>Message</th></tr></thead><tbody id="loglines"></tbody></table>';
this.logsummary=$("logsummary");this.loglines=$("loglines")},_toHTML:function(a){return a.escapeHTML().replace(/\n/g,"<br/>")},addLinksToResults:function(){$$("tr.failed .nameCell").each(function(a){a.title="Run only this test";Event.observe(a,"click",function(){window.location.search="?tests="+a.innerHTML})});$$("tr.passed .nameCell").each(function(a){a.title="Run all tests";Event.observe(a,"click",function(){window.location.search=""})})}};Test.Unit.Runner=Class.create();
Test.Unit.Runner.prototype={initialize:function(a,c){this.options=Object.extend({testLog:"testlog"},c||{});this.options.resultsURL=this.parseResultsURLQueryParameter();this.options.tests=this.parseTestsQueryParameter();if(this.options.testLog)this.options.testLog=$(this.options.testLog)||null;if(this.options.tests){this.tests=[];for(var b=0;b<this.options.tests.length;b++)/^test/.test(this.options.tests[b])&&this.tests.push(new Test.Unit.Testcase(this.options.tests[b],a[this.options.tests[b]],a.setup,
a.teardown))}else if(this.options.test)this.tests=[new Test.Unit.Testcase(this.options.test,a[this.options.test],a.setup,a.teardown)];else for(b in this.tests=[],a)/^test/.test(b)&&this.tests.push(new Test.Unit.Testcase(this.options.context?" -> "+this.options.titles[b]:b,a[b],a.setup,a.teardown));this.currentTest=0;this.logger=new Test.Unit.Logger(this.options.testLog);setTimeout(this.runTests.bind(this),1E3)},parseResultsURLQueryParameter:function(){return window.location.search.parseQuery().resultsURL},
parseTestsQueryParameter:function(){if(window.location.search.parseQuery().tests)return window.location.search.parseQuery().tests.split(",")},getResult:function(){for(var a=!1,c=0;c<this.tests.length;c++){if(this.tests[c].errors>0)return"ERROR";this.tests[c].failures>0&&(a=!0)}return a?"FAILURE":"SUCCESS"},postResults:function(){this.options.resultsURL&&new Ajax.Request(this.options.resultsURL,{method:"get",parameters:"result="+this.getResult(),asynchronous:!1})},runTests:function(){var a=this.tests[this.currentTest];
a?(a.isWaiting||this.logger.start(a.name),a.run(),a.isWaiting?(this.logger.message("Waiting for "+a.timeToWait+"ms"),setTimeout(this.runTests.bind(this),a.timeToWait||1E3)):(this.logger.finish(a.status(),a.summary()),this.currentTest++,this.runTests())):(this.postResults(),this.logger.summary(this.summary()))},summary:function(){for(var a=0,c=0,b=0,d=0;d<this.tests.length;d++)a+=this.tests[d].assertions,c+=this.tests[d].failures,b+=this.tests[d].errors;return(this.options.context?this.options.context+
": ":"")+this.tests.length+" tests, "+a+" assertions, "+c+" failures, "+b+" errors"}};Test.Unit.Assertions=Class.create();
Test.Unit.Assertions.prototype={initialize:function(){this.errors=this.failures=this.assertions=0;this.messages=[]},summary:function(){return this.assertions+" assertions, "+this.failures+" failures, "+this.errors+" errors\n"+this.messages.join("\n")},pass:function(){this.assertions++},fail:function(a){this.failures++;this.messages.push("Failure: "+a)},info:function(a){this.messages.push("Info: "+a)},error:function(a){this.errors++;this.messages.push(a.name+": "+a.message+"("+Test.Unit.inspect(a)+
")")},status:function(){return this.failures>0?"failed":this.errors>0?"error":"passed"},assert:function(a,c){var b=c||'assert: got "'+Test.Unit.inspect(a)+'"';try{a?this.pass():this.fail(b)}catch(d){this.error(d)}},assertEqual:function(a,c,b){b=b||"assertEqual";try{a==c?this.pass():this.fail(b+': expected "'+Test.Unit.inspect(a)+'", actual "'+Test.Unit.inspect(c)+'"')}catch(d){this.error(d)}},assertInspect:function(a,c,b){b=b||"assertInspect";try{a==c.inspect()?this.pass():this.fail(b+': expected "'+
Test.Unit.inspect(a)+'", actual "'+Test.Unit.inspect(c)+'"')}catch(d){this.error(d)}},assertEnumEqual:function(a,c,b){b=b||"assertEnumEqual";try{$A(a).length==$A(c).length&&a.zip(c).all(function(a){return a[0]==a[1]})?this.pass():this.fail(b+": expected "+Test.Unit.inspect(a)+", actual "+Test.Unit.inspect(c))}catch(d){this.error(d)}},assertNotEqual:function(a,c,b){b=b||"assertNotEqual";try{a!=c?this.pass():this.fail(b+': got "'+Test.Unit.inspect(c)+'"')}catch(d){this.error(d)}},assertIdentical:function(a,
c,b){b=b||"assertIdentical";try{a===c?this.pass():this.fail(b+': expected "'+Test.Unit.inspect(a)+'", actual "'+Test.Unit.inspect(c)+'"')}catch(d){this.error(d)}},assertNotIdentical:function(a,c,b){b=b||"assertNotIdentical";try{a!==c?this.pass():this.fail(b+': expected "'+Test.Unit.inspect(a)+'", actual "'+Test.Unit.inspect(c)+'"')}catch(d){this.error(d)}},assertNull:function(a,c){var b=c||"assertNull";try{a==null?this.pass():this.fail(b+': got "'+Test.Unit.inspect(a)+'"')}catch(d){this.error(d)}},
assertMatch:function(a,c,b){b=b||"assertMatch";try{RegExp(a).exec(c)?this.pass():this.fail(b+' : regex: "'+Test.Unit.inspect(a)+" did not match: "+Test.Unit.inspect(c)+'"')}catch(d){this.error(d)}},assertHidden:function(a,c){this.assertEqual("none",a.style.display,c||"assertHidden")},assertNotNull:function(a,c){this.assert(a!=null,c||"assertNotNull")},assertType:function(a,c,b){b=b||"assertType";try{c.constructor==a?this.pass():this.fail(b+': expected "'+Test.Unit.inspect(a)+'", actual "'+c.constructor+
'"')}catch(d){this.error(d)}},assertNotOfType:function(a,c,b){b=b||"assertNotOfType";try{c.constructor!=a?this.pass():this.fail(b+': expected "'+Test.Unit.inspect(a)+'", actual "'+c.constructor+'"')}catch(d){this.error(d)}},assertInstanceOf:function(a,c,b){b=b||"assertInstanceOf";try{c instanceof a?this.pass():this.fail(b+": object was not an instance of the expected type")}catch(d){this.error(d)}},assertNotInstanceOf:function(a,c,b){b=b||"assertNotInstanceOf";try{!(c instanceof a)?this.pass():this.fail(b+
": object was an instance of the not expected type")}catch(d){this.error(d)}},assertRespondsTo:function(a,c,b){b=b||"assertRespondsTo";try{c[a]&&typeof c[a]=="function"?this.pass():this.fail(b+": object doesn't respond to ["+a+"]")}catch(d){this.error(d)}},assertReturnsTrue:function(a,c,b){b=b||"assertReturnsTrue";try{var d=c[a];d||(d=c["is"+a.charAt(0).toUpperCase()+a.slice(1)]);d()?this.pass():this.fail(b+": method returned false")}catch(e){this.error(e)}},assertReturnsFalse:function(a,c,b){b=b||
"assertReturnsFalse";try{var d=c[a];d||(d=c["is"+a.charAt(0).toUpperCase()+a.slice(1)]);!d()?this.pass():this.fail(b+": method returned true")}catch(e){this.error(e)}},assertRaise:function(a,c,b){b=b||"assertRaise";try{c(),this.fail(b+": exception expected but none was raised")}catch(d){a==null||d.name==a?this.pass():this.error(d)}},assertElementsMatch:function(){var a=$A(arguments),c=$A(a.shift());if(c.length!=a.length)return this.fail("assertElementsMatch: size mismatch: "+c.length+" elements, "+
a.length+" expressions"),!1;c.zip(a).all(function(a,c){var e=$(a.first()),g=a.last();if(e.match(g))return!0;this.fail("assertElementsMatch: (in index "+c+") expected "+g.inspect()+" but got "+e.inspect())}.bind(this))&&this.pass()},assertElementMatches:function(a,c){this.assertElementsMatch([a],c)},benchmark:function(a,c,b){var d=new Date;(c||1).times(a);a=new Date-d;this.info((b||"Operation")+" finished "+c+" iterations in "+a/1E3+"s");return a},_isVisible:function(a){a=$(a);if(!a.parentNode)return!0;
this.assertNotNull(a);return a.style&&Element.getStyle(a,"display")=="none"?!1:this._isVisible(a.parentNode)},assertNotVisible:function(a,c){this.assert(!this._isVisible(a),Test.Unit.inspect(a)+" was not hidden and didn't have a hidden parent either. "+c)},assertVisible:function(a,c){this.assert(this._isVisible(a),Test.Unit.inspect(a)+" was not visible. "+c)},benchmark:function(a,c,b){var d=new Date;(c||1).times(a);a=new Date-d;this.info((b||"Operation")+" finished "+c+" iterations in "+a/1E3+"s");
return a}};Test.Unit.Testcase=Class.create();
Object.extend(Object.extend(Test.Unit.Testcase.prototype,Test.Unit.Assertions.prototype),{initialize:function(a,c,b,d){Test.Unit.Assertions.prototype.initialize.bind(this)();this.name=a;typeof c=="string"?(c=c.gsub(/(\.should[^\(]+\()/,"#{0}this,"),c=c.gsub(/(\.should[^\(]+)\(this,\)/,"#{1}(this)"),this.test=function(){eval("with(this){"+c+"}")}):this.test=c||function(){};this.setup=b||function(){};this.teardown=d||function(){};this.isWaiting=!1;this.timeToWait=1E3},wait:function(a,c){this.isWaiting=
!0;this.test=c;this.timeToWait=a},run:function(){try{try{this.isWaiting||this.setup.bind(this)(),this.isWaiting=!1,this.test.bind(this)()}finally{this.isWaiting||this.teardown.bind(this)()}}catch(a){this.error(a)}}});
Test.setupBDDExtensionMethods=function(){var a=function(a,b,d){this[a].apply(this,(b||[]).concat([d]))};Test.BDDMethods={};$H({shouldEqual:"assertEqual",shouldNotEqual:"assertNotEqual",shouldEqualEnum:"assertEnumEqual",shouldBeA:"assertType",shouldNotBeA:"assertNotOfType",shouldBeAn:"assertType",shouldNotBeAn:"assertNotOfType",shouldBeNull:"assertNull",shouldNotBeNull:"assertNotNull",shouldBe:"assertReturnsTrue",shouldNotBe:"assertReturnsFalse",shouldRespondTo:"assertRespondsTo"}).each(function(c){Test.BDDMethods[c.key]=
function(){var b=$A(arguments),d=b.shift();a.apply(d,[c.value,b,this])}});[Array.prototype,String.prototype,Number.prototype,Boolean.prototype].each(function(a){Object.extend(a,Test.BDDMethods)})};
Test.context=function(a,c,b){Test.setupBDDExtensionMethods();var d={},e={};for(specName in c)switch(specName){case "setup":case "teardown":d[specName]=c[specName];break;default:var g="test"+specName.gsub(/\s+/,"-").camelize(),f=c[specName].toString().split("\n").slice(1);/^\{/.test(f[0])&&(f=f.slice(1));f.pop();f=f.map(function(a){return a.strip()});d[g]=f.join("\n");e[g]=specName}new Test.Unit.Runner(d,{titles:e,testLog:b||"testlog",context:a})};
