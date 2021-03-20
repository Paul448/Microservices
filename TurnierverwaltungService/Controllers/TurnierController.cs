using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using TurnierverwaltungService.Models;
using MySql.Data.MySqlClient;

namespace TurnierverwaltungService.Controllers
{
    public class TurnierController : ApiController
    {
        // GET: api/Trunier
        
        public List<Turnier> GetTurniere()
        {
            List<Turnier> ListTurnier = new List<Turnier>();
            string cnst = "Server=localhost;Database=microservicespro;Uid=root;";
            MySqlConnection connect = new MySqlConnection(cnst);
            string sel = "select * from turnier";
            MySqlCommand cmd = new MySqlCommand(sel, connect);
            connect.Open();
            MySqlDataReader reader = cmd.ExecuteReader();
            while(reader.Read())
            {
                ListTurnier.Add(new Turnier(reader.GetString(1), reader.GetInt32(0)));
            }
            return ListTurnier;
        }

        public List<spiele> GetSpiele(int TID) // Spiele die zum Turnier gehören
        {

            return new List<spiele>();
        }

        public List<Mannschaft> GetMannschaft(int TID) // Mannschaften die zum Turnier gehören
        {

            return new List<Mannschaft>();
        }
    }
}
