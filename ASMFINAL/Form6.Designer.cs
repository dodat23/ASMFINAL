namespace ASMFINAL
{
    partial class Form6
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
            label1 = new Label();
            dtgemployee = new DataGridView();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            label5 = new Label();
            txtuser = new TextBox();
            txtpass = new TextBox();
            txtname = new TextBox();
            txtposition = new TextBox();
            button1Abtnadd = new Button();
            btnedit = new Button();
            btndelete = new Button();
            btnreturn = new Button();
            txtID = new TextBox();
            label6 = new Label();
            ((System.ComponentModel.ISupportInitialize)dtgemployee).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Sitka Display", 14F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point, 0);
            label1.Location = new Point(400, 9);
            label1.Name = "label1";
            label1.Size = new Size(277, 40);
            label1.TabIndex = 0;
            label1.Text = "Employee Mangament";
            // 
            // dtgemployee
            // 
            dtgemployee.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dtgemployee.Location = new Point(56, 52);
            dtgemployee.Name = "dtgemployee";
            dtgemployee.RowHeadersWidth = 62;
            dtgemployee.Size = new Size(954, 284);
            dtgemployee.TabIndex = 1;
            dtgemployee.CellContentClick += dtgemployee_CellContentClick;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI Semibold", 11F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label2.Location = new Point(-2, 456);
            label2.Name = "label2";
            label2.Size = new Size(112, 30);
            label2.TabIndex = 2;
            label2.Text = "Username";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI Semibold", 11F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label3.Location = new Point(-2, 518);
            label3.Name = "label3";
            label3.Size = new Size(105, 30);
            label3.TabIndex = 3;
            label3.Text = "Password";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI Semibold", 11F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label4.Location = new Point(400, 398);
            label4.Name = "label4";
            label4.Size = new Size(72, 30);
            label4.TabIndex = 4;
            label4.Text = "Name";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI Semibold", 11F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label5.Location = new Point(400, 485);
            label5.Name = "label5";
            label5.Size = new Size(93, 30);
            label5.TabIndex = 5;
            label5.Text = "Position";
            // 
            // txtuser
            // 
            txtuser.Location = new Point(140, 457);
            txtuser.Name = "txtuser";
            txtuser.Size = new Size(167, 31);
            txtuser.TabIndex = 6;
            // 
            // txtpass
            // 
            txtpass.Location = new Point(140, 514);
            txtpass.Name = "txtpass";
            txtpass.Size = new Size(167, 31);
            txtpass.TabIndex = 7;
            // 
            // txtname
            // 
            txtname.Location = new Point(528, 399);
            txtname.Name = "txtname";
            txtname.Size = new Size(167, 31);
            txtname.TabIndex = 8;
            // 
            // txtposition
            // 
            txtposition.Location = new Point(528, 486);
            txtposition.Name = "txtposition";
            txtposition.Size = new Size(167, 31);
            txtposition.TabIndex = 9;
            
            // 
            // button1Abtnadd
            // 
            button1Abtnadd.Font = new Font("Segoe UI Emoji", 11F, FontStyle.Bold, GraphicsUnit.Point, 0);
            button1Abtnadd.Location = new Point(774, 392);
            button1Abtnadd.Name = "button1Abtnadd";
            button1Abtnadd.Size = new Size(112, 42);
            button1Abtnadd.TabIndex = 10;
            button1Abtnadd.Text = "Add";
            button1Abtnadd.UseVisualStyleBackColor = true;
            button1Abtnadd.Click += button1Abtnadd_Click;
            // 
            // btnedit
            // 
            btnedit.Font = new Font("Segoe UI Emoji", 11F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnedit.Location = new Point(931, 392);
            btnedit.Name = "btnedit";
            btnedit.Size = new Size(112, 42);
            btnedit.TabIndex = 11;
            btnedit.Text = "Edit";
            btnedit.UseVisualStyleBackColor = true;
            btnedit.Click += btnedit_Click;
            // 
            // btndelete
            // 
            btndelete.Font = new Font("Segoe UI Emoji", 11F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btndelete.Location = new Point(774, 477);
            btndelete.Name = "btndelete";
            btndelete.Size = new Size(112, 42);
            btndelete.TabIndex = 12;
            btndelete.Text = "Delete";
            btndelete.UseVisualStyleBackColor = true;
            btndelete.Click += btndelete_Click;
            // 
            // btnreturn
            // 
            btnreturn.Font = new Font("Segoe UI Emoji", 11F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnreturn.Location = new Point(931, 479);
            btnreturn.Name = "btnreturn";
            btnreturn.Size = new Size(112, 42);
            btnreturn.TabIndex = 13;
            btnreturn.Text = "Return";
            btnreturn.UseVisualStyleBackColor = true;
            btnreturn.Click += btnreturn_Click;
            // 
            // txtID
            // 
            txtID.Location = new Point(140, 392);
            txtID.Name = "txtID";
            txtID.Size = new Size(167, 31);
            txtID.TabIndex = 14;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Segoe UI Semibold", 11F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label6.Location = new Point(-2, 391);
            label6.Name = "label6";
            label6.Size = new Size(132, 30);
            label6.TabIndex = 15;
            label6.Text = "EmployeeID";
            // 
            // Form6
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1055, 557);
            Controls.Add(label6);
            Controls.Add(txtID);
            Controls.Add(btnreturn);
            Controls.Add(btndelete);
            Controls.Add(btnedit);
            Controls.Add(button1Abtnadd);
            Controls.Add(txtposition);
            Controls.Add(txtname);
            Controls.Add(txtpass);
            Controls.Add(txtuser);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(dtgemployee);
            Controls.Add(label1);
            Name = "Form6";
            Text = "Form6";
            ((System.ComponentModel.ISupportInitialize)dtgemployee).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private DataGridView dtgemployee;
        private Label label2;
        private Label label3;
        private Label label4;
        private Label label5;
        private TextBox txtuser;
        private TextBox txtpass;
        private TextBox txtname;
        private TextBox txtposition;
        private Button button1Abtnadd;
        private Button btnedit;
        private Button btndelete;
        private Button btnreturn;
        private TextBox txtID;
        private Label label6;
    }
}