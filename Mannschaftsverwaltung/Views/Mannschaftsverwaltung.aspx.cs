using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Mannschaftsverwaltung.Controllers;
using Mannschaftsverwaltung.Models;

namespace Mannschaftsverwaltung.Views
{
    public partial class Mannschaftsverwaltung : System.Web.UI.Page
    {
        private controller _Verwalter;

        public controller Verwalter { get => _Verwalter; set => _Verwalter = value; }

        protected void Page_Load(object sender, EventArgs e)
        {
            Verwalter = new controller();
            Verwalter.LoadMS();
            LoadList();
        } 

        public void Auth()
        {
            var uri = new Uri(HttpContext.Current.Request.Url.AbsoluteUri);
            var query = HttpUtility.ParseQueryString(uri.Query);
            string AuthID = query.Get("auth");
        }

        public void LoadList()
        {
            List<Mannschaft> MSTabelle = Verwalter.MSLIST;
            foreach(var e in MSTabelle)
            {
                selectTeam.Items.Add(e.Name);        
            }
        }
    }
}