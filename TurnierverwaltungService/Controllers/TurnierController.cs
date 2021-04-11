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
        [Route("API/Turnier/GetTurniere")]
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
                ListTurnier.Add(new Turnier(reader.GetString(2), reader.GetInt32(0)));
            }

            foreach(var e in ListTurnier)
            {
                e.ListSpiele = GetSpiele(e.TID);
                e.ListTeilnehmer = GetMannschaft(e.TID);
            }
            return ListTurnier;
        }

        public List<spiele> GetSpiele(int TID) // Spiele die zum Turnier gehören
        {
            List<spiele> ListSpiele = new List<spiele>();
            string cnst = "Server=localhost;Database=microservicespro;Uid=root;";
            MySqlConnection connect = new MySqlConnection(cnst);
            string sel = "select * from spiele where TID =" + TID;
            MySqlCommand cmd = new MySqlCommand(sel, connect);
            connect.Open();
            MySqlDataReader reader = cmd.ExecuteReader();
            while(reader.Read())
            {
                ListSpiele.Add(new spiele(TID, reader.GetInt32(0), reader.GetInt32(2), reader.GetInt32(3), reader.GetInt32(4), reader.GetInt32(5)));
            }
            connect.Close();
            return ListSpiele;
        }

        [Route("API/Turnier/GetMS/{TID}")]
        public List<Mannschaft> GetMannschaft(int TID) // Mannschaften die zum Turnier gehören
        {
            List<Mannschaft> ListMS = new List<Mannschaft>();
            string cnst = "Server=localhost;Database=microservicespro;Uid=root;";
            MySqlConnection connect = new MySqlConnection(cnst);
            string sel = "select tms.TID, tms.MID, ms.NAME from tms inner join mannschaft ms on ms.MID = tms.MID where tms.TID =" + TID;
            MySqlCommand cmd = new MySqlCommand(sel, connect);
            connect.Open();
            MySqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                ListMS.Add(new Mannschaft(reader.GetString(2), reader.GetInt32(1)));
            }
            connect.Close();
            return ListMS;
        }
        [Route("API/Turnier/AddSpiel")]
        public bool AddSpiel([FromBody]spiele sp)
        {
            string sql = "insert into spiele (TID, MS1ID, MS2ID, Ergebnis1, Ergebnis2) Values (" + sp.TurnierID + ", " + sp.MS1 + ", " + sp.MS2 + ", " + sp.Ergebnis1 + ", " + sp.Ergebnis2 + ")"; 
            string cnst = "Server=localhost;Database=microservicespro;Uid=root;";
            MySqlConnection connect = new MySqlConnection(cnst);
            MySqlCommand cmd = new MySqlCommand(sql, connect);
            try
            {
                connect.Open();
                cmd.ExecuteNonQuery();
                connect.Close();
                return true;
            }
            catch(Exception e)
            {
                return false;
            }
        }
        [HttpGet]
        [Route("API/Turnier/GetMSOUTER/{TID}")]
        public List<Mannschaft> GetMSOUTER(int TID) // Mannschaften die zum Turnier gehören
        {
            List<Mannschaft> ListMS = new List<Mannschaft>();
            string cnst = "Server=localhost;Database=microservicespro;Uid=root;";
            MySqlConnection connect = new MySqlConnection(cnst);
            string sel = "select tms.TID, ms.MID, ms.NAME from mannschaft ms left join (select * from tms where TID = " + TID + ") as tms on tms.MID = ms.MID where tms.MID is null";
            MySqlCommand cmd = new MySqlCommand(sel, connect);
            connect.Open();
            MySqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                ListMS.Add(new Mannschaft(reader.GetString(2), reader.GetInt32(1)));
            }
            connect.Close();
            return ListMS;
        }
        [HttpGet]
        [Route("API/Turnier/AddTeilMS/{TID}/{MID}")]
        public bool AddTeilMS(int TID, int MID)
        {
            string cnst = "Server=localhost;Database=microservicespro;Uid=root;";
            MySqlConnection connection = new MySqlConnection(cnst);
            string sql = "insert into tms (TID, MID) Values (" + TID + "," + MID + ")";
            try
            {
                connection.Open();
                MySqlCommand cmd = new MySqlCommand(sql, connection);
                cmd.ExecuteNonQuery();
                connection.Close();
            }
            catch { }
            return true;
        }
        [HttpGet]
        [Route("API/Turnier/AddTurnier/{TuNAME}")]
        public bool AddTurnier(string TuNAME)
        {
            string sql = "insert into turnier (name) values ('" + TuNAME + "')";
            string cnst = "Server=localhost;Database=microservicespro;Uid=root;";
            MySqlConnection connect = new MySqlConnection(cnst);
            MySqlCommand cmd = new MySqlCommand(sql, connect);
            try
            {
                connect.Open();
                cmd.ExecuteNonQuery();
                connect.Close();
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }

        [HttpGet]
        [Route("API/Turnier/DelTurnier/{TID}")]
        public bool DelTurnier(string TID)
        {
            string sql = "delete from Turnier where TID =" + TID ;
            string cnst = "Server=localhost;Database=microservicespro;Uid=root;";
            MySqlConnection connect = new MySqlConnection(cnst);
            MySqlCommand cmd = new MySqlCommand(sql, connect);
            try
            {
                connect.Open();
                cmd.ExecuteNonQuery();
                connect.Close();
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }
    }
}
