<%@ Page Language="C#" AutoEventWireup="true" CodeFile="download_manager.aspx.cs" Inherits="admin_download_manager" %>
<%@ Register Assembly="AspNetPager" Namespace="Wuqi.Webdiyer" TagPrefix="pager" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>列表-下载管理</title>
    <link type="text/css" rel="Stylesheet" href="/style/admin.css" />
</head>
<body>
    <form id="form1" runat="server">    
    <div style="margin: 5px;">
    <%--OnItemDataBound="rpt_OnItemDataBound"--%>
        <asp:Repeater ID="rptList" runat="server"  onitemcommand="rpt_OnItemCommand"
            >
            <HeaderTemplate>
                <table id="tbLst" class="tb_grid" style="width: 100%;">
                    <tr class="tr_head">
                        <th scope="col" width="1%" style="text-align: center;">
                            <input id="chkAll" type="checkbox" onclick="selectAll('chkAll')" />
                        </th>
                        <th scope="col" width="15%">
                            名称
                        </th>
                        <th scope="col" width="10%">
                            图片
                        </th>
                        <%--<th scope="col" width="30%">
                            描述
                        </th>--%>
                        <%--<th scope="col" width="5%">
                            排序
                        </th>--%>
                        <th scope="col" width="10%">
                            创建时间
                        </th>
                        <th scope="col" width="15%">
                            操作
                        </th>
                    </tr>
            </HeaderTemplate>
            <ItemTemplate>
                <tr class="tr_light">
                    <td style="text-align:center;">
                        <asp:CheckBox ID="chkItem" runat="server"></asp:CheckBox>
                    </td>
                    <td>
                        <a href='/download.aspx' target="_blank"><%# Eval("name")%></a>
                    </td>
                    <td>
                        <img alt='' width="100" height="100" src='<%# GetPic(Eval("picture").ToString())%>' />
                    </td>
                    <%--<td>
                        <%# Eval( "remark" )%>
                    </td>
                    <td>
                        <%# Eval( "sort" )%>
                    </td>--%>
                    <td>
                        <%# Eval("create_time") %>
                    </td>
                    <td>                        
                        <asp:LinkButton Text="删除" ID="lbtnOpen" runat="server" CommandName="lbt_opt" CommandArgument='<%# Eval("down_id") %>' OnClientClick="return confirm('确认要删除此行信息吗？')" ></asp:LinkButton>&nbsp;&nbsp;<a href='/admin/download_edit.aspx?id=<%# Eval("down_id") %>'>编辑</a>
                    </td>
                </tr>
            </ItemTemplate>            
            <FooterTemplate>
                </table>
            </FooterTemplate>
        </asp:Repeater>
    <pager:AspNetPager ID="pager1" runat="server" UrlPaging="true" HorizontalAlign="Center"></pager:AspNetPager>     
    </div>
    </form>
</body>
</html>
