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
            this.pnl_InfoPane = new System.Windows.Forms.Panel();
            this.btn_LoadRegion = new System.Windows.Forms.Button();
            this.cbo_Region = new System.Windows.Forms.ComboBox();
            this.lb_Pages = new System.Windows.Forms.Label();
            this.pb_APIBar = new System.Windows.Forms.ProgressBar();
            this.lbl_progress = new System.Windows.Forms.Label();
            this.pnl_ContractWindow = new System.Windows.Forms.Panel();
            this.btn_NextPage = new System.Windows.Forms.Button();
            this.btn_PrevPage = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // pnl_InfoPane
            // 
            this.pnl_InfoPane.Location = new System.Drawing.Point(266, 12);
            this.pnl_InfoPane.Name = "pnl_InfoPane";
            this.pnl_InfoPane.Size = new System.Drawing.Size(1000, 500);
            this.pnl_InfoPane.TabIndex = 1;
            // 
            // btn_LoadRegion
            // 
            this.btn_LoadRegion.Location = new System.Drawing.Point(13, 545);
            this.btn_LoadRegion.Name = "btn_LoadRegion";
            this.btn_LoadRegion.Size = new System.Drawing.Size(133, 23);
            this.btn_LoadRegion.TabIndex = 2;
            this.btn_LoadRegion.Text = "Load";
            this.btn_LoadRegion.UseVisualStyleBackColor = true;
            this.btn_LoadRegion.Click += new System.EventHandler(this.Btn_LoadRegion_Click);
            // 
            // cbo_Region
            // 
            this.cbo_Region.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbo_Region.FormattingEnabled = true;
            this.cbo_Region.Items.AddRange(new object[] {
            "Select Region"});
            this.cbo_Region.Location = new System.Drawing.Point(13, 518);
            this.cbo_Region.Name = "cbo_Region";
            this.cbo_Region.Size = new System.Drawing.Size(247, 21);
            this.cbo_Region.TabIndex = 3;
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
            this.pb_APIBar.Step = 1;
            this.pb_APIBar.TabIndex = 4;
            this.pb_APIBar.Visible = false;
            // 
            // lbl_progress
            // 
            this.lbl_progress.BackColor = System.Drawing.Color.Transparent;
            this.lbl_progress.Location = new System.Drawing.Point(266, 546);
            this.lbl_progress.Name = "lbl_progress";
            this.lbl_progress.Size = new System.Drawing.Size(996, 12);
            this.lbl_progress.TabIndex = 5;
            this.lbl_progress.Text = "0/0";
            this.lbl_progress.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.lbl_progress.Visible = false;
            // 
            // pnl_ContractWindow
            // 
            this.pnl_ContractWindow.AutoScroll = true;
            this.pnl_ContractWindow.Location = new System.Drawing.Point(13, 12);
            this.pnl_ContractWindow.Name = "pnl_ContractWindow";
            this.pnl_ContractWindow.Size = new System.Drawing.Size(247, 500);
            this.pnl_ContractWindow.TabIndex = 16;
            // 
            // btn_NextPage
            // 
            this.btn_NextPage.Location = new System.Drawing.Point(341, 546);
            this.btn_NextPage.Name = "btn_NextPage";
            this.btn_NextPage.Size = new System.Drawing.Size(84, 23);
            this.btn_NextPage.TabIndex = 17;
            this.btn_NextPage.Text = "Next Page";
            this.btn_NextPage.UseVisualStyleBackColor = true;
            this.btn_NextPage.Click += new System.EventHandler(this.btn_NextPage_Click);
            // 
            // btn_PrevPage
            // 
            this.btn_PrevPage.Location = new System.Drawing.Point(251, 546);
            this.btn_PrevPage.Name = "btn_PrevPage";
            this.btn_PrevPage.Size = new System.Drawing.Size(84, 23);
            this.btn_PrevPage.TabIndex = 18;
            this.btn_PrevPage.Text = "Previous Page";
            this.btn_PrevPage.UseVisualStyleBackColor = true;
            this.btn_PrevPage.Click += new System.EventHandler(this.btn_PrevPage_Click);
            // 
            // ContractBrowser
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1274, 573);
            this.Controls.Add(this.btn_PrevPage);
            this.Controls.Add(this.btn_NextPage);
            this.Controls.Add(this.pnl_ContractWindow);
            this.Controls.Add(this.lb_Pages);
            this.Controls.Add(this.lbl_progress);
            this.Controls.Add(this.pb_APIBar);
            this.Controls.Add(this.cbo_Region);
            this.Controls.Add(this.btn_LoadRegion);
            this.Controls.Add(this.pnl_InfoPane);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "ContractBrowser";
            this.Text = "Contract Browser";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Panel pnl_InfoPane;
        private System.Windows.Forms.Button btn_LoadRegion;
        private System.Windows.Forms.ComboBox cbo_Region;
        private System.Windows.Forms.Label lb_Pages;
        private System.Windows.Forms.ProgressBar pb_APIBar;
        private System.Windows.Forms.Label lbl_progress;
        private System.Windows.Forms.Panel pnl_ContractWindow;
        private System.Windows.Forms.Button btn_NextPage;
        private System.Windows.Forms.Button btn_PrevPage;
    }
}

