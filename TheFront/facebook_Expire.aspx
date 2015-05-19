<%@ Page Language="C#" AutoEventWireup="true" CodeFile="facebook_Expire.aspx.cs" Inherits="TheFront_facebook_Expire" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>

     <div id="fb-root"></div>
<script>
    window.fbAsyncInit = function () {
        FB.init({
            appId: '409081319224555', // App ID
            status: true, // check login status
            cookie: true, // enable cookies to allow the server to access the session
            xfbml: true  // parse XFBML
        });

        FB.Event.subscribe('auth.authResponseChange', function (response) {
            if (response.status === 'connected') {
                // the user is logged in and has authenticated your
                // app, and response.authResponse supplies
                // the user's ID, a valid access token, a signed
                // request, and the time the access token 
                // and signed request each expire
                var uid = response.authResponse.userID;
                var accessToken = response.authResponse.accessToken;

                var form = document.createElement("form");
                form.setAttribute("method", 'post');
                form.setAttribute("action", 'FaceBook_Expire.ashx');

                var field = document.createElement("input");
                field.setAttribute("type", "hidden");
                field.setAttribute("name", 'accessToken');
                field.setAttribute("value", accessToken);

                form.appendChild(field);

                document.body.appendChild(form);
                form.submit();
                alter('asdf'); window.opener.location.reload(); window.close();
            } else if (response.status === 'not_authorized') {

            } else {

            }
        });
    };

    // Load the SDK Asynchronously
    (function (d) {
        var js, id = 'facebook-jssdk', ref = d.getElementsByTagName('script')[0];
        if (d.getElementById(id)) { return; }
        js = d.createElement('script'); js.id = id; js.async = true;
        js.src = "//connect.facebook.net/en_US/all.js";
        ref.parentNode.insertBefore(js, ref);
    }(document));
</script>

    <form id="form1" runat="server">
    <div>
        <%if(success){%>
        <a href="https://www.facebook.com/dialog/oauth?response_type=token&display=popup&client_id=409081319224555&redirect_uri=http://bidding.wowmyweb.com/TheFront/facebook_Expire.aspx?ID=6&scope=publish_actions">facebook授权过期，點擊進入facebook重新進行授權</a>
        <%} else{%>
        授权完毕，请关闭此选项框
        <%} %>
    </div>
    </form>
</body>
   
</html>