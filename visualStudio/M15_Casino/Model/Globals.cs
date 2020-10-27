using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public static class Globals
    {
        public static Player activeUser;
        public static GameTable currentTable;
        public static PlayerTable gameStats;
        public static List<PlayerTable> playersInGame;
        public static List<Deck> tableDeck;
        public static readonly string resourceDirectory = "..\\..\\..\\resources\\";


        /* ONLINE CONVEYOR */
        public static readonly string ws1 = "https://m15-casino-ws.conveyor.cloud/api/";
        public static readonly string wsUri = string.Format("wss://m15-casino-ws.conveyor.cloud//api/websocket");

        /* OFFLINE CONVEYOR */
        //public static readonly string ws1 = "https://192.168.1.35:45455/api/";
        //public static readonly string wsUri = string.Format("wss://localhost:44344/api/websocket");
        
    }
}
