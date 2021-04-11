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
    public partial class Rankinganzeige : System.Web.UI.Page
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
            tblRanking.Rows.Clear();
            //Dropdown Laden
            List<Turnier> TLIST = Verwalter.GetTurniere();
            if (DDTurnier.Items.Count == 0 | DDTurnier.Items.Count != TLIST.Count)
            {
                DDTurnier.Items.Clear();
                foreach (var e in TLIST)
                {
                    DDTurnier.Items.Add(e.TID + " - " + e.TNAME);
                }
            }

            //Tabelle Laden
            string[] vsplit = DDTurnier.SelectedItem.Text.Split('-');
            int vTID = Convert.ToInt32(vsplit[0].Trim());
            List<Mannschaft> MSLIST = Verwalter.GetMS(vTID);
            List<spiele> SPLIST = Verwalter.getSpiele(vTID);

            TableCell tc = new TableCell();
            tc.BorderStyle = BorderStyle.Solid;
            tc.BorderWidth = 1;
            TableRow tr = new TableRow();
            tc.Text = "MID:";
            tr.Cells.Add(tc);
            tc = new TableCell();
            tc.Text = "Mannschaft:";
            tr.Cells.Add(tc);
            tc = new TableCell();
            tc.Text = "Punkte (Tore):";
            tr.Cells.Add(tc);
            tblRanking.Rows.Add(tr);
            tc = new TableCell();
            tr = new TableRow();
            tc.BorderStyle = BorderStyle.Solid;
            tc.BorderWidth = 1;

            foreach(var e in MSLIST)
            {
                string MSNAME = e.MNAME;
                int sMID = e.MID;
                int Tore = 0;
                tc = new TableCell();
                tc.BorderStyle = BorderStyle.Solid;
                tc.BorderWidth = 1;
                tc.Text = sMID.ToString();
                tr.Cells.Add(tc);
                tc = new TableCell();
                tc.BorderStyle = BorderStyle.Solid;
                tc.BorderWidth = 1;
                tc.Text = MSNAME;
                tr.Cells.Add(tc);
                tc = new TableCell();
                tc.BorderStyle = BorderStyle.Solid;
                tc.BorderWidth = 1;
                foreach (var x in SPLIST)
                {
                    if(sMID == x.MS1)
                    {
                        Tore = Tore + x.Ergebnis1;
                    }
                    else if(sMID == x.MS2)
                    {
                        Tore = Tore + x.Ergebnis2;
                    }
                }
                tc.Text = Tore.ToString();
                tr.Cells.Add(tc);
                tblRanking.Rows.Add(tr);
                tr = new TableRow();
            }
        }

        protected void DDTurnier_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadUI();
        }
    }
}