<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Account_infor.aspx.cs" Inherits="TheFront_Account_infor" %>

<!DOCTYPE html>
<html lang="en" style="-webkit-text-size-adjust: 100%; -ms-text-size-adjust: 100%;">
<head>
    <meta charset="utf-8" />
    <meta name="viewport" content="width=device-width, initial-scale=1, minimum-scale=1, maximum-scale=1, user-scalable=0" />
    <title>拍卖网</title>
    <link href="css/style.css" rel="stylesheet" type="text/css" />
    <link href="css/account_executive.css" rel="stylesheet" type="text/css">
    <link href="css/style_2.css" rel="stylesheet" type="text/css" />
    <link href="css/css2.css" rel="stylesheet" type="text/css" />

    <script type="text/javascript">
        $(document).ready(function () {
            $("#btnAjaxSubmit").click(function () {
                var education = $("#<%=frmeducation.ClientID%>").val();
                //  alert(education);
                var income = $("#<%=frmincome.ClientID%>").val();
                var gender = $("#<%=frmgender.ClientID%>").val();
                var options = {
                    url: '../FrontView/checkInfor.ashx?ed=' + education + '&ic=' + income + '&gd=' + gender,
                    type: 'post',
                    dataType: 'text',
                    data: $("#frmInfor").serialize(),
                    success: function (data) {

                    }
                };
                $.ajax(options);
                return false;
            });
        });
    </script>

</head>

<body>
    <div class="bai">
        <div class="vessel">
            <div class="head">设置账户信息</div>
            <img src="images/gimg.jpg" height="306" border="0" class="gimg" />
            <nav id="navigation">
                <a href="account_executive.html" class="nav-btn">设置账户信息<span class="arr"></span></a>
                <ul>
                    <li onclick="clickAccount('Account_executive.aspx')"><a href="#">賺取bids點</a></li>
                    <li><a href="account_To_win_the_2.html">勝出拍賣</a></li>
                    <li onclick="clickAccount('Account_Bids.aspx')"><a href="#">我的 BIDS</a></li>
                    <li onclick="clickAccount('Account_infor.aspx')" class="active"><a href="#">設置帳戶資訊</a></li>
                    <li onclick="clickAccount('Account_ChangeEmail.aspx')"><a href="#">修改郵箱</a></li>
                    <li onclick="clickAccount('Account_Key.aspx')"><a href="#">修改密碼</a></li>
                    <li><a href="account_share_7.html">分享統計</a></li>
                    <li onclick="clickAccount('Account_Friends.aspx')"><a href="#">邀请朋友</a></li>
                    <li><a href="account_marketing_9.html">瀏覽推介歷史</a></li>

                </ul>
            </nav>
            <form id="frmInfor" runat="server" name="frmInfor" method="post">
                <div class="width770">
                    <div class="setting_up">
                        <ul class="Form">
                            <li class="width80" id="email11">電郵</li>
                            <li>
                                <asp:TextBox ID="frmemail" name="frmemail" class="width250 width2" runat="server" Enabled="false"></asp:TextBox>
                                <input type="hidden" name="ID" value="<%=ID %>" />
                                &nbsp;&nbsp;修改 </li>
                            <div class="clar"></div>
                            <li class="width80">用戶名 *</li>
                            <li>
                                <asp:TextBox ID="frmname" name="frmname" class="width250" runat="server" Enabled="false"></asp:TextBox>

                            </li>
                            <div class="clar"></div>
                            <li class="width80">姓名</li>
                            <li>
                                <asp:TextBox ID="frmnickName" name="frmnickName" class="width250" runat="server"></asp:TextBox>
                            </li>
                            <div class="clar"></div>
                            <li class="width80">性别</li>
                            <li>
                                <asp:DropDownList ID="frmgender" DataValueField="value" DataTextField="value" runat="server"></asp:DropDownList>
                            </li>
                            <div class="clar"></div>
                            <li class="width80">出生日期</li>
                            <li>
                                <select id="frmbirthday" name="frmbirthday" size="1">
                                    <option value="2013">2013</option>
                                    <option value="2012">2012</option>
                                    <option value="2011">2011</option>
                                    <option value="2010">2010</option>
                                    <option value="2009">2009</option>
                                    <option value="2008">2008</option>
                                    <option value="2007">2007</option>
                                    <option value="2006">2006</option>
                                    <option value="2005">2005</option>
                                    <option value="2004">2004</option>
                                    <option value="2003">2003</option>
                                    <option value="2002">2002</option>
                                    <option value="2001">2001</option>
                                    <option value="2000">2000</option>
                                    <option value="1999">1999</option>
                                    <option value="1998">1998</option>
                                    <option value="1997">1997</option>
                                    <option value="1996">1996</option>
                                    <option value="1995">1995</option>
                                    <option value="1994">1994</option>
                                    <option value="1993">1993</option>
                                    <option value="1992">1992</option>
                                    <option value="1991">1991</option>
                                    <option value="1990">1990</option>
                                    <option value="1989">1989</option>
                                    <option value="1988">1988</option>
                                    <option value="1987">1987</option>
                                    <option value="1986">1986</option>
                                    <option value="1985">1985</option>
                                    <option value="1984">1984</option>
                                    <option value="1983">1983</option>
                                    <option value="1982">1982</option>
                                    <option value="1981">1981</option>
                                    <option value="1980">1980</option>
                                    <option value="1979">1979</option>
                                    <option value="1978">1978</option>
                                    <option value="1977">1977</option>
                                    <option value="1976">1976</option>
                                    <option value="1975">1975</option>
                                    <option value="1974">1974</option>
                                    <option value="1973">1973</option>
                                    <option value="1972">1972</option>
                                    <option value="1971">1971</option>
                                    <option value="1970">1970</option>
                                    <option value="1969">1969</option>
                                    <option value="1968">1968</option>
                                    <option value="1967">1967</option>
                                    <option value="1966">1966</option>
                                    <option value="1965">1965</option>
                                    <option value="1964">1964</option>
                                    <option value="1963">1963</option>
                                    <option value="1962">1962</option>
                                    <option value="1961">1961</option>
                                    <option value="1960">1960</option>
                                    <option value="1959">1959</option>
                                    <option value="1958">1958</option>
                                    <option value="1957">1957</option>
                                    <option value="1956">1956</option>
                                    <option value="1955">1955</option>
                                    <option value="1954">1954</option>
                                    <option value="1953">1953</option>
                                    <option value="1952">1952</option>
                                    <option value="1951">1951</option>
                                    <option value="1950">1950</option>
                                </select></li>
                            <div class="clar"></div>
                            <li class="width80">女儿</li>
                            <li>
                                <asp:TextBox ID="frmgirl" name="frmgirl" class="width250" runat="server"></asp:TextBox>
                            </li>
                            <div class="clar"></div>
                            <li class="width80">儿子</li>
                            <li>
                                <asp:TextBox ID="frmboy" name="frmboy" class="width250" runat="server"></asp:TextBox>
                            </li>
                            <div class="clar"></div>
                            <li class="width80">教育程度</li>
                            <li>
                                <asp:DropDownList ID="frmeducation" DataValueField="value" DataTextField="value" runat="server"></asp:DropDownList>
                            </li>
                            <div class="clar"></div>
                            <li class="width80">收入</li>
                            <li>
                                <asp:DropDownList ID="frmincome" runat="server" DataValueField="value" DataTextField="value"></asp:DropDownList>
                            </li>
                            <div class="clar"></div>
                            <li class="width80">介绍人</li>
                            <li>
                                <asp:TextBox ID="IntroduceName" name="IntroduceName" class="width250" runat="server" Enabled="false"></asp:TextBox>
                            </li>
                            <div class="clar"></div>
                            <li class="width80"></li>
                            <li class="width80">
                                <input type="submit" id="btnAjaxSubmit" value="提交" class="ba_red-3" /></li>
                        </ul>
                    </div>
                </div>
            </form>
        </div>
    </div>
</body>
</html>
