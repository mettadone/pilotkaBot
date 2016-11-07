using Logic;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using PilotkaBot.Forms;
using PilotkaBot.Logic.Api;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

using static PilotkaBot.Logic.API;

namespace PilotkaBot
{
    public partial class MainForm : Form
    {
        InventoryMarketForm fIM;
        FormInventorySteam fIS;
        StatisticForm sF;
        OrdersForm oF;
        NotificationForm nF;
        JObject result;
        



        public MainForm()
        {
            InitializeComponent();
        }
        /*
         * http://json2csharp.com/
         * PM> Install-Package Newtonsoft.Json
         */
        public void GetTrades(DataGridView data)
        {
            result = null;
            Info.GetUrlJSON(csgo_marketTrades + keyMarket, ref result);
            //Info.GetUrlJSON(@"G:\Documents\Visual Studio 2013\Projects\PilotkaBot\PilotkaBot\PilotkaBot\JSONResponse\HTMLPage2.html", ref result);
            if (result != null)
            {
                List<Trade> trades = null;
                Converter.JsonToTradeList(result, ref trades);
                data.DataSource = trades;
            }
        }
        public void LoadMarketDB()
        {
            Info.LoadFile(csgo_getCurrentDB, Info.GetCurrentDB(csgo_currentDB).db.ToString(), Info.dbMarketName);
        }
       
        private void Form1_Load(object sender, EventArgs e)
        {            
            moneyLabel.Text = Info.GetMoney(csgo_getMoney + keyMarket).ToString() + " RUB";
            LoadMarketDB();
            GetTrades(dataGridViewTrades);
            timerPingPong.Start();            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            fIM = new InventoryMarketForm();
            fIM.Show();
        }

        private void buttonInventorySteam_Click(object sender, EventArgs e)
        {
            fIS = new FormInventorySteam();
            fIS.Show();
        }

        private void buttonStatistic_Click(object sender, EventArgs e)
        {
            sF = new StatisticForm();
            sF.Show();
        }

        private void timerPingPong_Tick(object sender, EventArgs e)
        {
            PingPong.DoPingPong();
        }

        private void buttonCheck_Click(object sender, EventArgs e)
        {
           MessageBox.Show(Info.GetUrl(csgo_test + keyMarket));
        }

        private void buttonOrders_Click(object sender, EventArgs e)
        {
            oF = new OrdersForm();
            oF.Show();
        }

        private void buttonNotification_Click(object sender, EventArgs e)
        {
            nF = new NotificationForm();
            nF.Show();
        }
    }
}
