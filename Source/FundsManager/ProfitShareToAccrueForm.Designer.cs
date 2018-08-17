namespace FundsManager
{
    partial class ProfitShareToAccrueForm
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
            this.label1 = new System.Windows.Forms.Label();
            this.dtpDate = new System.Windows.Forms.DateTimePicker();
            this.cmdGenerateInterest = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(30, 23);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(33, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Date:";
            // 
            // dtpDate
            // 
            this.dtpDate.Location = new System.Drawing.Point(69, 21);
            this.dtpDate.Name = "dtpDate";
            this.dtpDate.Size = new System.Drawing.Size(200, 20);
            this.dtpDate.TabIndex = 1;
            // 
            // cmdGenerateInterest
            // 
            this.cmdGenerateInterest.Location = new System.Drawing.Point(92, 64);
            this.cmdGenerateInterest.Name = "cmdGenerateInterest";
            this.cmdGenerateInterest.Size = new System.Drawing.Size(177, 23);
            this.cmdGenerateInterest.TabIndex = 2;
            this.cmdGenerateInterest.Text = "Generate Interest";
            this.cmdGenerateInterest.UseVisualStyleBackColor = true;
            this.cmdGenerateInterest.Click += new System.EventHandler(this.cmdGenerateInterest_Click);
            // 
            // ProfitShareToAccrueForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(294, 110);
            this.Controls.Add(this.cmdGenerateInterest);
            this.Controls.Add(this.dtpDate);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "ProfitShareToAccrueForm";
            this.Text = "Profit Share To Accrue";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DateTimePicker dtpDate;
        private System.Windows.Forms.Button cmdGenerateInterest;
    }
}