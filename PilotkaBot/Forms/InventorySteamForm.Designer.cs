namespace PilotkaBot
{
    partial class FormInventorySteam
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
            this.dataGridViewAllItems = new System.Windows.Forms.DataGridView();
            this.labelPrice = new System.Windows.Forms.Label();
            this.textBoxPrice = new System.Windows.Forms.TextBox();
            this.buttonSell = new System.Windows.Forms.Button();
            this.dataGridViewForSell = new System.Windows.Forms.DataGridView();
            this.labelProgress = new System.Windows.Forms.Label();
            this.labelCount = new System.Windows.Forms.Label();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPageSellltems = new System.Windows.Forms.TabPage();
            this.tabPageAllItems = new System.Windows.Forms.TabPage();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewAllItems)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewForSell)).BeginInit();
            this.tabControl1.SuspendLayout();
            this.tabPageSellltems.SuspendLayout();
            this.tabPageAllItems.SuspendLayout();
            this.SuspendLayout();
            // 
            // dataGridViewAllItems
            // 
            this.dataGridViewAllItems.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewAllItems.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridViewAllItems.Location = new System.Drawing.Point(3, 3);
            this.dataGridViewAllItems.Name = "dataGridViewAllItems";
            this.dataGridViewAllItems.Size = new System.Drawing.Size(1142, 343);
            this.dataGridViewAllItems.TabIndex = 0;
            this.dataGridViewAllItems.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellClick);
            // 
            // labelPrice
            // 
            this.labelPrice.AutoSize = true;
            this.labelPrice.Location = new System.Drawing.Point(801, 402);
            this.labelPrice.Name = "labelPrice";
            this.labelPrice.Size = new System.Drawing.Size(34, 13);
            this.labelPrice.TabIndex = 7;
            this.labelPrice.Text = "Price:";
            // 
            // textBoxPrice
            // 
            this.textBoxPrice.Location = new System.Drawing.Point(841, 399);
            this.textBoxPrice.Name = "textBoxPrice";
            this.textBoxPrice.Size = new System.Drawing.Size(169, 20);
            this.textBoxPrice.TabIndex = 6;
            // 
            // buttonSell
            // 
            this.buttonSell.Location = new System.Drawing.Point(1016, 397);
            this.buttonSell.Name = "buttonSell";
            this.buttonSell.Size = new System.Drawing.Size(75, 23);
            this.buttonSell.TabIndex = 5;
            this.buttonSell.Text = "Sell";
            this.buttonSell.UseVisualStyleBackColor = true;
            this.buttonSell.Click += new System.EventHandler(this.buttonSell_Click);
            // 
            // dataGridViewForSell
            // 
            this.dataGridViewForSell.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewForSell.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridViewForSell.Location = new System.Drawing.Point(3, 3);
            this.dataGridViewForSell.Name = "dataGridViewForSell";
            this.dataGridViewForSell.Size = new System.Drawing.Size(1142, 343);
            this.dataGridViewForSell.TabIndex = 10;
            this.dataGridViewForSell.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewForSell_CellClick);
            this.dataGridViewForSell.ColumnHeaderMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dataGridViewForSell_ColumnHeaderMouseClick);
            // 
            // labelProgress
            // 
            this.labelProgress.AutoSize = true;
            this.labelProgress.Location = new System.Drawing.Point(1097, 402);
            this.labelProgress.Name = "labelProgress";
            this.labelProgress.Size = new System.Drawing.Size(0, 13);
            this.labelProgress.TabIndex = 13;
            // 
            // labelCount
            // 
            this.labelCount.AutoSize = true;
            this.labelCount.Location = new System.Drawing.Point(5, 390);
            this.labelCount.Name = "labelCount";
            this.labelCount.Size = new System.Drawing.Size(41, 13);
            this.labelCount.TabIndex = 14;
            this.labelCount.Text = "Count: ";
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPageSellltems);
            this.tabControl1.Controls.Add(this.tabPageAllItems);
            this.tabControl1.Location = new System.Drawing.Point(1, 12);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(1156, 375);
            this.tabControl1.TabIndex = 15;
            // 
            // tabPageSellltems
            // 
            this.tabPageSellltems.Controls.Add(this.dataGridViewForSell);
            this.tabPageSellltems.Location = new System.Drawing.Point(4, 22);
            this.tabPageSellltems.Name = "tabPageSellltems";
            this.tabPageSellltems.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageSellltems.Size = new System.Drawing.Size(1148, 349);
            this.tabPageSellltems.TabIndex = 0;
            this.tabPageSellltems.Text = "Sell items in Steam";
            this.tabPageSellltems.UseVisualStyleBackColor = true;
            // 
            // tabPageAllItems
            // 
            this.tabPageAllItems.Controls.Add(this.dataGridViewAllItems);
            this.tabPageAllItems.Location = new System.Drawing.Point(4, 22);
            this.tabPageAllItems.Name = "tabPageAllItems";
            this.tabPageAllItems.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageAllItems.Size = new System.Drawing.Size(1148, 349);
            this.tabPageAllItems.TabIndex = 1;
            this.tabPageAllItems.Text = "All items in Steam";
            this.tabPageAllItems.UseVisualStyleBackColor = true;
            // 
            // FormInventorySteam
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1169, 430);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.labelCount);
            this.Controls.Add(this.labelProgress);
            this.Controls.Add(this.labelPrice);
            this.Controls.Add(this.textBoxPrice);
            this.Controls.Add(this.buttonSell);
            this.Name = "FormInventorySteam";
            this.Text = "FormInventorySteam";
            this.Load += new System.EventHandler(this.FormInventorySteam_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewAllItems)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewForSell)).EndInit();
            this.tabControl1.ResumeLayout(false);
            this.tabPageSellltems.ResumeLayout(false);
            this.tabPageAllItems.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridViewAllItems;
        private System.Windows.Forms.Label labelPrice;
        private System.Windows.Forms.TextBox textBoxPrice;
        private System.Windows.Forms.Button buttonSell;
        private System.Windows.Forms.DataGridView dataGridViewForSell;
        private System.Windows.Forms.Label labelProgress;
        private System.Windows.Forms.Label labelCount;
        private System.Windows.Forms.TabPage tabPageAllItems;
        private System.Windows.Forms.TabPage tabPageSellltems;
        private System.Windows.Forms.TabControl tabControl1;
    }
}