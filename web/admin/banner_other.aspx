<%@ Page Language="C#" AutoEventWireup="true" CodeFile="banner_other.aspx.cs" Inherits="admin_banner_other" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>其它页面广告设置Banner</title>
    <link type="text/css" rel="Stylesheet" href="/style/admin.css" />
</head>
<body>
    <form id="form1" runat="server">
    <div style="margin: 5px;">
        <asp:Repeater ID="rptList" runat="server">
            <HeaderTemplate>
                <table id="tbLst" class="tb_grid" style="width: 100%;">
                    <tr class="tr_head">
                        <th scope="col" width="1%" style="text-align:center;">
                            <input id="chkAll" type="checkbox" />
                        </th>
                        <th scope="col" width="40%">
                            图片
                        </th>
                        <th scope="col" width="19%">
                            上传
                        </th>
                        <th scope="col" width="40%">
                            页面关键字
                        </th>
                        <%--<th scope="col" width="15%">
                            操作
                        </th>--%>
                    </tr>
            </HeaderTemplate>
            <ItemTemplate>
                <tr class="tr_light">
                    <td style="text-align:center;">
                        <asp:CheckBox ID="chkItem" runat="server"></asp:CheckBox>
                    </td>
                    <td>
                        <a href='<%# Eval("img")%>' target="_blank"><img id="img_banner" runat="server" src='<%# Eval("img")%>' style="border:none;height:40px;margin:3px;" alt="" /></a>
                    </td>
                    <td>
                        <asp:FileUpload ID="upload" runat="server" />
                    </td>
                    <td>
                        <asp:TextBox ID="txtUrl" runat="server" ReadOnly="true" Text='<%# Eval("key")%>'></asp:TextBox>
                    </td>
                    <%--<td>                        
                        
                    </td>--%>
                </tr>
            </ItemTemplate>            
            <FooterTemplate>
                </table>
            </FooterTemplate>
        </asp:Repeater>
        
        <div style="text-align:center;margin-top:10px;">
        <asp:Button ID="btnOK" runat="server" Text="保 存" OnClick="btnOK_Click" />
        </div>
    </div>
    </form>
</body>
</html>
