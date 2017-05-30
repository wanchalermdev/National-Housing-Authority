using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Test.Data;

namespace Test.AdminNHA
{
    public partial class ResearchDetail : System.Web.UI.Page
    {
        static NHADATABASEEntities1 db = new NHADATABASEEntities1();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                ViewState["researcher_id"] = Request.QueryString["rid"];
                ViewState["pid"] = Request.QueryString["pid"];
                loadResearcherDetail();
            }       
        }

        private void loadResearcherDetail()
        {
            int rid = Int32.Parse(ViewState["researcher_id"].ToString());
            var query = db.Researcher_Select_Detail(rid);
            foreach (var item in query.ToList())
            {
                TextBoxPname.Text = item.pname;
                TextBoxFname.Text = item.fname;
                TextBoxLname.Text = item.lname;
                TextBoxGender.Text = item.gender;
                TextBoxID.Text = item.id_card;
                TextBoxBirth.Text = item.birthday;
                TextBoxRole.Text = item.role;
                TextBoxPosition.Text = item.position;
                TextBoxIns.Text = item.institution;
                TextBoxEduc.Text = item.education;
                TextBoxDegree.Text = item.Degree;
                TextBoxMajor.Text = item.major;
                TextBoxExp.Text = item.experience;
                TextBoxTel.Text = item.tel;
                TextBoxFax.Text = item.fax;
                TextBoxPhone.Text = item.phone;
                TextBoxEmail.Text = item.email;
            }
        }

        protected void ButtonEdit_Click(object sender, EventArgs e)
        {
            int rid = Int32.Parse(ViewState["researcher_id"].ToString());
            db.Researcher_Edit(rid,
                TextBoxRole.Text,
                TextBoxPname.Text,
                TextBoxFname.Text,
                TextBoxLname.Text,
                TextBoxPosition.Text,
                TextBoxIns.Text,
                TextBoxID.Text,
                TextBoxBirth.Text,
                TextBoxGender.Text,
                TextBoxEduc.Text,
                TextBoxDegree.Text,
                TextBoxMajor.Text,
                TextBoxExp.Text,
                TextBoxTel.Text,
                TextBoxFax.Text,
                TextBoxPhone.Text,
                TextBoxEmail.Text);
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            Response.Redirect("AddResearcher.aspx?id=" + ViewState["pid"].ToString());
        }
    }
}