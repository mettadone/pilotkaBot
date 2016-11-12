using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PilotkaBotWPF
{
    public class SteamApiItem
    {
        public bool success { get; set; }
        public string median_price { get; set; }
        public string median_net_price { get; set; }
        public string average_price { get; set; }
        public string average_net_price { get; set; }
        public string lowest_price { get; set; }
        public string lowest_net_price { get; set; }
        public string highest_price { get; set; }
        public string highest_net_price { get; set; }
        public string mean_absolute_deviation { get; set; }
        public double deviation_percentage { get; set; }
        public int volume { get; set; }
        public int first_seen { get; set; }
    }
}
