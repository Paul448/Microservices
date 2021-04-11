// Microservices
// Autor: Paul Jansen
// AI118 PRO
//
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
            if(AuthID == "")
            {
                AuthID = "-1";
                lblinfo.Text = "Authentifizierung fehlgeschlagen!";
            }
            else
            {
                if (Global.Verwalter.CheckCode(AuthID))
                {
                    Load_Users();
                }
                else
                {
                    lblinfo.Text = "Authentifizierung fehlgeschlagen!";
                }
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

        protected void DirectTO(object sender, EventArgs e)
        {
            Button test = (Button)sender;
            Uri uri = new Uri(HttpContext.Current.Request.Url.AbsoluteUri);
            var query = HttpUtility.ParseQueryString(uri.Query);
            string AuthID = query.Get("auth");
            string ID = test.ID.Replace("ä", "/").Replace("ö", ":");
            string Link = "https://" + ID + "?auth=" + AuthID;
            Response.Redirect(Link);
        }

        protected void LogoutClick(object sender, EventArgs e)
        {
            Response.Redirect("https://localhost:44338/Views/Gatehome");
        }
    }
}