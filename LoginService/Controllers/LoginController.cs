using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Web.Http;
using LoginService.Models;
using MySql.Data.MySqlClient;
using System.Security.Cryptography;

namespace LoginService.Controllers
{
    public class LoginController : ApiController
    {
        // GET: api/Login/5
        [Route("api/LoginController/{UID}/{PW}")]
        public string Get(string UID = "", string PW = "")
        {
            MD5 crypt = MD5.Create();
            byte[] PWBYTE = System.Text.Encoding.ASCII.GetBytes(PW);
            byte[] MD5HASH = crypt.ComputeHash(PWBYTE);
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < MD5HASH.Length; i++)
            {
                sb.Append(MD5HASH[i].ToString("X2"));
            }
            string PWHASH = sb.ToString();
            string cnst = "Server=localhost;Database=microservicespro;Uid=root;";
            MySqlConnection con = new MySqlConnection(cnst);
            try
            {
                int count = 0;
                con.Open();
                string cmdst = "select count(*) from Users where pass ='" + PWHASH + "' and Name = '" + UID + "'";
                MySqlCommand cmd = new MySqlCommand(cmdst, con);
                MySqlDataReader reader = cmd.ExecuteReader();
                while(reader.Read())
                {
                   count = Convert.ToInt32(reader.GetValue(0));
                }
                if(count != 0)
                {
                    con.Close();
                    string AuthID = RandomString(20);
                    return AuthID;
                }
                else
                {
                    con.Close();
                    return "0";
                }
            }
            catch(Exception e)
            {
                return "0";
            }
            /*
            if(UID == "123" & PW == "123")
            {
                string AuthID = RandomString(20);
                return AuthID;
            }
            else
            {
                return "0";
            } */
        }

        // POST: api/Login
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/Login/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Login/5
        public void Delete(int id)
        {
        }

        private static string RandomString(int length)
        {
            Random randome = new Random();
            const string pool = "abcdefghijklmnopqrstuvwxyz0123456789";
            var builder = new StringBuilder();

            for (var i = 0; i < length; i++)
            {
                var c = pool[randome.Next(0, pool.Length)];
                builder.Append(c);
            }

            return builder.ToString();
        }
    }
}
