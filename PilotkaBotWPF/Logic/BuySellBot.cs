using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using HtmlAgilityPack;

using static PilotkaBotWPF.Logic.API;
#pragma warning disable 0219
namespace PilotkaBotWPF
{
    /// <summary>
    /// Item Requests class
    /// </summary>
    public static class BuySellBot
    {
       

        public static void ItemRequest(string url)
        {
            Info.GetUrl(url);
        }
        public static void RunRequestByStatus(DataGridView data, IProgress<string> progress, ref bool requestMode)
        {
            for (int i = 0; i < data.Rows.Count; i++)
            {
                if (Convert.ToInt32(data.Rows[i].Cells["ui_status"].Value) == 2)
                {
                    BuySellBot.ItemRequest(csgo_itemRequest + keyMarket);
                }
                progress.Report(Convert.ToDouble((i + 1) * 100 / data.Rows.Count).ToString() + "%");
            }
            requestMode = false;
        }
        public static void RunRequestByStatus(DataGridView data)
        {
            for (int i = 0; i < data.Rows.Count; i++)
            {
                if (Convert.ToInt32(data.Rows[i].Cells["ui_status"].Value) == 2)
                {
                    BuySellBot.ItemRequest(csgo_itemRequest + keyMarket);
                }
            }
        }
        public static string BuyItemsInSteam(string url, string name)
        {
            string html = Info.GetUrl(url, name);
            HtmlAgilityPack.HtmlDocument doc = new HtmlAgilityPack.HtmlDocument();
            doc.LoadHtml(html);
            List<HtmlNode> resultNodes = null;

            // Собственно, здесь и производится выборка интересующих нодов
            // В данном случае выбираем блочные элементы с классом eTitle
            foreach (HtmlNode divResult in doc.DocumentNode.SelectNodes(@"//div[@class='market_buy_commodity_input']"))
            {
                HtmlAgilityPack.HtmlDocument docItem = new HtmlAgilityPack.HtmlDocument();
                docItem.LoadHtml(divResult.OuterHtml);
                foreach (HtmlNode nameNode in docItem.DocumentNode.SelectNodes(@"//input[@id='market_buy_commodity_input_quantity']"))
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
    }
}
