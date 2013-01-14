<%@ Page Language="C#" AutoEventWireup="true" CodeFile="productlist.aspx.cs" Inherits="productlist" %>

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
            &nbsp;当前位置：<a href="/" class="agray">首页</a> - <a href="product.aspx">产品中心</a><asp:Label ID="lbl_nav" runat="server"></asp:Label>
        </p>
    </div>
    <div id="content">
        <div id="content-left">
            <UC:product ID="prod" runat="server" />
        </div>
        <div id="content-right">
            <div style="background: url(images/product_shuoming.jpg) no-repeat 0px 15px;">
                <p style="height:60px;padding-top: 35px; padding-left: 30px; font-size: 14px; color: #FFF; font-family: '微软雅黑', '宋体';">
                    产品中心</p>
                <div style="margin-top: 20px; padding-left: 20px; padding-right: 20px; line-height: 2em;">
                    <p id="type_remark" runat="server" style="line-height: 2em; margin-top: 20px; padding-left: 20px; padding-right: 20px"></p>
                </div>
                <div class="pageContent_list">
                    <asp:Repeater ID="rptLst" runat="server">
                        <ItemTemplate>
                            <div class="item">
                                <div class="itemPic">
                                <table style="width:124px;height:124px;vertical-align:middle;"><tr><td>
                                    <a href='productview.aspx?pid=<%# Eval("pid") %>' title='<%# Eval("product_name") %>'>
                                        <img src='<%# GetPic(Eval("picture_small").ToString()) %>' style="width:120px;max-width:120px;max-height:120px;" alt='<%# Eval("product_name") %>' /></a></td></tr></table></div>
                                <div class="productsm">
                                    <div class="itemName">
                                        <ul class="menu">
                                            <li><a href='productview.aspx?pid=<%# Eval("pid") %>' title='<%# Eval("product_name") %>'>
                                                <%# Eval("product_name") %>
                                            </a></li>
                                            <li><span style="font-weight:bold;">型号：</span><%# Eval("model") %>
                                            </li>
                                        </ul>
                                        <div class="clear"></div>
                                    </div>
                                    <div class="sm">
                                        <%# Eval("product_synopsis")%>
                                    </div>
                                    <div class="sm">
                                    <a href='productview.aspx?pid=<%# Eval("pid") %>' title='详细内容见产品介绍'>详细内容见产品介绍>>></a>
                                    </div>
                                </div>
                                <div class="clear">
                                </div>
                            </div>
                        </ItemTemplate>
                    </asp:Repeater>
                </div>
                <div style="margin: 20px auto;">
                    <pager:AspNetPager ID="pager1" runat="server" UrlPaging="true" HorizontalAlign="Center"
                        LastPageText="最后一页" NextPageText="下一页" PrevPageText="上一页" FirstPageText="第一页">
                    </pager:AspNetPager>
                </div>
            </div>
        </div>
    </div>
    <div class="clear">
    </div>
    <UC:foot ID="foot1" runat="server" />
</body>
</html>
