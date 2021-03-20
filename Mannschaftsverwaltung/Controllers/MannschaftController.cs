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
        [Route("api/Mannschaft/GetMS")]
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

        [Route("api/Mannschaft/Delete/{MID}")]
        public bool Get(int MID = -1)
        {
            if(MID != -1)
            {
                string cnst = "Server=localhost;Database=microservicespro;Uid=root;";
                MySqlConnection con = new MySqlConnection(cnst);
                MySqlCommand cmd = new MySqlCommand("delete from mannschaft where MID ='" + MID + "'", con);
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
                return true;
            }
            else
            {
                return false;
            }
        }

        [Route("api/Mannschaft/ADD")]
        public bool Post([FromBody]Mannschaft ms)
        {
            if (ms != null)
            {
                string cnst = "Server=localhost;Database=microservicespro;Uid=root;";
                MySqlConnection con = new MySqlConnection(cnst);
                string SQL = "insert into mannschaft(Name) values ('" + ms.Name + "')";
                MySqlCommand cmd = new MySqlCommand(SQL, con);
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
                return true;
            }
            else
            {
                return false;
            }
        }
        [Route("api/Mannschaft/GetPersonen")]
        public List<Person> getPersonen(int MS)
        {
            List<Person> ps = new List<Person>();
            string cnst = "Server=localhost;Database=microservicespro;Uid=root;";
            MySqlConnection con2 = new MySqlConnection(cnst);
            con2.Open();
            string sel = "select Person.* from person inner join (select * from PS_MS where MID = '" + MS + "') as PSMS on person.PID = PSMS.PID";
            MySqlCommand cmd = new MySqlCommand(sel, con2);
            MySqlDataReader reader2 = cmd.ExecuteReader();
            while(reader2.Read())
            {
                ps.Add(new Person(reader2.GetString(1), reader2.GetInt32(0)));
            }
            con2.Close();
            return ps;
        } 
        [Route("api/Mannschaft/GetPS")]
        public List<Person> GetPS()
        {
            List<Person> ps = new List<Person>();
            string cnst = "Server=localhost;Database=microservicespro;Uid=root;";
            MySqlConnection con2 = new MySqlConnection(cnst);
            con2.Open();
            string sel = "SELECT Person.* FROM Person left join PS_MS on PS_MS.PID = PERSON.PID where PS_MS.PID is null";
            MySqlCommand cmd = new MySqlCommand(sel, con2);
            MySqlDataReader reader2 = cmd.ExecuteReader();
            while (reader2.Read())
            {
                ps.Add(new Person(reader2.GetString(1), reader2.GetInt32(0)));
            }
            con2.Close();
            return ps;
        }
        [Route("api/Mannschaft/Update/{PID}/{MID}")]
        public bool Get(int PID, int MID)
        {
            try
            {
                string cnst = "Server=localhost;Database=microservicespro;Uid=root;";
                MySqlConnection con2 = new MySqlConnection(cnst);
                con2.Open();
                string sel = "insert into ps_ms (MID, PID) Values (" + MID + "," + PID + ")";
                MySqlCommand cmd = new MySqlCommand(sel, con2);
                cmd.ExecuteNonQuery();
                con2.Close();
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}
