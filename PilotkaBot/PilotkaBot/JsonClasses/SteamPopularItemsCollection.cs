using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PilotkaBot.JsonClasses
{
    public class SteamPopularItemsCollection
    {
        public bool success { get; set; }
        public List<SteamPopularItem> items { get; set; }
        public int build_time { get; set; }
        public int updated_at { get; set; }
    }

    public class SteamPopularItem
    {
        public int rank { get; set; }
        public string market_hash_name { get; set; }
        public int volume { get; set; }
    }
}
