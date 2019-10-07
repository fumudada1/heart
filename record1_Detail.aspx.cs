using System;
using System.Collections.Generic;
using System.Data;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using TIN;

public partial class record1_Detail : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            Show();

        }
    }

    private void Show()
    {
        TIN.EasyDataProvide OutputDate = new EasyDataProvide("OutputDate");
        DataRow row= OutputDate.FillPlaceHolderControlsById(Request["id"]);
        coco.Text =Convert.ToInt16(row["coco"]) .ToString("C0");
    }
}