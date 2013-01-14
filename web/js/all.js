function setMenuStyle(obj)
{
    $(".menusel").attr("class","");
	$(obj).parent().attr("class","menusel");
}

function setClass(id){
    $("#"+id).attr("class","menusel");
}

function selectAll(id)
{
	var val=$("#"+id).attr("checked");alert(val);

	if(val==true)
	{
		$(":input").attr("checked",true);
	}
	else
	{
		$(":input").attr("checked",false);
	}
}

function AddFavorite(sURL, sTitle)
{
	try
	{
		window.external.addFavorite(sURL, sTitle);
	}
	catch (e)
	{
		try
		{
			window.sidebar.addPanel(sTitle, sURL, "");
		}
		catch (e)
		{
			alert("加入收藏失败，请使用Ctrl+D进行添加");
		}
	}
}

function SetHome(obj,vrl)
{
	try
	{
		obj.style.behavior='url(#default#homepage)';obj.setHomePage(vrl);
	}
	catch(e)
	{
		if(window.netscape)
		{
			try
			{
				netscape.security.PrivilegeManager.enablePrivilege("UniversalXPConnect");
			}
			catch (e)
			{
				alert("此操作被浏览器拒绝！\n请在浏览器地址栏输入“about:config”并回车\n然后将 [signed.applets.codebase_principal_support]的值设置为'true',双击即可。");
			}
			var prefs = Components.classes['@mozilla.org/preferences-service;1'].getService(Components.interfaces.nsIPrefBranch);
			prefs.setCharPref('browser.startup.homepage',vrl);
		}
	}
}

function ChangeCkeckNo()
{   
  document.getElementById("Image1").src="/ValidateNumber.aspx?d="+Math.random();
}

function isEmail(id)
{
	var strEmail=$("#"+id).val();

	if(strEmail.length!=0)
	{
		if (strEmail.charAt(0)=="." ||
		        strEmail.charAt(0)=="@"||
		        strEmail.indexOf('@', 0) == -1 ||
		        strEmail.indexOf('.', 0) == -1 ||
		        strEmail.lastIndexOf("@")==strEmail.length-1 ||
		        strEmail.lastIndexOf(".")==strEmail.length-1)
		{
			alert("Email的格式不正确！");
			$("#"+id).focus();
			return false;
		}
		return true;
	}
	else
	{
		alert("Email的不能为空！");
		$("#"+id).focus();
		return false;
	}
	return false;
}
//********************Login**********************
function login(){
    var uid= $("#txtUID").val();
    var pwd= $("#txtPWD").val();
    var chk= $("#txtChk").val();
    $.post("/ajax/LoginOut.ashx",
        {username:uid,password:pwd,act:"in",chkNo:chk,r:Math.random()},
        function(data){
            if(data && data=="True"){
                $("#spanLogin").html(" | 已登录，"+uid);
                $("#spanLogin").css("display","inline");
            }
            else{
                alert("登录失败:"+data);
            }
        });
}

//******************Register*********************
function ChangeInputColor(obj, i)
{
	if (i == 1)//û ý  
	{
		obj.style.backgroundColor = "#99CC99";
	}
	else if (i == 0)//  ˳ 
	{
		obj.style.backgroundColor = "#FFFFFF";
	}

}

var _reg={
	valUserName:false,
	valPwd:false,
	valPwdConfirm:false,
	valEmail:false,
	valCheckNo:false,
	ico_ok:"<img src='/img/ico_ok.gif' />",
	ico_no:"<img src='/img/ico_no.gif' />"
}

function checkUserName()
{
$.post("/Ajax/RegCheck.ashx", { act: "userid", userid: $("#txtUserName").val(), dd: Math.random() },
	       function(data)
	       {
		       if (data == "True")
		       {
				   _reg.valUserName = true;
			       $("#txtUserName+span").html(_reg.ico_ok);
		       }
		       else
		       {
			       _reg.valUserName = false;
			       $("#txtUserName+span").html(_reg.ico_no);
		       }
	       }
	      );
}
function checkPwd()
{
	if ($("#txtPwd").val().length > 5)
	{
		_reg.valPwd = true;
		$("#txtPwd+span").html(_reg.ico_ok);
	}
	else
	{
		_reg.valPwd = false;
		$("#txtPwd+span").html(_reg.ico_no);
	}
}

function checkPwdConfirm()
{
	if ($("#txtPwd").val() == $("#txtPwdConfirm").val())
	{
		_reg.valPwdConfirm = true;
		$("#txtPwdConfirm+span").html(_reg.ico_ok);
	}
	else
	{
		_reg.valPwdConfirm = false;
		$("#txtPwdConfirm+span").html(_reg.ico_no);
	}
}

function checkEmail()
{
	if(!isEmail('txtEmail'))
	{
		_reg.valEmail = false;
		$("#txtEmail+span").html(_reg.ico_no);
		return false;
	}
$.post("/Ajax/RegCheck.ashx", { act: "email", email: $("#txtEmail").val(), dd: Math.random() },
	       function(data)
	       {
		       if (data == "True")
		       {
			       _reg.valEmail = true;
			       $("#txtEmail+span").html(_reg.ico_ok);
		       }
		       else
		       {
			       _reg.valEmail = false;
			       $("#txtEmail+span").html(_reg.ico_no);
		       }
	       }
	      );
}

function checkCheckNo()
{
$.post("/Ajax/RegCheck.ashx", { act: "checkno", checkno: $("#txtCheckNo").val(), dd: Math.random() },
	       function(data)
	       {
		       if (data == "True")
		       {
			       _reg.valCheckNo = true;
			       $("#txtCheckNo+span").html(_reg.ico_ok);
		       }
		       else
		       {
			       _reg.valCheckNo = false;
			       $("#txtCheckNo+span").html(_reg.ico_no);
		       }
	       }
	      );
}

function AddUser()
{
	if (_reg.valCheckNo && _reg.valEmail && _reg.valPwd && _reg.valUserName && _reg.valPwdConfirm)
	{
$.post("/Ajax/regUser.ashx", { email:  $("#txtEmail").val(), username: $("#txtUserName").val(), password: $("#txtPwd").val(), dd: Math.random() },
		       function(data)
		       {
			       if (data == "True")
			       {
				       alert("注册成功，请登录");
				       document.location = "/";
			       }
			       else
			       {
				       alert("注册失败");
			       }
		       }
		      );
	}
	else
	{
		alert("填写信息有误");
	}
}

/*图片展示插件*/
