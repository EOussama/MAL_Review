namespace MAL_Reviewer_UI.forms.sub_forms
{
    partial class SettingsGeneralForm
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
            this.GeneralSettingsResetButton = new System.Windows.Forms.Button();
            this.contentPanel = new System.Windows.Forms.Panel();
            this.StoragePathBrowserControl = new MAL_Reviewer_UI.user_controls.PathBrowserControl();
            this.StorageLabel = new System.Windows.Forms.Label();
            this.linePanel = new System.Windows.Forms.Panel();
            this.titleLabel = new System.Windows.Forms.Label();
            this.contentPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // GeneralSettingsResetButton
            // 
            this.GeneralSettingsResetButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.GeneralSettingsResetButton.BackColor = System.Drawing.SystemColors.ScrollBar;
            this.GeneralSettingsResetButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.GeneralSettingsResetButton.FlatAppearance.BorderSize = 0;
            this.GeneralSettingsResetButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.GeneralSettingsResetButton.Font = new System.Drawing.Font("Bahnschrift Light", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.GeneralSettingsResetButton.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.GeneralSettingsResetButton.Location = new System.Drawing.Point(432, 12);
            this.GeneralSettingsResetButton.Name = "GeneralSettingsResetButton";
            this.GeneralSettingsResetButton.Size = new System.Drawing.Size(92, 33);
            this.GeneralSettingsResetButton.TabIndex = 31;
            this.GeneralSettingsResetButton.Text = "Reset all";
            this.GeneralSettingsResetButton.UseVisualStyleBackColor = false;
            this.GeneralSettingsResetButton.Click += new System.EventHandler(this.GeneralSettingsResetButton_Click);
            // 
            // contentPanel
            // 
            this.contentPanel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.contentPanel.AutoScroll = true;
            this.contentPanel.BackColor = System.Drawing.Color.Transparent;
            this.contentPanel.Controls.Add(this.StoragePathBrowserControl);
            this.contentPanel.Controls.Add(this.StorageLabel);
            this.contentPanel.Location = new System.Drawing.Point(12, 94);
            this.contentPanel.Name = "contentPanel";
            this.contentPanel.Size = new System.Drawing.Size(512, 366);
            this.contentPanel.TabIndex = 30;
            // 
            // StoragePathBrowserControl
            // 
            this.StoragePathBrowserControl.BackColor = System.Drawing.SystemColors.Control;
            this.StoragePathBrowserControl.BrowseOrOpen = false;
            this.StoragePathBrowserControl.BrowserPath = "";
            this.StoragePathBrowserControl.BrowserText = "Open";
            this.StoragePathBrowserControl.Location = new System.Drawing.Point(9, 26);
            this.StoragePathBrowserControl.MinimumSize = new System.Drawing.Size(275, 40);
            this.StoragePathBrowserControl.Name = "StoragePathBrowserControl";
            this.StoragePathBrowserControl.Size = new System.Drawing.Size(494, 40);
            this.StoragePathBrowserControl.TabIndex = 2;
            // 
            // StorageLabel
            // 
            this.StorageLabel.AutoSize = true;
            this.StorageLabel.Font = new System.Drawing.Font("Bahnschrift", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.StorageLabel.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.StorageLabel.Location = new System.Drawing.Point(4, 2);
            this.StorageLabel.Name = "StorageLabel";
            this.StorageLabel.Size = new System.Drawing.Size(102, 19);
            this.StorageLabel.TabIndex = 1;
            this.StorageLabel.Text = "Storage path";
            // 
            // linePanel
            // 
            this.linePanel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.linePanel.BackColor = System.Drawing.SystemColors.ScrollBar;
            this.linePanel.Location = new System.Drawing.Point(12, 51);
            this.linePanel.Name = "linePanel";
            this.linePanel.Size = new System.Drawing.Size(512, 5);
            this.linePanel.TabIndex = 29;
            // 
            // titleLabel
            // 
            this.titleLabel.AutoSize = true;
            this.titleLabel.Font = new System.Drawing.Font("Bahnschrift", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.titleLabel.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.titleLabel.Location = new System.Drawing.Point(12, 15);
            this.titleLabel.Name = "titleLabel";
            this.titleLabel.Size = new System.Drawing.Size(165, 25);
            this.titleLabel.TabIndex = 28;
            this.titleLabel.Text = "General settings";
            // 
            // SettingsGeneralForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlLight;
            this.ClientSize = new System.Drawing.Size(536, 473);
            this.Controls.Add(this.GeneralSettingsResetButton);
            this.Controls.Add(this.contentPanel);
            this.Controls.Add(this.linePanel);
            this.Controls.Add(this.titleLabel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "SettingsGeneralForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "General settings";
            this.contentPanel.ResumeLayout(false);
            this.contentPanel.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button GeneralSettingsResetButton;
        private System.Windows.Forms.Panel contentPanel;
        private System.Windows.Forms.Label StorageLabel;
        private System.Windows.Forms.Panel linePanel;
        private System.Windows.Forms.Label titleLabel;
        private user_controls.PathBrowserControl StoragePathBrowserControl;
    }
}