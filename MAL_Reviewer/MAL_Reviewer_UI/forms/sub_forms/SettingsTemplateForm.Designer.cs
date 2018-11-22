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
            this.components = new System.ComponentModel.Container();
            this.contentPanel = new System.Windows.Forms.Panel();
            this.reviewTemplateClearButton = new System.Windows.Forms.Button();
            this.templatePreviewPanel = new System.Windows.Forms.Panel();
            this.noPreviewLabel = new System.Windows.Forms.Label();
            this.templatePreviewRichTextBox = new System.Windows.Forms.RichTextBox();
            this.editDateLabel = new System.Windows.Forms.Label();
            this.creationDateLabel = new System.Windows.Forms.Label();
            this.templateDefaultButton = new System.Windows.Forms.Button();
            this.templateUpdateButton = new System.Windows.Forms.Button();
            this.templateDeleteButton = new System.Windows.Forms.Button();
            this.templateTLDRCheckBox = new System.Windows.Forms.CheckBox();
            this.templateIntroCheckBox = new System.Windows.Forms.CheckBox();
            this.templateAspectsPanel = new System.Windows.Forms.Panel();
            this.aspectsTextBox = new MAL_Reviewer_UI.user_controls.TextboxControl();
            this.templateAspectsFlowPanel = new System.Windows.Forms.FlowLayoutPanel();
            this.templateLabel = new System.Windows.Forms.Label();
            this.templateListBox = new System.Windows.Forms.ListBox();
            this.linePanel = new System.Windows.Forms.Panel();
            this.titleLabel = new System.Windows.Forms.Label();
            this.reviewTemplateTooltip = new System.Windows.Forms.ToolTip(this.components);
            this.reviewTemplateCreateButton = new System.Windows.Forms.Button();
            this.reviewTemplateSettingsResetButton = new System.Windows.Forms.Button();
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
            this.contentPanel.Controls.Add(this.reviewTemplateClearButton);
            this.contentPanel.Controls.Add(this.templatePreviewPanel);
            this.contentPanel.Controls.Add(this.templateLabel);
            this.contentPanel.Controls.Add(this.templateListBox);
            this.contentPanel.Location = new System.Drawing.Point(12, 94);
            this.contentPanel.Name = "contentPanel";
            this.contentPanel.Size = new System.Drawing.Size(512, 366);
            this.contentPanel.TabIndex = 8;
            // 
            // reviewTemplateClearButton
            // 
            this.reviewTemplateClearButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.reviewTemplateClearButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.reviewTemplateClearButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.reviewTemplateClearButton.Location = new System.Drawing.Point(268, 2);
            this.reviewTemplateClearButton.Name = "reviewTemplateClearButton";
            this.reviewTemplateClearButton.Size = new System.Drawing.Size(118, 27);
            this.reviewTemplateClearButton.TabIndex = 22;
            this.reviewTemplateClearButton.Text = "Clear all";
            this.reviewTemplateClearButton.UseVisualStyleBackColor = true;
            this.reviewTemplateClearButton.Click += new System.EventHandler(this.ReviewTemplateClearButton_Click);
            // 
            // templatePreviewPanel
            // 
            this.templatePreviewPanel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.templatePreviewPanel.BackColor = System.Drawing.SystemColors.ControlLight;
            this.templatePreviewPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.templatePreviewPanel.Controls.Add(this.noPreviewLabel);
            this.templatePreviewPanel.Controls.Add(this.templatePreviewRichTextBox);
            this.templatePreviewPanel.Controls.Add(this.editDateLabel);
            this.templatePreviewPanel.Controls.Add(this.creationDateLabel);
            this.templatePreviewPanel.Controls.Add(this.templateDefaultButton);
            this.templatePreviewPanel.Controls.Add(this.templateUpdateButton);
            this.templatePreviewPanel.Controls.Add(this.templateDeleteButton);
            this.templatePreviewPanel.Controls.Add(this.templateTLDRCheckBox);
            this.templatePreviewPanel.Controls.Add(this.templateIntroCheckBox);
            this.templatePreviewPanel.Controls.Add(this.templateAspectsPanel);
            this.templatePreviewPanel.Location = new System.Drawing.Point(268, 32);
            this.templatePreviewPanel.Name = "templatePreviewPanel";
            this.templatePreviewPanel.Size = new System.Drawing.Size(239, 323);
            this.templatePreviewPanel.TabIndex = 2;
            // 
            // noPreviewLabel
            // 
            this.noPreviewLabel.AutoSize = true;
            this.noPreviewLabel.Font = new System.Drawing.Font("Bahnschrift", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.noPreviewLabel.ForeColor = System.Drawing.SystemColors.ControlDark;
            this.noPreviewLabel.Location = new System.Drawing.Point(28, 51);
            this.noPreviewLabel.Name = "noPreviewLabel";
            this.noPreviewLabel.Size = new System.Drawing.Size(190, 16);
            this.noPreviewLabel.TabIndex = 21;
            this.noPreviewLabel.Text = "No review templates to preview.";
            this.noPreviewLabel.Visible = false;
            // 
            // templatePreviewRichTextBox
            // 
            this.templatePreviewRichTextBox.BackColor = System.Drawing.SystemColors.ScrollBar;
            this.templatePreviewRichTextBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.templatePreviewRichTextBox.Dock = System.Windows.Forms.DockStyle.Top;
            this.templatePreviewRichTextBox.Font = new System.Drawing.Font("Bahnschrift", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.templatePreviewRichTextBox.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.templatePreviewRichTextBox.Location = new System.Drawing.Point(0, 0);
            this.templatePreviewRichTextBox.Name = "templatePreviewRichTextBox";
            this.templatePreviewRichTextBox.Size = new System.Drawing.Size(237, 48);
            this.templatePreviewRichTextBox.TabIndex = 3;
            this.templatePreviewRichTextBox.Text = "Template Name";
            // 
            // editDateLabel
            // 
            this.editDateLabel.AutoSize = true;
            this.editDateLabel.Cursor = System.Windows.Forms.Cursors.Help;
            this.editDateLabel.Font = new System.Drawing.Font("Bahnschrift Light", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.editDateLabel.ForeColor = System.Drawing.SystemColors.ControlDark;
            this.editDateLabel.Location = new System.Drawing.Point(15, 263);
            this.editDateLabel.Name = "editDateLabel";
            this.editDateLabel.Size = new System.Drawing.Size(117, 13);
            this.editDateLabel.TabIndex = 20;
            this.editDateLabel.Text = "Last modified on [date]";
            // 
            // creationDateLabel
            // 
            this.creationDateLabel.AutoSize = true;
            this.creationDateLabel.Cursor = System.Windows.Forms.Cursors.Help;
            this.creationDateLabel.Font = new System.Drawing.Font("Bahnschrift Light", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.creationDateLabel.ForeColor = System.Drawing.SystemColors.ControlDark;
            this.creationDateLabel.Location = new System.Drawing.Point(15, 241);
            this.creationDateLabel.Name = "creationDateLabel";
            this.creationDateLabel.Size = new System.Drawing.Size(91, 13);
            this.creationDateLabel.TabIndex = 19;
            this.creationDateLabel.Text = "Created on [date]";
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
            this.templateDefaultButton.Click += new System.EventHandler(this.ReviewTemplateDefaultButton_Click);
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
            this.templateUpdateButton.Click += new System.EventHandler(this.ReviewTemplateUpdateButton_Click);
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
            this.templateDeleteButton.Click += new System.EventHandler(this.ReviewTemplateDeleteButton_Click);
            // 
            // templateTLDRCheckBox
            // 
            this.templateTLDRCheckBox.AutoSize = true;
            this.templateTLDRCheckBox.Font = new System.Drawing.Font("Bahnschrift Light", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.templateTLDRCheckBox.Location = new System.Drawing.Point(154, 206);
            this.templateTLDRCheckBox.Name = "templateTLDRCheckBox";
            this.templateTLDRCheckBox.Size = new System.Drawing.Size(67, 17);
            this.templateTLDRCheckBox.TabIndex = 6;
            this.templateTLDRCheckBox.Text = "Add tl:dr";
            this.templateTLDRCheckBox.UseVisualStyleBackColor = true;
            // 
            // templateIntroCheckBox
            // 
            this.templateIntroCheckBox.AutoSize = true;
            this.templateIntroCheckBox.Font = new System.Drawing.Font("Bahnschrift Light", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.templateIntroCheckBox.Location = new System.Drawing.Point(17, 206);
            this.templateIntroCheckBox.Name = "templateIntroCheckBox";
            this.templateIntroCheckBox.Size = new System.Drawing.Size(108, 17);
            this.templateIntroCheckBox.TabIndex = 5;
            this.templateIntroCheckBox.Text = "Add review intro";
            this.templateIntroCheckBox.UseVisualStyleBackColor = true;
            // 
            // templateAspectsPanel
            // 
            this.templateAspectsPanel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.templateAspectsPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.templateAspectsPanel.Controls.Add(this.aspectsTextBox);
            this.templateAspectsPanel.Controls.Add(this.templateAspectsFlowPanel);
            this.templateAspectsPanel.Location = new System.Drawing.Point(17, 66);
            this.templateAspectsPanel.Name = "templateAspectsPanel";
            this.templateAspectsPanel.Size = new System.Drawing.Size(205, 125);
            this.templateAspectsPanel.TabIndex = 4;
            // 
            // aspectsTextBox
            // 
            this.aspectsTextBox.AllowLoad = false;
            this.aspectsTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.aspectsTextBox.AutoSubmit = false;
            this.aspectsTextBox.BackColor = System.Drawing.SystemColors.ControlLight;
            this.aspectsTextBox.BackgroundColor = System.Drawing.SystemColors.ControlLight;
            this.aspectsTextBox.Icon = global::MAL_Reviewer_UI.Properties.Resources.icon_add;
            this.aspectsTextBox.InnerText = "";
            this.aspectsTextBox.Location = new System.Drawing.Point(-1, -1);
            this.aspectsTextBox.Name = "aspectsTextBox";
            this.aspectsTextBox.Placeholder = "Aspect name...";
            this.aspectsTextBox.PlaceholderColor = System.Drawing.SystemColors.ControlDark;
            this.aspectsTextBox.Size = new System.Drawing.Size(205, 36);
            this.aspectsTextBox.SubmitMin = 3;
            this.aspectsTextBox.TabIndex = 3;
            this.aspectsTextBox.Tag = "0";
            this.aspectsTextBox.ToggleIcon = true;
            // 
            // templateAspectsFlowPanel
            // 
            this.templateAspectsFlowPanel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.templateAspectsFlowPanel.AutoScroll = true;
            this.templateAspectsFlowPanel.BackColor = System.Drawing.SystemColors.Control;
            this.templateAspectsFlowPanel.Location = new System.Drawing.Point(0, 35);
            this.templateAspectsFlowPanel.Name = "templateAspectsFlowPanel";
            this.templateAspectsFlowPanel.Size = new System.Drawing.Size(203, 88);
            this.templateAspectsFlowPanel.TabIndex = 3;
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
            // templateListBox
            // 
            this.templateListBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.templateListBox.BackColor = System.Drawing.SystemColors.ControlLight;
            this.templateListBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.templateListBox.Cursor = System.Windows.Forms.Cursors.Hand;
            this.templateListBox.Font = new System.Drawing.Font("Bahnschrift Light", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.templateListBox.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.templateListBox.FormattingEnabled = true;
            this.templateListBox.ItemHeight = 19;
            this.templateListBox.Location = new System.Drawing.Point(5, 30);
            this.templateListBox.Name = "templateListBox";
            this.templateListBox.Size = new System.Drawing.Size(239, 325);
            this.templateListBox.TabIndex = 0;
            this.templateListBox.SelectedIndexChanged += new System.EventHandler(this.TemplateListBox_SelectedIndexChanged);
            // 
            // linePanel
            // 
            this.linePanel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.linePanel.BackColor = System.Drawing.SystemColors.ScrollBar;
            this.linePanel.Location = new System.Drawing.Point(12, 51);
            this.linePanel.Name = "linePanel";
            this.linePanel.Size = new System.Drawing.Size(512, 5);
            this.linePanel.TabIndex = 7;
            // 
            // titleLabel
            // 
            this.titleLabel.AutoSize = true;
            this.titleLabel.Font = new System.Drawing.Font("Bahnschrift", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.titleLabel.Location = new System.Drawing.Point(12, 15);
            this.titleLabel.Name = "titleLabel";
            this.titleLabel.Size = new System.Drawing.Size(245, 25);
            this.titleLabel.TabIndex = 6;
            this.titleLabel.Text = "Review template settings";
            // 
            // reviewTemplateCreateButton
            // 
            this.reviewTemplateCreateButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.reviewTemplateCreateButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.reviewTemplateCreateButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.reviewTemplateCreateButton.Location = new System.Drawing.Point(401, 96);
            this.reviewTemplateCreateButton.Name = "reviewTemplateCreateButton";
            this.reviewTemplateCreateButton.Size = new System.Drawing.Size(118, 27);
            this.reviewTemplateCreateButton.TabIndex = 21;
            this.reviewTemplateCreateButton.Text = "Create a new review template";
            this.reviewTemplateCreateButton.UseVisualStyleBackColor = true;
            this.reviewTemplateCreateButton.Click += new System.EventHandler(this.ReviewTemplateCreateButton_Click);
            // 
            // reviewTemplateSettingsResetButton
            // 
            this.reviewTemplateSettingsResetButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.reviewTemplateSettingsResetButton.BackColor = System.Drawing.SystemColors.ScrollBar;
            this.reviewTemplateSettingsResetButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.reviewTemplateSettingsResetButton.FlatAppearance.BorderSize = 0;
            this.reviewTemplateSettingsResetButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.reviewTemplateSettingsResetButton.Font = new System.Drawing.Font("Bahnschrift Light", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.reviewTemplateSettingsResetButton.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.reviewTemplateSettingsResetButton.Location = new System.Drawing.Point(432, 12);
            this.reviewTemplateSettingsResetButton.Name = "reviewTemplateSettingsResetButton";
            this.reviewTemplateSettingsResetButton.Size = new System.Drawing.Size(92, 33);
            this.reviewTemplateSettingsResetButton.TabIndex = 23;
            this.reviewTemplateSettingsResetButton.Text = "Reset settings";
            this.reviewTemplateSettingsResetButton.UseVisualStyleBackColor = false;
            this.reviewTemplateSettingsResetButton.Click += new System.EventHandler(this.ReviewTemplateSettingsResetButton_Click);
            // 
            // SettingsTemplateForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.BackColor = System.Drawing.SystemColors.ControlLight;
            this.ClientSize = new System.Drawing.Size(536, 473);
            this.Controls.Add(this.reviewTemplateSettingsResetButton);
            this.Controls.Add(this.reviewTemplateCreateButton);
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
        private System.Windows.Forms.Panel templateAspectsPanel;
        private System.Windows.Forms.FlowLayoutPanel templateAspectsFlowPanel;
        private System.Windows.Forms.CheckBox templateTLDRCheckBox;
        private System.Windows.Forms.CheckBox templateIntroCheckBox;
        private System.Windows.Forms.Button templateDefaultButton;
        private System.Windows.Forms.Button templateUpdateButton;
        private System.Windows.Forms.Button templateDeleteButton;
        private user_controls.TextboxControl aspectsTextBox;
        private System.Windows.Forms.Label editDateLabel;
        private System.Windows.Forms.Label creationDateLabel;
        private System.Windows.Forms.ToolTip reviewTemplateTooltip;
        private System.Windows.Forms.RichTextBox templatePreviewRichTextBox;
        private System.Windows.Forms.Button reviewTemplateCreateButton;
        private System.Windows.Forms.Label noPreviewLabel;
        private System.Windows.Forms.Button reviewTemplateClearButton;
        private System.Windows.Forms.Button reviewTemplateSettingsResetButton;
    }
}