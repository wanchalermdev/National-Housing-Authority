using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;
using Test.Data;
namespace Test.AdminNHA
{
    public partial class AddTOR : System.Web.UI.Page
    {
        NHADATABASEEntities1 db = new NHADATABASEEntities1();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                ViewState["project_id"] = Request.QueryString["id"];
            }
        }

        protected void save_Click(object sender, EventArgs e)
        {
            if (Page.IsValid)
            {
                string number = TextBox1.Text.ToString();
                string topic = TextBox2.Text.ToString();
                string date = TextBox3.Text.ToString();
                string detail = TextBox4.Text.ToString();
                int projectid = Int32.Parse(ViewState["project_id"].ToString());
                int user_id = Int32.Parse(Session["USER"].ToString());
                Upload();
                db.Upload_TOR_History(user_id, projectid, number, topic, date, detail);
                db.Update_Project_State(user_id, projectid, 5);
                Response.Redirect("/AdminNHA/ApproveRecord.aspx?id=" + ViewState["project_id"].ToString());
            }
            

        }

        protected void cancel_Click(object sender, EventArgs e)
        {
            Response.Redirect("/AdminNHA/ApproveRecord.aspx?id=" + ViewState["project_id"].ToString());
        }

        private void Upload()
        {
            string filename = Path.GetFileName(FileUpload.PostedFile.FileName);
            string contentType = FileUpload.PostedFile.ContentType;
            using (Stream fs = FileUpload.PostedFile.InputStream)
            {
                using (BinaryReader br = new BinaryReader(fs))
                {
                    byte[] bytes = br.ReadBytes((Int32)fs.Length);
                    db.UploadFile(Int32.Parse(Session["USER"].ToString()), Int32.Parse(ViewState["project_id"].ToString()), filename, contentType, bytes, 5);
                    
                }
            }
        }
    }
}