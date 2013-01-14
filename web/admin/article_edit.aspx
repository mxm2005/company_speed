<%@ Page Language="C#" AutoEventWireup="true" CodeFile="article_edit.aspx.cs" Inherits="admin_article_edit"
    ValidateRequest="false" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>资讯编辑</title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            标题：<asp:TextBox ID="txtTitle" runat="server" Width="400"></asp:TextBox>
            <span style="color: Red;">*</span>
            <br />
            副标题：<asp:TextBox ID="txtSubTitle" runat="server" Width="400"></asp:TextBox>
            <br />
            作者：<asp:TextBox ID="txtAuthor" runat="server" Width="120px"></asp:TextBox>
            <br />
            分类：
            <asp:DropDownList ID="ddlType" runat="server" AutoPostBack="false">
            </asp:DropDownList>
            <span style="color: #ff0000">*</span><br />
            正文：<span style="color: Red;">*</span><br />
            <textarea id="txtContent" runat="server" cols="80" rows="15"></textarea>
            <br />
            形象图-小图：<span style="color:Red;">图片尺寸限(120x120)</span><br />
            <img id="img" runat="server" style="width:120px;height:120px;" /><br />
            <asp:FileUpload ID="fileUp1" runat="server" />
            <br />
            编辑：<asp:TextBox ID="txtEditor" runat="server" Width="118px"></asp:TextBox>
            <br />
            <br />
            <asp:Button ID="btnSubmit" runat="server" Text="提 交" OnClick="btnSubmit_OnClick" />
        </div>
    </form>
</body>
</html>

<script type="text/javascript" src="/js/jquery.js"></script>

<script type="text/javascript" src="/kindeditor/kindeditor.js"></script>

<script type="text/javascript" language="javascript">
    function getEditorValue() {
        $("#txtContent").val(editor.getSource());
    }
    KE.show({
        id: 'txtContent',
        cssPath: '/kindeditor/skins/default.css',
        imageAttachPath: '/uploadfile/img/',
        imageUploadJson: '/Ajax/upload_json.ashx',
        afterCreate: function(id) {
            KE.event.ctrl(document, 13, function() {
                KE.util.setData(id);
                document.forms['form1'].submit();
            });
            KE.event.ctrl(KE.g[id].iframeDoc, 13, function() {
                KE.util.setData(id);
                document.forms['form1'].submit();
            });
        }
    });

</script>

