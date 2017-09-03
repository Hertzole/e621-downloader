namespace E621MassDownloader
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.label1 = new System.Windows.Forms.Label();
            this.searchTagsBox = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.downloadDestBox = new System.Windows.Forms.TextBox();
            this.browseDownloadDestButton = new System.Windows.Forms.Button();
            this.downloadAmountLabel = new System.Windows.Forms.Label();
            this.downloadAmountBar = new System.Windows.Forms.TrackBar();
            this.startDownloadButton = new System.Windows.Forms.Button();
            this.animatedCheckBox = new System.Windows.Forms.CheckBox();
            this.downloadProgressBar = new System.Windows.Forms.ProgressBar();
            this.downloadingLabel = new System.Windows.Forms.Label();
            this.cancelDownloadButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.downloadAmountBar)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(68, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Search Tags";
            // 
            // searchTagsBox
            // 
            this.searchTagsBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.searchTagsBox.Location = new System.Drawing.Point(12, 25);
            this.searchTagsBox.Name = "searchTagsBox";
            this.searchTagsBox.Size = new System.Drawing.Size(320, 20);
            this.searchTagsBox.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 72);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(111, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Download Destination";
            // 
            // downloadDestBox
            // 
            this.downloadDestBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.downloadDestBox.Location = new System.Drawing.Point(12, 88);
            this.downloadDestBox.Name = "downloadDestBox";
            this.downloadDestBox.Size = new System.Drawing.Size(239, 20);
            this.downloadDestBox.TabIndex = 4;
            // 
            // browseDownloadDestButton
            // 
            this.browseDownloadDestButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.browseDownloadDestButton.Location = new System.Drawing.Point(257, 86);
            this.browseDownloadDestButton.Name = "browseDownloadDestButton";
            this.browseDownloadDestButton.Size = new System.Drawing.Size(75, 23);
            this.browseDownloadDestButton.TabIndex = 5;
            this.browseDownloadDestButton.Text = "Browse";
            this.browseDownloadDestButton.UseVisualStyleBackColor = true;
            this.browseDownloadDestButton.Click += new System.EventHandler(this.browseDownloadDestButton_Click);
            // 
            // downloadAmountLabel
            // 
            this.downloadAmountLabel.AutoSize = true;
            this.downloadAmountLabel.Location = new System.Drawing.Point(9, 111);
            this.downloadAmountLabel.Name = "downloadAmountLabel";
            this.downloadAmountLabel.Size = new System.Drawing.Size(58, 13);
            this.downloadAmountLabel.TabIndex = 6;
            this.downloadAmountLabel.Text = "Amount - 0";
            // 
            // downloadAmountBar
            // 
            this.downloadAmountBar.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.downloadAmountBar.Location = new System.Drawing.Point(12, 127);
            this.downloadAmountBar.Maximum = 100;
            this.downloadAmountBar.Minimum = 1;
            this.downloadAmountBar.Name = "downloadAmountBar";
            this.downloadAmountBar.Size = new System.Drawing.Size(320, 45);
            this.downloadAmountBar.TabIndex = 7;
            this.downloadAmountBar.TickStyle = System.Windows.Forms.TickStyle.Both;
            this.downloadAmountBar.Value = 1;
            // 
            // startDownloadButton
            // 
            this.startDownloadButton.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.startDownloadButton.Location = new System.Drawing.Point(12, 215);
            this.startDownloadButton.Name = "startDownloadButton";
            this.startDownloadButton.Size = new System.Drawing.Size(150, 23);
            this.startDownloadButton.TabIndex = 8;
            this.startDownloadButton.Text = "Start Downloading!";
            this.startDownloadButton.UseVisualStyleBackColor = true;
            this.startDownloadButton.Click += new System.EventHandler(this.startDownloadButton_Click);
            // 
            // animatedCheckBox
            // 
            this.animatedCheckBox.AutoSize = true;
            this.animatedCheckBox.Location = new System.Drawing.Point(15, 52);
            this.animatedCheckBox.Name = "animatedCheckBox";
            this.animatedCheckBox.Size = new System.Drawing.Size(76, 17);
            this.animatedCheckBox.TabIndex = 2;
            this.animatedCheckBox.Text = "Animated?";
            this.animatedCheckBox.UseVisualStyleBackColor = true;
            // 
            // downloadProgressBar
            // 
            this.downloadProgressBar.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.downloadProgressBar.Location = new System.Drawing.Point(12, 191);
            this.downloadProgressBar.Name = "downloadProgressBar";
            this.downloadProgressBar.Size = new System.Drawing.Size(320, 10);
            this.downloadProgressBar.Step = 0;
            this.downloadProgressBar.Style = System.Windows.Forms.ProgressBarStyle.Continuous;
            this.downloadProgressBar.TabIndex = 9;
            this.downloadProgressBar.Value = 50;
            // 
            // downloadingLabel
            // 
            this.downloadingLabel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.downloadingLabel.Location = new System.Drawing.Point(12, 175);
            this.downloadingLabel.Name = "downloadingLabel";
            this.downloadingLabel.Size = new System.Drawing.Size(320, 13);
            this.downloadingLabel.TabIndex = 10;
            this.downloadingLabel.Text = "Downloading nothing";
            // 
            // cancelDownloadButton
            // 
            this.cancelDownloadButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.cancelDownloadButton.Enabled = false;
            this.cancelDownloadButton.Location = new System.Drawing.Point(182, 215);
            this.cancelDownloadButton.Name = "cancelDownloadButton";
            this.cancelDownloadButton.Size = new System.Drawing.Size(150, 23);
            this.cancelDownloadButton.TabIndex = 11;
            this.cancelDownloadButton.Text = "Cancel Download";
            this.cancelDownloadButton.UseVisualStyleBackColor = true;
            this.cancelDownloadButton.Click += new System.EventHandler(this.cancelDownloadButton_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(344, 250);
            this.Controls.Add(this.cancelDownloadButton);
            this.Controls.Add(this.downloadingLabel);
            this.Controls.Add(this.downloadProgressBar);
            this.Controls.Add(this.animatedCheckBox);
            this.Controls.Add(this.startDownloadButton);
            this.Controls.Add(this.downloadAmountBar);
            this.Controls.Add(this.downloadAmountLabel);
            this.Controls.Add(this.browseDownloadDestButton);
            this.Controls.Add(this.downloadDestBox);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.searchTagsBox);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "E621 Downloader";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.OnFormClosing);
            ((System.ComponentModel.ISupportInitialize)(this.downloadAmountBar)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox searchTagsBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox downloadDestBox;
        private System.Windows.Forms.Button browseDownloadDestButton;
        private System.Windows.Forms.Label downloadAmountLabel;
        private System.Windows.Forms.TrackBar downloadAmountBar;
        private System.Windows.Forms.Button startDownloadButton;
        private System.Windows.Forms.CheckBox animatedCheckBox;
        private System.Windows.Forms.ProgressBar downloadProgressBar;
        private System.Windows.Forms.Label downloadingLabel;
        private System.Windows.Forms.Button cancelDownloadButton;
    }
}

