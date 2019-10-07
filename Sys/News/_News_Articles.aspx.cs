using System;
using System.Collections.Generic;
using System.Data;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using TIN;

public partial class manage_News_News_Articles : System.Web.UI.Page
{
    #region "�N�ثe�\���ưe��Master Page��"
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
            EasyDataProvide ModulePublish = new EasyDataProvide("ModulePublish");
            DataRow row = ModulePublish.GetById(Request["ID"]);
            ViewState["title"] = row["title"];
            //if (!DataLayer.IsInRole("admins", User.Identity.Name))
            //{
            //    if (row["beSelect"].ToString() != "0") //���O�ۤv�o�G��
            //    {
            //        btnSure.Visible = false;
            //    }

            //}
        }
    }

    private void show()
    {
        EasyDataProvide ModuleContents = new EasyDataProvide("ModuleContents");
        ModuleContents.AddParameter("publishID", Request["ID"]);
        DataTable dt = ModuleContents.GetData("publishID=@publishID and type=1","order by initDate desc");
        repReply.DataSource = dt;
        repReply.DataBind();
    }

    protected void repReply_ItemCommand(object source, RepeaterCommandEventArgs e)
    {
        if(e.CommandName=="Delete")
        {
            HiddenField hidID = (HiddenField) e.Item.FindControl("hidID");
            EasyDataProvide ModuleContents = new EasyDataProvide("ModuleContents");
            ModuleContents.DeleteById(hidID.Value);

        }
        show();
    }
}