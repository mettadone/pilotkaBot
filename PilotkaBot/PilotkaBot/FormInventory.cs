using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PilotkaBot
{
    public partial class FormInventory : Form
    {
        public FormInventory()
        {
            InitializeComponent();
        }
               /*
             * http://json2csharp.com/
             * PM> Install-Package Newtonsoft.Json
             */
        private void FormInventory_Load(object sender, EventArgs e)
        {
            
            //dataGridView1.DataSource = from item in SearchBot.GetUrlJSONparsIntoDictionary(@"https://market.csgo.com/history/json/")
            //                    select new { Key = item.Key, Value = item.Value };
            SearchBot.GetUrlJSON(@"https://market.csgo.com/history/json/");
            dataGridView1.DataSource = SearchBot.GetUrlJSONInventorylist(@"https://market.csgo.com/api/Trades/?key=" + mykey);
            dataGridView1.Columns.Add("SteamPrice", "SteamPrice");
//            for (int i = 0; i < 7; i++)
//            {
//                string name = dataGridView1.Rows[i].Cells["hash_name"].Value.ToString();
//                if (name.Contains("™")||name.Contains("★"))
//                    name = Regex.Replace(name, "[^\x0d\x0a\x20-\x7e\t]", "");
//                dataGridView1.Rows[i].Cells["SteamPrice"].Value = SearchBot.HtmlPriceParse(@"http://steamcommunity.com/market/search?appid=730&q=", 
//                    name);
////                Thread.Sleep(300);
//            }
            //dataGridView1.Columns["classid"].SortMode = DataGridViewColumnSortMode.Programmatic;
            //dataGridView1.Sort(this.dataGridView1.Columns["classid"], ListSortDirection.Descending);
        //}
    }
    }
}
