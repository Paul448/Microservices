using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Personenverwaltung.Models
{
    public class user
    {
        private int _UID;
        private string _Hash;
        private string _Status;
        private string _Info;
        private string _Name;

        public int UID { get => _UID; set => _UID = value; }
        public string Hash { get => _Hash; set => _Hash = value; }
        public string Status { get => _Status; set => _Status = value; }
        public string Info { get => _Info; set => _Info = value; }
        public string Name { get => _Name; set => _Name = value; }

        public user()
        {
            UID = -1;
            Status = "TEST";
            Info = "TEST";
            Name = "-";
        }

        public user(int vUID, string vName, string vStatus, string vInfo, string vHash)
        {
            this.UID = vUID;
            this.Name = vName;
            this.Status = vStatus;
            this.Info = vInfo;
            this.Hash = vHash;
        }
    }
}