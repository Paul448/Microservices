using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TurnierverwaltungService.Models
{
    public class Turnier
    {
        private int _TID;
        private string _TNAME;
        private List<Mannschaft> _ListTeilnehmer;
        private List<spiele> _ListSpiele;

        public string TNAME { get => _TNAME; set => _TNAME = value; }
        public List<Mannschaft> ListTeilnehmer { get => _ListTeilnehmer; set => _ListTeilnehmer = value; }
        public int TID { get => _TID; set => _TID = value; }
        public List<spiele> ListSpiele { get => _ListSpiele; set => _ListSpiele = value; }

        public Turnier()
        {
            TNAME = "EMPTY";
            ListTeilnehmer = null;
        }
        
        public Turnier(string vName, int vTID)
        {
            TID = vTID;
            TNAME = vName;
        }
    }
}