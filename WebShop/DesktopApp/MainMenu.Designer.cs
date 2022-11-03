namespace DesktopApp
{
    partial class MainMenu
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
            this.btn_StockOverview = new System.Windows.Forms.Button();
            this.btn_CreateProduct = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btn_StockOverview
            // 
            this.btn_StockOverview.Location = new System.Drawing.Point(68, 137);
            this.btn_StockOverview.Name = "btn_StockOverview";
            this.btn_StockOverview.Size = new System.Drawing.Size(94, 29);
            this.btn_StockOverview.TabIndex = 0;
            this.btn_StockOverview.Text = "StockOverview";
            this.btn_StockOverview.UseVisualStyleBackColor = true;
            this.btn_StockOverview.Click += new System.EventHandler(this.btn_StockOverview_Click);
            // 
            // btn_CreateProduct
            // 
            this.btn_CreateProduct.Location = new System.Drawing.Point(245, 137);
            this.btn_CreateProduct.Name = "btn_CreateProduct";
            this.btn_CreateProduct.Size = new System.Drawing.Size(94, 29);
            this.btn_CreateProduct.TabIndex = 1;
            this.btn_CreateProduct.Text = "CreateProduct";
            this.btn_CreateProduct.UseVisualStyleBackColor = true;
            this.btn_CreateProduct.Click += new System.EventHandler(this.btn_CreateProduct_Click);
            // 
            // MainMenu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btn_CreateProduct);
            this.Controls.Add(this.btn_StockOverview);
            this.Name = "MainMenu";
            this.Text = "MainMenu";
            this.ResumeLayout(false);

        }

        #endregion

        private Button btn_StockOverview;
        private Button btn_CreateProduct;
    }
}