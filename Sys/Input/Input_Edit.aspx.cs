using System;
using System.Collections.Generic;
using System.Data;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using TIN;

public partial class Sys_Input_Input_Edit : System.Web.UI.Page
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
        EasyDataProvide InputData = new EasyDataProvide("InputData");
        DataRow row = InputData.FillPlaceHolderControlsById(Request["ID"]);
        if(row==null) return;
        lblaliasName.Text = row["aliasName"].ToString();
        coco.Text = Convert.ToDouble(row["coco"]).ToString("0");

    }

    protected void UpdateButton_Click(object sender, EventArgs e)
    {
        EasyDataProvide InputData = new EasyDataProvide("InputData");
        InputData.SetPlaceHolderFormQuest();
        InputData.UpdateById(Request["ID"]);
        Response.Redirect("Input_list.aspx?ModuleID=" + Request["ModuleID"]);
    }
}