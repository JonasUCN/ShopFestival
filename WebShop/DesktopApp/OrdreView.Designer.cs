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
            this.view_allOrders = new System.Windows.Forms.ListBox();
            this.btn_toMainScreen = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // view_allOrders
            // 
            this.view_allOrders.FormattingEnabled = true;
            this.view_allOrders.ItemHeight = 20;
            this.view_allOrders.Location = new System.Drawing.Point(352, 25);
            this.view_allOrders.Name = "view_allOrders";
            this.view_allOrders.Size = new System.Drawing.Size(411, 304);
            this.view_allOrders.TabIndex = 0;
            // 
            // btn_toMainScreen
            // 
            this.btn_toMainScreen.Location = new System.Drawing.Point(50, 390);
            this.btn_toMainScreen.Name = "btn_toMainScreen";
            this.btn_toMainScreen.Size = new System.Drawing.Size(156, 29);
            this.btn_toMainScreen.TabIndex = 1;
            this.btn_toMainScreen.Text = "Tilbage til Main";
            this.btn_toMainScreen.UseVisualStyleBackColor = true;
            this.btn_toMainScreen.Click += new System.EventHandler(this.button1_Click);
            // 
            // OrdreView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btn_toMainScreen);
            this.Controls.Add(this.view_allOrders);
            this.Name = "OrdreView";
            this.Text = "OrdreView";
            this.ResumeLayout(false);

        }

        #endregion

        private ListBox view_allOrders;
        private Button btn_toMainScreen;
    }
}