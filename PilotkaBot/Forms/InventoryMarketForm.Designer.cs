namespace PilotkaBot
{
    partial class InventoryMarketForm
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
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.buttonUpdate = new System.Windows.Forms.Button();
            this.textBoxPrice = new System.Windows.Forms.TextBox();
            this.labelPrice = new System.Windows.Forms.Label();
            this.labelProgress = new System.Windows.Forms.Label();
            this.buttonItemRequestModeOff = new System.Windows.Forms.Button();
            this.buttonItemRequestMode = new System.Windows.Forms.Button();
            this.buttonRemoveAll = new System.Windows.Forms.Button();
            this.buttonUpdateGroup = new System.Windows.Forms.Button();
            this.timerRequest = new System.Windows.Forms.Timer(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToOrderColumns = true;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(12, 12);
            this.dataGridView1.MultiSelect = false;
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.Size = new System.Drawing.Size(1053, 529);
            this.dataGridView1.TabIndex = 0;
            this.dataGridView1.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellClick);
            this.dataGridView1.ColumnHeaderMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dataGridView1_ColumnHeaderMouseClick);
            // 
            // buttonUpdate
            // 
            this.buttonUpdate.Location = new System.Drawing.Point(1152, 262);
            this.buttonUpdate.Name = "buttonUpdate";
            this.buttonUpdate.Size = new System.Drawing.Size(88, 23);
            this.buttonUpdate.TabIndex = 2;
            this.buttonUpdate.Text = "Update item";
            this.buttonUpdate.UseVisualStyleBackColor = true;
            this.buttonUpdate.Click += new System.EventHandler(this.buttonUpdate_Click);
            // 
            // textBoxPrice
            // 
            this.textBoxPrice.Location = new System.Drawing.Point(1071, 194);
            this.textBoxPrice.Name = "textBoxPrice";
            this.textBoxPrice.Size = new System.Drawing.Size(169, 20);
            this.textBoxPrice.TabIndex = 3;
            // 
            // labelPrice
            // 
            this.labelPrice.AutoSize = true;
            this.labelPrice.Location = new System.Drawing.Point(1072, 175);
            this.labelPrice.Name = "labelPrice";
            this.labelPrice.Size = new System.Drawing.Size(34, 13);
            this.labelPrice.TabIndex = 4;
            this.labelPrice.Text = "Price:";
            // 
            // labelProgress
            // 
            this.labelProgress.AutoSize = true;
            this.labelProgress.Location = new System.Drawing.Point(1168, 431);
            this.labelProgress.Name = "labelProgress";
            this.labelProgress.Size = new System.Drawing.Size(0, 13);
            this.labelProgress.TabIndex = 10;
            // 
            // buttonItemRequestModeOff
            // 
            this.buttonItemRequestModeOff.Location = new System.Drawing.Point(1129, 450);
            this.buttonItemRequestModeOff.Name = "buttonItemRequestModeOff";
            this.buttonItemRequestModeOff.Size = new System.Drawing.Size(111, 24);
            this.buttonItemRequestModeOff.TabIndex = 9;
            this.buttonItemRequestModeOff.Text = "Request mode off";
            this.buttonItemRequestModeOff.UseVisualStyleBackColor = true;
            this.buttonItemRequestModeOff.Visible = false;
            this.buttonItemRequestModeOff.Click += new System.EventHandler(this.buttonItemRequestModeOff_Click_1);
            // 
            // buttonItemRequestMode
            // 
            this.buttonItemRequestMode.Location = new System.Drawing.Point(1129, 450);
            this.buttonItemRequestMode.Name = "buttonItemRequestMode";
            this.buttonItemRequestMode.Size = new System.Drawing.Size(111, 24);
            this.buttonItemRequestMode.TabIndex = 8;
            this.buttonItemRequestMode.Text = "Request mode on";
            this.buttonItemRequestMode.UseVisualStyleBackColor = true;
            this.buttonItemRequestMode.Click += new System.EventHandler(this.buttonItemRequestMode_Click_1);
            // 
            // buttonRemoveAll
            // 
            this.buttonRemoveAll.Location = new System.Drawing.Point(1152, 320);
            this.buttonRemoveAll.Name = "buttonRemoveAll";
            this.buttonRemoveAll.Size = new System.Drawing.Size(88, 23);
            this.buttonRemoveAll.TabIndex = 11;
            this.buttonRemoveAll.Text = "Remove all";
            this.buttonRemoveAll.UseVisualStyleBackColor = true;
            this.buttonRemoveAll.Click += new System.EventHandler(this.buttonRemoveAll_Click);
            // 
            // buttonUpdateGroup
            // 
            this.buttonUpdateGroup.Location = new System.Drawing.Point(1152, 291);
            this.buttonUpdateGroup.Name = "buttonUpdateGroup";
            this.buttonUpdateGroup.Size = new System.Drawing.Size(88, 23);
            this.buttonUpdateGroup.TabIndex = 12;
            this.buttonUpdateGroup.Text = "Update group";
            this.buttonUpdateGroup.UseVisualStyleBackColor = true;
            this.buttonUpdateGroup.Click += new System.EventHandler(this.buttonUpdateGroup_Click);
            // 
            // timerRequest
            // 
            this.timerRequest.Interval = 180000;
            this.timerRequest.Tick += new System.EventHandler(this.timerRequest_Tick);
            // 
            // InventoryMarketForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1252, 553);
            this.Controls.Add(this.buttonUpdateGroup);
            this.Controls.Add(this.buttonRemoveAll);
            this.Controls.Add(this.labelProgress);
            this.Controls.Add(this.buttonItemRequestModeOff);
            this.Controls.Add(this.buttonItemRequestMode);
            this.Controls.Add(this.labelPrice);
            this.Controls.Add(this.textBoxPrice);
            this.Controls.Add(this.buttonUpdate);
            this.Controls.Add(this.dataGridView1);
            this.Name = "InventoryMarketForm";
            this.Text = "FormInventoryMarket";
            this.Load += new System.EventHandler(this.FormInventory_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button buttonUpdate;
        private System.Windows.Forms.TextBox textBoxPrice;
        private System.Windows.Forms.Label labelPrice;
        private System.Windows.Forms.Label labelProgress;
        private System.Windows.Forms.Button buttonItemRequestModeOff;
        private System.Windows.Forms.Button buttonItemRequestMode;
        private System.Windows.Forms.Button buttonRemoveAll;
        public System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button buttonUpdateGroup;
        private System.Windows.Forms.Timer timerRequest;
    }
}

