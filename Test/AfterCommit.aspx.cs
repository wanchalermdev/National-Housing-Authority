using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Word = Microsoft.Office.Interop.Word;
using Test.Data;

namespace NHAWebForm.AdminNHA
{
    public partial class AfterCommit : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            string form = TextBoxForm.Text;
            string to = TextBoxTo.Text;
            string at = TextBoxAt.Text;
            string date = TextBoxDate.Text;

            string SourceFile = Server.MapPath("~/FormTemplate/แบบฟอร์มขออนุมัติข้อกำหนดโครงการ.docx");
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
           
            FindAndReplace(word, "[from]", form);
            FindAndReplace(word, "[to]", to);
            FindAndReplace(word, "[at]", at);
            FindAndReplace(word, "[date]", date);

            string projectname = "";
            string day = "";
            string year = "";
            string money = "";
            using (NHADATABASEEntities1 db = new NHADATABASEEntities1())
            {
                //int userID = ((int)Session["USER"]);
                //var query = db.SP_GenForm("P600001", 4);
                //if (query != null)
                //{
                //    foreach (var item2 in query.ToList())
                //    {
                //        projectname = item2.project_name;
                //        day = item2.period.ToString();
                //        year = item2.year.ToString();
                //        money = item2.project_budget.ToString();
                //    }
                //}

            }
            string month = (Int32.Parse(day) / 30).ToString();
            double monneyBath = Convert.ToDouble(money);
            FindAndReplace(word, "[projectName]", projectname);
            FindAndReplace(word, "[day]", day);
            FindAndReplace(word, "[month] ", month);
            FindAndReplace(word, "[budget]", monneyBath.ToString("N2"));
            FindAndReplace(word, "[budgetThai]", ThaiBaht(money));
            FindAndReplace(word, "[subsidies]", year);
            //FindAndReplace(word, "[Committee]", txtDay.Text);
            //FindAndReplace(word, "[CommitteeCheck]", txtDay.Text);

            doc.Save();
            doc.Close(ref missing, ref missing, ref missing);
            word.Quit(ref missing, ref missing, ref missing);

            Response.ContentType = "Application/doc";
            Response.AppendHeader("Content-Disposition", "attachment; filename=แบบฟอร์มขออนุมัติข้อกำหนดโครงการ.docx");
            Response.TransmitFile(NewFile);
            Response.Flush();
            System.IO.File.Delete(NewFile);
            Response.End();
        }

        public static string ThaiBaht(string txt)
        {
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
            catch { }
        }

    }
}