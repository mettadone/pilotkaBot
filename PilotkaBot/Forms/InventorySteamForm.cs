using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using PilotkaBot.JsonClasses;
using PilotkaBot.Logic;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

using static PilotkaBot.Logic.API;
using static PilotkaBot.;
namespace PilotkaBot
{
    public partial class FormInventorySteam : Form
    {
        int rowIndex;
        string classid, instanceid;
        int currentColumnIndex = 0;
        List<JObject> itemsrgInventory;
        BindingList<JsonInventoryResult> marketItems;
        BindingList<ItemId> soldSteamItems;
    //    BindingList<InventorySteamTableClass>




        #region Form
        public FormInventorySteam()
        {
            InitializeComponent();
        }
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
            BindingList <ItemId> sellItems = new BindingList<ItemId>();
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

        #endregion


        public void AddParameters(DataGridView dataSellSteam)
        {
            for (int i = 0; i < dataSellSteam.Rows.Count; i++)
            {
                MarketItemInfo info = Info.GetMarketItemInfo(csgo_itemInfo + dataSellSteam.Rows[i].Cells["classid"].Value + "_"
                    + dataSellSteam.Rows[i].Cells["instanceid"].Value + "/ru/?key=" + keyMarket);
                MarketItemHistory history = Info.GetMarketItemHistory(csgo_itemHistory + info.classid + "_"
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
            marketItems = Converter.InventoryListToBindingList(Info.GetUrlJSONInventorylist(csgo_trades + keyMarket));
            var targetListSteam = itemsrgInventory.Select(x =>
                new ItemId() { classid = x["classid"].ToString(), instanceid = x["instanceid"].ToString() }).ToList();
            var targetListMarket = marketItems.Select(x => 
                new ItemId() { classid = x.i_classid, instanceid = x.ui_real_instance}).ToList();
            int count = 0;
            soldSteamItems = SoldItemsFromSteam(targetListSteam, targetListMarket, ref count);
            dataGridViewForSell.DataSource = soldSteamItems;
            labelCount.Text = "Count: " + count.ToString();
            AddParameters(dataGridViewForSell);
            FormsLogic.AddSteamPrices(ref dataGridViewForSell);
            FormsLogic.AddEarnings(ref dataGridViewForSell);
        }

        public void SetDataSourceAllItem()
        {
            //lightnining Y9PRN
            JObject result = null;
            Info.GetUrlJSON(steam_csgo_inventory, ref result);
            itemsrgInventory = Converter.jObjectToList("rgInventory", result);
            dataGridViewAllItems.DataSource = itemsrgInventory;
        }
        private void FormInventorySteam_Load(object sender, EventArgs e)
        {
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
                instanceid = dataGridViewForSell.Rows[rowIndex].Cells["instanceid"].Value.ToString();
                classid = dataGridViewForSell.Rows[rowIndex].Cells["classid"].Value.ToString();
            }
        }

        public void SellItems(DataGridView items, int rowIndex, IProgress<string> progress)
        {
            for (int i = 0; i < Convert.ToInt32(items.Rows[rowIndex].Cells["count"].Value); i++)
            {
                    Info.GetUrl(csgo_setPrice + items.Rows[rowIndex].Cells["classid"].Value.ToString() + "_" +
                        items.Rows[rowIndex].Cells["instanceid"].Value.ToString() + @"/" + textBoxPrice.Text + @"/?key="+keyMarket).ToString();
                    Thread.Sleep(100);
                    progress.Report(Convert.ToDouble((i + 1) * 100 / Convert.ToInt32(items.Rows[rowIndex].Cells["count"].Value)).ToString() + "%");
            }
        }

        private void dataGridViewForSell_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (currentColumnIndex == e.ColumnIndex)
            {
                soldSteamItems = new BindingList<ItemId>(soldSteamItems.OrderByDescending(
                    x => x.GetType().GetProperty(dataGridViewForSell.Columns[e.ColumnIndex].Name).GetValue(x, null)
                    ).ToList());
                currentColumnIndex = 0;
            }
            else
            {
                soldSteamItems = new BindingList<ItemId>(soldSteamItems.OrderBy(
                        x => x.GetType().GetProperty(dataGridViewForSell.Columns[e.ColumnIndex].Name).GetValue(x, null)
                        ).ToList());
                currentColumnIndex = e.ColumnIndex;
            }
            dataGridViewForSell.DataSource = soldSteamItems;
        }

        private async void buttonSell_Click(object sender, EventArgs e)
        {
            var progress = new Progress<string>(s => labelProgress.Text = s);
            await Task.Factory.StartNew(() =>
            {
                buttonSell.BeginInvoke((MethodInvoker)(() =>
                {
                    buttonSell.Enabled = false;
                }));
                SellItems(dataGridViewForSell, rowIndex, progress);             
            });
            SetDataSourceSellItem(dataGridViewForSell);
            buttonSell.Enabled = true;
        }
    }
}
