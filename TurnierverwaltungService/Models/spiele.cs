using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TurnierverwaltungService.Models
{
    public class spiele
    {
        private int _SpielID;
        private int _TurnierID;
        private int _MS1;
        private int _MS2;
        private int _Ergebnis1;
        private int _Ergebnis2;

        public int SpielID { get => _SpielID; set => _SpielID = value; }
        public int TurnierID { get => _TurnierID; set => _TurnierID = value; }
        public int MS1 { get => _MS1; set => _MS1 = value; }
        public int MS2 { get => _MS2; set => _MS2 = value; }
        public int Ergebnis1 { get => _Ergebnis1; set => _Ergebnis1 = value; }
        public int Ergebnis2 { get => _Ergebnis2; set => _Ergebnis2 = value; }

        public spiele()
        {
            this.SpielID = -1;
            this.TurnierID = -1;
        }

        public spiele(int TID, int SID, int MS1ID, int MS2ID, int ERG1, int ERG2)
        {
            this.TurnierID = TID;
            this.SpielID = SID;
            this.MS1 = MS1ID;
            this.MS2 = MS2ID;
            this.Ergebnis1 = ERG1;
            this.Ergebnis2 = ERG2;
        }
    }
}