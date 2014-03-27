using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace Danulabs_bookstore
{
    public partial class Site1 : System.Web.UI.MasterPage
    {
        bsdb baza = new bsdb();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["username"] == null)
            {
                pnlsignupform.Visible = true;
                pnlloginform.Visible = true;
                pnlloggedin.Visible = false;

            }
            else
            {
                pnlsignupform.Visible = false;
                pnlloginform.Visible = false;
                pnlloggedin.Visible = true;
                lblloggedin.Text = String.Format("Hello, {0}! ", Session["username"]);
            }
        }

        protected void btnlogin_Click(object sender, EventArgs e)
        {
            lblerror.Text = "";
            if (tbloginusername.Text.Trim() != "" && tbloginpassword.Text.Trim() != "")
            {
               
                baza.Connect();
                baza.Open();
                bool cnt1 = baza.User_Exists(tbloginusername.Text);
                if (cnt1)
                {
                    bool cnt2 = baza.Password_OK(tbloginusername.Text, tbloginpassword.Text);
                    if (cnt2)
                    {
                        Session["username"] = tbloginusername.Text;
                        Response.Redirect("Books.aspx");

                    }
                    else
                    {
                        lblerror.Text = "Incorrect password!";
                    }
                }
                else
                {
                    lblerror.Text = "Username doesn't exist!";
                }
                baza.Close();
            }
        }

        protected void lbsignout_Click(object sender, EventArgs e)
        {
            Session.Abandon();
            Response.Redirect("Home.aspx");
            
        }

        
    }
}