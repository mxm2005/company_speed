<%@ Page Language="C#" AutoEventWireup="true" CodeFile="newslist.aspx.cs" Inherits="newslist" %>

<%@ Register TagName="head" TagPrefix="UC" Src="~/control/head.ascx" %>
<%@ Register TagName="foot" TagPrefix="UC" Src="~/control/foot.ascx" %>
<%@ Register TagName="product" TagPrefix="UC" Src="~/control/product_list.ascx" %>
<%@ Register Assembly="AspNetPager" Namespace="Wuqi.Webdiyer" TagPrefix="pager" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>新闻动态</title>
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
            &nbsp;当前位置：<a href="/" class="agray">首页</a> - 新闻动态
        </p>
    </div>
    <div id="content">
        <div id="content-left">
            <UC:product ID="prod" runat="server" />
        </div>
        <div id="content-right">
            <div style="padding: 20px;line-height: 2em;">
                <asp:Repeater ID="rptLst" runat="server">
                    <HeaderTemplate>
                        <table width="98%" border="0" cellspacing="0" cellpadding="0">
                            <tr style="height: 32px;">
                                <td width="550" style="color: #FFFFFF; font-weight: bold; background: url(Images/split.gif) no-repeat right center;
                                    background-color: #abacaf">
                                    &nbsp;&nbsp;&nbsp;&nbsp;信息标题</td>
                                <td align="center" bgcolor="#ABACAF" style="color: #FFFFFF; font-weight: bold">
                                    发布日期</td>
                            </tr>
                    </HeaderTemplate>
                    <ItemTemplate>
                        <tr style="height: 28px;">
                            <td style="background: url(/images/bg2.gif) repeat-x left bottom;">
                                &nbsp;<img src="/images/title.jpg" width="4" height="8" align="absmiddle" />&nbsp;&nbsp;<a class="a-link" href="/news_detail.aspx?id=<%# Eval("aid") %>"><%# Eval("title") %></a></td>
                            <td align="center" style="background: url(Images/bg2.gif) repeat-x left bottom; color: #999999"><%# Eval("update_time") %></td>
                        </tr>
                    </ItemTemplate>
                    <FooterTemplate>
                        </table>
                    </FooterTemplate>
                </asp:Repeater>                
                <div style="margin:20px auto;">
                <pager:AspNetPager ID="pager1" runat="server" UrlPaging="true" HorizontalAlign="Center" LastPageText="最后一页" NextPageText="下一页" PrevPageText="上一页" FirstPageText="第一页"></pager:AspNetPager>
                </div>
            </div>
        </div>
    </div>
    <div class="clear">
    </div>
    <UC:foot ID="foot1" runat="server" />
</body>
</html>
