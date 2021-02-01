using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TurnierverwaltungService.Models
{
    public class Mannschaft
    {
        private string _MNAME;

        public string MNAME { get => _MNAME; set => _MNAME = value; }

        public Mannschaft()
        {
            this.MNAME = "EMPTY";
        }

        public Mannschaft(string vName)
        {
            this.MNAME = vName;
        }
    }
}