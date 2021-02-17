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

        public List<Mannschaft> Get()
        {
            List<Mannschaft> ListMS = new List<Mannschaft>();
            string cnst = "Server=localhost;Database=microservicespro;Uid=root;";
            MySqlConnection con = new MySqlConnection(cnst);
            try 
            {
                con.Open();
                string sel = "select * from mannschaft";
                MySqlCommand cmd = new MySqlCommand(sel, con);
                MySqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    int MSID = reader.GetInt16(0);
                    List<Person> PSLS = getPersonen(MSID);
                    ListMS.Add(new Mannschaft(reader.GetString(1), PSLS, MSID));
                }
                con.Close();
                return ListMS;
            }
            catch(Exception e)
            {
                return null;
            }
        }
        public List<Person> getPersonen(int MS)
        {
            List<Person> ps = new List<Person>();
            string cnst = "Server=localhost;Database=microservicespro;Uid=root;";
            MySqlConnection con2 = new MySqlConnection(cnst);
            con2.Open();
            string sel = "select * from person where MID ='" + MS + "'";
            MySqlCommand cmd = new MySqlCommand(sel, con2);
            MySqlDataReader reader2 = cmd.ExecuteReader();
            while(reader2.Read())
            {
                ps.Add(new Person(reader2.GetString(0)));
            }
            con2.Close();
            return ps;
        }
    }
}
