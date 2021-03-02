using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using Personenverwaltung.Models;

namespace Personenverwaltung.Controllers
{
    public class controller
    {
        private List<Person> _ListPS;
        public List<Person> ListPS { get => _ListPS; set => _ListPS = value; }

        public controller()
        {
            this.ListPS = new List<Person>();
            ListPS.Add(new Fussballspieler());
        }

        public List<Person> GetAllPersons()
        {
            string json = HTTPRequest("API/Person");

            return ListPS;
        }

        public string HTTPRequest(string URI, string Port = "44328")
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
    }
}