using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using TIN;

public partial class Sys_Unit_Unit_Edit : System.Web.UI.Page
{
    #region "將目前功能資料送到Master Page裡"

    protected void Page_Init(object sender, EventArgs e)
    {
        HiddenField FunctionNumber = (HiddenField)Master.FindControl("FunctionNumber");
        FunctionNumber.Value = Request["ModuleID"];
    }

    #endregion

    TIN.EasyDataProvide _UnitName = new EasyDataProvide("UnitName");
    protected void Page_Load(object sender, EventArgs e)
    {
        if(!Page.IsPostBack)
        {
            Show();
        }
    }

    private void Show()
    {
        if (Request != null) _UnitName.FillPlaceHolderControlsById(Request["id"].ToString());
    }

    protected void UpdateButton_Click(object sender, EventArgs e)
    {
        
        _UnitName.SetPlaceHolderFormQuest();
        _UnitName.UpdateById(Request["id"].ToString());
        Response.Redirect("Unit_list.aspx?ModuleID=" + Request["ModuleID"]);
    }
}