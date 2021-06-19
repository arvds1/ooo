namespace PPR
{
    partial class Barbora
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
            this.buttonExecute = new System.Windows.Forms.Button();
            this.labelProcess = new System.Windows.Forms.Label();
            this.catlabel = new System.Windows.Forms.Label();
            this.urllabel = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.productDataView)).BeginInit();
            this.SuspendLayout();
            // 
            // productDataView
            // 
            this.productDataView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.productDataView.Location = new System.Drawing.Point(3, 53);
            this.productDataView.Name = "productDataView";
            this.productDataView.RowTemplate.Height = 24;
            this.productDataView.Size = new System.Drawing.Size(1445, 888);
            this.productDataView.TabIndex = 0;
            this.productDataView.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            // 
            // buttonExecute
            // 
            this.buttonExecute.Location = new System.Drawing.Point(1523, 140);
            this.buttonExecute.Name = "buttonExecute";
            this.buttonExecute.Size = new System.Drawing.Size(146, 43);
            this.buttonExecute.TabIndex = 1;
            this.buttonExecute.Text = "Execute";
            this.buttonExecute.UseVisualStyleBackColor = true;
            this.buttonExecute.Click += new System.EventHandler(this.button1_Click);
            // 
            // labelProcess
            // 
            this.labelProcess.AutoSize = true;
            this.labelProcess.Location = new System.Drawing.Point(1550, 53);
            this.labelProcess.Name = "labelProcess";
            this.labelProcess.Size = new System.Drawing.Size(90, 17);
            this.labelProcess.TabIndex = 24;
            this.labelProcess.Text = "Processing...";
            this.labelProcess.Click += new System.EventHandler(this.label1_Click);
            // 
            // catlabel
            // 
            this.catlabel.AutoSize = true;
            this.catlabel.Location = new System.Drawing.Point(1494, 93);
            this.catlabel.Name = "catlabel";
            this.catlabel.Size = new System.Drawing.Size(0, 17);
            this.catlabel.TabIndex = 25;
            this.catlabel.Click += new System.EventHandler(this.label1_Click_1);
            // 
            // urllabel
            // 
            this.urllabel.AutoSize = true;
            this.urllabel.Location = new System.Drawing.Point(1610, 93);
            this.urllabel.Name = "urllabel";
            this.urllabel.Size = new System.Drawing.Size(0, 17);
            this.urllabel.TabIndex = 26;
            this.urllabel.Click += new System.EventHandler(this.urllabel_Click);
            // 
            // Barbora
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1817, 953);
            this.Controls.Add(this.urllabel);
            this.Controls.Add(this.catlabel);
            this.Controls.Add(this.labelProcess);
            this.Controls.Add(this.buttonExecute);
            this.Controls.Add(this.productDataView);
            this.Name = "Barbora";
            this.Text = "Barbora Latvia Product Data";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.productDataView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView productDataView;
        private System.Windows.Forms.Button buttonExecute;
        private System.Windows.Forms.Label labelProcess;
        private System.Windows.Forms.Label catlabel;
        private System.Windows.Forms.Label urllabel;
    }
}

