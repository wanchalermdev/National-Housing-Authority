using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;
using Test.Data;

namespace Test.SuperPowerAdmin
{
    public partial class committee : System.Web.UI.Page
    {
        NHADATABASEEntities1 db = new NHADATABASEEntities1();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {               
                ViewState["project_id"] = Request.QueryString["id"];
                ViewState["project_name"] = Request.QueryString["name"];
                Pname.Text = ViewState["project_name"].ToString();
            }

            LoadData();
        }
        [WebMethod]
        public static string[] GetUsers(string prefix)
        {
            List<string> users = new List<string>();
            using (NHADATABASEEntities1 db = new NHADATABASEEntities1())
            {
                var data = db.SP_SuperPowerAdmin_SearchUser(prefix);
                foreach (var item in data)
                {
                    users.Add(string.Format("{0}-{1}-{2}-{3}", item.pname,item.first_name,item.last_name, item.user_id));
                }

            }
            return users.ToArray();
        }

        private void LoadData()
        {
            using (NHADATABASEEntities1 db = new NHADATABASEEntities1())
            {
                int id = Int32.Parse(ViewState["project_id"].ToString());
                gvCoor.DataSource = db.SelectCommit_NHA(id);
                gvPM.DataSource = db.SelectCommit_PM(id);
                gvCoor.DataBind();
                gvPM.DataBind();
            }
        }

    

        protected void btnAdd_Click(object sender, EventArgs e)
        {
            int user_id = Int32.Parse(hfUserId.Value.ToString());
            string type = CommiteeType.SelectedItem.Value;
            db.ProjectCharacter_Create(Int32.Parse(ViewState["project_id"].ToString()), user_id, type);
            LoadData();
        }

        protected void BtnSave_Click(object sender, EventArgs e)
        {

            db.Update_Project_State(Int32.Parse(Session["USER"].ToString()), Int32.Parse(ViewState["project_id"].ToString()), 1);
            Response.Redirect("HomeCreateProject.aspx");
        }

        protected void gvCoor_SelectedIndexChanged(object sender, EventArgs e)
        {
            GridViewRow row = gvCoor.SelectedRow;
            int id = Int32.Parse(ViewState["project_id"].ToString());
            int uid = (int)gvCoor.DataKeys[row.RowIndex].Value;
            db.ProjectCharacter_Delete(id, uid);
            Page.Response.Redirect(Page.Request.Url.ToString(), true);
        }

        protected void gvPM_SelectedIndexChanged(object sender, EventArgs e)
        {
            GridViewRow row = gvPM.SelectedRow;
            int id = Int32.Parse(ViewState["project_id"].ToString());
            int uid = (int)gvPM.DataKeys[row.RowIndex].Value;
            db.ProjectCharacter_Delete(id, uid);
            Page.Response.Redirect(Page.Request.Url.ToString(), true);
        }

    }

  
}