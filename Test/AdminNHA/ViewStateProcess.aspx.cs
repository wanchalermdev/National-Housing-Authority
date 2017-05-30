using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;
using Test.Data;
using NPOI.SS.UserModel;
using NPOI.SS.Util;
using NPOI.XSSF.UserModel;
using System.IO;
using System.Globalization;
using System.Web.UI.HtmlControls;

namespace Test
{
    public partial class ViewStateProcess1 : System.Web.UI.Page
    {
        static NHADATABASEEntities1 db = new NHADATABASEEntities1();
        protected void Page_Load(object sender, EventArgs e)
        {
            HtmlAnchor HA = new HtmlAnchor();
           // HA.ServerClick += new EventHandler(GenExcel);

            //LoadData();
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



        private static string getButtonProject(bool nha, bool pm, int pid)
        {
            if (nha && pm)
            {
                //return "<a id=\"sendTOR\" class=\"btn btn-info \" href=\"#\"> แจ้งขอ TOR</a> <a id = \"acceptTOR\" class=\"btn btn-info disabled\" href=\"#\">รับทราบเอกสารข้ออนุมัติ</a> <a id = \"editCommitee\" class=\"btn btn-info disabled\" href=\"#\"> แก้ไขกรรมการ</a><a id = \"genForm\" class=\"btn btn-info disabled\" href=\"#\"> สร้างฟอร์มการขออนุมัติ</a>";
                string str = "";
                str += "<div class=\"btn-group btn-group-justified\">";
                str += "<a id=\"sendTOR\" ";
                System.Data.Entity.Core.Objects.ObjectParameter result = new System.Data.Entity.Core.Objects.ObjectParameter("result", typeof(int));
                var stateTORRequest = db.Get_Project_State(pid, 2, result);
                if (Int32.Parse(result.Value.ToString()) == 1)
                {
                    str += "class=\"btn btn-info \" href=\"../AdminNHA/Accept.aspx?id=" + pid + "\">";
                }
                else
                {
                    str += "class=\"btn btn-info  disabled\" href=\"#\">";
                }
                str += "<i class=\"glyphicon glyphicon-bullhorn\" style=\"font-size:25px; \"></i><br>แจ้งขอ TOR</a>";

                str += "<a id=\"acceptTOR\" ";
                if (Int32.Parse(result.Value.ToString()) == 2)
                {
                    str += "class=\"btn btn-info \" href=\"../ProjectManager/UpTor.aspx?id=" + pid + "\">";
                }
                else
                {
                    str += "class=\"btn btn-info  disabled\" href=\"#\">";
                }
                str += "<i class=\"glyphicon glyphicon-briefcase\" style=\"font-size:25px; \"></i><br>รับทราบเอกสาร<br>ข้ออนุมัติ</a>";

                str += "<a id=\"editCommitee\" ";
                if (Int32.Parse(result.Value.ToString()) == 3)
                {
                    str += "class=\"btn btn-info \" href=\"../AdminNHA/EditCommitee.aspx?id=" + pid + "\">";
                }
                else
                {
                    str += "class=\"btn btn-info  disabled\" href=\"#\">";
                }
                str += " <i class=\"glyphicon glyphicon-edit\" style=\"font-size:25px; \"></i><br>แก้ไขกรรมการ</a>";

                str += "<a id=\"genForm\" ";
                if (Int32.Parse(result.Value.ToString()) == 3 || Int32.Parse(result.Value.ToString()) == 4)
                {
                    str += "class=\"btn btn-info \" href=\"../AdminNHA/AfterCommit.aspx?id=" + pid + "&key=tor\">";
                }
                else
                {
                    str += "class=\"btn btn-info  disabled\" href=\"#\">";
                }
                str += " <i class=\"glyphicon glyphicon-print\" style=\"font-size:25px; \"></i><br>สร้างฟอร์ม<br>การขออนุมัติ</a>";
                str += "</div";
                return str;
            }
            else if (nha)
            {
                System.Data.Entity.Core.Objects.ObjectParameter result = new System.Data.Entity.Core.Objects.ObjectParameter("result", typeof(int));
                var stateTORRequest = db.Get_Project_State(pid, 2, result);
                string str = "";
                str += "<div class=\"btn-group btn-group-justified\">";
                str += "<a id=\"sendTOR\" ";
                if (Int32.Parse(result.Value.ToString()) == 1)
                {
                    str += "class=\"btn btn-info \" href=\"../AdminNHA/Accept.aspx?id=" + pid + "\">";
                }
                else
                {
                    str += "class=\"btn btn-info  disabled\" href=\"#\">";
                }
                str += "<i class=\"glyphicon glyphicon-bullhorn\" style=\"font-size:25px; \"></i><br> แจ้งขอ TOR</a>";

                result = new System.Data.Entity.Core.Objects.ObjectParameter("result", typeof(int));
                stateTORRequest = db.Get_Project_State(pid, 2, result);
                str += "<a id=\"editCommitee\" ";
                if (Int32.Parse(result.Value.ToString()) == 3)
                {
                    str += "class=\"btn btn-info \" href=\"../AdminNHA/EditCommitee.aspx?id=" + pid + "\">";
                }
                else
                {
                    str += "class=\"btn btn-info  disabled\" href=\"#\">";
                }
                str += " <i class=\"glyphicon glyphicon-edit\" style=\"font-size:25px; \"></i><br>แก้ไขกรรมการ</a>";

                result = new System.Data.Entity.Core.Objects.ObjectParameter("result", typeof(int));
                stateTORRequest = db.Get_Project_State(pid, 2, result);
                str += "<a id=\"genForm\" ";
                if (Int32.Parse(result.Value.ToString()) == 3 || Int32.Parse(result.Value.ToString()) == 4)
                {
                    str += "class=\"btn btn-info \" href=\"../AdminNHA/AfterCommit.aspx?id=" + pid + "&key=tor\">";
                }
                else
                {
                    str += "class=\"btn btn-info  disabled\" href=\"#\">";
                }
                str += " <i class=\"glyphicon glyphicon-print\" style=\"font-size:25px; \"></i><br>สร้างฟอร์ม<br>การขออนุมัติ</a>";
                str += "</div>";
                return str;
            }
            else if (pm)
            {
                System.Data.Entity.Core.Objects.ObjectParameter result = new System.Data.Entity.Core.Objects.ObjectParameter("result", typeof(int));
                var stateTORRequest = db.Get_Project_State(pid, 2, result);
                string str = "";
                str += "<div class=\"btn-group btn-group-justified\">";
                str += "<a id=\"acceptTOR\" ";
                if (Int32.Parse(result.Value.ToString()) == 2)
                {
                    str += "class=\"btn btn-info \" href=\"../ProjectManager/UpTor.aspx?id=" + pid + "\">";
                }
                else
                {
                    str += "class=\"btn btn-info  disabled\" href=\"#\">";
                }
                str += " <i class=\"glyphicon glyphicon-briefcase\" style=\"font-size:25px; \"></i><br>รับทราบเอกสารข้ออนุมัติ</a>";
                str += "</div>";
                return str;
            }
            return "";
        }

        private static string getButtonProject2(int pid)
        {
            string str = "";
            str += "<div class=\"btn-group btn-group-justified\">";
            str += "<a id=\"save_allow\" ";
            System.Data.Entity.Core.Objects.ObjectParameter result = new System.Data.Entity.Core.Objects.ObjectParameter("result", typeof(int));
            var stateTORRequest = db.Get_Project_State(pid, 2, result);
            if (Int32.Parse(result.Value.ToString()) == 4 || Int32.Parse(result.Value.ToString()) == 5)
            {
                str += "class=\"btn btn-info \" href=\"../AdminNHA/ApproveRecord.aspx?id=" + pid + "\">";
            }
            else
            {
                str += "class=\"btn btn-info  disabled\" href=\"#\">";
            }
            str += "<i class=\"glyphicon glyphicon-save-file\" style=\"font-size:25px; \"></i><br>จัดเก็บเอกสาร<br>การขออนุมัติ</a>";

            str += "<a id=\"print_doc\" ";
            if (Int32.Parse(result.Value.ToString()) == 5 || Int32.Parse(result.Value.ToString()) == 6)
            {
                str += "class=\"btn btn-info \" href=\"../AdminNHA/AfterCommit.aspx?id=" + pid + "&key=tor2\">";
            }
            else
            {
                str += "class=\"btn btn-info  disabled\" href=\"#\">";
            }
            str += "<i class=\"glyphicon glyphicon-print\" style=\"font-size:25px; \"></i><br>สร้างแบบฟอร์ม<br>การได้รับข้ออนุมัติ</a>";

            str += "<a id=\"save_comittee\" ";
            if (Int32.Parse(result.Value.ToString()) == 6 || Int32.Parse(result.Value.ToString()) == 7 || Int32.Parse(result.Value.ToString()) == 8 || Int32.Parse(result.Value.ToString()) == 9)
            {
                str += "class=\"btn btn-info \" href=\"../AdminNHA/ApproveRecord_2.aspx?id=" + pid + "\">";
            }
            else
            {
                str += "class=\"btn btn-info  disabled\" href=\"#\">";
            }
            str += "<i class=\"glyphicon glyphicon-floppy-disk\" style=\"font-size:25px; \"></i><br> บันทึกความเห็น<br>กรรมการ</a>";

            str += "<a id=\"btnGenexcel\" ";
            if (Int32.Parse(result.Value.ToString()) == 8)
            {
                //str += "class=\"btn btn-info \" onserverclick=\"btnGenExcel_Click\" runat=\"server\" >";
                str += "class=\"btn btn-info \" href=\"../AdminNHA/GenExcel.aspx?id=" + pid + "\">";
            }
            else
            {
                str += "class=\"btn btn-info  disabled\" >";
            }
            str += "<i class=\"glyphicon glyphicon-floppy-saved\" style=\"font-size:25px; \"></i><br>เสร็จสิ้นการสร้าง<br>แบบแผนโครงการ</a>";

            str += "</div>";
            return str;
        }

        private static string getButtonProject3(int pid)
        {
            string str = "";
            str += "<div class=\"btn-group btn-group-justified\">";
            str += "<a id=\"save_allow\" ";
            System.Data.Entity.Core.Objects.ObjectParameter result = new System.Data.Entity.Core.Objects.ObjectParameter("result", typeof(int));
            var stateTORRequest = db.Get_Project_State(pid, 2, result);
            //if (Int32.Parse(result.Value.ToString()) == 4 || Int32.Parse(result.Value.ToString()) == 5)
            //{
                str += "class=\"btn btn-info \" href=\"../AdminNHA/WriteAbstact.aspx?id=" + pid + "\">";
            //}
            //else
            //{
            //    str += "class=\"btn btn-info  \" href=\"#\">";
            //}
            str += "<i class=\"glyphicon glyphicon-book\" style=\"font-size:25px; \"></i><br>เพิ่มบทคัดย่อ</a>";

            str += "<a id=\"\" ";
            //if (Int32.Parse(result.Value.ToString()) == 5 || Int32.Parse(result.Value.ToString()) == 6)
            //{
                str += "class=\"btn btn-info \" href=\"../AdminNHA/UploadDocument.aspx?id=" + pid + "&key=tor2\">";
            //}
            //else
            //{
            //    str += "class=\"btn btn-info  \" href=\"#\">";
            //}
            str += "<i class=\"glyphicon glyphicon-upload\" style=\"font-size:25px; \"></i><br>อัพโหลดเนื้องาน</a>";

            str += "<a id=\"save_comittee\" ";
            //if (Int32.Parse(result.Value.ToString()) == 6 || Int32.Parse(result.Value.ToString()) == 7 || Int32.Parse(result.Value.ToString()) == 8 || Int32.Parse(result.Value.ToString()) == 9)
            //{
            str += "class=\"btn btn-info \" href=\"../AdminNHA/SetPermissionsDocument.aspx?id=" + pid + "\">";
            //}
            //else
            //{
            //    str += "class=\"btn btn-info  \" href=\"#\">";
            //}
            str += "<i class=\"glyphicon glyphicon-share\" style=\"font-size:25px; \"></i><br> กำหนดสิทธิ์<br>การเผยแพร่</a>";

            str += "<a id=\"btnGenexcel\" ";
            //if (Int32.Parse(result.Value.ToString()) == 8)
            //{
                //str += "class=\"btn btn-info \" onserverclick=\"btnGenExcel_Click\" runat=\"server\" >";
                str += "class=\"btn btn-info \" >";
            //}
            //else
            //{
            //    str += "class=\"btn btn-info  \" >";
            //}
            str += "<i class=\"glyphicon glyphicon-globe\" style=\"font-size:25px; \"></i><br>สถานะ<br>สาธารณะ</a>";

            str += "</div>";
            return str;
        }

        [WebMethod]
        public static string getMyProjectTable(string user_id)
        {
            string html = "";
            var data = db.SelectMyProject(Int32.Parse(user_id));
            html += "<table class=\"table table-hover\">";

            html += "<thead>";
            html += "<tr>";
            html += "<td width=\"10%\"><b align=\"center\">รหัสโครงการ<b></td>";
            html += "<td width=\"35%\"><b align=\"center\">ชื่อโครงการ<b></td>";
            html += "<td width=\"10%\"><b align=\"center\">หน้าที่<b></td>";
            html += "<td width=\"45%\"></td>";
            html += "</tr>";
            html += "</thead>";
            foreach (var item in data.ToList())
            {
                html += "<tbody>";
                html += "<tr>";
                html += "<td>P" + item.year.ToString().Substring(2) + getStringProjectId(item.project_id) + "</td>";
                html += "<td>" + item.project_name + "</td>";

                html += "<td>";
                int countRole = 0;
                bool isNHA = false;
                bool isPM = false;
                System.Data.Entity.Core.Objects.ObjectParameter result = new System.Data.Entity.Core.Objects.ObjectParameter("result", typeof(int));
                var role = db.SelectMyProject_NHA(item.project_id, Int32.Parse(user_id), result);
                if (Int32.Parse(result.Value.ToString()) == 1)
                {
                    countRole++;
                    isNHA = true;
                    html += "ผู้ประสานงาน";
                }

                result = new System.Data.Entity.Core.Objects.ObjectParameter("result", typeof(int));
                role = db.SelectMyProject_PM(item.project_id, Int32.Parse(user_id), result);
                if (Int32.Parse(result.Value.ToString()) == 1)
                {
                    if (countRole > 0)
                    {
                        html += "<br />";
                    }
                    countRole++;
                    isPM = true;
                    html += "ผู้รับผิดชอบโครงการ";
                }

                html += "</td>";

                html += "<td>" + getButtonProject(isNHA, isPM, item.project_id) + "</td>";

                html += "</tr>";
                html += "</tbody>";
            }
            html += "</table>";
            return html;
        }

        [WebMethod]
        public static string getMyProjectTable2(string user_id)
        {
            string html = "";
            var data = db.SelectMyProject(Int32.Parse(user_id));
            html += "<table class=\"table table-hover\">";

            html += "<thead>";
            html += "<tr>";
            html += "<td width=\"10%\"><b align=\"center\">รหัสโครงการ<b></td>";
            html += "<td width=\"35%\"><b align=\"center\">ชื่อโครงการ<b></td>";
            html += "<td width=\"10%\"><b align=\"center\">หน้าที่<b></td>";
            html += "<td width=\"45%\"></td>";
            html += "</tr>";
            html += "</thead>";
            foreach (var item in data.ToList())
            {
                System.Data.Entity.Core.Objects.ObjectParameter result = new System.Data.Entity.Core.Objects.ObjectParameter("result", typeof(int));
                var role = db.SelectMyProject_NHA(item.project_id, Int32.Parse(user_id), result);
                if (Int32.Parse(result.Value.ToString()) == 1)
                {
                    html += "<tbody>";
                    html += "<tr>";
                    html += "<td>P" + item.year.ToString().Substring(2) + getStringProjectId(item.project_id) + "</td>";
                    html += "<td>" + item.project_name + "</td>";

                    html += "<td>";
                    html += "ผู้ประสานงาน";

                    html += "</td>";

                    html += "<td>" + getButtonProject2(item.project_id) + "</td>";

                    html += "</tr>";
                    html += "</tbody>";
                }
            }
            html += "</table>";
            
            return html;
        }

        [WebMethod]
        public static string getMyProjectTable3(string user_id)
        {
            string html = "";
            var data = db.SelectMyProject(Int32.Parse(user_id));
            html += "<table class=\"table table-hover\">";
            html += "<thead>";
            html += "<tr>";
            html += "<td width=\"10%\"><b align=\"center\">รหัสโครงการ<b></td>";
            html += "<td width=\"35%\"><b align=\"center\">ชื่อโครงการ<b></td>";
            html += "<td width=\"10%\"><b align=\"center\">หน้าที่<b></td>";
            html += "<td width=\"45%\"></td>";
            html += "</tr>";
            html += "</thead>";
            foreach (var item in data.ToList())
            {
                System.Data.Entity.Core.Objects.ObjectParameter result = new System.Data.Entity.Core.Objects.ObjectParameter("result", typeof(int));
                var role = db.SelectMyProject_NHA(item.project_id, Int32.Parse(user_id), result);
                if (Int32.Parse(result.Value.ToString()) == 1)
                {
                html += "<tbody>";
                html += "<tr>";
                html += "<td>P" + item.year.ToString().Substring(2) + getStringProjectId(item.project_id) + "</td>";
                html += "<td>" + item.project_name + "</td>";

                html += "<td>";
                
                    html += "ผู้ประสานงาน";
                
                html += "</td>";

                html += "<td>" + getButtonProject3(item.project_id) + "</td>";

                html += "</tr>";
                html += "</tbody>";
            
            }
        }
            html += "</table>";
            return html;
        }

        private void LoadData()
        {
            int user_id = Int32.Parse(Session["USER"].ToString());
        }

    }
}