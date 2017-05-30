using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Test.Data;

namespace Test.AdminNHA
{
    public partial class Accept : System.Web.UI.Page
    {
        NHADATABASEEntities1 db = new NHADATABASEEntities1();

        protected void Page_Load(object sender, EventArgs e)
        {

            if (!IsPostBack)
            {
                ViewState["project_id"] = HttpUtility.UrlDecode(Request.QueryString["id"]);
            }
            LoadData();
            
        }

        private void LoadData()
        {

            var data = db.Select_Project(Int32.Parse(ViewState["project_id"].ToString()));
            foreach (var item in data)
            {
                string project_id = "P" + item.year.ToString().Substring(2) + getStringProjectId(Int32.Parse(item.project_id.ToString()));
                pid.Text = project_id;
                pname.Text = item.project_name;
                pyear.Text = item.year.ToString();
                pbg.Text = item.project_budget.ToString();
                py.Text = item.year.ToString();
                pbg2.Text = item.project_budget.ToString();
            }
        }

        private static string getStringProjectId(int pid)
        {
            if (pid < 10)
            {
                return "000" + pid;
            }
            else if (pid < 100)
            {
                return "00" + pid;
            }
            else if (pid < 1000)
            {
                return "0" + pid;
            }
            return pid.ToString();
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            int user_id = Int32.Parse(Session["USER"].ToString());
            int project_id = Int32.Parse(ViewState["project_id"].ToString());
            db.Update_Project_State(user_id, project_id, 2);
            ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "showModal();", true);
        }
    }
}