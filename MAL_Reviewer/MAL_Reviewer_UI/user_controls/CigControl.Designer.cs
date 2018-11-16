namespace MAL_Reviewer_UI.user_controls
{
    partial class CigControl
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
            this.cigLabel = new System.Windows.Forms.Label();
            this.closeLabel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // cigLabel
            // 
            this.cigLabel.AutoSize = true;
            this.cigLabel.BackColor = System.Drawing.Color.Transparent;
            this.cigLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cigLabel.Font = new System.Drawing.Font("Bahnschrift Light", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cigLabel.Location = new System.Drawing.Point(0, 0);
            this.cigLabel.Name = "cigLabel";
            this.cigLabel.Padding = new System.Windows.Forms.Padding(5);
            this.cigLabel.Size = new System.Drawing.Size(44, 23);
            this.cigLabel.TabIndex = 0;
            this.cigLabel.Text = "Label";
            this.cigLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // closeLabel
            // 
            this.closeLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.closeLabel.AutoSize = true;
            this.closeLabel.BackColor = System.Drawing.Color.Transparent;
            this.closeLabel.Cursor = System.Windows.Forms.Cursors.Hand;
            this.closeLabel.Font = new System.Drawing.Font("Bahnschrift Light", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.closeLabel.ForeColor = System.Drawing.SystemColors.ControlDark;
            this.closeLabel.Location = new System.Drawing.Point(33, 0);
            this.closeLabel.Name = "closeLabel";
            this.closeLabel.Size = new System.Drawing.Size(13, 13);
            this.closeLabel.TabIndex = 1;
            this.closeLabel.Text = "x";
            this.closeLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.closeLabel.Click += new System.EventHandler(this.CloseLabel_Click);
            this.closeLabel.MouseEnter += new System.EventHandler(this.CloseLabel_MouseEnter);
            this.closeLabel.MouseLeave += new System.EventHandler(this.CloseLabel_MouseLeave);
            // 
            // CigControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Controls.Add(this.closeLabel);
            this.Controls.Add(this.cigLabel);
            this.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Name = "CigControl";
            this.Padding = new System.Windows.Forms.Padding(0, 0, 2, 0);
            this.Size = new System.Drawing.Size(46, 23);
            this.MouseEnter += new System.EventHandler(this.CigControl_MouseEnter);
            this.MouseLeave += new System.EventHandler(this.CigControl_MouseLeave);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label cigLabel;
        private System.Windows.Forms.Label closeLabel;
    }
}
