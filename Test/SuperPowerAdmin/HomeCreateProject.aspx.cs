using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Test.SuperPowerAdmin
{
    public partial class HomeCreateProject : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void ButtonCreate_Click(object sender, EventArgs e)
        {
            Response.Redirect("CreateBudget.aspx");
        }

        protected void ButtonEditForm_Click(object sender, EventArgs e)
        {
            Response.Redirect("EditForm.aspx");
        }

        protected void ButtonPrint_Click(object sender, EventArgs e)
        {
            Response.Redirect("PrintDoc.aspx");
        }

        protected void ButtonFillData_Click(object sender, EventArgs e)
        {
            Response.Redirect("FillProjectData.aspx");
        }

    }
}