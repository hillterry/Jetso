// JavaScript Document
var lasttime = new Array(101);
for (i = 0; i < lasttime.length; i++) {
    lasttime[i] = "";
}
// 根据最后截止时间获取当前的剩余时间(毫秒数)
function getRemaindTime(nowTime, endTime, lasttimeId, memberName) {
    var nowDate = new Date();
    var endDate = new Date();
    nowDate = Date.parse(nowTime);
    endDate = Date.parse(endTime);
    var remainTime = endDate.getTime() - nowDate.getTime();
    if (remainTime < 0) {
        lasttime[lasttimeId] = memberName;
    }

    return remainTime;
}

/**********倒计时函数**********************************************************************************************/
var day = 1000 * 60 * 60 * 24;
var hour = 1000 * 60 * 60;
var minute = 1000 * 60;
var second = 1000;
function auctionCountDown(index, remainderDateTimeId, type) {
    remainderDateTime[index] = remainderDateTime[index] - 1000;
    var remainderDateTime1 = remainderDateTime[index] + 3000;
    var last10s = remainderDateTime[index];
    var lasts = 10 * 1000;  // 最后30秒
    var islast = last10s < lasts;
    if (remainderDateTime[index] > 0) {
        var remainderDay = Math.floor(remainderDateTime[index] / day);
        var remainderHour = AppendZero(Math.floor(remainderDateTime[index] / hour));
        var remainderMinute = AppendZero(Math.floor((remainderDateTime[index] / minute) % 60));
        var remainderSecond = AppendZero(Math.floor((remainderDateTime[index] / second) % 60));
        var h = '';
        if (islast) {
            h += '<p class="'
            h += 'fon18 red beij float_left white bb"';
            h += '>';
            h += remainderHour + "&nbsp;" + ":" + "&nbsp;" + remainderMinute + "&nbsp;" + ":" + "&nbsp;" + remainderSecond;
            h += '</p>';
        } else {
            h += '<p class="'
            h += 'fon18 red float_left white bb"';
            h += '>';
            h += remainderHour + "&nbsp;" + ":" + "&nbsp;" + remainderMinute + "&nbsp;" + ":" + "&nbsp;" + remainderSecond;
            h += '</p>';
        }
        $(remainderDateTimeId).html(h);
    }
    else if (remainderDateTime1 < 0) {
        if (lasttime[index] != "") {
            h = '已结束';
            document.getElementById("over" + type).setAttribute("style","display:block");
        }
        $(remainderDateTimeId).html(h);
    }
    setTimeout("auctionCountDown(" + index + ",'" + remainderDateTimeId + "','" + type + "')", 1000);
}

// 最后10秒倒计时函数
function countDown(remainderTime) {
    var remainderTime = remainderTime - 1000;
    if (remainderTime > 0) {
        var remainderSecond = AppendZero(Math.floor((remainderTime / second) % 60));
        $("#cc").html("<span class='red'>剩余时间: " + remainderSecond + "秒</span>");
        // alert(remainderSecond);
        setTimeout("countDown(" + remainderTime + ")", 1000);
    } else {
        return;
    }
}

// 获取指定时间范围内的随便机时间数
function getRandomTime(timeAddRange) {
    //alert(timeAddRange);

    var timeAddRangeArray = timeAddRange.split("-");
    var A = parseInt(trim(timeAddRangeArray[0]));
    var B = parseInt(trim(timeAddRangeArray[1]));
    return parseInt(Math.random() * (B - A + 1) + A);
}

function getAuctionTime(time) {
    var timeAddRangeArray = time.split("(");
    var back = trim(timeAddRangeArray[1]);
    var time1 = back.split(")");
    return trim(time1[0]);
}

var winImage;
function showImage(bImg, objImg) {
    if (bImg == '') {
        return;
    }
    var url = 'show_image.asp?fileName=' + bImg;
    var width = objImg.getWidth() + 14;
    if (width < 200) width = 200;
    var height = objImg.getHeight() + 43;
    if (height < 180) height = 180;
    winImage = new SmeWindow({ title: "瀏覽大圖", width: width, height: height, isMask: true, isScroll: false });
    winImage.setAjaxContent(url, {
        method: 'post',
        onComplete: function () {
        }
    });
    winImage.show();
}

function ShowGoodsImage(smallSrc) {
    if (firstGoodsImage == '') return;
    var obja = $(smallSrc);
    Element.addClassName($(obja).parentNode, "select");
    var title = (obja.title.escapeQuot(false));
    var bigImageContent = $('goodsBigImageContent');
    if (Prototype.Browser.IE) {
        bigImageContent.style.filter = "blendTrans(duration=1.5) revealTrans(duration=1.0,transition=" + getEffectRand() + ")";
        bigImageContent.filters(0).apply();
        bigImageContent.filters(1).apply();
        bigImageContent.update('<a href="image.html?p=' + escape('upload/') + '&i=' + escape(allGoodsImages) + '&c=' + escape(smallSrc) + '" title="' + title + '" target="_blank" class="picOut"><span class="picInner">' + createModule('upload/', getBigImage(smallSrc), 330, 330, 0) + '<i class="edge"> </i></span></a>');
        bigImageContent.filters(0).play();
        bigImageContent.filters(1).play();
    } else {
        bigImageContent.update('<a href="../image.html?p=' + escape(_WebPageInfo.ModelUserPath + 'gallery/') + '&i=' + escape(allGoodsImages) + '&c=' + escape(smallSrc) + '" title="' + title + '" target="_blank" class="picOut"><span class="picInner">' + createModule('upload/', getBigImage(smallSrc), 330, 330, 0) + '<i class="edge"> </i></span></a>');
    }
    var dts = $(obja).parentNode.parentNode.getElementsByTagName("dt");
    for (var i = 0; i < dts.length; i++) {
        if (dts[i] != $(obja).parentNode) {
            $(dts[i]).removeClassName("select");
        }
    }
}

function AppendZero(time) {
    var currentTime = "";
    if (time >= 10) { currentTime = time; } else { currentTime = "0" + time; }
    return currentTime;
}