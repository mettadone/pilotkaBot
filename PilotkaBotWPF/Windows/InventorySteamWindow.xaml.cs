using Newtonsoft.Json.Linq;
using PilotkaBotWPF;
using PilotkaBotWPF.JsonClasses;
using PilotkaBotWPF.Logic;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Forms;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using static PilotkaBotWPF.Logic.API;
namespace PilotkaBotWPF
{
    /// <summary>
    /// Логика взаимодействия для InventorySteamWindow.xaml
    /// </summary>
    public partial class InventorySteamWindow : Window
    {
        public InventorySteamWindow()
        {
            InitializeComponent();
            //dataGridView1.DataSource = SearchBot.GetUrlJSONInventorySteamlist(@"http://steamcommunity.com/profiles/76561198131830880/inventory/json/570/2/?trading=1");
            SetDataSourceAllItem();
            //FormsLogic.AddColumns(ref dataGridViewForSell, new List<string>()
            //{
            //    "name",
            //    "type",
            //    "min_price",
            //    "average_market_price",
            //    "lowest_market_price",
            //    "highest_market_price",
            //    "average_price",
            //    "median_price",
            //    "highest_price",
            //    "lowest_price",
            //    "min_earnings",
            //    "average_earnings",
            //    "max_earnings"
            //});
            SetDataSourceSellItem(dataGridViewForSell);
        }

        int rowIndex;
        string classid, instanceid;
        int currentColumnIndex = 0;
        List<JObject> itemsrgInventory;
        BindingList<JsonInventoryResult> marketItems;
        BindingList<ItemId> soldSteamItems;
        
        public List<ItemId> GetGroupItems(List<ItemId> listItems)
        {
            return listItems
                .GroupBy(itemId => itemId.classid, itemId => itemId.instanceid)
                .Select(group => new ItemId
                {
                    classid = group.Key,
                    instanceid = group.First(),
                    count = group.Count()
                }).ToList();
        }
        public BindingList<ItemId> SoldItemsFromSteam(List<ItemId> targetListSteam, List<ItemId> targetListMarket, ref int count)
        {
            List<ItemId> tttSteam = GetGroupItems(targetListSteam);
            List<ItemId> tttMarket = GetGroupItems(targetListMarket);
            BindingList<ItemId> sellItems = new BindingList<ItemId>();
            count = 0;
            if (tttMarket.Count > 0)
            {
                foreach (var itttSteam in tttSteam)
                {
                    bool found;
                    foreach (var itttMarket in tttMarket)
                    {
                        found = itttSteam.classid == itttMarket.classid &&
                            itttSteam.instanceid == itttMarket.instanceid;
                        if (found)
                        {
                            itttSteam.count -= itttMarket.count;
                            count += itttSteam.count;
                        }
                    }
                    if (itttSteam.count != 0)
                    {
                        sellItems.Add(itttSteam);
                    }
                }
            }
            else
            {
                foreach (var itttSteam in tttSteam)
                {
                    count += itttSteam.count;
                    if (itttSteam.count != 0)
                        sellItems.Add(itttSteam);
                }
            }
            if (count == 0)
            {
                foreach (var itttSteam in tttSteam)
                {
                    count += itttSteam.count;
                }
            }
            return sellItems;
        }
        public void AddParameters(DataGridView dataSellSteam)
        {
            for (int i = 0; i < dataSellSteam.Rows.Count; i++)
            {
                MarketItemInfo info = Info.GetMarketItemInfo(@"https://market.csgo.com/api/ItemInfo/" + dataSellSteam.Rows[i].Cells["classid"].Value + "_"
                    + dataSellSteam.Rows[i].Cells["instanceid"].Value + "/ru/?key=" + keyMarket);
                MarketItemHistory history = Info.GetMarketItemHistory(@"https://market.csgo.com/api/ItemHistory/" + info.classid + "_"
                    + info.instanceid + "?key=" + keyMarket);
                dataSellSteam.Rows[i].Cells["min_price"].Value = Convert.ToDouble(Math.Abs(info.min_price)) / 100;
                dataSellSteam.Rows[i].Cells["name"].Value = info.name;
                dataSellSteam.Rows[i].Cells["type"].Value = info.type;
                dataSellSteam.Rows[i].Cells["average_market_price"].Value = Convert.ToDouble(history.average) / 100;
                dataSellSteam.Rows[i].Cells["lowest_market_price"].Value = Convert.ToDouble(history.min) / 100;
                dataSellSteam.Rows[i].Cells["highest_market_price"].Value = Convert.ToDouble(history.max) / 100;
            }
        }
        public void SetDataSourceSellItem(DataGridView dataGridViewForSell)
        {
            marketItems = Converter.InventoryListToBindingList(Info.GetUrlJSONInventorylist(@"https://market.csgo.com/api/Trades/?key=" + keyMarket));
            var targetListSteam = itemsrgInventory.Select(x =>
                new ItemId() { classid = x["classid"].ToString(), instanceid = x["instanceid"].ToString() }).ToList();
            var targetListMarket = marketItems.Select(x =>
                new ItemId() { classid = x.i_classid, instanceid = x.ui_real_instance }).ToList();
            int count = 0;
            soldSteamItems = SoldItemsFromSteam(targetListSteam, targetListMarket, ref count);
            dataGridViewForSell.DataSource = soldSteamItems;
            labelCount.Content = "Count: " + count.ToString();
            AddParameters(dataGridViewForSell);
            FormsLogic.AddSteamPrices(ref dataGridViewForSell);
            FormsLogic.AddEarnings(ref dataGridViewForSell);
        }

        public void SetDataSourceAllItem()
        {
            //lightnining Y9PRN
            JObject result = null;
            Info.GetUrlJSON(@"http://steamcommunity.com/profiles/76561198131830880/inventory/json/730/2/?trading=1", ref result);
            itemsrgInventory = Converter.jObjectToList("rgInventory", result);
            dataGridViewAllItems.ItemsSource = itemsrgInventory;
        }
        private void FormInventorySteam_Load(object sender, EventArgs e)
        {
            //dataGridView1.DataSource = SearchBot.GetUrlJSONInventorySteamlist(@"http://steamcommunity.com/profiles/76561198131830880/inventory/json/570/2/?trading=1");
            SetDataSourceAllItem();
            FormsLogic.AddColumns(ref dataGridViewForSell, new List<string>()
            {
                "name",
                "type",
                "min_price",
                "average_market_price",
                "lowest_market_price",
                "highest_market_price",
                "average_price",
                "median_price",
                "highest_price",
                "lowest_price",
                "min_earnings",
                "average_earnings",
                "max_earnings"
            });
            SetDataSourceSellItem(dataGridViewForSell);
        }

        private void SetDataSourceSellItem(System.Windows.Controls.DataGrid dataGridViewForSell)
        {
            marketItems = Converter.InventoryListToBindingList(Info.GetUrlJSONInventorylist(@"https://market.csgo.com/api/Trades/?key=" + keyMarket));
            var targetListSteam = itemsrgInventory.Select(x =>
                new ItemId() { classid = x["classid"].ToString(), instanceid = x["instanceid"].ToString() }).ToList();
            var targetListMarket = marketItems.Select(x =>
                new ItemId() { classid = x.i_classid, instanceid = x.ui_real_instance }).ToList();
            int count = 0;
            soldSteamItems = SoldItemsFromSteam(targetListSteam, targetListMarket, ref count);
            dataGridViewForSell.ItemsSource = soldSteamItems;
            labelCount.Content = "Count: " + count.ToString();
            AddParameters(dataGridViewForSell);
            FormsLogic.AddSteamPrices(ref dataGridViewForSell);
            FormsLogic.AddEarnings(ref dataGridViewForSell);
        }

        private void AddParameters(System.Windows.Controls.DataGrid dataSellSteam)
        {
            for (int i = 0; i < dataSellSteam.Items.Count; i++)
            {
                MarketItemInfo info = Info.GetMarketItemInfo(@"https://market.csgo.com/api/ItemInfo/" +
                    (dataSellSteam.Items[i] as ItemId).classid + "_"
                    + (dataSellSteam.Items[i] as ItemId).instanceid 
                    + "/ru/?key=" + keyMarket);
                MarketItemHistory history = Info.GetMarketItemHistory(@"https://market.csgo.com/api/ItemHistory/" + info.classid + "_"
                    + info.instanceid + "?key=" + keyMarket);

                var newItem = new dataSellSteamItem
                {
                    min_price = "" + Convert.ToDouble(Math.Abs(info.min_price)) / 100,
                    name = info.name,
                    type = info.type,
                    average_market_price = "" + Convert.ToDouble(history.average) / 100,
                    lowest_market_price = "" + Convert.ToDouble(history.min) / 100,
                    highest_market_price = "" + Convert.ToDouble(history.max) / 100,
                };

                FormsLogic.SaveItem(ref dataSellSteam, i, newItem);
            }
        }

        public static void SaveItem(ref System.Windows.Controls.DataGrid dataSellSteam, int i, dataSellSteamItem newItem)
        {
            var items = dataSellSteam.Items;
            items[i] = newItem;
            dataSellSteam.ItemsSource = items;
        }

        public class dataSellSteamItem
        {
            public string min_price;
            public string name;
            public string type;
            public string average_market_price;
            public string lowest_market_price;
            public string highest_market_price;
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            //rowIndex = e.RowIndex;
            //instanceid = dataGridViewAllItems.Rows[rowIndex].Cells["instanceid"].Value.ToString();
            //classid = dataGridViewAllItems.Rows[rowIndex].Cells["classid"].Value.ToString();
        }

        private void dataGridViewForSell_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex > -1)
            {
                rowIndex = e.RowIndex;
                instanceid = (dataGridViewForSell.Items[rowIndex] as ItemId).instanceid;
                classid = (dataGridViewForSell.Items[rowIndex] as ItemId).classid;
            }
        }

        public void SellItems(DataGridView items, int rowIndex, IProgress<string> progress)
        {
            for (int i = 0; i < Convert.ToInt32(items.Rows[rowIndex].Cells["count"].Value); i++)
            {
                Info.GetUrl(@"https://market.csgo.com/api/SetPrice/new_" + items.Rows[rowIndex].Cells["classid"].Value.ToString() + "_" +
                    items.Rows[rowIndex].Cells["instanceid"].Value.ToString() + @"/" + textBoxPrice.Text + @"/?key=" + keyMarket).ToString();
                Thread.Sleep(100);
                progress.Report(Convert.ToDouble((i + 1) * 100 / Convert.ToInt32(items.Rows[rowIndex].Cells["count"].Value)).ToString() + "%");
            }
        }

        private void dataGridViewForSell_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (currentColumnIndex == e.ColumnIndex)
            {
                soldSteamItems = new BindingList<ItemId>(soldSteamItems.OrderByDescending(
                    x => x.GetType().GetProperty(dataGridViewForSell.Columns[e.ColumnIndex].Header.ToString()).GetValue(x, null)
                    ).ToList());
                currentColumnIndex = 0;
            }
            else
            {
                soldSteamItems = new BindingList<ItemId>(soldSteamItems.OrderBy(
                        x => x.GetType().GetProperty(dataGridViewForSell.Columns[e.ColumnIndex].Header.ToString()).GetValue(x, null)
                        ).ToList());
                currentColumnIndex = e.ColumnIndex;
            }
            dataGridViewForSell.ItemsSource = soldSteamItems;
        }

        private async void buttonSell_Click(object sender, EventArgs e)
        {
            var progress = new Progress<string>(s => labelProgress.Content = s);
            await Task.Factory.StartNew(() =>
            {
                buttonSell.Dispatcher.BeginInvoke((MethodInvoker)(() =>
                {
                    buttonSell.IsEnabled = false;
                }));
                SellItems(dataGridViewForSell, rowIndex, progress);
            });
            SetDataSourceSellItem(dataGridViewForSell);
            buttonSell.IsEnabled = true;
        }

        private void SellItems(System.Windows.Controls.DataGrid items, int rowIndex, IProgress<string> progress)
        {
            for (int i = 0; i < Convert.ToInt32((items.Items[rowIndex] as ItemId).count); i++)
            {
                Info.GetUrl(@"https://market.csgo.com/api/SetPrice/new_" + (items.Items[rowIndex] as ItemId).classid.ToString() + "_" +
                    (items.Items[rowIndex] as ItemId).instanceid.ToString() + @"/" + textBoxPrice.Text + @"/?key=" + keyMarket).ToString();
                Thread.Sleep(100);
                progress.Report(Convert.ToDouble((i + 1) * 100 / Convert.ToInt32((items.Items[rowIndex] as ItemId).count)).ToString() + "%");
            }
        }
    }
}
