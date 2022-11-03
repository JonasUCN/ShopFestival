namespace DesktopApp
{
    partial class StockOverview
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
            this.View_Inventory = new System.Windows.Forms.ListBox();
            this.SuspendLayout();
            // 
            // View_Inventory
            // 
            this.View_Inventory.FormattingEnabled = true;
            this.View_Inventory.ItemHeight = 20;
            this.View_Inventory.Location = new System.Drawing.Point(23, 27);
            this.View_Inventory.Name = "View_Inventory";
            this.View_Inventory.Size = new System.Drawing.Size(251, 324);
            this.View_Inventory.TabIndex = 0;
            // 
            // StockOverview
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.View_Inventory);
            this.Name = "StockOverview";
            this.Text = "StockOverview";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.StockOverview_FormClosed);
            this.Load += new System.EventHandler(this.StockOverview_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private ListBox View_Inventory;
    }
}