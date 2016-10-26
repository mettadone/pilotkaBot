using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PilotkaBot
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
            /*
             * http://json2csharp.com/
             * PM> Install-Package Newtonsoft.Json
             */
        private void Form1_Load(object sender, EventArgs e)
        {

            moneyLabel.Text = SearchBot.GetMoney(@"https://market.dota2.net/api/GetMoney/?key=3gu14Qg59zgKzw0aKT9FVo7oYY6ReS5").ToString() + " RUB";
            //dataGridView1.Columns["classid"].SortMode = DataGridViewColumnSortMode.Programmatic;
            //dataGridView1.Sort(this.dataGridView1.Columns["classid"], ListSortDirection.Descending);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            FormInventory fI = new FormInventory();
            fI.Show();
        }
    }
}
