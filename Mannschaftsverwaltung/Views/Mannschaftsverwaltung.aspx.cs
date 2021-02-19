﻿using System;
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
            // LOADLIST
            List<Mannschaft> MSTabelle = Verwalter.MSLIST;
            if (selectTeam.Items.Count == 1)
            {
                foreach (var e in MSTabelle)
                {
                    selectTeam.Items.Add(e.MID + " - " + e.Name);
                }
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
            tblPersonen.Rows.Clear();
            List<Person> PSLIST = Verwalter.GetPersonList(MS);
            TableCell tc = new TableCell();
            TableRow tr = new TableRow();
            foreach(var e in PSLIST)
            {
                tc.Text = e.PID.ToString();
                tr.Cells.Add(tc);
                tc = new TableCell();
                tc.Text = e.Name;
                tr.Cells.Add(tc);
                tc = new TableCell();
                tc.Text = e.Geb.ToString();
                tr.Cells.Add(tc);
                tc = new TableCell();
                tc.Text = MS.ToString();
                tr.Cells.Add(tc);
                tc = new TableCell();
                tblPersonen.Rows.Add(tr);
                tr = new TableRow();
            }
        }
    }
}