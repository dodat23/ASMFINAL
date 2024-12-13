namespace ASMFINAL
{
    partial class Form3
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
            backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            groupBox1 = new GroupBox();
            btnpur = new Button();
            btnreturn = new Button();
            btncustomer = new Button();
            btneplacc = new Button();
            btnproduct = new Button();
            groupBox1.SuspendLayout();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI Symbol", 16F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Location = new Point(283, 9);
            label1.Name = "label1";
            label1.Size = new Size(304, 45);
            label1.TabIndex = 0;
            label1.Text = "Welcome Manager";
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(btnpur);
            groupBox1.Controls.Add(btnreturn);
            groupBox1.Controls.Add(btncustomer);
            groupBox1.Controls.Add(btneplacc);
            groupBox1.Controls.Add(btnproduct);
            groupBox1.Location = new Point(162, 57);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(543, 389);
            groupBox1.TabIndex = 1;
            groupBox1.TabStop = false;
            // 
            // btnpur
            // 
            btnpur.Font = new Font("Segoe UI Historic", 10F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnpur.Location = new Point(310, 149);
            btnpur.Name = "btnpur";
            btnpur.Size = new Size(212, 72);
            btnpur.TabIndex = 7;
            btnpur.Text = "Purchase History";
            btnpur.UseVisualStyleBackColor = true;
            btnpur.Click += btnpur_Click;
            // 
            // btnreturn
            // 
            btnreturn.Font = new Font("Segoe UI Historic", 10F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnreturn.Location = new Point(177, 311);
            btnreturn.Name = "btnreturn";
            btnreturn.Size = new Size(212, 72);
            btnreturn.TabIndex = 6;
            btnreturn.Text = "Return";
            btnreturn.UseVisualStyleBackColor = true;
            btnreturn.Click += btnreturn_Click;
            // 
            // btncustomer
            // 
            btncustomer.Font = new Font("Segoe UI Historic", 10F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btncustomer.Location = new Point(25, 149);
            btncustomer.Name = "btncustomer";
            btncustomer.Size = new Size(212, 72);
            btncustomer.TabIndex = 5;
            btncustomer.Text = "Customer Account";
            btncustomer.UseVisualStyleBackColor = true;
            btncustomer.Click += btncustomer_Click;
            // 
            // btneplacc
            // 
            btneplacc.Font = new Font("Segoe UI Historic", 10F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btneplacc.Location = new Point(310, 39);
            btneplacc.Name = "btneplacc";
            btneplacc.Size = new Size(212, 72);
            btneplacc.TabIndex = 4;
            btneplacc.Text = "Employee Account";
            btneplacc.UseVisualStyleBackColor = true;
            btneplacc.Click += btneplacc_Click;
            // 
            // btnproduct
            // 
            btnproduct.Font = new Font("Segoe UI Historic", 10F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnproduct.Location = new Point(25, 39);
            btnproduct.Name = "btnproduct";
            btnproduct.Size = new Size(212, 72);
            btnproduct.TabIndex = 2;
            btnproduct.Text = "Product Manament";
            btnproduct.UseVisualStyleBackColor = true;
            btnproduct.Click += btnproduct_Click;
            // 
            // Form3
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(880, 476);
            Controls.Add(groupBox1);
            Controls.Add(label1);
            Name = "Form3";
            Text = "Form3";
            groupBox1.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private GroupBox groupBox1;
        private Button btnproduct;
        private Button btneplacc;
        private Button btncustomer;
        private Button btnreturn;
        private Button btnpur;
    }
}