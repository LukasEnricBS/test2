using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class Player
    {
        public Player()
        {
        }
        public string usrName { get; set; }
        public string pwd { get; set; }
        public int currentMoney { get; set; }
        public int cardBack { get; set; }
        public int gameBg { get; set; }
    }
}
