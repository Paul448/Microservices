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
            LoadUI();
        }

        public void LoadUI()
        {
            List<Turnier> TLIST = Verwalter.GetTurniere();
            foreach(var e in TLIST)
            {
                DDTurnier.Items.Add(e.TID + " - " + e.TNAME);
            }

            List<Mannschaft> MSLIST = new List<Mannschaft>();
            foreach(var e in TLIST)
            {
                foreach(var x in e.ListTeilnehmer)
                {
                    MSLIST.Add(x);
                }
            }

            List<spiele> SpielList = new List<spiele>();
            foreach (var e in TLIST)
            {
                foreach (var x in e.ListSpiele)
                {
                    SpielList.Add(x);
                }
            }

            foreach (var e in MSLIST)
            {
                TableRow tr = new TableRow();
                TableCell tc = new TableCell();
                tc.Text = e.MNAME;
                tr.Cells.Add(tc);
                TblMS.Rows.Add(tr);
            }


            foreach (var e in SpielList)
            {
                TableRow tr = new TableRow();
                TableCell tc = new TableCell();
                tc.Text = e.SpielID.ToString();
                tr.Cells.Add(tc);
                tblSpiele.Rows.Add(tr);
            }
        }
    }
}