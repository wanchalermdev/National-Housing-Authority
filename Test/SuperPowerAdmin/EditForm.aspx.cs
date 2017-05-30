using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;

namespace Test.SuperPowerAdmin
{
    public partial class EditForm : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnUpload_OnClick(Object sender, EventArgs e)
        {
            if (this.fiUpload.HasFile)
            {
                string name = "";
                try
                {
                    name = ((fiUpload.FileName).ToString()).Replace(".docx", "").Replace(".doc", "");                  
                    if (name == "แบบฟอร์มขออนุมัติข้อกำหนดโครงการ")
                    {
                        this.fiUpload.SaveAs(Server.MapPath("~/FormTemplate/" + name + ".docx"));
                        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('อัพโหลดเอกสารสำเร็จ')", true);
                    }
                    else if (name == "แบบฟอร์มขออนุมัติเบิกค่าจ้าง")
                    {
                        this.fiUpload.SaveAs(Server.MapPath("~/FormTemplate/" + name + ".docx"));
                        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('อัพโหลดเอกสารสำเร็จ')", true);
                    }
                    else if (name == "แบบฟอร์มขอเชิญประชุมตรวจรับงาน")
                    {
                        this.fiUpload.SaveAs(Server.MapPath("~/FormTemplate/" + name + ".docx"));
                        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('อัพโหลดเอกสารสำเร็จ')", true);
                    }
                    else if (name == "แบบฟอร์มขอเชิญเป็นประธานประชุมตรวจรับงาน")
                    {
                        this.fiUpload.SaveAs(Server.MapPath("~/FormTemplate/" + name + ".docx"));
                        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('อัพโหลดเอกสารสำเร็จ')", true);
                    }
                    else if (name == "แบบฟอร์มแจ้งได้รับอนุมัติโครงการ")
                    {
                        this.fiUpload.SaveAs(Server.MapPath("~/FormTemplate/" + name + ".docx"));
                        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('อัพโหลดเอกสารสำเร็จ')", true);
                    }
                    else if (name == "แบบพิมพ์ตรวจสอบงานวิจัย")
                    {
                        this.fiUpload.SaveAs(Server.MapPath("~/FormTemplate/" + name + ".docx"));
                        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('อัพโหลดเอกสารสำเร็จ')", true);
                    }
                    else
                    {
                        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('กรุณาตั้งชื่อไฟล์หรือเลือกไฟล์ให้ถูกต้อง')", true);
                    }
                }
                catch { }

            }
        }

        protected void ButtonDownload1_Click(object sender, EventArgs e)
        {
            PrivDocLoad(0);
        }

        protected void ButtonDownload2_Click(object sender, EventArgs e)
        {
            PrivDocLoad(1);
        }

        protected void ButtonDownload3_Click(object sender, EventArgs e)
        {
            PrivDocLoad(2);
        }

        protected void ButtonDownload4_Click(object sender, EventArgs e)
        {
            PrivDocLoad(3);
        }

        protected void ButtonDownload5_Click(object sender, EventArgs e)
        {
            PrivDocLoad(4);
        }

        protected void ButtonDownload6_Click(object sender, EventArgs e)
        {
            PrivDocLoad(5);
        }

        private void PrivDocLoad(int Type)
        {
            switch (Type)
            {
                case 0:
                    {
                        Response.ContentType = "Application/doc";
                        Response.AppendHeader("Content-Disposition", "attachment; filename=แบบฟอร์มขออนุมัติข้อกำหนดโครงการ.docx");
                        Response.TransmitFile(Server.MapPath("~/FormTemplate/แบบฟอร์มขออนุมัติข้อกำหนดโครงการ.docx"));
                        Response.End();
                        break;
                    }
                case 1:
                    {
                        Response.ContentType = "Application/doc";
                        Response.AppendHeader("Content-Disposition", "attachment; filename=แบบฟอร์มแจ้งได้รับอนุมัติโครงการ.docx");
                        Response.TransmitFile(Server.MapPath("~/FormTemplate/แบบฟอร์มแจ้งได้รับอนุมัติโครงการ.docx"));
                        Response.End();
                        break;
                    }
                case 2:
                    {
                        Response.ContentType = "Application/doc";
                        Response.AppendHeader("Content-Disposition", "attachment; filename=แบบฟอร์มขอเชิญเป็นประธานประชุมตรวจรับงาน.docx");
                        Response.TransmitFile(Server.MapPath("~/FormTemplate/แบบฟอร์มขอเชิญเป็นประธานประชุมตรวจรับงาน.docx"));
                        Response.End();
                        break;
                    }
                case 3:
                    {
                        Response.ContentType = "Application/doc";
                        Response.AppendHeader("Content-Disposition", "attachment; filename=แบบฟอร์มขอเชิญประชุมตรวจรับงาน.docx");
                        Response.TransmitFile(Server.MapPath("~/FormTemplate/แบบฟอร์มขอเชิญประชุมตรวจรับงาน.docx"));
                        Response.End();
                        break;
                    }
                case 4:
                    {
                        Response.ContentType = "Application/doc";
                        Response.AppendHeader("Content-Disposition", "attachment; filename=แบบฟอร์มขออนุมัติเบิกค่าจ้าง.docx");
                        Response.TransmitFile(Server.MapPath("~/FormTemplate/แบบฟอร์มขออนุมัติเบิกค่าจ้าง.docx"));
                        Response.End();
                        break;
                    }
                case 5:
                    {
                        Response.ContentType = "Application/doc";
                        Response.AppendHeader("Content-Disposition", "attachment; filename=แบบพิมพ์ตรวจสอบงานวิจัย.docx");
                        Response.TransmitFile(Server.MapPath("~/FormTemplate/แบบพิมพ์ตรวจสอบงานวิจัย.docx"));
                        Response.End();
                        break;
                    }
            }
        }
    }
}