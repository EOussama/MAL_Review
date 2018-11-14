namespace MAL_Reviewer_UI.user_controls
{
    partial class ReviewTemplatePreviewCardControl
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
            this.components = new System.ComponentModel.Container();
            this.selectRadioButton = new System.Windows.Forms.RadioButton();
            this.containerPanel = new System.Windows.Forms.Panel();
            this.introLabel = new System.Windows.Forms.Label();
            this.tldrLabel = new System.Windows.Forms.Label();
            this.aspectsLabel = new System.Windows.Forms.Label();
            this.extraInfoTooltip = new System.Windows.Forms.ToolTip(this.components);
            this.containerPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // selectRadioButton
            // 
            this.selectRadioButton.AutoEllipsis = true;
            this.selectRadioButton.AutoSize = true;
            this.selectRadioButton.BackColor = System.Drawing.Color.Transparent;
            this.selectRadioButton.Font = new System.Drawing.Font("Bahnschrift", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.selectRadioButton.Location = new System.Drawing.Point(3, 3);
            this.selectRadioButton.Name = "selectRadioButton";
            this.selectRadioButton.Size = new System.Drawing.Size(112, 20);
            this.selectRadioButton.TabIndex = 0;
            this.selectRadioButton.TabStop = true;
            this.selectRadioButton.Text = "Template name";
            this.selectRadioButton.TextAlign = System.Drawing.ContentAlignment.TopLeft;
            this.selectRadioButton.UseVisualStyleBackColor = false;
            // 
            // containerPanel
            // 
            this.containerPanel.BackColor = System.Drawing.Color.Transparent;
            this.containerPanel.Controls.Add(this.introLabel);
            this.containerPanel.Controls.Add(this.tldrLabel);
            this.containerPanel.Controls.Add(this.aspectsLabel);
            this.containerPanel.Controls.Add(this.selectRadioButton);
            this.containerPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.containerPanel.Location = new System.Drawing.Point(10, 10);
            this.containerPanel.Name = "containerPanel";
            this.containerPanel.Size = new System.Drawing.Size(156, 118);
            this.containerPanel.TabIndex = 1;
            // 
            // introLabel
            // 
            this.introLabel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.introLabel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.introLabel.Font = new System.Drawing.Font("Bahnschrift Light", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.introLabel.Location = new System.Drawing.Point(11, 54);
            this.introLabel.Name = "introLabel";
            this.introLabel.Padding = new System.Windows.Forms.Padding(5);
            this.introLabel.Size = new System.Drawing.Size(134, 27);
            this.introLabel.TabIndex = 3;
            this.introLabel.Text = "Intro: false";
            this.introLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // tldrLabel
            // 
            this.tldrLabel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tldrLabel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tldrLabel.Font = new System.Drawing.Font("Bahnschrift Light", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tldrLabel.Location = new System.Drawing.Point(11, 82);
            this.tldrLabel.Name = "tldrLabel";
            this.tldrLabel.Padding = new System.Windows.Forms.Padding(5);
            this.tldrLabel.Size = new System.Drawing.Size(134, 27);
            this.tldrLabel.TabIndex = 2;
            this.tldrLabel.Text = "tl;dr: false";
            this.tldrLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // aspectsLabel
            // 
            this.aspectsLabel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.aspectsLabel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.aspectsLabel.Font = new System.Drawing.Font("Bahnschrift Light", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.aspectsLabel.Location = new System.Drawing.Point(11, 26);
            this.aspectsLabel.Name = "aspectsLabel";
            this.aspectsLabel.Padding = new System.Windows.Forms.Padding(5);
            this.aspectsLabel.Size = new System.Drawing.Size(134, 27);
            this.aspectsLabel.TabIndex = 1;
            this.aspectsLabel.Text = "Aspects: 6";
            this.aspectsLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // extraInfoTooltip
            // 
            this.extraInfoTooltip.ToolTipIcon = System.Windows.Forms.ToolTipIcon.Info;
            // 
            // ReviewTemplatePreviewCardControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlLight;
            this.Controls.Add(this.containerPanel);
            this.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Font = new System.Drawing.Font("Bahnschrift", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "ReviewTemplatePreviewCardControl";
            this.Padding = new System.Windows.Forms.Padding(10);
            this.Size = new System.Drawing.Size(176, 138);
            this.containerPanel.ResumeLayout(false);
            this.containerPanel.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.RadioButton selectRadioButton;
        private System.Windows.Forms.Panel containerPanel;
        private System.Windows.Forms.Label introLabel;
        private System.Windows.Forms.Label tldrLabel;
        private System.Windows.Forms.Label aspectsLabel;
        private System.Windows.Forms.ToolTip extraInfoTooltip;
    }
}
