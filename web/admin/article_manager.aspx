<%@ Page Language="C#" AutoEventWireup="true" CodeFile="article_manager.aspx.cs" Inherits="admin_article_manager" %>
<%@ Register Assembly="AspNetPager" Namespace="Wuqi.Webdiyer" TagPrefix="pager" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>资讯列表管理</title>
    <link type="text/css" rel="Stylesheet" href="/style/admin.css" />
</head>
<body>
    <form id="form1" runat="server">    
    <div style="margin: 5px;">
    <div style="text-align:left;height:34px;line-height:34px;">
    分类：
    <asp:DropDownList ID="ddlType" runat="server">
    </asp:DropDownList>
    标题：
    <asp:TextBox ID="txtKeyWord" runat="server"></asp:TextBox>
    <asp:Button ID="btnFilter" runat="server" Text="过 滤" OnClick="btnFilter_Click" />
    </div>
    <%--OnItemDataBound="rpt_OnItemDataBound"  onitemcommand="rpt_OnItemCommand"
            --%>
        <asp:Repeater ID="rptList" runat="server">
            <HeaderTemplate>
                <table id="tbLst" class="tb_grid" style="width: 100%;">
                    <tr class="tr_head">
                        <th scope="col" width="1%" style="text-align:center;">
                            <input id="chkAll" type="checkbox" onclick="selectAll('chkAll')" />
                        </th>
                        <th scope="col" width="22%">
                            标题
                        </th>
                        <th scope="col" width="4%">
                            作者
                        </th>
                        <th scope="col" width="9%">
                            更新时间
                        </th>
                        <th scope="col" width="3%">
                            状态
                        </th>
                        <th scope="col" width="10%">
                            操作
                        </th>
                    </tr>
            </HeaderTemplate>
            <ItemTemplate>
                <tr class="tr_light">
                    <td style="text-align:center;">
                        <asp:CheckBox ID="chkItem" runat="server"></asp:CheckBox>
                        <span style="display:none;"><%# Eval("aid")%></span>
                    </td>
                    <td>
                        <a href='/article_detail.aspx?id=<%# Eval("aid")%>' target="_blank"><%# Eval("title")%></a>
                    </td>
                    <td>
                        <%# Eval( "author" )%>
                    </td>
                    <td>
                        <%# Eval( "update_time" )%>
                    </td>
                    <td>
                        <%# Eval("status")%>
                    </td>
                    <td>                        
                        <a href='/admin/article_edit.aspx?aid=<%# Eval("aid") %>'>编辑</a>&nbsp;&nbsp;
                        <asp:LinkButton
                                    ID="lbt_delete" runat="server" Text="删除" CommandArgument='<%# Eval("aid") %>'
                                    CommandName="delete_type" OnCommand="delete_type" OnClientClick="return confirm('确认要删除此行信息吗？')" ></asp:LinkButton>
                    </td>
                </tr>
            </ItemTemplate>
            <AlternatingItemTemplate>
                <tr class="tr_blue">
                    <td style="text-align:center;">
                        <asp:CheckBox ID="chkItem" runat="server"></asp:CheckBox>
                        <span style="display:none;"><%# Eval("aid")%></span>
                    </td>
                    <td>
                        <a href='/article_detail.aspx?id=<%# Eval("aid")%>' target="_blank"><%# Eval("title")%></a>
                    </td>
                    <td>
                        <%# Eval( "author" )%>
                    </td>
                    <td>
                        <%# Eval( "update_time" )%>
                    </td>
                    <td>
                        <%# Eval("status")%>
                    </td>
                    <td>                        
                        <a href='/admin/article_edit.aspx?aid=<%# Eval("aid") %>'>编辑</a>&nbsp;&nbsp;
                        <asp:LinkButton
                                    ID="lbt_delete" runat="server" Text="删除" CommandArgument='<%# Eval("aid") %>'
                                    CommandName="delete_type" OnCommand="delete_type"  OnClientClick="return confirm('确认要删除此行信息吗？')" ></asp:LinkButton>
                    </td>
                </tr>
            </AlternatingItemTemplate>
            <FooterTemplate>
                </table>
            </FooterTemplate>
        </asp:Repeater>
    <pager:AspNetPager ID="pager1" runat="server" UrlPaging="true" HorizontalAlign="Center"></pager:AspNetPager>
    </div>
    </form>
</body>
</html>
