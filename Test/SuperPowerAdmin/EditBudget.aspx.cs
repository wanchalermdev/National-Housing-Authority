using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Test.Data;

namespace Test.SuperPowerAdmin
{
    public partial class EditBudget : System.Web.UI.Page
    {
        NHADATABASEEntities1 db = new NHADATABASEEntities1();
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                ViewState["year"] = Request.QueryString["year"];
                int year = Int32.Parse(ViewState["year"].ToString());
                var query = db.SP_SuperPowerAdmin_Budget_SelectForUpdate(year);
                foreach (var item in query)
                {
                    TxtYear.Text = item.year.ToString();
                    TxtBudget.Text = item.budget.ToString();
                }
            }


        }

        protected void BtnAdd_Click(object sender, EventArgs e)
        {
            int year = Int32.Parse(ViewState["year"].ToString());
            decimal budget = Decimal.Parse(TxtBudget.Text);
            db.SP_SuperPowerAdmin_Budget_Update(year,budget);
            Response.Redirect("Createbudget.aspx");
        }
    }
}