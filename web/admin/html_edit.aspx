<%@ Page Language="C#" AutoEventWireup="true" CodeFile="html_edit.aspx.cs" Inherits="admin_html_edit" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>HTML文件修改</title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    <textarea id="txtContent" runat="server" cols="80" rows="15"></textarea>
    <br /><br />
    <asp:Button ID="btnSubmit" runat="server" Text="提 交" OnClick="btnSubmit_OnClick" />
    &nbsp&nbsp;
    <a href="htmlManager.aspx" target="_self">返回列表</a>
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

