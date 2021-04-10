using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TurnierverwaltungService.Models
{
    public class Mannschaft
    {
        private string _MNAME;
        private int _MID;

        public string MNAME { get => _MNAME; set => _MNAME = value; }
        public int MID { get => _MID; set => _MID = value; }

        public Mannschaft()
        {
            this.MNAME = "EMPTY";
        }

        public Mannschaft(string vName)
        {
            this.MNAME = vName;
        }

        public Mannschaft(string vName, int vMID)
        {
            this.MNAME = vName;
            this.MID = vMID;
        }
    }
}