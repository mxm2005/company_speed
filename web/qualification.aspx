<%@ Page Language="C#" AutoEventWireup="true" CodeFile="qualification.aspx.cs" Inherits="qualification" %>

<%@ Register TagName="head" TagPrefix="UC" Src="~/control/head.ascx" %>
<%@ Register TagName="foot" TagPrefix="UC" Src="~/control/foot.ascx" %>
<%@ Register TagName="product" TagPrefix="UC" Src="~/control/product_list.ascx" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>企业资质</title>
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
            &nbsp;当前位置：<a href="/" class="agray">首页</a> - 企业资质
        </p>
    </div>
    <div id="content">
        <div id="content-left">
            <UC:product ID="prod" runat="server" />
        </div>
        <div id="content-right">
            <div style="padding-right: 20px; line-height: 2em;" id="divContent" runat="server">
            </div>
        </div>
    </div>
    <div class="clear">
    </div>
    <UC:foot ID="foot1" runat="server" />
</body>
</html>
