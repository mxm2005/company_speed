<%@ Control Language="C#" AutoEventWireup="true" CodeFile="head.ascx.cs" Inherits="control_head" %>
<%@ OutputCache Duration="3600" VaryByParam="none" %>
<div id="head" class="head_logo">
    <div id="logo">
    </div>
    <div id="headright">
        <p><span>中文版</span> | <a href="javascript:void(0)">English</a></p>
        <div id="menutj">
            <%--<ul>
                <li><a href="/">首&nbsp;&nbsp;&nbsp;&nbsp;页</a>&nbsp;&nbsp;|</li>
                <li><a href="/about.aspx">关于我们</a>&nbsp;&nbsp;|</li>
                <li><a href="/newslist.aspx">新闻动态</a>&nbsp;&nbsp;|</li>
                <li><a href="/product.aspx">产品中心</a>&nbsp;&nbsp;|</li>
                <li><a href="/messagewrite.aspx">在线留言</a>&nbsp;&nbsp;|</li>
                <li><a href="/contact.aspx">联系我们</a></li>
            </ul>--%>
            <%--人才招聘|新闻动态|资料下载|企业邮箱--%>
            <a href="/">首&nbsp;&nbsp;&nbsp;&nbsp;页</a>&nbsp;&nbsp;|&nbsp;&nbsp; <a href="/about.aspx">
                关于我们</a>&nbsp;&nbsp;|&nbsp;&nbsp; <a href="/qualification.aspx">企业资质</a>&nbsp;&nbsp;|&nbsp;&nbsp;<a
                    href="/product.aspx">产品中心</a>&nbsp;&nbsp;|&nbsp;&nbsp; <a href="/solution.aspx">工程案例</a>&nbsp;&nbsp;|&nbsp;&nbsp;
            <a href="/technical_service.aspx">技术服务</a>&nbsp;&nbsp;|&nbsp;&nbsp; <a href="/contact.aspx">
                联系我们</a><%--&nbsp;&nbsp;|&nbsp;&nbsp; <a href="/contact.aspx">
                人才招聘</a>&nbsp;&nbsp;|&nbsp;&nbsp; <a href="/contact.aspx">
                资料下载</a>--%>
        </div>
        <div id="indexsearch">
        </div>
    </div>
</div>
<div class="clear">
</div>
