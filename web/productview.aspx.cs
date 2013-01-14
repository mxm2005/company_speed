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

public partial class productview : System.Web.UI.Page
{
    int _pid = 0;
    protected string _video = "";
    Mxm.DAL.production prodMgr = new Mxm.DAL.production();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Request.QueryString["pid"] != null)
        {
            _pid = int.Parse(Request.QueryString["pid"].ToString());
        }
        ShowProduct();
    }

    private void ShowProduct()
    {
        if (_pid <= 0)
        {
            return;
        }
        Mxm.Model.production mo = prodMgr.GetModel(_pid);
        string picPath = ConfigurationManager.AppSettings["imgPath"].ToString();
        if (mo != null)
        {
            lbl_name.Text = mo.product_name;
            lbl_model.Text = mo.model;
            divDesc.InnerHtml = mo.product_desc;
            divImg.InnerHtml = string.Format("<table style=\"width:338px;height:338px;vertical-align:middle;text-align:center;\"><tr><td><a href='{0}' title='{1}' rel='lightbox' target='_blank'><img style='max-width:335px;max-height:335px;' src='{2}' title='{3}' border='0' /></a></td></tr></table>",
               picPath + mo.picture, mo.product_name, picPath + mo.picture, mo.product_name);
            //spanLink.InnerHtml = string.Format("<a href='{0}' target='_blank'><img src='/images/pic.jpg'></a>", picPath + mo.picture);
            _video = ConfigurationManager.AppSettings["vidioPath"].ToString()+mo.vidio;

            ShowPreNext(mo.product_type);
            SetNavTitle(mo.product_type, mo.product_name);

            //ShowVidio(mo.pid);
        }
    }

    private void SetNavTitle(int type,string name)
    {
        Mxm.Model.product_type mo = new Mxm.DAL.product_type().GetModel(type);
        if (mo != null)
        {
            lbl_nav.Text = " - <a href='productlist.aspx?type=" + type + "'>" + mo.type_name +
                "</a> - " + name;
            if (!string.IsNullOrEmpty(mo.banner))
            {
                topBanner.Src = ConfigurationManager.AppSettings["imgPath"] + mo.banner;
            }
            else
            {
                topBanner.Style.Add("display", "none");
            }
        }
        Title = name + ConfigurationManager.AppSettings["title"];
    }

    /// <summary>
    /// 展示上一篇、下一篇
    /// </summary>
    private void ShowPreNext(int type_id)
    {
        //上一篇
        Mxm.Model.production mo = null;
        try
        {
            mo = prodMgr.GetNextModel(_pid, 1, "product_type=" + type_id);
        }
        catch (Exception ex)
        {
            Session["ex"] = ex;
            Response.Redirect("exception.aspx", true);
        }
        if (mo != null)
        {
            divPrev.InnerHtml = "上一篇：<a class='a-link' href=\"productview.aspx?pid=" + mo.pid + "\">" +
                mo.product_name + "</a>";
        }
        else
        {
            divPrev.InnerHtml = "上一篇：暂无";
        }
        //下一篇
        mo = null;
        try
        {
            mo = prodMgr.GetNextModel(_pid, 0, "product_type=" + type_id);
        }
        catch (Exception ex)
        {
            Session["ex"] = ex;
            Response.Redirect("exception.aspx", true);
        }
        if (mo != null)
        {
            divNext.InnerHtml = "下一篇：<a class='a-link' href=\"productview.aspx?pid=" + mo.pid + "\">" +
                mo.product_name + "</a>";
        }
        else
        {
            divNext.InnerHtml += "下一篇：暂无";
        }
    }

    ///// <summary>
    ///// 显示视频附件，如果有
    ///// </summary>
    ///// <param name="pid"></param>
    //private void ShowVidio(int pid)
    //{
    //    DataSet ds = (new Mxm.DAL.attachment()).GetList("depositor_id=" + pid +
    //        " and depositor_type=" + (int)Mxm.Model.attachment.DepositorType.Production);
    //    if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
    //    {
    //        _video = ds.Tables[0].Rows[0]["path"].ToString();
    //    }
    //}
}
