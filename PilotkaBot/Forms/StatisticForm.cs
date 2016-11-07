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
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using Jint;
using System.Collections.Specialized;
using System.Net;
using Flurl.Http;

using static PilotkaBot.Logic.API;
using PilotkaBot.Logic.Api;

namespace PilotkaBot.Forms
{
    public partial class StatisticForm : Form
    {
        JsonResult currentObject;
        List<SteamPopularItem> popularSteamItems;



        #region Forms
        public StatisticForm()
        {
            InitializeComponent();
        }

        List<SteamPopularItem> SetSteamPopularData(int limit)
        {
            JObject result = null;
            Info.GetUrlJSON(+limit + "&key=" + keyXYZ, ref result);
            return Converter.jArrayToSteamPopularItemsList("items", result);
        }
        void GetMarketDB(string filename)
        {
            var BooksFromCsv = from row in File.ReadLines(filename).Where(arg => !string.IsNullOrWhiteSpace(arg) && arg.Length > 0).AsEnumerable()
                               let column = row.Split(';')
                               select new MarketDBMini
                               {
                                   c_classid = column[0],
                                   c_instanceid = column[1],
                                   c_price = column[2],
                                   // public string c_offers { get; set; }
                                   c_popularity = column[4],
                                   c_market_name_en = column[11],
                                   c_pop = column[14],
                                   //public string c_rarity { get; set; }
                                   //public string c_quality { get; set; }
                                   //public string c_heroid { get; set; }
                                   //public string c_slot { get; set; }
                                   //public string c_stickers { get; set; }
                                   //public string c_market_name { get; set; }
                                   //public string c_market_name_en { get; set; }
                                   //public string c_name_color { get; set; }
                                   //public string c_price_updated { get; set; }
                                   //public string  { get; set; }
                               };
           
        }
        void statisticOld()
        {
            popularSteamItems = SetSteamPopularData(0);
            List<JsonResult> history = Info.GetUrlJSONlist(csgo_history);
            history.Distinct();
            dataGridViewStatisticMarket.DataSource = history;
            List<string> columnsNames = new List<string>()
            {
                "average_price",
                "median_price",
                "highest_price",
                "lowest_price",
                "hash",
                "rank"
            };

            FormsLogic.AddColumns(ref dataGridViewStatisticMarket, columnsNames);
            for (int i = 0; i < dataGridViewStatisticMarket.RowCount; i++)
            {
                MarketItemInfo marketInfo = Info.GetMarketItemInfo(csgo_itemInfo + dataGridViewStatisticMarket.Rows[i].Cells["classid"].Value + "_"
                    + dataGridViewStatisticMarket.Rows[i].Cells["instanceid"].Value + "/ru/?key=" + keyMarket);
                foreach (SteamPopularItem item in popularSteamItems)
                {
                    if (item.market_hash_name == marketInfo.market_hash_name)
                        dataGridViewStatisticMarket.Rows[i].Cells["rank"].Value = item.rank.ToString();
                }
                //if (name.Contains("™") || name.Contains("★"))
                //    name = Regex.Replace(name, "[^\x0d\x0a\x20-\x7e\t]", "");
                //if (name.Contains("StatTrak"))
                //    name = Regex.Replace(name, "StatTrak", "");
                //     SteamApiItemCS steamInfo = Info.GetApiItemCS(@"http://csgobackpack.net/api/GetItemPrice/?currency=RUB&id=" + marketInfo.market_hash_name + "&time=7&icon=1");//Info.GetSteamApiItem(@"http://api.csgo.steamlytics.xyz/v1/prices/" + marketInfo.market_hash_name + "?key=8754a7606d6b00db0cc9ce1dee003256");
                //dataGridViewStatisticMarket.Rows[i].Cells["average_price"].Value = steamInfo.average_price;
                //dataGridViewStatisticMarket.Rows[i].Cells["median_price"].Value = steamInfo.median_price;
                //dataGridViewStatisticMarket.Rows[i].Cells["highest_price"].Value = steamInfo.highest_price;
                //dataGridViewStatisticMarket.Rows[i].Cells["lowest_price"].Value = steamInfo.lowest_price;
                dataGridViewStatisticMarket.Rows[i].Cells["hash"].Value = marketInfo.hash;
                // Thread.Sleep(10500);
            }

        }
        private void StatisticForm_Load(object sender, EventArgs e)
        {
            GetMarketDB(Info.dbMarketName);
            
        }
        #endregion
        #region Click
        private void buttonCreateOrder_Click(object sender, EventArgs e)
        {
            if (textBoxPrice.Text != "" || textBoxCount.Text != "" || currentObject != null)
            {
                List<string> result = new List<string>();
                for (int i = 0; i < Convert.ToInt32(textBoxCount.Text); i++)
                {
                    result.Add(Info.GetUrl(csgo_insertOrder + currentObject.classid + @"/" + currentObject.instanceid +
                        @"/" + textBoxPrice.Text + @"/" + currentObject.id + "/?key=" + keyMarket) + "\n");
                }
                MessageBox.Show(result.ToString());
            }
            else MessageBox.Show("Set price or select item!");
        }

        private void dataGridViewStatistic_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            currentObject = new JsonResult();
            if (e.RowIndex > -1)
            {
                currentObject.classid = dataGridViewStatisticMarket.Rows[e.RowIndex].Cells["classid"].Value.ToString();
                currentObject.instanceid = dataGridViewStatisticMarket.Rows[e.RowIndex].Cells["instanceid"].Value.ToString();
                currentObject.id = dataGridViewStatisticMarket.Rows[e.RowIndex].Cells["hash"].Value.ToString();
                currentObject.hash_name = dataGridViewStatisticMarket.Rows[e.RowIndex].Cells["hash_name"].Value.ToString();
            }
            
        }

        private async void buttonCreateOrderSteam_Click(object sender, EventArgs e)
        {
            StreamReader sr = new StreamReader(Directory.GetCurrentDirectory() + @"\My.js");
            string script = "function hello() {log('Hello World')}";
            var add = new Engine()
        .Execute("function add(a, b) { return a + b; }")
        .GetValue("add")
        ;

            add.Invoke(1, 2); // -> 3

            //var request = (HttpWebRequest)WebRequest.Create("https://steamcommunity.com/market/createbuyorder/");

            //var postData = "sessionid=f7ce88064c72ae59b40e559a";
            //postData += "&appid=730";
            //postData += "&currency=5";
            //postData += "&market_hash_name=USP-S | Guardian (Field-Tested)";
            //postData += "&price_total=11";
            //postData += "&quantity=11";
            //var data = Encoding.ASCII.GetBytes(postData);

            //request.Method = "POST";
            //request.ContentType = "application/x-www-form-urlencoded";
            //request.ContentLength = data.Length;

            //using (var stream = request.GetRequestStream())
            //{
            //    stream.Write(data, 0, data.Length);
            //}

            //var response = (HttpWebResponse)request.GetResponse();

            //var responseString = new StreamReader(response.GetResponseStream()).ReadToEnd();


            //using (var client = new WebClient())
            //{
            //    var values = new NameValueCollection();
            //    values["sessionid"] = "f7ce88064c72ae59b40e559a";
            //    values["appid"] = "730";
            //    values["currency"] = "5";
            //    values["market_hash_name"] = "USP-S | Guardian (Field-Tested)";
            //    values["price_total"] = "11";
            //    values["quantity"] = "2";
            //    var response = client.UploadValues("https://steamcommunity.com/market/createbuyorder/", values);

            //    var responseString = Encoding.Default.GetString(response);
            //}
     //       Info.GetUrl(@"https://steamcommunity.com/market/createbuyorder/?sessionid=f7ce88064c72ae59b40e559a&currency=5&appid=730&market_hash_name=USP-S%20|%20Guardian%20(Field-Tested)&price_total=11&quantity=1");
            string jquery = File.ReadAllText(@"C:\Users\User\Desktop\PilotkaBot\PilotkaBot\PilotkaBot\Scripts\jquery-3.1.0.slim.min.js");

            string scriptPost =
                @"jQuery.ajax( {
			        url: 'https://steamcommunity.com/market/createbuyorder/',
			        type: 'POST',
			        data: {
				        sessionid: g_sessionID, //f7ce88064c72ae59b40e559a
				        currency: g_rgWalletInfo['wallet_currency'], //5
				        appid: this.m_unAppId, //730
				        market_hash_name: this.m_strMarketHashName, //USP-S | Guardian (Field-Tested)
				        price_total: price_total, // 11 (kopeiki)
				        quantity: quantity // 1, сколько вы хотите купить?
			        },
			        crossDomain: true,
			        xhrFields: { withCredentials: true }
		        } );";

            string scriptPostExample =
                @"jQuery.ajax( {
			        url: 'https://steamcommunity.com/market/createbuyorder/',
			        type: 'POST',
			        data: {
				        sessionid: 'f7ce88064c72ae59b40e559a',
				        currency: '5',
				        appid: '730',
				        market_hash_name: 'USP-S | Guardian (Field-Tested)',
				        price_total: '11', 
				        quantity: '1'
			        },
			        crossDomain: true,
			        xhrFields: { withCredentials: true }
		        } );";

            string scriptPostExample2 =
                @"jQuery.ajax( {
			        url: 'https://steamcommunity.com/market/createbuyorder/',
			        type: 'POST',
			        data: {
				        sessionid: 'f7ce88064c72ae59b40e559a',
				        currency: '5',
				        appid: '730',
				        market_hash_name: 'USP-S | Guardian (Field-Tested)',
				        price_total: '11', 
				        quantity: '2'
			        },
			        crossDomain: true,
			        xhrFields: { withCredentials: true },
                    Access-Control-Allow-Origin: 'http://steamcommunity.com',
                    Access-Control-Allow-Credentials: true,
                } ).done( function ( data ) {
			        //CreateBuyOrderDialog.OnCreateBuyOrderComplete( { responseJSON: data } );
                    console.log(data);
		        } ).fail( function( jqxhr ) {
			        // jquery doesn't parse json on fail
			        var data = $J.parseJSON( jqxhr.responseText );
			        //CreateBuyOrderDialog.OnCreateBuyOrderComplete( { responseJSON: data } );
                    console.log(data);
		        } );";
            Info.POST("https://steamcommunity.com/market/createbuyorder/", "sessionid=f7ce88064c72ae59b40e559a&currency=5&appid=730&market_hash_name=AWP | Asiimov (Battle-Scarred)&price_total=1&quantity=1");
            var postcreatebuyorder = new Engine()
        .Execute(@"var jq = document.createElement('script'); 
                 jq.src = 'https://ajax.googleapis.com/ajax/libs/jquery/2.1.4/jquery.min.js';
                 document.getElementsByTagName('head')[0].appendChild(jq); 
                 jQuery.noConflict(); 
                 function postcreatebuyorder(g_sessionID, m_unAppId, m_strMarketHashName,price_total,quantity) { " + scriptPost + " }")
        .GetValue("postcreatebuyorder")
        ;


            postcreatebuyorder.Invoke("f7ce88064c72ae59b40e559a",5 ,"730", "USP-S | Guardian (Field-Tested)", 11, 1);
            if (textBoxPrice.Text != "" || textBoxCount.Text != "" || currentObject != null)
            {

                BuySellBot.BuyItemsInSteam(@"http://steamcommunity.com/market/listings/730/", currentObject.hash_name);
            }
        }

        #endregion
    }
}