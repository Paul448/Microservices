using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Mannschaftsverwaltung.Models;
using MySql.Data.MySqlClient;


namespace Mannschaftsverwaltung.Controllers
{
    public class MannschaftController : ApiController
    {
        // GET: api/Mannschaft

        public Mannschaft Get()
        {
            List<Person> ListMS = new List<Person>();
            string cnst = "Server=localhost;Database=microservicespro;Uid=root;";
            MySqlConnection con = new MySqlConnection(cnst);
            try 
            {
                con.Open();
                string sel = "select * from person where mid = '1'";
                MySqlCommand cmd = new MySqlCommand(sel, con);
                MySqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    ListMS.Add(new Person(reader.GetString(1)));
                }
                Mannschaft MSNEW = new Mannschaft("TEST", ListMS);
                con.Close();
                return MSNEW;
            }
            catch(Exception e)
            {
                return null;
            }
        }

        // GET: api/Mannschaft/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Mannschaft
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/Mannschaft/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Mannschaft/5
        public void Delete(int id)
        {
        }
    }
}
