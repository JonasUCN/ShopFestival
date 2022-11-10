namespace DesktopApp
{
    partial class OrdreView
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
            this.btn_toMainScreen = new System.Windows.Forms.Button();
            this.dgv_SaleOrders = new System.Windows.Forms.DataGridView();
            this.btn_activeOrders = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_SaleOrders)).BeginInit();
            this.SuspendLayout();
            // 
            // btn_toMainScreen
            // 
            this.btn_toMainScreen.Location = new System.Drawing.Point(12, 409);
            this.btn_toMainScreen.Name = "btn_toMainScreen";
            this.btn_toMainScreen.Size = new System.Drawing.Size(156, 29);
            this.btn_toMainScreen.TabIndex = 1;
            this.btn_toMainScreen.Text = "Tilbage til Main";
            this.btn_toMainScreen.UseVisualStyleBackColor = true;
            this.btn_toMainScreen.Click += new System.EventHandler(this.button1_Click);
            // 
            // dgv_SaleOrders
            // 
            this.dgv_SaleOrders.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dgv_SaleOrders.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_SaleOrders.Location = new System.Drawing.Point(12, 12);
            this.dgv_SaleOrders.Name = "dgv_SaleOrders";
            this.dgv_SaleOrders.ReadOnly = true;
            this.dgv_SaleOrders.RowHeadersWidth = 51;
            this.dgv_SaleOrders.RowTemplate.Height = 29;
            this.dgv_SaleOrders.Size = new System.Drawing.Size(776, 372);
            this.dgv_SaleOrders.TabIndex = 2;
            // 
            // btn_activeOrders
            // 
            this.btn_activeOrders.Location = new System.Drawing.Point(694, 390);
            this.btn_activeOrders.Name = "btn_activeOrders";
            this.btn_activeOrders.Size = new System.Drawing.Size(94, 29);
            this.btn_activeOrders.TabIndex = 3;
            this.btn_activeOrders.Text = "Se Aktive Ordre";
            this.btn_activeOrders.UseVisualStyleBackColor = true;
            this.btn_activeOrders.Click += new System.EventHandler(this.btn_activeOrders_ClickAsync);
            // 
            // OrdreView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btn_activeOrders);
            this.Controls.Add(this.dgv_SaleOrders);
            this.Controls.Add(this.btn_toMainScreen);
            this.Name = "OrdreView";
            this.Text = "OrdreView";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.OrdreView_FormClosed);
            this.Load += new System.EventHandler(this.OrdreView_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgv_SaleOrders)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private Button btn_toMainScreen;
        private DataGridView dgv_SaleOrders;
        private Button btn_activeOrders;
    }
}