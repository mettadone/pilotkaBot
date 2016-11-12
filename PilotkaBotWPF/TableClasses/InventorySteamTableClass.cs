using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PilotkaBotWPF.TableClasses
{
    public class InventorySteamTableClass
    {
        public string classid { get; set; }
        public string instanceid { get; set; }
        public string name { get; set; }
        public string type { get; set; }
        public string min_price { get; set; }
        public string average_market_price { get; set; }
        public string lowest_market_price { get; set; }
        public string highest_market_price { get; set; }
        public string average_price { get; set; }
        public string median_price { get; set; }
        public string highest_price { get; set; }
        public string lowest_price { get; set; }
        public string min_earnings { get; set; }
        public string average_earnings { get; set; }
        public string max_earnings { get; set; }
        public string count { get; set; }
    }
}
