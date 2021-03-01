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
            string jsonMS = HTTPRequest("api/Mannschaft/GetMS");
            MSLIST = (List<Mannschaft>)JsonConvert.DeserializeObject(jsonMS, typeof(List<Mannschaft>));
        }

        public void DelMS(int MID)
        {
            //MS PORT: 44336
            string jsonMS = HTTPRequest("api/Mannschaft/Delete/" + MID + "/");
        }
         public void AddMS(Mannschaft MS_ADD)
        {
            string json = JsonConvert.SerializeObject(MS_ADD);
            PostJson(json, "api/mannschaft/add");
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

        public List<Person> GetFreePersons()
        {
            string JSON = HTTPRequest("api/mannschaft/GetPS/");
            List<Person> neu = (List<Person>)JsonConvert.DeserializeObject(JSON, typeof(List<Person>));
            return neu;
        }

        public void PostJson(string JsonToPost, string URI, string Port = "44336")
        {
            var httpWebRequest = (HttpWebRequest)WebRequest.Create("https://localhost:" + Port + "/" + URI);
            httpWebRequest.ContentType = "application/json";
            httpWebRequest.Method = "POST";

            using (var streamWriter = new StreamWriter(httpWebRequest.GetRequestStream()))
            {
                streamWriter.Write(JsonToPost);
            }

            var httpResponse = (HttpWebResponse)httpWebRequest.GetResponse();
            using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
            {
                var result = streamReader.ReadToEnd();
            }
        }

        public void AddPersonToMs(int PID, int MID)
        {
            string request = "api/Mannschaft/Update/" + PID + "/ " + MID + "/";
            string json = HTTPRequest(request);
        }
    }
}