using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Personenverwaltung.Models
{
    public class Person
    {
        private string _Name;
        private DateTime _Geb;
        private int _PID;
        private string _Typ;

        public string Name { get => _Name; set => _Name = value; }
        public DateTime Geb { get => _Geb; set => _Geb = value; }
        public int PID { get => _PID; set => _PID = value; }
        public string Typ { get => _Typ; set => _Typ = value; }

        public Person()
        {
            Name = "NONAME";
            Geb = DateTime.Now;
            Typ = "UNBEKANNT"; 
        }

        public Person(string vName, int vPID = -1, string vTyp = "Fussballspieler")
        {
            Name = vName;
            Geb = DateTime.Now;
            PID = vPID;
            Typ = vTyp;
        }
    }
}