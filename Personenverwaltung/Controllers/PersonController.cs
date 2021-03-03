using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using MySql.Data.MySqlClient;
using Personenverwaltung.Models;

namespace Personenverwaltung.Controllers
{
    public class PersonController : ApiController
    {
        // GET: api/Person
        [Route("api/Person/GetPerson")]
        public List<Person> GetPerson()
        {
            List<Person> ListPS = new List<Person>();
            List<Mannschaft> ListMS = new List<Mannschaft>();
            string cnst = "Server=localhost;Database=microservicespro;Uid=root;";
            MySqlConnection con = new MySqlConnection(cnst);
            try
            {
                con.Open();
                MySqlCommand cmd = new MySqlCommand("select * from Fussballspieler", con);
                MySqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    ListPS.Add(new Fussballspieler(reader.GetString("Name"), reader.GetInt32("Tore"), reader.GetInt32("Siege"), reader.GetInt32("Nummer")));
                }
                con.Close();
                return ListPS;
            }
            catch
            {
                return null;
            }
        }

        [Route("api/Person/GetUser")]
        public List<user> GetUser()
        {
            List<user> userlist = new List<user>();
            string cnst = "Server=localhost;Database=microservicespro;Uid=root;";
            MySqlConnection con = new MySqlConnection(cnst);
            try
            {
                con.Open();
                MySqlCommand cmd = new MySqlCommand("Select * from Users", con);
                MySqlDataReader reader = cmd.ExecuteReader();
                while(reader.Read())
                {
                    userlist.Add(new user(reader.GetInt32("UID"), reader.GetString("Name"), reader.GetString("Status"), reader.GetString("Info"), reader.GetString("Pass")));
                }
            }
            catch
            {

            }
            return userlist;
        }

    }
}
