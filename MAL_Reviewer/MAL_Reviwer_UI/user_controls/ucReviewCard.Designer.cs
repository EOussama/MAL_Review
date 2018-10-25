namespace MAL_Reviwer_UI.user_controls
{
    partial class ucReviewCard
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.pScore = new System.Windows.Forms.Panel();
            this.lScore = new System.Windows.Forms.Label();
            this.lScoreDec = new System.Windows.Forms.Label();
            this.lTitle = new System.Windows.Forms.Label();
            this.lType = new System.Windows.Forms.Label();
            this.bLink = new System.Windows.Forms.Button();
            this.bRemove = new System.Windows.Forms.Button();
            this.pScore.SuspendLayout();
            this.SuspendLayout();
            // 
            // pScore
            // 
            this.pScore.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pScore.Controls.Add(this.lScoreDec);
            this.pScore.Controls.Add(this.lScore);
            this.pScore.Location = new System.Drawing.Point(3, 3);
            this.pScore.Name = "pScore";
            this.pScore.Size = new System.Drawing.Size(80, 80);
            this.pScore.TabIndex = 0;
            // 
            // lScore
            // 
            this.lScore.Font = new System.Drawing.Font("Bahnschrift", 36F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lScore.Location = new System.Drawing.Point(-1, -1);
            this.lScore.Name = "lScore";
            this.lScore.Size = new System.Drawing.Size(80, 79);
            this.lScore.TabIndex = 0;
            this.lScore.Text = "8";
            this.lScore.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lScoreDec
            // 
            this.lScoreDec.AutoSize = true;
            this.lScoreDec.Font = new System.Drawing.Font("Bahnschrift", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lScoreDec.Location = new System.Drawing.Point(48, 17);
            this.lScoreDec.Name = "lScoreDec";
            this.lScoreDec.Size = new System.Drawing.Size(26, 19);
            this.lScoreDec.TabIndex = 1;
            this.lScoreDec.Text = "35";
            // 
            // lTitle
            // 
            this.lTitle.AutoSize = true;
            this.lTitle.Font = new System.Drawing.Font("Bahnschrift SemiBold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lTitle.Location = new System.Drawing.Point(84, 3);
            this.lTitle.Name = "lTitle";
            this.lTitle.Size = new System.Drawing.Size(65, 19);
            this.lTitle.TabIndex = 1;
            this.lTitle.Text = "Paprika";
            // 
            // lType
            // 
            this.lType.AutoSize = true;
            this.lType.Location = new System.Drawing.Point(86, 25);
            this.lType.Name = "lType";
            this.lType.Size = new System.Drawing.Size(36, 13);
            this.lType.TabIndex = 2;
            this.lType.Text = "Movie";
            // 
            // bLink
            // 
            this.bLink.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.bLink.BackColor = System.Drawing.Color.Transparent;
            this.bLink.BackgroundImage = global::MAL_Reviwer_UI.Properties.Resources.icon_link;
            this.bLink.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.bLink.Cursor = System.Windows.Forms.Cursors.Hand;
            this.bLink.FlatAppearance.BorderSize = 0;
            this.bLink.FlatAppearance.MouseDownBackColor = System.Drawing.Color.White;
            this.bLink.FlatAppearance.MouseOverBackColor = System.Drawing.Color.WhiteSmoke;
            this.bLink.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.bLink.ImageKey = "(none)";
            this.bLink.Location = new System.Drawing.Point(201, 3);
            this.bLink.Name = "bLink";
            this.bLink.Size = new System.Drawing.Size(10, 10);
            this.bLink.TabIndex = 8;
            this.bLink.UseVisualStyleBackColor = false;
            // 
            // bRemove
            // 
            this.bRemove.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.bRemove.BackColor = System.Drawing.Color.Transparent;
            this.bRemove.BackgroundImage = global::MAL_Reviwer_UI.Properties.Resources.icon_close;
            this.bRemove.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.bRemove.Cursor = System.Windows.Forms.Cursors.Hand;
            this.bRemove.FlatAppearance.BorderSize = 0;
            this.bRemove.FlatAppearance.MouseDownBackColor = System.Drawing.Color.White;
            this.bRemove.FlatAppearance.MouseOverBackColor = System.Drawing.Color.WhiteSmoke;
            this.bRemove.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.bRemove.ImageKey = "(none)";
            this.bRemove.Location = new System.Drawing.Point(217, 3);
            this.bRemove.Name = "bRemove";
            this.bRemove.Size = new System.Drawing.Size(10, 10);
            this.bRemove.TabIndex = 7;
            this.bRemove.UseVisualStyleBackColor = false;
            // 
            // ucReviewCard
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.bLink);
            this.Controls.Add(this.bRemove);
            this.Controls.Add(this.lType);
            this.Controls.Add(this.lTitle);
            this.Controls.Add(this.pScore);
            this.Name = "ucReviewCard";
            this.Size = new System.Drawing.Size(230, 86);
            this.pScore.ResumeLayout(false);
            this.pScore.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel pScore;
        private System.Windows.Forms.Label lScoreDec;
        private System.Windows.Forms.Label lScore;
        private System.Windows.Forms.Label lTitle;
        private System.Windows.Forms.Label lType;
        private System.Windows.Forms.Button bRemove;
        private System.Windows.Forms.Button bLink;
    }
}
