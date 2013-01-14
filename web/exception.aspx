<%@ Page Language="C#" AutoEventWireup="true" CodeFile="exception.aspx.cs" Inherits="exception" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>异常、报错信息页面</title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    <span style="color:Red;">出错页面：</span><asp:Label ID="lbl_url" runat="server"></asp:Label>
    </div>
    <br />
    <span style="color:Red;">错误信息：</span>
    <div id="divInfo" runat="server" style="border:solid 1px #999;padding:10px 10px;height:22px;line-height:22px;display:table;">
    
    </div>
    </form>
</body>
</html>