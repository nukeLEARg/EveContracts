namespace NukeContracts.UI
{
    partial class ItemPanel
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
            this.pb_Icon = new System.Windows.Forms.PictureBox();
            this.lb_ItemName = new System.Windows.Forms.Label();
            this.lb_Amount = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pb_Icon)).BeginInit();
            this.SuspendLayout();
            // 
            // pb_Icon
            // 
            this.pb_Icon.Location = new System.Drawing.Point(0, 0);
            this.pb_Icon.Name = "pb_Icon";
            this.pb_Icon.Size = new System.Drawing.Size(50, 50);
            this.pb_Icon.TabIndex = 0;
            this.pb_Icon.TabStop = false;
            // 
            // lb_ItemName
            // 
            this.lb_ItemName.AutoSize = true;
            this.lb_ItemName.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lb_ItemName.Location = new System.Drawing.Point(54, 7);
            this.lb_ItemName.Name = "lb_ItemName";
            this.lb_ItemName.Size = new System.Drawing.Size(87, 20);
            this.lb_ItemName.TabIndex = 1;
            this.lb_ItemName.Text = "Item Name";
            // 
            // lb_Amount
            // 
            this.lb_Amount.AutoSize = true;
            this.lb_Amount.Location = new System.Drawing.Point(58, 31);
            this.lb_Amount.Name = "lb_Amount";
            this.lb_Amount.Size = new System.Drawing.Size(33, 13);
            this.lb_Amount.TabIndex = 2;
            this.lb_Amount.Text = "xXXX";
            // 
            // ItemPanel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.lb_Amount);
            this.Controls.Add(this.lb_ItemName);
            this.Controls.Add(this.pb_Icon);
            this.Name = "ItemPanel";
            this.Size = new System.Drawing.Size(400, 50);
            ((System.ComponentModel.ISupportInitialize)(this.pb_Icon)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pb_Icon;
        private System.Windows.Forms.Label lb_ItemName;
        private System.Windows.Forms.Label lb_Amount;
    }
}
