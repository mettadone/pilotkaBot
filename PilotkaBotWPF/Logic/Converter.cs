using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using PilotkaBotWPF.JsonClasses;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Linq;

using static PilotkaBotWPF.Logic.API;

namespace PilotkaBotWPF
{
    public static class Converter
    {
        public static Dictionary<string, string> ToDictionary(this NameValueCollection nvc)
        {
            return nvc.AllKeys.ToDictionary(k => k, k => nvc[k]);
        }
        public static void JsonToTradeList(JObject jObject, ref List<Trade> listTrade)
        {
            if(jObject["success"].ToString() == "True")
                listTrade = JsonConvert.DeserializeObject<List<Trade>>(jObject["trades"].ToString());
        }
        public static void JsonToOrdersList(JObject jObject, ref List<Order> listOrder)
        {
            if (jObject["success"].ToString() == "True")
                listOrder = JsonConvert.DeserializeObject<List<Order>>(jObject["Orders"].ToString());
        }
        public static void JsonToNotificationsList(JObject jObject, ref List<Notification> listOrder)
        {
            if (jObject["success"].ToString() == "True")
                listOrder = JsonConvert.DeserializeObject<List<Notification>>(jObject["Notifications"].ToString());
        }
        public static List<JObject> jObjectToList(string name, JObject inJObject)
        {
            JObject outJObject = (JObject)inJObject[name];
            List<JObject> outList = new List<JObject>();
            foreach (var item in outJObject.Values())
                outList.Add((JObject)item);
            return outList;
        }
        public static List<SteamPopularItem> jArrayToSteamPopularItemsList(string name, JObject inJObject)
        {
            JArray tmpJArray = (JArray)inJObject[name];
            List<SteamPopularItem> outList = tmpJArray.ToObject<List<SteamPopularItem>>();
            return outList;
        }
        public static BindingList<JsonInventoryResult> InventoryListToBindingList(List<JsonInventoryResult> list)
        {
            BindingList<JsonInventoryResult> items = new BindingList<JsonInventoryResult>();
            var temp = list;
            foreach (var item in temp)
                items.Add(item);
            return items;
        }
    }
}
