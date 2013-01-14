<%@ Page Language="C#" AutoEventWireup="true" CodeFile="download_edit.aspx.cs" Inherits="admin_download_edit" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>修改-下载管理</title>
    <link type="text/css" rel="Stylesheet" href="/style/admin.css" />
</head>
<body>
    <form id="form1" runat="server">
        <div style="text-align:left;margin:5px;">
            <%--down_id, name, remark, picture, path, sort, create_time--%>
            名称：<br />
            <asp:TextBox ID="txtName" runat="server" Width="400"></asp:TextBox><span style="color: Red;">
                *</span>
            <br />
            <br />
            文件：<br />
            <asp:Label ID="lblFile" runat="server"></asp:Label><br />
            <asp:FileUpload ID="fileUp" runat="server" /><span style="color: Red;"> *</span>
            <br />
            <br />
            描述：<span style="color:#999;">(字数请尽量简练)</span><br />
            <textarea id="txtContent" runat="server" rows="3" style="width: 543px; height: 135px"></textarea>
            <br />
            <br />
            图片：<br />
            <img id="img1" runat="server" style="max-width:160px;max-height:160px;" />
            <br />
            <asp:FileUpload ID="picUp" runat="server" /><br />
            <br />
            <asp:Button ID="btnSubmit" runat="server" Text="提 交" OnClick="btnSubmit_OnClick" />
            <br />
            <br />
            <a href="download_manager.aspx">返回列表</a>
        </div>
    </form>
</body>
</html>
