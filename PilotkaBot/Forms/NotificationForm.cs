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
    public partial class NotificationForm : Form
    {
        JsonResult currentObject;
        

        #region Form
        public NotificationForm()
        {
            InitializeComponent();
        }

        private void NotificationForm_Load(object sender, EventArgs e)
        {
           dataGridViewNotification.DataSource = Info.GetNotifications();
        }

        #endregion
        #region Click
        private void dataGridViewNotification_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            currentObject = new JsonResult();
            if (e.RowIndex > -1)
            {
                currentObject.classid = dataGridViewNotification.Rows[e.RowIndex].Cells["i_classid"].Value.ToString();
                currentObject.instanceid = dataGridViewNotification.Rows[e.RowIndex].Cells["i_instanceid"].Value.ToString();
                textBoxPrice.Text = dataGridViewNotification.Rows[e.RowIndex].Cells["n_val"].Value.ToString();
            }
        }

        private void buttonUpdate_Click(object sender, EventArgs e)
        {
            if (textBoxPrice.Text != "" || currentObject != null)
            {
                MessageBox.Show(Info.GetUrl(csgo_updateNotification + currentObject.classid + @"/" +
                    currentObject.instanceid + @"/" + textBoxPrice.Text + @"/?key=" + keyMarket));
                dataGridViewNotification.DataSource = Info.GetNotifications();
            }
            else MessageBox.Show("Set price or select item!");
        }

        private void buttonDelete_Click(object sender, EventArgs e)
        {
            if (currentObject != null)
            {
                MessageBox.Show(Info.GetUrl(csgo_updateNotification + currentObject.classid + @"/" +
                    currentObject.instanceid + @"/0/?key=" + keyMarket));
                dataGridViewNotification.DataSource = Info.GetNotifications();
            }
            else MessageBox.Show("Select item!");
        }
        #endregion
    }
}
