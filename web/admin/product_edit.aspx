<%@ Page Language="C#" AutoEventWireup="true" CodeFile="product_edit.aspx.cs" Inherits="admin_product_edit"
    ValidateRequest="false" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>编辑产品-产品管理</title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            产品名称：<br />
            <asp:TextBox ID="txtName" runat="server" Width="400"></asp:TextBox>
            <br />
            <br />
            产品分类：<br />
            <asp:DropDownList ID="ddlType" runat="server">
            </asp:DropDownList>
            <span id="spanType"></span><span style="color: red">*</span>
            <br />
            <br />
            产品简介：<br />
            <textarea id="txtSummary" runat="server" cols="80" rows="8"></textarea>
            <br />
            <br />
            产品详情：<br />
            <textarea id="txtContent" runat="server" cols="80" rows="15"></textarea>
            <br />
            产品形象图--大图：<br />
            <img id="img" runat="server" alt="" src="" style="width: 200px; border: solid 1px #CCC;" /><br />
            <asp:FileUpload ID="fileUp" runat="server" /><br />
            产品形象图--小图：<span style="color:Red;">图片尺寸限(120x120)</span><br />
            <img id="img1" runat="server" alt="" src="" style="width: 120px;height:120px; border: solid 1px #CCC;" /><br />
            <asp:FileUpload ID="fileUp1" runat="server" /><br />            
            <br />
            <div id="video">
            </div>
            <asp:FileUpload ID="vidioUp" runat="server" /><br />
            <br />
            <asp:CheckBox ID="chkStatus" runat="server" />显示/隐藏&nbsp;&nbsp;<asp:CheckBox ID="chk_video"
                runat="server" />清除视频<br />
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
        $("#txtSummary").val(editor.getSource());
        $("#txtContent").val(editor.getSource());
    }
    KE.show({
            id: 'txtSummary',
            cssPath: '/kindeditor/skins/default.css',
            imageAttachPath: '/img/attached/',
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
    KE.show({
        id: 'txtContent',
        cssPath: '/kindeditor/skins/default.css',
        imageAttachPath: '/img/attached/',
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
    var path="<%= _video %>";
    $(function(){
    var str='<object classid="clsid:D27CDB6E-AE6D-11cf-96B8-444553540000" codebase="http://download.macromedia.com/pub/shockwave/cabs/flash/swflash.cab#version=6,0,29,0" '+
                'width="300" height="230">'+
                '<param name="movie" value="/swf/vcastr22.swf?vcastr_file='+path+'">'+
                '<param name="quality" value="high">'+
                '<param name="allowFullScreen" value="true" />'+
                '<embed src="/swf/vcastr22.swf?vcastr_file='+path+'" quality="high"'+
                    'pluginspage="http://www.macromedia.com/go/getflashplayer" type="application/x-shockwave-flash"'+
                    'width="340" height="230"></embed></object>';
    $("#video").html(str);
    });
</script>

