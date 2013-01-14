<%@ Page Language="C#" AutoEventWireup="true" CodeFile="htmlManager.aspx.cs" Inherits="admin_htmlManager" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>HTML页管理</title>
    <link type="text/css" rel="Stylesheet" href="/style/admin.css" />
</head>
<body>
     <form id="form1" runat="server">
        <div style="padding: 5px 5px;width:800px;">
            <div style="height:350px;overflow:auto;">
                <asp:Repeater ID="rptList" runat="server">
                    <HeaderTemplate>
                        <table class="tb_grid">
                            <tr>
                                <th>
                                    名称</th>
                                    <th>
                                        路径</th>
                                    <th>
                                        操作</th>
                            </tr>
                    </HeaderTemplate>
                    <ItemTemplate>
                        <tr>
                            <td align="left">
                                <%# Eval("name") %>
                            </td>
                            <td style="text-align: left; padding:0px 3px;">
                                <%# Eval("file") %>
                            </td>
                            <td>
                                <a href='html_edit.aspx?key=<%# Eval("key") %>' target="_self">修改</a>
                            </td>
                        </tr>
                    </ItemTemplate>
                    <FooterTemplate>
                        </table>
                    </FooterTemplate>
                </asp:Repeater>
            </div>
        </div>
         <div style="display: none;">
             <div id="showbox" style="border:solid 1px red;text-align:center;line-height:30px;">
                <input id="txtShowId" type="text" value="{2}" />
                <input id="btnEdit" type="button" onclick="editType('{0}',this)" value="修改" />
             </div>
         </div>
    </form>
</body>
</html>