using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Test.Data;
namespace Test.Authentication
{
    public partial class Login : System.Web.UI.Page
    {
        NHADATABASEEntities1 db = new NHADATABASEEntities1();
        protected void Page_Load(object sender, EventArgs e)
        {
           
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            if (Page.IsValid)
            {
                var query = db.SP_User_Login(UserName.Text, Password.Text);
                if (query != null)
                {
                    foreach (var item in query.ToList())
                    {
                        Session["USER"] = item.user_id;
                        Session["USER_FULLNAME"] = item.first_name + " " + item.last_name;
                        Session["USER_TYPE"] = item.type;
                    }

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
                        Response.Redirect("Login.aspx");
                    }
                }
                else
                {
                    Response.Redirect("Login.aspx");
                }
            }
            else
            {
                Response.Redirect("Login.aspx");
            }
            
          
        }
    }
}