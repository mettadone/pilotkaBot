using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PilotkaBotWPF.JsonClasses
{

    public class Notification
    {
        public string i_classid { get; set; }
        public string i_instanceid { get; set; }
        public string i_market_hash_name { get; set; }
        public string i_market_name { get; set; }
        public string n_val { get; set; }
    }

    public class NotificationCollection
    {
        public bool success { get; set; }
        public List<Notification> Notifications { get; set; }
    }
}

