using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft;
using System.Web;
using HtmlAgilityPack;
using System.Text.RegularExpressions;
using Newtonsoft.Json.Linq;
using PilotkaBot.JsonClasses;

using static PilotkaBot.Logic.API;


namespace PilotkaBot
{
    public static class Info
    {


        public static string dbMarketName = "marketDB.csv";

        #region get
        /// <summary>
        /// get without parameters
        /// </summary>
        /// <param name="url">url</param>
        /// <returns>html document in text format</returns>
        public static string GetUrl(string url)
        {          
           
            return GetUrl(url, String.Empty); 
        }
        /// <summary>
        /// NameValueCollection
        /// </summary>
        /// <param name="url"></param>
        /// <returns></returns>
        public static NameValueCollection GetUrlJSON(string url)
        {
            WebClient client = new WebClient();
            Stream html = client.OpenRead(url);
            var pars = new NameValueCollection();

            using (var webClient = new WebClient())
            {
                webClient.QueryString.Add("format", "json");
                // Выполняем запрос по адресу и получаем ответ в виде строки
                //html = webClient.DownloadString(url);
                var response = webClient.UploadValues(url, pars);
            }


            return pars;
        }
        public static string POST(string Url, string Data)
        {
            System.Net.WebRequest req = System.Net.WebRequest.Create(Url);
            req.Method = "POST";
            req.Timeout = 100000;
            req.ContentType = "application/x-www-form-urlencoded";
            byte[] sentData = Encoding.GetEncoding(1251).GetBytes(Data);
            req.ContentLength = sentData.Length;
            System.IO.Stream sendStream = req.GetRequestStream();
            sendStream.Write(sentData, 0, sentData.Length);
            sendStream.Close();
            System.Net.WebResponse res = req.GetResponse();
            System.IO.Stream ReceiveStream = res.GetResponseStream();
            System.IO.StreamReader sr = new System.IO.StreamReader(ReceiveStream, Encoding.UTF8);
            //Кодировка указывается в зависимости от кодировки ответа сервера
            Char[] read = new Char[256];
            int count = sr.Read(read, 0, 256);
            string Out = String.Empty;
            while (count > 0)
            {
                String str = new String(read, 0, count);
                Out += str;
                count = sr.Read(read, 0, 256);
            }
            return Out;
        }
        /// <summary>
        /// Get document by url plus name who add in tail url
        /// </summary>
        /// <param name="url">http:// or https:// format</param>
        /// <param name="name">parameters with name (encoding uri, with %%%%)</param>
        /// <returns>document html in string format</returns>
        public static string GetUrl(string url, string name)
        {
            WebClient client = new WebClient();
            string html = client.DownloadString(url + HttpUtility.UrlEncode(name));
            
            return html;
        }
        public static void LoadFile(string url, string saveToFileName)
        {

            LoadFile(url, String.Empty, saveToFileName);
        }
        public static void LoadFile(string url, string loadFileName, string saveToFileName)
        {
            WebClient client = new WebClient();
            client.DownloadFile(url + HttpUtility.UrlEncode(loadFileName), saveToFileName);
        }
        public static double GetMoney(string url)
        {
            string money = GetUrl(url);
            Regex regex = new Regex(@"[^0-9]");
            money = regex.Replace(money,"");          
            return Convert.ToDouble(money)/100;
        }
        /// <summary>
        /// HtmlNode
        /// </summary>
        /// <param name="url"></param>
        /// <param name="name"></param>
        /// <returns></returns>
        public static string HtmlPriceParse(string url, string name)
        {
            string html = GetUrl(url, name);
            HtmlDocument doc = new HtmlDocument();
            doc.LoadHtml(html);
            List<HtmlNode> resultNodes = null;

            // Собственно, здесь и производится выборка интересующих нодов
            // В данном случае выбираем блочные элементы с классом eTitle
            foreach (HtmlNode divResult in doc.DocumentNode.SelectNodes(@"//div[@class='market_listing_row market_recent_listing_row market_listing_searchresult']"))
            {
                HtmlDocument docItem = new HtmlDocument();
                docItem.LoadHtml(divResult.OuterHtml);
                foreach (HtmlNode nameNode in docItem.DocumentNode.SelectNodes(@"//span[@class='market_listing_item_name']"))
                {
                    if (name == nameNode.InnerText)
                    {
                        foreach (HtmlNode priceNode in docItem.DocumentNode.SelectNodes(@"//span[@class='normal_price']"))
                        {
                            return priceNode.InnerText;
                        }
                    }
                }
            }
            return null;
         //   HtmlNodeCollection NoAltElements = doc.DocumentNode.SelectNodes("//span[@class='normal_price']");
        }
        public static MarketItemInfo GetMarketItemInfo(string url)
        {
            return JsonConvert.DeserializeObject<MarketItemInfo>(GetUrl(url));
        }
        public static MarketItemHistory GetMarketItemHistory(string url)
        {
            return JsonConvert.DeserializeObject<MarketItemHistory>(GetUrl(url));
        }
        public static SteamItem GetSteamItem(string url)
        {
            return JsonConvert.DeserializeObject<SteamItem>(GetUrl(url));
        }
        public static SteamApiItem GetSteamApiItem(string url)
        {
            return JsonConvert.DeserializeObject<SteamApiItem>(GetUrl(url));
        }
        public static List<JsonResult> GetUrlJSONlist(string url)
        {
            return JsonConvert.DeserializeObject<List<JsonResult>>(GetUrl(url));
        }
        public static SteamApiItemCS GetApiItemCS(string url)
        {
            return JsonConvert.DeserializeObject<SteamApiItemCS>(GetUrl(url));
        }
        public static CurrentDB GetCurrentDB(string url)
        {
            return JsonConvert.DeserializeObject<CurrentDB>(GetUrl(url));
        }
        #endregion
        public static List<Order> GetOrders()
        {
            JObject result = null;
            Info.GetUrlJSON(csgo_getOrders + keyMarket, ref result);
            if (result["Orders"].ToString() != "No orders")
            {
                List<Order> orders = null;
                Converter.JsonToOrdersList(result, ref orders);
                return orders;
            }
            return null;
        }

        public static List<Notification> GetNotifications()
        {
            JObject result = null;
            Info.GetUrlJSON(csgo_getNotifications + keyMarket, ref result);
            if (result["Notifications"].ToString() != "No notifications")
            {
                List<Notification> notifications = null;
                Converter.JsonToNotificationsList(result, ref notifications);
                return notifications;
            }
            return null;
        }
        /// <summary>
        /// JsonInventoryResult
        /// </summary>
        /// <param name="url"></param>
        /// <returns></returns>
        public static List<JsonInventoryResult> GetUrlJSONInventorylist(string url)
        {

            return JsonConvert.DeserializeObject<List<JsonInventoryResult>>(GetUrl(url));
        }
        /// <summary>
        /// RootObject
        /// </summary>
        /// <param name="url"></param>
        /// <returns></returns>
        public static void GetUrlJSON(string url, ref JObject jObject)
        {

            jObject = (JObject)JsonConvert.DeserializeObject(GetUrl(url));
        }


        /// <summary>
        /// Dictionary
        /// </summary>
        /// <param name="url"></param>
        /// <returns></returns>
        public static Dictionary<string, string> GetUrlJSONparsIntoDictionary(string url)
        {

            return Info.GetUrlJSON(url).ToDictionary();
        }


    }
}
