﻿function changeAdminFlag(Content) {
    var row = parent.parent.headFrame.document.all.Trans.rows[0];
    row.cells[3].innerHTML = Content;
    return true;
}

function ConfirmDelSort(Result, ID) {
    if (confirm("是否确定删除本类、子类及下属所有信息？")) {
        window.location.href = Result + ".Asp?Action=Del&ID=" + ID
    }
}

function AddToSort(imagePath) {
    window.opener.LPform.LPattern.focus();
    window.opener.document.LPform.LPattern.value = imagePath;
    window.opener = null;
    window.close();
}

function OpenScript(url, width, height) {
    var win = window.open(url, "SelectToSort", 'width=' + width + ',height=' + height + ',resizable=1 ,scrollbars=yes, menubar=no, status=yes');
}

function EndSortChange(a, b) {
    if (eval(a).style.display == '') {
        eval(a).style.display = 'none';
        eval(b).className = 'SortEndFolderOpen';
    }
    else {
        eval(a).style.display = '';
        eval(b).className = 'SortEndFolderClose';
    }
}

function SortChange(a, b) {
    if (eval(a).style.display == '') {
        eval(a).style.display = 'none';
        eval(b).className = 'SortFolderOpen';
    }
    else {
        eval(a).style.display = '';
        eval(b).className = 'SortFolderClose';
    }
}

function CheckOthers(form) {
    for (var i = 0; i < form.elements.length; i++) {
        var e = form.elements[i];
        if (e.checked == false) {
            e.checked = true;
        }
        else {
            e.checked = false;
        }
    }
}

function CheckAll(form) {
    for (var i = 0; i < form.elements.length; i++) {
        var e = form.elements[i];
        e.checked = true;
    }
}

function ConfirmDel(message) {
    if (confirm(message)) {
        document.formDel.submit()
    }
}

function OpenDialog(sURL, iWidth, iHeight) {
    var oDialog = window.open(sURL, "_EditorDialog", "width=" + iWidth.toString() + ",height=" + iHeight.toString() + ",resizable=no,left=0,top=0,scrollbars=no,status=no,titlebar=no,toolbar=no,menubar=no,location=no");
    oDialog.focus();
}

function voidNum(argValue) {
    var flag1 = false;
    var compStr = "1234567890abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ_-";
    var length2 = argValue.length;
    for (var iIndex = 0; iIndex < length2; iIndex++) {
        var temp1 = compStr.indexOf(argValue.charAt(iIndex));
        if (temp1 == -1) {
            flag1 = false;
            break;
        }
        else
        { flag1 = true; }
    }
    return flag1;
}

function CheckAdminEdit() {
    if (document.editAdminForm.AdminName.value.length < 3 || document.editAdminForm.AdminName.value.length > 10) {
        alert("请正确输入登录名(必须为0-9,a-z,-_组合)！");
        document.editAdminForm.AdminName.focus();
        return false;
        exit;
    }
    var check;
    if (!voidNum(document.editAdminForm.AdminName.value)) {
        alert("请正确输入登录名(必须为0-9,a-z,-_组合)！");
        document.editAdminForm.AdminName.focus();
        return false;
        exit;
    }
}

function CheckMemEdit() {
    if (document.editMemForm.MemName.value.length < 3 || document.editMemForm.MemName.value.length > 16) {
        alert("请正确输入登录名(必须为0-9,a-z,-_组合)！");
        document.editMemForm.MemName.focus();
        return false;
        exit;
    }
    var check;
    if (!voidNum(document.editMemForm.MemName.value)) {
        alert("请正确输入登录名(必须为0-9,a-z,-_组合)！");
        document.editMemForm.MemName.focus();
        return false;
        exit;
    }
}

function AdminOut() {
    if (confirm("是否确定退出管理登录？"))
        location.replace("CheckAdmin.asp?AdminAction=Out")
}

function GoPage(Myself) {
    window.location.href = Myself + "Page=" + document.formDel.SkipPage.value;
}

function AddSort(SortName,ID,Path)
{
	window.opener.editForm.SortName.focus();
	window.opener.document.editForm.SortName.value=SortName;
	window.opener.document.editForm.SortID.value=ID;
	window.opener.document.editForm.SortPath.value=Path;
    window.opener=null;
    window.close();
}

function test() {
    if (!confirm('是否确定进行批量操作？操作后不能恢复！')) return false;
}

function num_1() {
    var num_1 = document.getElementById("Num_1").value;
    var num_1_str = document.getElementById("num_1_str");
    var str;
    str = "<table width='100%' border='0' cellspacing='0' cellpadding='0'>";
    for (var i = 0; i < num_1; i++) {
        str = str + "<tr><td height='28'>";
        str = str + "属性名称：<input name='attributeCh" + (parseInt(i) + 1) + "' type='text' id='attributeCh" + (parseInt(i) + 1) + "' size='18' /> 属性值：<input name='attributeCh" + (parseInt(i) + 1) + "_value' type='text' id='attributeCh" + (parseInt(i) + 1) + "_value' size='50' /></td>";
        str = str + "</tr>";
    }
    str = str + "</table>";
    num_1_str.innerHTML = str;
}

function num_1_1() {
    var num_1 = document.getElementById("Num_1").value;
    var num_1_str = document.getElementById("num_1_str");
    var str;
    str = "<table width='100%' border='0' cellspacing='0' cellpadding='0'>";
    str = str + "<tr><td height='28'>";
    str = str + "属性名称：<input name='attributeCh" + (parseInt(num_1) + 1) + "' type='text' id='attributeCh" + (parseInt(num_1) + 1) + "' size='18' /> 属性值：<input name='attributeCh" + (parseInt(num_1) + 1) + "_value' type='text' id='attributeCh" + (parseInt(num_1) + 1) + "_value' size='50' /></td>";
    str = str + "</tr>";
    str = str + "</table>";
    num_1_str.innerHTML = num_1_str.innerHTML + str;
    document.getElementById("Num_1").value = (parseInt(num_1) + 1);
}

function num_2() {
    var num_2 = document.getElementById("num_2").value;
    var num_2_str = document.getElementById("num_2_str");
    var str;
    str = "<table width='100%' border='0' cellspacing='0' cellpadding='0'>";
    for (var i = 0; i < num_2; i++) {
        str = str + "<tr><td height='28'>";
        str = str + "属性名称：<input name='attributeEn" + (parseInt(i) + 1) + "' type='text' id='attributeEn" + (parseInt(i) + 1) + "' size='18' /> 属性值：<input name='attributeEn" + (parseInt(i) + 1) + "_value' type='text' id='attributeEn" + (parseInt(i) + 1) + "_value' size='50' /></td>";
        str = str + "</tr>";
    }
    str = str + "</table>";
    num_2_str.innerHTML = str;
}

function num_2_1() {
    var num_2 = document.getElementById("num_2").value;
    var num_2_str = document.getElementById("num_2_str");
    var str;
    str = "<table width='100%' border='0' cellspacing='0' cellpadding='0'>";
    str = str + "<tr><td height='28'>";
    str = str + "属性名称：<input name='attributeEn" + (parseInt(num_2) + 1) + "' type='text' id='attributeEn" + (parseInt(num_2) + 1) + "' size='18' /> 属性值：<input name='attributeEn" + (parseInt(num_2) + 1) + "_value' type='text' id='attributeEn" + (parseInt(num_2) + 1) + "_value' size='50' /></td>";
    str = str + "</tr>";
    str = str + "</table>";
    num_2_str.innerHTML = num_2_str.innerHTML + str;
    document.getElementById("num_2").value = (parseInt(num_2) + 1);
}

function num_3() {
    var num_3 = document.getElementById("Num_3").value;
    var num_3_str = document.getElementById("num_3_str");
    var str;
    str = "<table width='100%' border='0' cellspacing='0' cellpadding='0'>";
    for (var i = 0; i < num_3; i++) {
        str = str + "<tr><td height='28'>";
        str = str + "<input type='text' style='width: 300' name='more" + (parseInt(i) + 1) + "_pic' id='more" + (parseInt(i) + 1) + "_pic' /> <input type='button' value='上传图片' onclick=\"showUploadDialog('image', 'editForm.more" + (parseInt(i) + 1) + "_pic', '')\"></td>";
        str = str + "</tr>";
    }
    str = str + "</table>";
    num_3_str.innerHTML = str;
}

function num_3_1() {
    var num_3 = document.getElementById("Num_3").value;
    var num_3_str = document.getElementById("num_3_str");
    var str;
    str = "<table width='100%' border='0' cellspacing='0' cellpadding='0'>";
    str = str + "<tr><td height='28'>";
    str = str + "<input type='text' style='width: 300' name='more" + (parseInt(num_3) + 1) + "_pic' id='more" + (parseInt(num_3) + 1) + "_pic' /> <input type='button' value='上传图片' onclick=\"showUploadDialog('image', 'editForm.more" + (parseInt(num_3) + 1) + "_pic', '')\"></td>";
    str = str + "</tr>";
    str = str + "</table>";
    num_3_str.innerHTML = num_3_str.innerHTML + str;
    document.getElementById("Num_3").value = (parseInt(num_3) + 1);
}

function CopyWebTitleCh(v) {
    document.editForm.SeoKeywordsCh.value = v;
    document.editForm.SeoDescriptionCh.value = v;
}

function CopyWebTitleEn(v) {
    document.editForm.SeoKeywordsEn.value = v;
    document.editForm.SeoDescriptionEn.value = v;
}

function doDisplay(obj_Btn, s) {
    var obj_Table = document.getElementById("table_display_" + s);
    if (obj_Table.style.display != "") {
        obj_Table.style.display = "";
        obj_Btn.value = "隐藏编辑器";
    } else {
        obj_Table.style.display = "none";
        obj_Btn.value = "显示编辑器";
    }
}

function ShowDialog(url, width, height) {
    var arr = showModalDialog(url, window, "dialogWidth: " + width + "px; dialogHeight: " + height + "px; help: no; scroll: no; status: no");
}

function Addqul()
{
    var ul=document.getElementById("qul");
    var input=document.createElement("input");
    var li=document.createElement("li");
    input.setAttribute("name","sohu_FormContent");
    li.appendChild(input);
    ul.appendChild(li);
}

function Delqul()
{
    var ul=document.getElementById("qul");
    var li=ul.lastChild;
    if (ul.firstChild==li)
    alert("必须至少保留一个选项！");
    else
    ul.removeChild(li);
}