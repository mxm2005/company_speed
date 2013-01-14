<%@ Page Language="C#" AutoEventWireup="true" CodeFile="product.aspx.cs" Inherits="product" %>

<%@ Register TagName="head" TagPrefix="UC" Src="~/control/head.ascx" %>
<%@ Register TagName="product" TagPrefix="UC" Src="~/control/product_list.ascx" %>
<%@ Register TagName="foot" TagPrefix="UC" Src="~/control/foot.ascx" %>
<%@ Register Assembly="AspNetPager" Namespace="Wuqi.Webdiyer" TagPrefix="pager" %>
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
            &nbsp;当前位置：<a href="/" class="agray">首页</a> - 产品中心
        </p>
    </div>
    <div id="content">
        <div id="content-left">
            <UC:product ID="prod" runat="server" />
        </div>
        <div id="content-right">
            <div style="background: url(images/product_shuoming.jpg) no-repeat 0px 15px;display:table;">
                <p style="padding-top: 35px; padding-left: 30px; font-size: 14px; color: #FFF; font-family: '微软雅黑', '宋体';">
                    产品中心</p>
                <%--<p style="margin-top: 20px; padding-left: 20px; padding-right: 20px; line-height: 2em;">
                    <span style="font-weight: bold;">包装机械</span>是包装工艺流程中必不可少的生产设备。天键重点致力于包装后道设备的生产，以及各种包装材料、生产线上辅助设备等，以上均可按照实际情况来进行定制。<br />
                    包装机械价格合理，如果您有需要，可以致电详谈。</p>--%>
                <div style="padding-left: 30px; padding-top: 40px;">
                    <asp:DataList ID="dataLst" runat="server" RepeatColumns="2" RepeatDirection="Horizontal" RepeatLayout="Flow">
                        <ItemTemplate>
                            <div class="product">
                                <div class="product-picbg">                                    
                                    <table style="height:124px;vertical-align:middle;"><tr><td><a href='productlist.aspx?type=<%# Eval("type_id") %>'>
                                        <img class="product-pic" src='<%# GetTypePic(Eval("type_id").ToString()) %>' /></a></td></tr></table></div>
                                <div style="width: 170px; float: right;">
                                    <div class="product-list-title">
                                        <a href='productlist.aspx?type=<%# Eval("type_id") %>'><%# Mxm.Common.Comm.GetShortString(Eval("type_name").ToString(),12) %></a></div>
                                    <ul class="listproductname">
                                        <%# GetListStr(Eval("type_id").ToString()) %>
                                        <li>......</li>
                                    </ul>
                                </div>
                            </div>
                        </ItemTemplate>
                    </asp:DataList>                    
                </div>
            </div>
            <div style="margin:20px auto;">
                <pager:AspNetPager ID="pager1" runat="server" UrlPaging="true" HorizontalAlign="Center" LastPageText="最后一页" NextPageText="下一页" PrevPageText="上一页" FirstPageText="第一页" PageSize="10"></pager:AspNetPager>
                </div>
        </div>
    </div>
    <div class="clear">
    </div>
    <UC:foot ID="foot1" runat="server" />
</body>
</html>
