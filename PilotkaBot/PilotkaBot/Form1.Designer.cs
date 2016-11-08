namespace PilotkaBot
{
    partial class Form1
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
            this.buttonInventory = new System.Windows.Forms.Button();
            this.moneyTextLabel = new System.Windows.Forms.Label();
            this.moneyLabel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // buttonInventory
            // 
            this.buttonInventory.Location = new System.Drawing.Point(552, 133);
            this.buttonInventory.Name = "buttonInventory";
            this.buttonInventory.Size = new System.Drawing.Size(75, 23);
            this.buttonInventory.TabIndex = 0;
            this.buttonInventory.Text = "Inventory";
            this.buttonInventory.UseVisualStyleBackColor = true;
            this.buttonInventory.Click += new System.EventHandler(this.button1_Click);
            // 
            // moneyTextLabel
            // 
            this.moneyTextLabel.AutoSize = true;
            this.moneyTextLabel.Location = new System.Drawing.Point(549, 13);
            this.moneyTextLabel.Name = "moneyTextLabel";
            this.moneyTextLabel.Size = new System.Drawing.Size(42, 13);
            this.moneyTextLabel.TabIndex = 1;
            this.moneyTextLabel.Text = "Money:";
            // 
            // moneyLabel
            // 
            this.moneyLabel.AutoSize = true;
            this.moneyLabel.Location = new System.Drawing.Point(556, 40);
            this.moneyLabel.Name = "moneyLabel";
            this.moneyLabel.Size = new System.Drawing.Size(35, 13);
            this.moneyLabel.TabIndex = 2;
            this.moneyLabel.Text = "label1";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(639, 553);
            this.Controls.Add(this.moneyLabel);
            this.Controls.Add(this.moneyTextLabel);
            this.Controls.Add(this.buttonInventory);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button buttonInventory;
        private System.Windows.Forms.Label moneyTextLabel;
        private System.Windows.Forms.Label moneyLabel;
    }
}

