namespace MAL_Reviewer_UI.user_controls
{
    partial class PathBrowserControl
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
            this.PathTextbox = new System.Windows.Forms.TextBox();
            this.PathButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // PathTextbox
            // 
            this.PathTextbox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.PathTextbox.BackColor = System.Drawing.SystemColors.Control;
            this.PathTextbox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.PathTextbox.Font = new System.Drawing.Font("Consolas", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.PathTextbox.Location = new System.Drawing.Point(11, 11);
            this.PathTextbox.Name = "PathTextbox";
            this.PathTextbox.ReadOnly = true;
            this.PathTextbox.Size = new System.Drawing.Size(168, 19);
            this.PathTextbox.TabIndex = 0;
            // 
            // PathButton
            // 
            this.PathButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.PathButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.PathButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.PathButton.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.PathButton.Location = new System.Drawing.Point(190, 7);
            this.PathButton.Name = "PathButton";
            this.PathButton.Size = new System.Drawing.Size(78, 27);
            this.PathButton.TabIndex = 25;
            this.PathButton.Text = "Browse";
            this.PathButton.UseVisualStyleBackColor = true;
            this.PathButton.Click += new System.EventHandler(this.PathButton_Click);
            // 
            // PathBrowserControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.PathTextbox);
            this.Controls.Add(this.PathButton);
            this.MinimumSize = new System.Drawing.Size(275, 40);
            this.Name = "PathBrowserControl";
            this.Size = new System.Drawing.Size(275, 40);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox PathTextbox;
        private System.Windows.Forms.Button PathButton;
    }
}
