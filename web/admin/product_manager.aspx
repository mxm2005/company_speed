<%@ Page Language="C#" AutoEventWireup="true" CodeFile="product_manager.aspx.cs" Inherits="admin_product_manager" %>
<%@ Register Assembly="AspNetPager" Namespace="Wuqi.Webdiyer" TagPrefix="pager" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>产品发布管理</title>
    <link type="text/css" rel="Stylesheet" href="/style/admin.css" />
</head>
<body>
    <form id="form1" runat="server">    
    <div style="margin: 5px;">
    <div style="text-align:left;height:34px;line-height:34px;">    
    标题：
    <asp:TextBox ID="txtKeyWord" runat="server"></asp:TextBox>
    <asp:Button ID="btnFilter" runat="server" Text="过 滤" OnClick="btnFilter_Click" />
    </div>
    <%--OnItemDataBound="rpt_OnItemDataBound"--%>
        <asp:Repeater ID="rptList" runat="server"  onitemcommand="rpt_OnItemCommand"
            >
            <HeaderTemplate>
                <table id="tbLst" class="tb_grid" style="width: 100%;">
                    <tr class="tr_head">
                        <th scope="col" width="1%" style="text-align:center;">
                            <input id="chkAll" type="checkbox" onclick="selectAll('chkAll')" />
                        </th>
                        <th scope="col" width="2%">
                            编号
                        </th>
                        <th scope="col" width="22%">
                            产品名称
                        </th>
                        <th scope="col" width="5%">
                            产品图片
                        </th>
                        <th scope="col" width="8%">
                            发布时间
                        </th>
                        <th scope="col" width="3%">
                            状态
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
                        <%# Eval("pid")%>
                    </td>
                    <td>
                        <a href='/productview.aspx?pid=<%# Eval("pid")%>' target="_blank"><%# Eval("product_name")%></a>
                    </td>
                    <td>
                        <img src='<%# GetPic(Eval("picture").ToString()) %>' style="width:80px;height:80px;" />
                    </td>
                    <td>
                        <%# Eval( "create_time" )%>
                    </td>
                    <td>
                        <%# Eval("status").ToString() == "0" ? "隐藏" : "显示"%>
                    </td>
                    <td>                        
                        <asp:LinkButton Text="显示/隐藏" ID="lbtnOpen" runat="server" CommandName="OpenStop" CommandArgument='<%# Eval("pid") +","+ Eval("status") %>'></asp:LinkButton>&nbsp;<a href='/admin/product_edit.aspx?pid=<%# Eval("pid") %>'>编辑</a>&nbsp;<asp:LinkButton Text="删除" ID="LinkButton1" runat="server" CommandName="delete" CommandArgument='<%# Eval("pid") %>' OnClientClick="return confirm('确认要删除此行信息吗？')" ></asp:LinkButton>
                    </td>
                </tr>
            </ItemTemplate>
            <AlternatingItemTemplate>
                <tr class="tr_blue">
                    <td style="text-align:center;">
                        <asp:CheckBox ID="chkItem" runat="server"></asp:CheckBox>
                    </td>
                    <td>
                        <%# Eval("pid")%>
                    </td>
                    <td>
                        <a href='/productview.aspx?pid=<%# Eval("pid")%>' target="_blank"><%# Eval("product_name")%></a>
                    </td>
                    <td>
                        <img src='<%# GetPic(Eval("picture").ToString()) %>' style="width:80px;height:80px;" />
                    </td>
                    <td>
                        <%# Eval( "create_time" )%>
                    </td>
                    <td>
                        <%# Eval("status").ToString() == "0" ? "隐藏" : "显示"%>
                    </td>
                    <td>
                        <asp:LinkButton Text="显示/隐藏" ID="lbtnOpen" runat="server" CommandName="OpenStop" CommandArgument='<%# Eval("pid") +","+ Eval("status") %>'></asp:LinkButton>&nbsp;<a href='/admin/product_edit.aspx?pid=<%# Eval("pid") %>'>编辑</a>&nbsp;<asp:LinkButton Text="删除" ID="LinkButton1" runat="server" CommandName="delete" CommandArgument='<%# Eval("pid") %>' OnClientClick="return confirm('确认要删除此行信息吗？')" ></asp:LinkButton>
                    </td>
                </tr>
            </AlternatingItemTemplate>
            <FooterTemplate>
                </table>
            </FooterTemplate>
        </asp:Repeater>
    <pager:AspNetPager ID="pager1" runat="server" UrlPaging="true" HorizontalAlign="Center" PageSize="10"></pager:AspNetPager>     
    </div>
    </form>
</body>
</html>
