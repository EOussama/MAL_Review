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
            this.pMain = new System.Windows.Forms.Panel();
            this.pHeader = new System.Windows.Forms.Panel();
            this.lTitle = new System.Windows.Forms.Label();
            this.pButtons = new System.Windows.Forms.Panel();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.pReviewLookUp = new System.Windows.Forms.Panel();
            this.bNew = new System.Windows.Forms.Button();
            this.pbLogo = new System.Windows.Forms.PictureBox();
            this.ilSizeControl = new System.Windows.Forms.ImageList(this.components);
            this.pSide.SuspendLayout();
            this.pMain.SuspendLayout();
            this.pHeader.SuspendLayout();
            this.pButtons.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbLogo)).BeginInit();
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
            // pMain
            // 
            this.pMain.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pMain.BackColor = System.Drawing.SystemColors.Control;
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
            // pButtons
            // 
            this.pButtons.Controls.Add(this.button2);
            this.pButtons.Controls.Add(this.button1);
            this.pButtons.Controls.Add(this.bNew);
            this.pButtons.Dock = System.Windows.Forms.DockStyle.Top;
            this.pButtons.Location = new System.Drawing.Point(0, 0);
            this.pButtons.Name = "pButtons";
            this.pButtons.Size = new System.Drawing.Size(230, 73);
            this.pButtons.TabIndex = 2;
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.Transparent;
            this.button1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button1.FlatAppearance.BorderSize = 0;
            this.button1.FlatAppearance.MouseDownBackColor = System.Drawing.Color.LightGray;
            this.button1.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Gainsboro;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.ImageIndex = 1;
            this.button1.ImageList = this.ilSizeControl;
            this.button1.Location = new System.Drawing.Point(77, 3);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 67);
            this.button1.TabIndex = 4;
            this.button1.UseVisualStyleBackColor = false;
            // 
            // button2
            // 
            this.button2.BackColor = System.Drawing.Color.Transparent;
            this.button2.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button2.FlatAppearance.BorderSize = 0;
            this.button2.FlatAppearance.MouseDownBackColor = System.Drawing.Color.LightGray;
            this.button2.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Gainsboro;
            this.button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button2.ImageIndex = 2;
            this.button2.ImageList = this.ilSizeControl;
            this.button2.Location = new System.Drawing.Point(152, 3);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 67);
            this.button2.TabIndex = 5;
            this.button2.UseVisualStyleBackColor = false;
            // 
            // pReviewLookUp
            // 
            this.pReviewLookUp.Dock = System.Windows.Forms.DockStyle.Top;
            this.pReviewLookUp.Location = new System.Drawing.Point(0, 73);
            this.pReviewLookUp.Name = "pReviewLookUp";
            this.pReviewLookUp.Size = new System.Drawing.Size(230, 55);
            this.pReviewLookUp.TabIndex = 2;
            // 
            // bNew
            // 
            this.bNew.BackColor = System.Drawing.SystemColors.ControlLight;
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
            // ilSizeControl
            // 
            this.ilSizeControl.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("ilSizeControl.ImageStream")));
            this.ilSizeControl.TransparentColor = System.Drawing.SystemColors.ControlLight;
            this.ilSizeControl.Images.SetKeyName(0, "icon-add.png");
            this.ilSizeControl.Images.SetKeyName(1, "icon-open.png");
            this.ilSizeControl.Images.SetKeyName(2, "icon-delete.png");
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
            this.pMain.ResumeLayout(false);
            this.pHeader.ResumeLayout(false);
            this.pButtons.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pbLogo)).EndInit();
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
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Panel pReviewLookUp;
        private System.Windows.Forms.ImageList ilSizeControl;
    }
}