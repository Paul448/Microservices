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
            string cnst = "Server=localhost;Database=microservicespro;Uid=root;";
            MySqlConnection con = new MySqlConnection(cnst);
            try
            {
                con.Open();
                MySqlCommand cmd = new MySqlCommand("select * from Person", con);
                MySqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    ListPS.Add(new Person(reader.GetString("Name"), reader.GetInt16("PID"), reader.GetString("Typ")));
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
        [Route("api/Person/GetDelUser/{PID}")]
        public void GetDelUser(int PID)
        {
            List<user> userlist = new List<user>();
            string cnst = "Server=localhost;Database=microservicespro;Uid=root;";
            MySqlConnection con = new MySqlConnection(cnst);
            try
            {
                con.Open();
                MySqlCommand cmd = new MySqlCommand("Delete from person where PID =" + PID, con);
                cmd.ExecuteNonQuery();
            }
            catch
            {

            }
        }
        [Route("api/Person/GetAddUser/{Name}/{Typ}")]
        public void GetAddUser(string Name, string Typ)
        {
            string cnst = "Server=localhost;Database=microservicespro;Uid=root;";
            MySqlConnection con = new MySqlConnection(cnst);
            try
            {
                con.Open();
                string SQL = "insert into Person(Name, Typ) Values ('" + Name + "', '" + Typ + "')";
                MySqlCommand cmd = new MySqlCommand(SQL, con);
                cmd.ExecuteNonQuery();
            }
            catch
            {

            }
        }
    }
}
