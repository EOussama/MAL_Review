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
            this.lChapters = new System.Windows.Forms.Label();
            this.lTargetChapters = new System.Windows.Forms.Label();
            this.lVolumesEpisodes = new System.Windows.Forms.Label();
            this.lTargetVolumesEpisodes = new System.Windows.Forms.Label();
            this.lStatus = new System.Windows.Forms.Label();
            this.lTargetStatus = new System.Windows.Forms.Label();
            this.bMAL = new System.Windows.Forms.Button();
            this.lType = new System.Windows.Forms.Label();
            this.lRank = new System.Windows.Forms.Label();
            this.lScore = new System.Windows.Forms.Label();
            this.lTargetType = new System.Windows.Forms.Label();
            this.lTargetRank = new System.Windows.Forms.Label();
            this.lTargetScore = new System.Windows.Forms.Label();
            this.lTargetSynopsis = new System.Windows.Forms.Label();
            this.lTargetTitle = new System.Windows.Forms.Label();
            this.pbTargetImage = new System.Windows.Forms.PictureBox();
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
            this.lPreview = new System.Windows.Forms.Label();
            this.pbLoadingPreview = new System.Windows.Forms.PictureBox();
            this.pReviewLookUp.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbLoading)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbShow)).BeginInit();
            this.pPreview.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbTargetImage)).BeginInit();
            this.pSetup.SuspendLayout();
            this.gbRating.SuspendLayout();
            this.gbRatingScale.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nupScaleOther)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbLoadingPreview)).BeginInit();
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
            this.pbLoading.Image = global::MAL_Reviwer_UI.Properties.Resources.loading_gif_control_light;
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
            this.pbShow.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pbShow.Image = ((System.Drawing.Image)(resources.GetObject("pbShow.Image")));
            this.pbShow.Location = new System.Drawing.Point(204, 8);
            this.pbShow.Name = "pbShow";
            this.pbShow.Size = new System.Drawing.Size(20, 20);
            this.pbShow.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pbShow.TabIndex = 1;
            this.pbShow.TabStop = false;
            this.pbShow.MouseClick += new System.Windows.Forms.MouseEventHandler(this.pbShow_MouseClick);
            this.pbShow.MouseEnter += new System.EventHandler(this.pbShow_MouseEnter);
            this.pbShow.MouseLeave += new System.EventHandler(this.pbShow_MouseLeave);
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
            this.tbSearch.MouseClick += new System.Windows.Forms.MouseEventHandler(this.tbSearch_MouseClick);
            this.tbSearch.TextChanged += new System.EventHandler(this.tbSearch_TextChanged);
            // 
            // pPreview
            // 
            this.pPreview.Controls.Add(this.lChapters);
            this.pPreview.Controls.Add(this.lTargetChapters);
            this.pPreview.Controls.Add(this.lVolumesEpisodes);
            this.pPreview.Controls.Add(this.lTargetVolumesEpisodes);
            this.pPreview.Controls.Add(this.lStatus);
            this.pPreview.Controls.Add(this.lTargetStatus);
            this.pPreview.Controls.Add(this.bMAL);
            this.pPreview.Controls.Add(this.lType);
            this.pPreview.Controls.Add(this.lRank);
            this.pPreview.Controls.Add(this.lScore);
            this.pPreview.Controls.Add(this.lTargetType);
            this.pPreview.Controls.Add(this.lTargetRank);
            this.pPreview.Controls.Add(this.lTargetScore);
            this.pPreview.Controls.Add(this.lTargetSynopsis);
            this.pPreview.Controls.Add(this.lTargetTitle);
            this.pPreview.Controls.Add(this.pbTargetImage);
            this.pPreview.Location = new System.Drawing.Point(343, 12);
            this.pPreview.Name = "pPreview";
            this.pPreview.Size = new System.Drawing.Size(255, 339);
            this.pPreview.TabIndex = 4;
            this.pPreview.Visible = false;
            // 
            // lChapters
            // 
            this.lChapters.AutoSize = true;
            this.lChapters.Location = new System.Drawing.Point(144, 113);
            this.lChapters.Name = "lChapters";
            this.lChapters.Size = new System.Drawing.Size(49, 13);
            this.lChapters.TabIndex = 21;
            this.lChapters.Text = "Chapters";
            this.lChapters.Visible = false;
            // 
            // lTargetChapters
            // 
            this.lTargetChapters.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lTargetChapters.Font = new System.Drawing.Font("Bahnschrift", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lTargetChapters.Location = new System.Drawing.Point(190, 113);
            this.lTargetChapters.Name = "lTargetChapters";
            this.lTargetChapters.Size = new System.Drawing.Size(58, 13);
            this.lTargetChapters.TabIndex = 20;
            this.lTargetChapters.Text = "23";
            this.lTargetChapters.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.lTargetChapters.Visible = false;
            // 
            // lVolumesEpisodes
            // 
            this.lVolumesEpisodes.AutoSize = true;
            this.lVolumesEpisodes.Location = new System.Drawing.Point(144, 95);
            this.lVolumesEpisodes.Name = "lVolumesEpisodes";
            this.lVolumesEpisodes.Size = new System.Drawing.Size(50, 13);
            this.lVolumesEpisodes.TabIndex = 19;
            this.lVolumesEpisodes.Text = "Episodes";
            // 
            // lTargetVolumesEpisodes
            // 
            this.lTargetVolumesEpisodes.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lTargetVolumesEpisodes.Font = new System.Drawing.Font("Bahnschrift", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lTargetVolumesEpisodes.Location = new System.Drawing.Point(190, 95);
            this.lTargetVolumesEpisodes.Name = "lTargetVolumesEpisodes";
            this.lTargetVolumesEpisodes.Size = new System.Drawing.Size(58, 13);
            this.lTargetVolumesEpisodes.TabIndex = 18;
            this.lTargetVolumesEpisodes.Text = "23";
            this.lTargetVolumesEpisodes.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lStatus
            // 
            this.lStatus.AutoSize = true;
            this.lStatus.Location = new System.Drawing.Point(144, 77);
            this.lStatus.Name = "lStatus";
            this.lStatus.Size = new System.Drawing.Size(37, 13);
            this.lStatus.TabIndex = 17;
            this.lStatus.Text = "Status";
            // 
            // lTargetStatus
            // 
            this.lTargetStatus.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lTargetStatus.Font = new System.Drawing.Font("Bahnschrift", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lTargetStatus.Location = new System.Drawing.Point(176, 77);
            this.lTargetStatus.Name = "lTargetStatus";
            this.lTargetStatus.Size = new System.Drawing.Size(72, 13);
            this.lTargetStatus.TabIndex = 16;
            this.lTargetStatus.Text = "airing";
            this.lTargetStatus.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // bMAL
            // 
            this.bMAL.Cursor = System.Windows.Forms.Cursors.Hand;
            this.bMAL.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.bMAL.Location = new System.Drawing.Point(147, 155);
            this.bMAL.Name = "bMAL";
            this.bMAL.Size = new System.Drawing.Size(99, 27);
            this.bMAL.TabIndex = 13;
            this.bMAL.Text = "Visit MAL page";
            this.bMAL.UseVisualStyleBackColor = true;
            this.bMAL.Click += new System.EventHandler(this.bMAL_Click);
            // 
            // lType
            // 
            this.lType.AutoSize = true;
            this.lType.Location = new System.Drawing.Point(144, 59);
            this.lType.Name = "lType";
            this.lType.Size = new System.Drawing.Size(31, 13);
            this.lType.TabIndex = 12;
            this.lType.Text = "Type";
            // 
            // lRank
            // 
            this.lRank.AutoSize = true;
            this.lRank.Location = new System.Drawing.Point(144, 41);
            this.lRank.Name = "lRank";
            this.lRank.Size = new System.Drawing.Size(33, 13);
            this.lRank.TabIndex = 11;
            this.lRank.Text = "Rank";
            // 
            // lScore
            // 
            this.lScore.AutoSize = true;
            this.lScore.Location = new System.Drawing.Point(144, 23);
            this.lScore.Name = "lScore";
            this.lScore.Size = new System.Drawing.Size(35, 13);
            this.lScore.TabIndex = 10;
            this.lScore.Text = "Score";
            // 
            // lTargetType
            // 
            this.lTargetType.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lTargetType.Font = new System.Drawing.Font("Bahnschrift", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lTargetType.Location = new System.Drawing.Point(190, 59);
            this.lTargetType.Name = "lTargetType";
            this.lTargetType.Size = new System.Drawing.Size(58, 13);
            this.lTargetType.TabIndex = 9;
            this.lTargetType.Text = "movie";
            this.lTargetType.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lTargetRank
            // 
            this.lTargetRank.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lTargetRank.Font = new System.Drawing.Font("Bahnschrift", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lTargetRank.Location = new System.Drawing.Point(192, 39);
            this.lTargetRank.Name = "lTargetRank";
            this.lTargetRank.Size = new System.Drawing.Size(56, 16);
            this.lTargetRank.TabIndex = 8;
            this.lTargetRank.Text = "10000";
            this.lTargetRank.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lTargetScore
            // 
            this.lTargetScore.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lTargetScore.Font = new System.Drawing.Font("Bahnschrift", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lTargetScore.Location = new System.Drawing.Point(195, 21);
            this.lTargetScore.Name = "lTargetScore";
            this.lTargetScore.Size = new System.Drawing.Size(51, 17);
            this.lTargetScore.TabIndex = 7;
            this.lTargetScore.Text = "7.63";
            this.lTargetScore.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lTargetSynopsis
            // 
            this.lTargetSynopsis.Location = new System.Drawing.Point(11, 249);
            this.lTargetSynopsis.Name = "lTargetSynopsis";
            this.lTargetSynopsis.Size = new System.Drawing.Size(235, 77);
            this.lTargetSynopsis.TabIndex = 6;
            this.lTargetSynopsis.Text = "Synopsis";
            // 
            // lTargetTitle
            // 
            this.lTargetTitle.Font = new System.Drawing.Font("Bahnschrift SemiBold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lTargetTitle.Location = new System.Drawing.Point(10, 185);
            this.lTargetTitle.Name = "lTargetTitle";
            this.lTargetTitle.Size = new System.Drawing.Size(236, 45);
            this.lTargetTitle.TabIndex = 5;
            this.lTargetTitle.Text = "Title";
            // 
            // pbTargetImage
            // 
            this.pbTargetImage.Location = new System.Drawing.Point(14, 19);
            this.pbTargetImage.Name = "pbTargetImage";
            this.pbTargetImage.Size = new System.Drawing.Size(124, 163);
            this.pbTargetImage.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbTargetImage.TabIndex = 0;
            this.pbTargetImage.TabStop = false;
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
            this.pSearchCards.Size = new System.Drawing.Size(230, 10);
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
            this.rbAnime.Tag = "0";
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
            this.rbManga.Tag = "1";
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
            // lPreview
            // 
            this.lPreview.Font = new System.Drawing.Font("Bahnschrift", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lPreview.ForeColor = System.Drawing.SystemColors.ControlDark;
            this.lPreview.Location = new System.Drawing.Point(343, 12);
            this.lPreview.Name = "lPreview";
            this.lPreview.Size = new System.Drawing.Size(255, 339);
            this.lPreview.TabIndex = 6;
            this.lPreview.Text = "Anime preview";
            this.lPreview.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // pbLoadingPreview
            // 
            this.pbLoadingPreview.Image = global::MAL_Reviwer_UI.Properties.Resources.loading_gif_control;
            this.pbLoadingPreview.Location = new System.Drawing.Point(455, 141);
            this.pbLoadingPreview.Name = "pbLoadingPreview";
            this.pbLoadingPreview.Size = new System.Drawing.Size(25, 24);
            this.pbLoadingPreview.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pbLoadingPreview.TabIndex = 2;
            this.pbLoadingPreview.TabStop = false;
            this.pbLoadingPreview.Visible = false;
            // 
            // fNewReview
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(624, 363);
            this.Controls.Add(this.pbLoadingPreview);
            this.Controls.Add(this.pSetup);
            this.Controls.Add(this.pPreview);
            this.Controls.Add(this.pSectionSeparator);
            this.Controls.Add(this.lPreview);
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
            ((System.ComponentModel.ISupportInitialize)(this.pbTargetImage)).EndInit();
            this.pSetup.ResumeLayout(false);
            this.pSetup.PerformLayout();
            this.gbRating.ResumeLayout(false);
            this.gbRating.PerformLayout();
            this.gbRatingScale.ResumeLayout(false);
            this.gbRatingScale.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nupScaleOther)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbLoadingPreview)).EndInit();
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
        private System.Windows.Forms.Label lTargetSynopsis;
        private System.Windows.Forms.Label lType;
        private System.Windows.Forms.Label lRank;
        private System.Windows.Forms.Label lScore;
        private System.Windows.Forms.Label lTargetType;
        private System.Windows.Forms.Label lTargetRank;
        private System.Windows.Forms.Label lTargetScore;
        private System.Windows.Forms.Button bMAL;
        private System.Windows.Forms.Label lChapters;
        private System.Windows.Forms.Label lTargetChapters;
        private System.Windows.Forms.Label lVolumesEpisodes;
        private System.Windows.Forms.Label lTargetVolumesEpisodes;
        private System.Windows.Forms.Label lStatus;
        private System.Windows.Forms.Label lTargetStatus;
        private System.Windows.Forms.Label lPreview;
        private System.Windows.Forms.PictureBox pbLoadingPreview;
    }
}