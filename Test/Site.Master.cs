using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Test
{
    public partial class SiteMaster : MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["USER"] != null)
            {
                SessionName.Text = Session["USER_FULLNAME"].ToString();
            }
            else
            {
                mainVavbar.Visible = false;
                //Response.Redirect("~/Authentication/Login.aspx");
            }
        }


        protected void Logout(object sender, EventArgs e)
        {
            Session.RemoveAll();
            Response.Redirect("~/Authentication/Login.aspx");
        }
    }
}