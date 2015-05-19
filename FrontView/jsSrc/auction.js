// JavaScript Document

// 根据最后截止时间获取当前的剩余时间(毫秒数)
function getRemaindTime(nowTime, endTime, lasttimeId, memberid) {
  var nowDate = Date.parse(nowTime);
  var endDate = Date.parse(endTime)
  var remainTime = endDate.getTime() - nowDate.getTime();
  if (remainTime < 0) {
    lasttime[lasttimeId] = memberid;
    //alert(lasttime[lasttimeId]);
  }
  return remainTime;
}

/**********倒计时函数**********************************************************************************************/
var day = 1000 * 60 * 60 * 24;
var hour = 1000 * 60 * 60;
var minute = 1000 * 60;
var second = 1000;
function auctionCountDown(index, remainderDateTimeId, type) {
  var remainderDateTime1 = remainderDateTime[index] + 3000;
  remainderDateTime[index] = remainderDateTime[index] - 1000;
  var last30s = remainderDateTime[index];
  var lasts = 30 * 1000;  // 最后30秒
  var islast = last30s < lasts;
  if (remainderDateTime[index] > 0) {
    var remainderDay = Math.floor(remainderDateTime[index] / day);
    var remainderHour = objInvalid.appendZero(Math.floor((remainderDateTime[index] % day) / hour) + remainderDay * 24);
    var remainderMinute = objInvalid.appendZero(Math.floor((remainderDateTime[index] % hour) / minute));
    var remainderSecond = objInvalid.appendZero(Math.floor((remainderDateTime[index] % minute) / second));
    var h = '';
    if (type == 'detail') {
      h = '<span class="utd1 padT5 alignR">剩餘時間：</span>';
      h += '<div class="utd2 timeBar"><div class="bgL';
      if (remainderDay > 0 || remainderHour > 0) {
        h += '">';
      }

      if (remainderDay == 0 && remainderHour == 0 && remainderMinute > 0) {
        h += ' last-min">';
      }

      if (remainderDay == 0 && remainderHour == 0 && remainderMinute == 0 && remainderSecond > 0) {
        h += ' last-sec">';
      }
    } else {
      h += '<span>剩餘時間</span><strong>';
    }

    if (remainderDay > 0 || remainderHour > 0) {
      h += '<em class="t t-' + remainderHour.substr(0, 1) + '">' + remainderHour.substr(0, 1) + '</em><em class="t t-' + remainderHour.substr(1, 1) + '">' + remainderHour.substr(1, 1) + '</em><em class="t t-sep">:</em>';
    }
    if (remainderDay > 0 || remainderHour > 0 || remainderMinute > 0) {
      h += '<em class="t t-' + remainderMinute.substr(0, 1) + '">' + remainderMinute.substr(0, 1) + '</em><em class="t t-' + remainderMinute.substr(1, 1) + '">' + remainderMinute.substr(1, 1) + '</em><em class="t t-sep">:</em>';
    }
    if (remainderDay > 0 || remainderHour > 0 || remainderMinute > 0 || remainderSecond > 0) {
      if (remainderDay <= 0 && remainderHour <= 0 && remainderMinute <= 0) {
        h += '<em class="t t-' + remainderMinute.substr(0, 1) + '">' + remainderMinute.substr(0, 1) + '</em><em class="t t-' + remainderMinute.substr(1, 1) + '">' + remainderMinute.substr(1, 1) + '</em><em class="t t-sep">:</em>';

      }
      h += '<em class="t t-' + remainderSecond.substr(0, 1) + '">' + remainderSecond.substr(0, 1) + '</em><em class="t t-' + remainderSecond.substr(1, 1) + '">' + remainderSecond.substr(1, 1) + '</em>';
    }

    if (type == 'detail') {
      h += '</div><i class="bgR"></i></div>';
    } else {
      h += '</strong>';
    }

    $(remainderDateTimeId).update(h);
  }
  else if (remainderDateTime1 < 0) {
    if (lasttime[index] != "") {
      h = '<span>竞投已结束</span>' + '<strong class="mallPrice"><span>恭喜会员' + lasttime[index] + '竞投成功</span></stong>';
    }

    $(remainderDateTimeId).update(h);
  }
  setTimeout("auctionCountDown(" + index + ",'" + remainderDateTimeId + "','" + type + "')", 1000);
}

// 最后10秒倒计时函数
function countDown(remainderTime, auctionId, fType) {
  var remainderTime = remainderTime - 1000;
  if (remainderTime > 0) {
    var remainderSecond = Math.floor((remainderTime % minute) / second);
    if ($('countDown') != null) {
      $('countDown').update("<span>剩餘時間<strong>" + "" + remainderSecond + "</strong>秒</span>");
      setTimeout("countDown(" + remainderTime + ", " + auctionId + ", " + fType + ")", 1000);
    }
  } else {
    if (fType == 1) {
      adsWin.closeWin();
      //nowBid2();
    } else {
      adsWin.closeWin();
      logonWin.closeWin();
      //nowBid2();
      //window.location.href = 'e_auction_info.asp?auctionId=' + auctionId;
    }
  }
}

// 获取指定时间范围内的随便机时间数
function getRandomTime(timeAddRange) {
  var timeAddRangeArray = timeAddRange.split("-");
  var A = parseInt(trim(timeAddRangeArray[0]));
  var B = parseInt(trim(timeAddRangeArray[1]));
  return parseInt(Math.random() * (B - A + 1) + A);
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