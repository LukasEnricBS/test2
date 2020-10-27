using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class GameTable
    {
        public GameTable()
        {
        }
        public int id { get; set; }
        public string name { get; set; }
        public int maxPlayers { get; set; }
        public string pwd { get; set; }
    }
}
