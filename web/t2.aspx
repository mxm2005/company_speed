<%@ Page Language="C#" AutoEventWireup="true" CodeFile="t2.aspx.cs" Inherits="t2" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>无标题页</title>
</head>
<body>
    <form id="form1" runat="server">
        <div style="height: 300px; border: solid 1px red;">
            <div id="vidio" style=" margin-right: 4px;">
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
            <%--<div id="myElement">Loading the player...</div>--%>
        </div>
        
    </form>
</body>
</html>

<script type="text/javascript" src="js/jquery.js"></script>
<%--<script type="text/javascript" src="jw_player/jwplayer.js"></script>
<script type="text/javascript">jwplayer.key = "kesw0H3OzUXsSJL3trANEXpFbq8dxeJPvj6BDA==";</script>

<script type="text/javascript">
    jwplayer("myElement").setup({
        file: "/uploadfile/vidio/index.flv",
        image: "/uploadfile/img/20121207125907_6882.jpg",
        width:300,
        height:250
    });
</script>--%>
<script type="text/javascript"> 
    function killErrors() {
        return true;
    }
    window.onerror = killErrors;
    var path="/uploadfile/vidio/index.flv";
    $(function(){alert(path);
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

