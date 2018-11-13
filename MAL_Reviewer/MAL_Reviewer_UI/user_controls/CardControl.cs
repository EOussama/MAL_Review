using System.Drawing;
using System.Windows.Forms;

namespace MAL_Reviewer_UI.user_controls
{
    /// <summary>
    /// Card control.
    /// </summary>
    public partial class CardControl : UserControl
    {
        /// <summary>
        /// Sets and gets the title of the card.
        /// </summary>
        public string Title
        {
            get => TitleLabel.Text;
            set => TitleLabel.Text = value;
        }

        /// <summary>
        /// Sets and gets the icon of the card.
        /// </summary>
        public Image Icon
        {
            get => IconPictureBox.Image;
            set => IconPictureBox.Image = value;
        }

        /// <summary>
        /// Sets and gets the background color of the card.
        /// </summary>
        public Color BackgroundColor
        {
            get => this.BackColor;
            set {
                this.BackColor = value;
                IconPictureBox.BackColor = value;
            }
        }

        /// <summary>
        /// Sets and gets the color of the card's shadow.
        /// </summary>
        public Color ShadowColor
        {
            get => BottomShadowPanel.BackColor;
            set => BottomShadowPanel.BackColor = value;
        }

        /// <summary>
        /// Gets the control panel of the card.
        /// </summary>
        public Panel Content
        {
            get => ContentPanel;
        }

        /// <summary>
        /// Sets and gets the visibility of the card's label.
        /// </summary>
        public bool LabelVisibility
        {
            get => LabelLabel.Visible;
            set => LabelLabel.Visible = value;
        }

        /// <summary>
        /// Sets and gets the text of the card's label.
        /// </summary>
        public string LabelText
        {
            get => LabelLabel.Text;
            set => LabelLabel.Text = value;
        }

        public CardControl()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Updates the tooltip of the card's label.
        /// </summary>
        /// <param name="username"></param>
        public void UpdateTooltip(string username)
        {
            LabelInfoToolTip.ToolTipTitle = $"{Title}";
            LabelInfoToolTip.SetToolTip(LabelLabel, $"{username}'s {Title.Split(' ')[0]} list is {LabelLabel.Text.ToLower()}.");
        }
    }
}
