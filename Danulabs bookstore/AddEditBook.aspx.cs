using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SQLite;
using System.Data;
using System.Text.RegularExpressions;

namespace Danulabs_bookstore
{

    public partial class AddEditBook : System.Web.UI.Page
    {
        bsdb baza = new bsdb();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["username"] == null)
            {
                Response.Redirect("Home.aspx");
            }
            else
            {
                if (Session["selected_book"] == null)
                {
                    lbladdeditbook.Text = "Add new book";
                }
                else
                {
                    if (!Page.IsPostBack)
                    {
                        baza.Connect();
                        baza.Open();
                        string selected_isbn = baza.Get_ISBN(Session["selected_book"].ToString());
                        string selected_title = baza.Get_Title(Session["selected_book"].ToString());
                        string selected_author = baza.Get_Author(Session["selected_book"].ToString());
                        string selected_genre = baza.Get_Genre(Session["selected_book"].ToString());
                        lbladdeditbook.Text = String.Format("Edit {0}", selected_title);
                        tbisbn.Text = selected_isbn;
                        tbtitle.Text = selected_title;
                        tbauthor.Text = selected_author;
                        tbgenre.Text = selected_genre;
                        baza.Close();
                    }
                }
            }

        }

        protected void btnsave_Click(object sender, EventArgs e)
        {
            lblauthor.Text = "";
            lblisbn.Text = "";
            lbltitle.Text = "";
            lblgenre.Text = "";
            lblerror.Text = "";
            string isbn = tbisbn.Text.Trim();
            string title = tbtitle.Text.Trim();
            string author = tbauthor.Text.Trim();
            string genre = tbgenre.Text.Trim();

            if (isbn != "")
            {
                if (title != "")
                {
                    if (author != "")
                    {
                        if (genre != "")
                        {

                            if (isbn.Length == 13)
                            {
                                
                                bool res = Regex.IsMatch(isbn, "^[0-9]{13}$");
                                if (res)
                                {
                                    if (isbn.StartsWith("978") || isbn.StartsWith("979"))
                                    {
                                        decimal res1 = Convert.ToDecimal(isbn.Substring(3, 5));
                                        if (res1 < 65000 || res1 > 69999)
                                        {
                                            int check = 0;
                                            for (int i = 1; i < 14; i++)
                                            {
                                                int res2 = Convert.ToInt16(isbn.Substring(i - 1, 1));
                                                if (i % 2 != 0)
                                                {
                                                    check = check + res2;
                                                }
                                                else
                                                {
                                                    check = check + 3 * res2;
                                                }
                                            }
                                            if (check % 10 == 0)
                                            {
                                                baza.Connect();
                                                baza.Open();
                                                if (Session["selected_book"] == null)
                                                {
                                                    int cnt = baza.Add_Book(isbn, title, author, genre);
                                                    if (cnt == 1)
                                                    {
                                                        Response.Redirect("Books.aspx");
                                                    }
                                                    else
                                                    {
                                                        lblerror.Text = "Adding book failed";
                                                    }
                                                }
                                                else
                                                {
                                                    int cnt = baza.Update_Book(Session["selected_book"].ToString(), isbn, title, author, genre);
                                                    if (cnt == 1)
                                                    {
                                                        Response.Redirect("Books.aspx");
                                                    }
                                                    else
                                                    {
                                                        lblerror.Text = "Editing book failed";
                                                    }
                                                }
                                                baza.Close();
                                            }
                                            else
                                            {
                                                lblisbn.Text = "invalid ISBN";
                                            }
                                        }
                                        else
                                        {
                                            lblisbn.Text = "invalid ISBN";
                                        }

                                    }
                                    else
                                    {
                                        lblisbn.Text = "invalid ISBN";
                                    }
                                }
                                else
                                {
                                    lblisbn.Text = "ISBN must contain numbers only!";
                                }
                            }
                            else
                            {
                                if (isbn.Length < 13)
                                {
                                    lblisbn.Text = "ISBN too short!";
                                }
                                else
                                {
                                    lblisbn.Text = "ISBN too long!";
                                }
                            }
                        }
                        else
                        {
                            lblgenre.Text = "This field is mandatory!";
                        }
                    }
                    else
                    {
                        lblauthor.Text = "This field is mandatory!";
                    }
                }
                else
                {
                    lbltitle.Text = "This field is mandatory!";
                }
            }
            else
            {
                lblisbn.Text = "This field is mandatory!";
            }
            
        }

        protected void lbcancel_Click(object sender, EventArgs e)
        {
            Session["selected_book"] = null;
            Response.Redirect("Books.aspx");
        }

    }
}