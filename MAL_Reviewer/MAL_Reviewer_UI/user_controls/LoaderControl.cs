using System.Windows.Forms;
using System.Drawing;

namespace MAL_Reviewer_UI.user_controls
{
    public partial class LoaderControl : UserControl
    {
        /// <summary>
        /// Get and set the user control's back color.
        /// </summary>
        public Color @Color
        {
            get => this.BackColor;
            set
            {
                this.BackColor = value;
                this.LoaderPictureBox.BackColor = value;
                this.LoaderPictureBox.Image = GetProperImage();
            }
        }

        public LoaderControl()
        {
            InitializeComponent();
            this.Visible = false;
        }

        /// <summary>
        /// Get the apropriate loading gif given the background color.
        /// </summary>
        /// <returns></returns>
        private Image GetProperImage()
        {
            Image _image = null;

            switch (this.Color.Name)
            {
                case "White":
                    _image = Properties.Resources.loading_gif_white;
                    break;
                case "ControlLight":
                    _image = Properties.Resources.loading_gif_control_light;
                    break;
                default:
                    _image = Properties.Resources.loading_gif_control;
                    break;
            }

            return _image;
        }
    }
}
