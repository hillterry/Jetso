(function($){
    $.fn.kkcountdown = function(options) {
            var defaults = {
                dayText			: 	'day ',
                days2Text       :   'days ',
                daysText		: 	'days ',
                hourText		: 	':',
                hours2Text      :   'hours ',
                hoursText		: 	':',
                minutesText		:	':',
                secondsText		:	'',
                textAfterCount	: 	'---',
                oneDayClass		:	false,
                displayDays		: 	true,
                displayZeroDays	:	true,
                addClass		: 	false,
                callback		: 	false,
                warnSeconds		:	60,
                warnClass		:	false,
                rusNumbers      :   false,
				restart 		:   false,
            };

            var options =  $.extend(defaults, options);

            // rather than continue to read the timestamp/seconds from the dom element, store it within the plugin
            var start1;
			var start2;
			
            this.each(function(){
            	var _this = $(this);
				var counttime = _this.attr("data-seconds");
		        var box = $(document.createElement('span')).addClass('kkcountdown-box').attr('id','countbox');
		        var boxDni = $(document.createElement('span')).addClass('kkc-dni');
		        var boxGodz = $(document.createElement('span')).addClass('kkc-godz');
		        var boxMin = $(document.createElement('span')).addClass('kkc-min');
		        var boxSec = $(document.createElement('span')).addClass('kkc-sec');
		        var boxDniText = $(document.createElement('span')).addClass('kkc-dni-text');
		        var boxGodzText = $(document.createElement('span')).addClass('kkc-godz-text');
		        var boxMinText = $(document.createElement('span')).addClass('kkc-min-text');
		        var boxSecText = $(document.createElement('span')).addClass('kkc-sec-text');

		        if(options.addClass != false){
		        	box.addClass(options.addClass);
		        }
				
				if(options.restart != false){
					clearTimeout(start1);
				}

		        boxGodzText.html(options.hoursText);
	            boxMinText.html(options.minutesText);
	            boxSecText.html(options.secondsText);

		        box.append(boxDni).append(boxDniText).append(boxGodz).append(boxGodzText).append(boxMin).append(boxMinText).append(boxSec).append(boxSecText);
		        _this.append(box);

            	kkCountdownInit(_this , counttime);

            });

            function kkCountdownInit(_this , counttimes){
            	/*
            	 * look first for the number of seconds and not a time attribute on the object
            	 * - time relies on the browser's time being set in sync with the server
            	 * - number of seconds can be confidently set based on the server time
            	 */
            	
					var count = counttimes
				
            	
					count = count - 1;
		        if (options.warnClass && count < options.warnSeconds) {
			        _this.addClass(options.warnClass)
		        }
		        if(count < 0){
		            _this.html(options.textAfterCount);
		            if(options.callback){
		            	options.callback(_this);
		            }
		        }else if(count <= 24*60*60){
		         start1 = setTimeout(function(){
						kkCountDown(true, _this, count);
						kkCountdownInit(_this , count);
					}, 1000);
		        }else{
		         start1 = setTimeout(function(){
		            	kkCountDown(false, _this, count);
		            	kkCountdownInit(_this , count);
		            }, 1000);
		        }
            }

            function kkCountDown(oneDay, obj, count){
            	var sekundy = naprawaCzasu(count % 60);
	            count = Math.floor(count/60);
	            var minuty = naprawaCzasu(count % 60);
	            count = Math.floor(count/60);
	            var godziny = naprawaCzasu(count % 24);
	            count = Math.floor(count/24);
	            var dni = count;

				if(oneDay && options.oneDayClass != false){
		            obj.addClass(options.oneDayClass);
				}

            if (dni == 0 && !options.displayZeroDays) {

            } else {
					obj.find('.kkc-dni').html(dni);
                obj.find('.kkc-dni-text').html(formatNumberedText(dni, 'day'));
	            }

	            obj.find('.kkc-godz').html(godziny);
            obj.find('.kkc-godz-text').html(formatNumberedText(godziny, 'hour'));

	            obj.find('.kkc-min').html(minuty);
	            obj.find('.kkc-sec').html(sekundy);
            }

        /**
        * @var int number
        * @var string optionText - {daysText: day, dayText: day, hoursText: hour, etc}
        */
        function formatNumberedText(number, optionText) {
            var daysText = options[optionText+'sText'];

            if (options.rusNumbers) {
                if (number >= 5 && number < 20) {
                    daysText = options[optionText+'sText'];
                } else {
                    var lastDigit = (""+number).replace(/^\d+(\d)$/, '$1') * 1;
                    if (lastDigit == 1) {
                        daysText = options[optionText+'Text'];
                    } else {
                        if (lastDigit >= 2 && lastDigit <= 4) {
                            daysText = options[optionText+'s2Text'];
                        } else {
                            daysText = options[optionText+'sText'];
                        }
                    }
                }
            } else {
                if (1 == number) {
                    daysText = options[optionText+'Text'];
                }
            }
            return daysText;
        }

        function naprawaCzasu(obj){
		    s = '';
		    if(obj < 10){
		        obj = '0' + obj;
		    }
		    return obj;
		}
      }
})(jQuery);