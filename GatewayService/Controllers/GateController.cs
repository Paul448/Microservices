// Microservices
// Autor: Paul Jansen
// AI118 PRO
//
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using GatewayService.Models;
using GatewayService;

namespace GatewayService.Controllers
{
    public class GateController : ApiController
    {
        private List<AuthCodes> _ListCodes;
        public List<AuthCodes> ListCodes { get => _ListCodes; set => _ListCodes = value; }
        public GateController()
        {
            ListCodes = Global.AuthCodes;
        }

        // LOGIN + GET AUTH
        [Route("api/Gate/Login/{UID}/{PW}")]
        public string Get(string UID = "", string PW = "") //User Login return True/False
        {
            string Response = GetHTTP("api/LoginController/" + UID + "/" + PW);
            string str = JToken.Parse(Response).ToString();
            if (str != "0")
            {
                ListCodes.Add(new AuthCodes(str));
                Global.AuthCodes.Add(new AuthCodes(str));
            }
            else
            {

            }
            /*AuthCodes[AuthCodes.Count() + 1] = str; */
            return str;
        }

        // CHECK AUTH
        [Route("api/Gate/CheckAuth/{AUTH}")]
        public bool Get(string AUTH) //User Login return True/False
        {
            bool ret = CheckAuth(AUTH);
            return ret;
        }

        public async Task<string> GetAync(string URI)
        {
            HttpClient client = new HttpClient();
            try
            {
                HttpResponseMessage Response = await client.GetAsync("https://localhost:44396/" + URI);
                return await Response.Content.ReadAsStringAsync();
            }
            catch(Exception e)
            {
                return e.ToString();
            }
        }

        public string GetHTTP(string URI, string Port = "44330")
        {
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create("https://localhost:" + Port + "/" + URI);
            request.Method = "GET";
            request.MaximumAutomaticRedirections = 4;
            request.MaximumResponseHeadersLength = 4;
            request.Credentials = CredentialCache.DefaultCredentials;
            HttpWebResponse response = (HttpWebResponse)request.GetResponse();
            Stream recieve = response.GetResponseStream();
            StreamReader reader = new StreamReader(recieve);
            string return1 = reader.ReadToEnd();
            return return1;
        }

        public bool CheckAuth(string Check)
        {
            int count = ListCodes.Count;
            for(int index = 0;index < count; index++)
            {
                if(ListCodes[index].AuthCode == Check)
                {
                    return true;
                }
                else
                {

                }
            }
            return false;
        }
    }
}
