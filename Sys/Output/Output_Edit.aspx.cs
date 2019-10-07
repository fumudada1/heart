using System;
using System.Collections.Generic;
using System.Data;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using TIN;

public partial class Sys_Output_Output_Edit : System.Web.UI.Page
{
    DataLayer dl = new DataLayer();

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


            show();


        }
    }

    private void show()
    {
        EasyDataProvide OutputDate = new EasyDataProvide("OutputDate");
        DataRow row = OutputDate.FillPlaceHolderControlsById(Request["ID"]);
        coco.Text = Convert.ToDecimal(row["coco"].ToString()).ToString("0");

    }


    protected void UpdateButton_Click1(object sender, EventArgs e)
    {
        EasyDataProvide OutputDate = new EasyDataProvide("OutputDate");
        OutputDate.SetPlaceHolderFormQuest();
        OutputDate.UpdateById(Request["ID"]);
        Response.Redirect("Output_list.aspx?ModuleID=" + Request["ModuleID"]);
    }
}