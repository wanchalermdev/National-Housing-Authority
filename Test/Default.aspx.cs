using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Test
{
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["USER"] != null)
            {
                if (Session["USER_TYPE"].ToString() == "superadmin")
                {
                    // SADMIN
                    Response.Redirect("~/SuperPowerAdmin/HomeCreateProject.aspx");
                }

                if (Session["USER_TYPE"].ToString() == "officer")
                {
                    // NADMIN
                    Response.Redirect("~/AdminNHA/ViewStateProcess.aspx");
                }
            }
            else
            {
                Response.Redirect("~/Authentication/Login.aspx");
            }
        }

    }
}