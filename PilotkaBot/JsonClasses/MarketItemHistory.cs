using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PilotkaBot.JsonClasses
{
    public class History
    {
        public string l_price { get; set; }
        public string l_time { get; set; }
    }

    public class MarketItemHistory
    {
        public bool success { get; set; }
        public int max { get; set; }
        public int min { get; set; }
        public int average { get; set; }
        public int number { get; set; }
        public List<History> history { get; set; }
    }
}
