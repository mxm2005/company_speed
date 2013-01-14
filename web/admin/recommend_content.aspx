<%@ Page Language="C#" AutoEventWireup="true" CodeFile="recommend_content.aspx.cs" Inherits="admin_recommend_content" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>推荐分组内容管理</title>
    <link type="text/css" rel="Stylesheet" href="/style/admin.css" />
</head>
<body>
    <form id="form1" runat="server">    
    <div style="text-align:left;padding:0px 5px;">
    <span style="height:28px;line-height:28px;font-size:14px;font-weight:bold;">分组：
    <asp:Label ID="lblGroup" runat="server"></asp:Label>
    </span>
        <asp:Repeater ID="rptList" runat="server">
            <HeaderTemplate>
                <table id="tbLst" class="tb_grid" style="width:100%;">
                    <tr class="tr_head">
                        <th scope="col" width="20%">
                            标题
                        </th>
                        <th scope="col" width="35%">
                            内容
                        </th>
                        <th scope="col" width="25%">
                            链接
                        </th>
                        <th scope="col" width="10%">
                            图片
                        </th>
                        <th scope="col" width="10%">
                            操作
                        </th>
                    </tr>
            </HeaderTemplate>
            <ItemTemplate>
                <tr class="tr_light">
                    <td>
                        <%# Eval("title")%>
                    </td>
                    <td>
                        <%#  Eval("content")%>
                    </td>
                    <td>
                        <%# Eval("url")%>
                    </td>
                    <td>
                        <img alt='' style="width:80px;height:80px;" src='<%# GetImgPath(Eval("picture").ToString())%>' />
                    </td>
                    <td>
                        <a href="recommend_content_edit.aspx?id=<%# Eval("id") %>">修改</a>&nbsp;<asp:LinkButton
                            ID="lbt_delete" runat="server" Text="删除" CommandArgument='<%# Eval("group_id") %>'
                            CommandName="delete_type" OnCommand="delete_type" OnClientClick="return confirm('确认要删除此行信息吗？')"></asp:LinkButton>
                    </td>
                </tr>
            </ItemTemplate>
            <FooterTemplate>
                </table>
            </FooterTemplate>
        </asp:Repeater>
    </div>
    <div style="padding:5px 5px;text-align:left;">
    <span style="height:32px;line-height:32px;font-size:14px;font-weight:bold;">新增推荐</span>
        <br />
        编号：<asp:TextBox ID="txtID" runat="server" ReadOnly="true" Width="100px" style="color:Green;" Text="0"></asp:TextBox><br />
        标题：<asp:TextBox ID="txtTitle" runat="server" MaxLength="100" Width="300px"></asp:TextBox><br />
        内容：<asp:TextBox ID="txtContent" runat="server" MaxLength="300" Height="60" Rows="3" Width="500px"></asp:TextBox><br />
        链接：<asp:TextBox ID="txtURL" runat="server" Width="299px"></asp:TextBox>
        <span style="color:#CCC;">示例：http://www.baidu.com</span>
        <br />
        图片：<asp:FileUpload ID="fileUp1" runat="server" Width="307px" /><br />
    <asp:Button ID="btnAdd" runat="server" Text="保 存" OnClick="btnAdd_Click" />
    </div>
    </form>
</body>
</html>
