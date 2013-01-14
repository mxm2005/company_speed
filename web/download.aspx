<%@ Page Language="C#" AutoEventWireup="true" CodeFile="download.aspx.cs" Inherits="download" %>

<%@ Register TagName="head" TagPrefix="UC" Src="~/control/head.ascx" %>
<%@ Register TagName="foot" TagPrefix="UC" Src="~/control/foot.ascx" %>
<%@ Register TagName="menu" TagPrefix="UC" Src="~/control/tech_menu.ascx" %>
<%@ Register Assembly="AspNetPager" Namespace="Wuqi.Webdiyer" TagPrefix="pager" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>资料下载</title>
    <link href="style/main.css" type="text/css" rel="stylesheet" />
</head>
<body class="other_body">
    <UC:head ID="head2" runat="server" />
    <div id="banner">
        <div id="bannercontent">
            <img id="topBanner" runat="server" src="images/product_05.jpg" alt="" width="980"
                height="190" /></div>
    </div>
    <div class="clear">
    </div>
    <div id="position">
        <p>
            &nbsp;当前位置：<a href="/" class="agray">首页</a> - 资料下载
        </p>
    </div>
    <div id="content">
        <div id="content-left" style="margin-top: 10px;">
            <UC:menu ID="menu1" runat="server" SelectIxt="2" />
        </div>
        <div id="content-right">
            <div style="background: url(images/product_shuoming.jpg) no-repeat 0px 15px;">
                <p style="padding-top: 35px; padding-left: 30px; font-size: 14px; color: #FFF; font-family: '微软雅黑', '宋体';">
                    资料下载</p>
                <div style="margin-top: 20px; padding-left: 20px; padding-right: 20px; line-height: 2em;">
                    <p id="type_remark" runat="server" style="line-height: 2em; margin-top: 20px; padding-left: 20px;
                        padding-right: 20px">
                    </p>
                </div>
                <div class="pageContent_list">
                    <asp:Repeater ID="rptLst" runat="server">
                        <ItemTemplate>
                            <div class="item">
                                <div class="itemPic">
                                <table style="width:124px;height:124px;vertical-align:middle;text-align:center;border:0;table-layout:fixed;"><tr><td>
                                    <img src='<%# GetPic(Eval("picture").ToString()) %>' style="max-width: 120px;max-height: 120px;" alt='<%# Eval("name") %>' /></td></tr></table></div>
                                <div class="productsm">
                                    <div class="itemName">
                                        <%--<a href='/download_file.aspx?fileid=<%# Eval("down_id") %>' title='<%# Eval("name") %>' target="_blank">--%>
                                            <%# Eval("name") %>
                                        <%--</a>--%>
                                    </div>
                                    <div style="padding:3px 0px;">
                                        <a class="button-1" href='/download_file.aspx?fileid=<%# Eval("down_id") %>' title='<%# Eval("name") %>' target="_blank">
                                            下载 </a>
                                    </div>
                                    <div class="sm">
                                        <%# Mxm.Common.Comm.GetShortString(Mxm.Common.FiterHtml.ParseTags(Eval("remark").ToString()), 160)%>
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

<script type="text/javascript" src="/js/jquery.js"></script>

<script type="text/javascript" src="/js/all.js"></script>

<script type="text/javascript">
$(document).ready(function(){
    setClass('tech0');
});
</script>

