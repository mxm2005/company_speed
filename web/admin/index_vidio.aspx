<%@ Page Language="C#" AutoEventWireup="true" CodeFile="index_vidio.aspx.cs" Inherits="admin_index_vidio" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>首页推荐视频管理</title>
    <link type="text/css" rel="Stylesheet" href="/style/admin.css" />
</head>
<body>
    <form id="form1" runat="server">
        <div style="text-align: left;margin:5px;">
            <div>
                首页视频：</div>
            <div class="video">
                <object classid="clsid:D27CDB6E-AE6D-11cf-96B8-444553540000" codebase="http://download.macromedia.com/pub/shockwave/cabs/flash/swflash.cab#version=6,0,29,0"
                    width="340" height="230">
                    <param name="movie" value="/swf/vcastr22.swf?vcastr_file=<%= _vidio %>">
                    <param name="quality" value="high">
                    <param name="allowFullScreen" value="true" />
                    <embed src="/swf/vcastr22.swf?vcastr_file=<%= _vidio %>" quality="high"
                        pluginspage="http://www.macromedia.com/go/getflashplayer" type="application/x-shockwave-flash"
                        width="340" height="230">
</embed>
                </object>
            </div>
            <div style="height: 26px; line-height: 26px;">
                <asp:FileUpload ID="up1" runat="server" /><asp:Button ID="btnOK" runat="server" Text="更 新"
                    OnClick="btnOK_Click" />
            </div>
        </div>
    </form>
</body>
</html>
