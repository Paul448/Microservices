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
        private List<Turnier> _TurnierList;

        public List<Turnier> TurnierList { get => _TurnierList; set => _TurnierList = value; }

        public controller()
        {
            TurnierList = new List<Turnier>();
            LoadTurniere("GetTurniere");
        }

        public void LoadTurniere(string URI)
        {
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create("https://localhost:44399/API/Turnier/" + URI);
            request.Method = "GET";
            HttpWebResponse response = (HttpWebResponse)request.GetResponse();
            Stream recieve = response.GetResponseStream();
            StreamReader reader = new StreamReader(recieve);
            string ResponseText = reader.ReadToEnd();
            this.TurnierList = (List<Turnier>)JsonConvert.DeserializeObject(ResponseText, typeof(List<Turnier>));
        }
    }
}