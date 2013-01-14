<%@ Page Language="C#" AutoEventWireup="true" CodeFile="product_type.aspx.cs" Inherits="admin_product_type" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>产品类别管理</title>
    <link type="text/css" rel="Stylesheet" href="/style/admin.css" />
    <link type="text/css" rel="Stylesheet" href="/facebox/facebox.css" />
</head>
<body>
     <form id="form1" runat="server">
        <div style="padding: 0px 5px;width:800px;">
            <div style="height:28px;line-height:28px;text-align:left;">
                <a href='product_type.aspx'>顶级大类</a>--><asp:Label ID="lbl_parent_type" runat="server"></asp:Label>
            </div>
            <div style="height:300px;overflow:auto;">
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
                                <a href='javascript:void(0)' onclick='showbox(<%# Eval("type_id") %>)'>修改</a>&nbsp;&nbsp;
                                <a href='product_type.aspx?parent_id=<%# Eval("type_id") %>'>管理子类</a>&nbsp;&nbsp;<asp:LinkButton
                                    ID="lbt_delete" runat="server" Text="删除" CommandArgument='<%# Eval("type_id") %>'
                                    CommandName="delete_type" OnCommand="delete_type" OnClientClick="return confirm('确认要删除此行信息吗？')" ></asp:LinkButton>
                                    &nbsp;
                                    <a href="javascript:void(0)" onclick="Up(this)"><img border="0" src="/images/up.gif" /></a>
                                    &nbsp;
                                    <a href="javascript:void(0)" onclick="Down(this)"><img border="0" src="/images/down.gif" /></a>
                       <span style="display:none;"><%# Eval("sort") %></span>
                            </td>
                        </tr>
                    </ItemTemplate>
                    <FooterTemplate>
                        </table>
                    </FooterTemplate>
                </asp:Repeater>
            </div>
            <div style="text-align:left;padding-left:10px;">
            <input id="btnSaveSort" type="button" value="保存排序" onclick="SaveSort()" />
            </div>
            <div style="text-align: left; margin-top: 15px;padding:3px 5px;">
                <div style="background: #ddd; font: 14px; height: 26px; line-height: 26px;width:500px;padding-left:5px;">
                    添加分类</div>
                <div style="margin-top:5px;padding-left:5px;">
                    分类名称：<asp:TextBox ID="txtTypeName" runat="server"></asp:TextBox><br />
                    分类图片：<asp:FileUpload ID="upload" runat="server" /><br />
                    分类描述：<asp:TextBox ID="txtTypeRemark" runat="server" TextMode="MultiLine" Height="62px" Width="413px" MaxLength="2000"></asp:TextBox>                    
                    <br />
                    <asp:Button ID="btnAdd" runat="server" Text="添 加" OnClick="btnAdd_Click" />
                    <a></a>
                </div>
            </div>
        </div>
    </form>
    <div class="showbox" id="showbox">
    <iframe id="boxIframe" src="product_type_edit.aspx?type_id={0}" scrolling="no" style="border:none;width:350px;height:350px;"></iframe>
    </div>
</body>
</html>
<script type="text/javascript" src="/js/jquery.js"></script>
<script type="text/javascript" src="/facebox/facebox.js"></script>
<script type="text/javascript">

function showbox(id){
    var content= $("#showbox").html().replace("{0}",id);
    $.facebox(content);
    $('#facebox .content').attr('style','width:350px;');
    $(document).bind('afterClose.facebox', function() {window.location.reload(true);});
}
function SaveSort(){
    var trs=$("table.tb_grid").find("tr");
    var ids="";
    for(var i=1;i<=trs.length-1;i++){
        ids+=trs.eq(i).find("td").eq(0).html();
        if(i!=trs.length-1){
            ids+="#";
        }
    }
    $.get("/ajax/UpdateProductSort.ashx",{"ids":ids,"d":new Date()},function(d){
        if(d=="True"){
            alert("保存成功");
        }else{
            alert("保存失败，原因请查看日志");
        }
    });
}
function Up(obj){
    var trs=$("table.tb_grid").find("tr");
    var thisTr=$(obj).parent().parent();
    var newTb="<tr>"+trs.eq(0).html()+"</tr>";
    for(var i=1;i<=trs.length-1;i++){
        if(i>1 && trs.eq(i).find("td").eq(0).html()==thisTr.find("td").eq(0).html()){
            var tmp=trs.eq(i-1).html();
            trs.eq(i-1).html(thisTr.html());
            trs.eq(i).html(tmp);
        }
    }
    for(var i=1;i<=trs.length-1;i++){
        newTb+="<tr>"+trs.eq(i).html()+"</tr>";
    }
    $("table.tb_grid").html(newTb);
}
function Down(obj){
    var trs=$("table.tb_grid").find("tr");
    var thisTr=$(obj).parent().parent();
    var newTb="<tr>"+trs.eq(0).html()+"</tr>";
    for(var i=1;i<=trs.length-1;i++){
        if(i<trs.length-1 && trs.eq(i).find("td").eq(0).html()==thisTr.find("td").eq(0).html()){
            var tmp=trs.eq(i+1).html();
            trs.eq(i+1).html(thisTr.html());
            trs.eq(i).html(tmp);
        }
    }
    for(var i=1;i<=trs.length-1;i++){
        newTb+="<tr>"+trs.eq(i).html()+"</tr>";
    }
    $("table.tb_grid").html(newTb);
}
</script>