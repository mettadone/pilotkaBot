using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PilotkaBot
{
    public class SteamApiItemCS
    {
        public bool success { get; set; }
        public string average_price { get; set; }
        public string median_price { get; set; }
        public string amount_sold { get; set; }
        public string standard_deviation { get; set; }
        public string lowest_price { get; set; }
        public string highest_price { get; set; }
        public string first_sale_date { get; set; }
        public string time { get; set; }
        public string icon { get; set; }
        public string currency { get; set; }
    }
}