using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class PlayerTable
    {
        public PlayerTable()
        {
        }
        public int tableId { get; set; }
        public string playerName { get; set; }
        public int totalBet { get; set; }
        public bool isActivePlayer { get; set; }
        public bool isSmallBlind { get; set; }
        public bool isBigBlind { get; set; }
        public bool hasFolded { get; set; }
    }
}
