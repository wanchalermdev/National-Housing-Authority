using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Test.Data;

namespace Test.AdminNHA
{
    public partial class SetPermissionsDocument : System.Web.UI.Page
    {
        static NHADATABASEEntities1 db = new NHADATABASEEntities1();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                ViewState["project_id"] = Request.QueryString["id"];
                int project_id = Int32.Parse(ViewState["project_id"].ToString());
                string abs = "";
                try
                {
                    var query = db.Project_SelectAbstract(project_id);
                    foreach (var item in query)
                    {
                        abs = item.@abstract;
                    }
                    LabelAbstract.Text = abs;
                }
                catch { }
                loadGridview();
            }

        }
        private void loadGridview()
        {
            int id = Int32.Parse(ViewState["project_id"].ToString());
            gridview.DataSource = db.ProjectPublishFileUpload_Select(id);
            gridview.DataBind();
        }

        protected void gridview_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            int rowIndex = Convert.ToInt32(e.CommandArgument);
            string str = e.CommandName.ToString();
            int id = Int32.Parse(ViewState["project_id"].ToString());
            int file_id = (int)gridview.DataKeys[rowIndex].Values[0];
            var query = db.ProjectPublishFileUpload_SelectDownload(file_id);
            string filename = "";
            string name = "";
            foreach (var item in query)
            {
                filename = item.filename;
                name = item.nameFomTextBox;
            }

            string[] split = filename.Split('.');
            if (str == "download")
            {
                Response.ContentType = "Application/doc";
                Response.AppendHeader("Content-Disposition", "attachment; filename=" + name + '.' + split[1]);
                Response.TransmitFile(Server.MapPath("~/fileUpload/" + split[0] + '.' + split[1]));
                Response.End();
            }
        }

        protected void gridview_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            string cities = "เผยแพร่สาธารณะ,เฉพาะเจ้าหน้าที่";
            string[] arr = cities.Split(',');
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                DropDownList ddl = (DropDownList)e.Row.FindControl("DrdDatabase");
                foreach (string colName in arr)
                    ddl.Items.Add(new ListItem(colName));

            }
        }

        protected void gridview_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void DrdDatabase_SelectedIndexChanged(object sender, EventArgs e)
        {
            int project_id = Int32.Parse(ViewState["project_id"].ToString());
            DropDownList ddl = (DropDownList)sender;
            GridViewRow row = (GridViewRow)ddl.Parent.Parent;
            int idx = row.RowIndex;
            string recevId = gridview.DataKeys[idx].Values[0].ToString();
            int rid = Int32.Parse(recevId);
            string status = ddl.SelectedItem.Text.ToString();
            db.ProjectPublishFilePermission_Update(project_id, rid, status);

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            Response.Redirect("ViewStateProcess.aspx");
        }
    }
}