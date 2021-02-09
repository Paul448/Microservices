using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Mannschaftsverwaltung.Models
{
    public class Person
    {
        private string _Name;
        private DateTime _Geb;

        public string Name { get => _Name; set => _Name = value; }
        public DateTime Geb { get => _Geb; set => _Geb = value; }

        public Person()
        {
            Name = "NONAME";
            Geb = DateTime.Now;
        }

        public Person(string vName)
        {
            Name = vName;
            Geb = DateTime.Now;
        }
    }
}