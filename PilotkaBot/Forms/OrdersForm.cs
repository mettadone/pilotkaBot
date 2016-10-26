using Newtonsoft.Json.Linq;
using PilotkaBot.JsonClasses;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using static PilotkaBot.Logic.API;

namespace PilotkaBot.Forms
{
    public partial class OrdersForm : Form
    {
        JsonResult currentObject;
        


        #region Form
        public OrdersForm()
        {
            InitializeComponent();
        }
        private void OrdersForm_Load(object sender, EventArgs e)
        {
            dataGridViewOrders.DataSource = Info.GetOrders();
        }
        #endregion

        #region Click
        private void buttonUpdate_Click(object sender, EventArgs e)
        {
            if (textBoxPrice.Text != "" && currentObject != null)
            {
                MessageBox.Show(Info.GetUrl(csgo_updateOrder + currentObject.classid + @"/" +
                    currentObject.instanceid + @"/" + textBoxPrice.Text + @"/?key=" + keyMarket));
                dataGridViewOrders.DataSource = Info.GetOrders();
            }
            else MessageBox.Show("Set price or select item!");
        }

        private void dataGridViewOrders_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            currentObject = new JsonResult();
            if (e.RowIndex > -1)
            {
                currentObject.classid = dataGridViewOrders.Rows[e.RowIndex].Cells["i_classid"].Value.ToString();
                currentObject.instanceid = dataGridViewOrders.Rows[e.RowIndex].Cells["i_instanceid"].Value.ToString();
                textBoxPrice.Text = dataGridViewOrders.Rows[e.RowIndex].Cells["o_price"].Value.ToString();
            }
        }

        private void buttonDelete_Click(object sender, EventArgs e)
        {
            if (currentObject != null)
            {
                Info.GetUrl(csgo_updateOrder + currentObject.classid + @"/" +
                    currentObject.instanceid + @"/0/?key=" + keyMarket);
                dataGridViewOrders.DataSource = Info.GetOrders();
            }
            else MessageBox.Show("Select item!");
        }

        private void buttonDeleteAll_Click(object sender, EventArgs e)
        {
            Info.GetUrl(csgo_deleteOrder + keyMarket);
            dataGridViewOrders.DataSource = Info.GetOrders();
        }

        #endregion
    }
}

