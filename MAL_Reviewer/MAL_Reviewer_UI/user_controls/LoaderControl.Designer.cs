namespace MAL_Reviewer_UI.user_controls
{
    partial class LoaderControl
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
            this.LoaderPictureBox = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.LoaderPictureBox)).BeginInit();
            this.SuspendLayout();
            // 
            // LoaderPictureBox
            // 
            this.LoaderPictureBox.BackColor = System.Drawing.Color.Transparent;
            this.LoaderPictureBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.LoaderPictureBox.Image = global::MAL_Reviewer_UI.Properties.Resources.loading_gif_white;
            this.LoaderPictureBox.Location = new System.Drawing.Point(0, 0);
            this.LoaderPictureBox.Name = "LoaderPictureBox";
            this.LoaderPictureBox.Size = new System.Drawing.Size(30, 30);
            this.LoaderPictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.LoaderPictureBox.TabIndex = 3;
            this.LoaderPictureBox.TabStop = false;
            // 
            // LoaderControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Transparent;
            this.Controls.Add(this.LoaderPictureBox);
            this.Name = "LoaderControl";
            this.Size = new System.Drawing.Size(30, 30);
            ((System.ComponentModel.ISupportInitialize)(this.LoaderPictureBox)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox LoaderPictureBox;
    }
}
