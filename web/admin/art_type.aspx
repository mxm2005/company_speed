<%@ Page Language="C#" AutoEventWireup="true" CodeFile="art_type.aspx.cs" Inherits="admin_art_type" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>文章分类管理</title>
    <link type="text/css" rel="Stylesheet" href="/style/admin.css" />
    <link type="text/css" rel="Stylesheet" href="/facebox/facebox.css" />
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
                                    编号</th>
                                    <th>
                                        分类名称</th>
                                    <th>
                                        操作</th>
                            </tr>
                    </HeaderTemplate>
                    <ItemTemplate>
                        <tr>
                            <td>
                                <%# Eval("type_id") %>
                            </td>
                            <td style="text-align: left; padding:0px 3px;">
                                <%# Eval("type_name") %>
                            </td>
                            <td>
                                <a href='javascript:void(0)' onclick="showbox(this)">修改</a>&nbsp;&nbsp;
                                <asp:LinkButton
                                    ID="lbt_delete" runat="server" Text="删除" CommandArgument='<%# Eval("type_id") %>'
                                    CommandName="delete_type" OnCommand="delete_type" OnClientClick="return confirm('确认要删除此行信息吗？')" ></asp:LinkButton>
                            </td>
                        </tr>
                    </ItemTemplate>
                    <FooterTemplate>
                        </table>
                    </FooterTemplate>
                </asp:Repeater>
            </div>
            <div style="text-align: left; margin-top: 15px;padding:3px 5px;">
                <div style="background: #ddd; font: 14px; height: 26px; line-height: 26px;width:500px;padding-left:5px;">
                    添加分类</div>
                <div style="margin-top:5px;padding-left:5px;">
                    分类名称：<asp:TextBox ID="txtTypeName" runat="server"></asp:TextBox>
                    <asp:Button ID="btnAdd" runat="server" Text="添 加" OnClick="btnAdd_Click" />
                </div>
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
<script type="text/javascript" src="/js/jquery.js"></script>
<script type="text/javascript" src="/facebox/facebox.js"></script>
<script type="text/javascript">

function showbox(obj){
    var tr=$(obj).parent().parent().find("td");
    var id=tr.eq(0).html();
    var name=tr.eq(1).html();
    $.facebox($("#showbox").html().replace("{0}",id).replace("{1}",name).replace("{2}",name));
}
function editType(id,obj){
    $.get("/ajax/edit_art_type.ashx",
    {'type_id':id,'type_name':$(obj).prev().val(),'r':new Date()},
    function(d){
        if(d=="True"){
            alert("修改成功");
        }
        else{
            alert("修改失败");
        }
        $.facebox.close();
        window.location.reload();
    });
}
</script>