using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
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

        public List<Mannschaft> GetMS(int vTID = 1)
        {
            string json = GetHTTP("GetMS/" + vTID);
            List<Mannschaft> RET = (List<Mannschaft>)JsonConvert.DeserializeObject(json, typeof(List<Mannschaft>));
            return RET;
        }

        public void AddSpiel(spiele sp1)
        {
            string json = JsonConvert.SerializeObject(sp1);
            string test = PostHTTP("AddSpiel", json);
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

        public string PostHTTP(string URI3, string JSON)
        {
            HttpWebRequest webRequest = null;

            webRequest = (HttpWebRequest)WebRequest.Create("https://localhost:44399/API/Turnier/" + URI3);
            webRequest.ContentType = "application/json";
            webRequest.Method = "POST";

            //Daten senden
            byte[] byteArray = Encoding.UTF8.GetBytes(JSON);
            webRequest.ContentLength = byteArray.Length;
            // Get the request stream.
            Stream dataStream = webRequest.GetRequestStream();
            // Write the data to the request stream.
            dataStream.Write(byteArray, 0, byteArray.Length);
            // Close the Stream object.
            dataStream.Close();

            //Antwort abholen
            HttpWebResponse webResponse = (HttpWebResponse)webRequest.GetResponse();


            using (StreamReader responseStream = new StreamReader(webResponse.GetResponseStream()))
            {
                return responseStream.ReadToEnd();
            }
            webResponse.Close();
        }
    }
}