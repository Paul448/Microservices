using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LoginService.Models
{
    public class Turnier
    {
        private int _TID;
        private string _Name;
        public string Name { get => _Name; set => _Name = value; }
        public int TID { get => _TID; set => _TID = value; }

        public Turnier()
        {
            this.Name = "";
            this.TID = -1;
        }

        public Turnier(string vName, int ID)
        {
            this.Name = vName;
            this.TID = ID;
        }
    }
}