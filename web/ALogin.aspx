<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ALogin.aspx.cs" Inherits="ALogin" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>后台登录</title>
</head>
<body>
    <form id="form1" runat="server">
    <div style="width:400px;margin:150px auto;height:200px;border:solid 1px #AAA;">
    <div style="margin:60px auto;text-align:center;">
        用户名：<asp:TextBox ID="txtUid" runat="server" Width="160"></asp:TextBox>
        <br /><br />
        密&nbsp;&nbsp;&nbsp;&nbsp;码：<asp:TextBox ID="txtPwd" Width="160" TextMode="Password" runat="server"></asp:TextBox>
        <br /><br />
    <span style="display:block;width:220px;"><asp:Button  id="btn_login" runat="server" Text="登 录" OnClick="btn_login_Click" /></span>
    </div>
    </div>
    </form>
</body>
</html>
