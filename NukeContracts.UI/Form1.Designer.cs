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
            this.testText = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.textHeader = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // testText
            // 
            this.testText.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.testText.Location = new System.Drawing.Point(6, 77);
            this.testText.Margin = new System.Windows.Forms.Padding(2);
            this.testText.Multiline = true;
            this.testText.Name = "testText";
            this.testText.Size = new System.Drawing.Size(1379, 508);
            this.testText.TabIndex = 0;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(11, 589);
            this.button1.Margin = new System.Windows.Forms.Padding(2);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(134, 27);
            this.button1.TabIndex = 1;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // textHeader
            // 
            this.textHeader.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textHeader.Location = new System.Drawing.Point(6, 12);
            this.textHeader.Multiline = true;
            this.textHeader.Name = "textHeader";
            this.textHeader.Size = new System.Drawing.Size(1379, 60);
            this.textHeader.TabIndex = 2;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1396, 627);
            this.Controls.Add(this.textHeader);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.testText);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox testText;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox textHeader;
    }
}
