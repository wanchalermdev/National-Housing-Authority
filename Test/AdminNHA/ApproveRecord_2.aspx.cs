using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Test.Data;
namespace Test.AdminNHA
{
    public partial class ApproveRecord_2 : System.Web.UI.Page
    {
        static NHADATABASEEntities1 db = new NHADATABASEEntities1();
        protected void Page_Load(object sender, EventArgs e)
        {

            ViewState["project_id"] = Request.QueryString["id"];
            System.Data.Entity.Core.Objects.ObjectParameter result = new System.Data.Entity.Core.Objects.ObjectParameter("result", typeof(int));
            var stateTORRequest = db.Get_Project_State(Int32.Parse(ViewState["project_id"].ToString()), 7, result);
            if(Int32.Parse(result.Value.ToString()) >= 7)
            {
                Response.Redirect("/AdminNHA/AddResearcher.aspx?id="+ ViewState["project_id"].ToString());
            }

            LoadData();
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            int projectID = Int32.Parse(ViewState["project_id"].ToString());
            if (Page.IsValid)
            {
                NHADATABASEEntities1 db = new NHADATABASEEntities1();

                string conNum = TextboxNum.Text;
                string dateValue = TextboxDate.Text;
                string comment = TextboxComment.Text;
                int period = Int32.Parse(TextboxPeriod.Text);
                decimal budget = decimal.Parse(TextboxBudgetCon.Text);
                string Employee = TextboxEmployee.Text;

                double day = Convert.ToDouble(period);
                DateTime start = DateTime.Parse(dateValue);
                DateTime end = start.AddDays(day);
                string str = start.AddDays(1).ToString("yyyy-MM-dd");
                //TextBox1.Text = end.ToString("yyyy-MM-dd");
                db.Insert_Contract(projectID, conNum, dateValue, comment, str, end.ToString("yyyy-MM-dd"),Employee,period,budget);


                int user_id = Int32.Parse(Session["USER"].ToString());
                int project_id = Int32.Parse(ViewState["project_id"].ToString());
                db.Update_Project_State(user_id, project_id, 7);
                Response.Redirect("/AdminNHA/AddResearcher.aspx?id=" + ViewState["project_id"].ToString());

            }
        }

        private void LoadData()
        {
            //using (NHADATABASEEntities1 db = new NHADATABASEEntities1())
            //{
            //    int id = Int32.Parse(ViewState["project_id"].ToString());
            //    tablePeriod.DataSource = db.Select_Period(id);
            //    tablePeriod.DataBind();
            //}
        }

        protected void TextboxDateBudgetCon_TextChanged(object sender, EventArgs e)
        {
            int projectID = Int32.Parse(ViewState["project_id"].ToString());
            var query = db.Select_BudgetForCheck(projectID);
            string budgetRead = "";
            try
            {
                foreach(var item in query)
                {
                    budgetRead = item.project_budget.ToString();
                }
            }
            catch { }
            double budget = double.Parse(budgetRead, System.Globalization.CultureInfo.InvariantCulture);
            double fillbudget = double.Parse(TextboxBudgetCon.Text.ToString(), System.Globalization.CultureInfo.InvariantCulture);
            if (fillbudget > budget)
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('งบประมาณตามสัญญาเกินงบประมาณที่ตั้งไว้')", true);
                TextboxBudgetCon.Text = "";
            }
           
        }

        protected void TextboxPeriod_TextChanged(object sender, EventArgs e)
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
            int fillPeriod = Int32.Parse(TextboxPeriod.Text.ToString());
            if (fillPeriod > periodRead)
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('จำนวนวันตามสัญญาเกินจำนวนวันที่กำหนด')", true);
                TextboxPeriod.Text = "";              
            }
        }


    }
}