using System;
using System.Collections.Generic;
using System.Data;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using TIN;

public partial class manage_News_News_Pictures : System.Web.UI.Page
{
    #region "將目前功能資料送到Master Page裡"
    protected void Page_Init(object sender, EventArgs e)
    {
        HiddenField FunctionNumber = (HiddenField)Master.FindControl("FunctionNumber");
        FunctionNumber.Value = Request["ModuleID"];
    }
    #endregion

    private readonly EasyDataProvide _ModulePictures = new EasyDataProvide("ModulePictures");

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            show();
            EasyDataProvide ModulePublish = new EasyDataProvide("ModulePublish");
            DataRow row = ModulePublish.GetById(Request["ID"].ToString());
            //if (!DataLayer.IsInRole("admins", User.Identity.Name))
            //{
            //    if (row["beSelect"].ToString() != "0") //不是自己發佈的
            //    {
            //        btnSure.Visible = false;
            //    }
            //}
        }
    }

    private void show()
    {
        _ModulePictures.AddParameter("publishID", Request["ID"].ToString());
        DataTable dt = _ModulePictures.GetData("publishID=@publishID", "order by listNum asc");
        gvList.DataSource = dt;
        gvList.DataBind();
    }

    protected void gvList_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            e.Row.Cells[4].Attributes.Add("onclick",
                                          "javascript:if(!window.confirm('你確定要刪除嗎?')) return false;");
            string picID = gvList.DataKeys[e.Row.RowIndex].Value.ToString();
            HyperLink lnkEdit = (HyperLink)e.Row.FindControl("lnkEdit");
            lnkEdit.NavigateUrl =
                String.Format(
                    "_News_Pictures_Edit.aspx?publishID={0}&ModuleID={1}&ID={2}&KeepThis=true&TB_iframe=true&height=400&width=600",
                    Request["ID"], Request["ModuleID"], picID);
        }
    }

    protected void gvList_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        string picID = gvList.DataKeys[e.RowIndex].Value.ToString();
        _ModulePictures.DeleteById(picID);
        show();
    }

    protected void btnSure_Click(object sender, EventArgs e)
    {
        foreach (GridViewRow row in gvList.Rows)
        {
            string id = Convert.ToString(gvList.DataKeys[row.RowIndex].Value);
            TextBox listNum = (TextBox)row.FindControl("listNum");
            _ModulePictures.AddParameter("listNum", listNum.Text);
            _ModulePictures.UpdateById(id);
        }
        show();
    }
}