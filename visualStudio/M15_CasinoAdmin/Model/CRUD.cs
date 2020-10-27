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
        /* LOCALHOST URL */
        //private static string ws1 = "https://localhost:44344/api/";
        /* CONVEYOR LOCAL URL */
        //private static string ws1 = "https://192.168.1.35:45455/api/";
        /* ONLINE URL */
        private static string ws1 = "https://m15-casino-ws.conveyor.cloud/api/";

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

        public List<MoneyRequest> GetAllMoneyRequests()
        {
            List<MoneyRequest> c = (List<MoneyRequest>)MakeRequest(string.Concat(ws1, "requests/"), null, "GET", "application/json", typeof(List<MoneyRequest>));
            return c;
        }

        public MoneyRequest GetMoneyRequestById(int id)
        {
            MoneyRequest c = (MoneyRequest)MakeRequest(string.Concat(ws1, "requests/", id), null, "GET", "application/json", typeof(MoneyRequest));
            return c;
        }

        public List<MoneyRequest> GetPendingMoneyRequests()
        {
            List<MoneyRequest> c = (List<MoneyRequest>)MakeRequest(string.Concat(ws1, "pendingRequests/"), null, "GET", "application/json", typeof(List<MoneyRequest>));
            return c;
        }

        public List<MoneyRequest> GetAcceptedMoneyRequests()
        {
            List<MoneyRequest> c = (List<MoneyRequest>)MakeRequest(string.Concat(ws1, "acceptedRequests/"), null, "GET", "application/json", typeof(List<MoneyRequest>));
            return c;
        }

        public List<MoneyRequest> GetDeniedMoneyRequests()
        {
            List<MoneyRequest> c = (List<MoneyRequest>)MakeRequest(string.Concat(ws1, "deniedRequests/"), null, "GET", "application/json", typeof(List<MoneyRequest>));
            return c;
        }

        /**************************************** POST *********************************/

        public Player InsertPlayer(Player p2Add)
        {
            Player c = (Player)MakeRequest(string.Concat(ws1, "player/"), p2Add, "POST", "application/json", typeof(Player));
            return c;
        }


        /**************************************** PUT **********************************/

        public Player UpdatePlayer(Player p2Upd)
        {
            Player c = (Player)MakeRequest(string.Concat(ws1, "player/", p2Upd.usrName), p2Upd, "PUT", "application/json", typeof(Player));
            return c;
        }

        public MoneyRequest UpdateRequest(MoneyRequest mr2Upd)
        {
            MoneyRequest c = (MoneyRequest)MakeRequest(string.Concat(ws1, "request/", mr2Upd.id), mr2Upd, "PUT", "application/json", typeof(MoneyRequest));
            return c;
        }

        /**************************************** DELETE *******************************/

        public void DeletePlayer(string id)
        {
            MakeRequest(string.Concat(ws1, "player/", id), null, "DELETE", null, typeof(void));
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

