using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TurnierverwaltungService.Models
{
    public class Turnier
    {
        private string _TNAME;
        private List<Mannschaft> _ListTeilnehmer;

        public string TNAME { get => _TNAME; set => _TNAME = value; }
        public List<Mannschaft> ListTeilnehmer { get => _ListTeilnehmer; set => _ListTeilnehmer = value; }

        public Turnier()
        {
            TNAME = "EMPTY";
            ListTeilnehmer = null;
        }
        
        public Turnier(string vName)
        {
            TNAME = vName;
        }
    }
}