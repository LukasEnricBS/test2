using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace M15_Casino_WS.Models
{
    public class GameTableRepository
    {

        public static List<GameTable> GetAllGameTables()
        {
            casinoEntities dataContext = new casinoEntities();
            List<GameTable> lc = dataContext.GameTables.OrderBy(x => x.name).ToList();
            return lc;
        }

        public static GameTable GetGameTable(int id)
        {
            casinoEntities dataContext = new casinoEntities();
            GameTable p = dataContext.GameTables.Where(x => x.id == id).SingleOrDefault();
            return p;
        }

        public static GameTable GetGameTableByName(string name)
        {
            casinoEntities dataContext = new casinoEntities();
            GameTable p = dataContext.GameTables.Where(x => x.name.Equals(name)).SingleOrDefault();
            return p;
        }

        public static GameTable InsertGameTable(GameTable p)
        {
            casinoEntities dataContext = new casinoEntities();
            try
            {
                dataContext.GameTables.Add(p);
                dataContext.SaveChanges();

                /*** CREATE DECK ***/

                foreach (var card in dataContext.GameCards.ToList())
                {
                    Deck d = new Deck();
                    d.tableId = p.id;
                    d.cardNum = card.num;
                    d.cardSuit = card.suit;
                    dataContext.Decks.Add(d);
                }
                dataContext.SaveChanges();

                /*** END CREATE DECK ***/

                return GetGameTable(p.id);
            }
            catch (Exception e)
            {
                return null;
            }
        }

        public static void DeleteGameTable(int id)
        {
            casinoEntities dataContext = new casinoEntities();
            GameTable m = dataContext.GameTables.Where(x => x.id == id).SingleOrDefault();
            if (m != null)
            {
                if (m.Decks != null)
                {
                    dataContext.Decks.RemoveRange(m.Decks);
                    dataContext.SaveChanges();
                }
                if (m.PlayerTables != null)
                {
                    dataContext.PlayerTables.RemoveRange(m.PlayerTables);
                    dataContext.SaveChanges();
                }
                dataContext.GameTables.Remove(m);
                dataContext.SaveChanges();
            }
        }

    }
}