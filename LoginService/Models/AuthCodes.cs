using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LoginService.Models
{
    public class AuthCodes
    {
        private string _AuthCode;
        private string _HostIP;
        private DateTime _TimeCreated;
        private DateTime _TimeOutDated;

        public string AuthCode { get => _AuthCode; set => _AuthCode = value; }
        public string HostIP { get => _HostIP; set => _HostIP = value; }
        public DateTime TimeCreated { get => _TimeCreated; set => _TimeCreated = value; }
        public DateTime TimeOutDated { get => _TimeOutDated; set => _TimeOutDated = value; }


        public AuthCodes(string Code)
        {
            this.AuthCode = Code;
            this.TimeCreated = DateTime.Now;
            this.TimeOutDated = TimeCreated.AddMinutes(30);
        }
    }
}