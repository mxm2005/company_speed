<%@ Page Language="C#" AutoEventWireup="true" CodeFile="product_type_edit.aspx.cs"
    Inherits="admin_product_type_edit" ValidateRequest="false" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>产品类别编辑</title>
</head>
<body>
    <form id="form1" runat="server">
        <div style="text-align: left; margin-top: 15px; padding: 3px 5px;">
            <div style="background: #ddd; font: 14px; height: 26px; line-height: 26px; width: 300px;
                padding-left: 5px;">
                编辑分类</div>
            <div style="margin-top: 5px; padding-left: 5px;">
                分类名称：<asp:TextBox ID="txtTypeName" runat="server"></asp:TextBox><br />
                旧的图片：<asp:Image ID="imgOld" runat="server" Width="200" style="max-height:100px;" /><br />
                新的图片：<asp:FileUpload ID="upload" runat="server" /><br />
                分类描述：<br />
                <asp:TextBox ID="txtTypeRemark" runat="server" TextMode="MultiLine" Height="62px"
                    Width="300px" MaxLength="2000"></asp:TextBox>
            </div>
            <div style="text-align:center;width: 300px;padding-top:5px;">
            <asp:Button ID="btnAdd" runat="server" Text="保 存" OnClick="btnOK_Click" />
            </div>
        </div>
    </form>
</body>
</html>
