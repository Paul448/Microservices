using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using TurnierverwaltungService.Models;
using TurnierverwaltungService.Controllers;

namespace TurnierverwaltungService.Views
{
    public partial class Turnierverwaltung : System.Web.UI.Page
    {
        private controller _Verwalter;

        public controller Verwalter { get => _Verwalter; set => _Verwalter = value; }

        protected void Page_Load(object sender, EventArgs e)
        {
            Verwalter = new controller();
        }
    }
}