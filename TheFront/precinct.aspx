<%@ Page Language="C#" AutoEventWireup="true" CodeFile="precinct.aspx.cs" Inherits="TheFront_precinct" %>

<!DOCTYPE html>
<html lang="en" style="-webkit-text-size-adjust: 100%; -ms-text-size-adjust: 100%;">
<head>
    <meta charset="utf-8" />
    <meta name="viewport" content="width=device-width, initial-scale=1, minimum-scale=1, maximum-scale=1, user-scalable=0" />
    <title>拍卖网</title>
    <link href="css/style.css" rel="stylesheet" type="text/css" />
    <link href="css/style_2.css" rel="stylesheet" type="text/css" />
    <link href="css/css2.css" rel="stylesheet" type="text/css" />
    <link href="css/account_executive.css" rel="stylesheet" type="text/css">
    <%--<script type="text/javascript" src="js/jquery.min.js"></script>--%>
     <%--<script type="text/javascript" src="js/cloud-zoom.js"></script>--%>
    <link href="css/cloud-zoom.css" rel="stylesheet" type="text/css" />
   
</head>

<body>
    <style>
        .precwin1{width:287px; height:318px;}
        .precwin2{ width:85px; height:78px;}
    </style>

    <form id="form1" runat="server">
        <%--<script>
            $(document).ready(function () {
                $('.cloud-zoom, .cloud-zoom-gallery').CloudZoom();
            });
        </script>--%>
        <div class="bai">
            <asp:DataList ID="DataList1" runat="server" DataSourceID="ObjectDataSource3">
                <ItemTemplate>
            <div class="tou_10">
                <div class="tou_1000">
                    <span class="linggc">產品介紹</span>
                    <div class="fot_x">
                        <%if (islogin)
                          { %>
                        <a id="shareFacebook" href="#">
                            <img src="images/fot_x_06.png" class="fot1" /></a><a href="#" onclick="closed()"><img src="images/fot_x6_03.png" class="fot2" /></a>
                        <%}
                          else
                          { %>
                        <a href="#" onclick="openlogin()">
                            <img src="images/fot_x_06.png" class="fot1" /></a><a href="#" onclick="closed()"><img src="images/fot_x6_03.png" class="fot2" /></a>
                            <%} %>
                    </div>
                </div>
            </div>
                    <input type="hidden" value='<%#Eval("ID")%>' id="AuctionId" />
                    <div class="l-content pure-hidden-desktop">
                        <div class="rwerw">
                            <div class="demo">
                                <div class="zoom-section">
                                    <div class="zoom-small-image">
                                        <a href='../<%#Eval("ProductImage1") %>' class='cloud-zoom' id='zoom1' rel="position:'inside',showTitle:false,adjustX:-4,adjustY:-4">
                                            <img src='../<%#Eval("ProductImage1") %>' alt='' border="0" title="Your caption here" class="precwin1" /></a>
                                    </div>
                                    <div class="clar"></div>
                                    <div class="zoom-desc">
                                        <a href='../<%#Eval("ProductImage1") %>' class='cloud-zoom-gallery' title='Red' rel="useZoom: 'zoom1', smallImage: '../<%#Eval("ProductImage1") %>'">
                                            <img src='../<%#Eval("ProductImage1") %>' alt="Thumbnail 1" border="0" class="zoom-tiny-image precwin2" /></a>
                                        <a href='../<%#Eval("ProductImage1") %>' class='cloud-zoom-gallery' title='Blue' rel="useZoom: 'zoom1', smallImage: '../<%#Eval("ProductImage1") %>'">
                                            <img src='../<%#Eval("ProductImage1") %>' alt="Thumbnail 2" border="0" class="zoom-tiny-image precwin2"  /></a>
                                        <a href='../<%#Eval("ProductImage1") %>' class='cloud-zoom-gallery' title='Blue' rel="useZoom: 'zoom1', smallImage: '../<%#Eval("ProductImage1") %>'">
                                            <img src='../<%#Eval("ProductImage1") %>' alt="Thumbnail 3" border="0" class="zoom-tiny-image precwin2" /></a>
                                    </div>
                                </div>
                                <!--zoom-section end-->
                            </div>
                            <right_b class="right_ba">
<ul>
<li class="bold"><%#Eval("ProductName") %></li>
<li class="green bold">零售價 : HK$<%#Eval("MarkPrice")%> </li>
<li class="font14"><%#Eval("ProductBrief")%></li>
<li class="nserting-coil fbb51 fontsize20" id="biddpice<%#Eval("ID")%>">HK￥<%#Eval("BiddingPriceNow")%></li>
<li class="nserting-coil green fontsize16 imgperson" id="winBidder<%#Eval("ID")%>"> <%#Eval("member.nickName")%></li>
<li class="nserting-coil green fontsize20">
    <div class="img-bi"><img src="images/igm1_10.png"/></div> 
    <div class="font30" id="remainingTime<%#Eval("ID")%>"></div>
    <div class="input1">
        <%if (islogin)
          { %>
          <%if (isWiner)
            { %>
            <a href="javascript:nowBid(1,'<%#Eval("ID")%>','<%#Eval("TimeAddRange")%>','<%=NeedPoint%>')" class="ba_red-3" id="11">現在出價</a>
          <%}
            else
            { %>
           <a href="javascript:nowBid(0,'<%#Eval("ID")%>','<%#Eval("TimeAddRange")%>','<%=NeedPoint%>')" class="ba_red-3" id="11">現在出價</a>
            <%} %>
         <%}
          else
          { %>
           <div><a href="#" onclick="openlogin()" class="ba_red-3" data-reveal-id="myModal" id="111">現在出價</a></div>
            <%} %>
    </div>
    <div class="clar"></div></li>
<li class="nserting-coil Automatic-tb Automatic-bid" style="display:none"><span class="fbb51">自動出價 ：</span> 自動出價 ( 必須登入方可使用 )</li>
<li class="nserting-coil Automatic-tb A-cash-refund"><span class="fbb51">現金退還: 取回你部份的bids!</span><br/>現金退還 第一名 288 bids <br /> 
    <div id="theTen<%#Eval("ID") %>">
    <asp:DataList ID="DataList3" runat="server" DataSourceID="ObjectDataSource1">
                                                        <ItemTemplate>
                                                            <asp:Label ID="Label1" CssClass="automa_mo padding3" runat="server"><%#Eval("member.nickName")%> -<%#Eval("BidDate") %> </asp:Label>
                                                        </ItemTemplate>
                                                    </asp:DataList>
                                                    <asp:ObjectDataSource ID="ObjectDataSource1" runat="server" DataObjectTypeName="Jetso.Data.AuctionHistory" DeleteMethod="Delete" InsertMethod="Insert" OldValuesParameterFormatString="original_{0}" SelectMethod="Search" TypeName="Jetso.Data.AuctionHistory" UpdateMethod="Update">
                                                        <SelectParameters>
                                                            <asp:Parameter Name="key" Type="String" />
                                                            <asp:QueryStringParameter DefaultValue="" Name="ID" QueryStringField="ID" Type="Int32" />
                                                            <asp:Parameter Name="orderClause" Type="String" DefaultValue="ID DESC" />
                                                            <asp:Parameter Name="startRowIndex" Type="Int32" />
                                                            <asp:Parameter Name="maximumRows" Type="Int32" DefaultValue="10" />
                                                        </SelectParameters>
                                                    </asp:ObjectDataSource>
            </div>

        </li>
</ul>
</right_b>
                            <div class="clar"></div>
                        </div>
                        <div class="product-presentation">產品介紹</div>
                        <div class="zj-1">
                            <%#Eval("ProductDescription") %>
                        </div>
                        <div class="clar"></div>

                    </div>
                </ItemTemplate>
            </asp:DataList>
            <asp:ObjectDataSource ID="ObjectDataSource3" runat="server" DataObjectTypeName="Jetso.Data.Auction" DeleteMethod="Delete" InsertMethod="Insert" OldValuesParameterFormatString="original_{0}" SelectMethod="FindByID" TypeName="Jetso.Data.Auction" UpdateMethod="Update">
                <SelectParameters>
                    <asp:QueryStringParameter Name="id" QueryStringField="ID" Type="Int32" />
                </SelectParameters>
            </asp:ObjectDataSource>
        </div>
    </form>


    <script>
        
           
        
        $(function () {
            $("#shareFacebook").click(function () {
                var id = $('#AuctionId').val();
                $.ajax({
                    type: 'POST',
                    url: 'ShareFacebook.ashx?id=' + id,
                    dataType: "text",

                    success: function (result) {
                        if (result == "success") {
                            alert("分享成功");
                        } else if (result == "error") {
                            alert("分享出错");
                        } else if (result == "auth_error") {
                            alert("facebook授權过期,請重新授權");
                            window.open("facebook_Expire.aspx","重新授權",'width=200,height=100');
                        }

                    },

                    error: function (XMLHttp, textStatus, errorThrown) {
                        //alert(XMLHttp.status);
                        //alert(XMLHttp.readyState);
                        //alert(XMLHttp.responseText);

                    },


                });
            });
        });

    </script>
</body>

</html>
