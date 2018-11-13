namespace MAL_Reviewer_UI.forms
{
    partial class LoadUserForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(LoadUserForm));
            this.lTitle = new System.Windows.Forms.Label();
            this.pMALUsername = new System.Windows.Forms.Panel();
            this.tbMALUsername = new System.Windows.Forms.TextBox();
            this.pTopSeparator = new System.Windows.Forms.Panel();
            this.bLoad = new System.Windows.Forms.Button();
            this.llNoAcc = new System.Windows.Forms.LinkLabel();
            this.lDisclaimer = new System.Windows.Forms.Label();
            this.pBottomSeparator = new System.Windows.Forms.Panel();
            this.pbLogo = new System.Windows.Forms.PictureBox();
            this.pbLoading = new System.Windows.Forms.PictureBox();
            this.pbSearch = new System.Windows.Forms.PictureBox();
            this.textboxControl1 = new MAL_Reviewer_UI.user_controls.TextboxControl();
            this.textboxControl2 = new MAL_Reviewer_UI.user_controls.TextboxControl();
            this.pMALUsername.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbLogo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbLoading)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbSearch)).BeginInit();
            this.SuspendLayout();
            // 
            // lTitle
            // 
            this.lTitle.AutoSize = true;
            this.lTitle.Font = new System.Drawing.Font("Bahnschrift SemiBold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lTitle.Location = new System.Drawing.Point(47, 164);
            this.lTitle.Name = "lTitle";
            this.lTitle.Size = new System.Drawing.Size(192, 19);
            this.lTitle.TabIndex = 0;
            this.lTitle.Text = "Input your MAL username";
            // 
            // pMALUsername
            // 
            this.pMALUsername.BackColor = System.Drawing.SystemColors.ControlLight;
            this.pMALUsername.Controls.Add(this.pbLoading);
            this.pMALUsername.Controls.Add(this.pbSearch);
            this.pMALUsername.Controls.Add(this.tbMALUsername);
            this.pMALUsername.Location = new System.Drawing.Point(51, 186);
            this.pMALUsername.Name = "pMALUsername";
            this.pMALUsername.Size = new System.Drawing.Size(230, 35);
            this.pMALUsername.TabIndex = 3;
            // 
            // tbMALUsername
            // 
            this.tbMALUsername.BackColor = System.Drawing.SystemColors.ControlLight;
            this.tbMALUsername.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.tbMALUsername.Font = new System.Drawing.Font("Bahnschrift Light", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbMALUsername.Location = new System.Drawing.Point(9, 7);
            this.tbMALUsername.Name = "tbMALUsername";
            this.tbMALUsername.Size = new System.Drawing.Size(188, 20);
            this.tbMALUsername.TabIndex = 0;
            // 
            // pTopSeparator
            // 
            this.pTopSeparator.BackColor = System.Drawing.SystemColors.ControlLight;
            this.pTopSeparator.Location = new System.Drawing.Point(38, 138);
            this.pTopSeparator.Name = "pTopSeparator";
            this.pTopSeparator.Size = new System.Drawing.Size(257, 6);
            this.pTopSeparator.TabIndex = 5;
            // 
            // bLoad
            // 
            this.bLoad.Cursor = System.Windows.Forms.Cursors.Hand;
            this.bLoad.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.bLoad.Location = new System.Drawing.Point(182, 250);
            this.bLoad.Name = "bLoad";
            this.bLoad.Size = new System.Drawing.Size(99, 31);
            this.bLoad.TabIndex = 2;
            this.bLoad.Text = "Load";
            this.bLoad.UseVisualStyleBackColor = true;
            this.bLoad.Click += new System.EventHandler(this.BLoad_Click);
            // 
            // llNoAcc
            // 
            this.llNoAcc.LinkVisited = true;
            this.llNoAcc.Location = new System.Drawing.Point(51, 224);
            this.llNoAcc.Name = "llNoAcc";
            this.llNoAcc.Size = new System.Drawing.Size(230, 23);
            this.llNoAcc.TabIndex = 1;
            this.llNoAcc.TabStop = true;
            this.llNoAcc.Text = "You don\'t have a MAL account? create one.";
            this.llNoAcc.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.llNoAcc.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.LlNoAcc_LinkClicked);
            // 
            // lDisclaimer
            // 
            this.lDisclaimer.Font = new System.Drawing.Font("Bahnschrift Light", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lDisclaimer.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.lDisclaimer.Location = new System.Drawing.Point(38, 332);
            this.lDisclaimer.Name = "lDisclaimer";
            this.lDisclaimer.Size = new System.Drawing.Size(257, 109);
            this.lDisclaimer.TabIndex = 16;
            this.lDisclaimer.Text = resources.GetString("lDisclaimer.Text");
            this.lDisclaimer.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // pBottomSeparator
            // 
            this.pBottomSeparator.BackColor = System.Drawing.SystemColors.ControlLight;
            this.pBottomSeparator.Location = new System.Drawing.Point(38, 305);
            this.pBottomSeparator.Name = "pBottomSeparator";
            this.pBottomSeparator.Size = new System.Drawing.Size(257, 6);
            this.pBottomSeparator.TabIndex = 6;
            // 
            // pbLogo
            // 
            this.pbLogo.Image = global::MAL_Reviewer_UI.Properties.Resources.logo;
            this.pbLogo.Location = new System.Drawing.Point(12, 19);
            this.pbLogo.Name = "pbLogo";
            this.pbLogo.Size = new System.Drawing.Size(310, 96);
            this.pbLogo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pbLogo.TabIndex = 4;
            this.pbLogo.TabStop = false;
            // 
            // pbLoading
            // 
            this.pbLoading.Image = global::MAL_Reviewer_UI.Properties.Resources.loading_gif_control_light;
            this.pbLoading.Location = new System.Drawing.Point(200, 5);
            this.pbLoading.Name = "pbLoading";
            this.pbLoading.Size = new System.Drawing.Size(25, 24);
            this.pbLoading.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pbLoading.TabIndex = 6;
            this.pbLoading.TabStop = false;
            this.pbLoading.Visible = false;
            // 
            // pbSearch
            // 
            this.pbSearch.Image = global::MAL_Reviewer_UI.Properties.Resources.icon_user;
            this.pbSearch.Location = new System.Drawing.Point(204, 7);
            this.pbSearch.Name = "pbSearch";
            this.pbSearch.Size = new System.Drawing.Size(20, 20);
            this.pbSearch.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pbSearch.TabIndex = 1;
            this.pbSearch.TabStop = false;
            // 
            // textboxControl1
            // 
            this.textboxControl1.AllowLoad = false;
            this.textboxControl1.BackgroundColor = System.Drawing.SystemColors.Control;
            this.textboxControl1.Icon = ((System.Drawing.Image)(resources.GetObject("textboxControl1.Icon")));
            this.textboxControl1.InnerText = "";
            this.textboxControl1.Location = new System.Drawing.Point(63, 317);
            this.textboxControl1.Name = "textboxControl1";
            this.textboxControl1.Size = new System.Drawing.Size(232, 33);
            this.textboxControl1.TabIndex = 17;
            this.textboxControl1.ToggleIcon = true;
            // 
            // textboxControl2
            // 
            this.textboxControl2.AllowLoad = false;
            this.textboxControl2.BackgroundColor = System.Drawing.SystemColors.Control;
            this.textboxControl2.Icon = ((System.Drawing.Image)(resources.GetObject("textboxControl2.Icon")));
            this.textboxControl2.InnerText = "";
            this.textboxControl2.Location = new System.Drawing.Point(63, 356);
            this.textboxControl2.Name = "textboxControl2";
            this.textboxControl2.Size = new System.Drawing.Size(232, 33);
            this.textboxControl2.TabIndex = 18;
            this.textboxControl2.ToggleIcon = false;
            // 
            // LoadUserForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(334, 472);
            this.Controls.Add(this.textboxControl2);
            this.Controls.Add(this.textboxControl1);
            this.Controls.Add(this.pBottomSeparator);
            this.Controls.Add(this.lDisclaimer);
            this.Controls.Add(this.llNoAcc);
            this.Controls.Add(this.bLoad);
            this.Controls.Add(this.pTopSeparator);
            this.Controls.Add(this.pbLogo);
            this.Controls.Add(this.pMALUsername);
            this.Controls.Add(this.lTitle);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "LoadUserForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Load your MAL info";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FLoadUser_FormClosing);
            this.pMALUsername.ResumeLayout(false);
            this.pMALUsername.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbLogo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbLoading)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbSearch)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lTitle;
        private System.Windows.Forms.Panel pMALUsername;
        private System.Windows.Forms.PictureBox pbSearch;
        private System.Windows.Forms.TextBox tbMALUsername;
        private System.Windows.Forms.PictureBox pbLogo;
        private System.Windows.Forms.Panel pTopSeparator;
        private System.Windows.Forms.PictureBox pbLoading;
        private System.Windows.Forms.Button bLoad;
        private System.Windows.Forms.LinkLabel llNoAcc;
        private System.Windows.Forms.Label lDisclaimer;
        private System.Windows.Forms.Panel pBottomSeparator;
        private user_controls.TextboxControl textboxControl1;
        private user_controls.TextboxControl textboxControl2;
    }
}