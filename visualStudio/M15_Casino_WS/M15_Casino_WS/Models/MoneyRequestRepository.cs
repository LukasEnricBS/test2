using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace M15_Casino_WS.Models
{
    public class MoneyRequestRepository
    {

        public static List<MoneyRequest> GetAllMoneyRequests()
        {
            casinoEntities dataContext = new casinoEntities();
            List<MoneyRequest> lc = dataContext.MoneyRequests.OrderBy(x => x.playerName).ToList();
            return lc;
        }

        public static MoneyRequest GetMoneyRequest(int id)
        {
            casinoEntities dataContext = new casinoEntities();
            MoneyRequest p = dataContext.MoneyRequests.Where(x => x.id == id).SingleOrDefault();
            return p;
        }

        public static List<MoneyRequest> GetMoneyRequestsByName(string name)
        {
            casinoEntities dataContext = new casinoEntities();
            List<MoneyRequest> p = dataContext.MoneyRequests.Where(x => x.playerName.Equals(name)).ToList();
            return p;
        }

        public static List<MoneyRequest> GetAllPendingMoneyRequests()
        {
            casinoEntities dataContext = new casinoEntities();
            List<MoneyRequest> lc = dataContext.MoneyRequests.Where(x=>x.pending == true).OrderBy(x => x.playerName).ToList();
            return lc;
        }

        public static List<MoneyRequest> GetAllAcceptedMoneyRequests()
        {
            casinoEntities dataContext = new casinoEntities();
            List<MoneyRequest> lc = dataContext.MoneyRequests.Where(x => x.accepted == true && x.pending == false).OrderBy(x => x.playerName).ToList();
            return lc;
        }

        public static List<MoneyRequest> GetAllDeniedMoneyRequests()
        {
            casinoEntities dataContext = new casinoEntities();
            List<MoneyRequest> lc = dataContext.MoneyRequests.Where(x => x.accepted == false && x.pending == false).OrderBy(x => x.playerName).ToList();
            return lc;
        }

        public static MoneyRequest InsertMoneyRequest(MoneyRequest p)
        {
            casinoEntities dataContext = new casinoEntities();
            try
            {
                dataContext.MoneyRequests.Add(p);
                dataContext.SaveChanges();
                return GetMoneyRequest(p.id);
            }
            catch (Exception e)
            {
                return null;
            }
        }

        public static MoneyRequest UpdateMoneyRequest(int id, MoneyRequest p)
        {
            casinoEntities dataContext = new casinoEntities();
            try
            {
                MoneyRequest p0 = dataContext.MoneyRequests.Where(x => x.id == id).SingleOrDefault();
                if (p.pending != null) p0.pending = p.pending;
                if (p.accepted != null) p0.accepted = p.accepted;
                dataContext.SaveChanges();
                return GetMoneyRequest(id);
            }
            catch (Exception e)
            {
                return null;
            }
        }
    }
}