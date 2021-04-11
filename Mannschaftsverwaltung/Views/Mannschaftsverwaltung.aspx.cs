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
            Uri uri = new Uri(HttpContext.Current.Request.Url.AbsoluteUri);
            string Check = Verwalter.CheckPW(uri);
            if (Check == "false")
            {
                Response.Redirect("https://localhost:44338/Views/Gatehome");
            }
            else
            {
                //PW Richtig
            }
            Verwalter.LoadMS();
            if(!this.IsPostBack)
            {
                LoadList();
                LoadPersonList();
            }
            string[] vsplit = selectTeam.SelectedItem.Text.Split('-');
            int vvMID = Convert.ToInt32(vsplit[0].Trim());
            LoadPersonen(vvMID);
        } 

        public void Auth()
        {
            var uri = new Uri(HttpContext.Current.Request.Url.AbsoluteUri);
            var query = HttpUtility.ParseQueryString(uri.Query);
            string AuthID = query.Get("auth");
        }

        public void LoadList()
        {
            // LOADLIST
            List<Mannschaft> MSTabelle = Verwalter.MSLIST;
            selectTeam.Items.Clear();
                foreach (var e in MSTabelle)
                {
                    selectTeam.Items.Add(e.MID + " - " + e.Name);
                }
            
        }

        protected void selectTeam_SelectedIndexChanged(object sender, EventArgs e)
        {  
            string[] vsplit = selectTeam.SelectedItem.Text.Split('-');
            int vMID = Convert.ToInt32(vsplit[0].Trim());
            LoadPersonen(vMID);
        }

        public void LoadPersonen(int MS)
        {
            for (int i = 1; i < tblPersonen.Rows.Count; i++)
            {
                    tblPersonen.Rows.RemoveAt(i);
            }
            tblPersonen.BorderWidth = 2;
            tblPersonen.CellSpacing = 0;
            List<Person> PSLIST = Verwalter.GetPersonList(MS);
            TableCell tc = new TableCell();
            tc.BorderWidth = 1;
            TableRow tr = new TableRow();
            foreach(var e in PSLIST)
            {
                tc.Text = e.PID.ToString();
                tr.Cells.Add(tc);
                tc = new TableCell();
                tc.BorderWidth = 1;
                tc.Text = e.Name;
                tr.Cells.Add(tc);
                tc = new TableCell();
                tc.BorderWidth = 1;
                tc.Text = e.Geb.ToString();
                tr.Cells.Add(tc);
                tc = new TableCell();
                tc.BorderWidth = 1;
                tc.Text = MS.ToString();
                tr.Cells.Add(tc);
                tc = new TableCell();
                tc.BorderWidth = 1;
                tblPersonen.Rows.Add(tr);
                tr = new TableRow();
            }
        }

        protected void btnDelete_Click(object sender, EventArgs e)
        {
            Verwalter.DelMS(Convert.ToInt32(txtMID.Text));
            Verwalter.LoadMS();
            LoadList();
        }

        protected void btnAdd_Click(object sender, EventArgs e)
        {
            Mannschaft neu = new Mannschaft(txtNAME.Text, null);
            Verwalter.AddMS(neu);
            Verwalter.LoadMS();
            selectTeam.Items.Clear();
            LoadList();
        }

        public void LoadPersonList()
        {
            listSpieler.Items.Clear();
            List<Person> pslist = Verwalter.GetFreePersons();
            foreach(var e in pslist)
            {
                listSpieler.Items.Add(e.PID + " - " + e.Name);
            }
        }

        protected void btnZuweisen_Click(object sender, EventArgs e)
        {
            string[] vsplit = listSpieler.SelectedItem.Text.Split('-');
            int vPID = Convert.ToInt32(vsplit[0].Trim());
            vsplit = selectTeam.SelectedItem.Text.Split('-');
            int vMID = Convert.ToInt32(vsplit[0].Trim());
            Verwalter.AddPersonToMs(vPID, vMID);
            Verwalter.LoadMS();
            string[] vsplit2 = selectTeam.SelectedItem.Text.Split('-');
            int v1MID = Convert.ToInt32(vsplit2[0].Trim());
            LoadPersonen(v1MID);
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