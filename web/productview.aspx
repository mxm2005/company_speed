<%@ Page Language="C#" AutoEventWireup="true" CodeFile="productview.aspx.cs" Inherits="productview" %>

<%@ Register TagName="head" TagPrefix="UC" Src="~/control/head.ascx" %>
<%@ Register TagName="product" TagPrefix="UC" Src="~/control/product_list.ascx" %>
<%@ Register TagName="foot" TagPrefix="UC" Src="~/control/foot.ascx" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>产品中心</title>
    <link href="style/main.css" type="text/css" rel="stylesheet" />
</head>
<body class="other_body">
    <UC:head ID="head2" runat="server" />
    <div id="banner">
        <div id="bannercontent">
            <img id="topBanner" runat="server" src="images/product_05.jpg" alt="" width="980" height="190" /></div>
    </div>
    <div class="clear">
    </div>
    <div id="position">
        <p>
            &nbsp;当前位置：<a href="/" class="agray">首页</a> - <a href="product.aspx">产品中心</a><asp:Label ID="lbl_nav" runat="server"></asp:Label>
        </p>
    </div>
    <div id="content">
        <div id="content-left">
            <UC:product ID="prod" runat="server" />
        </div>
        <div id="content-right">
            <div style="background: url(images/product_shuoming.jpg) no-repeat 0px 15px;">
                <p style="padding-top: 35px; padding-left: 30px; font-size: 14px; color: #FFF; font-family: '微软雅黑', '宋体';">
                    产品中心</p>
                <p style="margin-top: 20px; padding-left: 20px; padding-right: 20px; line-height: 2em;">
                </p>
                <div>
                </div>
                <div style="width: 730px;">
                    <div class="viewpic">
                        <div class="bigpic">
                            <div class="bigpic-cont" id="divImg" runat="server">
                            </div>
                        </div>
                    </div>
                    <div class="viewright">
                        <div class="viewtitle">
                            产品名称：<asp:Label ID="lbl_name" runat="server"></asp:Label>
                            <br />
                            规格型号：<asp:Label ID="lbl_model" runat="server"></asp:Label>
                        </div>
                        <%--<div class="viewpic1">
                            <a href="javascript:alert('暂不接受在线订购，请来电咨询')">
                                <img src="images/buy.jpg"></a>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span
                                    id="spanLink" runat="server"></span></div>--%>
                        <div id="video" class="video" style="vertical-align:top;margin-top:10px;">
                            <%--<object classid="clsid:D27CDB6E-AE6D-11cf-96B8-444553540000" codebase="http://download.macromedia.com/pub/shockwave/cabs/flash/swflash.cab#version=6,0,29,0"
                                width="300" height="230">
                                <param name="movie" value="/swf/vcastr22.swf?vcastr_file=/vidiofile/<%= _vidio %>">
                                <param name="quality" value="high">
                                <param name="allowFullScreen" value="true" />
                                <embed src="/swf/vcastr22.swf?vcastr_file=/vidiofile/<%= _vidio %>"
                                    quality="high" pluginspage="http://www.macromedia.com/go/getflashplayer" type="application/x-shockwave-flash"
                                    width="300" height="230">
</embed>
                            </object>--%>
                        </div>
                    </div>
                    <div class="clear">
                    </div>
                    <div style="height: 10px;">
                    </div>
                    <div style="height: 29px; background: url(images/show.jpg) no-repeat; width: 719px;
                        margin-top: 20px; height: auto;">
                        <div class="productview" id="divDesc" runat="server">
                        </div>
                    </div>
                    <div style="line-height: 26px;">
                        <div id="divPrev" runat="server">
                            
                        </div>
                        <div id="divNext" runat="server">
                            
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
    <div class="clear">
    </div>
    <UC:foot ID="foot1" runat="server" />
</body>
</html>
<script type="text/javascript" src="/js/jquery.js"></script>
    <script type="text/javascript"> 
    var path="<%= _video %>";
    $(function(){
        var str='<object classid="clsid:D27CDB6E-AE6D-11cf-96B8-444553540000" codebase="http://download.macromedia.com/pub/shockwave/cabs/flash/swflash.cab#version=6,0,29,0" '+
                    'width="300" height="230">'+
                    '<param name="movie" value="/swf/vcastr22.swf?vcastr_file='+path+'">'+
                    '<param name="quality" value="high">'+
                    '<param name="allowFullScreen" value="true" />'+
                    '<embed src="/swf/vcastr22.swf?vcastr_file='+path+'" quality="high"'+
                        'pluginspage="http://www.macromedia.com/go/getflashplayer" type="application/x-shockwave-flash"'+
                        'width="300" height="230"></embed></object>';
        $("#video").html(str);
    });
    </script>