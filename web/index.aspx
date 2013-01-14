<%@ Page Language="C#" AutoEventWireup="true" CodeFile="index.aspx.cs" Inherits="index" %>

<%@ Register TagName="head" TagPrefix="UC" Src="~/control/head.ascx" %>
<%@ Register TagName="foot" TagPrefix="UC" Src="~/control/foot.ascx" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="head2" runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>首页</title>
    <link href="style/main.css" type="text/css" rel="stylesheet" />
    <script type="text/javascript" src="Scripts/Admin.js"></script>
    <script type="text/javascript" src="js/ScrollPic.js"></script>
    <script type="text/javascript" src="js/AC_RunActiveContent.js"></script>
          
    <script type="text/javascript" src="js/left.js"></script>
    <script type="text/javascript" src="js/jquery.js"></script>
    <script type="text/javascript"> 
    function killErrors() {
        return true;
    }
    window.onerror = killErrors;
    var path="<%= _vidio %>";
    $(function(){
        var str='<object classid="clsid:D27CDB6E-AE6D-11cf-96B8-444553540000" codebase="http://download.macromedia.com/pub/shockwave/cabs/flash/swflash.cab#version=6,0,29,0" '+
                    'width="300" height="230">'+
                    '<param name="movie" value="/swf/vcastr22.swf?vcastr_file='+path+'">'+
                    '<param name="quality" value="high">'+
                    '<param name="allowFullScreen" value="true" />'+
                    '<embed src="/swf/vcastr22.swf?vcastr_file='+path+'" quality="high"'+
                        'pluginspage="http://www.macromedia.com/go/getflashplayer" type="application/x-shockwave-flash"'+
                        'width="300" height="230"></embed></object>';
        $("#vidio").html(str);
    });
    </script>

</head>
<body class="index_body">
<UC:head ID="head1" runat="server" />

<div class="clear"></div>
    <div id="banner">
        <div id="bannercontent">
            <script type="text/javascript">
AC_FL_RunContent( 'codebase','http://download.macromedia.com/pub/shockwave/cabs/flash/swflash.cab#version=6,0,0,0','width','980','height','350','src','swf/newPro','quality','high','pluginspage','http://www.macromedia.com/go/getflashplayer','bgcolor','#ff0000','menu','false','flashvars',<%= _banner %>,'wmode','transparent','movie','swf/newPro' ); //end AC code
            </script>
        </div>
    </div>
<div class="clear"></div>

    <div id="productlist">
        <div id="indexproduct-content">
            <div id="indexproductkid">                
                <div id="divProduct" runat="server" style="width: 640px; padding: 0; margin: 0; margin-top: 60px; margin-left: 10px;">
                </div>
            </div>
            <div id="vidio" style="float:right;margin-right:4px;">
                <%--<object classid="clsid:D27CDB6E-AE6D-11cf-96B8-444553540000" codebase="http://download.macromedia.com/pub/shockwave/cabs/flash/swflash.cab#version=6,0,29,0"
                    width="300" height="230">
                    <param name="movie" value="/swf/vcastr22.swf?vcastr_file=<%= _vidio %>">
                    <param name="quality" value="high">
                    <param name="allowFullScreen" value="true" />
                    <embed src="/swf/vcastr22.swf?vcastr_file=<%= _vidio %>" quality="high"
                        pluginspage="http://www.macromedia.com/go/getflashplayer" type="application/x-shockwave-flash"
                        width="300" height="230">
</embed>
                </object>--%>
            </div>
            <div class="clear"></div>
        </div>
    </div>
<div class="clear"></div>
<div id="indexpro">
<div id="indexpro-con">
    <div class="ny2010">
        <div id="demo" style="overflow: hidden; width: 976px; height: 165px; margin: 0px;
            display: inline; float: left;" onmousemove="MoveDiv(event);" onmouseout="MoveOutDiv();">
            <div id="demo1" style="width: 100%;">
                <table cellspacing="0" cellpadding="0">
                    <tbody>
                        <tr valign="top">
                            <td valign="top" nowrap id="tdRecProduct" runat="server">
                            </td>
                            <td width="0">
                                <div id="demo2" style="width: 100%;">
                                </div>
                            </td>
                        </tr>
                    </tbody>
                </table>
            </div>
        </div>
    </div>
<script type="text/javascript">
document.getElementById("demo2").innerHTML = document.getElementById("demo1").innerHTML;
MyMar=setInterval(Marquee,speed);
</script>  
</div>
</div>
<div></div>
<div class="clear"></div>
    <div id="index-company">
        <div id="com">
            <div id="company-pic">
                <div style="padding-top: 50px;" id="divCompany" runat="server">
                    
                </div>
            </div>
            <div id="news-pic">
                <div class="picNews">
                    <div class="lpicnews">
                        <img src="#" id="imgNews" runat="server" style="border:none;max-width:160px;max-height:100px;" alt="" /></div>
                    <div class="lpicnewsright">
                        <span class="name" id="spanLink" runat="server"></span><br />
                        <span id="spanContent" runat="server"></span>
                    </div>
                </div>
                <div class="clear">
                </div>
                <div class="textNews">
                    <ul class="newslisttitle" id="ulTextNews" runat="server">
                        
                    </ul>
                    <a href="newslist.aspx?type=1" target="_blank">
                        <img src="images/more.jpg" style="float: right; margin-top: 5px;" /></a>
                </div>
            </div>
        </div>
    </div>



<div class="clear"></div>
<UC:foot ID="foot1" runat="server" />
</body>
</html>