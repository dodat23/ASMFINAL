namespace ASMFINAL
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
            label1 = new Label();
            label2 = new Label();
            groupBox1 = new GroupBox();
            cbbposition = new ComboBox();
            label5 = new Label();
            btnlogin = new Button();
            btnregist = new Button();
            btnexit = new Button();
            txtpass = new TextBox();
            txtuser = new TextBox();
            label4 = new Label();
            cbbas = new ComboBox();
            label3 = new Label();
            groupBox1.SuspendLayout();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Showcard Gothic", 11F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point, 0);
            label1.Location = new Point(163, 0);
            label1.Name = "label1";
            label1.Size = new Size(401, 28);
            label1.TabIndex = 0;
            label1.Text = "Welcome to Dat Do book store";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point, 163);
            label2.Location = new Point(84, 74);
            label2.Name = "label2";
            label2.Size = new Size(128, 32);
            label2.TabIndex = 1;
            label2.Text = "UserName";
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(cbbposition);
            groupBox1.Controls.Add(label5);
            groupBox1.Controls.Add(btnlogin);
            groupBox1.Controls.Add(btnregist);
            groupBox1.Controls.Add(btnexit);
            groupBox1.Controls.Add(txtpass);
            groupBox1.Controls.Add(txtuser);
            groupBox1.Controls.Add(label4);
            groupBox1.Controls.Add(cbbas);
            groupBox1.Controls.Add(label3);
            groupBox1.Controls.Add(label2);
            groupBox1.Controls.Add(label1);
            groupBox1.Location = new Point(90, 50);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(776, 392);
            groupBox1.TabIndex = 2;
            groupBox1.TabStop = false;
            // 
            // cbbposition
            // 
            cbbposition.Font = new Font("Segoe UI Semibold", 10F, FontStyle.Bold, GraphicsUnit.Point, 163);
            cbbposition.FormattingEnabled = true;
            cbbposition.Items.AddRange(new object[] { "Sale", "Warehouse management" });
            cbbposition.Location = new Point(585, 179);
            cbbposition.Name = "cbbposition";
            cbbposition.Size = new Size(185, 36);
            cbbposition.TabIndex = 11;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point, 163);
            label5.Location = new Point(463, 183);
            label5.Name = "label5";
            label5.Size = new Size(100, 32);
            label5.TabIndex = 10;
            label5.Text = "Position";
            label5.Click += label5_Click;
            // 
            // btnlogin
            // 
            btnlogin.Font = new Font("Segoe UI Symbol", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnlogin.Location = new Point(550, 276);
            btnlogin.Name = "btnlogin";
            btnlogin.Size = new Size(119, 41);
            btnlogin.TabIndex = 9;
            btnlogin.Text = "Login";
            btnlogin.UseVisualStyleBackColor = true;
            btnlogin.Click += btnlogin_Click_1;
            // 
            // btnregist
            // 
            btnregist.Font = new Font("Segoe UI Symbol", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnregist.Location = new Point(322, 276);
            btnregist.Name = "btnregist";
            btnregist.Size = new Size(119, 41);
            btnregist.TabIndex = 8;
            btnregist.Text = "Register";
            btnregist.UseVisualStyleBackColor = true;
            btnregist.Click += btnregist_Click;
            // 
            // btnexit
            // 
            btnexit.Font = new Font("Segoe UI Symbol", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnexit.Location = new Point(84, 276);
            btnexit.Name = "btnexit";
            btnexit.Size = new Size(119, 41);
            btnexit.TabIndex = 7;
            btnexit.Text = "Exit";
            btnexit.UseVisualStyleBackColor = true;
            btnexit.Click += btnexit_Click;
            // 
            // txtpass
            // 
            txtpass.Location = new Point(240, 182);
            txtpass.Name = "txtpass";
            txtpass.PasswordChar = '*';
            txtpass.Size = new Size(184, 31);
            txtpass.TabIndex = 6;
            // 
            // txtuser
            // 
            txtuser.Location = new Point(240, 77);
            txtuser.Name = "txtuser";
            txtuser.Size = new Size(184, 31);
            txtuser.TabIndex = 5;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point, 163);
            label4.Location = new Point(463, 77);
            label4.Name = "label4";
            label4.Size = new Size(104, 32);
            label4.TabIndex = 4;
            label4.Text = "Login as";
            // 
            // cbbas
            // 
            cbbas.Font = new Font("Segoe UI Semibold", 10F, FontStyle.Bold, GraphicsUnit.Point, 163);
            cbbas.FormattingEnabled = true;
            cbbas.Items.AddRange(new object[] { "Manager", "Employee", "Customer" });
            cbbas.Location = new Point(585, 74);
            cbbas.Name = "cbbas";
            cbbas.Size = new Size(185, 36);
            cbbas.TabIndex = 3;
            cbbas.SelectedIndexChanged += cbbas_SelectedIndexChanged;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point, 163);
            label3.Location = new Point(84, 183);
            label3.Name = "label3";
            label3.Size = new Size(119, 32);
            label3.TabIndex = 2;
            label3.Text = "PassWord";
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(932, 531);
            Controls.Add(groupBox1);
            Name = "Form1";
            Text = "Form1";
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Label label1;
        private Label label2;
        private GroupBox groupBox1;
        private TextBox txtuser;
        private Label label4;
        private ComboBox cbbas;
        private Label label3;
        private Button btnlogin;
        private Button btnregist;
        private Button btnexit;
        private TextBox txtpass;
        private ComboBox cbbposition;
        private Label label5;
    }
}
