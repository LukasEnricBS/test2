using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace M15_Casino_WS.Models
{
    public class PlayerTableRepository
    {
        public static List<PlayerTable> GetPlayerTableByTableId(int id)
        {
            casinoEntities dataContext = new casinoEntities();
            List<PlayerTable> lc = dataContext.PlayerTables.Where(x => x.tableId == id).OrderBy(x => x.tableId).ToList();
            return lc;
        }

        public static PlayerTable GetPlayerTableByPlayerName(string name)
        {
            casinoEntities dataContext = new casinoEntities();
            PlayerTable p = dataContext.PlayerTables.Where(x => x.playerName == name).SingleOrDefault();
            return p;
        }

        public static PlayerTable InsertPlayerTable(PlayerTable p)
        {
            casinoEntities dataContext = new casinoEntities();
            try
            {
                dataContext.PlayerTables.Add(p);
                dataContext.SaveChanges();
                return GetPlayerTableByPlayerName(p.playerName);
            }
            catch (Exception e)
            {
                return null;
            }
        }

        public static void DeletePlayerTable(int id, string name)
        {
            casinoEntities dataContext = new casinoEntities();
            PlayerTable m = dataContext.PlayerTables.Where(x => x.playerName == name && x.tableId == id).SingleOrDefault();
            if (m != null)
            {
                dataContext.PlayerTables.Remove(m);
                dataContext.SaveChanges();
            }
        }

        public static PlayerTable UpdatePlayerTable(string name, PlayerTable p)
        {
            casinoEntities dataContext = new casinoEntities();
            try
            {
                PlayerTable p0 = dataContext.PlayerTables.Where(x => x.playerName == name && x.tableId == p.tableId).SingleOrDefault();

                if (p.totalBet != null) p0.totalBet = p.totalBet;
                if (p.isActivePlayer != null) p0.isActivePlayer = p.isActivePlayer;
                if (p.isBigBlind != null) p0.isBigBlind = p.isBigBlind;
                if (p.isSmallBlind != null) p0.isSmallBlind = p.isSmallBlind;
                if (p.hasFolded != null) p0.hasFolded = p.hasFolded;
                dataContext.SaveChanges();
                return GetPlayerTableByPlayerName(p.playerName);
            }
            catch (Exception e)
            {
                return null;
            }
        }

    }
}