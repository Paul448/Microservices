using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Mannschaftsverwaltung.Views
{
    public partial class Mannschaftsverwaltung : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        } 

        public void Auth()
        {
            var uri = new Uri(HttpContext.Current.Request.Url.AbsoluteUri);
            var query = HttpUtility.ParseQueryString(uri.Query);
            string AuthID = query.Get("auth");
        }
    }
}