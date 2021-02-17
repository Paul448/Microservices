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
        private int _PID;

        public string Name { get => _Name; set => _Name = value; }
        public DateTime Geb { get => _Geb; set => _Geb = value; }
        public int PID { get => _PID; set => _PID = value; }

        public Person()
        {
            Name = "NONAME";
            Geb = DateTime.Now;
        }

        public Person(string vName, int vPID = -1)
        {
            Name = vName;
            Geb = DateTime.Now;
            PID = vPID;
        }
    }
}