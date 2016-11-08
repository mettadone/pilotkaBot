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

namespace PilotkaBot
{
    public static class SearchBot
    {
        public static string GetUrl(string url)
        {          
           
            return GetUrl(url, String.Empty); 
        }
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
        public static string GetUrl(string url, string name)
        {
            WebClient client = new WebClient();
            string html = client.DownloadString(url + HttpUtility.UrlEncode(name));
            
            return html;
        }
        public static double GetMoney(string url)
        {
            string money = GetUrl(url);
            Regex regex = new Regex(@"[^0-9]");
            money = regex.Replace(money,"");          
            return Convert.ToDouble(money)/100;
        }
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
        public static List<JsonResult> GetUrlJSONlist(string url)
        {

            return JsonConvert.DeserializeObject<List<JsonResult>>(GetUrl(url));
        }

        public static List<JsonInventoryResult> GetUrlJSONInventorylist(string url)
        {

            return JsonConvert.DeserializeObject<List<JsonInventoryResult>>(GetUrl(url));
        }
        public static Dictionary<string, string> GetUrlJSONparsIntoDictionary(string url)
        {

            return SearchBot.GetUrlJSON(url).ToDictionary();
        }

    }
}
