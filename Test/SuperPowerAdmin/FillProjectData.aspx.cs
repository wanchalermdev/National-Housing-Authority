using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Test.Data;

namespace Test.SuperPowerAdmin
{
    public partial class FillProjectData : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LoadBudgetYear();
            }
        }

        private void LoadBudgetYear()
        {
            using (NHADATABASEEntities1 db = new NHADATABASEEntities1())
            {
                var bgYear = db.SP_SuperPowerAdmin_Budget_Select();

                string[] year = new string[4];
                int i = 0;

                foreach (var item in bgYear)
                {
                    year[i] = item.year.ToString();
                    i++;
                }
                DDbudgetYear1.Items.Clear();
                DDbudgetYear2.Items.Clear();
                DDbudgetYear3.Items.Clear();
                DDbudgetYear4.Items.Clear();

                foreach (string y in year)
                {
                    DDbudgetYear1.Items.Add(y);
                    DDbudgetYear2.Items.Add(y);
                    DDbudgetYear3.Items.Add(y);
                    DDbudgetYear4.Items.Add(y);
                }
                DDbudgetYear1.Items.Insert(0, new ListItem("กรุณาเลือกปี", "0"));
                DDbudgetYear2.Items.Insert(0, new ListItem("กรุณาเลือกปี", "0"));
                DDbudgetYear3.Items.Insert(0, new ListItem("กรุณาเลือกปี", "0"));
                DDbudgetYear4.Items.Insert(0, new ListItem("กรุณาเลือกปี", "0"));
            }
        }


        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            if (Page.IsValid)
            {
                // Project Name & ProcessYear
                lbProjectName.InnerText = TxtProjectName.Text;
                lbProcessYear.InnerText = TxtProcessYear.Text;
                // Budget Years
                lbBudgetYear1.InnerText = DDbudgetYear1.SelectedItem.Text;
                lbBudgetYear2.InnerText = DDbudgetYear2.SelectedItem.Text;
                lbBudgetYear3.InnerText = DDbudgetYear3.SelectedItem.Text;
                lbBudgetYear4.InnerText = DDbudgetYear4.SelectedItem.Text;
                // Budget Money I Years
                lbTextBox1.InnerText = TbBudget1.Text;
                lbTextBox2.InnerText = TbBudget2.Text;
                lbTextBox3.InnerText = TbBudget3.Text;
                lbTextBox4.InnerText = TbBudget4.Text;
                // Peroid Total Budget
                lbPeriod.InnerText = TxtPeroid.Text;
                lbTxtBudget.InnerText = Request.Form[TxtBudget.UniqueID];
                // Budget plan
                Tb10.InnerText = Text10.Text;
                Tb11.InnerText = Text11.Text;
                Tb12.InnerText = Text12.Text;
                Tb1.InnerText = Text1.Text;
                Tb2.InnerText = Text2.Text;
                Tb3.InnerText = Text3.Text;
                Tb4.InnerText = Text4.Text;
                Tb5.InnerText = Text5.Text;
                Tb6.InnerText = Text6.Text;
                Tb7.InnerText = Text7.Text;
                Tb8.InnerText = Text8.Text;
                Tb9.InnerText = Text9.Text;
                TbTotalMoney.InnerText = Request.Form[Total.UniqueID];
                TbTotalPeroid.InnerText = Request.Form[TextBox3.UniqueID];
                // Run Modal
                ScriptManager.RegisterStartupScript(Page, Page.GetType(), "myModal", "$('#myModal').modal();", true);
                upModal.Update();
            }

        }

        protected void BtnOk_OnClick(object sender, EventArgs e)
        {
            int nowYear = Int32.Parse(TxtProcessYear.Text.ToString());
            string projectName = TxtProjectName.Text.ToString();

            // Budget Plan
            int peroid = Int32.Parse(TxtPeroid.Text.ToString());
            decimal october = decimal.Parse(Text10.Text.ToString());
            decimal november = decimal.Parse(Text11.Text.ToString());
            decimal december = decimal.Parse(Text12.Text.ToString());
            decimal january = decimal.Parse(Text1.Text.ToString());
            decimal february = decimal.Parse(Text2.Text.ToString());
            decimal march = decimal.Parse(Text3.Text.ToString());
            decimal april = decimal.Parse(Text4.Text.ToString());
            decimal may = decimal.Parse(Text5.Text.ToString());
            decimal june = decimal.Parse(Text6.Text.ToString());
            decimal july = decimal.Parse(Text7.Text.ToString());
            decimal august = decimal.Parse(Text8.Text.ToString());
            decimal september = decimal.Parse(Text9.Text.ToString());

            // Budget All
            decimal projectBudget1 = decimal.Parse(TbBudget1.Text.ToString());
            int budget_year1 = Int32.Parse(DDbudgetYear1.SelectedItem.Text.ToString());
            decimal projectBudget2 = decimal.Parse(TbBudget2.Text.ToString());
            int budget_year2 = Int32.Parse(DDbudgetYear2.SelectedItem.Text.ToString());
            decimal projectBudget3 = decimal.Parse(TbBudget3.Text.ToString());
            int budget_year3 = Int32.Parse(DDbudgetYear3.SelectedItem.Text.ToString());
            decimal projectBudget4 = decimal.Parse(TbBudget4.Text.ToString());
            int budget_year4 = Int32.Parse(DDbudgetYear4.SelectedItem.Text.ToString());

            int id = 0;
            string pjname = "";
            // Save Data To Database
            using (NHADATABASEEntities1 db = new NHADATABASEEntities1())
            {

                var data = db.SP_SuperPowerAdmin_ProjectInfo_Create(projectName, nowYear, 1, peroid,
                     budget_year1, budget_year2, budget_year3, budget_year4,
                     projectBudget1, projectBudget2, projectBudget3, projectBudget4);
                foreach (var item in data)
                {
                    id = item.project_id;
                    pjname = item.project_name;
                }
                db.SP_SuperPowerAdmin_Budgetplan_Create(id, nowYear, january, february, march, april,
                    may, june, july, august, september, october, november, december);
            }

            // Redirect To Add Committee
            Response.Redirect("committee.aspx?id=" + id + "&name=" + pjname);
        }

        protected void BtnCancel_OnClick(object sender, EventArgs e)
        {
            Response.Redirect("HomeCreateProject.aspx");
        }
    }
}