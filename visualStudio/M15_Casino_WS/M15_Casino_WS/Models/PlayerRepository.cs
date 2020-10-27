using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace M15_Casino_WS.Models
{
    public class PlayerRepository
    {

        public static List<Player> GetAllPlayers()
        {
            casinoEntities dataContext = new casinoEntities();
            List<Player> lc = dataContext.Players.OrderBy(x => x.usrName).ToList();
            return lc;
        }

        public static List<Player> GetAllPlayersByMoney()
        {
            casinoEntities dataContext = new casinoEntities();
            List<Player> lc = dataContext.Players.OrderByDescending(x => x.currentMoney).ThenBy(x => x.usrName).ToList();
            return lc;
        }

        public static Player GetPlayer(string name)
        {
            casinoEntities dataContext = new casinoEntities();
            Player p = dataContext.Players.Where(x => x.usrName == name).SingleOrDefault();
            return p;
        }

        public static Player InsertPlayer(Player p)
        {
            casinoEntities dataContext = new casinoEntities();
            try
            {
                dataContext.Players.Add(p);
                dataContext.SaveChanges();
                return GetPlayer(p.usrName);
            }
            catch (Exception e)
            {
                return null;
            }
        }

        public static void DeletePlayer(string name)
        {
            casinoEntities dataContext = new casinoEntities();
            Player m = dataContext.Players.Where(x => x.usrName == name).SingleOrDefault();
            if (m != null)
            {
                if (m.MoneyRequests != null)
                {
                    dataContext.MoneyRequests.RemoveRange(m.MoneyRequests);
                    dataContext.SaveChanges();
                }
                dataContext.Players.Remove(m);
                dataContext.SaveChanges();
            }
        }

        public static Player UpdatePlayer(string name, Player p)
        {
            casinoEntities dataContext = new casinoEntities();
            try
            {
                Player p0 = dataContext.Players.Where(x => x.usrName == name).SingleOrDefault();

                if (p.pwd != null) p0.pwd = p.pwd;
                if (p.currentMoney != null) p0.currentMoney = p.currentMoney;
                if (p.cardBack != null) p0.cardBack = p.cardBack;
                if (p.gameBg != null) p0.gameBg = p.gameBg;
                dataContext.SaveChanges();
                return GetPlayer(name);
            }
            catch (Exception e)
            {
                return null;
            }
        }

    }
}