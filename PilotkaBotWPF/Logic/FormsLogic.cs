using PilotkaBotWPF.JsonClasses;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Forms;

using static PilotkaBotWPF.Logic.API;

namespace PilotkaBotWPF.Logic
{
    static class FormsLogic
    {
        private static string average_market_price;
        private static string max_earnings;
        private static string highest_market_price;
        private static string average_earnings;
        private static string lowest_market_price;

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

        internal static void DeleteColumns(ref System.Windows.Controls.DataGrid data, List<string> columnsNames)
        {
            for (int i = 0; i < columnsNames.Count; i++)
            {
                for(int j = 0; j < data.Columns.Count; j++)
                    if(columnsNames[i] == data.Columns[i].Header.ToString())
                data.Columns.RemoveAt(j);
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

        internal static void AddColumns(ref System.Windows.Controls.DataGrid data, List<string> columnsNames)
        {
            for (int i = 0; i < columnsNames.Count; i++)
            {
                DataGridTextColumn textColumn = new DataGridTextColumn();
                textColumn.Header = columnsNames[i];
                textColumn.Binding = new System.Windows.Data.Binding(columnsNames[i]);
                data.Columns.Add(textColumn);

                
                
            }
        }

        internal static void AddSteamPrices(ref System.Windows.Controls.DataGrid data)
        {
            for (int i = 0; i < data.Items.Count; i++)
            {
                MarketItemInfo marketInfo = Info.GetMarketItemInfo(csgoItemInfo + (data.Items[i] as ItemId).classid + "_"
                    + (data.Items[i] as ItemId).instanceid + "/ru/?key=" + keyMarket);
                SteamApiItemCS steamInfo = Info.GetApiItemCS(csgobackpacknet + marketInfo.market_hash_name + "&time=7&icon=1");//Info.GetSteamApiItem(@"http://api.csgo.steamlytics.xyz/v1/prices/" + marketInfo.market_hash_name + "?key=8754a7606d6b00db0cc9ce1dee003256");
                
                var newItem = new dataItem
                {
                    average_price = steamInfo.average_price,
                    median_price = steamInfo.median_price,
                    highest_price = steamInfo.highest_price,
                    lowest_price = steamInfo.lowest_price,
                };
                data.Items[i] = newItem;
                //data.Rows[i].Cells["hash"].Value = marketInfo.hash;
                // Thread.Sleep(10500);
            }
        }

        public class dataItem
        {
            public string average_price;
            public string median_price;
            public string highest_price;
            public string lowest_price;
        }

        internal static void AddEarnings(ref System.Windows.Controls.DataGrid data)
        {

            for (int i = 0; i < data.Items.Count; i++)
            {
                if (data.Items[i] != null)
                {/*
                    data.Rows[i].Cells["min_earnings"].Value = Earnings(data.Rows[i].Cells["lowest_price"].Value.ToString(),
                        data.Rows[i].Cells["lowest_market_price"].Value.ToString());
                    data.Rows[i].Cells["average_earnings"].Value = Earnings(data.Rows[i].Cells["average_price"].Value.ToString(),
                        data.Rows[i].Cells["average_market_price"].Value.ToString());
                    data.Rows[i].Cells["max_earnings"].Value = Earnings(data.Rows[i].Cells["highest_price"].Value.ToString(),
                        data.Rows[i].Cells["highest_market_price"].Value.ToString());
                        */
                    var newItem = new dataItemEarnings
                    {
                        min_earnings = Earnings((data.Items[i] as dataItemEarnings).lowest_price.ToString(),
                        (data.Items[i] as dataItemEarnings).lowest_market_price.ToString()),

                        lowest_market_price = (data.Items[i] as dataItemEarnings).lowest_market_price.ToString(),
                        average_earnings = Earnings((data.Items[i] as dataItemEarnings).average_price.ToString(),
                        (data.Items[i] as dataItemEarnings).average_market_price.ToString()),

                        average_market_price = (data.Items[i] as dataItemEarnings).average_market_price.ToString(),
                        max_earnings = Earnings((data.Items[i] as dataItemEarnings).highest_price.ToString(),
                        (data.Items[i] as dataItemEarnings).highest_market_price.ToString()),

                        highest_market_price = (data.Items[i] as dataItemEarnings).highest_market_price.ToString(),

                        lowest_price = (data.Items[i] as dataItemEarnings).lowest_price,
                        average_price = (data.Items[i] as dataItemEarnings).average_price,
                        highest_price = (data.Items[i] as dataItemEarnings).highest_price,
                    };
                    data.Items[i] = newItem;
                }
            }
        }

        public class dataItemEarnings
        {
            public string min_earnings;
            public string lowest_market_price;
            public string average_earnings;
            public string average_market_price;
            public string max_earnings;
            public string highest_market_price;
            public string lowest_price;
            public string average_price;
            public string highest_price;
        }

        public static void SaveItem(ref System.Windows.Controls.DataGrid dataSellSteam, int i, InventorySteamWindow.dataSellSteamItem newItem)
        {
            var coll = dataSellSteam.Items.SourceCollection;
            var outcoll = new List<object>();
            foreach (var item in coll)
                outcoll.Add(item);
            outcoll[i] = newItem;
            dataSellSteam.ItemsSource = outcoll;
        }

        
    }
}
