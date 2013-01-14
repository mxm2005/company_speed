
/// <reference path="/Js/jquery-1.4.1.min.js" />

var _JqueryIsUnload = false;     //开关
var AjaxJquery = null;   //请求变量
function AjaxStopRequest() {
    if (AjaxJquery != null) {
        AjaxJquery.abort();  //中止请求 
        _JqueryIsUnload = true;  //开关状态  
    }
    AjaxJquery = null;
    _JqueryIsUnload = false;
}
//Top导航栏目
function documentTop() {
    var str = "";
    str += "<div class=\"top2\">";
    str += "     <div class=\"FL gray_9\"><font id=\"TopUserName\"></font>欢迎使用内容作业系统</div>";
    str += "     <div style=\"_margin-top:3px;\" class=\"FR newFR\">";
    str += "         <a href=\"http://www.yituanma.com/\" target=\"_blank\">一团麻首页</a> ";
    str += "         <span class=\"gray_c\">|</span>";
    str += "         <a href=\"javascript:void(0);\" onclick=\"javascript:EditorPassWord('',1);return false;\">修改密码</a> ";
    str += "         <span class=\"gray_c\">|</span>";
    str += "         <a href=\"javascript:void(0);\" onclick=\"javascript:LoginOut();return false;\">退出</a> ";
    str += "      </div>";
    str += "</div>";
    return str;
}
//退出
function LoginOut() {
    if (confirm("您确定要退出系统吗？")) {
        $.ajax({
            url: "/Ajax/Login/LoginAction.aspx",
            type: "post",
            data: { actionType: "2", rand: new Date().getTime() },
            dataType: "text",
            success: function (data, textStatus) {
                if (data == "1") {
                    window.location.href = "/login.aspx";
                } else { alert("退出失败,请重试!"); }
            },
            error: function (XMLHttpRequest, textStatus) {
                alert("退出失败,请重试!");
            }
        });
    }
}
//修改密码
function EditorPassWord(obj, type) {
    if (type == 1) {
        HiddenSelect(1);
        var strHtml = "";
        strHtml += "<div class=\"mask\" id=\"mask\"></div>";
        strHtml += "<div class=\"pwdpop_bg\" id=\"editorpwd\" style=\"width:400px;height:300px; left:50%;top:20%; font-size:14px;\">";
        strHtml += "     <div class=\"pwdpop_k\" style=\"padding:0px;\">";
        strHtml += "          <a href=\"javascript:void(0);\" onclick=\"javascript:HiddenDiv();return false;\" class=\"btn_close3\"><img src=\"/images/btn_close.gif\" /></a>";
        strHtml += "          <h1 class=\"T_cnter\" style=\"font-size:24px; font-family:'微软雅黑', '宋体'; width:370px; margin:0px auto; padding:20px 0px;\">修改密码</h1>";
        strHtml += "          <div class=\"pwdarticle\" >";
        strHtml += "                   <p>&nbsp;&nbsp;旧密码：<input type=\"password\"  id=\"OldInput\" class=\"input_25\" /></p>";
        strHtml += "                   <p>&nbsp;&nbsp;新密码：<input type=\"password\"  id=\"NewInput\" class=\"input_25\" /></p>";
        strHtml += "                   <p>确认密码：<input type=\"password\"  id=\"ConInput\" class=\"input_25\" /></p>";
        strHtml += "          </div>";
        strHtml += "          <div class=\"btn_xg\"><input type=\"button\" value=\"修改\" class=\"btn_1\" onclick=\"EditorPassWord(this,2);\" />";
        strHtml += "                   <p class=\"MT5\"><span id=\"ErrorTip\" style=\"color:#FF0000;font-size:12px;\">&nbsp;</span></p></div>";
        strHtml += "     </div>";
        strHtml += "</div>";
        $("body").prepend(strHtml);

        //设置DIV高度
        var H = document.body.clientHeight;
        var Page_H = document.documentElement.clientHeight;
        if (H > Page_H) {
            $("#mask").css("height", H + "px");
        }
        if (Page_H > H) {
            $("#mask").css("height", Page_H + "px");
        }
    }
    else {
        if ($("#OldInput").val() == "") { $("#OldInput").focus(); $("#ErrorTip").html("旧密码不能为空"); return; }
        if ($("#NewInput").val() == "") { $("#NewInput").focus(); $("#ErrorTip").html("新密码不能为空"); return; }
        if ($("#ConInput").val() == "") { $("#ConInput").focus(); $("#ErrorTip").html("确认密码不能为空"); return; }
        if ($("#NewInput").val() != $("#ConInput").val()) { $("#ConInput").focus(); $("#ErrorTip").html("两次密码不一样"); return; }
        $.ajax({
            url: "/Ajax/Login/LoginAction.aspx",
            type: "post",
            data: { actionType: "3", OldPwd: $("#OldInput").val(), NewPwd: $("#NewInput").val(), ConPwd: $("#ConInput").val(), rand: new Date().getTime() },
            dataType: "text",
            beforeSend: function (XMLHttpRequest) {
                $(obj).attr("disabled", "disabled");
                $("#ErrorTip").html("正在操作，请稍候…")
            },
            success: function (data, textStatus) {
                $(obj).removeAttr("disabled"); $("#ErrorTip").html("&nbsp;")
                if (data == "Success") {
                    $("#ErrorTip").html("修改成功");
                    HiddenDiv();
                }
                else if (data == "OldFailure") {
                    $("#OldInput").focus();
                    $("#ErrorTip").html("旧密码错误");
                    return;
                }
                else if (data == "Failure") {
                    $("#ErrorTip").html("密码修改失败");
                    return;
                }
                else if (data == "NoSame") {
                    $("#ErrorTip").html("两次密码不一样");
                    return;
                }
                else {
                    $("#ErrorTip").html("密码修改失败");
                    return;
                }
            }
        });
    }
}
//获取用户名
function GetEditorUserName() {
    var UserName = "";
    $.ajax({
        url: "/Ajax/Primary/Primary.ashx",
        type: "post",
        data: { action: "GetUserName", rand: new Date().getTime() },
        dataType: "text",
        cache: false,
        success: function (data, textStatus) {
            if (data != "") {
                $("#TopUserName").html(data + "，");
            }
        }
    });
}
//弹出编辑内容层
//type=1弹出采集层，type=2弹出查看层,type=3弹出修改层
function EditorDivLayer(type, id) {
    HiddenDiv();
    HiddenSelect(1);
    if (type == 1) {
        SetContent(id, "", "", "");
        SetDivHeight(type);
    }
    else {
        $.ajax({
            url: "/Ajax/Primary/Primary.ashx?jsoncallback=?",
            data: { action: "EditorDivLayer",
                IDTypeDate: id,
                rand: new Date().getTime()
            },
            type: "POST",
            dataType: "json",
            cache: false,
            success: function (data) {
                if (data.State == "success") {
                    if (type == 2) {
                        var strHtml = "";
                        strHtml += "<div class=\"mask\" id=\"mask\"></div>";
                        strHtml += "<div class=\"pop_bg\" id=\"article_pop\" style=\"width:840px; margin-left:-420px; font-size:14px;\">";
                        strHtml += "     <div class=\"pop_k\" style=\"padding:0px;\">";
                        strHtml += "          <a href=\"javascript:void(0);\" onclick=\"javascript:HiddenDiv();return false;\" class=\"btn_close3\"><img src=\"/images/btn_close.gif\" /></a>";
                        strHtml += "          <h1 class=\"T_cnter\" style=\"font-size:24px; font-family:'微软雅黑', '宋体'; width:778px; margin:0px auto; padding:20px 0px;\">" + data.Title + "</h1>";
                        strHtml += "          <div class=\"article\">";
                        strHtml += "               <p style=\"font-size:14px; line-height:24px;text-indent:28px; margin-top:20px;\">" + data.Content + "</p>";
                        strHtml += "          </div>";
                        strHtml += "          <div class=\"btn_xg\"><input type=\"button\" value=\"关闭\" class=\"btn_1\" onclick=\"HiddenDiv();\" /></div>";
                        strHtml += "     </div>";
                        strHtml += "</div>";
                        $("body").prepend(strHtml);
                    }
                    else if (type == 3) {
                        SetContent(id, data.Title, data.Content, data.KeyWords);
                    }
                }
            },
            complete: function (XMLHttpRequest) {
                SetDivHeight(type);
            }
        })
    }
}
function SetDivHeight(type) {
    //设置DIV高度
    var H = document.body.clientHeight;
    var Page_H = document.documentElement.clientHeight;
    if (H > Page_H) {
        $("#mask").css("height", H + "px");
    }
    if (Page_H > H) {
        $("#mask").css("height", Page_H + "px");
    }
    var Scroll_H = document.body.scrollTop + document.documentElement.scrollTop;
    var Div_H = 0;
    var Div_top = 0;
    if (type == 1 || type == 3) {
        Div_H = document.getElementById("editor_pop").offsetHeight;
        Div_top = Scroll_H + (Page_H - Div_H) / 2;
        $("#editor_pop").css({ "top": Div_top + "px", "visibility": "visible" });
    }
    else {
        Div_H = document.getElementById("article_pop").offsetHeight;
        Div_top = Scroll_H + (Page_H - Div_H) / 2;
        $("#article_pop").css({ "top": Div_top + "px", "visibility": "visible" });
    }
}
//弹出采集层
function SetContent(Id, Title, Content, Keys) {
    var strHtml = "";
    strHtml += "<div class=\"mask\" id=\"mask\"></div>";
    strHtml += "<!--------弹窗-------->";
    strHtml += "<div class=\"pop_chose_city\" id=\"editor_pop\" style=\"width:582px; margin-left:-291px;\">";
    strHtml += "     <div class=\"pop_border2\">";
    strHtml += "          <div class=\"add_sj_xq P15\">";
    strHtml += "               <ul>";
    strHtml += "                   <li>标题：<input type=\"text\" title='标题不能超过20个字' id=\"InputTitle\" class=\"input_25\" style=\"width:506px;\" value=\"" + Title + "\" /></li>";
    strHtml += "                   <li>";

    strHtml += "     <div style=\"border:1px solid #B4C1C8\"><input type=\"hidden\" id=\"FckEditor\" name=\"FckEditor\" value=\"\" />";
    strHtml += "      <input type=\"hidden\" id=\"FckEditor___Config\" value=\"DefaultLanguage=zh-cn&amp;AutoDetectLanguage=false&amp;HtmlEncodeOutput=true\" />";
    strHtml += "        <iframe id=\"FckEditor___Frame\"  src=\"/Controls/FCKeditor_2.6.4.1/fckeditor/editor/fckeditor.html?InstanceName=FckEditor&amp;Toolbar=Default&amp;rand=" + new Date().getTime() + "\" width=\"548px\" height=\"270px\" frameborder=\"no\" scrolling=\"no\">";
    strHtml += "        </iframe>";
    strHtml += "     </div>";

    strHtml += "   </li>";
    strHtml += "                   <li>标签：<input type=\"text\" title='最多4个标签且每个标签不能为空且不能超过7个字,多个以“,”隔开' id=\"InputKeys\" class=\"input_25\" style=\"width:406px;\" value=\"" + Keys + "\"  /></li>";
    strHtml += "               </ul>";
    strHtml += "               <div class=\"T_cnter\" style=\"padding:5px 0px;\">";
    strHtml += " <input type=\"button\" value=\"预览\"  class=\"btn_7\" onclick=\"ContentPreview();\" /> ";
    strHtml += " <input type=\"button\" value=\"保存\" WorkId=\"" + Id + "\" class=\"btn_7\" onclick=\"BtnSave(this);\" />";
    strHtml += "                   <input type=\"button\" value=\"取消\" class=\"btn_6 ML10\" onclick=\"HiddenDiv();\" />";
    strHtml += "               <p class=\"MT15\"><span id=\"ErrorTip\" style=\"color:#FF0000;\">&nbsp;</span></p>";
    strHtml += "               </div>";
    strHtml += "          </div>";
    strHtml += "     </div>";
    strHtml += "</div>";
    strHtml += "<!--------弹窗END-------->";
    $("body").prepend(strHtml);
//    if (Content.length > 0) {
//        FckSetDataExtend.SetData("FckEditor", Content);
//    }
}

// 采编预览
function ContentPreview() {
    var oEditor = FCKeditorAPI.GetInstance("FckEditor");
    var Content = oEditor.GetXHTML(true);
    if ($("#InputTitle").val().replace(/\s+/g, "") == "") { $("#InputTitle").focus(); $("#ErrorTip").html("标题不能为空"); return; }
    if (Content == "") { oEditor.Focus(); $("#ErrorTip").html("内容不能为空"); return; }
    $("#ErrorTip").html("");
    var strHtml = "";
    strHtml += "<div class=\"mask\" style=\"z-index:202;\" id=\"mask_Preview\"></div>";
    strHtml += "<div class=\"pop_bg\" id=\"article_pop_Preview\" style=\"width:840px; margin-left:-420px; font-size:14px;z-index:203;\">";
    strHtml += "     <div class=\"pop_k\" style=\"padding:0px;\">";
    strHtml += "          <a href=\"javascript:void(0);\" onclick=\"ContentPreviewHide();\" class=\"btn_close3\"><img src=\"/images/btn_close.gif\" /></a>";
    strHtml += "          <h1 class=\"T_cnter\" style=\"font-size:24px; font-family:'微软雅黑', '宋体'; width:778px; margin:0px auto; padding:20px 0px;\">" + $("#InputTitle").val() + "</h1>";
    strHtml += "          <div class=\"article\">";
    strHtml += "               <p style=\"font-size:14px; line-height:24px;text-indent:28px; margin-top:20px;\">" + Content + "</p>";
    strHtml += "          </div>";
    strHtml += "          <div class=\"btn_xg\"><input type=\"button\" value=\"关闭\" class=\"btn_1\" onclick=\"ContentPreviewHide();\" /></div>";
    strHtml += "     </div>";
    strHtml += "</div>";
    $("body").prepend(strHtml);
    $("#mask").hide();
    $("#editor_pop").hide();
}

// 采编预览移除
function ContentPreviewHide() {
    // 移除预览
    $("#mask_Preview").remove();
    $("#article_pop_Preview").remove();
    // 显示采编div
    $("#mask").show();
    $("#editor_pop").show();
}

//采集保存
function BtnSave(obj) {
    $("#ErrorTip").html("&nbsp;");
    var oEditor = FCKeditorAPI.GetInstance("FckEditor");
    if ($("#InputTitle").val().replace(/\s+/g, "") == "") { $("#InputTitle").focus(); $("#ErrorTip").html("标题不能为空"); return; }
    if ($("#InputTitle").val().length > 20) { $("#InputTitle").focus(); $("#ErrorTip").html("标题太长，输入字符不能大于20"); return; }
    if ($("#InputTitle").val().indexOf("<") >= 0) { $("#InputTitle").focus(); $("#ErrorTip").html("标题包含非法字符"); return; }

    if (oEditor.GetXHTML(true) == "") { oEditor.Focus(); $("#ErrorTip").html("内容不能为空"); return; }

    if ($("#InputKeys").val().replace(/\s+/g, "") != "") {
        if ($("#InputKeys").val().indexOf("<") >= 0) { $("#InputKeys").focus(); $("#ErrorTip").html("标签包含非法字符"); return; }
        //寻找每一个中文逗号，并替换
        while ($("#InputKeys").val().indexOf("，") >= 0) { $("#InputKeys").val($("#InputKeys").val().replace("，", ",")); }
        if ($("#InputKeys").val().split(",").length > 4) { $("#InputKeys").focus(); $("#ErrorTip").html("最多只能写4个标签,多个以“,”隔开"); return; }
        else {
            for (var i = 0; i < $("#InputKeys").val().split(",").length; i++) {
                //标签包含中文及英文，则不能大于7个字符
                if (/.*[\u4e00-\u9fa5]+.*$/.test($("#InputKeys").val().split(",")[i])) {
                    if ($("#InputKeys").val().split(",")[i].length > 7 || $("#InputKeys").val().split(",")[i].length <= 0) {
                        $("#InputKeys").focus(); $("#ErrorTip").html("每个标签不能为空且不能超过7个字,多个以“,”隔开"); return;
                        break;
                    }
                }
                else {
                    //标签为全英文，则不能大于20个字符
                    if ($("#InputKeys").val().split(",")[i].length > 20 || $("#InputKeys").val().split(",")[i].length <= 0) {
                        $("#InputKeys").focus(); $("#ErrorTip").html("每个标签不能为空且纯英文字符不能超过20个字符,多个以“,”隔开"); return;
                        break;
                    }
                }
            }
        }
    }
    $.ajax({
        url: "/Ajax/Primary/Primary.ashx",
        data: { action: "BtnSave",
            IDTypeDate: $(obj).attr("WorkId"),
            TitleDate: $.trim($("#InputTitle").val()),
            ContentDate: oEditor.GetXHTML(true),
            KeysDate: $.trim($("#InputKeys").val()),
            rand: new Date().getTime()
        },
        type: "POST",
        dataType: "text",
        cache: false,
        beforeSend: function (XMLHttpRequest)
        { $("#ErrorTip").html("正在操作，请稍候…"); },
        success: function (data) {
            if (data == "success") {
                $("table tbody").find("tr").each(function (index) {
                    if ($(this).find("td").last().find("a").eq(1).attr("WorkId") == $(obj).attr("WorkId")) {
                        $(this).find("td").last().find("a").attr({ "disabled": "disabled" }).removeAttr("href").removeAttr("onclick").unbind("click").css({ "cursor": "auto", "color": "#999" });
                    }
                })
                $("#InputTitle").val("");
                $("#InputKeys").val("");
                FckSetDataExtend.SetData("FckEditor", "");
                $("#ErrorTip").html("采集成功");

                //sunx 用于刷新数据
                if ($("#hfExecution").length > 0) {
                    lodData();
                }
                else {
                    NewWorks('', 2, $("#IdWorkListDate").attr("_NavIdWorkType"), $("#IdWorkListDate").attr("_NavPageIndex"));
                }
                setTimeout(HiddenDiv, 1000);
            }
            else {
                $("#ErrorTip").html("采集失败"); return;
            }
        }
    });
}
//IE6下select会在层上
function HiddenSelect(type) {
    if (IsNavigator() == "IE6.0") {
        if (type == 1) {
            $("select").hide();
        } else {
            $("select").show();
        }
    }
}
//隐藏DIV
function HiddenDiv() {
    $(".mask").remove();
    $(".pop_chose_city").remove();
    $(".pop_bg").remove();
    $(".pwdpop_bg").remove();

    HiddenSelect(2);
    //移除FCK
    FckSetDataExtend.RemoveLoaded("FckEditor");
}
//判断浏览器
function IsNavigator() {
    var Sys = {};
    var ua = navigator.userAgent.toLowerCase();
    var s;
    (s = ua.match(/msie ([\d.]+)/)) ? Sys.ie = s[1] :
                (s = ua.match(/firefox\/([\d.]+)/)) ? Sys.firefox = s[1] :
                (s = ua.match(/chrome\/([\d.]+)/)) ? Sys.chrome = s[1] :
                (s = ua.match(/opera.([\d.]+)/)) ? Sys.opera = s[1] :
                (s = ua.match(/version\/([\d.]+).*safari/)) ? Sys.safari = s[1] : 0;

    var str = "";
    //以下进行测试
    if (Sys.ie) str = 'IE' + Sys.ie;
    if (Sys.firefox) str = 'Firefox';
    if (Sys.chrome) str = 'Chrome';
    if (Sys.opera) str = 'Opera';
    if (Sys.safari) str = 'Safari';
    return str;
}

//清除指定样式列表
function GetTextHtml() {
    //寻找每一个中文逗号，并替换
    while ($("#FckValue").val().toLowerCase().indexOf("font-size:") != -1 || $("#FckValue").val().toLowerCase().indexOf("size=") != -1) {
        $("#FckValue").val($("#FckValue").val().toLowerCase().replace("font-size:"), "");
        $("#FckValue").val($("#FckValue").val().toLowerCase().replace("size="), "");
    }
}
function tr_bg(m, n) {
    if (m == "hover") {
        n.className = "dq";
    }
    if (m == "out") {
        n.className = "";
    }
}

function reasons(m, n) {
    if (m == "hover") {
        n.className = "dq";
    }
    if (m == "out") {
        n.className = "";
    }
}

//判断FCK是否加载完成
var FckSetDataExtend = (function () {
    window["FCKeditor_OnComplete"] = function (ins) {
        FckSetDataExtend.AddLoaded(ins.Name);
        for (var i = 0; i < FckSetDataExtend._funList.length; i++)
            FckSetDataExtend._funList[i](ins);
    }
    return {
        _funList: [],
        _loadStore: {},
        AddLoaded: function (insName) {
            this._loadStore[insName] = true;
        },
        RemoveLoaded: function (insName) {
            //清除标记
            delete this._loadStore[insName];
            //清除函数
            FckSetDataExtend._funList.length = 0;
        },
        SetData: function (insName, value) {
            //判断是否加载完了
            if (this._loadStore[insName]) {
                //已加载,直接调用API设置值
                FCKeditorAPI.GetInstance(insName).SetData(value);
            } else {
                //未加载完,放到回调序列里,延时设置
                FckSetDataExtend._funList.push(function (ins) {
                    if (ins.Name == insName)
                        ins.SetData(value);
                });
            }
        }
    };
})();