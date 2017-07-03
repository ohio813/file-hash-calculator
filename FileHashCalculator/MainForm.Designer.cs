namespace FileHashCalculator
{
    partial class MainForm
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
            this.generateHashesButton = new System.Windows.Forms.Button();
            this.fileTextBox = new System.Windows.Forms.TextBox();
            this.browseButton = new System.Windows.Forms.Button();
            this.hashProgressBar = new System.Windows.Forms.ProgressBar();
            this.hashListView = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.hashPercentageLabel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // generateHashesButton
            // 
            this.generateHashesButton.Location = new System.Drawing.Point(352, 40);
            this.generateHashesButton.Name = "generateHashesButton";
            this.generateHashesButton.Size = new System.Drawing.Size(88, 24);
            this.generateHashesButton.TabIndex = 0;
            this.generateHashesButton.Text = "Generate";
            this.generateHashesButton.UseVisualStyleBackColor = true;
            this.generateHashesButton.Click += new System.EventHandler(this.generateHashesButton_Click);
            // 
            // fileTextBox
            // 
            this.fileTextBox.Location = new System.Drawing.Point(8, 8);
            this.fileTextBox.Name = "fileTextBox";
            this.fileTextBox.ReadOnly = true;
            this.fileTextBox.Size = new System.Drawing.Size(336, 20);
            this.fileTextBox.TabIndex = 1;
            // 
            // browseButton
            // 
            this.browseButton.Location = new System.Drawing.Point(352, 8);
            this.browseButton.Name = "browseButton";
            this.browseButton.Size = new System.Drawing.Size(88, 24);
            this.browseButton.TabIndex = 2;
            this.browseButton.Text = "Browse";
            this.browseButton.UseVisualStyleBackColor = true;
            this.browseButton.Click += new System.EventHandler(this.browseButton_Click);
            // 
            // hashProgressBar
            // 
            this.hashProgressBar.Location = new System.Drawing.Point(8, 32);
            this.hashProgressBar.Name = "hashProgressBar";
            this.hashProgressBar.Size = new System.Drawing.Size(288, 16);
            this.hashProgressBar.TabIndex = 3;
            // 
            // hashListView
            // 
            this.hashListView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2});
            this.hashListView.FullRowSelect = true;
            this.hashListView.GridLines = true;
            this.hashListView.Location = new System.Drawing.Point(8, 72);
            this.hashListView.Name = "hashListView";
            this.hashListView.Size = new System.Drawing.Size(432, 248);
            this.hashListView.TabIndex = 4;
            this.hashListView.UseCompatibleStateImageBehavior = false;
            this.hashListView.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Algorithm";
            this.columnHeader1.Width = 73;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Hash";
            this.columnHeader2.Width = 327;
            // 
            // hashPercentageLabel
            // 
            this.hashPercentageLabel.AutoSize = true;
            this.hashPercentageLabel.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.hashPercentageLabel.Location = new System.Drawing.Point(304, 34);
            this.hashPercentageLabel.Name = "hashPercentageLabel";
            this.hashPercentageLabel.Size = new System.Drawing.Size(23, 15);
            this.hashPercentageLabel.TabIndex = 5;
            this.hashPercentageLabel.Text = "0%";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(449, 330);
            this.Controls.Add(this.hashPercentageLabel);
            this.Controls.Add(this.hashListView);
            this.Controls.Add(this.hashProgressBar);
            this.Controls.Add(this.browseButton);
            this.Controls.Add(this.fileTextBox);
            this.Controls.Add(this.generateHashesButton);
            this.Name = "MainForm";
            this.Text = "File Hash Generator";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button generateHashesButton;
        private System.Windows.Forms.TextBox fileTextBox;
        private System.Windows.Forms.Button browseButton;
        private System.Windows.Forms.ProgressBar hashProgressBar;
        private System.Windows.Forms.ListView hashListView;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.Label hashPercentageLabel;

    }
}

