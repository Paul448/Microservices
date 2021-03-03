using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Personenverwaltung.Controllers;
using Personenverwaltung.Models;

namespace Personenverwaltung.Views
{
    public partial class Personenverwaltung : System.Web.UI.Page
    {
        private controller _Verwalter;

        public controller Verwalter { get => _Verwalter; set => _Verwalter = value; }

        protected void Page_Load(object sender, EventArgs e)
        {
            if(!this.IsPostBack)
            {
                Verwalter = new controller();
                
            }
            Verwalter.GetAllPersons();
            LoadTable();
        }

        public void LoadTable()
        {
            tblPersonen.BorderWidth = 2;
            tblPersonen.CellSpacing = 0;
            tblPersonen.Rows.Clear();
            List<Person> ps = Verwalter.ListPS;
            TableCell tc = new TableCell();
            TableRow tr = new TableRow();
            foreach(var e in ps)
            {
                tc.Text = e.ID.ToString();
                tr.Cells.Add(tc);
                tc = new TableCell();
                tc.BorderWidth = 1;
                tc.Text = e.Name;
                tr.Cells.Add(tc);
                tc = new TableCell();
                tc.BorderWidth = 1;
                tc.Text = e.Geburtsdatum.ToString();
                tr.Cells.Add(tc);
                tc = new TableCell();
                tblPersonen.Rows.Add(tr);
                tr = new TableRow();
            }
        }
    }
}