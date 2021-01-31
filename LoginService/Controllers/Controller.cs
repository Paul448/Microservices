using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using System.Xml.Linq;
using System.Xml;
using LoginService.Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace LoginService.Controllers
{
    public class Controller
    {
        private string _AuthID;
        public string AuthID { get => _AuthID; set => _AuthID = value; }

        public Controller()
        {
            this.AuthID = "-1";
        }

        public void Login(string UID, string PW)
        {
            string URI = "api/Gate/Login/" + UID + "/" + PW;
            string result = GetHTTP(URI);
            result = JToken.Parse(result).ToString();
            this.AuthID = result;
        }

        public bool CheckAuth()
        {
            string URI = "api/Gate/CheckAuth/" + AuthID;
            bool result = Convert.ToBoolean(GetHTTP(URI));
            return result;
        }

        public bool CheckCode(string Code)
        {
            string URI = "api/Gate/CheckAuth/" + Code;
            bool result = Convert.ToBoolean(GetHTTP(URI));
            return result;
        }

        public string GetHTTP(string URI, string Port = "44338")
        {
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create("https://localhost:" + Port + "/" + URI);
            request.Method = "GET";
            request.MaximumAutomaticRedirections = 4;
            request.MaximumResponseHeadersLength = 4;
            request.Credentials = CredentialCache.DefaultCredentials;
            HttpWebResponse response = (HttpWebResponse)request.GetResponse();
            Stream recieve = response.GetResponseStream();
            StreamReader reader = new StreamReader(recieve);
            string Auth1 = reader.ReadToEnd();
            return Auth1;
        }

    }
}