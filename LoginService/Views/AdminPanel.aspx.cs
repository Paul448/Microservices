using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MySql.Data.MySqlClient;

namespace LoginService.Views
{
    public partial class AdminPanel : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            var uri = new Uri(HttpContext.Current.Request.Url.AbsoluteUri);
            var query = HttpUtility.ParseQueryString(uri.Query);
            string AuthID = query.Get("auth");
            if(Global.Verwalter.CheckCode(AuthID))
            {
                Load_Users();
            }
            else
            {
                lblinfo.Text = "Code ungültig";
            }

        }

        void Load_Users()
        {
            string cnst = "Server=localhost;Database=microservicespro;Uid=root;";
            MySqlConnection con = new MySqlConnection(cnst);
            TUSERS.Rows.Clear();
            try
            {
                con.Open();
                MySqlCommand cmd = new MySqlCommand("select * from users", con);
                MySqlDataReader reader = cmd.ExecuteReader();
                while(reader.Read())
                {
                    TableRow tr = new TableRow();
                    TableCell tc = new TableCell();
                    tc.Text = reader.GetString(0);
                    tr.Cells.Add(tc);
                    tc = new TableCell();
                    tc.Text = reader.GetString(4);
                    tr.Cells.Add(tc);
                    tc = new TableCell();
                    tc.Text = reader.GetString(1);
                    tr.Cells.Add(tc);
                    tc = new TableCell();
                    tc.Text = reader.GetString(2);
                    tr.Cells.Add(tc);
                    tc = new TableCell();
                    tc.Text = reader.GetString(3);
                    tr.Cells.Add(tc);
                    TUSERS.Rows.Add(tr);
                }
                con.Close();
            } 
            catch(Exception e)
            {

            }
        }
    }
}