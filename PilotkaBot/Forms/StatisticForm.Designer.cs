namespace PilotkaBot.Forms
{
    partial class StatisticForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.panel1 = new System.Windows.Forms.Panel();
            this.dataGridViewStatisticMarket = new System.Windows.Forms.DataGridView();
            this.buttonCreateOrderMarket = new System.Windows.Forms.Button();
            this.textBoxPrice = new System.Windows.Forms.TextBox();
            this.labelPrice = new System.Windows.Forms.Label();
            this.dataGridViewStatisticSteam = new System.Windows.Forms.DataGridView();
            this.labelCount = new System.Windows.Forms.Label();
            this.textBoxCount = new System.Windows.Forms.TextBox();
            this.buttonCreateOrderSteam = new System.Windows.Forms.Button();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPageMarket = new System.Windows.Forms.TabPage();
            this.tabPageSteam = new System.Windows.Forms.TabPage();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewStatisticMarket)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewStatisticSteam)).BeginInit();
            this.tabControl1.SuspendLayout();
            this.tabPageMarket.SuspendLayout();
            this.tabPageSteam.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.dataGridViewStatisticMarket);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(3, 3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1086, 388);
            this.panel1.TabIndex = 0;
            // 
            // dataGridViewStatisticMarket
            // 
            this.dataGridViewStatisticMarket.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewStatisticMarket.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridViewStatisticMarket.Location = new System.Drawing.Point(0, 0);
            this.dataGridViewStatisticMarket.Name = "dataGridViewStatisticMarket";
            this.dataGridViewStatisticMarket.Size = new System.Drawing.Size(1086, 388);
            this.dataGridViewStatisticMarket.TabIndex = 0;
            this.dataGridViewStatisticMarket.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewStatistic_CellClick);
            // 
            // buttonCreateOrderMarket
            // 
            this.buttonCreateOrderMarket.Location = new System.Drawing.Point(1108, 358);
            this.buttonCreateOrderMarket.Name = "buttonCreateOrderMarket";
            this.buttonCreateOrderMarket.Size = new System.Drawing.Size(119, 23);
            this.buttonCreateOrderMarket.TabIndex = 1;
            this.buttonCreateOrderMarket.Text = "Create order Market";
            this.buttonCreateOrderMarket.UseVisualStyleBackColor = true;
            this.buttonCreateOrderMarket.Click += new System.EventHandler(this.buttonCreateOrder_Click);
            // 
            // textBoxPrice
            // 
            this.textBoxPrice.Location = new System.Drawing.Point(1108, 303);
            this.textBoxPrice.Name = "textBoxPrice";
            this.textBoxPrice.Size = new System.Drawing.Size(118, 20);
            this.textBoxPrice.TabIndex = 2;
            // 
            // labelPrice
            // 
            this.labelPrice.AutoSize = true;
            this.labelPrice.Location = new System.Drawing.Point(1109, 284);
            this.labelPrice.Name = "labelPrice";
            this.labelPrice.Size = new System.Drawing.Size(34, 13);
            this.labelPrice.TabIndex = 3;
            this.labelPrice.Text = "Price:";
            // 
            // dataGridViewStatisticSteam
            // 
            this.dataGridViewStatisticSteam.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewStatisticSteam.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridViewStatisticSteam.Location = new System.Drawing.Point(0, 0);
            this.dataGridViewStatisticSteam.Name = "dataGridViewStatisticSteam";
            this.dataGridViewStatisticSteam.Size = new System.Drawing.Size(821, 394);
            this.dataGridViewStatisticSteam.TabIndex = 0;
            // 
            // labelCount
            // 
            this.labelCount.AutoSize = true;
            this.labelCount.Location = new System.Drawing.Point(1110, 219);
            this.labelCount.Name = "labelCount";
            this.labelCount.Size = new System.Drawing.Size(71, 13);
            this.labelCount.TabIndex = 5;
            this.labelCount.Text = "Orders count:";
            // 
            // textBoxCount
            // 
            this.textBoxCount.Location = new System.Drawing.Point(1109, 238);
            this.textBoxCount.Name = "textBoxCount";
            this.textBoxCount.Size = new System.Drawing.Size(118, 20);
            this.textBoxCount.TabIndex = 4;
            // 
            // buttonCreateOrderSteam
            // 
            this.buttonCreateOrderSteam.Location = new System.Drawing.Point(1107, 405);
            this.buttonCreateOrderSteam.Name = "buttonCreateOrderSteam";
            this.buttonCreateOrderSteam.Size = new System.Drawing.Size(119, 23);
            this.buttonCreateOrderSteam.TabIndex = 6;
            this.buttonCreateOrderSteam.Text = "Create order Steam";
            this.buttonCreateOrderSteam.UseVisualStyleBackColor = true;
            this.buttonCreateOrderSteam.Click += new System.EventHandler(this.buttonCreateOrderSteam_Click);
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPageMarket);
            this.tabControl1.Controls.Add(this.tabPageSteam);
            this.tabControl1.Location = new System.Drawing.Point(1, 12);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(1100, 420);
            this.tabControl1.TabIndex = 3;
            // 
            // tabPageMarket
            // 
            this.tabPageMarket.Controls.Add(this.panel1);
            this.tabPageMarket.Location = new System.Drawing.Point(4, 22);
            this.tabPageMarket.Name = "tabPageMarket";
            this.tabPageMarket.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageMarket.Size = new System.Drawing.Size(1092, 394);
            this.tabPageMarket.TabIndex = 1;
            this.tabPageMarket.Text = "Market statistic";
            this.tabPageMarket.UseVisualStyleBackColor = true;
            // 
            // tabPageSteam
            // 
            this.tabPageSteam.Controls.Add(this.dataGridViewStatisticSteam);
            this.tabPageSteam.Location = new System.Drawing.Point(4, 22);
            this.tabPageSteam.Name = "tabPageSteam";
            this.tabPageSteam.Size = new System.Drawing.Size(821, 394);
            this.tabPageSteam.TabIndex = 2;
            this.tabPageSteam.Text = "Popular in steam";
            this.tabPageSteam.UseVisualStyleBackColor = true;
            // 
            // StatisticForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1238, 445);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.buttonCreateOrderSteam);
            this.Controls.Add(this.labelCount);
            this.Controls.Add(this.textBoxCount);
            this.Controls.Add(this.labelPrice);
            this.Controls.Add(this.textBoxPrice);
            this.Controls.Add(this.buttonCreateOrderMarket);
            this.Name = "StatisticForm";
            this.Text = "Statistic";
            this.Load += new System.EventHandler(this.StatisticForm_Load);
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewStatisticMarket)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewStatisticSteam)).EndInit();
            this.tabControl1.ResumeLayout(false);
            this.tabPageMarket.ResumeLayout(false);
            this.tabPageSteam.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.DataGridView dataGridViewStatisticMarket;
        private System.Windows.Forms.Button buttonCreateOrderMarket;
        private System.Windows.Forms.TextBox textBoxPrice;
        private System.Windows.Forms.Label labelPrice;
        private System.Windows.Forms.DataGridView dataGridViewStatisticSteam;
        private System.Windows.Forms.Label labelCount;
        private System.Windows.Forms.TextBox textBoxCount;
        private System.Windows.Forms.Button buttonCreateOrderSteam;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPageMarket;
        private System.Windows.Forms.TabPage tabPageSteam;
    }
}