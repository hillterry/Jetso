<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/templateleft.master" CodeFile="member_login.aspx.cs" Inherits="FrontView_member_login" %>

<asp:Content ID="Content8" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <script type="text/javascript">
        function MemberLogin1() {
            var frm = document.getElementById("<%=frmMemberLogin1.ClientID %>");
        if (trim(frm.Account1.value) == "") {
            alert("請輸入帳號 或者 電子郵件");
            frm.Account1.focus();
            return false;
        }
        if (trim(frm.Password1.value) == "") {
            alert("請輸入密碼");
            frm.Password1.focus();
            return false;
        }
        return true;
    }
        //清除字符串左右空格
        function trim(str) {
            regExp1 = /^ */;
            regExp2 = / *$/;
            return str.replace(regExp1, '').replace(regExp2, '');
        }

    function enter() {
        var frm = document.getElementById("<%=button1.ClientID %>");
        if (event.keyCode == 13) {

            frm.click();
        }
    }
    </script>

    <!--primary:begin-->
    <div class="primaryBox">
        <!--centerBox:begin-->
        <div class="centerBox">
            <!--centerContent:begin-->
            <div class="centerContent">
                <div class="centerT">
                    <nav class="navBar">您的位置： <a href="#" class="rootNav">首頁</a> &gt; <span class="currentNav">會員登入</span></nav>
                    <h3 class="cTitle">
                        <strong class="bgL">會員登入</strong><i class="bgR"></i>
                    </h3>
                </div>

                <section class="centerM centerMPad0">
                    <div class="baseMT baseMTEm1Bg1"><i class="MTL"></i><i class="MTC"></i><i class="MTR"></i></div>
                    <%if (!errorMsg.Equals(" "))
                      {%>
                    <div class="rBox rBox0Bg1 rBoxTipMsgBox noteMsg">
                        <!--noteMsg okMsg warningMsg errorMsg-->
                        <p class="rbMT"><i class="MTL"></i><i class="MTC"></i><i class="MTR"></i></p>
                        <div class="rBoxSkin msgContent icoSmall">
                            <i class="icoS"></i>
                            <div class="msg">
                                <p>
                                    <% =errorMsg %>>
                                </p>
                            </div>
                        </div>
                        <p class="rbMB"><i class="MBL"></i><i class="MBC"></i><i class="MBR"></i></p>
                    </div>
                    <%} %>
                    <form id="frmMemberLogin1" method="post" onsubmit="return MemberLogin1()" runat="server">
                        <input type="hidden" name="opt" value="" />
                        <dl class="utab formBox f2Col border1 baseMM1 lineDashedHBUtrs">
                            <dt class="utr2 trHx trHx3"><span class="trHxList">登入</span><span class="msg floatR margR10"><i class="starMsg">*</i>为必填选项</span></dt>
                            <dt class="utr"><span class="utd1 uLabel">帳號 / 電子郵件:<i class="starMsg">*</i></span>
                                <p class="utd2 uValue">
                                    <input type="text" name="Account1" value="" size="30" onkeydown="enter()" />
                                </p>
                            </dt>
                            <dt class="utr"><span class="utd1 uLabel">密碼<i class="starMsg">*</i></span>
                                <p class="utd2 uValue">
                                    <input type="password" name="Password1" value="" size="30" onkeydown="enter()" />
                                </p>
                            </dt>
                            <dt class="noLineDashedHBMask"></dt>
                            <dt class="utabbd padTB10 borderT2">
                                <p class="btnLib bBtn utd2">
                                    <span class="uCell">
                                        <%--                          <a href="javascript:MemberLogin1()" class="btn btnEm1"><strong class="btnL"><i class="ico submitBtn"></i>登入</strong><i class="btnR"></i></a>--%>
                                        <%--<asp:linkbutton ID="button1" runat="server" class="btn btnEm1" OnClick="Unnamed1_Click"><strong class="btnL"><i class="ico submitBtn"></i>登入</strong><i class="btnR"></i></asp:linkbutton>--%>
                                        <asp:LinkButton ID="button1" class="btn btnEm1" OnClick="button1_Click" runat="server"><strong class="btnL"><i class="ico submitBtn"></i>登入</strong><i class="btnR"></i></asp:LinkButton>

                                    </span>
                                    <span class="uCell">
                                        <a href="member_forget_password.asp"><strong class="btnL"><i class="ico submitBtn"></i>忘记密码?</strong><i class="btnR"></i></a>
                                    </span>
                                </p>
                            </dt>
                            <dt class="utr2 trHx trHx3"><span class="trHxList">無法一直登入嗎？</span></dt>
                            <figure class="utabbd inHtmlContent font14 padLR10">
                                <p>若您還未成為Net Rewards會員，<a href="member_join_info.aspx">請按這裡</a>來加入Net Rewards。</p>
                            </figure>
                        </dl>
                    </form>
                    <div class="baseMB baseMBEm1Bg1"><i class="MBL"></i><i class="MBC"></i><i class="MBR"></i></div>
                </section>

            </div>
            <!--centerContent:end-->
        </div>
        <!--centerBox:end-->
    </div>
    <!--primary:end-->

    </div>
      </div>
      <!--bdInBox:end-->
    </div>
    <!--bdOutBox:end-->
    </section>
  <!--g-body-wrap:end-->

</asp:Content>
