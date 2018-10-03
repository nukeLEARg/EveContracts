namespace NukeContracts.UI.Controls
{
    partial class ItemDetails
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
            this.label2 = new System.Windows.Forms.Label();
            this.lb_itemID = new System.Windows.Forms.Label();
            this.lb_typeID = new System.Windows.Forms.Label();
            this.lb_TYPE = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(4, 4);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(44, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Item ID:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(3, 28);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(48, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Type ID:";
            // 
            // lb_itemID
            // 
            this.lb_itemID.AutoSize = true;
            this.lb_itemID.Location = new System.Drawing.Point(55, 4);
            this.lb_itemID.Name = "lb_itemID";
            this.lb_itemID.Size = new System.Drawing.Size(22, 13);
            this.lb_itemID.TabIndex = 2;
            this.lb_itemID.Text = "xxx";
            // 
            // lb_typeID
            // 
            this.lb_typeID.AutoSize = true;
            this.lb_typeID.Location = new System.Drawing.Point(58, 28);
            this.lb_typeID.Name = "lb_typeID";
            this.lb_typeID.Size = new System.Drawing.Size(22, 13);
            this.lb_typeID.TabIndex = 3;
            this.lb_typeID.Text = "xxx";
            // 
            // lb_TYPE
            // 
            this.lb_TYPE.Location = new System.Drawing.Point(7, 65);
            this.lb_TYPE.Name = "lb_TYPE";
            this.lb_TYPE.Size = new System.Drawing.Size(304, 414);
            this.lb_TYPE.TabIndex = 4;
            this.lb_TYPE.Text = "label3";
            // 
            // ItemDetails
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.lb_TYPE);
            this.Controls.Add(this.lb_typeID);
            this.Controls.Add(this.lb_itemID);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "ItemDetails";
            this.Size = new System.Drawing.Size(314, 493);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lb_itemID;
        private System.Windows.Forms.Label lb_typeID;
        private System.Windows.Forms.Label lb_TYPE;
    }
}
