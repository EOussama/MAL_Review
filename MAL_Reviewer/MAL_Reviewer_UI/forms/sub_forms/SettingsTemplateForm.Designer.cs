namespace MAL_Reviewer_UI.forms.sub_forms
{
    partial class SettingsTemplateForm
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
            this.contentPanel = new System.Windows.Forms.Panel();
            this.linePanel = new System.Windows.Forms.Panel();
            this.titleLabel = new System.Windows.Forms.Label();
            this.templateListBox = new System.Windows.Forms.ListBox();
            this.templateLabel = new System.Windows.Forms.Label();
            this.templatePreviewPanel = new System.Windows.Forms.Panel();
            this.templatePreviewLabel = new System.Windows.Forms.Label();
            this.templateAspectsPanel = new System.Windows.Forms.Panel();
            this.templateAspectsFlowPanel = new System.Windows.Forms.FlowLayoutPanel();
            this.templateIntroCheckBox = new System.Windows.Forms.CheckBox();
            this.templateTLDRCheckBox = new System.Windows.Forms.CheckBox();
            this.templateDeleteButton = new System.Windows.Forms.Button();
            this.templateUpdateButton = new System.Windows.Forms.Button();
            this.templateDefaultButton = new System.Windows.Forms.Button();
            this.contentPanel.SuspendLayout();
            this.templatePreviewPanel.SuspendLayout();
            this.templateAspectsPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // contentPanel
            // 
            this.contentPanel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.contentPanel.AutoScroll = true;
            this.contentPanel.Controls.Add(this.templatePreviewPanel);
            this.contentPanel.Controls.Add(this.templateLabel);
            this.contentPanel.Controls.Add(this.templateListBox);
            this.contentPanel.Location = new System.Drawing.Point(12, 94);
            this.contentPanel.Name = "contentPanel";
            this.contentPanel.Size = new System.Drawing.Size(635, 366);
            this.contentPanel.TabIndex = 8;
            // 
            // linePanel
            // 
            this.linePanel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.linePanel.BackColor = System.Drawing.SystemColors.ScrollBar;
            this.linePanel.Location = new System.Drawing.Point(12, 51);
            this.linePanel.Name = "linePanel";
            this.linePanel.Size = new System.Drawing.Size(635, 5);
            this.linePanel.TabIndex = 7;
            // 
            // titleLabel
            // 
            this.titleLabel.AutoSize = true;
            this.titleLabel.Font = new System.Drawing.Font("Bahnschrift", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.titleLabel.Location = new System.Drawing.Point(12, 15);
            this.titleLabel.Name = "titleLabel";
            this.titleLabel.Size = new System.Drawing.Size(175, 25);
            this.titleLabel.TabIndex = 6;
            this.titleLabel.Text = "Template settings";
            // 
            // templateListBox
            // 
            this.templateListBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.templateListBox.BackColor = System.Drawing.SystemColors.Control;
            this.templateListBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.templateListBox.Cursor = System.Windows.Forms.Cursors.Hand;
            this.templateListBox.Font = new System.Drawing.Font("Bahnschrift Light", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.templateListBox.FormattingEnabled = true;
            this.templateListBox.ItemHeight = 19;
            this.templateListBox.Location = new System.Drawing.Point(5, 32);
            this.templateListBox.Name = "templateListBox";
            this.templateListBox.Size = new System.Drawing.Size(239, 323);
            this.templateListBox.TabIndex = 0;
            // 
            // templateLabel
            // 
            this.templateLabel.AutoSize = true;
            this.templateLabel.Font = new System.Drawing.Font("Bahnschrift", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.templateLabel.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.templateLabel.Location = new System.Drawing.Point(1, 1);
            this.templateLabel.Name = "templateLabel";
            this.templateLabel.Size = new System.Drawing.Size(158, 19);
            this.templateLabel.TabIndex = 1;
            this.templateLabel.Text = "Review templates [x]";
            // 
            // templatePreviewPanel
            // 
            this.templatePreviewPanel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.templatePreviewPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.templatePreviewPanel.Controls.Add(this.templateDefaultButton);
            this.templatePreviewPanel.Controls.Add(this.templateUpdateButton);
            this.templatePreviewPanel.Controls.Add(this.templateDeleteButton);
            this.templatePreviewPanel.Controls.Add(this.templateTLDRCheckBox);
            this.templatePreviewPanel.Controls.Add(this.templateIntroCheckBox);
            this.templatePreviewPanel.Controls.Add(this.templateAspectsPanel);
            this.templatePreviewPanel.Controls.Add(this.templatePreviewLabel);
            this.templatePreviewPanel.Location = new System.Drawing.Point(393, 32);
            this.templatePreviewPanel.Name = "templatePreviewPanel";
            this.templatePreviewPanel.Size = new System.Drawing.Size(239, 323);
            this.templatePreviewPanel.TabIndex = 2;
            // 
            // templatePreviewLabel
            // 
            this.templatePreviewLabel.AutoEllipsis = true;
            this.templatePreviewLabel.Dock = System.Windows.Forms.DockStyle.Top;
            this.templatePreviewLabel.Font = new System.Drawing.Font("Bahnschrift", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.templatePreviewLabel.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.templatePreviewLabel.Location = new System.Drawing.Point(0, 0);
            this.templatePreviewLabel.Name = "templatePreviewLabel";
            this.templatePreviewLabel.Size = new System.Drawing.Size(237, 46);
            this.templatePreviewLabel.TabIndex = 3;
            this.templatePreviewLabel.Text = "Template name";
            this.templatePreviewLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // templateAspectsPanel
            // 
            this.templateAspectsPanel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.templateAspectsPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.templateAspectsPanel.Controls.Add(this.templateAspectsFlowPanel);
            this.templateAspectsPanel.Location = new System.Drawing.Point(17, 78);
            this.templateAspectsPanel.Name = "templateAspectsPanel";
            this.templateAspectsPanel.Size = new System.Drawing.Size(205, 125);
            this.templateAspectsPanel.TabIndex = 4;
            // 
            // templateAspectsFlowPanel
            // 
            this.templateAspectsFlowPanel.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.templateAspectsFlowPanel.Location = new System.Drawing.Point(0, 40);
            this.templateAspectsFlowPanel.Name = "templateAspectsFlowPanel";
            this.templateAspectsFlowPanel.Size = new System.Drawing.Size(203, 83);
            this.templateAspectsFlowPanel.TabIndex = 3;
            // 
            // templateIntroCheckBox
            // 
            this.templateIntroCheckBox.AutoSize = true;
            this.templateIntroCheckBox.Location = new System.Drawing.Point(17, 221);
            this.templateIntroCheckBox.Name = "templateIntroCheckBox";
            this.templateIntroCheckBox.Size = new System.Drawing.Size(102, 17);
            this.templateIntroCheckBox.TabIndex = 5;
            this.templateIntroCheckBox.Text = "Add review intro";
            this.templateIntroCheckBox.UseVisualStyleBackColor = true;
            // 
            // templateTLDRCheckBox
            // 
            this.templateTLDRCheckBox.AutoSize = true;
            this.templateTLDRCheckBox.Location = new System.Drawing.Point(17, 251);
            this.templateTLDRCheckBox.Name = "templateTLDRCheckBox";
            this.templateTLDRCheckBox.Size = new System.Drawing.Size(65, 17);
            this.templateTLDRCheckBox.TabIndex = 6;
            this.templateTLDRCheckBox.Text = "Add tl:dr";
            this.templateTLDRCheckBox.UseVisualStyleBackColor = true;
            // 
            // templateDeleteButton
            // 
            this.templateDeleteButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.templateDeleteButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.templateDeleteButton.Enabled = false;
            this.templateDeleteButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.templateDeleteButton.Location = new System.Drawing.Point(159, 291);
            this.templateDeleteButton.Name = "templateDeleteButton";
            this.templateDeleteButton.Size = new System.Drawing.Size(75, 27);
            this.templateDeleteButton.TabIndex = 16;
            this.templateDeleteButton.Text = "Delete";
            this.templateDeleteButton.UseVisualStyleBackColor = true;
            // 
            // templateUpdateButton
            // 
            this.templateUpdateButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.templateUpdateButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.templateUpdateButton.Enabled = false;
            this.templateUpdateButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.templateUpdateButton.Location = new System.Drawing.Point(81, 291);
            this.templateUpdateButton.Name = "templateUpdateButton";
            this.templateUpdateButton.Size = new System.Drawing.Size(75, 27);
            this.templateUpdateButton.TabIndex = 17;
            this.templateUpdateButton.Text = "Update";
            this.templateUpdateButton.UseVisualStyleBackColor = true;
            // 
            // templateDefaultButton
            // 
            this.templateDefaultButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.templateDefaultButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.templateDefaultButton.Enabled = false;
            this.templateDefaultButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.templateDefaultButton.Location = new System.Drawing.Point(3, 291);
            this.templateDefaultButton.Name = "templateDefaultButton";
            this.templateDefaultButton.Size = new System.Drawing.Size(75, 27);
            this.templateDefaultButton.TabIndex = 18;
            this.templateDefaultButton.Text = "Default";
            this.templateDefaultButton.UseVisualStyleBackColor = true;
            // 
            // SettingsTemplateForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlLight;
            this.ClientSize = new System.Drawing.Size(659, 473);
            this.Controls.Add(this.contentPanel);
            this.Controls.Add(this.linePanel);
            this.Controls.Add(this.titleLabel);
            this.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "SettingsTemplateForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "SettingsTemplateForm";
            this.contentPanel.ResumeLayout(false);
            this.contentPanel.PerformLayout();
            this.templatePreviewPanel.ResumeLayout(false);
            this.templatePreviewPanel.PerformLayout();
            this.templateAspectsPanel.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel contentPanel;
        private System.Windows.Forms.Panel linePanel;
        private System.Windows.Forms.Label titleLabel;
        private System.Windows.Forms.ListBox templateListBox;
        private System.Windows.Forms.Label templateLabel;
        private System.Windows.Forms.Panel templatePreviewPanel;
        private System.Windows.Forms.Label templatePreviewLabel;
        private System.Windows.Forms.Panel templateAspectsPanel;
        private System.Windows.Forms.FlowLayoutPanel templateAspectsFlowPanel;
        private System.Windows.Forms.CheckBox templateTLDRCheckBox;
        private System.Windows.Forms.CheckBox templateIntroCheckBox;
        private System.Windows.Forms.Button templateDefaultButton;
        private System.Windows.Forms.Button templateUpdateButton;
        private System.Windows.Forms.Button templateDeleteButton;
    }
}