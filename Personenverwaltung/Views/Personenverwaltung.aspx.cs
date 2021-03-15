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
                //Verwalter = new controller();
            }
            Verwalter = new controller();
            Verwalter.GetAllPersons();
            Verwalter.GetAllUser();
            LoadTablePerson();
            LoadTableUser();
        }

        public void LoadTablePerson()
        {
            tblPersonen.BorderWidth = 2;
            tblPersonen.CellSpacing = 0;
            tblPersonen.Rows.Clear();
            List<Person> ps = Verwalter.ListPS;
            if(ps == null)
            {
                ps = new List<Person>();
                ps.Add(new Person("MYSQL ERROR - NO DB"));
            }
            TableCell tc = new TableCell();
            TableRow tr = new TableRow();
            foreach(var e in ps)
            {
                tc.Text = e.PID.ToString();
                tr.Cells.Add(tc);
                tc = new TableCell();
                tc.BorderWidth = 1;
                tc.Text = e.Name;
                tr.Cells.Add(tc);
                tc = new TableCell();
                tc.BorderWidth = 1;
                tc.Text = e.Typ;
                tr.Cells.Add(tc);
                tc = new TableCell();
                tblPersonen.Rows.Add(tr);
                tr = new TableRow();
            }
        }

        public void LoadTableUser()
        {
            tblUser.BorderWidth = 2;
            tblUser.CellSpacing = 0;
            tblUser.Rows.Clear();
            List<user> ps = Verwalter.ULIST;
            TableCell tc = new TableCell();
            TableRow tr = new TableRow();
            foreach (var e in ps)
            {
                tc.Text = e.UID.ToString();
                tr.Cells.Add(tc);
                tc = new TableCell();
                tc.BorderWidth = 1;
                tc.Text = e.Name;
                tr.Cells.Add(tc);
                tc = new TableCell();
                tc.BorderWidth = 1;
                tc.Text = e.Status;
                tr.Cells.Add(tc);
                tc = new TableCell();
                tblUser.Rows.Add(tr);
                tr = new TableRow();
            }
        }

        protected void btnADD_Click(object sender, EventArgs e)
        {
            Person neu = new Person(txtName.Text, -1, txtTYP.Text);
            Verwalter.AddPerson(neu);
            LoadTablePerson();
        }

        protected void btnDEL_Click(object sender, EventArgs e)
        {
            Verwalter.DelPerson(Convert.ToInt32(txtDel.Text));
            LoadTablePerson();
        }
    }
}