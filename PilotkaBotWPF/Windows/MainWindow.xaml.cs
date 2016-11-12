using Logic;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Forms;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using static PilotkaBotWPF.Logic.API;

namespace PilotkaBotWPF
{
    public interface IMainWindow
    {
        void GetTrades(System.Windows.Controls.DataGrid data);
        void LoadMarketDB();
        void GetTrades(DataGridView data);
    }
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window, IMainWindow
    {
        InventoryMarketWindow wIM;
        InventorySteamWindow wIS;
        StatisticWindow sW;
        OrdersWindow oW;
        NotificationWindow nW;
        JObject result;
        public MainWindow()
        {
            /* <Timer> */
            InitializeComponent(); System.Windows.Threading.DispatcherTimer dispatcherTimer = new System.Windows.Threading.DispatcherTimer();
            dispatcherTimer.Tick += new EventHandler(dispatcherTimer_Tick);
            dispatcherTimer.Interval = new TimeSpan(0, 5, 0);
            dispatcherTimer.Start();
            /* </Timer> */

            moneyLabel.Content = Info.GetMoney(csgo_getMoney + keyMarket).ToString() + " RUB";
            LoadMarketDB();
            GetTrades(dataGridViewTrades);
            
        }

        public void GetTrades(System.Windows.Controls.DataGrid data)
        {
            result = null;
            Info.GetUrlJSON(csgo_marketTrades + keyMarket, ref result);
            //Info.GetUrlJSON(@"G:\Documents\Visual Studio 2013\Projects\PilotkaBot\PilotkaBot\PilotkaBot\JSONResponse\HTMLPage2.html", ref result);
            if (result != null)
            {
                List<Trade> trades = null;
                Converter.JsonToTradeList(result, ref trades);
                data.ItemsSource = trades;
            }
        }

        private void dispatcherTimer_Tick(object sender, EventArgs e)
        {
            PingPong.DoPingPong();
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

        #region Clicks
        private void buttonInventory_Click(object sender, RoutedEventArgs e)
        {
            wIM = new InventoryMarketWindow();
            wIM.Show();
        }

        private void buttonStatistic_Click(object sender, RoutedEventArgs e)
        {
            sW = new StatisticWindow();
            sW.Show();
        }

        private void buttonOrders_Click(object sender, RoutedEventArgs e)
        {
            oW = new OrdersWindow();
            oW.Show();
        }

        private void buttonInventorySteam_Click(object sender, RoutedEventArgs e)
        {
            wIS = new InventorySteamWindow();
            wIS.Show();
        }

        private void buttonNotification_Click(object sender, RoutedEventArgs e)
        {
            nW = new NotificationWindow();
            nW.Show();
        }

        

        private void buttonCheck_Click(object sender, RoutedEventArgs e)
        {
            System.Windows.MessageBox.Show(Info.GetUrl(csgo_test + keyMarket));
        }
        #endregion
    }
}
