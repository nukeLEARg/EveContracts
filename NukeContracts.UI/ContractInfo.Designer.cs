namespace NukeContracts.UI
{
    partial class ContractInfo
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.lb_ContractName = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.lb_Price = new System.Windows.Forms.Label();
            this.lb_Volume = new System.Windows.Forms.Label();
            this.lb_date_issued = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(16, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(81, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Contract Name:";
            // 
            // lb_ContractName
            // 
            this.lb_ContractName.AutoSize = true;
            this.lb_ContractName.Location = new System.Drawing.Point(103, 15);
            this.lb_ContractName.Name = "lb_ContractName";
            this.lb_ContractName.Size = new System.Drawing.Size(32, 13);
            this.lb_ContractName.TabIndex = 1;
            this.lb_ContractName.Text = "xxxxx";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(16, 38);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(34, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Price:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(16, 61);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(42, 13);
            this.label3.TabIndex = 3;
            this.label3.Text = "Volume";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(16, 84);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(41, 13);
            this.label4.TabIndex = 4;
            this.label4.Text = "Issued:";
            // 
            // lb_Price
            // 
            this.lb_Price.AutoSize = true;
            this.lb_Price.Location = new System.Drawing.Point(57, 38);
            this.lb_Price.Name = "lb_Price";
            this.lb_Price.Size = new System.Drawing.Size(32, 13);
            this.lb_Price.TabIndex = 5;
            this.lb_Price.Text = "xxxxx";
            // 
            // lb_Volume
            // 
            this.lb_Volume.AutoSize = true;
            this.lb_Volume.Location = new System.Drawing.Point(65, 61);
            this.lb_Volume.Name = "lb_Volume";
            this.lb_Volume.Size = new System.Drawing.Size(32, 13);
            this.lb_Volume.TabIndex = 6;
            this.lb_Volume.Text = "xxxxx";
            // 
            // lb_date_issued
            // 
            this.lb_date_issued.AutoSize = true;
            this.lb_date_issued.Location = new System.Drawing.Point(64, 84);
            this.lb_date_issued.Name = "lb_date_issued";
            this.lb_date_issued.Size = new System.Drawing.Size(32, 13);
            this.lb_date_issued.TabIndex = 7;
            this.lb_date_issued.Text = "xxxxx";
            // 
            // ContractInfo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.lb_date_issued);
            this.Controls.Add(this.lb_Volume);
            this.Controls.Add(this.lb_Price);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.lb_ContractName);
            this.Controls.Add(this.label1);
            this.Name = "ContractInfo";
            this.Size = new System.Drawing.Size(1118, 603);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lb_ContractName;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label lb_Price;
        private System.Windows.Forms.Label lb_Volume;
        private System.Windows.Forms.Label lb_date_issued;
    }
}
