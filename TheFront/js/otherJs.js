

$(window).load(function () {
    //alert(document.documentElement.scrollTop);

    //设置和获取一些变量
    var thumbnail = {
        imgIncrease: 100, /* 增加图像像素（变焦） */
        effectDuration: 400, /* 效果的持续时间（变焦和标题） */
        /* 
        获取的图像的宽度和高度。要使用这些
        2件事:
        列表项大小相同
        得到的图像缩放后恢复正常
        */
        imgWidth: $('.thumbnailWrapper ul li').find('img').width(),
        imgHeight: $('.thumbnailWrapper ul li').find('img').height()
    };

    //列表项相同的大小作为图像
    $('.thumbnailWrapper ul li').css({
        'width': thumbnail.imgWidth,
        'height': thumbnail.imgHeight
    });
    var width = document.body.clientWidth;
    if ((1130 <= width && width <= 1300) || (748 <= width && width < 997)) {
        var left = (width - 1000) / 2;
        $('.content222').css({ 'left': left });
    }
    if (748 <= width && width < 997) {
        var left = (width - 760) / 2;
        $('.content222').css({ 'left': left });
    }
    if (width > 1300) {
        var left = (width - 1000) / 2;
        $('.content222').css({ 'left': left });
    }
    if (997 <= width && width <= 1129) {
        var left = (width - 1000) / 2;
        $('.content222').css({ 'left': left });
    }
    if (462 <= width && width <= 747) {
        var left = (width - 470) / 2;
        $('.content222').css({ 'left': left });
    }
    if (300 <= width && width <= 462) {
        var left = (width - 320) / 2;
        $('.content222').css({ 'left': left });
    }

    $(window).resize(function () {
        //alert(width);
        var width = document.body.clientWidth;
        //alert(width);
        if ((1130 < width && width <= 1300) || (748 <= width && width < 997)) {
            //thumbnail.imgWidth=186;
            //alert("高度1: "+width);
            $('.thumbnailWrapper ul li').css({
                'width': 186,
                'height': 225
            });
            $('.thumbnailWrapper ul li img').css({
                'width': 186
            });
            thumbnail.imgHeight = 225;
            thumbnail.imgWidth = 186;
            var left = (width - 1000) / 2;
            $('.content222').css({ 'left': left });
            var Left1 = (width - 1150) / 2;
            $('#menu').css({ 'left': Left1 });
            //alert($('.thumbnailWrapper').width());
            //$('.thumbnailWrapper ul li a img').width(186);
        }
        if (748 <= width && width < 997) {
            var left = (width - 760) / 2;
            $('.content222').css({ 'left': left });
            var Left1 = (width - 767) / 2;
            $('#menu').css({ 'left': Left1 });

        }
        if (width > 1300) {
            //thumbnail.imgWidth=186;
            //alert("高度2: "+width);
            $('.thumbnailWrapper ul li').css({
                'width': 207,
                'height': 250
            });
            $('.thumbnailWrapper ul li img').css({
                'width': 207
            });
            thumbnail.imgHeight = 250;
            thumbnail.imgWidth = 207;
            var Left1 = (width - 1300) / 2;
            var left = (width - 1000) / 2;
            $('.content222').css({ 'left': left });
            var Left1 = (width - 1300) / 2;
            $('#menu').css({ 'left': Left1 });
            //alert($('.thumbnailWrapper').width());
            //$('.thumbnailWrapper ul li a img').width(186);
        }
        if (997 <= width && width <= 1129) {
            //thumbnail.imgWidth=186;
            //alert("高度3: "+width);
            $('.thumbnailWrapper ul li').css({
                'width': 165,
                'height': 198
            });
            $('.thumbnailWrapper ul li img').css({
                'width': 165,
            });
            thumbnail.imgHeight = 198;
            thumbnail.imgWidth = 165;
            var left = (width - 1000) / 2;
            $('.content222').css({ 'left': left });
            var Left1 = (width - 1008) / 2;
            $('#menu').css({ 'left': Left1 });
        }
        if (462 <= width && width <= 747) {
            //thumbnail.imgWidth=186;
            //alert("高度3: "+width);

            $('.thumbnailWrapper ul li').css({
                'width': 160,
                'height': 194
            });
            $('.thumbnailWrapper ul li img').css({
                'width': 160,
            });
            var left = (width - 470) / 2;
            $('.content222').css({ 'left': left });
            var Left1 = (width - 420) / 2;
            $('#menu').css({ 'left': Left1 });
            thumbnail.imgHeight = 194;
            thumbnail.imgWidth = 160;
        }
        if (300 <= width && width <= 462) {
            var left = (width - 320) / 2;
            $('.content222').css({ 'left': left });
            var Left1 = (width - 400) / 2;
            $('#menu').css({ 'left': Left1 });
        }
        //alert("width:"+thumbnail.imgWidth+"--"+"height"+thumbnail.imgHeight);
    });
    //当鼠标移到列表项...
    $('.thumbnailWrapper ul li').hover(function () {
        $(this).find('img').stop().animate({
            /* 变焦效果，提高图像的宽度 */
            width: parseInt(thumbnail.imgWidth) + thumbnail.imgIncrease,
            /* 我们需要改变的左侧和顶部的位置，才能有放大效应，因此我们将它们移动到一个负占据一半的img增加 */
            left: thumbnail.imgIncrease / 2 * (-1),
            top: thumbnail.imgIncrease / 2 * (-1)
        }, {
            "duration": thumbnail.effectDuration,
            "queue": false
        });

        //使用slideDown事件显示的标题
        $(this).find('.caption:not(:animated)').slideDown(thumbnail.effectDuration);

        //当鼠标离开...
    }, function () {

        //发现图像和动画...
        $(this).find('img').animate({
            /* 回原来的尺寸（缩小） */
            width: thumbnail.imgWidth,
            /* 左侧和顶部位置恢复正常 */
            left: 0,
            top: 0

        }, thumbnail.effectDuration);

        //隐藏使用滑块事件的标题
        $(this).find('.caption').slideUp(thumbnail.effectDuration);

    });

});

$(document).ready(function () {
    var k = !0;

    $(".loginmask").css("opacity", 0.8);

    if ($.browser.version <= 6) {
        $('#reg_setp1,.loginmask').height($(document).height());
    }

    $(".thirdlogin ul li:odd").css({ marginRight: 0 });

    $(".openlogin").click(function () {
        k && "0px" != $("#loginalert").css("top") && ($("#loginalert").show(), $(".loginmask").fadeIn(500), $("#loginalert").animate({ top: 0 }, 400, "easeOutQuart"))
    });

    $(".loginmask,.closealert").click(function () {
        k && (k = !1, $("#loginalert").animate({ top: -600 }, 400, "easeOutQuart", function () { $("#loginalert").hide(); k = !0 }), $(".loginmask").fadeOut(500))
    });


    $(".menu a").click(function () {
        var width = document.body.clientWidth;
        var Left1 = 0;
        if ((1300 >= width && width >= 1130) || (748 <= width && width < 997)) {
            Left1 = (width - 1145) / 2;
        }
        if (748 <= width && width < 997) {
            Left1 = (width - 760) / 2;
        }
        if (width > 1300) {
            Left1 = (width - 1300) / 2;
            //alert(left);
        }
        if (997 <= width && width <= 1129) {
            Left1 = (width - 1008) / 2;
        }
        if (462 <= width && width <= 747) {
            Left1 = (width - 470) / 2;
        }
        if (300 <= width && width <= 462) {
            Left1 = (width - 320) / 2;
        }
        $("#menu,#menubutton").show();
        $("#menu").animate({ left: Left1 }, 500, "easeOutQuart")
        $('.bg').fadeIn(200);

    });

    $("#back").click(function () {
        $("#menu").animate({ left: "100%" }, 500, "easeOutQuart", function () {
            $("#menu").hide();
        })
        $('.bg').fadeOut(800);
    });
    $("#sigup_now,.reg a").click(function () {
        k && (k = !1, $("#loginalert").animate({ top: -600 }, 400, "easeOutQuart", function () { $("#loginalert").hide(); k = !0 }), $(".loginmask").fadeOut(500))
        $("#reg_setp,#setp_quicklogin").show();
        $("#reg_setp").animate({ left: 0 }, 500, "easeOutQuart")
    });

    $(".back_setp").click(function () {
        "block" == $("#setp_quicklogin").css("display") && $("#reg_setp").animate({ left: "100%" }, 500, "easeOutQuart", function () { $("#reg_setp,#setp_quicklogin").hide() })
    });


});
//登陆验证
$(document).ready(function () {

    var options = {
        success: function (data) {
            var msg = data;
            if (msg == "account_error") {
                $(".login_warning").css("display", "block");
                $(".login_warning").text("您的帳號或者密碼不正確!");
            }
            //if (msg == "not_active") {
            //    $("#errortext").css("display", "block");
            //    $("#errortext").text("您的帳號尚未激活!");
            //}
            if (msg == "not_used") {
                $(".login_warning").css("display", "block");
                $(".login_warning").text("您的帳號被停用!");
            }
            if (msg == "success") {
                window.location.reload();
            }
        }
    };

    // ajaxForm
    $("#frmLogin").ajaxForm(options);
    $("#Account").click(function () {
        $(".login_warning").text("");
    });


});


//弹出登陆窗口
function openlogin() {
    $("#loginalert").show();
    $(".loginmask").fadeIn(500);
    $("#loginalert").animate({ top: 0 }, 400, "easeOutQuart");
}

function openlogin2() {
    $("#loginalert").show();
    $(".loginmask").fadeIn(500);
    $("#loginalert").animate({ top: 0 }, 400, "easeOutQuart");
}

function login() {
    var frm = document.getElementById("frmLogin");

    if (trim(frm.Account.value) == "") {
        alert("請輸入會員帳號!");
        frm.Account.focus();
        return false;
    }

    if (trim(frm.Password.value) == "") {
        alert("請輸入會員密碼!");
        frm.Password.focus();
        return false;
    }

    return true;
}
function trim(str) {
    regExp1 = /^ */;
    regExp2 = / *$/;
    return str.replace(regExp1, '').replace(regExp2, '');
}


function click2(id, rowCount) {
    var scrolltop = 0;
    // scrolltop = document.documentElement.scrollTop;
    //$(".content222").load('precinct.aspx?ID=' + id + "&rowCount=" + rowCount);
    var url = 'precinct.aspx?ID=' + id + "&rowCount=" + rowCount;
    //var url = "Default.aspx";
    // alert(url);
    intervalTheTen = setInterval("Fresh2(" + id + ")", 5000);
    var htmlobj = $.ajax({
        url: url,
        cache: false,
        async: false,
        complete: function (XHR, TS) { XHR = null }
    });
    $(".content222").html(htmlobj.responseText);
    $('.bg').fadeIn(200);
    $('.content222').fadeIn(400);
    $('.content_fixed').css("position", "fixed");
}
function clickAccount(url) {
    // scrolltop = document.documentElement.scrollTop;
    //$(".content222").load('precinct.aspx?ID=' + id + "&rowCount=" + rowCount);
    //隐藏导航		
    $("#menu").animate({ left: "100%" }, 500, "easeOutQuart", function () {
        $("#menu,#menubutton").hide();
        //隐藏导航end
    })

    $(".content222").load(url);
    $('.bg').fadeIn(200);
    $('.content222').fadeIn(400);
    $('.content_fixed').css("position", "fixed");
}
function bgclick() {
    $('.bg').fadeOut(800);
    $('.content222').fadeOut(800);
    $('.content222').html("");
    $('.content_fixed').css("position", "");
    //隐藏导航		
    $("#menu").animate({ left: "100%" }, 500, "easeOutQuart", function () {
        $("#menu,#menubutton").hide();
        //隐藏导航end
    })
    //定位滚动条
}

//弹出层关闭按钮
function closed() {
    $('.bg').fadeOut(800);
    $('.content222').fadeOut(800);
    $('.content222').html("");
    $('.content_fixed').css("position", "");
    //隐藏导航		
    $("#menu").animate({ left: "100%" }, 500, "easeOutQuart", function () {
        $("#menu,#menubutton").hide();
        //隐藏导航end
    })
    //定位滚动条
}

//var adsWin;
//广告弹出
function openAdsUrl(id) {
    title = '廣告';
   // id = "uWinContentM";
    url = "placing_ads.aspx?ID=" + id;
    //clearInterval(InterValObj);
    //countDown(1000 * 10);
    if (advtime != id) {
        tipsWindown(title, "url:" + url, 496, 370, "true", "10000", "true", id);
    }
    else {
        tipsWindown(title, "url:" + url, 496, 370, "true", "5000", "true", id);
    }
    //判断是否是当前账户重复点击参与竞投，是则第二次广告只有5秒
    advtime = id;

    //tipsWindown(title, "id:" + "simTestContent", 600, 230, "true", "", "true", "simTestContent");
}

// 现在出价----按钮
// 先放10秒的促销广告
//type 为是否为当前投中者，ID则为产品ID，timeadd为增加的时间段，needpoint为竞投所需分数。
function nowBid(type, AuctionId, timeAdd, NeedPoint) {
    if (type) {
        alert("您已是最新投中者！");
        // alert(WinningBidder);
    }
    else {
        // 检查这个会员总E元是否达到目前的竞投价，达到则参与竞投，否则弹出消息拒绝竞投
        if (NeedPoint) {
            //广告
            openAdsUrl(AuctionId);
           // alert("dd");
            // 会员开始E元竞投
            timeAddRange = getRandomTime(timeAdd);
            var url = 'update_auction_info.aspx?ID=' + AuctionId + "&timeAdd=" + timeAddRange;
            $.get(url, function (data, status) {
                if (data == "success") { }
            });
        }
        else {
            alert('對不起，您的积分餘額不夠，無法參與本次競投!');
        }
    }
}


function ChecEmail() {
    var frm = document.getElementById("frmLogin");

    if (trim(frm.Account.value) == ""){
        alert("請輸入會員帳號!");
        frm.Account.focus();
        return false;
    }

    if (trim(frm.Password.value) == "") {
        alert("請輸入會員密碼!");
        frm.Password.focus();
        return false;
    }

    return true;
}
function isEmail(mail) {
    return (new RegExp(/^\w+((-\w+)|(\.\w+))*\@[A-Za-z0-9]+((\.|-)[A-Za-z0-9]+)*\.[A-Za-z0-9]+$/).test(mail));
}

function chcekFrm(){
    var frm = document.getElementById("frmRegister");


    if (trim(frm.Email.value) == "") {
        alert("請輸入電郵地址！");
        frm.Email.focus();
        return false;
    }

    if (!isEmail(trim(frm.Email.value))) {
        alert("請輸入正確的電郵地址！");
        frm.Email.focus();
        return false;
    }
    if (trim(frm.Account.value) == "") {
        alert("請輸入會員帳號");
        frm.Account.focus();
        return false;
    }
    if (trim(frm.password.value) == "") {
        alert("請輸入會員密碼!");
        frm.password.focus();
        return false;
    }
    if (trim(frm.password2.value) == "" || trim(frm.password.value) != trim(frm.password2.value)) {
        alert("輸入密碼不一致!");
        frm.password2.focus();
        return false;
    }

    if (document.getElementById("isread").checked != true)
    {
        popTips();
        return false;
    }
    return true;
}
$(document).ready(function (){
    var options = {
        success: function (data) {
            var msg = data;
            if(msg =="error_Account")
            {
                $("#error_Accountdiv").css("display","block");
                $("#error_Account").html("用户名错误,用户名已存在!");
            }
            if (msg == "error_Email") {
                $("#error_Emaildiv").css("display", "block");
                $("#error_Email").html("Email已存在!");
            }
            if (msg == "not_Auth") {
                $("#error_Authdiv").css("display", "block");
                $("#error_Auth").html("Facebook還沒有授權!");
            }
            if(msg == "sud")
            {
                if (confirm("注册成功，是否登录?")) {
                    $("#loginalert").show();
                    $(".loginmask").fadeIn(500);
                    $("#loginalert").animate({ top: 0 }, 400, "easeOutQuart");
                    $("#reg_setp").animate({ left: "100%" }, 500, "easeOutQuart", function () { $("#reg_setp,#setp_quicklogin").hide() });
                }
                else {
                    window.location.href = "index.aspx";
                }
            }                
        }
    };

    // ajaxForm
    $("#frmRegister").ajaxForm(options);

    $("#user").click(function () {
        $("#error_Accountdiv").css("display", "none");
    });
    $("#email").click(function () {
        $("#error_Emaildiv").css("display", "none");
    });
});
function Fresh2(id) {
    var htmlobj = $.ajax({
        type: 'POST',
        url: 'WebService.asmx/AuctionsHistory',
        data: '{id:'+id +'}',
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        success: function (result) {
            var json = result.d;
            var str = "";
            for (var i = 0; i < json.length; i++) {
                str += json[i]["MemberID"] + "-" + json[i]["BidDate"];
            }
        }
    });
}