using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using static PilotkaBot.Logic.API;

namespace PilotkaBot.Logic
{
    static class FormsLogic
    {
       


        public static void AddColumns(ref DataGridView data, List<string> columnsNames)
        {
            for (int i = 0; i < columnsNames.Count; i++)
            {
                data.Columns.Add(columnsNames[i], columnsNames[i]);
            }
        }
        public static void DeleteColumns(ref DataGridView data, List<string> columnsNames)
        {
            for (int i = 0; i < columnsNames.Count; i++)
            {
                data.Columns.Remove(columnsNames[i]);
            }
        }
        public static void AddSteamPrices(ref DataGridView data)
        {

            for (int i = 0; i < data.RowCount; i++)
            {
                MarketItemInfo marketInfo = Info.GetMarketItemInfo(csgoItemInfo + data.Rows[i].Cells["classid"].Value + "_"
                    + data.Rows[i].Cells["instanceid"].Value + "/ru/?key=" + keyMarket);
                SteamApiItemCS steamInfo = Info.GetApiItemCS(csgobackpacknet + marketInfo.market_hash_name + "&time=7&icon=1");//Info.GetSteamApiItem(@"http://api.csgo.steamlytics.xyz/v1/prices/" + marketInfo.market_hash_name + "?key=8754a7606d6b00db0cc9ce1dee003256");
                data.Rows[i].Cells["average_price"].Value = steamInfo.average_price;
                data.Rows[i].Cells["median_price"].Value = steamInfo.median_price;
                data.Rows[i].Cells["highest_price"].Value = steamInfo.highest_price;
                data.Rows[i].Cells["lowest_price"].Value = steamInfo.lowest_price;
                //data.Rows[i].Cells["hash"].Value = marketInfo.hash;
                // Thread.Sleep(10500);
            }
        }
        static string Earnings(double steamPrice, double marketPrice)
        {
            if (marketPrice - steamPrice > 0)
                return Math.Abs(marketPrice - steamPrice).ToString() + " on Market";
            else return Math.Abs(marketPrice - steamPrice).ToString() + " on Steam";
        }
        static string Earnings(string steamPrice, string marketPrice)
        {
            double convertedMarketPrice = Convert.ToDouble(marketPrice);
            double convertedSteamPrice = Convert.ToDouble(steamPrice, new NumberFormatInfo() { CurrencyDecimalSeparator = "." });
            if (convertedMarketPrice - convertedSteamPrice > 0)
                return Math.Round(Math.Abs(convertedMarketPrice - convertedSteamPrice),3).ToString() + " on Market";
            else return Math.Round(Math.Abs(convertedMarketPrice - convertedSteamPrice),3).ToString() + " on Steam";
            
        }
        public static void AddEarnings(ref DataGridView data)
        {

            for (int i = 0; i < data.RowCount; i++)
            {
                if (data.Rows[i].DataBoundItem != null)
                {
                    data.Rows[i].Cells["min_earnings"].Value = Earnings(data.Rows[i].Cells["lowest_price"].Value.ToString(),
                        data.Rows[i].Cells["lowest_market_price"].Value.ToString());
                    data.Rows[i].Cells["average_earnings"].Value = Earnings(data.Rows[i].Cells["average_price"].Value.ToString(),
                        data.Rows[i].Cells["average_market_price"].Value.ToString());
                    data.Rows[i].Cells["max_earnings"].Value = Earnings(data.Rows[i].Cells["highest_price"].Value.ToString(),
                        data.Rows[i].Cells["highest_market_price"].Value.ToString());
                }
            }
        }
    }
}
