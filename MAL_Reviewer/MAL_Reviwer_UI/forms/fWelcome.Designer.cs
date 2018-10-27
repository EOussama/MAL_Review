namespace MAL_Reviwer_UI.forms
{
    partial class fWelcome
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(fWelcome));
            this.pSide = new System.Windows.Forms.Panel();
            this.pReviews = new System.Windows.Forms.Panel();
            this.pUser = new System.Windows.Forms.Panel();
            this.bUser = new System.Windows.Forms.Button();
            this.ilSizeControl = new System.Windows.Forms.ImageList(this.components);
            this.pReviewLookUp = new System.Windows.Forms.Panel();
            this.pbSearch = new System.Windows.Forms.PictureBox();
            this.tbSearch = new System.Windows.Forms.TextBox();
            this.pButtons = new System.Windows.Forms.Panel();
            this.bClear = new System.Windows.Forms.Button();
            this.bOpen = new System.Windows.Forms.Button();
            this.bNew = new System.Windows.Forms.Button();
            this.pMain = new System.Windows.Forms.Panel();
            this.pHeader = new System.Windows.Forms.Panel();
            this.lTitle = new System.Windows.Forms.Label();
            this.pbLogo = new System.Windows.Forms.PictureBox();
            this.bSettings = new System.Windows.Forms.Button();
            this.lVersion = new System.Windows.Forms.Label();
            this.pDashboard = new System.Windows.Forms.Panel();
            this.tpMangalist = new System.Windows.Forms.TabPage();
            this.tpAnimelist = new System.Windows.Forms.TabPage();
            this.tpStatistics = new System.Windows.Forms.TabPage();
            this.tcDashboard = new System.Windows.Forms.TabControl();
            this.pSide.SuspendLayout();
            this.pUser.SuspendLayout();
            this.pReviewLookUp.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbSearch)).BeginInit();
            this.pButtons.SuspendLayout();
            this.pMain.SuspendLayout();
            this.pHeader.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbLogo)).BeginInit();
            this.pDashboard.SuspendLayout();
            this.tcDashboard.SuspendLayout();
            this.SuspendLayout();
            // 
            // pSide
            // 
            this.pSide.BackColor = System.Drawing.SystemColors.ControlLight;
            this.pSide.Controls.Add(this.pReviews);
            this.pSide.Controls.Add(this.pUser);
            this.pSide.Controls.Add(this.pReviewLookUp);
            this.pSide.Controls.Add(this.pButtons);
            this.pSide.Dock = System.Windows.Forms.DockStyle.Left;
            this.pSide.Location = new System.Drawing.Point(0, 0);
            this.pSide.Name = "pSide";
            this.pSide.Size = new System.Drawing.Size(230, 581);
            this.pSide.TabIndex = 0;
            // 
            // pReviews
            // 
            this.pReviews.AutoScroll = true;
            this.pReviews.BackColor = System.Drawing.Color.Transparent;
            this.pReviews.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pReviews.Location = new System.Drawing.Point(0, 108);
            this.pReviews.Name = "pReviews";
            this.pReviews.Size = new System.Drawing.Size(230, 400);
            this.pReviews.TabIndex = 2;
            // 
            // pUser
            // 
            this.pUser.Controls.Add(this.bUser);
            this.pUser.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pUser.Location = new System.Drawing.Point(0, 508);
            this.pUser.Name = "pUser";
            this.pUser.Size = new System.Drawing.Size(230, 73);
            this.pUser.TabIndex = 7;
            // 
            // bUser
            // 
            this.bUser.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.bUser.BackColor = System.Drawing.Color.Transparent;
            this.bUser.Cursor = System.Windows.Forms.Cursors.Hand;
            this.bUser.FlatAppearance.BorderSize = 0;
            this.bUser.FlatAppearance.MouseDownBackColor = System.Drawing.Color.LightGray;
            this.bUser.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Gainsboro;
            this.bUser.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.bUser.Font = new System.Drawing.Font("Bahnschrift", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bUser.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.bUser.ImageIndex = 4;
            this.bUser.ImageList = this.ilSizeControl;
            this.bUser.Location = new System.Drawing.Point(3, 3);
            this.bUser.Name = "bUser";
            this.bUser.Size = new System.Drawing.Size(224, 67);
            this.bUser.TabIndex = 7;
            this.bUser.Text = "Username";
            this.bUser.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.bUser.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage;
            this.bUser.UseVisualStyleBackColor = false;
            // 
            // ilSizeControl
            // 
            this.ilSizeControl.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("ilSizeControl.ImageStream")));
            this.ilSizeControl.TransparentColor = System.Drawing.SystemColors.ControlLight;
            this.ilSizeControl.Images.SetKeyName(0, "icon-add.png");
            this.ilSizeControl.Images.SetKeyName(1, "icon-open.png");
            this.ilSizeControl.Images.SetKeyName(2, "icon-delete.png");
            this.ilSizeControl.Images.SetKeyName(3, "icon-settings.png");
            this.ilSizeControl.Images.SetKeyName(4, "icon-user.png");
            // 
            // pReviewLookUp
            // 
            this.pReviewLookUp.BackColor = System.Drawing.SystemColors.ScrollBar;
            this.pReviewLookUp.Controls.Add(this.pbSearch);
            this.pReviewLookUp.Controls.Add(this.tbSearch);
            this.pReviewLookUp.Dock = System.Windows.Forms.DockStyle.Top;
            this.pReviewLookUp.Location = new System.Drawing.Point(0, 73);
            this.pReviewLookUp.Name = "pReviewLookUp";
            this.pReviewLookUp.Size = new System.Drawing.Size(230, 35);
            this.pReviewLookUp.TabIndex = 2;
            // 
            // pbSearch
            // 
            this.pbSearch.Image = global::MAL_Reviwer_UI.Properties.Resources.icon_search;
            this.pbSearch.Location = new System.Drawing.Point(204, 7);
            this.pbSearch.Name = "pbSearch";
            this.pbSearch.Size = new System.Drawing.Size(20, 20);
            this.pbSearch.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pbSearch.TabIndex = 1;
            this.pbSearch.TabStop = false;
            // 
            // tbSearch
            // 
            this.tbSearch.BackColor = System.Drawing.SystemColors.ScrollBar;
            this.tbSearch.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.tbSearch.Font = new System.Drawing.Font("Bahnschrift Light", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbSearch.Location = new System.Drawing.Point(9, 7);
            this.tbSearch.Name = "tbSearch";
            this.tbSearch.Size = new System.Drawing.Size(188, 20);
            this.tbSearch.TabIndex = 0;
            // 
            // pButtons
            // 
            this.pButtons.BackColor = System.Drawing.Color.Transparent;
            this.pButtons.Controls.Add(this.bClear);
            this.pButtons.Controls.Add(this.bOpen);
            this.pButtons.Controls.Add(this.bNew);
            this.pButtons.Dock = System.Windows.Forms.DockStyle.Top;
            this.pButtons.Location = new System.Drawing.Point(0, 0);
            this.pButtons.Name = "pButtons";
            this.pButtons.Size = new System.Drawing.Size(230, 73);
            this.pButtons.TabIndex = 2;
            // 
            // bClear
            // 
            this.bClear.BackColor = System.Drawing.Color.Transparent;
            this.bClear.Cursor = System.Windows.Forms.Cursors.Hand;
            this.bClear.FlatAppearance.BorderSize = 0;
            this.bClear.FlatAppearance.MouseDownBackColor = System.Drawing.Color.LightGray;
            this.bClear.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Gainsboro;
            this.bClear.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.bClear.ImageIndex = 2;
            this.bClear.ImageList = this.ilSizeControl;
            this.bClear.Location = new System.Drawing.Point(152, 3);
            this.bClear.Name = "bClear";
            this.bClear.Size = new System.Drawing.Size(75, 67);
            this.bClear.TabIndex = 5;
            this.bClear.UseVisualStyleBackColor = false;
            // 
            // bOpen
            // 
            this.bOpen.BackColor = System.Drawing.Color.Transparent;
            this.bOpen.Cursor = System.Windows.Forms.Cursors.Hand;
            this.bOpen.FlatAppearance.BorderSize = 0;
            this.bOpen.FlatAppearance.MouseDownBackColor = System.Drawing.Color.LightGray;
            this.bOpen.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Gainsboro;
            this.bOpen.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.bOpen.ImageIndex = 1;
            this.bOpen.ImageList = this.ilSizeControl;
            this.bOpen.Location = new System.Drawing.Point(77, 3);
            this.bOpen.Name = "bOpen";
            this.bOpen.Size = new System.Drawing.Size(75, 67);
            this.bOpen.TabIndex = 4;
            this.bOpen.UseVisualStyleBackColor = false;
            // 
            // bNew
            // 
            this.bNew.BackColor = System.Drawing.Color.Transparent;
            this.bNew.Cursor = System.Windows.Forms.Cursors.Hand;
            this.bNew.FlatAppearance.BorderSize = 0;
            this.bNew.FlatAppearance.MouseDownBackColor = System.Drawing.Color.LightGray;
            this.bNew.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Gainsboro;
            this.bNew.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.bNew.ImageIndex = 0;
            this.bNew.ImageList = this.ilSizeControl;
            this.bNew.Location = new System.Drawing.Point(3, 3);
            this.bNew.Name = "bNew";
            this.bNew.Size = new System.Drawing.Size(74, 67);
            this.bNew.TabIndex = 3;
            this.bNew.UseVisualStyleBackColor = false;
            this.bNew.Click += new System.EventHandler(this.bNew_Click);
            // 
            // pMain
            // 
            this.pMain.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pMain.BackColor = System.Drawing.SystemColors.Control;
            this.pMain.Controls.Add(this.pDashboard);
            this.pMain.Controls.Add(this.pHeader);
            this.pMain.Location = new System.Drawing.Point(231, 0);
            this.pMain.Name = "pMain";
            this.pMain.Size = new System.Drawing.Size(753, 581);
            this.pMain.TabIndex = 1;
            // 
            // pHeader
            // 
            this.pHeader.BackColor = System.Drawing.SystemColors.Control;
            this.pHeader.Controls.Add(this.lVersion);
            this.pHeader.Controls.Add(this.bSettings);
            this.pHeader.Controls.Add(this.lTitle);
            this.pHeader.Controls.Add(this.pbLogo);
            this.pHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.pHeader.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.pHeader.Location = new System.Drawing.Point(0, 0);
            this.pHeader.Name = "pHeader";
            this.pHeader.Size = new System.Drawing.Size(753, 232);
            this.pHeader.TabIndex = 1;
            // 
            // lTitle
            // 
            this.lTitle.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.lTitle.Font = new System.Drawing.Font("Bahnschrift Light", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lTitle.Location = new System.Drawing.Point(0, 190);
            this.lTitle.Name = "lTitle";
            this.lTitle.Size = new System.Drawing.Size(753, 42);
            this.lTitle.TabIndex = 2;
            this.lTitle.Text = "MAL Reviewer";
            this.lTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // pbLogo
            // 
            this.pbLogo.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pbLogo.Image = global::MAL_Reviwer_UI.Properties.Resources.logo;
            this.pbLogo.Location = new System.Drawing.Point(9, 10);
            this.pbLogo.Name = "pbLogo";
            this.pbLogo.Size = new System.Drawing.Size(734, 152);
            this.pbLogo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pbLogo.TabIndex = 0;
            this.pbLogo.TabStop = false;
            // 
            // bSettings
            // 
            this.bSettings.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.bSettings.BackColor = System.Drawing.Color.Transparent;
            this.bSettings.Cursor = System.Windows.Forms.Cursors.Hand;
            this.bSettings.FlatAppearance.BorderSize = 0;
            this.bSettings.FlatAppearance.MouseDownBackColor = System.Drawing.Color.White;
            this.bSettings.FlatAppearance.MouseOverBackColor = System.Drawing.Color.WhiteSmoke;
            this.bSettings.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.bSettings.ImageIndex = 3;
            this.bSettings.ImageList = this.ilSizeControl;
            this.bSettings.Location = new System.Drawing.Point(676, 3);
            this.bSettings.Name = "bSettings";
            this.bSettings.Size = new System.Drawing.Size(74, 67);
            this.bSettings.TabIndex = 6;
            this.bSettings.UseVisualStyleBackColor = false;
            // 
            // lVersion
            // 
            this.lVersion.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.lVersion.Font = new System.Drawing.Font("Bahnschrift Light", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lVersion.ForeColor = System.Drawing.SystemColors.ButtonShadow;
            this.lVersion.Location = new System.Drawing.Point(0, 177);
            this.lVersion.Name = "lVersion";
            this.lVersion.Size = new System.Drawing.Size(753, 13);
            this.lVersion.TabIndex = 1;
            this.lVersion.Text = "0.1.0";
            this.lVersion.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // pDashboard
            // 
            this.pDashboard.AutoScroll = true;
            this.pDashboard.Controls.Add(this.tcDashboard);
            this.pDashboard.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pDashboard.Location = new System.Drawing.Point(0, 232);
            this.pDashboard.Name = "pDashboard";
            this.pDashboard.Size = new System.Drawing.Size(753, 349);
            this.pDashboard.TabIndex = 7;
            // 
            // tpMangalist
            // 
            this.tpMangalist.AutoScroll = true;
            this.tpMangalist.Location = new System.Drawing.Point(4, 34);
            this.tpMangalist.Name = "tpMangalist";
            this.tpMangalist.Padding = new System.Windows.Forms.Padding(3);
            this.tpMangalist.Size = new System.Drawing.Size(681, 255);
            this.tpMangalist.TabIndex = 2;
            this.tpMangalist.Text = "Mangalist";
            this.tpMangalist.UseVisualStyleBackColor = true;
            // 
            // tpAnimelist
            // 
            this.tpAnimelist.AutoScroll = true;
            this.tpAnimelist.Location = new System.Drawing.Point(4, 34);
            this.tpAnimelist.Name = "tpAnimelist";
            this.tpAnimelist.Padding = new System.Windows.Forms.Padding(3);
            this.tpAnimelist.Size = new System.Drawing.Size(681, 255);
            this.tpAnimelist.TabIndex = 1;
            this.tpAnimelist.Text = "Animelist";
            this.tpAnimelist.UseVisualStyleBackColor = true;
            // 
            // tpStatistics
            // 
            this.tpStatistics.AutoScroll = true;
            this.tpStatistics.Location = new System.Drawing.Point(4, 34);
            this.tpStatistics.Name = "tpStatistics";
            this.tpStatistics.Padding = new System.Windows.Forms.Padding(3);
            this.tpStatistics.Size = new System.Drawing.Size(681, 255);
            this.tpStatistics.TabIndex = 0;
            this.tpStatistics.Text = "Statistics";
            this.tpStatistics.UseVisualStyleBackColor = true;
            // 
            // tcDashboard
            // 
            this.tcDashboard.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tcDashboard.Controls.Add(this.tpStatistics);
            this.tcDashboard.Controls.Add(this.tpAnimelist);
            this.tcDashboard.Controls.Add(this.tpMangalist);
            this.tcDashboard.Font = new System.Drawing.Font("Bahnschrift Light", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tcDashboard.ItemSize = new System.Drawing.Size(100, 30);
            this.tcDashboard.Location = new System.Drawing.Point(35, 33);
            this.tcDashboard.Multiline = true;
            this.tcDashboard.Name = "tcDashboard";
            this.tcDashboard.SelectedIndex = 0;
            this.tcDashboard.Size = new System.Drawing.Size(689, 293);
            this.tcDashboard.SizeMode = System.Windows.Forms.TabSizeMode.Fixed;
            this.tcDashboard.TabIndex = 7;
            // 
            // fWelcome
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(984, 581);
            this.Controls.Add(this.pMain);
            this.Controls.Add(this.pSide);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimumSize = new System.Drawing.Size(850, 600);
            this.Name = "fWelcome";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "MAL Reviewer";
            this.pSide.ResumeLayout(false);
            this.pUser.ResumeLayout(false);
            this.pReviewLookUp.ResumeLayout(false);
            this.pReviewLookUp.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbSearch)).EndInit();
            this.pButtons.ResumeLayout(false);
            this.pMain.ResumeLayout(false);
            this.pHeader.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pbLogo)).EndInit();
            this.pDashboard.ResumeLayout(false);
            this.tcDashboard.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pSide;
        private System.Windows.Forms.Panel pMain;
        private System.Windows.Forms.PictureBox pbLogo;
        private System.Windows.Forms.Panel pHeader;
        private System.Windows.Forms.Label lTitle;
        private System.Windows.Forms.Panel pButtons;
        private System.Windows.Forms.Button bNew;
        private System.Windows.Forms.Button bClear;
        private System.Windows.Forms.Button bOpen;
        private System.Windows.Forms.Panel pReviewLookUp;
        private System.Windows.Forms.ImageList ilSizeControl;
        private System.Windows.Forms.PictureBox pbSearch;
        private System.Windows.Forms.TextBox tbSearch;
        private System.Windows.Forms.Button bSettings;
        private System.Windows.Forms.Panel pUser;
        private System.Windows.Forms.Button bUser;
        private System.Windows.Forms.Panel pReviews;
        private System.Windows.Forms.Label lVersion;
        private System.Windows.Forms.Panel pDashboard;
        private System.Windows.Forms.TabControl tcDashboard;
        private System.Windows.Forms.TabPage tpStatistics;
        private System.Windows.Forms.TabPage tpAnimelist;
        private System.Windows.Forms.TabPage tpMangalist;
    }
}