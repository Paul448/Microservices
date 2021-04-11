using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using GatewayService.Controllers;

namespace GatewayService.Views
{
    public partial class Gatehome : System.Web.UI.Page
    {
        string AuthID;
        protected void Page_Load(object sender, EventArgs e)
        {
            var uri = new Uri(HttpContext.Current.Request.Url.AbsoluteUri);
            var query = HttpUtility.ParseQueryString(uri.Query);
            AuthID = query.Get("auth");
            lblAuth.Text = "AuthID: " + AuthID;
            if(AuthID == "" | AuthID is null | AuthID == " ")
            {
                lblInfo.Text = "Bitte melden sie sich an!";
            }
            else
            {
                lblInfo.Text = "";
            }
        }

        protected void Page_Init(object sender, EventArgs e)
        {

        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            Response.Redirect("https://localhost:44330/Views/Login");
        }

        protected void btnAdmin_Click(object sender, EventArgs e)
        {
            Response.Redirect("https://localhost:44330/Views/Adminpanel?auth=" + AuthID);
        }

        protected void btnTurnier_Click(object sender, EventArgs e)
        {
            Response.Redirect("https://localhost:44399/Views/Turnierverwaltung?auth=" + AuthID);
        }

        protected void btnMannschaft_Click(object sender, EventArgs e)
        {
            Response.Redirect("https://localhost:44336/Views/Mannschaftsverwaltung?auth=" + AuthID);
            //44336
        }

        protected void btnPS_Click(object sender, EventArgs e)
        {
            Response.Redirect("https://localhost:44328/Views/Personenverwaltung?auth=" + AuthID);
            
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
            Response.Redirect("https://localhost:44330/Views/Login");
        }
    }
}