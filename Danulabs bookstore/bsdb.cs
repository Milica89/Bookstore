using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SQLite;
using System.Web.Configuration;

namespace Danulabs_bookstore
{

    class bsdb
    {
        String conn_Str;
        SQLiteConnection conn;
        SQLiteCommand sql;
        String sql_cmd;

        public bsdb()
        {
            conn_Str = WebConfigurationManager.ConnectionStrings["DanulabsBookstore"].ConnectionString;
        }

        public bsdb(String ps_DbFile)
        {
            conn_Str = String.Format("Data Source={0}", ps_DbFile);
        }


        public int Connect()
        {
            conn = new SQLiteConnection(conn_Str);

            return 1;
        }

        public Boolean Open()
        {
            Boolean res = true;

            try
            {
                conn.Open();
            }
            catch
            {
                res = false;
            }

            return res;
        }

        public Boolean Close()
        {
            Boolean res = true;

            try
            {
                conn.Close();
            }
            catch
            {
                res = false;
            }

            return res;
        }

        private SQLiteCommand sqll_cmd(String pc_SQL)
        {
            sql = new SQLiteCommand(pc_SQL, conn);

            return sql;
        }

        public Boolean User_Exists(String pc_UserName)
        {
            sql_cmd = String.Format("SELECT COUNT(*) FROM useraccount t WHERE t.username='{0}' AND NOT t.isdeleted", pc_UserName);

            sql = sqll_cmd(sql_cmd);
            object cnt = sql.ExecuteScalar();

            return cnt.ToString() != "0";
        }

        public Boolean Password_OK(String pc_UserName, String pc_Password)
        {
            sql_cmd = String.Format("SELECT COUNT(*) FROM useraccount t WHERE t.username='{0}' AND t. password='{1}' AND NOT t.isdeleted", pc_UserName, pc_Password);

            sql = sqll_cmd(sql_cmd);
            object cnt = sql.ExecuteScalar();

            return (cnt.ToString() != "0");
        }

        public String Get_UserAccountID(String pc_UserName)
        {
            sql_cmd = String.Format("SELECT t.useraccountid FROM useraccount t WHERE t.username='{0}' AND NOT t.isdeleted", pc_UserName);

            sql = sqll_cmd(sql_cmd);
            object id = sql.ExecuteScalar();

            return id.ToString();
        }

        public String Get_BookID(String pc_ISBN)
        {
            sql_cmd = String.Format("SELECT t.bookid FROM book t WHERE t.isbn='{0}' AND NOT t.isdeleted", pc_ISBN);

            sql = sqll_cmd(sql_cmd);
            object id = sql.ExecuteScalar();

            return id.ToString();
        }

        public String Get_Title(String pc_BookID)
        {
            sql_cmd = String.Format("SELECT t.title FROM book t WHERE t.bookid='{0}'", pc_BookID);

            sql = sqll_cmd(sql_cmd);
            object title = sql.ExecuteScalar();

            return title.ToString();
        }

        public String Get_ISBN(String pc_BookID)
        {
            sql_cmd = String.Format("SELECT t.isbn FROM book t WHERE t.bookid='{0}'", pc_BookID);

            sql = sqll_cmd(sql_cmd);
            object isbn = sql.ExecuteScalar();

            return isbn.ToString();
        }

        public String Get_Author(String pc_BookID)
        {
            sql_cmd = String.Format("SELECT t.author FROM book t WHERE t.bookid='{0}'", pc_BookID);

            sql = sqll_cmd(sql_cmd);
            object author = sql.ExecuteScalar();

            return author.ToString();
        }

        public String Get_Genre(String pc_BookID)
        {
            sql_cmd = String.Format("SELECT t.genre FROM book t WHERE t.bookid='{0}'", pc_BookID);

            sql = sqll_cmd(sql_cmd);
            object genre = sql.ExecuteScalar();

            return genre.ToString();
        }

        public int Delete_Book(String pc_BookID)
        {
            sql_cmd = String.Format("UPDATE book SET isdeleted=1 WHERE bookid='{0}' AND NOT isdeleted", pc_BookID);

            sql = sqll_cmd(sql_cmd);
            int cnt = sql.ExecuteNonQuery();

            return cnt;
        }

        public int Add_UserAccount(String pc_UserName, String pc_Password)
        {
            int cnt = -1;
            sql_cmd = String.Format("INSERT INTO useraccount (useraccountid, username, password) VALUES ('{0}', '{1}', '{2}')", Guid.NewGuid().ToString(), pc_UserName, pc_Password);
            sql = sqll_cmd(sql_cmd);
            cnt = sql.ExecuteNonQuery();
            return cnt;
        }

        public int Add_Book(String pn_ISBN, String pc_Title, String pc_Author, String pc_Genre)
        {
            int cnt = -1;
            sql_cmd = String.Format("INSERT INTO book (bookid, isbn, title, author, genre) VALUES ('{0}', '{1}', '{2}', '{3}', '{4}')", Guid.NewGuid().ToString(), pn_ISBN, pc_Title, pc_Author, pc_Genre);
            sql = sqll_cmd(sql_cmd);
            cnt = sql.ExecuteNonQuery();
            return cnt;
        }

        public int Update_Book(String pc_BookID, String pn_ISBN, String pc_Title, String pc_Author, String pc_Genre)
        {
            int cnt = -1;
            sql_cmd = String.Format("UPDATE book SET isbn={1}, title='{2}', author='{3}', genre='{4}' WHERE bookid='{0}'", pc_BookID, pn_ISBN, pc_Title, pc_Author, pc_Genre);
            sql = sqll_cmd(sql_cmd);
            cnt = sql.ExecuteNonQuery();
            return cnt;
        }

    }

}
