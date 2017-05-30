using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Test.Data;

namespace Test.ProjectManager
{
    public partial class PMIndex : System.Web.UI.Page
    {
        NHADATABASEEntities1 db = new NHADATABASEEntities1();
        protected void Page_Load(object sender, EventArgs e)
        {
            LoadData();
        }

        private void LoadData()
        {
            int user_id = Int32.Parse(Session["USER"].ToString());
            gvProject.DataSource = db.PM_Select_Project(user_id);
            gvProject.DataBind();
        }

        protected void back_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/AdminNHA/ViewStateProcess.aspx");
        }
    }
}