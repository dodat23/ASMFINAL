namespace ASMFINAL
{
    partial class Form4
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
            dtgproduct = new DataGridView();
            btnadd = new Button();
            btnedit = new Button();
            btndelete = new Button();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            label5 = new Label();
            txtname = new TextBox();
            txtcost = new TextBox();
            txtquantity = new TextBox();
            txtdescr = new TextBox();
            label6 = new Label();
            pictureBox1 = new PictureBox();
            btnchoose = new Button();
            btnup = new Button();
            ((System.ComponentModel.ISupportInitialize)dtgproduct).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // dtgproduct
            // 
            dtgproduct.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dtgproduct.Location = new Point(12, 42);
            dtgproduct.Name = "dtgproduct";
            dtgproduct.RowHeadersWidth = 62;
            dtgproduct.Size = new Size(909, 210);
            dtgproduct.TabIndex = 0;
            dtgproduct.CellClick += dtgproduct_CellContentClick;
            dtgproduct.CellContentClick += dtgproduct_CellContentClick_1;
            // 
            // btnadd
            // 
            btnadd.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 163);
            btnadd.Location = new Point(714, 334);
            btnadd.Name = "btnadd";
            btnadd.Size = new Size(112, 45);
            btnadd.TabIndex = 1;
            btnadd.Text = "Add";
            btnadd.UseVisualStyleBackColor = true;
            btnadd.Click += btnadd_Click;
            // 
            // btnedit
            // 
            btnedit.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 163);
            btnedit.Location = new Point(714, 409);
            btnedit.Name = "btnedit";
            btnedit.Size = new Size(112, 45);
            btnedit.TabIndex = 2;
            btnedit.Text = "Edit";
            btnedit.UseVisualStyleBackColor = true;
            btnedit.Click += btnedit_Click;
            // 
            // btndelete
            // 
            btndelete.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 163);
            btndelete.Location = new Point(714, 485);
            btndelete.Name = "btndelete";
            btndelete.Size = new Size(112, 45);
            btndelete.TabIndex = 3;
            btndelete.Text = "Delete";
            btndelete.UseVisualStyleBackColor = true;
            btndelete.Click += btndelete_Click;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI Historic", 10F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label2.Location = new Point(0, 272);
            label2.Name = "label2";
            label2.Size = new Size(68, 28);
            label2.TabIndex = 6;
            label2.Text = "Name";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI Historic", 10F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label3.Location = new Point(297, 272);
            label3.Name = "label3";
            label3.Size = new Size(117, 28);
            label3.TabIndex = 7;
            label3.Text = "Cost (USD)";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI Historic", 10F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label4.Location = new Point(0, 346);
            label4.Name = "label4";
            label4.Size = new Size(96, 28);
            label4.TabIndex = 8;
            label4.Text = "Quantity";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI Historic", 10F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label5.Location = new Point(291, 346);
            label5.Name = "label5";
            label5.Size = new Size(123, 28);
            label5.TabIndex = 9;
            label5.Text = "Description";
            // 
            // txtname
            // 
            txtname.Location = new Point(116, 269);
            txtname.Name = "txtname";
            txtname.Size = new Size(150, 31);
            txtname.TabIndex = 11;
            // 
            // txtcost
            // 
            txtcost.Location = new Point(430, 269);
            txtcost.Name = "txtcost";
            txtcost.Size = new Size(150, 31);
            txtcost.TabIndex = 12;
            // 
            // txtquantity
            // 
            txtquantity.Location = new Point(115, 346);
            txtquantity.Name = "txtquantity";
            txtquantity.Size = new Size(150, 31);
            txtquantity.TabIndex = 13;
            // 
            // txtdescr
            // 
            txtdescr.Location = new Point(430, 343);
            txtdescr.Name = "txtdescr";
            txtdescr.Size = new Size(150, 31);
            txtdescr.TabIndex = 14;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Sitka Subheading", 14F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label6.Location = new Point(332, -1);
            label6.Name = "label6";
            label6.Size = new Size(266, 40);
            label6.TabIndex = 15;
            label6.Text = "Product Manament";
            // 
            // pictureBox1
            // 
            pictureBox1.ErrorImage = null;
            pictureBox1.Location = new Point(12, 396);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(288, 135);
            pictureBox1.SizeMode = PictureBoxSizeMode.CenterImage;
            pictureBox1.TabIndex = 16;
            pictureBox1.TabStop = false;
            // 
            // btnchoose
            // 
            btnchoose.Font = new Font("Segoe UI", 11F, FontStyle.Bold, GraphicsUnit.Point, 163);
            btnchoose.Location = new Point(413, 444);
            btnchoose.Name = "btnchoose";
            btnchoose.Size = new Size(185, 45);
            btnchoose.TabIndex = 17;
            btnchoose.Text = "Choose Image";
            btnchoose.UseVisualStyleBackColor = true;
            btnchoose.Click += btnchoose_Click;
            // 
            // btnup
            // 
            btnup.Font = new Font("Segoe UI Symbol", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnup.Location = new Point(702, 264);
            btnup.Name = "btnup";
            btnup.Size = new Size(137, 47);
            btnup.TabIndex = 18;
            btnup.Text = "UploadData";
            btnup.UseVisualStyleBackColor = true;
            btnup.Click += btnup_Click;
            // 
            // Form4
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(933, 543);
            Controls.Add(btnup);
            Controls.Add(btnchoose);
            Controls.Add(pictureBox1);
            Controls.Add(label6);
            Controls.Add(txtdescr);
            Controls.Add(txtquantity);
            Controls.Add(txtcost);
            Controls.Add(txtname);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(btndelete);
            Controls.Add(btnedit);
            Controls.Add(btnadd);
            Controls.Add(dtgproduct);
            Name = "Form4";
            Text = "Form4";
            Load += Form4_Load;
            ((System.ComponentModel.ISupportInitialize)dtgproduct).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DataGridView dtgproduct;
        private Button btnadd;
        private Button btnedit;
        private Button btndelete;
        private Label label2;
        private Label label3;
        private Label label4;
        private Label label5;
        private TextBox txtname;
        private TextBox txtcost;
        private TextBox txtquantity;
        private TextBox txtdescr;
        private Label label6;
        private PictureBox pictureBox1;
        private Button btnchoose;
        private Button btnup;
    }
}