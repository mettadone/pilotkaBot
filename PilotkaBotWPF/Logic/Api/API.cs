using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PilotkaBotWPF.Logic
{
    public static class API
    {

        public static string csgo_PingPong = @"https://market.csgo.com/api/PingPong/?key=";

        public static string csgo_getOrders = @"https://market.csgo.com/api/GetOrders/?key=";
        public static string csgo_getNotifications = @"https://market.csgo.com/api/GetNotifications/?key=";

        public static string csgoItemInfo = @"https://market.csgo.com/api/ItemInfo/";
        public static string csgobackpacknet = @"http://csgobackpack.net/api/GetItemPrice/?currency=RUB&id=";

        public static string csgo_itemRequest = @"https://market.csgo.com/api/ItemRequest/in/1/?key=";

        public static string XYZ_items_popular = @"http://api.csgo.steamlytics.xyz/v1/items/popular?limit=";
        public static string csgo_history = @"https://market.csgo.com/history/json/";
        public static string csgo_itemInfo = @"https://market.csgo.com/api/ItemInfo/";
        public static string csgo_insertOrder = @"https://market.csgo.com/api/InsertOrder/";

        public static string csgo_updateOrder = @"https://market.csgo.com/api/UpdateOrder/";
        public static string csgo_deleteOrder = @"https://market.csgo.com/api/DeleteOrders/?key=";

        public static string csgo_updateNotification = @"https://market.csgo.com/api/UpdateNotification/";

        public static string csgo_marketTrades = @"https://market.csgo.com/api/MarketTrades/?key=";
        public static string csgo_getMoney = @"https://market.dota2.net/api/GetMoney/?key=";
        public static string csgo_test = @"https://market.csgo.com/api/Test/?key=";

       // public static string csgo_itemInfo = @"https://market.csgo.com/api/ItemInfo/";
        public static string csgo_itemHistory = @"https://market.csgo.com/api/ItemHistory/";
        public static string csgo_trades = @"https://market.csgo.com/api/Trades/?key=";
        public static string steam_csgo_inventory = @"http://steamcommunity.com/profiles/" + steamProfileID + "/inventory/json/730/2/?trading=1";
        public static string csgo_setPrice = @"https://market.csgo.com/api/SetPrice/new_";

       // public static string csgo_trades = @"https://market.csgo.com/api/Trades/?key=";
       // public static string csgo_setPrice = @"https://market.csgo.com/api/SetPrice/";
        public static string csgo_removeAll = @"https://market.csgo.com/api/RemoveAll/?key=";

        public static string csgo_currentDB = @"https://market.csgo.com/itemdb/current_730.json";
        public static string csgo_getCurrentDB = @"https://market.csgo.com/itemdb/";

        public static string keyMarket = "3gu14Qg59zgKzw0aKT9FVo7oYY6ReS5";
        public static string keyXYZ = "8754a7606d6b00db0cc9ce1dee003256";
        public static string steamProfileID = "76561198131830880";
        public static string keySteampowered = "CD6CFA2F5346E01DB82C50067AEF6D73";
    }
}
