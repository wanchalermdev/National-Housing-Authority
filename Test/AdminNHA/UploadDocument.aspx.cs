using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Test.Data;

namespace Test.AdminNHA
{
    public partial class UploadDocument : System.Web.UI.Page
    {
        NHADATABASEEntities1 db = new NHADATABASEEntities1();
        protected void Page_Load(object sender, EventArgs e)
        {

            
            if (!IsPostBack)
            {
                var count = db.ProjectPublishFileType_Select();

                int i = 0;
                foreach (var item in count)
                {
                    i++;
                }

                string[] type = new string[i];
                var t = db.ProjectPublishFileType_Select();
                i = 0;
                foreach (var item in t)
                {
                    type[i] = item.type_name;
                    i++;
                }
                DropDownList1.Items.Clear();
                foreach (string y in type)
                {
                    DropDownList1.Items.Add(y);
                }

                DropDownList1.Items.Insert(0, new ListItem("กรุณาเลือกชนิดไฟล์", "-1"));
                ViewState["project_id"] = Request.QueryString["id"];


            }
            loadGridView1();
        }

        private void loadGridView1()
        {
            int id = Int32.Parse(ViewState["project_id"].ToString());
            gridview.DataSource = db.ProjectPublishFileUpload_Select(id);
            gridview.DataBind();
        }


        protected void btnUpload_OnClick(Object sender, EventArgs e)
        {
            if (this.fiUpload.HasFile)
            {
                string[] split = fiUpload.FileName.Split('.');
                int count = split.Length-1;
                split[0] = DateTime.Now.ToString("yyyyMMddHHmmssfff");               
                try
                {
                    int projectid = Int32.Parse(ViewState["project_id"].ToString());
                    string getType = DropDownList1.SelectedItem.Text.ToString();
                    db.ProjectPublishFileUpload_Create(projectid, TextBoxName.Text, (split[0]+'.'+split[count]), getType);

                    this.fiUpload.SaveAs(Server.MapPath("~/fileUpload/" + split[0] + '.' + split[count]));
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('อัพโหลดเอกสารสำเร็จ')", true);
                    loadGridView1();

                }
                catch { }

            }
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
            foreach(var item in query)
            {
                filename = item.filename;
                name = item.nameFomTextBox;
            }

            string[] split = filename.Split('.');
            if (str == "download")
            {
                Response.ContentType = "Application/doc";
                Response.AppendHeader("Content-Disposition", "attachment; filename=" + name + '.' + split[1]);
                Response.TransmitFile(Server.MapPath("~/fileUpload/"+split[0] + '.' + split[1]));
                Response.End();
            }
            else if(str=="delete")
            {
                string pathfile = Server.MapPath("~/fileUpload/" + filename);
                db.ProjectPublishFileUpload_Delete(file_id);
                System.IO.File.Delete(pathfile);
                Page.Response.Redirect(Page.Request.Url.ToString(), true);
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            Response.Redirect("ViewStateProcess.aspx");
        }

    }
}