using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PilotkaBotWPF.JsonClasses
{
    public class Order
    {
        public string i_classid { get; set; }
        public string i_instanceid { get; set; }
        public string i_market_hash_name { get; set; }
        public string i_market_name { get; set; }
        public string o_price { get; set; }
        public string o_state { get; set; }
    }

    public class OrdersCollection
    {
        public bool success { get; set; }
        public List<Order> Orders { get; set; }
    }

}
