namespace ASMFINAL
{
    partial class Form2new
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
            groupBox1 = new GroupBox();
            btnregist = new Button();
            btnreturn = new Button();
            txtaddress = new TextBox();
            txtphone = new TextBox();
            txtname = new TextBox();
            txtpass = new TextBox();
            txtuser = new TextBox();
            label6 = new Label();
            label5 = new Label();
            label4 = new Label();
            label3 = new Label();
            label2 = new Label();
            label7 = new Label();
            txtID = new TextBox();
            groupBox1.SuspendLayout();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Sitka Heading", 16F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Location = new Point(299, 9);
            label1.Name = "label1";
            label1.Size = new Size(363, 47);
            label1.TabIndex = 0;
            label1.Text = "Register account in here";
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(txtID);
            groupBox1.Controls.Add(label7);
            groupBox1.Controls.Add(btnregist);
            groupBox1.Controls.Add(btnreturn);
            groupBox1.Controls.Add(txtaddress);
            groupBox1.Controls.Add(txtphone);
            groupBox1.Controls.Add(txtname);
            groupBox1.Controls.Add(txtpass);
            groupBox1.Controls.Add(txtuser);
            groupBox1.Controls.Add(label6);
            groupBox1.Controls.Add(label5);
            groupBox1.Controls.Add(label4);
            groupBox1.Controls.Add(label3);
            groupBox1.Controls.Add(label2);
            groupBox1.Location = new Point(164, 72);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(606, 472);
            groupBox1.TabIndex = 1;
            groupBox1.TabStop = false;
            // 
            // btnregist
            // 
            btnregist.Font = new Font("Segoe UI Symbol", 11F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnregist.Location = new Point(432, 393);
            btnregist.Name = "btnregist";
            btnregist.Size = new Size(112, 54);
            btnregist.TabIndex = 11;
            btnregist.Text = "Regist";
            btnregist.UseVisualStyleBackColor = true;
            btnregist.Click += btnregist_Click;
            // 
            // btnreturn
            // 
            btnreturn.Font = new Font("Segoe UI Symbol", 11F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnreturn.Location = new Point(102, 393);
            btnreturn.Name = "btnreturn";
            btnreturn.Size = new Size(112, 54);
            btnreturn.TabIndex = 10;
            btnreturn.Text = "Return";
            btnreturn.UseVisualStyleBackColor = true;
            btnreturn.Click += btnreturn_Click;
            // 
            // txtaddress
            // 
            txtaddress.Location = new Point(290, 339);
            txtaddress.Name = "txtaddress";
            txtaddress.Size = new Size(238, 31);
            txtaddress.TabIndex = 9;
            // 
            // txtphone
            // 
            txtphone.Location = new Point(290, 271);
            txtphone.Name = "txtphone";
            txtphone.Size = new Size(238, 31);
            txtphone.TabIndex = 8;
            // 
            // txtname
            // 
            txtname.Location = new Point(290, 205);
            txtname.Name = "txtname";
            txtname.Size = new Size(238, 31);
            txtname.TabIndex = 7;
            // 
            // txtpass
            // 
            txtpass.Location = new Point(290, 140);
            txtpass.Name = "txtpass";
            txtpass.Size = new Size(238, 31);
            txtpass.TabIndex = 6;
            // 
            // txtuser
            // 
            txtuser.Location = new Point(290, 75);
            txtuser.Name = "txtuser";
            txtuser.Size = new Size(238, 31);
            txtuser.TabIndex = 5;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Segoe UI Emoji", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label6.Location = new Point(100, 339);
            label6.Name = "label6";
            label6.Size = new Size(105, 32);
            label6.TabIndex = 4;
            label6.Text = "Address";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI Emoji", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label5.Location = new Point(102, 268);
            label5.Name = "label5";
            label5.Size = new Size(87, 32);
            label5.TabIndex = 3;
            label5.Text = "Phone";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI Emoji", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label4.Location = new Point(100, 205);
            label4.Name = "label4";
            label4.Size = new Size(82, 32);
            label4.TabIndex = 2;
            label4.Text = "Name";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI Emoji", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label3.Location = new Point(100, 139);
            label3.Name = "label3";
            label3.Size = new Size(120, 32);
            label3.TabIndex = 1;
            label3.Text = "Password";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI Emoji", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label2.Location = new Point(100, 73);
            label2.Name = "label2";
            label2.Size = new Size(129, 32);
            label2.TabIndex = 0;
            label2.Text = "Username";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Font = new Font("Segoe UI Emoji", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label7.Location = new Point(102, 15);
            label7.Name = "label7";
            label7.Size = new Size(150, 32);
            label7.TabIndex = 12;
            label7.Text = "CustomerID";
            // 
            // txtID
            // 
            txtID.Location = new Point(290, 15);
            txtID.Name = "txtID";
            txtID.Size = new Size(238, 31);
            txtID.TabIndex = 13;
            // 
            // Form2new
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(890, 547);
            Controls.Add(groupBox1);
            Controls.Add(label1);
            Name = "Form2new";
            Text = "Form2new";
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private GroupBox groupBox1;
        private TextBox txtpass;
        private TextBox txtuser;
        private Label label6;
        private Label label5;
        private Label label4;
        private Label label3;
        private Label label2;
        private Button btnregist;
        private Button btnreturn;
        private TextBox txtaddress;
        private TextBox txtphone;
        private TextBox txtname;
        private TextBox txtID;
        private Label label7;
    }
}