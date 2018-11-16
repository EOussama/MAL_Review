namespace MAL_Reviewer_UI.user_controls
{
    partial class TextboxControl
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
            this.iconPictureBox = new System.Windows.Forms.PictureBox();
            this.inputTextBox = new System.Windows.Forms.TextBox();
            this.placeholderLabel = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.iconPictureBox)).BeginInit();
            this.SuspendLayout();
            // 
            // iconPictureBox
            // 
            this.iconPictureBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.iconPictureBox.Image = global::MAL_Reviewer_UI.Properties.Resources.icon_open;
            this.iconPictureBox.Location = new System.Drawing.Point(205, 5);
            this.iconPictureBox.Name = "iconPictureBox";
            this.iconPictureBox.Size = new System.Drawing.Size(22, 25);
            this.iconPictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.iconPictureBox.TabIndex = 8;
            this.iconPictureBox.TabStop = false;
            // 
            // inputTextBox
            // 
            this.inputTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.inputTextBox.BackColor = System.Drawing.SystemColors.Control;
            this.inputTextBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.inputTextBox.Font = new System.Drawing.Font("Bahnschrift Light", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.inputTextBox.Location = new System.Drawing.Point(8, 7);
            this.inputTextBox.Name = "inputTextBox";
            this.inputTextBox.Size = new System.Drawing.Size(191, 20);
            this.inputTextBox.TabIndex = 7;
            this.inputTextBox.Tag = "";
            this.inputTextBox.TextChanged += new System.EventHandler(this.InputTextBox_TextChanged);
            // 
            // placeholderLabel
            // 
            this.placeholderLabel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.placeholderLabel.AutoEllipsis = true;
            this.placeholderLabel.BackColor = System.Drawing.Color.Transparent;
            this.placeholderLabel.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.placeholderLabel.Font = new System.Drawing.Font("Bahnschrift Light", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.placeholderLabel.ForeColor = System.Drawing.SystemColors.ControlDark;
            this.placeholderLabel.Location = new System.Drawing.Point(5, 5);
            this.placeholderLabel.Margin = new System.Windows.Forms.Padding(0);
            this.placeholderLabel.Name = "placeholderLabel";
            this.placeholderLabel.Size = new System.Drawing.Size(194, 25);
            this.placeholderLabel.TabIndex = 9;
            this.placeholderLabel.Text = "Placeholder";
            this.placeholderLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.placeholderLabel.Click += new System.EventHandler(this.PlaceholderLabel_Click);
            // 
            // TextboxControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.placeholderLabel);
            this.Controls.Add(this.iconPictureBox);
            this.Controls.Add(this.inputTextBox);
            this.Name = "TextboxControl";
            this.Size = new System.Drawing.Size(232, 36);
            this.Tag = "0";
            this.Enter += new System.EventHandler(this.TextboxControl_Enter);
            this.Leave += new System.EventHandler(this.TextboxControl_Leave);
            ((System.ComponentModel.ISupportInitialize)(this.iconPictureBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox iconPictureBox;
        private System.Windows.Forms.TextBox inputTextBox;
        private System.Windows.Forms.Label placeholderLabel;
    }
}
