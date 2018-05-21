namespace GetProductData
{
    partial class Form1
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
            this.productDataView = new System.Windows.Forms.DataGridView();
            this.button1 = new System.Windows.Forms.Button();
            this.textUrl = new System.Windows.Forms.TextBox();
            this.labelUrl = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.productDataView)).BeginInit();
            this.SuspendLayout();
            // 
            // productDataView
            // 
            this.productDataView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.productDataView.Location = new System.Drawing.Point(3, 101);
            this.productDataView.Name = "productDataView";
            this.productDataView.RowTemplate.Height = 24;
            this.productDataView.Size = new System.Drawing.Size(1052, 700);
            this.productDataView.TabIndex = 0;
            this.productDataView.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(909, 33);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(146, 43);
            this.button1.TabIndex = 1;
            this.button1.Text = "Execute";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // textUrl
            // 
            this.textUrl.Location = new System.Drawing.Point(58, 43);
            this.textUrl.Name = "textUrl";
            this.textUrl.Size = new System.Drawing.Size(824, 22);
            this.textUrl.TabIndex = 2;
            this.textUrl.TextChanged += new System.EventHandler(this.textUrl_TextChanged);
            // 
            // labelUrl
            // 
            this.labelUrl.AutoSize = true;
            this.labelUrl.Location = new System.Drawing.Point(12, 46);
            this.labelUrl.Name = "labelUrl";
            this.labelUrl.Size = new System.Drawing.Size(40, 17);
            this.labelUrl.TabIndex = 3;
            this.labelUrl.Text = "URL:";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1782, 953);
            this.Controls.Add(this.labelUrl);
            this.Controls.Add(this.textUrl);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.productDataView);
            this.Name = "Form1";
            this.Text = "Get Product Data";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.productDataView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView productDataView;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox textUrl;
        private System.Windows.Forms.Label labelUrl;
    }
}

