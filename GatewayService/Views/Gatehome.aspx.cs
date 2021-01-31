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
    }
}