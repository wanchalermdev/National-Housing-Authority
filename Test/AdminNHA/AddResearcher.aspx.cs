using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Test.Data;
using Word = Microsoft.Office.Interop.Word;
using System.Globalization;
using System.Threading;
using Test.Function;
namespace Test.AdminNHA
{
    public partial class AddResearcher : System.Web.UI.Page
    {
        static NHADATABASEEntities1 db = new NHADATABASEEntities1();
        ConvertFunction cf = new ConvertFunction();
        protected void Page_Load(object sender, EventArgs e)
        {
            ConvertFunction cf = new ConvertFunction();
            if (!IsPostBack)
            {
                ViewState["project_id"] = Request.QueryString["id"];
                try
                {
                    var data = db.Select_Contract(Int32.Parse(ViewState["project_id"].ToString()));
                    foreach (var item in data.ToList())
                    {
                        LabelConNum.Text = item.contract_id;
                        LabelDateCon.Text =  cf.DateToThai(item.day_contract.ToString());
                        LabelCommit.Text = item.comment;
                        double bud = double.Parse(item.Contract_Money.ToString(), System.Globalization.CultureInfo.InvariantCulture);
                        bud = Math.Round(bud, 2);
                        LabelBudgetCon.Text = bud.ToString("N2");
                        LabelEmp.Text = item.Employee;
                        LabelPeriod.Text = item.Period.ToString();
                    }
                }
                catch { }

            }
            loadTableResearcher();
            loadTablePeriod();
        }

        protected void btnAdd_Click(object sender, EventArgs e)
        {
            if (Page.IsValid)
            {
                int posion_id = Int32.Parse(hfUserId.Value.ToString());
                int pid = Int32.Parse(ViewState["project_id"].ToString());
                db.Researcher_insert(pid, posion_id);
                loadTableResearcher();
            }
           
        }

        private void loadTableResearcher()
        {
            int id = Int32.Parse(ViewState["project_id"].ToString());
            tableResearcher.DataSource = db.Researcher_Select(id);
            tableResearcher.DataBind();
        }

        [System.Web.Services.WebMethod]
        public static String[] SearchResearcher(string prefix)
        {
            List<string> users = new List<string>();
            using (NHADATABASEEntities1 db = new NHADATABASEEntities1())
            {
                var data = db.Search_Researcher(prefix);
                foreach (var item in data)
                {
                    users.Add(string.Format("{0}-{1}-{2}-{3}", item.pname, item.fname, item.lname, item.re_id));
                }
            }
            return users.ToArray();
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            Response.Redirect("AddPeriod.aspx?id="+ ViewState["project_id"].ToString());
        }

        private void loadTablePeriod()
        {
            int pid = Int32.Parse(ViewState["project_id"].ToString());
            //var data = db.Select_Period(pid);
            tablePeriod.DataSource = db.Select_Period(pid);
            tablePeriod.DataBind();
            string checkRow = tablePeriod.Rows.Count.ToString();
            if (checkRow=="0")
            {
                ButtonCon.Visible = false;
            }
            else if(checkRow!="0")
            {
                ButtonCon.Visible = true;
            }

        }



        protected void tablePeriod_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        protected void tablePeriod_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            string str = e.CommandName.ToString();
            int id = Int32.Parse(ViewState["project_id"].ToString());
            int uid = (Convert.ToInt32(e.CommandArgument)) + 1; 
            if (str == "addDocs")
            {
                Response.Redirect("AddDocs.aspx?pid="+id+"&pr="+uid);
            }else if (str == "a")
            {
                Response.Redirect("AfterCommit.aspx?id="+id+"&pr="+uid+"&key=meet1");
            }
            else if (str == "b")
            {
                Response.Redirect("AfterCommit.aspx?id=" + id + "&pr=" + uid + "&key=meet2");
            }
            else if (str == "c")
            {
                Response.Redirect("AfterCommit.aspx?id=" + id + "&pr=" + uid + "&key=widen");
            }
            else if (str == "check")
            {
                
            }
            //GridViewRow row = tablePeriod.SelectedRow;

            //string co = tablePeriod.SelectedIndex.ToString();

            //int uid = Int32.Parse(row.Cells[1].Text);

            //GridViewRow row = tablePeriod.Rows[uid];
            //db.Committee_Delete(id, uid);
            Page.Response.Redirect(Page.Request.Url.ToString(), true);
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            int user_id = Int32.Parse(Session["USER"].ToString());
            int id = Int32.Parse(ViewState["project_id"].ToString());
            db.Update_Project_State(user_id, id, 8);
            Response.Redirect("/");
        }

        protected void ButtonCon_Click(object sender, EventArgs e)
        {
            int projecID = Int32.Parse(ViewState["project_id"].ToString());
            string SourceFile = Server.MapPath("~/FormTemplate/แบบฟอร์มสรุปแผนการดำเนินงาน.docx");
            string NewFile = Server.MapPath("~/FormTemplate/temp" + DateTime.Now.ToString("yyyyMMddHHmmssfff") + ".docx");
            try
            {
                System.IO.File.Copy(SourceFile, NewFile, true);
            }
            catch
            { }
            Word.Application word = new Word.Application();
            Word.Document doc = new Word.Document();
            object missing = System.Type.Missing;
            object fileName = NewFile;
            word.Visible = false;
            doc = word.Documents.Open(ref fileName,
                    ref missing, ref missing, ref missing, ref missing,
                    ref missing, ref missing, ref missing, ref missing,
                    ref missing, ref missing, ref missing, ref missing,
                    ref missing, ref missing, ref missing);


            string projectname = "";
            string contractNum = "";
            string contractDate = "";

            var query = db.Concussion(projecID);
            if (query != null)
            {
                foreach (var item2 in query.ToList())
                {
                    projectname = item2.project_name;
                    contractNum = item2.contract_id;
                    contractDate = item2.day_contract;
                }
            }


            DateTime d = DateTime.ParseExact(contractDate, "yyyy-MM-dd", CultureInfo.InvariantCulture);
            Thread.CurrentThread.CurrentCulture = new CultureInfo("th-TH");
            contractDate = d.ToString("dd MMMM yyyy");

            FindAndReplace(word, "[projectName]", projectname);
            FindAndReplace(word, "[contractNum]", contractNum);
            FindAndReplace(word, "[contractDate] ", contractDate);

            int numf = 1;
            string committeeFirst = "";
            string committeeLast = "";
            string position = "";
            var queryCommit = db.Committee_Select_employ(projecID);
            if (queryCommit != null)
            {
                foreach (var item2 in queryCommit.ToList())
                {
                    committeeFirst += (numf) + "." + item2.first_name + (char)11;
                    committeeLast += item2.last_name + (char)11;
                    position += item2.position + (char)11;
                    numf++;
                }
            }
            FindAndReplace(word, "[committeeFirst]", committeeFirst);
            FindAndReplace(word, "[committeeLast]", committeeLast);
            FindAndReplace(word, "[committeePosition]", position);

            //----------------------------------------------------------------------------------------------------------

            string committeeFirst2 = "";
            string committeeLast2 = "";
            string position2 = "";
            int num2f = 1;
            var queryCommit2 = db.Committee_Select_check(projecID);
            if (queryCommit2 != null)
            {
                foreach (var item2 in queryCommit2.ToList())
                {
                    committeeFirst2 += (num2f) + "." + item2.first_name + (char)11;
                    committeeLast2 += item2.last_name + (char)11;
                    position2 += item2.position + (char)11;
                    num2f++;
                }
            }

            FindAndReplace(word, "[committeeCFirst]", committeeFirst2);
            FindAndReplace(word, "[committeeCLast]", committeeLast2);
            FindAndReplace(word, "[committeeCPosition]", position2);

            doc.Save();
            doc.Close(ref missing, ref missing, ref missing);
            word.Quit(ref missing, ref missing, ref missing);

            Response.ContentType = "Application/doc";
            Response.AppendHeader("Content-Disposition", "attachment; filename=แบบฟอร์มสรุปแผนการดำเนินงาน.docx");
            Response.TransmitFile(NewFile);
            Response.Flush();
            System.IO.File.Delete(NewFile);
            Response.End();

        }
        protected void tableResearcher_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            int rowIndex = Convert.ToInt32(e.CommandArgument);
            string str = e.CommandName.ToString();
            int id = Int32.Parse(ViewState["project_id"].ToString());
            int re_id = (int)tableResearcher.DataKeys[rowIndex].Values[0];
            if (str == "1")
            {
                db.Researcher_Delete(id, re_id);
                Page.Response.Redirect(Page.Request.Url.ToString(), true);
            }
            else if (str == "2")
            {
                Response.Redirect("ResearchDetail.aspx?rid=" + re_id + "&pid=" + id);
            }
        }

        public static string ThaiBaht2(string txt)
        {
            if (txt == "1")
            {
                return "หนึ่ง";
            }
            string bahtTxt, n, bahtTH = "";
            double amount;
            try { amount = Convert.ToDouble(txt); }
            catch { amount = 0; }
            bahtTxt = amount.ToString("####.00");
            string[] num = { "ศูนย์", "หนึ่ง", "สอง", "สาม", "สี่", "ห้า", "หก", "เจ็ด", "แปด", "เก้า", "สิบ" };
            string[] rank = { "", "สิบ", "ร้อย", "พัน", "หมื่น", "แสน", "ล้าน" };
            string[] temp = bahtTxt.Split('.');
            string intVal = temp[0];
            string decVal = temp[1];
            if (Convert.ToDouble(bahtTxt) == 0)
                bahtTH = "ศูนย์บาทถ้วน";
            else
            {
                for (int i = 0; i < intVal.Length; i++)
                {
                    n = intVal.Substring(i, 1);
                    if (n != "0")
                    {
                        if ((i == (intVal.Length - 1)) && (n == "1"))
                            bahtTH += "เอ็ด";
                        else if ((i == (intVal.Length - 2)) && (n == "2"))
                            bahtTH += "ยี่";
                        else if ((i == (intVal.Length - 2)) && (n == "1"))
                            bahtTH += "";
                        else
                            bahtTH += num[Convert.ToInt32(n)];
                        bahtTH += rank[(intVal.Length - i) - 1];
                    }
                }

                if (decVal == "00")
                { }

                else
                {
                    for (int i = 0; i < decVal.Length; i++)
                    {
                        n = decVal.Substring(i, 1);
                        if (n != "0")
                        {
                            if ((i == decVal.Length - 1) && (n == "1"))
                                bahtTH += "เอ็ด";
                            else if ((i == (decVal.Length - 2)) && (n == "2"))
                                bahtTH += "ยี่";
                            else if ((i == (decVal.Length - 2)) && (n == "1"))
                                bahtTH += "";
                            else
                                bahtTH += num[Convert.ToInt32(n)];
                            bahtTH += rank[(decVal.Length - i) - 1];
                        }
                    }
                    bahtTH += "สตางค์";
                }
            }
            return bahtTH;
        }

        public static string ThaiBaht(string txt)
        {
            string bahtTxt, n, bahtTH = "";
            double amount;
            try { amount = Convert.ToDouble(txt); }
            catch { amount = 0; }
            bahtTxt = amount.ToString("####.00");
            string[] num = { "ศูนย์", "หนึ่ง", "สอง", "สาม", "สี่", "ห้า", "หก", "เจ็ด", "แปด", "เก้า", "สิบ" };
            string[] rank = { "", "สิบ", "ร้อย", "พัน", "หมื่น", "แสน", "ล้าน", "สิบล้าน", "ร้อยล้าน", "พันล้าน" };
            string[] temp = bahtTxt.Split('.');
            string intVal = temp[0];
            string decVal = temp[1];
            if (Convert.ToDouble(bahtTxt) == 0)
                bahtTH = "บาทถ้วน";
            else
            {
                for (int i = 0; i < intVal.Length; i++)
                {
                    n = intVal.Substring(i, 1);
                    if (n != "0")
                    {
                        if ((i == (intVal.Length - 1)) && (n == "1"))
                            bahtTH += "เอ็ด";
                        else if ((i == (intVal.Length - 2)) && (n == "2"))
                            bahtTH += "ยี่";
                        else if ((i == (intVal.Length - 2)) && (n == "1"))
                            bahtTH += "";
                        else
                            bahtTH += num[Convert.ToInt32(n)];
                        bahtTH += rank[(intVal.Length - i) - 1];
                    }
                }
                bahtTH += "บาท";
                if (decVal == "00")
                    bahtTH += "ถ้วน";
                else
                {
                    for (int i = 0; i < decVal.Length; i++)
                    {
                        n = decVal.Substring(i, 1);
                        if (n != "0")
                        {
                            if ((i == decVal.Length - 1) && (n == "1"))
                                bahtTH += "เอ็ด";
                            else if ((i == (decVal.Length - 2)) && (n == "2"))
                                bahtTH += "ยี่";
                            else if ((i == (decVal.Length - 2)) && (n == "1"))
                                bahtTH += "";
                            else
                                bahtTH += num[Convert.ToInt32(n)];
                            bahtTH += rank[(decVal.Length - i) - 1];
                        }
                    }
                    bahtTH += "สตางค์";
                }
            }
            return bahtTH;
        }

        public void FindAndReplace(Word.Application WordApp, object findText, object replaceText)
        {
            try
            {
                object missing = Type.Missing;
                object matchCase = true;
                object matchWholeWord = true;
                object matchWildCards = false;
                object matchSoundLike = false;
                object nmatchAllWordForms = false;
                object forward = true;
                object format = false;
                object matchKashida = false;
                object matchDiacritics = false;
                object matchAlefHamza = false;
                object matchControl = false;
                object read_only = false;
                object visible = true;
                object replace = 2;
                object wrap = 1;

                if (replaceText.ToString().Length < 250)
                {
                    WordApp.Selection.Find.Execute(ref findText,
                                   ref matchCase,
                                   ref matchWholeWord,
                                   ref matchWildCards,
                                   ref matchSoundLike,
                                   ref nmatchAllWordForms,
                                   ref forward,
                                   ref wrap,
                                   ref format,
                                   ref replaceText,
                                   ref replace,
                                   ref matchKashida,
                                   ref matchDiacritics,
                                   ref matchAlefHamza,
                                   ref matchControl);
                }
                else
                {
                    WordApp.Selection.Find.Execute(ref findText,
                                   ref missing,
                                   ref missing,
                                   ref missing,
                                   ref missing,
                                   ref missing,
                                   ref missing,
                                   ref missing,
                                   ref missing,
                                   ref missing,
                                   ref missing,
                                   ref missing,
                                   ref missing,
                                   ref missing,
                                   ref missing);

                    WordApp.Selection.Text = (string)replaceText;
                }

            }
            catch { }
        }
    }
}