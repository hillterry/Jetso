var remainderDateTime = new Array(100);
var advtime = 0;
var timeAdd = 0;
var intervaltime = 5;
var winGalleryFiles;
var intervalTheTen

var str = "";
str += '<div class="tu1 tu_421_505 relative float_left left5 top5">';
str += '<img src="images/tu1_07.jpg" class="tuu1" />';
str += '<div class="time_20 white">10 : 10 : 10</div>';
str += '</div>';
var color = new Array("bb80ab", "bbbff1", "ddd9d8", "ccaf00", "bbbb9", "fedd0d", "bbb197", "fif3f8", "abi535", "dddcd5", "ffa93b", "ddc194");

var htmlobj = $.ajax({
    type: 'POST',
    url: 'WebService.asmx/Auctions',
    data: '{}',
    contentType: "application/json; charset=utf-8",
    dataType: "json",
    success: function (result) {
        var json = result.d;
        for (var i = 0; i < json.length; i++) {
            var radom = Math.floor(Math.random() * 11);
            //单张图片的模块

            if (i == 6) {
                str += '<div class="tu1 tu_421_505 relative float_left left5 top5">';
                str += '<img src="images/tu2_07.jpg" class="tuu1" />';
                str += '</div>';
            }
            if (i == 10) {
                str += '<div class="tu1 tu_421_505 relative float_left left5 top5">';
                str += '<img src="images/tu3_07.jpg" class="tuu1" />';
                str += '</div>';
            }
            if (i == 12) {
                str += '<div class="tu1 tu_421_505 relative float_left left5 top5">';
                str += '<img src="images/tu4_07.jpg" class="tuu1" />';
                str += '</div>';
            }
            str += '<div class="float_left left5 top5 tu_421_505">';
            str += "<div class=\"xia_421_250 " + color[radom] + '\">';
            str += "<div class=\"yjsu\" id='over" + json[i]["ID"] + "' style=\"display:none\"><img src=\"images/yjsu_03.png\" class=\"yjsu2\"/></div>";
            str += "<div class='thumbnailWrapper float_left'>";
            str += "<ul>";
            str += "<li onclick =\"click2('" + json[i]['ID'] + "')\"><a href=\"#\" >";
            str += '<img src="../' + json[i]['ProductImage2'] + '" /></a></li>';
            str += '</ul>';
            str += '</div>';
            str += '<div class="cont_ri width212 float_right relative">';
            str += '<ul>';
            str += '<li class="abso">';
            str += '<img src="images/' + color[radom] + '.png" /></li>';
            str += '<li class="height93 gray white">' + json[i]['ProductBrief'] + '</li>';
            str += '<li class="height63">';
            str += '<img src="images/igm1_10.png" class="float_left lin" />';
            str += '<div class="time_remaining float_left yellow">';
            str += '<h3>剩余时间</h3>';
            str += "<h1 id='remainingTime" + json[i]["ID"] + "'></h1>";
            str += '</div>';
            str += '</li>';
            str += "<li class=\"clear sxzy\" id='winBidder" + json[i]["ID"] + "'>" + json[i]["ProductDescription"] + "</li>";
            str += '<li class="money1"><span class="money float_left white">';
            str += "<h2 id='biddpice" + json[i]["ID"] + "'>$" + json[i]["BiddingPriceNow"] + "</h2>";
            str += '</span><a href="#" class="purchase float_left">';
            str += '<img src="images/igm1_18.png" /></a></li>';
            str += '</ul>';
            str += '</div>';
            str += '</div>';
            if (i < json.length - 1) {
                str += "<div class=\"xia_421_250  top5  float_left " + color[radom + 1] + '\">';
                str += "<div class=\"yjsu\" id='over" + json[i + 1]["ID"] + "' style='display:none'><img src=\"images/yjsu_03.png\" class=\"yjsu2\"/></div>";
                str += '<div class="cont_ri width212 float_left relative">';
                str += "<ul>";
                str += '<li class="abso2">';
                str += '<img src="images/' + color[radom + 1] + 'L.png"/></li>';
                str += '<li class="height93 gray">' + json[i + 1]['ProductBrief'] + '</li>';
                str += '<li class="height63 float_right">';
                str += '<img src="images/igm1_10.png" class="float_left lin"/>';
                str += '<div class="time_remaining float_left yellow">';
                str += '<h3>剩余时间</h3>';
                str += "<h1 id='remainingTime" + json[i + 1]["ID"] + "'></h1>";
                str += '</div>';
                str += '</li>';
                str += "<li class=\"clear sxzy float_right\">" + json[i + 1]["ProductDescription"] + "</li>";
                str += '<li class="money2"><a href="#" class="purchase float_left">';
                str += '<img src="images/igm1_18.png"/></a>';
                str += '<span class="money float_left white">';
                str += "<h2 id='biddpice" + json[i + 1]["ID"] + "'>$" + json[i + 1]["BiddingPriceNow"] + "</h2>";
                str += '</span> </li>';
                str += '</ul>';
                str += '</div>';
                str += '<div class="thumbnailWrapper float_right">';
                str += '<ul>';
                str += "<li onclick =\"click2('" + json[i + 1]['ID'] + "')\"><a href=\"#\" >";
                str += '<img src="../' + json[i + 1]['ProductImage2'] + '"/></a> </li>';
                str += '</ul>';
                str += '</div>';
                str += '</div>';
            }
            str += '</div>'
            $("#content").html(str);
            remainderDateTime[i] = getRemaindTime(json[i]['ProductNo'], json[i]['ProductName'], i, json[i]['ProductDescription']);
            auctionCountDown(i, '#remainingTime' + json[i]['ID'],json[i]['ID']);
            remainderDateTime[i + 1] = getRemaindTime(json[i + 1]['ProductNo'], json[i + 1]['ProductName'], i + 1, json[i+1]['ProductDescription']);
            auctionCountDown(i + 1, '#remainingTime' + json[i + 1]['ID'],json[i+1]['ID']);
            i++;

        }
    }
   
});
//htmlobj = null;
function Fresh() {
    var time = new Date();
    var winner = "";
    var htmlobj1= $.ajax({
        type: 'POST',
        url: 'WebService.asmx/Auctions',
        data: '{}',
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        success: function (result) {
            var json = result.d;
            for (var i = 0; i < json.length; i++) {
                $('#biddpice' + json[i]['ID']).html("$" + json[i]['BiddingPriceNow']);
                $('#winBidder' + json[i]['ID']).html(json[i]['ProductDescription']);
                // time = getAuctionTime(this['ProductName']);
                // alert(index);
                //console.log(json[i]['ProductNo']);
                timeA(i, json[i]['ProductNo'], json[i]['ProductName'], json[i]['ProductDescription']);
            }
        },
        error: function (XMLHttp, textStatus, errorThrown) {
            //alert(XMLHttp.status);
            //alert(XMLHttp.readyState);
            //alert(XMLHttp.responseText);
        },
        complete: function (XMLHttpRequest, textStatus) {
            this; // 调用本次AJAX请求时传递的options参数
        }
    });
    htmlobj = null;
}
Fresh();
//SysSecond = parseInt($("#remainSeconds").html()); //这里获取倒计时的起始时间 
var InterValObj = setInterval("Fresh()", 5000);

function timeA(index, nowtime, endtime, memberName) {    
    //alert("dafads");
    remainderDateTime[index] = getRemaindTime(nowtime, endtime, index, memberName);
    //alert("dafads");
}


