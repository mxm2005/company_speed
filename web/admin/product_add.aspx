<%@ Page Language="C#" AutoEventWireup="true" CodeFile="product_add.aspx.cs" Inherits="admin_product_add"
    ValidateRequest="false" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>添加产品-产品管理</title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            产品名称：<br />
            <asp:TextBox ID="txtName" runat="server" Width="400"></asp:TextBox><span style="color: Red;">
                *</span>
            <br />
            <br />
            产品分类：<br />
            <asp:DropDownList ID="ddlType" runat="server">
            </asp:DropDownList>
            <span id="spanType"></span>
            <span style="color: Red;">*</span>
            <br />
            <br />
            产品简介：<br />
            <textarea id="txtSummary" runat="server" cols="80" rows="8"></textarea>
            <br />
            <br />            
            产品详情：<br />
            <textarea id="txtContent" runat="server" cols="80" rows="15"></textarea>
            <br />
            产品形象图-大图：<br />
            <asp:FileUpload ID="fileUp" runat="server" /><br />
            产品形象图-小图：<span style="color:Red;">图片尺寸限(120x120)</span><br />
            <asp:FileUpload ID="fileUp1" runat="server" /><br />
            <br />
            产品视频：<br />
            <asp:FileUpload ID="vidioUp" runat="server" /><br />
            <br />
            <asp:CheckBox ID="chkStatus" runat="server" Checked="true" />显示/隐藏<br />
            <br />
            <asp:Button ID="btnSubmit" runat="server" Text="提 交" OnClick="btnSubmit_OnClick" />
        </div>
        <div id="div1"></div>
    </form>
</body>
</html>

<script type="text/javascript" src="/js/jquery.js"></script>

<script type="text/javascript" src="/kindeditor/kindeditor.js"></script>

<script type="text/javascript" language="javascript">
    function getEditorValue() {
        $("#txtContent").val(editor.getSource());
    }
    $(function(){
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
    });
    
    // onchange="InitType(this)"
    function InitType(obj){
        var json;
        if(obj.value){
            $.get("/ajax/getProdType.ashx", { pare_id: obj.value },
            function(data){
                if(data!="[]"){
                    json = eval( '(' + data + ')' );
                    var tmp="";
                    $.each(json,function(i,o){
                        tmp+='<option value="'+o.type_id+'">'+o.type_name+'</option>';
                    });
                    tmp='<span id="spanType"></span><select name="ddlType1" id="ddlType1">'+tmp+'</select></span>';
                    $("#spanType").html(tmp);
                }
                else{
                    $("#spanType").html('<span id="spanType"></span>');
                }
            }); 
        }
        else{
            $("#spanType").html('<span id="spanType"></span>');
        }
    }

</script>

