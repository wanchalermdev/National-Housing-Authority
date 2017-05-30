using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Test.Data;

namespace Test.AdminNHA
{
    public partial class WriteAbstact : System.Web.UI.Page
    {
        static NHADATABASEEntities1 db = new NHADATABASEEntities1();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                ViewState["project_id"] = Request.QueryString["id"];
                var data = db.Project_SelectAbstract(Int32.Parse(ViewState["project_id"].ToString()));
                try
                {
                    foreach (var item in data.ToList())
                    {
                        TextBoxForm.Text = item.@abstract.ToString();
                    }
                }
                catch { }
            }
        }

        protected void MainContent_BtnSave_Click(object sender, EventArgs e)
        {
            ViewState["project_id"] = Request.QueryString["id"];
                try
                {
                    var data = db.Project_abstract(Int32.Parse(ViewState["project_id"].ToString()), TextBoxForm.Text.ToString());
                }
                catch { }
        }

        protected void MainContent_BtnBack_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/AdminNHA/ViewStateProcess.aspx");
        }


    }
}