namespace ASMFINAL
{
    partial class Form7
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
            txtsearch = new TextBox();
            btnsearch = new Button();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            txtname = new TextBox();
            txtcost = new TextBox();
            txtdescr = new TextBox();
            txtquantity = new TextBox();
            ptb = new PictureBox();
            btnbuy = new Button();
            btnexit = new Button();
            dtgProductsForm7 = new DataGridView();
            ((System.ComponentModel.ISupportInitialize)ptb).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dtgProductsForm7).BeginInit();
            SuspendLayout();
            // 
            // txtsearch
            // 
            txtsearch.Location = new Point(12, 280);
            txtsearch.Name = "txtsearch";
            txtsearch.Size = new Size(228, 31);
            txtsearch.TabIndex = 1;
            // 
            // btnsearch
            // 
            btnsearch.Location = new Point(256, 280);
            btnsearch.Name = "btnsearch";
            btnsearch.Size = new Size(112, 34);
            btnsearch.TabIndex = 2;
            btnsearch.Text = "Search";
            btnsearch.UseVisualStyleBackColor = true;
            btnsearch.Click += btnsearch_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 163);
            label1.Location = new Point(12, 347);
            label1.Name = "label1";
            label1.Size = new Size(62, 25);
            label1.TabIndex = 3;
            label1.Text = "Name";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 163);
            label2.Location = new Point(12, 406);
            label2.Name = "label2";
            label2.Size = new Size(99, 25);
            label2.TabIndex = 4;
            label2.Text = "Cost(USD)";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 163);
            label3.Location = new Point(10, 457);
            label3.Name = "label3";
            label3.Size = new Size(87, 25);
            label3.TabIndex = 5;
            label3.Text = "Quantity";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 163);
            label4.Location = new Point(12, 509);
            label4.Name = "label4";
            label4.Size = new Size(109, 25);
            label4.TabIndex = 6;
            label4.Text = "Description";
            // 
            // txtname
            // 
            txtname.Location = new Point(168, 344);
            txtname.Name = "txtname";
            txtname.ReadOnly = true;
            txtname.Size = new Size(228, 31);
            txtname.TabIndex = 7;
            // 
            // txtcost
            // 
            txtcost.Location = new Point(168, 400);
            txtcost.Name = "txtcost";
            txtcost.ReadOnly = true;
            txtcost.Size = new Size(228, 31);
            txtcost.TabIndex = 8;
            // 
            // txtdescr
            // 
            txtdescr.Location = new Point(168, 506);
            txtdescr.Name = "txtdescr";
            txtdescr.ReadOnly = true;
            txtdescr.Size = new Size(228, 31);
            txtdescr.TabIndex = 9;
            // 
            // txtquantity
            // 
            txtquantity.Location = new Point(168, 456);
            txtquantity.Name = "txtquantity";
            txtquantity.ReadOnly = true;
            txtquantity.Size = new Size(228, 31);
            txtquantity.TabIndex = 9;
            // 
            // ptb
            // 
            ptb.ErrorImage = null;
            ptb.Location = new Point(419, 280);
            ptb.Name = "ptb";
            ptb.Size = new Size(398, 262);
            ptb.SizeMode = PictureBoxSizeMode.CenterImage;
            ptb.TabIndex = 10;
            ptb.TabStop = false;
            // 
            // btnbuy
            // 
            btnbuy.Font = new Font("SimSun", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnbuy.Location = new Point(888, 379);
            btnbuy.Name = "btnbuy";
            btnbuy.Size = new Size(112, 34);
            btnbuy.TabIndex = 11;
            btnbuy.Text = "Buy";
            btnbuy.UseVisualStyleBackColor = true;
            btnbuy.Click += btnbuy_Click;
            // 
            // btnexit
            // 
            btnexit.Font = new Font("SimSun", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnexit.Location = new Point(888, 457);
            btnexit.Name = "btnexit";
            btnexit.Size = new Size(112, 34);
            btnexit.TabIndex = 14;
            btnexit.Text = "Exit";
            btnexit.UseVisualStyleBackColor = true;
            btnexit.Click += btnexit_Click;
            // 
            // dtgProductsForm7
            // 
            dtgProductsForm7.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dtgProductsForm7.Location = new Point(172, 2);
            dtgProductsForm7.Name = "dtgProductsForm7";
            dtgProductsForm7.RowHeadersWidth = 62;
            dtgProductsForm7.Size = new Size(737, 248);
            dtgProductsForm7.TabIndex = 15;
            // 
            // Form7
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1049, 554);
            Controls.Add(dtgProductsForm7);
            Controls.Add(btnexit);
            Controls.Add(btnbuy);
            Controls.Add(ptb);
            Controls.Add(txtquantity);
            Controls.Add(txtdescr);
            Controls.Add(txtcost);
            Controls.Add(txtname);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(btnsearch);
            Controls.Add(txtsearch);
            Name = "Form7";
            Text = "Form7";
            ((System.ComponentModel.ISupportInitialize)ptb).EndInit();
            ((System.ComponentModel.ISupportInitialize)dtgProductsForm7).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private TextBox txtsearch;
        private Button btnsearch;
        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private TextBox txtname;
        private TextBox txtcost;
        private TextBox txtdescr;
        private TextBox txtquantity;
        private PictureBox ptb;
        private Button btnbuy;
        private Button btnexit;
        private DataGridView dtgProductsForm7;
    }
}