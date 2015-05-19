<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/ProvideTemplateLeft.master" CodeFile="provide_login.aspx.cs" Inherits="FrontView_provide_login" %>

<asp:Content ID="Contect18" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <script type="text/javascript">
        function ProvideLogin() {
            var frm = document.getElementById("<%=frmProvideLogin.ClientID%>");
            if (trim(frm.Account.value) == "") {
                alert("請輸入帳號 或者 電子郵件");
                frm.Account.focus();
                return false;
            } else if (trim(frm.Password.value) == "") {
                alert("請輸入密碼");
                frm.Password.focus();
                return false;
            } else {
                return true;
            }
        }
        function enter() {
            var frm = document.getElementById("<%=button1.ClientID%>");
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
                  <nav class="navBar">您的位置： <a href="#" class="rootNav">首頁</a> &gt; <span class="currentNav">商戶登入</span></nav>
                  <h3 class="cTitle">
                    <strong class="bgL">商戶登入</strong><i class="bgR"></i>
                  </h3>
                </div>

                <section class="centerM centerMPad0">
                	<div class="rBox rBox1Bg1">                    
                    <p class="rbMT"><i class="MTL"></i><i class="MTC"></i><i class="MTR"></i></p>
                    <div class="rBoxSkin">
                    	<div class="rowSpace rowSpace2"></div>
                         <%if (!errorMsg.Equals(" ")) {%>
												<div class="rBox rBox0Bg1 rBoxTipMsgBox noteMsg"><!--noteMsg okMsg warningMsg errorMsg-->
                          <p class="rbMT"><i class="MTL"></i><i class="MTC"></i><i class="MTR"></i></p>
                          <div class="rBoxSkin msgContent icoSmall"><i class="icoS"></i>
                            <div class="msg">
                              <p>
									<% =errorMsg %>>
                                    
															</p>
                            </div>
                          </div>
                          <p class="rbMB"><i class="MBL"></i><i class="MBC"></i><i class="MBR"></i></p>
                        </div>
									<%} %>
                    	<form id="frmProvideLogin" name="frmProvideLogin" method="post" runat="server" onsubmit="return ProvideLogin()">
                      <input type="hidden" name="opt" value=""/>
                      <div class="rBoxM">
                        <dl class="utab formBox margB20 f2Col lineDashedHBUtrs">
                        	<dt class="tipMsg">
                            <div class="msgContent icoSmall noteMsg floatR" style="margin-bottom:-25px;"><i class="icoS"></i>
                              <p class="msg"><i class="starMsg">*</i>为必填选项</p>
                            </div>
                          </dt>
                          <dt class="utr2 trHx trHx1"><span class="trHxList">商戶登入</span></dt>
                          <dt class="utr"><span class="utd1 uLabel">帳號 / 電子郵件:<i class="starMsg">*</i></span>
                            <p class="utd2 uValue">                                
                              <input type="text" name="Account" value="" size="30" onkeydown="enter()"/>
                            </p>
                          </dt>
                          <dt class="utr"><span class="utd1 uLabel">密碼<i class="starMsg">*</i></span>
                            <p class="utd2 uValue">
                            	<input type="password" name="Password" value="" size="30" onkeydown="enter()" />
                            </p>
                          </dt>
                        </dl>
                        
                        <div class="btnLib bBtn padTB10 borderT2">                          
                          <span class="uCell floatL">
                            <%--<a href="javascript:ProvideLogin()" class="btn btnEm1"><strong class="btnL"><i class="ico submitBtn"></i>登入</strong><i class="btnR"></i></a>--%> 
                              <asp:LinkButton ID="button1" name="button1" runat="server" class="btn btnEm1" OnClick="button1_Click"><strong class="btnL"><i class="ico submitBtn"></i>登入</strong><i class="btnR"></i></asp:LinkButton>   
                            <a href="provide_join.aspx" class="btn btn1"><strong class="btnL"><i class="ico defaultBtn"></i>注册</strong><i class="btnR"></i></a>                              
                          </span>                         
                      	</div>
                      </div>
                      </form>
                    </div>
                    <p class="rbMB"><i class="MBL"></i><i class="MBC"></i><i class="MBR"></i></p>
                  </div>
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