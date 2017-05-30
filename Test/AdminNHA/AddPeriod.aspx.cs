using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;
using Test.Data;
using System.Globalization;
using System.Threading;
using Test.Function;

namespace Test.AdminNHA
{
    public partial class AddPeriod : System.Web.UI.Page
    {
        NHADATABASEEntities1 db = new NHADATABASEEntities1();
        ConvertFunction cf = new ConvertFunction();
        double money = 0;
        string dateMount = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            ViewState["project_id"] = Request.QueryString["id"];

            int pid = Int32.Parse(ViewState["project_id"].ToString());
            var data = db.Select_Period_DateMoney(pid);
            foreach (var item in data.ToList())
            {
                money = Double.Parse(item.project_budget.ToString());
                dateMount = item.day_contract.ToString();
            }


            //budget.Text = money.ToString();
        }

        private void CheckPeriod()
        {
            
        }

        protected void ddldetails_SelectedIndexChanged(object sender, EventArgs e)
        {
            //if( DocType.SelectedItem.Value == "อื่นๆ")
            //{
            //    typeOther.Visible = false;
            //}
        }

        protected void Btnsave_Onclick(object sender, EventArgs e)
        {
            using (NHADATABASEEntities1 db = new NHADATABASEEntities1())
            {
                 //var data = db.S
            }
        }

        protected void budget_TextChanged(object sender, EventArgs e)
        {
            int projectID = Int32.Parse(ViewState["project_id"].ToString());
            var query = db.Select_BudgetForCheck(projectID);
            string budgetRead = "";
            try
            {
                foreach (var item in query)
                {
                    budgetRead = item.project_budget.ToString();
                }
            }
            catch { }
            double budgetCheck = double.Parse(budgetRead, System.Globalization.CultureInfo.InvariantCulture);
            double fillbudget = double.Parse(budget.Text.ToString(), System.Globalization.CultureInfo.InvariantCulture);
            if (fillbudget > budgetCheck)
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('งบประมาณเกินงบประมาณตามสัญญา')", true);
                budget.Text = "";
            }
        }

        protected void percent_TextChanged(object sender, EventArgs e)
        {

        }

        protected void day_TextChanged(object sender, EventArgs e)
        {

            int projectID = Int32.Parse(ViewState["project_id"].ToString());
            var query = db.Select_BudgetForCheck(projectID);
            int periodRead = 0;
            try
            {
                foreach (var item in query)
                {
                    periodRead = Int32.Parse(item.period.ToString());
                }
            }
            catch { }
            int fillPeriod = Int32.Parse(day.Text.ToString());
            if (fillPeriod > periodRead)
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('จำนวนวันตามสัญญาเกินจำนวนวันที่กำหนด')", true);
                day.Text = "";
            }
        }

        protected void btnAdd_Click(object sender, EventArgs e)
        {

            //int pid = Int32.Parse(ViewState["project_id"].ToString());
            //string nd = nameDoc.Text.ToString();
            //string dt = DocType.Text.ToString();
            //string numd = numDoc.Text.ToString();
            //db.Project_Document_Insert(pid, nd, dt, numd);
        }

        

        protected void BtnSave_Click(object sender, EventArgs e)
        {
            if (Page.IsValid)
            {
                //percent.Text = ((Double.Parse(budget.Text.ToString()) / money) * 100.0).ToString();
                double DayCount = Convert.ToDouble(day.Text);
                DateTime start = DateTime.Parse(dateMount);
                DateTime end = start.AddDays(DayCount);
                string percen = ((Double.Parse(budget.Text.ToString()) / money) * 100.0).ToString();
                int pid = Int32.Parse(ViewState["project_id"].ToString());
                string bg = budget.Text.ToString();
                //string pc = percent.Text.ToString();
                int d = Int32.Parse(day.Text.ToString());
                string ds = cf.DateToThai(end.ToString("yyyy-MM-dd"));
                string dt = textarea.Text.ToString();
                db.Period_insert2(pid, bg, percen, d, ds, dt);
                Response.Redirect("AddResearcher.aspx?id=" + ViewState["project_id"].ToString());
            }
           
        }
    }
}