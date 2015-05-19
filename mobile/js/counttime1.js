var day =  60 * 60 * 24;
var hour =  60 * 60;
var minute =  60;
var second = 1;
var remainderDateTime;
var clearout;
function auctionCountDown(htmlId, type) {
    remainderDateTime = remainderDateTime - 1;
    var remainderDateTime1 = remainderDateTime + 3000;
    var last10s = remainderDateTime;
    
    
    if (remainderDateTime > 0) {
        var remainderDay = Math.floor(remainderDateTime / day);
        var remainderHour = AppendZero(Math.floor(remainderDateTime / hour));
        var remainderMinute = AppendZero(Math.floor((remainderDateTime / minute) % 60));
        var remainderSecond = AppendZero(Math.floor((remainderDateTime / second) % 60));
        var h = '';
        
            h += '<p class="';
            h += 'fon18 red beij float_left white bb"';
            h += '>';
            h += remainderHour  + ":" + remainderMinute + ":"  + remainderSecond;
            h += '</p>';
            $("#"+htmlId).html(h);
    }
    else if (remainderDateTime <= 0) {
        
            h = '<span>競投結束</span>';
        
        $("#"+htmlId).html(h);
    }
	console.log("test");
    clearout = setTimeout("auctionCountDown('" + htmlId + "','" + type + "')", 1000);
}

function AppendZero(time) {
    var currentTime = "";
    if (time >= 10) { currentTime = time; } else { currentTime = "0" + time; }
    return currentTime;
}