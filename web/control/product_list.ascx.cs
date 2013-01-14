using System;
using System.Data;
using System.Configuration;
using System.Collections.Generic;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;

public partial class control_product_list : System.Web.UI.UserControl
{
    Mxm.DAL.production prodMgr = new Mxm.DAL.production();
    Mxm.DAL.product_type typeMgr = new Mxm.DAL.product_type();
    protected void Page_Load(object sender, EventArgs e)
    {
        string resVal = "";
        try
        {
            List<Mxm.Model.product_type> lst = typeMgr.GetListArray("parent_id=0");
            foreach (Mxm.Model.product_type mo in lst)
            {
                resVal += string.Format("<li><div class='nav1'>{0}</div><div><ul class='nav3'>{1}</ul></div></li>",
                    mo.type_name, GetTypeLst(mo.type_id));
            }
            nav_current.InnerHtml = resVal;
        }
        catch(Exception ex)
        {
            Mxm.Common.WriteError.WriteTxt(ex.Message + ex.StackTrace);
        }
    }

    /// <summary>
    /// 取小类列表
    /// </summary>
    /// <param name="pare_id"></param>
    /// <returns></returns>
    private string GetTypeLst(int pare_id)
    {
        string resVal = "";
        try
        {
            List<Mxm.Model.product_type> lst = typeMgr.GetListArray("parent_id=" + pare_id);
            foreach (Mxm.Model.product_type mo in lst)
            {
                //resVal += string.Format("<li><div class='nav2'>{0}</div><div><ul class='nav3'>{1}</ul></div></li>",
                //    mo.type_name, GetProdLst(mo.type_id));
                resVal += string.Format("<li><a href='/productlist.aspx?type={0}' target='_self'>{1}</a></li>",
                    mo.type_id,mo.type_name);
            }
            nav_current.InnerHtml = resVal;
        }
        catch (Exception ex)
        {
            Mxm.Common.WriteError.WriteTxt(ex.Message + ex.StackTrace);
        }
        return resVal;
    }

    /// <summary>
    /// 取产品列表
    /// </summary>
    /// <param name="type"></param>
    /// <returns></returns>
    private string GetProdLst(int type)
    {
        string resVal = "";
        try
        {
            List<Mxm.Model.production> lst = prodMgr.GetListArray("product_type=" + type);
            for (int i = 0; i < lst.Count; i++)
            {
                if (i != lst.Count - 1)
                {
                    resVal += string.Format("<li><a href='productview.aspx?pid={0}'>{1}</a></li>",
                        lst[i].pid, lst[i].product_name);
                }
                else
                {
                    resVal += string.Format("<li><a class='nav4' href='productview.aspx?pid={0}'>{1}</a></li>",
                        lst[i].pid, lst[i].product_name);
                }
            }
        }
        catch (Exception ex)
        {
            Mxm.Common.WriteError.WriteTxt(ex.Message + ex.StackTrace);
        }        
        return resVal;
    }
}
