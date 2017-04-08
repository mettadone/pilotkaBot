﻿using PilotkaBotWPF.Logic;
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
    /// Логика взаимодействия для InventoryMarketWindow.xaml
    /// </summary>
    public partial class InventoryMarketWindow : Window
    {
        JsonInventoryResult objJsonInventoryResult;
        bool requestMode = true;
#pragma warning disable 0414
        Task taskRequestMode = null;
        Thread forKill = null;
        BindingList<JsonInventoryResult> marketItems;
        List<string> badMarketColumns = new List<string>() { "min_price_text", "i_market_price_text", "i_name", "i_name_color", "i_descriptions", "type",
                                                            "min_price", "ui_bid", "ui_asset", "ui_price_text", "offer_live_time" };
        int currentColumnIndex = 0;
        public InventoryMarketWindow()
        {
            InitializeComponent();
            objJsonInventoryResult = new JsonInventoryResult();

            SetDataSourse();
            FormsLogic.DeleteColumns(ref dataGridView1, badMarketColumns);
            /* <Timer> */
            
            System.Windows.Threading.DispatcherTimer timerRequest = new System.Windows.Threading.DispatcherTimer();
            timerRequest.Tick += new EventHandler(timerRequest_Tick);
            timerRequest.Interval = new TimeSpan(0, 5, 0);
            timerRequest.Start();
            /* </Timer> */
        }
        /*
     * http://json2csharp.com/
     * PM> Install-Package Newtonsoft.Json
     */
        public void SetDataSourse()
        {
            marketItems = new BindingList<JsonInventoryResult>();
            var temp = Info.GetUrlJSONInventorylist(csgo_trades + keyMarket);
            foreach (var item in temp)
                marketItems.Add(item);
            dataGridView1.ItemsSource = marketItems;
        }
        private void FormInventory_Load(object sender, EventArgs e)
        {
            SetDataSourse();
            FormsLogic.DeleteColumns(ref dataGridView1, badMarketColumns);
            //timerRequest.Start();
        }

        private void buttonExit_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex > -1)
            {
                textBoxPrice.Text = (Convert.ToDouble((dataGridView1.Items[e.RowIndex] as JsonInventoryResult).ui_price) * 100).ToString();
                objJsonInventoryResult.ui_id = (dataGridView1.Items[e.RowIndex] as JsonInventoryResult).ui_id.ToString();
                objJsonInventoryResult.i_classid = (dataGridView1.Items[e.RowIndex] as JsonInventoryResult).i_classid.ToString();
                objJsonInventoryResult.ui_real_instance = (dataGridView1.Items[e.RowIndex] as JsonInventoryResult).ui_real_instance.ToString();
            }
        }



        private void buttonUpdate_Click(object sender, EventArgs e)
        {
            Info.GetUrl(csgo_setPrice + objJsonInventoryResult.ui_id + @"/" + textBoxPrice.Text + @"/?key=" + keyMarket);
            marketItems = new BindingList<JsonInventoryResult>();
            var temp = Info.GetUrlJSONInventorylist(csgo_trades + keyMarket);
            foreach (var item in temp)
                marketItems.Add(item);
            dataGridView1.ItemsSource = marketItems;
            FormsLogic.DeleteColumns(ref dataGridView1, badMarketColumns);
        }

        //void RunItemRequest(IProgress<string> progress)
        //{
        //    for (int i = 0; i < dataGridView1.Rows.Count; i++)
        //    {
        //        if(Convert.ToInt32(dataGridView1.Rows[i].Cells["ui_status"].Value)==2)
        //            BuySellBot.ItemRequest(@"https://market.csgo.com/api/ItemRequest/in/1/?key=" + Info.key);//" + dataGridViewTrades.Rows[i].Cells["bot_id"].Value.ToString() + "
        //        Thread.Sleep(2);
        //        progress.Report(Convert.ToDouble((i+1) * 100 / dataGridView1.Rows.Count).ToString() + "%");
        //    }
        //    requestMode = false;

        //}
        private async void buttonItemRequestMode_Click_1(object sender, EventArgs e)
        {
            var progress = new Progress<string>(s => labelProgress.Content= s);
            buttonItemRequestMode.Visibility = Visibility.Hidden;
            buttonItemRequestModeOff.Visibility = Visibility.Visible;
            await Task.Factory.StartNew(() =>
            {
                forKill = Thread.CurrentThread;
                BuySellBot.RunRequestByStatus(dataGridView1, progress, ref requestMode);
                buttonItemRequestModeOff.Dispatcher.BeginInvoke((MethodInvoker)(() =>
                {
                    buttonItemRequestModeOff.Visibility = Visibility.Hidden;
                    buttonItemRequestMode.Visibility = Visibility.Visible;
                }));
            });
            requestMode = false;
        }

#pragma warning disable 0618
        private void buttonItemRequestModeOff_Click_1(object sender, EventArgs e)
        {
buttonItemRequestModeOff.Visibility = Visibility.Hidden;
                    buttonItemRequestMode.Visibility = Visibility.Visible;
            requestMode = true;
            forKill.Suspend();
        }

        private void buttonRemoveAll_Click(object sender, EventArgs e)
        {
            Info.GetUrl(csgo_removeAll + keyMarket);
            SetDataSourse();
            FormsLogic.DeleteColumns(ref dataGridView1, badMarketColumns);
        }

        private void buttonUpdateGroup_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < dataGridView1.Items.Count - 1; i++)
            {
                if (objJsonInventoryResult.ui_real_instance == (dataGridView1.Items[i] as JsonInventoryResult).ui_real_instance.ToString()
                    && objJsonInventoryResult.i_classid == (dataGridView1.Items[i] as JsonInventoryResult).i_classid.ToString())
                    Info.GetUrl(csgo_setPrice + (dataGridView1.Items[i] as JsonInventoryResult).ui_id + @"/" + textBoxPrice.Text + @"/?key=" + keyMarket);
            }
            dataGridView1.ItemsSource = Info.GetUrlJSONInventorylist(csgo_trades + keyMarket);
            FormsLogic.DeleteColumns(ref dataGridView1, badMarketColumns);

        }

        private void timerRequest_Tick(object sender, EventArgs e)
        {
            BuySellBot.RunRequestByStatus(dataGridView1);
        }

        private void dataGridView1_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            //foreach (var prop in GetType().GetProperties())
            if (currentColumnIndex == e.ColumnIndex)
            {
                marketItems = new BindingList<JsonInventoryResult>(marketItems.OrderByDescending(
                    x => x.GetType().GetProperty(dataGridView1.Columns[e.ColumnIndex].Header.ToString()).GetValue(x, null)
                    ).ToList());
                currentColumnIndex = 0;
            }
            else
            {
                marketItems = new BindingList<JsonInventoryResult>(marketItems.OrderBy(
                        x => x.GetType().GetProperty(dataGridView1.Columns[e.ColumnIndex].Header.ToString()).GetValue(x, null)
                        ).ToList());
                currentColumnIndex = e.ColumnIndex;
            }
            dataGridView1.ItemsSource = marketItems;
            FormsLogic.DeleteColumns(ref dataGridView1, badMarketColumns);
        }
    }
}