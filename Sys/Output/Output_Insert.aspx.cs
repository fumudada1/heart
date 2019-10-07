using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using TIN;

public partial class Sys_Output_Output_Insert : System.Web.UI.Page
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

    }
    protected void InsertButton_Click(object sender, EventArgs e)
    {
        EasyDataProvide OutputDate = new EasyDataProvide("OutputDate");
        OutputDate.SetPlaceHolderFormQuest();

        OutputDate.Insert();
        Response.Redirect("Output_list.aspx?ModuleID=" + Request["ModuleID"]);
    }
}