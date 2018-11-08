using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace MAL_Reviwer_UI.user_controls
{
    public partial class Card : UserControl
    {
        public string Title
        {
            get => TitleLabel.Text;
            set => TitleLabel.Text = value;
        }

        public Image Icon
        {
            get => IconPictureBox.Image;
            set => IconPictureBox.Image = value;
        }

        public Color BackgroundColor
        {
            get => this.BackColor;
            set {
                this.BackColor = value;
                IconPictureBox.BackColor = value;
            }
        }

        public Color ShadowColor
        {
            get => BottomShadowPanel.BackColor;
            set => BottomShadowPanel.BackColor = value;
        }

        public Panel Content
        {
            get => ContentPanel;
        }

        public Card()
        {
            InitializeComponent();
        }
    }
}
