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
using GatewayService.Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace GatewayService.Controllers
{
    public class Controller
    {
        private List<Turnier> _Liste;
        private string _AuthID;
        public List<Turnier> Liste { get => _Liste; set => _Liste = value; }
        public string AuthID { get => _AuthID; set => _AuthID = value; }

        public Controller()
        {
            this.AuthID = "-1";
            this.Liste = new List<Turnier>();
            this.Liste = LoadTurniere();
        }

        public List<Turnier> LoadTurniere()
        {

            return new List<Turnier>();
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

        public string GetHTTP(string URI)
        {
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create("https://localhost:44396/" + URI);
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

        public void GetAllTurnier()
        {
            string JsonList = GetHTTP("api/Gate/Turnier");
        }

    }
}