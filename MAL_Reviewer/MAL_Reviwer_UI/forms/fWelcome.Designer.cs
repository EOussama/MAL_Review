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
            this.pReviewLookUp = new System.Windows.Forms.Panel();
            this.pButtons = new System.Windows.Forms.Panel();
            this.bClear = new System.Windows.Forms.Button();
            this.ilSizeControl = new System.Windows.Forms.ImageList(this.components);
            this.bOpen = new System.Windows.Forms.Button();
            this.bNew = new System.Windows.Forms.Button();
            this.pMain = new System.Windows.Forms.Panel();
            this.pHeader = new System.Windows.Forms.Panel();
            this.lTitle = new System.Windows.Forms.Label();
            this.pbLogo = new System.Windows.Forms.PictureBox();
            this.tbSearch = new System.Windows.Forms.TextBox();
            this.pbSearch = new System.Windows.Forms.PictureBox();
            this.button1 = new System.Windows.Forms.Button();
            this.pSide.SuspendLayout();
            this.pReviewLookUp.SuspendLayout();
            this.pButtons.SuspendLayout();
            this.pMain.SuspendLayout();
            this.pHeader.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbLogo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbSearch)).BeginInit();
            this.SuspendLayout();
            // 
            // pSide
            // 
            this.pSide.BackColor = System.Drawing.SystemColors.ControlLight;
            this.pSide.Controls.Add(this.pReviewLookUp);
            this.pSide.Controls.Add(this.pButtons);
            this.pSide.Dock = System.Windows.Forms.DockStyle.Left;
            this.pSide.Location = new System.Drawing.Point(0, 0);
            this.pSide.Name = "pSide";
            this.pSide.Size = new System.Drawing.Size(230, 561);
            this.pSide.TabIndex = 0;
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
            // ilSizeControl
            // 
            this.ilSizeControl.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("ilSizeControl.ImageStream")));
            this.ilSizeControl.TransparentColor = System.Drawing.SystemColors.ControlLight;
            this.ilSizeControl.Images.SetKeyName(0, "icon-add.png");
            this.ilSizeControl.Images.SetKeyName(1, "icon-open.png");
            this.ilSizeControl.Images.SetKeyName(2, "icon-delete.png");
            this.ilSizeControl.Images.SetKeyName(3, "icon-settings.png");
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
            // 
            // pMain
            // 
            this.pMain.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pMain.BackColor = System.Drawing.SystemColors.Control;
            this.pMain.Controls.Add(this.button1);
            this.pMain.Controls.Add(this.pHeader);
            this.pMain.Location = new System.Drawing.Point(231, 0);
            this.pMain.Name = "pMain";
            this.pMain.Size = new System.Drawing.Size(603, 561);
            this.pMain.TabIndex = 1;
            // 
            // pHeader
            // 
            this.pHeader.BackColor = System.Drawing.SystemColors.Control;
            this.pHeader.Controls.Add(this.lTitle);
            this.pHeader.Controls.Add(this.pbLogo);
            this.pHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.pHeader.Location = new System.Drawing.Point(0, 0);
            this.pHeader.Name = "pHeader";
            this.pHeader.Size = new System.Drawing.Size(603, 236);
            this.pHeader.TabIndex = 1;
            // 
            // lTitle
            // 
            this.lTitle.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.lTitle.Font = new System.Drawing.Font("Bahnschrift Light", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lTitle.Location = new System.Drawing.Point(0, 194);
            this.lTitle.Name = "lTitle";
            this.lTitle.Size = new System.Drawing.Size(603, 42);
            this.lTitle.TabIndex = 1;
            this.lTitle.Text = "MAL Reviewer";
            this.lTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // pbLogo
            // 
            this.pbLogo.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pbLogo.Image = global::MAL_Reviwer_UI.Properties.Resources.logo;
            this.pbLogo.Location = new System.Drawing.Point(194, 12);
            this.pbLogo.Name = "pbLogo";
            this.pbLogo.Size = new System.Drawing.Size(207, 179);
            this.pbLogo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pbLogo.TabIndex = 0;
            this.pbLogo.TabStop = false;
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
            // button1
            // 
            this.button1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.button1.BackColor = System.Drawing.Color.Transparent;
            this.button1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button1.FlatAppearance.BorderSize = 0;
            this.button1.FlatAppearance.MouseDownBackColor = System.Drawing.Color.White;
            this.button1.FlatAppearance.MouseOverBackColor = System.Drawing.Color.WhiteSmoke;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.ImageIndex = 3;
            this.button1.ImageList = this.ilSizeControl;
            this.button1.Location = new System.Drawing.Point(526, 491);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(74, 67);
            this.button1.TabIndex = 6;
            this.button1.UseVisualStyleBackColor = false;
            // 
            // fWelcome
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(834, 561);
            this.Controls.Add(this.pMain);
            this.Controls.Add(this.pSide);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimumSize = new System.Drawing.Size(850, 600);
            this.Name = "fWelcome";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "MAL Reviewer";
            this.pSide.ResumeLayout(false);
            this.pReviewLookUp.ResumeLayout(false);
            this.pReviewLookUp.PerformLayout();
            this.pButtons.ResumeLayout(false);
            this.pMain.ResumeLayout(false);
            this.pHeader.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pbLogo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbSearch)).EndInit();
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
        private System.Windows.Forms.Button button1;
    }
}