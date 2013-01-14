using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;

public partial class ALogin : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Request.QueryString["act"] != null)
        {
            if (Request.QueryString["act"].ToString() == "out")
            {
                Logout();
            }
        }
    }
    protected void btn_login_Click(object sender, EventArgs e)
    {
        string webUid = ConfigurationManager.AppSettings["uid"].ToString();
        string webPwd = ConfigurationManager.AppSettings["pwd"].ToString();
        if (txtUid.Text == webUid && txtPwd.Text == webPwd)
        {
            //“通知”表单验证，该用户名已经通过身份验证
            FormsAuthentication.RedirectFromLoginPage(txtUid.Text, true);
        }
        else
        {
            Mxm.Common.MessageBox.Show(this, "账号或密码有误，登录失败!");
        }
    }

    private void Logout()
    {
        //删除用户票据
        FormsAuthentication.SignOut();

        //重新定向到登陆页面
        //FormsAuthentication.RedirectToLoginPage();
        Response.Redirect("/ALogin.aspx");
    }
}
