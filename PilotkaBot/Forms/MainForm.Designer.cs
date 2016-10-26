namespace PilotkaBot
{
    partial class MainForm
    {
        /// <summary>
        /// Требуется переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Обязательный метод для поддержки конструктора - не изменяйте
        /// содержимое данного метода при помощи редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.buttonInventory = new System.Windows.Forms.Button();
            this.moneyTextLabel = new System.Windows.Forms.Label();
            this.moneyLabel = new System.Windows.Forms.Label();
            this.buttonInventorySteam = new System.Windows.Forms.Button();
            this.panelTrades = new System.Windows.Forms.Panel();
            this.dataGridViewTrades = new System.Windows.Forms.DataGridView();
            this.buttonStatistic = new System.Windows.Forms.Button();
            this.timerPingPong = new System.Windows.Forms.Timer(this.components);
            this.buttonCheck = new System.Windows.Forms.Button();
            this.buttonOrders = new System.Windows.Forms.Button();
            this.buttonNotification = new System.Windows.Forms.Button();
            this.panelTrades.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewTrades)).BeginInit();
            this.SuspendLayout();
            // 
            // buttonInventory
            // 
            this.buttonInventory.Location = new System.Drawing.Point(630, 158);
            this.buttonInventory.Name = "buttonInventory";
            this.buttonInventory.Size = new System.Drawing.Size(112, 23);
            this.buttonInventory.TabIndex = 0;
            this.buttonInventory.Text = "Inventory";
            this.buttonInventory.UseVisualStyleBackColor = true;
            this.buttonInventory.Click += new System.EventHandler(this.button1_Click);
            // 
            // moneyTextLabel
            // 
            this.moneyTextLabel.AutoSize = true;
            this.moneyTextLabel.Location = new System.Drawing.Point(664, 15);
            this.moneyTextLabel.Name = "moneyTextLabel";
            this.moneyTextLabel.Size = new System.Drawing.Size(42, 13);
            this.moneyTextLabel.TabIndex = 1;
            this.moneyTextLabel.Text = "Money:";
            // 
            // moneyLabel
            // 
            this.moneyLabel.AutoSize = true;
            this.moneyLabel.Location = new System.Drawing.Point(664, 38);
            this.moneyLabel.Name = "moneyLabel";
            this.moneyLabel.Size = new System.Drawing.Size(35, 13);
            this.moneyLabel.TabIndex = 2;
            this.moneyLabel.Text = "label1";
            // 
            // buttonInventorySteam
            // 
            this.buttonInventorySteam.Location = new System.Drawing.Point(630, 187);
            this.buttonInventorySteam.Name = "buttonInventorySteam";
            this.buttonInventorySteam.Size = new System.Drawing.Size(112, 23);
            this.buttonInventorySteam.TabIndex = 3;
            this.buttonInventorySteam.Text = "Inventory Steam";
            this.buttonInventorySteam.UseVisualStyleBackColor = true;
            this.buttonInventorySteam.Click += new System.EventHandler(this.buttonInventorySteam_Click);
            // 
            // panelTrades
            // 
            this.panelTrades.Controls.Add(this.dataGridViewTrades);
            this.panelTrades.Location = new System.Drawing.Point(12, 12);
            this.panelTrades.Name = "panelTrades";
            this.panelTrades.Size = new System.Drawing.Size(612, 529);
            this.panelTrades.TabIndex = 4;
            // 
            // dataGridViewTrades
            // 
            this.dataGridViewTrades.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewTrades.Location = new System.Drawing.Point(3, 3);
            this.dataGridViewTrades.Name = "dataGridViewTrades";
            this.dataGridViewTrades.Size = new System.Drawing.Size(606, 523);
            this.dataGridViewTrades.TabIndex = 0;
            // 
            // buttonStatistic
            // 
            this.buttonStatistic.Location = new System.Drawing.Point(630, 100);
            this.buttonStatistic.Name = "buttonStatistic";
            this.buttonStatistic.Size = new System.Drawing.Size(112, 23);
            this.buttonStatistic.TabIndex = 5;
            this.buttonStatistic.Text = "Statistic";
            this.buttonStatistic.UseVisualStyleBackColor = true;
            this.buttonStatistic.Click += new System.EventHandler(this.buttonStatistic_Click);
            // 
            // timerPingPong
            // 
            this.timerPingPong.Interval = 180000;
            this.timerPingPong.Tick += new System.EventHandler(this.timerPingPong_Tick);
            // 
            // buttonCheck
            // 
            this.buttonCheck.Location = new System.Drawing.Point(630, 505);
            this.buttonCheck.Name = "buttonCheck";
            this.buttonCheck.Size = new System.Drawing.Size(112, 36);
            this.buttonCheck.TabIndex = 6;
            this.buttonCheck.Text = "Check trade restrictions";
            this.buttonCheck.UseVisualStyleBackColor = true;
            this.buttonCheck.Click += new System.EventHandler(this.buttonCheck_Click);
            // 
            // buttonOrders
            // 
            this.buttonOrders.Location = new System.Drawing.Point(630, 129);
            this.buttonOrders.Name = "buttonOrders";
            this.buttonOrders.Size = new System.Drawing.Size(112, 23);
            this.buttonOrders.TabIndex = 7;
            this.buttonOrders.Text = "Orders";
            this.buttonOrders.UseVisualStyleBackColor = true;
            this.buttonOrders.Click += new System.EventHandler(this.buttonOrders_Click);
            // 
            // buttonNotification
            // 
            this.buttonNotification.Location = new System.Drawing.Point(630, 216);
            this.buttonNotification.Name = "buttonNotification";
            this.buttonNotification.Size = new System.Drawing.Size(112, 23);
            this.buttonNotification.TabIndex = 8;
            this.buttonNotification.Text = "Notification";
            this.buttonNotification.UseVisualStyleBackColor = true;
            this.buttonNotification.Click += new System.EventHandler(this.buttonNotification_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(754, 553);
            this.Controls.Add(this.buttonNotification);
            this.Controls.Add(this.buttonOrders);
            this.Controls.Add(this.buttonCheck);
            this.Controls.Add(this.buttonStatistic);
            this.Controls.Add(this.panelTrades);
            this.Controls.Add(this.buttonInventorySteam);
            this.Controls.Add(this.moneyLabel);
            this.Controls.Add(this.moneyTextLabel);
            this.Controls.Add(this.buttonInventory);
            this.Name = "MainForm";
            this.Text = "Pilotka";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.panelTrades.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewTrades)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button buttonInventory;
        private System.Windows.Forms.Label moneyTextLabel;
        private System.Windows.Forms.Label moneyLabel;
        private System.Windows.Forms.Button buttonInventorySteam;
        private System.Windows.Forms.Panel panelTrades;
        private System.Windows.Forms.DataGridView dataGridViewTrades;
        private System.Windows.Forms.Button buttonStatistic;
        private System.Windows.Forms.Timer timerPingPong;
        private System.Windows.Forms.Button buttonCheck;
        private System.Windows.Forms.Button buttonOrders;
        private System.Windows.Forms.Button buttonNotification;
    }
}

