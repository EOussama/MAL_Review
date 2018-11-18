namespace MAL_Reviewer_UI.forms
{
    partial class SettingsForm
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SettingsForm));
            this.sidePanel = new System.Windows.Forms.Panel();
            this.infoButton = new System.Windows.Forms.Button();
            this.sizeControlImageList = new System.Windows.Forms.ImageList(this.components);
            this.searchButton = new System.Windows.Forms.Button();
            this.templateButton = new System.Windows.Forms.Button();
            this.themeButton = new System.Windows.Forms.Button();
            this.userButton = new System.Windows.Forms.Button();
            this.contentPanel = new System.Windows.Forms.Panel();
            this.extraInfo = new System.Windows.Forms.ToolTip(this.components);
            this.sidePanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // sidePanel
            // 
            this.sidePanel.BackColor = System.Drawing.SystemColors.Control;
            this.sidePanel.Controls.Add(this.infoButton);
            this.sidePanel.Controls.Add(this.searchButton);
            this.sidePanel.Controls.Add(this.templateButton);
            this.sidePanel.Controls.Add(this.themeButton);
            this.sidePanel.Controls.Add(this.userButton);
            this.sidePanel.Dock = System.Windows.Forms.DockStyle.Left;
            this.sidePanel.Location = new System.Drawing.Point(0, 0);
            this.sidePanel.Name = "sidePanel";
            this.sidePanel.Size = new System.Drawing.Size(75, 473);
            this.sidePanel.TabIndex = 0;
            // 
            // infoButton
            // 
            this.infoButton.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.infoButton.BackColor = System.Drawing.Color.Transparent;
            this.infoButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.infoButton.FlatAppearance.BorderSize = 0;
            this.infoButton.FlatAppearance.MouseDownBackColor = System.Drawing.Color.LightGray;
            this.infoButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Gainsboro;
            this.infoButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.infoButton.ImageIndex = 2;
            this.infoButton.ImageList = this.sizeControlImageList;
            this.infoButton.Location = new System.Drawing.Point(3, 275);
            this.infoButton.Name = "infoButton";
            this.infoButton.Size = new System.Drawing.Size(69, 67);
            this.infoButton.TabIndex = 8;
            this.extraInfo.SetToolTip(this.infoButton, "About");
            this.infoButton.UseVisualStyleBackColor = false;
            this.infoButton.Click += new System.EventHandler(this.InfoButton_Click);
            // 
            // sizeControlImageList
            // 
            this.sizeControlImageList.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("sizeControlImageList.ImageStream")));
            this.sizeControlImageList.TransparentColor = System.Drawing.SystemColors.ControlLight;
            this.sizeControlImageList.Images.SetKeyName(0, "icon-user.png");
            this.sizeControlImageList.Images.SetKeyName(1, "icon_search.png");
            this.sizeControlImageList.Images.SetKeyName(2, "icon_info.png");
            this.sizeControlImageList.Images.SetKeyName(3, "icon_template.png");
            this.sizeControlImageList.Images.SetKeyName(4, "icon_theme.png");
            // 
            // searchButton
            // 
            this.searchButton.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.searchButton.BackColor = System.Drawing.Color.Transparent;
            this.searchButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.searchButton.FlatAppearance.BorderSize = 0;
            this.searchButton.FlatAppearance.MouseDownBackColor = System.Drawing.Color.LightGray;
            this.searchButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Gainsboro;
            this.searchButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.searchButton.ImageIndex = 1;
            this.searchButton.ImageList = this.sizeControlImageList;
            this.searchButton.Location = new System.Drawing.Point(3, 207);
            this.searchButton.Name = "searchButton";
            this.searchButton.Size = new System.Drawing.Size(69, 67);
            this.searchButton.TabIndex = 7;
            this.extraInfo.SetToolTip(this.searchButton, "Search settings");
            this.searchButton.UseVisualStyleBackColor = false;
            this.searchButton.Click += new System.EventHandler(this.SearchButton_Click);
            // 
            // templateButton
            // 
            this.templateButton.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.templateButton.BackColor = System.Drawing.Color.Transparent;
            this.templateButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.templateButton.FlatAppearance.BorderSize = 0;
            this.templateButton.FlatAppearance.MouseDownBackColor = System.Drawing.Color.LightGray;
            this.templateButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Gainsboro;
            this.templateButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.templateButton.ImageIndex = 3;
            this.templateButton.ImageList = this.sizeControlImageList;
            this.templateButton.Location = new System.Drawing.Point(3, 139);
            this.templateButton.Name = "templateButton";
            this.templateButton.Size = new System.Drawing.Size(69, 67);
            this.templateButton.TabIndex = 6;
            this.extraInfo.SetToolTip(this.templateButton, "Review templates settings");
            this.templateButton.UseVisualStyleBackColor = false;
            this.templateButton.Click += new System.EventHandler(this.TemplateButton_Click);
            // 
            // themeButton
            // 
            this.themeButton.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.themeButton.BackColor = System.Drawing.Color.Transparent;
            this.themeButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.themeButton.FlatAppearance.BorderSize = 0;
            this.themeButton.FlatAppearance.MouseDownBackColor = System.Drawing.Color.LightGray;
            this.themeButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Gainsboro;
            this.themeButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.themeButton.ImageIndex = 4;
            this.themeButton.ImageList = this.sizeControlImageList;
            this.themeButton.Location = new System.Drawing.Point(3, 71);
            this.themeButton.Name = "themeButton";
            this.themeButton.Size = new System.Drawing.Size(69, 67);
            this.themeButton.TabIndex = 5;
            this.extraInfo.SetToolTip(this.themeButton, "Theme settings");
            this.themeButton.UseVisualStyleBackColor = false;
            this.themeButton.Click += new System.EventHandler(this.ThemeButton_Click);
            // 
            // userButton
            // 
            this.userButton.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.userButton.BackColor = System.Drawing.Color.Transparent;
            this.userButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.userButton.FlatAppearance.BorderSize = 0;
            this.userButton.FlatAppearance.MouseDownBackColor = System.Drawing.Color.LightGray;
            this.userButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Gainsboro;
            this.userButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.userButton.ImageIndex = 0;
            this.userButton.ImageList = this.sizeControlImageList;
            this.userButton.Location = new System.Drawing.Point(3, 3);
            this.userButton.Name = "userButton";
            this.userButton.Size = new System.Drawing.Size(69, 67);
            this.userButton.TabIndex = 4;
            this.extraInfo.SetToolTip(this.userButton, "User settings");
            this.userButton.UseVisualStyleBackColor = false;
            this.userButton.Click += new System.EventHandler(this.UserButton_Click);
            // 
            // contentPanel
            // 
            this.contentPanel.BackColor = System.Drawing.SystemColors.ControlLight;
            this.contentPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.contentPanel.Location = new System.Drawing.Point(75, 0);
            this.contentPanel.Name = "contentPanel";
            this.contentPanel.Padding = new System.Windows.Forms.Padding(30, 0, 30, 0);
            this.contentPanel.Size = new System.Drawing.Size(600, 473);
            this.contentPanel.TabIndex = 1;
            // 
            // SettingsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(675, 473);
            this.Controls.Add(this.contentPanel);
            this.Controls.Add(this.sidePanel);
            this.Font = new System.Drawing.Font("Bahnschrift Light", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "SettingsForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Settings";
            this.sidePanel.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel sidePanel;
        private System.Windows.Forms.Button searchButton;
        private System.Windows.Forms.Button templateButton;
        private System.Windows.Forms.Button themeButton;
        private System.Windows.Forms.Button userButton;
        private System.Windows.Forms.ImageList sizeControlImageList;
        private System.Windows.Forms.Button infoButton;
        private System.Windows.Forms.Panel contentPanel;
        private System.Windows.Forms.ToolTip extraInfo;
    }
}