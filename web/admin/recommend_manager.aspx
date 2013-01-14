<%@ Page Language="C#" AutoEventWireup="true" CodeFile="recommend_manager.aspx.cs" Inherits="admin_recommend_manager" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>推荐管理</title>
    <link type="text/css" rel="Stylesheet" href="/style/admin.css" />
</head>
<body>
    <form id="form1" runat="server">    
    <div style="text-align:left;padding:0px 5px;">
    <span style="height:28px;line-height:28px;font-size:14px;font-weight:bold;">推荐分组</span>
        <asp:Repeater ID="rptList" runat="server">
            <HeaderTemplate>
                <table id="tbLst" class="tb_grid" style="width:600px;">
                    <tr class="tr_head">
                        <th scope="col" width="80%">
                            标题
                        </th>
                        <th scope="col" width="20%">
                            操作
                        </th>
                    </tr>
            </HeaderTemplate>
            <ItemTemplate>
                <tr class="tr_light">
                    <td>
                        <%# Eval("group_name")%>
                    </td>
                    <td>                        
                        <a href='/admin/recommend_content.aspx?gid=<%# Eval("group_id") %>'>去推荐内容</a>&nbsp;
                        <asp:LinkButton
                                    ID="lbt_delete" runat="server" Text="删除" CommandArgument='<%# Eval("group_id") %>'
                                    CommandName="delete_type" OnCommand="delete_type" OnClientClick="return confirm('确认要删除此行信息吗？')" ></asp:LinkButton>
                    </td>
                </tr>
            </ItemTemplate>
            <AlternatingItemTemplate>
            <tr class="tr_blue">
                    <td>
                        <%# Eval("group_name")%>
                    </td>
                    <td>                        
                        <a href='/admin/recommend_content.aspx?gid=<%# Eval("group_id") %>'>去推荐内容</a>&nbsp;
                        <asp:LinkButton
                                    ID="lbt_delete" runat="server" Text="删除" CommandArgument='<%# Eval("group_id") %>'
                                    CommandName="delete_type" OnCommand="delete_type" OnClientClick="return confirm('确认要删除此行信息吗？')" ></asp:LinkButton>
                    </td>
                </tr>
            </AlternatingItemTemplate>
            <FooterTemplate>
                </table>
            </FooterTemplate>
        </asp:Repeater>
    </div>
    <div style="padding:5px 5px;text-align:left;">
    <span style="height:28px;line-height:28px;font-size:14px;font-weight:bold;">新增分组</span>
        <br />
    <asp:TextBox ID="txtGroupName" runat="server"></asp:TextBox>
    <asp:Button ID="btnAdd" runat="server" Text="添 加" OnClick="btnAdd_Click" />
    </div>
    </form>
</body>
</html>
