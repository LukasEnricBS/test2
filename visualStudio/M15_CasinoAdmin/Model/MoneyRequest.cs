using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class MoneyRequest
    {
        public MoneyRequest()
        {
        }
        
        public int id { get; set; }
        public string playerName { get; set; }
        public int amount { get; set; }   
        public Boolean pending { get; set; }
        public Boolean accepted { get; set; }
    }
}
