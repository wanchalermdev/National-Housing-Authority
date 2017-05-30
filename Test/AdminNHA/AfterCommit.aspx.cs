using System;
using System.Linq;
using System.Web.UI.WebControls;
using Word = Microsoft.Office.Interop.Word;
using Test.Data;
using System.Globalization;
using System.Threading;


namespace Test.AdminNHA
{
    public partial class AfterCommit : System.Web.UI.Page
    {
        NHADATABASEEntities1 db = new NHADATABASEEntities1();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                ViewState["project_id"] = Request.QueryString["id"];
                ViewState["key"] = Request.QueryString["key"];
                ViewState["period"] = Request.QueryString["pr"];

            }
            Check();
        }

        private void Check()
        {
            //tor
            //tor2
            if (ViewState["key"].ToString() == "tor")
            {
                headForm.Text = ":: สร้างแบบฟอร์มการขออนุมัติ TOR";
                Button1.Text = "พิมพ์ขออนุมัติข้อกำหนดโครงการ";
                approve.Visible = true;
                TextApprove.Visible = true;
            }
            else if (ViewState["key"].ToString() == "tor2")
            {
                headForm.Text = ":: สร้างแบบฟอร์มแจ้งได้รับอนุมัติข้อกำหนด";
                Button1.Text = "พิมพ์แบบฟอร์มแจ้งได้รับอนุมัติข้อกำหนด";
                approve.Visible = true;
                TextApprove.Visible = true;
            }
            else if (ViewState["key"].ToString() == "meet1")
            {
                headForm.Text = ":: สร้างแบบฟอร์มขอเชิญเป็นประธานประชุมตรวจรับงาน";
                Button1.Text = "พิมพ์แบบฟอร์มขอเชิญเป็นประธานประชุมตรวจรับงาน";
                approve.Visible = false;
                TextApprove.Visible = false;
            }
            else if (ViewState["key"].ToString() == "meet2")
            {
                headForm.Text = ":: สร้างแบบฟอร์มขอเชิญประชุมตรวจรับงาน";
                Button1.Text = "พิมพ์แบบฟอร์มขอเชิญประชุมตรวจรับงาน";
                approve.Visible = false;
                TextApprove.Visible = false;
            }
            else if (ViewState["key"].ToString() == "widen")
            {
                headForm.Text = ":: สร้างแบบฟอร์มขออนุมัติเบิกค่าจ้าง";
                Button1.Text = "พิมพ์แบบฟอร์มขออนุมัติเบิกค่าจ้าง";
                approve.Visible = false;
                TextApprove.Visible = false;
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            if (Page.IsValid)
            {
                int user_id = Int32.Parse(Session["USER"].ToString());
                int project_id = Int32.Parse(ViewState["project_id"].ToString());
                if (ViewState["key"].ToString() == "tor")
                {
                    db.Update_Project_State(user_id, project_id, 4);
                    Print1();
                }
                else if (ViewState["key"].ToString() == "tor2")
                {
                    db.Update_Project_State(user_id, project_id, 6);
                    Print2();
                }
                else if (ViewState["key"].ToString() == "meet1")
                {
                    Print3();
                    Response.Redirect("AddResearcher.aspx?id=" + ViewState["project_id"].ToString());
                }
                else if (ViewState["key"].ToString() == "meet2")
                {
                    Print4();
                    Response.Redirect("AddResearcher.aspx?id=" + ViewState["project_id"].ToString());
                }
                else if (ViewState["key"].ToString() == "widen")
                {
                    Print5();
                    Response.Redirect("AddResearcher.aspx?id=" + ViewState["project_id"].ToString());
                }

                Response.Redirect("~/AdminNHA/ViewStateProcess.aspx");
            }

        }

        private string Thai(string money)
        {
            string[] split = money.Split('.');
            char[] myArray = split[0].ToCharArray();
            string myMoney = "";
            int state = 0;
            if (split[0].Length == 7)
            {
                for (int i = 0; i < 1; i++)  //ล้าน
                {
                    myMoney += myArray[i];
                    state = 1;
                }
            }
            else if (split[0].Length == 8)
            {
                for (int i = 0; i < 2; i++)  //สิบล้าน
                {
                    myMoney += myArray[i];
                    state = 2;
                }
            }
            else if (split[0].Length == 9) //ร้อยล้าน
            {
                for (int i = 0; i < 3; i++)
                {
                    myMoney += myArray[i];
                    state = 3;
                }
            }
            else if (split[0].Length == 10)  //พันล้าน
            {
                for (int i = 0; i < 4; i++)
                {
                    myMoney += myArray[i];
                    state = 4;
                }
            }
            else if (split[0].Length == 11) //หมื่นล้าน
            {
                for (int i = 0; i < 5; i++)
                {
                    myMoney += myArray[i];
                    state = 5;
                }
            }
            else if (split[0].Length == 12) //แสนล้าน
            {
                for (int i = 0; i < 6; i++)
                {
                    myMoney += myArray[i];
                    state = 6;
                }
            }
            else
            {
                return ThaiBaht(money);
            }
            string before = ThaiBaht2(myMoney);
            before += "ล้าน";
            string after = money.Substring(state, 9);
            before += ThaiBaht(after);
            return before;
        }

        private void Print1()
        {
            int userID = Int32.Parse(Session["USER"].ToString());
            int project_id = Int32.Parse(ViewState["project_id"].ToString());

            string form = TextBoxForm.Text;
            string to = TextBoxTo.Text;
            string at = TextBoxAt.Text;
            string date = TextBoxDate.Text;
            string state = "a0";
            db.FromToAt_insert(project_id, state, form, to, at, date);
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
            var query = db.NHA_GenForm(project_id, userID);
            if (query != null)
            {
                foreach (var item2 in query.ToList())
                {
                    projectname = item2.project_name;
                    day = item2.period.ToString();
                    money = item2.project_budget.ToString();
                }
            }
            
            string month = (Int32.Parse(day) / 30).ToString();
            double monneyBath = Convert.ToDouble(money);

            FindAndReplace(word, "[approve]", TextApprove.Text);
            FindAndReplace(word, "[projectName]", projectname);
            FindAndReplace(word, "[day]", day);
            FindAndReplace(word, "[month] ", month);
            FindAndReplace(word, "[budget]", monneyBath.ToString("N2"));
            FindAndReplace(word, "[budgetThai]", Thai(money));
            FindAndReplace(word, "[subsidies]", year);
            int numf = 3;
            int numl = 1;
            string committeeFirst = "";
            string committeeLast = "";
            string position = "";
            string commiteePosition = "";
            var queryCommit = db.Committee_Select_employ(project_id);
            if (queryCommit != null)
            {
                foreach (var item2 in queryCommit.ToList())
                {
                    committeeFirst += (numf) + "." + numl + "."+ item2.first_name + (char)11;
                    committeeLast += item2.last_name + (char)11;
                    position += item2.position + (char)11;
                    commiteePosition += item2.Committee_type + (char)11;
                    numl++;
                }
            }
            FindAndReplace(word, "[committeeFirst]", committeeFirst);
            FindAndReplace(word, "[committeeLast]", committeeLast);
            FindAndReplace(word, "[committeePrefix]", position);
            FindAndReplace(word, "[committeePosition]", commiteePosition);

            //----------------------------------------------------------------------------------------------------------

            string committeeFirst2 = "";
            string committeeLast2 = "";
            string position2 = "";
            string commiteePosition2 = "";

            int num2f = 4;
            int num2l = 1;
            var queryCommit2 = db.Committee_Select_check(project_id);
            if (queryCommit2 != null)
            {
                foreach (var item2 in queryCommit2.ToList())
                {
                    committeeFirst2 += (num2f) + "." + num2l + "." + item2.first_name + (char)11;
                    committeeLast2 += item2.last_name + (char)11;
                    position2 += item2.position + (char)11;
                    commiteePosition2 += item2.Committee_type + (char)11;
                    num2l++;
                }
            }

            FindAndReplace(word, "[committeeCFirst]", committeeFirst2);
            FindAndReplace(word, "[committeeCLast]", committeeLast2);
            FindAndReplace(word, "[committeeCPrefix]", position2);
            FindAndReplace(word, "[committeeCPosition]", commiteePosition2);

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

        private void Print2()
        {
            int userID = Int32.Parse(Session["USER"].ToString());
            int project_id = Int32.Parse(ViewState["project_id"].ToString());
            string form = TextBoxForm.Text;
            string to = TextBoxTo.Text;
            string at = TextBoxAt.Text;
            string date = TextBoxDate.Text;
            string state = "a1";
            db.FromToAt_insert(project_id, state, form, to, at,date);
            string SourceFile = Server.MapPath("~/FormTemplate/แบบฟอร์มแจ้งได้รับอนุมัติโครงการ.docx");
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
            string money = "";
            var query = db.NHA_GenForm(project_id, userID);
            if (query != null)
            {
                foreach (var item2 in query.ToList())
                {
                    projectname = item2.project_name;
                    day = item2.period.ToString();
                    money = item2.project_budget.ToString();
                }
            }

            string month = (Int32.Parse(day) / 30).ToString();
            double monneyBath = Convert.ToDouble(money);

            FindAndReplace(word, "[approve]", TextApprove.Text);
            FindAndReplace(word, "[projectName]", projectname);
            FindAndReplace(word, "[day]", day);
            FindAndReplace(word, "[month] ", month);
            FindAndReplace(word, "[budget]", monneyBath.ToString("N2"));
            FindAndReplace(word, "[budgetThai]", Thai(money));

            int num = 0;
            string committeeFirst = "";
            string committeeLast = "";
            string position = "";
            string commiteePosition = "";
            num = 0;
            var queryCommit = db.Committee_Select_employ(project_id);
            if (queryCommit != null)
            {
                foreach (var item2 in queryCommit.ToList())
                {
                    committeeFirst += (num + 1) + "."  + item2.first_name + (char)11;
                    committeeLast += item2.last_name + (char)11;
                    position += item2.position + (char)11;
                    commiteePosition += item2.Committee_type + (char)11;
                    num++;
                }
            }
            FindAndReplace(word, "[committeeFirst]", committeeFirst);
            FindAndReplace(word, "[committeeLast]", committeeLast);
            FindAndReplace(word, "[committeePrefix]", position);
            FindAndReplace(word, "[committeePosition]", commiteePosition);

            //----------------------------------------------------------------------------------------------------------

            string committeeFirst2 = "";
            string committeeLast2 = "";
            string position2 = "";
            string commiteePosition2 = "";

            int num2 = 0;
            var queryCommit2 = db.Committee_Select_check(project_id);
            if (queryCommit2 != null)
            {
                foreach (var item2 in queryCommit2.ToList())
                {
                    committeeFirst2 += (num2 + 1) + "." + item2.first_name + (char)11;
                    committeeLast2 += item2.last_name + (char)11;
                    position2 += item2.position + (char)11;
                    commiteePosition2 += item2.Committee_type + (char)11;
                    num2++;
                }
            }

            FindAndReplace(word, "[committeeCFirst]", committeeFirst2);
            FindAndReplace(word, "[committeeCLast]", committeeLast2);
            FindAndReplace(word, "[committeeCPrefix]", position2);
            FindAndReplace(word, "[committeeCPosition]", commiteePosition2);

            doc.Save();
            doc.Close(ref missing, ref missing, ref missing);
            word.Quit(ref missing, ref missing, ref missing);

            Response.ContentType = "Application/doc";
            Response.AppendHeader("Content-Disposition", "attachment; filename=แบบฟอร์มแจ้งได้รับอนุมัติโครงการ.docx");
            Response.TransmitFile(NewFile);
            Response.Flush();
            System.IO.File.Delete(NewFile);
            Response.End();
        }

        private void Print3()
        {
            string form = TextBoxForm.Text;
            string to = TextBoxTo.Text;
            string at = TextBoxAt.Text;
            string date = TextBoxDate.Text;
            //--------------------------------------------
            int projecID =Int32.Parse(ViewState["project_id"].ToString()); ;
            int period = Int32.Parse(ViewState["period"].ToString()); ;
            //--------------------------------------------
            string state = "meet1";
            db.FromToAt_insert(projecID, state, form, to, at, date);
            string SourceFile = Server.MapPath("~/FormTemplate/แบบฟอร์มขอเชิญเป็นประธานประชุมตรวจรับงาน.docx");
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
            string start = "";
            string stop = "";
            string employee = "";
            var query = db.NHA_GenForm_Meeting(projecID, period);
            if (query != null)
            {
                foreach (var item2 in query.ToList())
                {
                    projectname = item2.project_name;
                    day = item2.period.ToString();
                    money = item2.money.ToString();
                    start = item2.day_start;
                    stop = item2.day_end;
                    employee = item2.Employee;
                }
            }
            DateTime str = DateTime.ParseExact(start, "yyyy-MM-dd", CultureInfo.InvariantCulture);
            DateTime stp = DateTime.ParseExact(stop, "yyyy-MM-dd", CultureInfo.InvariantCulture);
            Thread.CurrentThread.CurrentCulture = new CultureInfo("th-TH");
            start = str.ToString("dd MMMM yyyy");
            stop = stp.ToString("dd MMMM yyyy");
            double monneyBath = Convert.ToDouble(money);

            FindAndReplace(word, "[period]", period);
            FindAndReplace(word, "[projectName]", projectname);
            FindAndReplace(word, "[employee]", employee);
            FindAndReplace(word, "[day]", day);
            FindAndReplace(word, "[dateStart]", start);
            FindAndReplace(word, "[dateEnd]", stop);
            FindAndReplace(word, "[budgetPeroid]", monneyBath.ToString("N2"));
            FindAndReplace(word, "[budgetThai]", Thai(money));

            string committeeCheck = "";

            int num2f = 1;
            var queryCommit2 = db.Committee_Select_check(projecID);
            if (queryCommit2 != null)
            {
                foreach (var item2 in queryCommit2.ToList())
                {
                    committeeCheck += (num2f) + "." + item2.position + "  -  " + item2.Committee_type + (char)11;
                    num2f++;
                }
            }
            FindAndReplace(word, "[committeeCheck]", committeeCheck);

            doc.Save();
            doc.Close(ref missing, ref missing, ref missing);
            word.Quit(ref missing, ref missing, ref missing);

            Response.ContentType = "Application/doc";
            Response.AppendHeader("Content-Disposition", "attachment; filename=แบบฟอร์มขอเชิญเป็นประธานประชุมตรวจรับงาน.docx");
            Response.TransmitFile(NewFile);
            Response.Flush();
            System.IO.File.Delete(NewFile);
            Response.End();
        }

        private void Print4()
        {
            string form = TextBoxForm.Text;
            string to = TextBoxTo.Text;
            string at = TextBoxAt.Text;
            string date = TextBoxDate.Text;
            //--------------------------------------------
            int projecID = Int32.Parse(ViewState["project_id"].ToString()); ;
            int period = Int32.Parse(ViewState["period"].ToString()); ;
            //--------------------------------------------
            string state = "meet2";
            db.FromToAt_insert(projecID, state, form, to, at, date);
            string SourceFile = Server.MapPath("~/FormTemplate/แบบฟอร์มขอเชิญประชุมตรวจรับงาน.docx");
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
            string money = "";
            string start = "";
            string stop = "";
            string employee = "";
            var query = db.NHA_GenForm_Meeting(projecID, period);
            if (query != null)
            {
                foreach (var item2 in query.ToList())
                {
                    projectname = item2.project_name;
                    day = item2.period.ToString();
                    money = item2.money.ToString();
                    start = item2.day_start;
                    stop = item2.day_end;
                    employee = item2.Employee;
                }
            }
            DateTime str = DateTime.ParseExact(start, "yyyy-MM-dd", CultureInfo.InvariantCulture);
            DateTime stp = DateTime.ParseExact(stop, "yyyy-MM-dd", CultureInfo.InvariantCulture);
            Thread.CurrentThread.CurrentCulture = new CultureInfo("th-TH");
            start = str.ToString("dd MMMM yyyy");
            stop = stp.ToString("dd MMMM yyyy");
            double monneyBath = Convert.ToDouble(money);

            FindAndReplace(word, "[period]", period);
            FindAndReplace(word, "[projectName]", projectname);
            FindAndReplace(word, "[employee]", employee);
            FindAndReplace(word, "[day]", day);
            FindAndReplace(word, "[dateStart]", start);
            FindAndReplace(word, "[dateEnd]", stop);
            FindAndReplace(word, "[budgetPeroid]", monneyBath.ToString("N2"));
            FindAndReplace(word, "[budgetThai]", Thai(money));

            string committeeCheck = "";

            int num2f = 1;
            var queryCommit2 = db.Committee_Select_check(projecID);
            if (queryCommit2 != null)
            {
                foreach (var item2 in queryCommit2.ToList())
                {
                    committeeCheck += (num2f) + "." + item2.position + "  -  " + item2.Committee_type + (char)11;
                    num2f++;
                }
            }
            FindAndReplace(word, "[committeeCheck]", committeeCheck);

            doc.Save();
            doc.Close(ref missing, ref missing, ref missing);
            word.Quit(ref missing, ref missing, ref missing);

            Response.ContentType = "Application/doc";
            Response.AppendHeader("Content-Disposition", "attachment; filename=แบบฟอร์มขอเชิญประชุมตรวจรับงาน.docx");
            Response.TransmitFile(NewFile);
            Response.Flush();
            System.IO.File.Delete(NewFile);
            Response.End();

        }

        private void Print5()
        {
            string form = TextBoxForm.Text;
            string to = TextBoxTo.Text;
            string at = TextBoxAt.Text;
            string date = TextBoxDate.Text;
            //-----------------------------------------------
            int projecID = Int32.Parse(ViewState["project_id"].ToString()); ;
            int period = Int32.Parse(ViewState["period"].ToString()); ;
            string state = "widen";
            db.FromToAt_insert(projecID, state, form, to, at, date);
            //-----------------------------------------------
            string SourceFile = Server.MapPath("~/FormTemplate/แบบฟอร์มขออนุมัติเบิกค่าจ้าง.docx");
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
            string money = "";
            string money2 = "";
            string conNum = "";
            string dateCon = "";
            string start = "";
            string stop = "";
            string dat = "";
            string year = "";
            string employee = "";
            var query = db.NHA_GenForm_widen(projecID, period);
            if (query != null)
            {
                foreach (var item2 in query.ToList())
                {
                    projectname = item2.project_name;
                    day = item2.Period.ToString();
                    money = item2.Contract_Money.ToString();
                    money2 = item2.money.ToString();
                    conNum = item2.contract_id.ToString();
                    dateCon = item2.day_contract;
                    start = item2.day_start;
                    stop = item2.day_end;
                    year = item2.year.ToString();
                    employee = item2.Employee;
                }
            }

            DateTime str = DateTime.ParseExact(start, "yyyy-MM-dd", CultureInfo.InvariantCulture);
            DateTime stp = DateTime.ParseExact(stop, "yyyy-MM-dd", CultureInfo.InvariantCulture);
            DateTime d = DateTime.ParseExact(dateCon, "yyyy-MM-dd", CultureInfo.InvariantCulture);
            Thread.CurrentThread.CurrentCulture = new CultureInfo("th-TH");
            start = str.ToString("dd MMMM yyyy");
            stop = stp.ToString("dd MMMM yyyy");
            dat = d.ToString("dd MMMM yyyy");
            double monneyBath = Convert.ToDouble(money);
            double monneyBath2 = Convert.ToDouble(money2);


            FindAndReplace(word, "[employee]", employee);
            FindAndReplace(word, "[period]", period);
            FindAndReplace(word, "[projectName]", projectname);
            FindAndReplace(word, "[contractNum]", conNum);
            FindAndReplace(word, "[dateContract]", dat);
            FindAndReplace(word, "[budget]", money);
            FindAndReplace(word, "[day]", day);
            FindAndReplace(word, "[dateStart]", start);
            FindAndReplace(word, "[dateEnd]", stop);
            FindAndReplace(word, "[withdraw]", monneyBath2.ToString("N2"));
            FindAndReplace(word, "[budgetThai1]", Thai(money));
            FindAndReplace(word, "[budgetThai2]", Thai(money2));
            FindAndReplace(word, "[budgetYear]", year);
            string committeeCheck = "";

            int num2f = 1;
            var queryCommit2 = db.Committee_Select_check(projecID);
            if (queryCommit2 != null)
            {
                foreach (var item2 in queryCommit2.ToList())
                {
                    committeeCheck += (num2f) + "." + item2.position + "  -  " + item2.Committee_type + (char)11;
                    num2f++;
                }
            }
            FindAndReplace(word, "[committeeCheck]", committeeCheck);

            doc.Save();
            doc.Close(ref missing, ref missing, ref missing);
            word.Quit(ref missing, ref missing, ref missing);

            Response.ContentType = "Application/doc";
            Response.AppendHeader("Content-Disposition", "attachment; filename=แบบฟอร์มขออนุมัติเบิกค่าจ้าง.docx");
            Response.TransmitFile(NewFile);
            Response.Flush();
            System.IO.File.Delete(NewFile);
            Response.End();

        }

        private void Print6()
        {
            int projecID = Int32.Parse(ViewState["project_id"].ToString()); ;

            string SourceFile = Server.MapPath("~/FormTemplate/สรุปแผนการดำเนินงาน.docx");
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
            Response.AppendHeader("Content-Disposition", "attachment; filename=สรุปแผนการดำเนินงาน.docx");
            Response.TransmitFile(NewFile);
            Response.Flush();
            System.IO.File.Delete(NewFile);
            Response.End();
        }

        public static string ThaiBaht2(string txt)
        {
            if(txt=="1")
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