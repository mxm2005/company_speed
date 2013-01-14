<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>菜单页</title>
    <style type="text/css">
html, body {height:100%;overflow:hidden;} /*为兼容ie7,ff*/
body {font-family:Arial, Helvetica, sans-serif; font-size:12px; margin:0px; text-align:center; border-right:1px #ccc solid;}
a {color: #000; text-decoration: none;}
#menu img {_margin-top: 12px;}/*没办法,ie6对list-style-image支持不好*/
#all {width: 100%;height:100%;}
#menu {width: 96%;}
#menu ul {padding:0; margin: 0; list-style: none;text-align:left;}
#menu ul li { background-repeat: repeat-x; background-position:center; height: 32px;padding-left:10px;margin-top: 2px; margin-bottom: 2px; border:1px #ccc solid; line-height: 2.8;}
#menu ul li a:hover{color:red;}
.menusel{background:#ddd;}
</style>
</head>
<body>
    <div id="all">
        <div id="menu">
            <ul>
                <li>
                    <img src="/images/li.jpg" />&nbsp;&nbsp;&nbsp; <a href="/admin/product_manager.aspx"
                        target="main" onclick="setMenuStyle(this)">产品管理列表</a></li>
                <li>
                    <img src="/images/li.jpg" />&nbsp;&nbsp;&nbsp; <a href="/admin/product_add.aspx"
                        target="main" onclick="setMenuStyle(this)">产品添加</a></li>
                <li>
                    <img src="/images/li.jpg" />&nbsp;&nbsp;&nbsp; <a href="/admin/article_manager.aspx"
                        target="main" onclick="setMenuStyle(this)">文章管理列表</a></li>
                <li>
                    <img src="/images/li.jpg" />&nbsp;&nbsp;&nbsp; <a href="/admin/article_add.aspx"
                        target="main" onclick="setMenuStyle(this)">文章添加</a></li>
                <li>
                    <img src="/images/li.jpg" />&nbsp;&nbsp;&nbsp; <a href="/admin/product_type.aspx"
                        target="main" onclick="setMenuStyle(this)">产品分类管理</a></li>
                <li>
                    <img src="/images/li.jpg" />&nbsp;&nbsp;&nbsp; <a href="/admin/art_type.aspx" target="main"
                        onclick="setMenuStyle(this)">文章分类管理</a></li>
                <li>
                    <img src="/images/li.jpg" />&nbsp;&nbsp;&nbsp; <a href="/admin/banner_index.aspx"
                        target="main" onclick="setMenuStyle(this)">首页Banner广告设置</a></li>
                <li>
                    <img src="/images/li.jpg" />&nbsp;&nbsp;&nbsp; <a href="/admin/index_vidio.aspx"
                        target="main" onclick="setMenuStyle(this)">首页推荐视频管理</a></li>
                <li>
                    <img src="/images/li.jpg" />&nbsp;&nbsp;&nbsp; <a href="/admin/banner_other.aspx"
                        target="main" onclick="setMenuStyle(this)">其它页面Banner图片设置</a></li>
                <li>
                    <img src="/images/li.jpg" />&nbsp;&nbsp;&nbsp; <a href="/admin/download_manager.aspx"
                        target="main" onclick="setMenuStyle(this)">下载列表管理</a></li>
                <li>
                    <img src="/images/li.jpg" />&nbsp;&nbsp;&nbsp; <a href="/admin/download_add.aspx"
                        target="main" onclick="setMenuStyle(this)">添加下载资源</a></li>
                <li>
                    <img src="/images/li.jpg" />&nbsp;&nbsp;&nbsp; <a href="/admin/htmlManager.aspx"
                        target="main" onclick="setMenuStyle(this)">HTML修改</a></li>
                <li>
                    <img src="/images/li.jpg" />&nbsp;&nbsp;&nbsp; <a href="/admin/recommend_manager.aspx"
                        target="main" onclick="setMenuStyle(this)">內容推荐分組管理</a></li>                
            </ul>
        </div>
    </div>
</body>
</html>

<script type="text/javascript" src="/js/jquery.js"></script>

<script type="text/javascript" src="/js/all.js"></script>

