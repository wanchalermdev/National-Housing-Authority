using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Test.Data;

namespace Test.AdminNHA
{
    public partial class AddDocs : System.Web.UI.Page
    {
        static NHADATABASEEntities1 db = new NHADATABASEEntities1();
        protected void Page_Load(object sender, EventArgs e)
        {
            ViewState["project_id"] = Request.QueryString["pid"];
            ViewState["period"] = Request.QueryString["pr"];
            loadTableDoc();
        }

        private void loadTableDoc()
        {
            int pid = Int32.Parse(ViewState["project_id"].ToString());
            string pr = ViewState["period"].ToString();
            gvDoc.DataSource = db.Project_Document_Select(pid,pr);
            gvDoc.DataBind();
        }

        protected void btnAdd_Click(object sender, EventArgs e)
        {
            if (Page.IsValid)
            {
                int pid = Int32.Parse(ViewState["project_id"].ToString());
                string docName = nameDoc.Text.ToString();
                string type = DocType.Text.ToString();
                string num = numDoc.Text.ToString();
                string pr = ViewState["period"].ToString();
                db.Project_Document_Insert(pid, docName, type, num, pr);
                loadTableDoc();
            }
         
        }

        protected void gvDoc_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            string str = e.CommandName.ToString();
            string pr = ViewState["period"].ToString();
            int id = Int32.Parse(ViewState["project_id"].ToString());

            int index = (Convert.ToInt32(e.CommandArgument));
            GridViewRow row = gvDoc.Rows[index];
            string docname = row.Cells[0].Text;

            if (str == "delete")
            {
                db.Project_Document_Delete(id, docname, pr);
                Page.Response.Redirect(Page.Request.Url.ToString(), true);
            }
        }

        protected void ButtonBack_Click(object sender, EventArgs e)
        {
            Response.Redirect("AddResearcher.aspx?id=" + ViewState["project_id"].ToString());
        }
    }
}