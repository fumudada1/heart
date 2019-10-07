using System;
using System.Collections.Generic;
using System.Data;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using TIN;

public partial class Sys_Unit_Unit_list : System.Web.UI.Page
{

    #region "將目前功能資料送到Master Page裡"

    protected void Page_Init(object sender, EventArgs e)
    {
        HiddenField FunctionNumber = (HiddenField)Master.FindControl("FunctionNumber");
        FunctionNumber.Value = Request["ModuleID"];
    }

    #endregion

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            string ModuleID = Request["ModuleID"];

           

            Show();
        }
    }

    private void Show()
    {
        TIN.EasyDataProvide UnitName = new EasyDataProvide("UnitName");
        DataTable dt = UnitName.GetAllData();
        gvList.DataSource = dt;
        gvList.DataBind();

    }

    protected void gvList_RowUpdating(object sender, GridViewUpdateEventArgs e)
    {
        string strID = gvList.DataKeys[e.RowIndex].Value.ToString();
        string page = Request["page"] ?? "1";
        Response.Redirect("Unit_Edit.aspx?ID=" + strID + "&ModuleID=" + Request["ModuleID"]);
    }
  
}