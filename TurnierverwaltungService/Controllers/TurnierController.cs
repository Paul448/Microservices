using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;

namespace TurnierverwaltungService.Controllers
{
    public class TurnierController
    {
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