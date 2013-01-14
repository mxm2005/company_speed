﻿<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
<meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
<title>Admin Header</title>
<style type="text/css">
body {background: #686868; font-family:Arial, Helvetica, sans-serif; font-size:12px; margin:0px; margin-bottom:2px;border-bottom: 1px #ccc solid;}
h1 {color: #FFF;}
a {color: #FFF; text-decoration: none;position:relative;}
ul { list-style:none;}
#all {width: 100%;}
#banner {margin-top: 8px; margin-left: 32px;}
#main {width: 100%; margin-bottom: 2px; background:#eeeeee; margin-left: 0px; margin-right:0px; height: 30px; color: #000; line-height: 2.4;overflow: auto;}
#main a {color:#000;}
#welcome { float:left; width: 40%; font-weight: 800; padding-left: 8px; position:relative;}
#adminop { float:left; width: 59%; position:relative; text-align:right; line-height:1; *line-height:2.2;}
#adminop ul li {float: right; width: 80px;}
#nav {width: 100%; clear: both; display:none;}
#nav ul li {float: right; width:82px; height:25px; line-height: 2.1; text-align: center;}
.inactive { background-image/**/:url(/images/admin/nav_bg_inactive2.png) !important;background: none; margin-left: 2px; margin-right:2px;filter:progid:DXImageTransform.Microsoft.AlphaImageLoader(src=/images/admin/nav_bg_inactive2.png);}
.inactive a {color: #000;}
.active {background:url(/images/admin/nav_bg_active2.png) !important;background: none; margin-left: 2px; margin-right:2px;filter:progid:DXImageTransform.Microsoft.AlphaImageLoader(src=/images/admin/nav_bg_active2.png);}
.active a {color:#fff;}
.blankgray {background:#bbb; height:2px; width:100%; margin:0; padding:0; clear:both; font-size:2px;}
</style>
<script type="text/javascript" language="javascript" src="/js/jquery.js"></script>
<script type="text/javascript">
var oplist = new Array('about', 'user', 'news', 'mars', 'jielong', 'box', 'school', 'config', 'other');
$(document).ready(function() {
	$('#nav').find("a").click(function() {
		var id = $(this).attr('id');
		$.each(oplist, function(i, n) {
			$('#'+n).attr('class', 'inactive');
		});
		$(this).parents("li").attr('class', 'active');
	});
});
</script>
</head>

<body>
<div id="all">
	<div id="banner"><h1>企业管理后台</h1></div>
    <!--<div id="nav">
    	<ul>
        	<li class="inactive" id="other"><a href="menu.html" target="menu">绠＄悊鎿嶄綔</a></li>
            <li class="inactive" id="about"><a href="menu.html" target="menu">绠＄悊鎿嶄綔</a></li>
            <li class="inactive" id="user"><a href="menu.html" target="menu">绠＄悊鎿嶄綔</a></li>
            <li class="inactive" id="news"><a href="menu.html" target="menu">绠＄悊鎿嶄綔</a></li>
            <li class="inactive" id="mars"><a href="menu.html" target="menu">绠＄悊鎿嶄綔</a></li>
            <li class="inactive" id="jielong"><a href="menu.html" target="menu">绠＄悊鎿嶄綔</a></li>
            <li class="inactive" id="box"><a href="menu.html" target="menu">绠＄悊鎿嶄綔</a></li>
            <li class="inactive" id="school"><a href="menu.html" target="menu">鐏煷瀛﹀爞</a></li>
            <li class="active" id="config"><a href="menu.html" target="menu">绔欑偣璁剧疆</a></li>
        </ul>
    </div>-->
    <div id="main">
    	<div id="welcome">欢迎访问管理后台，Admin! <img src="/images/clock.gif" />上次登录时间是：2012-4-13</div>
        <div id="adminop">
            <ul>
                <!--<li><a href="#">绔欑偣棣栭〉</a></li>-->
                <li><a href="javascript:parent.location.reload();">退出后台</a></li>
                <li><a href="javascript:parent.location.reload();">返回首页</a></li>
                <!--<li><a href="#">绔欑偣棣栭〉</a></li>-->
            </ul>
        </div>
    </div>
</div>
</body>
</html>
