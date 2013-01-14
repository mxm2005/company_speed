<%@ Page Language="C#" AutoEventWireup="true" CodeFile="recommend_content_edit.aspx.cs" Inherits="admin_recommend_content_edit" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>推荐内容编辑</title>
    <link type="text/css" rel="Stylesheet" href="/style/admin.css" />
</head>
<body>
    <form id="form1" runat="server">
    <div style="text-align:left;padding:5px;">
    编号：<asp:TextBox ID="txtID" runat="server" ReadOnly="true" Width="100px" style="color:Green;" Text="0"></asp:TextBox><br />
        标题：<asp:TextBox ID="txtTitle" runat="server" MaxLength="100" Width="300px"></asp:TextBox><br />
        内容：<asp:TextBox ID="txtContent" runat="server" MaxLength="300" Height="60" Rows="3" Width="500px"></asp:TextBox><br />
        链接：<asp:TextBox ID="txtURL" runat="server" Width="299px"></asp:TextBox>
        <span style="color:#CCC;">示例：http://www.baidu.com</span>
        <br />
        图片：<br />
        <img id="img" runat="server" style="width:100px;height:100px;" />
        <br />
        <asp:FileUpload ID="fileUp1" runat="server" Width="307px" /><br />
    <asp:Button ID="btnOK" runat="server" Text="保 存" OnClick="btnOK_Click" />
    </div><br />
    <div style="text-align:left;padding:5px;">
    <a href="recommend_content.aspx?gid=<%= _gid %>">返回列表</a>
    </div>
    </form>
</body>
</html>
