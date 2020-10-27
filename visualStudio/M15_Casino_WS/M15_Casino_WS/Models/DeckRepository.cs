using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace M15_Casino_WS.Models
{
    public class DeckRepository
    {
        public static List<Deck> GetTableDeck(int id)
        {
            casinoEntities dataContext = new casinoEntities();
            List<Deck> lc = dataContext.Decks.Where(x => x.tableId == id).ToList();
            return lc;
        }

        public static List<Deck> GetTableDeckPlayerCards(int id, string name)
        {
            casinoEntities dataContext = new casinoEntities();
            List<Deck> lc = dataContext.Decks.Where(x => x.tableId == id && x.playerName.Equals(name)).ToList();
            return lc;
        }

        public static List<Deck> GetTableCommonCards(int id)
        {
            casinoEntities dataContext = new casinoEntities();
            List<Deck> lc = dataContext.Decks.Where(x => x.tableId == id && x.playerName.Equals("Admin")).ToList();
            return lc;
        }

        public static void UpdateDeckTable(int id, Deck d)
        {
            casinoEntities dataContext = new casinoEntities();
            try
            {

                Deck p0 = dataContext.Decks.Where(x => x.tableId == id && x.cardNum == d.cardNum && x.cardSuit.Equals(d.cardSuit)).SingleOrDefault();

                if (d.playerName != null) p0.playerName = d.playerName;
                if (d.played != null) p0.played = d.played;

                dataContext.SaveChanges();
            }
            catch (Exception e)
            {
            }
        }

    }
}