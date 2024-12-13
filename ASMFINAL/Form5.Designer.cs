namespace ASMFINAL
{
    partial class Form5
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
            dtgacc = new DataGridView();
            backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            btndelete = new Button();
            btnreturn = new Button();
            ((System.ComponentModel.ISupportInitialize)dtgacc).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 16F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point, 163);
            label1.Location = new Point(322, 9);
            label1.Name = "label1";
            label1.Size = new Size(306, 45);
            label1.TabIndex = 0;
            label1.Text = "Customer Accounts";
            // 
            // dtgacc
            // 
            dtgacc.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dtgacc.Location = new Point(0, 72);
            dtgacc.Name = "dtgacc";
            dtgacc.RowHeadersWidth = 62;
            dtgacc.Size = new Size(954, 270);
            dtgacc.TabIndex = 1;
            dtgacc.CellContentClick += dtgacc_CellContentClick;
            // 
            // btndelete
            // 
            btndelete.Font = new Font("Showcard Gothic", 10F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btndelete.Location = new Point(600, 380);
            btndelete.Name = "btndelete";
            btndelete.Size = new Size(154, 59);
            btndelete.TabIndex = 2;
            btndelete.Text = "Delete";
            btndelete.UseVisualStyleBackColor = true;
            btndelete.Click += btndelete_Click;
            // 
            // btnreturn
            // 
            btnreturn.Font = new Font("Showcard Gothic", 10F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnreturn.Location = new Point(194, 380);
            btnreturn.Name = "btnreturn";
            btnreturn.Size = new Size(154, 59);
            btnreturn.TabIndex = 3;
            btnreturn.Text = "Return";
            btnreturn.UseVisualStyleBackColor = true;
            btnreturn.Click += btnreturn_Click;
            // 
            // Form5
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(957, 568);
            Controls.Add(btnreturn);
            Controls.Add(btndelete);
            Controls.Add(dtgacc);
            Controls.Add(label1);
            Name = "Form5";
            Text = "Form5";
            ((System.ComponentModel.ISupportInitialize)dtgacc).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private DataGridView dtgacc;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private Button btndelete;
        private Button btnreturn;
    }
}