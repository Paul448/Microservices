using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using TurnierverwaltungService.Models;

namespace TurnierverwaltungService.Controllers
{
    public class controller
    {


        public controller()
        {
            
        }
        public List<Turnier> GetTurniere()
        {
            string json = GetHTTP("GetTurniere");
            List<Turnier> RET = (List<Turnier>)JsonConvert.DeserializeObject(json, typeof(List<Turnier>));
            return RET;
        }



        public string GetHTTP(string URI2)
        {
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create("https://localhost:44399/API/Turnier/" + URI2);
            request.Method = "GET";
            HttpWebResponse response = (HttpWebResponse)request.GetResponse();
            Stream recieve = response.GetResponseStream();
            StreamReader reader = new StreamReader(recieve);
            string ResponseText = reader.ReadToEnd();
            return ResponseText;
        }
    }
}