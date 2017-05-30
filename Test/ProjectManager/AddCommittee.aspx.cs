using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Test.Data;
using System.Web.Services;

namespace Test.ProjectManager
{
    public partial class AddCommittee : System.Web.UI.Page
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

        protected void save_Click(object sender, EventArgs e)
        {
            // Do something
            int user_id = Int32.Parse(Session["USER"].ToString());
            int project_id = Int32.Parse(ViewState["project_id"].ToString());
            db.Update_Project_State(user_id, project_id, 3);
            Response.Redirect("~/AdminNHA/ViewStateProcess.aspx");
        }

        [WebMethod]
        public static string[] GetCommittees(string prefix)
        {
            List<string> users = new List<string>();
            using(NHADATABASEEntities1 db = new NHADATABASEEntities1())
            {
                var data = db.SP_SuperPowerAdmin_SearchUser(prefix);
                foreach (var item in data)
                {
                    users.Add(string.Format("{0}-{1}-{2}-{3}", item.pname, item.first_name, item.last_name, item.user_id));
                }
            }
            return users.ToArray();
        }

        private void LoadData()
        {
            int id = Int32.Parse(ViewState["project_id"].ToString());
            tablePC.DataSource = db.Committee_Select_check(id);
            tablePM.DataSource = db.Committee_Select_employ(id);
            tablePM.DataBind();
            tablePC.DataBind();
        }


        protected void btnAdd_Click(object sender, EventArgs e)
        {
            if (Page.IsValid)
            {
                if (CommiteeType.SelectedItem.Value.ToString() != "0")
                {
                    try
                    {
                        int posion_id = Int32.Parse(hfUserId.Value.ToString());
                        string commitee_position = "";
                        string type2 = "";
                        if (CommiteeType.SelectedItem.Value == "ประธานกรรมการจัดจ้าง")
                        {
                            commitee_position = "ประธานกรรมการ";
                            type2 = "กรรมการจัดจ้าง";
                        }
                        else if (CommiteeType.SelectedItem.Value == "ประธานกรรมการตรวจการจ้าง")
                        {
                            commitee_position = "ประธานกรรมการ";
                            type2 = "กรรมการตรวจการจ้าง";
                        }
                        else if (CommiteeType.SelectedItem.Value == "กรรมการจัดจ้าง")
                        {
                            commitee_position = "กรรมการ";
                            type2 = "กรรมการจัดจ้าง";
                        }
                        else if (CommiteeType.SelectedItem.Value == "กรรมการตรวจการจ้าง")
                        {
                            commitee_position = "กรรมการ";
                            type2 = "กรรมการตรวจการจ้าง";
                        }
                        else if (CommiteeType.SelectedItem.Value == "เลขานุการกรรมการจัดจ้าง")
                        {
                            commitee_position = "เลขานุการ";
                            type2 = "กรรมการจัดจ้าง";
                        }
                        else if (CommiteeType.SelectedItem.Value == "เลขานุการกรรมการตรวจการจ้าง")
                        {
                            commitee_position = "เลขานุการ";
                            type2 = "กรรมการตรวจการจ้าง";
                        }
                        int id = Int32.Parse(ViewState["project_id"].ToString());
                        int user_id = Int32.Parse(hfUserId.Value.ToString());

                        db.Committee_insert(id, user_id, commitee_position, type2);
                        LoadData();
                    }
                    catch { }
                }
               
            }

         
        }

        protected void tablePC_SelectedIndexChanged(object sender, EventArgs e)
        {
            GridViewRow row = tablePC.SelectedRow;
            int id = Int32.Parse(ViewState["project_id"].ToString());
            int uid = (int)tablePC.DataKeys[row.RowIndex].Value;
            db.Committee_Delete(id, uid);
            Page.Response.Redirect(Page.Request.Url.ToString(), true);
        }

        protected void tablePM_SelectedIndexChanged(object sender, EventArgs e)
        {
            GridViewRow row = tablePM.SelectedRow;
            int id = Int32.Parse(ViewState["project_id"].ToString());
            int uid = (int)tablePM.DataKeys[row.RowIndex].Value;
            db.Committee_Delete(id, uid);
            Page.Response.Redirect(Page.Request.Url.ToString(), true);
        }
    }
}