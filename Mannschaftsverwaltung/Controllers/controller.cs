using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using Mannschaftsverwaltung.Models;
using Newtonsoft.Json;

namespace Mannschaftsverwaltung.Controllers
{
    public class controller
    {
        private List<Mannschaft> _MSLIST;

        public List<Mannschaft> MSLIST { get => _MSLIST; set => _MSLIST = value; }

        public controller()
        {
            MSLIST = null;
        }

        public void LoadMS()
        {
            //MS PORT: 44336
            string jsonMS = HTTPRequest("api/Mannschaft");
            MSLIST = (List<Mannschaft>)JsonConvert.DeserializeObject(jsonMS, typeof(List<Mannschaft>));
        }

        public string HTTPRequest(string URI, string Port = "44336")
        {
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create("https://localhost:" + Port + "/" + URI);
            request.Method = "GET";
            request.MaximumAutomaticRedirections = 4;
            request.MaximumResponseHeadersLength = 4;
            request.Credentials = CredentialCache.DefaultCredentials;
            HttpWebResponse response = (HttpWebResponse)request.GetResponse();
            Stream recieve = response.GetResponseStream();
            StreamReader reader = new StreamReader(recieve);
            string retResponse = reader.ReadToEnd();
            return retResponse;
        }

        public List<Person> GetPersonList(int vMS)
        {
            return MSLIST.Find(x => x.MID == vMS).Personen;
        }
    }
}