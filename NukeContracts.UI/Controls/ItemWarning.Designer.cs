namespace NukeContracts.UI.Controls
{
    partial class ItemWarning
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
            this.lb_Warning = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lb_Warning
            // 
            this.lb_Warning.AutoSize = true;
            this.lb_Warning.Location = new System.Drawing.Point(4, 18);
            this.lb_Warning.Name = "lb_Warning";
            this.lb_Warning.Size = new System.Drawing.Size(35, 13);
            this.lb_Warning.TabIndex = 0;
            this.lb_Warning.Text = "label1";
            // 
            // ItemWarning
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.lb_Warning);
            this.Name = "ItemWarning";
            this.Size = new System.Drawing.Size(400, 50);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lb_Warning;
    }
}
