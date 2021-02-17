using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Mannschaftsverwaltung.Models
{
    public class Mannschaft
    {
        private string _Name;
        private List<Person> _Personen;
        private int _MID;

        public string Name { get => _Name; set => _Name = value; }
        public List<Person> Personen { get => _Personen; set => _Personen = value; }
        public int MID { get => _MID; set => _MID = value; }

        public Mannschaft()
        {
            Name = "NONAME";
            Personen = null;
        }

        public Mannschaft(string vName, List<Person> vList, int vMID = -1)
        {
            Name = vName;
            Personen = vList;
            MID = vMID;
        }
    }
}