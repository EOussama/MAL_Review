namespace MAL_Reviwer_UI.forms
{
    partial class fNewReview
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(fNewReview));
            this.pSeparator = new System.Windows.Forms.Panel();
            this.pReviewLookUp = new System.Windows.Forms.Panel();
            this.tbSearch = new System.Windows.Forms.TextBox();
            this.pPreview = new System.Windows.Forms.Panel();
            this.pSetup = new System.Windows.Forms.Panel();
            this.lTitle = new System.Windows.Forms.Label();
            this.rbManga = new System.Windows.Forms.RadioButton();
            this.rbAnime = new System.Windows.Forms.RadioButton();
            this.pbShow = new System.Windows.Forms.PictureBox();
            this.pReviewLookUp.SuspendLayout();
            this.pSetup.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbShow)).BeginInit();
            this.SuspendLayout();
            // 
            // pSeparator
            // 
            this.pSeparator.BackColor = System.Drawing.SystemColors.ControlLight;
            this.pSeparator.Location = new System.Drawing.Point(310, 28);
            this.pSeparator.Name = "pSeparator";
            this.pSeparator.Size = new System.Drawing.Size(6, 310);
            this.pSeparator.TabIndex = 0;
            // 
            // pReviewLookUp
            // 
            this.pReviewLookUp.BackColor = System.Drawing.SystemColors.ControlLight;
            this.pReviewLookUp.Controls.Add(this.pbShow);
            this.pReviewLookUp.Controls.Add(this.tbSearch);
            this.pReviewLookUp.Location = new System.Drawing.Point(12, 40);
            this.pReviewLookUp.Name = "pReviewLookUp";
            this.pReviewLookUp.Size = new System.Drawing.Size(230, 35);
            this.pReviewLookUp.TabIndex = 3;
            // 
            // tbSearch
            // 
            this.tbSearch.BackColor = System.Drawing.SystemColors.ControlLight;
            this.tbSearch.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.tbSearch.Font = new System.Drawing.Font("Bahnschrift Light", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbSearch.Location = new System.Drawing.Point(9, 7);
            this.tbSearch.Name = "tbSearch";
            this.tbSearch.Size = new System.Drawing.Size(188, 20);
            this.tbSearch.TabIndex = 0;
            // 
            // pPreview
            // 
            this.pPreview.Location = new System.Drawing.Point(343, 12);
            this.pPreview.Name = "pPreview";
            this.pPreview.Size = new System.Drawing.Size(255, 339);
            this.pPreview.TabIndex = 4;
            // 
            // pSetup
            // 
            this.pSetup.Controls.Add(this.rbAnime);
            this.pSetup.Controls.Add(this.rbManga);
            this.pSetup.Controls.Add(this.lTitle);
            this.pSetup.Controls.Add(this.pReviewLookUp);
            this.pSetup.Location = new System.Drawing.Point(27, 12);
            this.pSetup.Name = "pSetup";
            this.pSetup.Size = new System.Drawing.Size(255, 339);
            this.pSetup.TabIndex = 5;
            // 
            // lTitle
            // 
            this.lTitle.AutoSize = true;
            this.lTitle.Font = new System.Drawing.Font("Bahnschrift SemiBold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lTitle.Location = new System.Drawing.Point(8, 16);
            this.lTitle.Name = "lTitle";
            this.lTitle.Size = new System.Drawing.Size(86, 19);
            this.lTitle.TabIndex = 0;
            this.lTitle.Text = "Anime title";
            // 
            // rbManga
            // 
            this.rbManga.AutoSize = true;
            this.rbManga.Location = new System.Drawing.Point(184, 19);
            this.rbManga.Name = "rbManga";
            this.rbManga.Size = new System.Drawing.Size(58, 17);
            this.rbManga.TabIndex = 0;
            this.rbManga.Text = "Manga";
            this.rbManga.UseVisualStyleBackColor = true;
            // 
            // rbAnime
            // 
            this.rbAnime.AutoSize = true;
            this.rbAnime.Checked = true;
            this.rbAnime.Location = new System.Drawing.Point(124, 19);
            this.rbAnime.Name = "rbAnime";
            this.rbAnime.Size = new System.Drawing.Size(54, 17);
            this.rbAnime.TabIndex = 4;
            this.rbAnime.TabStop = true;
            this.rbAnime.Text = "Anime";
            this.rbAnime.UseVisualStyleBackColor = true;
            // 
            // pbShow
            // 
            this.pbShow.Image = global::MAL_Reviwer_UI.Properties.Resources.icon_anime;
            this.pbShow.Location = new System.Drawing.Point(204, 8);
            this.pbShow.Name = "pbShow";
            this.pbShow.Size = new System.Drawing.Size(20, 20);
            this.pbShow.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pbShow.TabIndex = 1;
            this.pbShow.TabStop = false;
            // 
            // fNewReview
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(624, 363);
            this.Controls.Add(this.pSetup);
            this.Controls.Add(this.pPreview);
            this.Controls.Add(this.pSeparator);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "fNewReview";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "New Review";
            this.pReviewLookUp.ResumeLayout(false);
            this.pReviewLookUp.PerformLayout();
            this.pSetup.ResumeLayout(false);
            this.pSetup.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbShow)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pSeparator;
        private System.Windows.Forms.Panel pReviewLookUp;
        private System.Windows.Forms.TextBox tbSearch;
        private System.Windows.Forms.Panel pPreview;
        private System.Windows.Forms.Panel pSetup;
        private System.Windows.Forms.Label lTitle;
        private System.Windows.Forms.RadioButton rbAnime;
        private System.Windows.Forms.RadioButton rbManga;
        private System.Windows.Forms.PictureBox pbShow;
    }
}