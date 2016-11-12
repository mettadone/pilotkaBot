using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PilotkaBotWPF
{
    public class Trade
    {
        public string dir { get; set; }
        public string trade_id { get; set; }
        public string bot_id { get; set; }
        public string timestamp { get; set; }
    }

    public class TradeCollection
    {
        public bool success { get; set; }
        public List<Trade> trades { get; set; }
    }
}
