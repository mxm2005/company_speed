<%@ Page Language="C#" AutoEventWireup="true" CodeFile="article_detail1.aspx.cs" Inherits="article_detail1" %>

<%@ Register TagName="head" TagPrefix="UC" Src="~/control/head.ascx" %>
<%@ Register TagName="foot" TagPrefix="UC" Src="~/control/foot.ascx" %>
<%@ Register TagName="product" TagPrefix="UC" Src="~/control/tech_menu.ascx" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>文章详情</title>
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
            &nbsp;当前位置：<a href="/" class="agray">首页</a><asp:Label ID="lbl_nav" runat="server"></asp:Label>
        </p>
    </div>
    <div id="content">
        <div id="content-left" style="margin-top:10px;">
            <UC:product ID="prod" runat="server" />
        </div>
        <div id="content-right">
            <div style="padding: 0; line-height: 2em;">
                <table border="0" cellspacing="0" cellpadding="0">
                
                    <tr>
                        <td>
                            <div style="text-align: center;">
                                <h3>
                                    <asp:Label ID="lbl_title" runat="server"></asp:Label></h3>
                            </div>
                        </td>
                    </tr>
                    <tr>
                        <td align="center" style="color: #999999">
                            <strong>发布时间：</strong><asp:Label ID="lbl_time" runat="server"></asp:Label><asp:Label ID="lbl_editor" runat="server"></asp:Label></td>
                    </tr>
                    <tr>
                        <td height="20">
                            &nbsp;</td>
                    </tr>
                    <tr>
                        <td>
                           <div id="tdContent" runat="server" class="art-content"></div>
                        </td>
                    </tr>
                    <tr>
                        <td style="height:32px;line-height:32px;text-align:center;" id="tdLink" runat="server">
                            上一篇：暂无 下一篇：暂无
                        </td>
                    </tr>
                    <tr>
                        <td height="20">
                            &nbsp;</td>
                    </tr>
                </table>
            </div>
        </div>
    </div>
    <div class="clear">
    </div>
    <UC:foot ID="foot1" runat="server" />
</body>
</html>
<script type="text/javascript" src="/js/jquery.js"></script>

<script type="text/javascript" src="/js/all.js"></script>
<script type="text/javascript">
$(document).ready(function(){
    setClass('<%= _cssClass %>');
});
</script>