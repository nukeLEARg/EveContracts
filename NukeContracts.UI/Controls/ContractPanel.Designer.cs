namespace NukeContracts.UI.Controls
{
    partial class ContractPanel
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
            this.lb_Amount = new System.Windows.Forms.Label();
            this.lb_ContractName = new System.Windows.Forms.Label();
            this.pb_Icon = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pb_Icon)).BeginInit();
            this.SuspendLayout();
            // 
            // lb_Amount
            // 
            this.lb_Amount.AutoSize = true;
            this.lb_Amount.Location = new System.Drawing.Point(48, 24);
            this.lb_Amount.Name = "lb_Amount";
            this.lb_Amount.Size = new System.Drawing.Size(33, 13);
            this.lb_Amount.TabIndex = 5;
            this.lb_Amount.Text = "xXXX";
            // 
            // lb_ContractName
            // 
            this.lb_ContractName.AutoSize = true;
            this.lb_ContractName.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.lb_ContractName.Location = new System.Drawing.Point(44, 3);
            this.lb_ContractName.Name = "lb_ContractName";
            this.lb_ContractName.Size = new System.Drawing.Size(92, 17);
            this.lb_ContractName.TabIndex = 4;
            this.lb_ContractName.Text = "Contract Title";
            // 
            // pb_Icon
            // 
            this.pb_Icon.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.pb_Icon.Location = new System.Drawing.Point(0, 0);
            this.pb_Icon.Name = "pb_Icon";
            this.pb_Icon.Size = new System.Drawing.Size(40, 40);
            this.pb_Icon.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pb_Icon.TabIndex = 3;
            this.pb_Icon.TabStop = false;
            // 
            // ContractPanel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.lb_Amount);
            this.Controls.Add(this.lb_ContractName);
            this.Controls.Add(this.pb_Icon);
            this.Name = "ContractPanel";
            this.Size = new System.Drawing.Size(230, 40);
            ((System.ComponentModel.ISupportInitialize)(this.pb_Icon)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lb_Amount;
        private System.Windows.Forms.Label lb_ContractName;
        private System.Windows.Forms.PictureBox pb_Icon;
    }
}
