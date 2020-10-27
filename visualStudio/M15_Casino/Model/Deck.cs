using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class Deck
    {
        public Deck()
        {
        }
        public int id { get; set; }
        public int tableId { get; set; }
        public int cardNum { get; set; }
        public char cardSuit { get; set; }
        public string playerName { get; set; }
        public bool played { get; set; }
    }
}
