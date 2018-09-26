namespace NukeContracts.UI
{
    partial class ContractBrowser
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
            this.button1 = new System.Windows.Forms.Button();
            this.dd_region = new System.Windows.Forms.ComboBox();
            this.lb_Pages = new System.Windows.Forms.Label();
            this.pb_APIBar = new System.Windows.Forms.ProgressBar();
            this.lb_progress = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // tv_MainView
            // 
            this.tv_MainView.Location = new System.Drawing.Point(12, 12);
            this.tv_MainView.Name = "tv_MainView";
            this.tv_MainView.Size = new System.Drawing.Size(248, 500);
            this.tv_MainView.TabIndex = 0;
            this.tv_MainView.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.tv_Main_AfterSelect);
            // 
            // pnl_InfoPane
            // 
            this.pnl_InfoPane.Location = new System.Drawing.Point(266, 12);
            this.pnl_InfoPane.Name = "pnl_InfoPane";
            this.pnl_InfoPane.Size = new System.Drawing.Size(1000, 500);
            this.pnl_InfoPane.TabIndex = 1;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(13, 545);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(133, 23);
            this.button1.TabIndex = 2;
            this.button1.Text = "Load";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // dd_region
            // 
            this.dd_region.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.dd_region.FormattingEnabled = true;
            this.dd_region.Items.AddRange(new object[] {
            "Select Region"});
            this.dd_region.Location = new System.Drawing.Point(13, 518);
            this.dd_region.Name = "dd_region";
            this.dd_region.Size = new System.Drawing.Size(247, 21);
            this.dd_region.TabIndex = 3;
            // 
            // lb_Pages
            // 
            this.lb_Pages.AutoSize = true;
            this.lb_Pages.Location = new System.Drawing.Point(152, 550);
            this.lb_Pages.Name = "lb_Pages";
            this.lb_Pages.Size = new System.Drawing.Size(43, 13);
            this.lb_Pages.TabIndex = 0;
            this.lb_Pages.Text = "Pages: ";
            // 
            // pb_APIBar
            // 
            this.pb_APIBar.Location = new System.Drawing.Point(266, 519);
            this.pb_APIBar.Name = "pb_APIBar";
            this.pb_APIBar.Size = new System.Drawing.Size(996, 23);
            this.pb_APIBar.TabIndex = 4;
            // 
            // lb_progress
            // 
            this.lb_progress.BackColor = System.Drawing.Color.Transparent;
            this.lb_progress.Location = new System.Drawing.Point(266, 546);
            this.lb_progress.Name = "lb_progress";
            this.lb_progress.Size = new System.Drawing.Size(996, 12);
            this.lb_progress.TabIndex = 5;
            this.lb_progress.Text = "label1";
            this.lb_progress.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // ContractBrowser
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1274, 576);
            this.Controls.Add(this.lb_Pages);
            this.Controls.Add(this.lb_progress);
            this.Controls.Add(this.pb_APIBar);
            this.Controls.Add(this.dd_region);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.pnl_InfoPane);
            this.Controls.Add(this.tv_MainView);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "ContractBrowser";
            this.Text = "Contract Browser";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TreeView tv_MainView;
        private System.Windows.Forms.Panel pnl_InfoPane;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.ComboBox dd_region;
        private System.Windows.Forms.Label lb_Pages;
        private System.Windows.Forms.ProgressBar pb_APIBar;
        private System.Windows.Forms.Label lb_progress;
    }
}

