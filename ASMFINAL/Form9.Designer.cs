namespace ASMFINAL
{
    partial class Form9
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
            dtgpurchase = new DataGridView();
            label1 = new Label();
            label2 = new Label();
            backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            btncal = new Button();
            btnclose = new Button();
            label3 = new Label();
            txtprin = new TextBox();
            txttotal = new TextBox();
            txtprofit = new TextBox();
            label4 = new Label();
            txttotalrevenue = new TextBox();
            ((System.ComponentModel.ISupportInitialize)dtgpurchase).BeginInit();
            SuspendLayout();
            // 
            // dtgpurchase
            // 
            dtgpurchase.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dtgpurchase.Location = new Point(0, 0);
            dtgpurchase.Name = "dtgpurchase";
            dtgpurchase.RowHeadersWidth = 62;
            dtgpurchase.Size = new Size(944, 241);
            dtgpurchase.TabIndex = 0;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 11F, FontStyle.Bold, GraphicsUnit.Point, 163);
            label1.Location = new Point(28, 258);
            label1.Name = "label1";
            label1.Size = new Size(163, 30);
            label1.TabIndex = 1;
            label1.Text = "Total Products";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 11F, FontStyle.Bold, GraphicsUnit.Point, 163);
            label2.Location = new Point(28, 420);
            label2.Name = "label2";
            label2.Size = new Size(72, 30);
            label2.TabIndex = 2;
            label2.Text = "Profit";
            // 
            // btncal
            // 
            btncal.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 163);
            btncal.Location = new Point(538, 308);
            btncal.Name = "btncal";
            btncal.Size = new Size(133, 57);
            btncal.TabIndex = 5;
            btncal.Text = "Calculate";
            btncal.UseVisualStyleBackColor = true;
            btncal.Click += btncal_Click;
            // 
            // btnclose
            // 
            btnclose.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 163);
            btnclose.Location = new Point(741, 308);
            btnclose.Name = "btnclose";
            btnclose.Size = new Size(133, 57);
            btnclose.TabIndex = 6;
            btnclose.Text = "Close";
            btnclose.UseVisualStyleBackColor = true;
            btnclose.Click += btnclose_Click;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 11F, FontStyle.Bold, GraphicsUnit.Point, 163);
            label3.Location = new Point(27, 360);
            label3.Name = "label3";
            label3.Size = new Size(202, 30);
            label3.TabIndex = 7;
            label3.Text = "Printciple Amount";
            // 
            // txtprin
            // 
            txtprin.Location = new Point(249, 362);
            txtprin.Name = "txtprin";
            txtprin.ReadOnly = true;
            txtprin.Size = new Size(177, 31);
            txtprin.TabIndex = 8;
            // 
            // txttotal
            // 
            txttotal.Location = new Point(249, 258);
            txttotal.Name = "txttotal";
            txttotal.ReadOnly = true;
            txttotal.Size = new Size(177, 31);
            txttotal.TabIndex = 9;
            // 
            // txtprofit
            // 
            txtprofit.Location = new Point(249, 418);
            txtprofit.Name = "txtprofit";
            txtprofit.ReadOnly = true;
            txtprofit.Size = new Size(177, 31);
            txtprofit.TabIndex = 10;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 11F, FontStyle.Bold, GraphicsUnit.Point, 163);
            label4.Location = new Point(28, 308);
            label4.Name = "label4";
            label4.Size = new Size(157, 30);
            label4.TabIndex = 11;
            label4.Text = "Total Revenue";
            // 
            // txttotalrevenue
            // 
            txttotalrevenue.Location = new Point(249, 307);
            txttotalrevenue.Name = "txttotalrevenue";
            txttotalrevenue.ReadOnly = true;
            txttotalrevenue.Size = new Size(177, 31);
            txttotalrevenue.TabIndex = 12;
            // 
            // Form9
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(943, 474);
            Controls.Add(txttotalrevenue);
            Controls.Add(label4);
            Controls.Add(txtprofit);
            Controls.Add(txttotal);
            Controls.Add(txtprin);
            Controls.Add(label3);
            Controls.Add(btnclose);
            Controls.Add(btncal);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(dtgpurchase);
            Name = "Form9";
            Text = "Form9";
            Load += Form9_Load;
            ((System.ComponentModel.ISupportInitialize)dtgpurchase).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DataGridView dtgpurchase;
        private Label label1;
        private Label label2;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private Button btncal;
        private Button btnclose;
        private Label label3;
        private TextBox txtprin;
        private TextBox txttotal;
        private TextBox txtprofit;
        private Label label4;
        private TextBox txttotalrevenue;
    }
}