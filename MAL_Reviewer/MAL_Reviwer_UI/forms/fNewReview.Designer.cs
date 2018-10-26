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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(fNewReview));
            this.pSectionSeparator = new System.Windows.Forms.Panel();
            this.pReviewLookUp = new System.Windows.Forms.Panel();
            this.pbLoading = new System.Windows.Forms.PictureBox();
            this.pbShow = new System.Windows.Forms.PictureBox();
            this.tbSearch = new System.Windows.Forms.TextBox();
            this.pPreview = new System.Windows.Forms.Panel();
            this.pSetup = new System.Windows.Forms.Panel();
            this.pSearchCards = new System.Windows.Forms.Panel();
            this.pRatingSeparator = new System.Windows.Forms.Panel();
            this.pTitleSeparator = new System.Windows.Forms.Panel();
            this.gbRating = new System.Windows.Forms.GroupBox();
            this.rbDecimalNo = new System.Windows.Forms.RadioButton();
            this.rbDecimalYes = new System.Windows.Forms.RadioButton();
            this.lRatingDecimal = new System.Windows.Forms.Label();
            this.gbRatingScale = new System.Windows.Forms.GroupBox();
            this.nupScaleOther = new System.Windows.Forms.NumericUpDown();
            this.rbScaleOther = new System.Windows.Forms.RadioButton();
            this.rbScale100 = new System.Windows.Forms.RadioButton();
            this.rbScale10 = new System.Windows.Forms.RadioButton();
            this.rbScale5 = new System.Windows.Forms.RadioButton();
            this.rbAnime = new System.Windows.Forms.RadioButton();
            this.rbManga = new System.Windows.Forms.RadioButton();
            this.lTitle = new System.Windows.Forms.Label();
            this.ttSearchCard = new System.Windows.Forms.ToolTip(this.components);
            this.pbTargetImage = new System.Windows.Forms.PictureBox();
            this.lTargetTitle = new System.Windows.Forms.Label();
            this.pReviewLookUp.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbLoading)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbShow)).BeginInit();
            this.pPreview.SuspendLayout();
            this.pSetup.SuspendLayout();
            this.gbRating.SuspendLayout();
            this.gbRatingScale.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nupScaleOther)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbTargetImage)).BeginInit();
            this.SuspendLayout();
            // 
            // pSectionSeparator
            // 
            this.pSectionSeparator.BackColor = System.Drawing.SystemColors.ControlLight;
            this.pSectionSeparator.Location = new System.Drawing.Point(310, 28);
            this.pSectionSeparator.Name = "pSectionSeparator";
            this.pSectionSeparator.Size = new System.Drawing.Size(6, 310);
            this.pSectionSeparator.TabIndex = 0;
            // 
            // pReviewLookUp
            // 
            this.pReviewLookUp.BackColor = System.Drawing.SystemColors.ControlLight;
            this.pReviewLookUp.Controls.Add(this.pbLoading);
            this.pReviewLookUp.Controls.Add(this.pbShow);
            this.pReviewLookUp.Controls.Add(this.tbSearch);
            this.pReviewLookUp.Location = new System.Drawing.Point(12, 40);
            this.pReviewLookUp.Name = "pReviewLookUp";
            this.pReviewLookUp.Size = new System.Drawing.Size(230, 35);
            this.pReviewLookUp.TabIndex = 3;
            // 
            // pbLoading
            // 
            this.pbLoading.Image = global::MAL_Reviwer_UI.Properties.Resources.loading;
            this.pbLoading.Location = new System.Drawing.Point(199, 5);
            this.pbLoading.Name = "pbLoading";
            this.pbLoading.Size = new System.Drawing.Size(25, 24);
            this.pbLoading.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pbLoading.TabIndex = 0;
            this.pbLoading.TabStop = false;
            this.pbLoading.Visible = false;
            // 
            // pbShow
            // 
            this.pbShow.Image = ((System.Drawing.Image)(resources.GetObject("pbShow.Image")));
            this.pbShow.Location = new System.Drawing.Point(204, 8);
            this.pbShow.Name = "pbShow";
            this.pbShow.Size = new System.Drawing.Size(20, 20);
            this.pbShow.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pbShow.TabIndex = 1;
            this.pbShow.TabStop = false;
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
            this.tbSearch.TextChanged += new System.EventHandler(this.tbSearch_TextChanged);
            // 
            // pPreview
            // 
            this.pPreview.Controls.Add(this.lTargetTitle);
            this.pPreview.Controls.Add(this.pbTargetImage);
            this.pPreview.Location = new System.Drawing.Point(343, 12);
            this.pPreview.Name = "pPreview";
            this.pPreview.Size = new System.Drawing.Size(255, 339);
            this.pPreview.TabIndex = 4;
            // 
            // pSetup
            // 
            this.pSetup.Controls.Add(this.pSearchCards);
            this.pSetup.Controls.Add(this.pRatingSeparator);
            this.pSetup.Controls.Add(this.pTitleSeparator);
            this.pSetup.Controls.Add(this.gbRating);
            this.pSetup.Controls.Add(this.rbAnime);
            this.pSetup.Controls.Add(this.rbManga);
            this.pSetup.Controls.Add(this.lTitle);
            this.pSetup.Controls.Add(this.pReviewLookUp);
            this.pSetup.Location = new System.Drawing.Point(27, 12);
            this.pSetup.Name = "pSetup";
            this.pSetup.Size = new System.Drawing.Size(255, 339);
            this.pSetup.TabIndex = 5;
            // 
            // pSearchCards
            // 
            this.pSearchCards.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.pSearchCards.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pSearchCards.Location = new System.Drawing.Point(12, 75);
            this.pSearchCards.Name = "pSearchCards";
            this.pSearchCards.Size = new System.Drawing.Size(230, 106);
            this.pSearchCards.TabIndex = 0;
            this.pSearchCards.Visible = false;
            // 
            // pRatingSeparator
            // 
            this.pRatingSeparator.BackColor = System.Drawing.SystemColors.ControlLight;
            this.pRatingSeparator.Location = new System.Drawing.Point(12, 275);
            this.pRatingSeparator.Name = "pRatingSeparator";
            this.pRatingSeparator.Size = new System.Drawing.Size(231, 6);
            this.pRatingSeparator.TabIndex = 2;
            // 
            // pTitleSeparator
            // 
            this.pTitleSeparator.BackColor = System.Drawing.SystemColors.ControlLight;
            this.pTitleSeparator.Location = new System.Drawing.Point(12, 88);
            this.pTitleSeparator.Name = "pTitleSeparator";
            this.pTitleSeparator.Size = new System.Drawing.Size(231, 6);
            this.pTitleSeparator.TabIndex = 1;
            // 
            // gbRating
            // 
            this.gbRating.Controls.Add(this.rbDecimalNo);
            this.gbRating.Controls.Add(this.rbDecimalYes);
            this.gbRating.Controls.Add(this.lRatingDecimal);
            this.gbRating.Controls.Add(this.gbRatingScale);
            this.gbRating.Font = new System.Drawing.Font("Bahnschrift SemiBold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gbRating.Location = new System.Drawing.Point(12, 103);
            this.gbRating.Name = "gbRating";
            this.gbRating.Size = new System.Drawing.Size(231, 159);
            this.gbRating.TabIndex = 0;
            this.gbRating.TabStop = false;
            this.gbRating.Text = "Rating settings";
            // 
            // rbDecimalNo
            // 
            this.rbDecimalNo.AutoSize = true;
            this.rbDecimalNo.Checked = true;
            this.rbDecimalNo.Font = new System.Drawing.Font("Bahnschrift Light", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbDecimalNo.Location = new System.Drawing.Point(179, 129);
            this.rbDecimalNo.Name = "rbDecimalNo";
            this.rbDecimalNo.Size = new System.Drawing.Size(42, 20);
            this.rbDecimalNo.TabIndex = 7;
            this.rbDecimalNo.TabStop = true;
            this.rbDecimalNo.Text = "No";
            this.rbDecimalNo.UseVisualStyleBackColor = true;
            // 
            // rbDecimalYes
            // 
            this.rbDecimalYes.AutoSize = true;
            this.rbDecimalYes.Font = new System.Drawing.Font("Bahnschrift Light", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbDecimalYes.Location = new System.Drawing.Point(127, 129);
            this.rbDecimalYes.Name = "rbDecimalYes";
            this.rbDecimalYes.Size = new System.Drawing.Size(46, 20);
            this.rbDecimalYes.TabIndex = 6;
            this.rbDecimalYes.Text = "Yes";
            this.rbDecimalYes.UseVisualStyleBackColor = true;
            // 
            // lRatingDecimal
            // 
            this.lRatingDecimal.AutoSize = true;
            this.lRatingDecimal.Font = new System.Drawing.Font("Bahnschrift SemiBold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lRatingDecimal.Location = new System.Drawing.Point(6, 128);
            this.lRatingDecimal.Name = "lRatingDecimal";
            this.lRatingDecimal.Size = new System.Drawing.Size(115, 19);
            this.lRatingDecimal.TabIndex = 5;
            this.lRatingDecimal.Text = "Decimal rating";
            // 
            // gbRatingScale
            // 
            this.gbRatingScale.Controls.Add(this.nupScaleOther);
            this.gbRatingScale.Controls.Add(this.rbScaleOther);
            this.gbRatingScale.Controls.Add(this.rbScale100);
            this.gbRatingScale.Controls.Add(this.rbScale10);
            this.gbRatingScale.Controls.Add(this.rbScale5);
            this.gbRatingScale.Font = new System.Drawing.Font("Bahnschrift SemiBold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gbRatingScale.Location = new System.Drawing.Point(9, 26);
            this.gbRatingScale.Name = "gbRatingScale";
            this.gbRatingScale.Size = new System.Drawing.Size(212, 93);
            this.gbRatingScale.TabIndex = 1;
            this.gbRatingScale.TabStop = false;
            this.gbRatingScale.Text = "Rating scale";
            // 
            // nupScaleOther
            // 
            this.nupScaleOther.BackColor = System.Drawing.SystemColors.ControlLight;
            this.nupScaleOther.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.nupScaleOther.Enabled = false;
            this.nupScaleOther.Font = new System.Drawing.Font("Bahnschrift Light", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nupScaleOther.Location = new System.Drawing.Point(83, 57);
            this.nupScaleOther.Minimum = new decimal(new int[] {
            5,
            0,
            0,
            0});
            this.nupScaleOther.Name = "nupScaleOther";
            this.nupScaleOther.Size = new System.Drawing.Size(44, 23);
            this.nupScaleOther.TabIndex = 0;
            this.nupScaleOther.Value = new decimal(new int[] {
            50,
            0,
            0,
            0});
            // 
            // rbScaleOther
            // 
            this.rbScaleOther.AutoSize = true;
            this.rbScaleOther.Font = new System.Drawing.Font("Bahnschrift Light", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbScaleOther.Location = new System.Drawing.Point(15, 58);
            this.rbScaleOther.Name = "rbScaleOther";
            this.rbScaleOther.Size = new System.Drawing.Size(58, 20);
            this.rbScaleOther.TabIndex = 8;
            this.rbScaleOther.Text = "Other";
            this.rbScaleOther.UseVisualStyleBackColor = true;
            // 
            // rbScale100
            // 
            this.rbScale100.AutoSize = true;
            this.rbScale100.Font = new System.Drawing.Font("Bahnschrift Light", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbScale100.Location = new System.Drawing.Point(155, 26);
            this.rbScale100.Name = "rbScale100";
            this.rbScale100.Size = new System.Drawing.Size(44, 20);
            this.rbScale100.TabIndex = 7;
            this.rbScale100.Text = "100";
            this.rbScale100.UseVisualStyleBackColor = true;
            // 
            // rbScale10
            // 
            this.rbScale10.AutoSize = true;
            this.rbScale10.Checked = true;
            this.rbScale10.Font = new System.Drawing.Font("Bahnschrift Light", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbScale10.Location = new System.Drawing.Point(83, 26);
            this.rbScale10.Name = "rbScale10";
            this.rbScale10.Size = new System.Drawing.Size(37, 20);
            this.rbScale10.TabIndex = 6;
            this.rbScale10.TabStop = true;
            this.rbScale10.Text = "10";
            this.rbScale10.UseVisualStyleBackColor = true;
            // 
            // rbScale5
            // 
            this.rbScale5.AutoSize = true;
            this.rbScale5.Font = new System.Drawing.Font("Bahnschrift Light", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbScale5.Location = new System.Drawing.Point(15, 26);
            this.rbScale5.Name = "rbScale5";
            this.rbScale5.Size = new System.Drawing.Size(33, 20);
            this.rbScale5.TabIndex = 5;
            this.rbScale5.Text = "5";
            this.rbScale5.UseVisualStyleBackColor = true;
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
            // ttSearchCard
            // 
            this.ttSearchCard.ToolTipIcon = System.Windows.Forms.ToolTipIcon.Info;
            this.ttSearchCard.ToolTipTitle = "Anime title";
            // 
            // pbTargetImage
            // 
            this.pbTargetImage.Location = new System.Drawing.Point(14, 19);
            this.pbTargetImage.Name = "pbTargetImage";
            this.pbTargetImage.Size = new System.Drawing.Size(128, 156);
            this.pbTargetImage.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbTargetImage.TabIndex = 0;
            this.pbTargetImage.TabStop = false;
            // 
            // lTargetTitle
            // 
            this.lTargetTitle.AutoSize = true;
            this.lTargetTitle.Font = new System.Drawing.Font("Bahnschrift SemiBold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lTargetTitle.Location = new System.Drawing.Point(10, 185);
            this.lTargetTitle.Name = "lTargetTitle";
            this.lTargetTitle.Size = new System.Drawing.Size(86, 19);
            this.lTargetTitle.TabIndex = 5;
            this.lTargetTitle.Text = "Anime title";
            // 
            // fNewReview
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(624, 363);
            this.Controls.Add(this.pSetup);
            this.Controls.Add(this.pPreview);
            this.Controls.Add(this.pSectionSeparator);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "fNewReview";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "New Review";
            this.pReviewLookUp.ResumeLayout(false);
            this.pReviewLookUp.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbLoading)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbShow)).EndInit();
            this.pPreview.ResumeLayout(false);
            this.pPreview.PerformLayout();
            this.pSetup.ResumeLayout(false);
            this.pSetup.PerformLayout();
            this.gbRating.ResumeLayout(false);
            this.gbRating.PerformLayout();
            this.gbRatingScale.ResumeLayout(false);
            this.gbRatingScale.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nupScaleOther)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbTargetImage)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pSectionSeparator;
        private System.Windows.Forms.Panel pReviewLookUp;
        private System.Windows.Forms.TextBox tbSearch;
        private System.Windows.Forms.Panel pPreview;
        private System.Windows.Forms.Panel pSetup;
        private System.Windows.Forms.Label lTitle;
        private System.Windows.Forms.RadioButton rbAnime;
        private System.Windows.Forms.RadioButton rbManga;
        private System.Windows.Forms.PictureBox pbShow;
        private System.Windows.Forms.GroupBox gbRating;
        private System.Windows.Forms.Panel pTitleSeparator;
        private System.Windows.Forms.GroupBox gbRatingScale;
        private System.Windows.Forms.NumericUpDown nupScaleOther;
        private System.Windows.Forms.RadioButton rbScaleOther;
        private System.Windows.Forms.RadioButton rbScale100;
        private System.Windows.Forms.RadioButton rbScale10;
        private System.Windows.Forms.RadioButton rbScale5;
        private System.Windows.Forms.RadioButton rbDecimalNo;
        private System.Windows.Forms.RadioButton rbDecimalYes;
        private System.Windows.Forms.Label lRatingDecimal;
        private System.Windows.Forms.Panel pRatingSeparator;
        private System.Windows.Forms.Panel pSearchCards;
        private System.Windows.Forms.ToolTip ttSearchCard;
        private System.Windows.Forms.PictureBox pbLoading;
        private System.Windows.Forms.Label lTargetTitle;
        private System.Windows.Forms.PictureBox pbTargetImage;
    }
}