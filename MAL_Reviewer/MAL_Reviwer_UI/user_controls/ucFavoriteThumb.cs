using System.Drawing;
using System.Windows.Forms;

namespace MAL_Reviwer_UI.user_controls
{
    public partial class ucFavoriteThumb : UserControl
    {
        public ucFavoriteThumb(string title, string image_url, string type)
        {
            InitializeComponent();

            this.lTitle.Text = title.Length > 32 ? title.Substring(0, 32) + "..." : title;

            if (image_url != null && image_url != "")
                this.pbImage.Load(image_url);

            // Tooltip initialization.
            this.ttTitle.ToolTipTitle = $"{ type } name";

            this.ttTitle.SetToolTip(this.lTitle, title);
            this.ttTitle.SetToolTip(this.pbImage, title);
            this.ttTitle.SetToolTip(this, title);

            // Wiring up the mouse click event.
            this.lTitle.MouseClick += ucFavoriteThumb_MouseClick;
            this.pbImage.MouseClick += ucFavoriteThumb_MouseClick;

            this.lTitle.MouseEnter += ucFavoriteThumb_MouseEnter;
            this.pbImage.MouseEnter += ucFavoriteThumb_MouseEnter;

            this.lTitle.MouseLeave += ucFavoriteThumb_MouseLeave;
            this.pbImage.MouseLeave += ucFavoriteThumb_MouseLeave;
        }

        private void ucFavoriteThumb_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
                System.Diagnostics.Process.Start(this.Tag.ToString());
        }

        private void ucFavoriteThumb_MouseEnter(object sender, System.EventArgs e)
        {
            this.BackColor = SystemColors.Control;
        }

        private void ucFavoriteThumb_MouseLeave(object sender, System.EventArgs e)
        {
            this.BackColor = SystemColors.ControlLight;
        }
    }
}
