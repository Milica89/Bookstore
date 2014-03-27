using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace Danulabs_bookstore
{
    public partial class Books : System.Web.UI.Page
    {
        bsdb baza = new bsdb();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["username"] == null)
            {
                Response.Redirect("Home.aspx");
            }       
        }
           
        protected void btnadd_click(object sender, EventArgs e)
        {
            Response.Redirect("AddEditBook.aspx");
        }

        protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            e.Cancel = true;
            baza.Connect();
            baza.Open();
            TableCell isbn_cell = GridView1.Rows[e.RowIndex].Cells[0];            
            string bookid = baza.Get_BookID(isbn_cell.Text);
            baza.Delete_Book(bookid);
            GridView1.DataBind();
            baza.Close();
        }

        protected void GridView1_SelectedIndexChanging(object sender, GridViewSelectEventArgs e)
        {
            e.Cancel = true;
            baza.Connect();
            baza.Open();            
            TableCell isbn_cell = GridView1.Rows[e.NewSelectedIndex].Cells[0];
            string bookid = baza.Get_BookID(isbn_cell.Text);
            Session["selected_book"] = bookid;
            baza.Close();
            Response.Redirect("AddEditBook.aspx");
        }

        protected void GridView1_RowCreated(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.Header)
            {
                GridView HeaderGrid = (GridView)sender;
                GridViewRow HeaderGridRow = new GridViewRow(0, 0, DataControlRowType.Header, DataControlRowState.Insert);
                TableCell HeaderCell = new TableCell();
                HeaderCell.Text = "ISBN";
                HeaderGridRow.Cells.Add(HeaderCell);
                
                HeaderCell = new TableCell();
                HeaderCell.Text = "Title";                
                HeaderGridRow.Cells.Add(HeaderCell);

                HeaderCell = new TableCell();
                HeaderCell.Text = "Author";
                HeaderGridRow.Cells.Add(HeaderCell);

                HeaderCell = new TableCell();
                HeaderCell.Text = "Genre";
                HeaderGridRow.Cells.Add(HeaderCell);

                HeaderCell = new TableCell();
                HeaderCell.Text = "Action";
                HeaderCell.ColumnSpan = 2;
                HeaderGridRow.Cells.Add(HeaderCell);

                GridView1.Controls[0].Controls.AddAt(0, HeaderGridRow);

            }
        }
               
    }
}