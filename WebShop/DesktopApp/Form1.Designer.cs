namespace DesktopApp
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.txt_createTitle = new System.Windows.Forms.TextBox();
            this.txt_createProductDescription = new System.Windows.Forms.TextBox();
            this.txt_createPrice = new System.Windows.Forms.TextBox();
            this.txt_createStock = new System.Windows.Forms.TextBox();
            this.txt_createBrand = new System.Windows.Forms.TextBox();
            this.btn_createProduct = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(261, 94);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(38, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "Title";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(261, 136);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(48, 20);
            this.label2.TabIndex = 1;
            this.label2.Text = "Brand";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(175, 179);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(136, 20);
            this.label3.TabIndex = 2;
            this.label3.Text = "Produkt Beskrivelse";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(226, 216);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(85, 20);
            this.label4.TabIndex = 3;
            this.label4.Text = "Lager Antal";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(261, 254);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(32, 20);
            this.label5.TabIndex = 4;
            this.label5.Text = "Pris";
            // 
            // txt_createTitle
            // 
            this.txt_createTitle.Location = new System.Drawing.Point(338, 94);
            this.txt_createTitle.Name = "txt_createTitle";
            this.txt_createTitle.Size = new System.Drawing.Size(125, 27);
            this.txt_createTitle.TabIndex = 5;
            // 
            // txt_createProductDescription
            // 
            this.txt_createProductDescription.Location = new System.Drawing.Point(338, 172);
            this.txt_createProductDescription.Name = "txt_createProductDescription";
            this.txt_createProductDescription.Size = new System.Drawing.Size(125, 27);
            this.txt_createProductDescription.TabIndex = 6;
            // 
            // txt_createPrice
            // 
            this.txt_createPrice.Location = new System.Drawing.Point(338, 251);
            this.txt_createPrice.Name = "txt_createPrice";
            this.txt_createPrice.Size = new System.Drawing.Size(125, 27);
            this.txt_createPrice.TabIndex = 7;
            // 
            // txt_createStock
            // 
            this.txt_createStock.Location = new System.Drawing.Point(338, 213);
            this.txt_createStock.Name = "txt_createStock";
            this.txt_createStock.Size = new System.Drawing.Size(125, 27);
            this.txt_createStock.TabIndex = 8;
            // 
            // txt_createBrand
            // 
            this.txt_createBrand.Location = new System.Drawing.Point(338, 133);
            this.txt_createBrand.Name = "txt_createBrand";
            this.txt_createBrand.Size = new System.Drawing.Size(125, 27);
            this.txt_createBrand.TabIndex = 9;
            // 
            // btn_createProduct
            // 
            this.btn_createProduct.Location = new System.Drawing.Point(338, 302);
            this.btn_createProduct.Name = "btn_createProduct";
            this.btn_createProduct.Size = new System.Drawing.Size(125, 29);
            this.btn_createProduct.TabIndex = 10;
            this.btn_createProduct.Text = "Opret Produkt";
            this.btn_createProduct.UseVisualStyleBackColor = true;
            this.btn_createProduct.Click += new System.EventHandler(this.btn_createProduct_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btn_createProduct);
            this.Controls.Add(this.txt_createBrand);
            this.Controls.Add(this.txt_createStock);
            this.Controls.Add(this.txt_createPrice);
            this.Controls.Add(this.txt_createProductDescription);
            this.Controls.Add(this.txt_createTitle);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private Label label5;
        private TextBox txt_createTitle;
        private TextBox txt_createProductDescription;
        private TextBox txt_createPrice;
        private TextBox txt_createStock;
        private TextBox txt_createBrand;
        private Button btn_createProduct;
    }
}