﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PilotkaBotWPF
{
    public class AppData
    {
        public string def_index { get; set; }
        public int is_itemset_name { get; set; }
    }

    public class Description
    {
        public string type { get; set; }
        public string value { get; set; }
        public string color { get; set; }
        public AppData app_data { get; set; }
    }

    public class Value
    {
        public string name { get; set; }
        public string link { get; set; }
    }

    public class Tag
    {
        public string internal_name { get; set; }
        public string name { get; set; }
        public string category { get; set; }
        public string category_name { get; set; }
        public string color { get; set; }
        public List<Value> value { get; set; }
    }

    public class MarketItemInfo
    {
        public string classid { get; set; }
        public string instanceid { get; set; }
        public string our_market_instanceid { get; set; }
        public string market_name { get; set; }
        public string name { get; set; }
        public string market_hash_name { get; set; }
        public string rarity { get; set; }
        public string quality { get; set; }
        public string type { get; set; }
        public string mtype { get; set; }
        public string slot { get; set; }
        public List<Description> description { get; set; }
        public List<Tag> tags { get; set; }
        public string hash { get; set; }
        public int min_price { get; set; }
    }
}
