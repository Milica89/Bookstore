using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SQLite;
using System.Data;

namespace Danulabs_bookstore
{
    public partial class SignUp : System.Web.UI.Page
    {
        bsdb baza = new bsdb();

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnconfirm_Click(object sender, EventArgs e)
        {
            lblusername.Text = "";
            lblpassword.Text = "";
            lblrepeatpassword.Text = "";
            string username = tbusername.Text.Trim();
            string password = tbpassword.Text.Trim();
            string repeatpassword = tbrepeatpassword.Text.Trim();            

            if (username != "")
            {
                if (password != "")
                {
                    if (repeatpassword == password)
                    {
                        baza.Connect();
                        baza.Open();
                        int cnt = baza.Add_UserAccount(username, password);
                        if (cnt == 1)
                        {
                            Session["username"] = tbusername.Text;
                            Response.Redirect("Books.aspx");
                        }
                        else
                        {
                            lblusername.Text = "This username is already taken";
                        }
                        baza.Close();
                    }
                    else
                    {
                        lblrepeatpassword.Text = "Passwords don't match";
                    }
                }
                else
                {
                    lblpassword.Text = "This field is mandatory!";
                }
            }
            else
            {
                lblusername.Text = "This field is mandatory!";
            }
        }
    }
}