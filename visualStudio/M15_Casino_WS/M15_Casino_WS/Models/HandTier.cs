using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace M15_Casino_WS.Models
{
    public class HandTier
    {
        public HandTier()
        {
        }
        public string usrName { get; set; }
        public List<int> cards { get; set; }
        public List<string> suits { get; set; }
        public int priority { get; set; }
    }
}