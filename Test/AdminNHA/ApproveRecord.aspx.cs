using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Test.Data;
namespace Test.AdminNHA
{
    public partial class ApproveRecord : System.Web.UI.Page
    {
        NHADATABASEEntities1 db = new NHADATABASEEntities1();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                ViewState["project_id"] = Request.QueryString["id"];
            }
            LoadData();
        }

        protected void BtnClick_Click(object sender, EventArgs e)
        {
            Response.Redirect("AddTOR.aspx?id="+ ViewState["project_id"].ToString());
        }

        private void LoadData()
        {
            var data = db.Get_TOR_Approve(Int32.Parse(ViewState["project_id"].ToString()));
            tableDoc.DataSource = data;
            tableDoc.DataBind();
        }
    }
}