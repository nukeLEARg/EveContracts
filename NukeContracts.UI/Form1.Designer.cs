namespace NukeContracts.UI
{
    partial class Form1
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
            this.tv_MainView = new System.Windows.Forms.TreeView();
            this.pnl_InfoPane = new System.Windows.Forms.Panel();
            this.SuspendLayout();
            // 
            // tv_MainView
            // 
            this.tv_MainView.Location = new System.Drawing.Point(12, 12);
            this.tv_MainView.Name = "tv_MainView";
            this.tv_MainView.Size = new System.Drawing.Size(248, 603);
            this.tv_MainView.TabIndex = 0;
            this.tv_MainView.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.tv_Main_AfterSelect);
            // 
            // pnl_InfoPane
            // 
            this.pnl_InfoPane.Location = new System.Drawing.Point(266, 12);
            this.pnl_InfoPane.Name = "pnl_InfoPane";
            this.pnl_InfoPane.Size = new System.Drawing.Size(1118, 603);
            this.pnl_InfoPane.TabIndex = 1;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1396, 627);
            this.Controls.Add(this.pnl_InfoPane);
            this.Controls.Add(this.tv_MainView);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TreeView tv_MainView;
        private System.Windows.Forms.Panel pnl_InfoPane;
    }
}

