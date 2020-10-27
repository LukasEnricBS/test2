using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class CRUD
    {
        private static string ws1 = Globals.ws1;
        public CRUD()
        {
        }

        /**************************************** GET *********************************/

        public Player GetPlayerByName(string name)
        {
            Player c = (Player)MakeRequest(string.Concat(ws1, "players/", name), null, "GET", "application/json", typeof(Player));
            return c;
        }

        public List<Player> GetAllPlayers()
        {
            List<Player> c = (List<Player>)MakeRequest(string.Concat(ws1, "players/"), null, "GET", "application/json", typeof(List<Player>));
            return c;
        }

        public List<Player> GetPlayerRanking()
        {
            List<Player> c = (List<Player>)MakeRequest(string.Concat(ws1, "ranking/"), null, "GET", "application/json", typeof(List<Player>));
            return c;
        }

        public List<MoneyRequest> GetMoneyRequestByName(string name)
        {
            List<MoneyRequest> c = (List<MoneyRequest>)MakeRequest(string.Concat(ws1, "requestsN/", name), null, "GET", "application/json", typeof(List<MoneyRequest>));
            return c;
        }

        public List<GameTable> GetGameTables()
        {
            List<GameTable> c = (List<GameTable>)MakeRequest(string.Concat(ws1, "tables/"), null, "GET", "application/json", typeof(List<GameTable>));
            return c;
        }

        public GameTable GetGameTableByName(string name)
        {
            GameTable c = (GameTable)MakeRequest(string.Concat(ws1, "tableName/", name), null, "GET", "application/json", typeof(GameTable));
            return c;
        }

        public List<PlayerTable> GetPlayersInTable(int id)
        {
            List<PlayerTable> c = (List<PlayerTable>)MakeRequest(string.Concat(ws1, "playerTables/", id), null, "GET", "application/json", typeof(List<PlayerTable>));
            return c;
        }

        public PlayerTable GetPlayerInTableByName(string name)
        {
            PlayerTable c = (PlayerTable)MakeRequest(string.Concat(ws1, "playerTablesN/", name), null, "GET", "application/json", typeof(PlayerTable));
            return c;
        }

        public List<Deck> GetCommonCardsInTable(int id)
        {
            List<Deck> c = (List<Deck>)MakeRequest(string.Concat(ws1, "deckC/", id), null, "GET", "application/json", typeof(List<Deck>));
            return c;
        }

        public List<Deck> GetTablePlayerCards(int id, string name)
        {
            List<Deck> c = (List<Deck>)MakeRequest(string.Concat(ws1, "deckN/", id,"/",name), null, "GET", "application/json", typeof(List<Deck>));
            return c;
        }

        /**************************************** POST *********************************/

        public Player InsertPlayer(Player p2Add)
        {
            Player c = (Player)MakeRequest(string.Concat(ws1, "player/"), p2Add, "POST", "application/json", typeof(Player));
            return c;
        }

        public MoneyRequest InsertMoneyRequest(MoneyRequest mr2Add)
        {
            MoneyRequest c = (MoneyRequest)MakeRequest(string.Concat(ws1, "request/"), mr2Add, "POST", "application/json", typeof(MoneyRequest));
            return c;
        }

        public GameTable InsertGameTable(GameTable gt2Add)
        {
            GameTable c = (GameTable)MakeRequest(string.Concat(ws1, "table/"), gt2Add, "POST", "application/json", typeof(GameTable));
            return c;
        }

        public PlayerTable InsertPlayerTable(PlayerTable gt2Add)
        {
            PlayerTable c = (PlayerTable)MakeRequest(string.Concat(ws1, "playerTable/"), gt2Add, "POST", "application/json", typeof(PlayerTable));
            return c;
        }

        /**************************************** PUT **********************************/

        public Player UpdatePlayer(Player p2Upd)
        {
            Player c = (Player)MakeRequest(string.Concat(ws1, "player/", p2Upd.usrName), p2Upd, "PUT", "application/json", typeof(Player));
            return c;
        }

        public PlayerTable UpdateTablePlayer(PlayerTable p2Upd)
        {
            PlayerTable c = (PlayerTable)MakeRequest(string.Concat(ws1, "playerTable/", p2Upd.playerName), p2Upd, "PUT", "application/json", typeof(PlayerTable));
            return c;
        }

        /**************************************** DELETE *******************************/

        public void DeleteGameTable(int id)
        {
            MakeRequest(string.Concat(ws1, "table/", id), null, "DELETE", null, typeof(void));
        }

        public void DeletePlayerTable(int id, string name)
        {
            MakeRequest(string.Concat(ws1, "playerTable/", id,"/",name), null, "DELETE", null, typeof(void));
        }


        /********************************* MAKE REQUEST ********************************/

        public object MakeRequest(string requestUrl, object JSONRequest, string JSONmethod, string JSONContentType, Type JSONResponseType)
        //  requestUrl: Url completa del Web Service, amb l'opció sol·licitada
        //  JSONrequest: objecte que se li passa en el body (només per a POST/PUT)
        //  JSONmethod: "GET"/"POST"/"PUT"/"DELETE"
        //  JSONContentType: "application/json" en els casos que el Web Service torni objectes
        //  JSONRensponseType:  tipus d'objecte que torna el Web Service (typeof(tipus))
        {
            try
            {
                HttpWebRequest request = WebRequest.Create(requestUrl) as HttpWebRequest; //WebRequest WR = WebRequest.Create(requestUrl);   
                string sb = JsonConvert.SerializeObject(JSONRequest);
                request.Method = JSONmethod;  // "GET"/"POST"/"PUT"/"DELETE";  

                if (JSONmethod != "GET")
                {
                    request.ContentType = JSONContentType; // "application/json";   
                    Byte[] bt = Encoding.UTF8.GetBytes(sb);
                    Stream st = request.GetRequestStream();
                    st.Write(bt, 0, bt.Length);
                    st.Close();
                }

                using (HttpWebResponse response = request.GetResponse() as HttpWebResponse)
                {
                    if (response.StatusCode != HttpStatusCode.OK)
                        throw new Exception(String.Format("Server error (HTTP {0}: {1}).", response.StatusCode, response.StatusDescription));

                    Stream stream1 = response.GetResponseStream();
                    StreamReader sr = new StreamReader(stream1);
                    string strsb = sr.ReadToEnd();
                    object objResponse = JsonConvert.DeserializeObject(strsb, JSONResponseType);
                    return objResponse;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return null;
            }
        }
    }
}
