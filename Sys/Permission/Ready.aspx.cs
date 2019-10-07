using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class manage_A01Permission_Ready : System.Web.UI.Page
{
    protected void Page_Init(object sender, EventArgs e)
    {
        HiddenField FunctionNumber = (HiddenField)Master.FindControl("FunctionNumber");
        FunctionNumber.Value = "";
    }

    protected void Page_Load(object sender, EventArgs e)
    {

    }
}