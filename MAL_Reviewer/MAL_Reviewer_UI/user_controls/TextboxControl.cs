using System.Drawing;
using System.Windows.Forms;

namespace MAL_Reviewer_UI.user_controls
{
    /// <summary>
    /// Custom textbox control.
    /// </summary>
    public partial class TextboxControl : UserControl
    {
        private bool toggleIcon = true;
        private const int searchInterval = 500;
        LoaderControl loaderControl;
        private Timer inputDelay;

        /// <summary>
        /// Sets and gets the text in inputTextBox.
        /// </summary>
        public string InnerText
        {
            get => this.inputTextBox.Text;
            set => this.inputTextBox.Text = value;
        }

        /// <summary>
        /// Sets and gets the icon of the iconPictureBox.
        /// </summary>
        public Image Icon
        {
            get => iconPictureBox.Image;
            set => iconPictureBox.Image = value;
        }

        /// <summary>
        /// Enables and disables the use of an icon for the textbox.
        /// </summary>
        public bool ToggleIcon
        {
            get => this.toggleIcon;
            set
            {
                this.toggleIcon = value;
                this.iconPictureBox.Visible = value;

                if (value)
                {
                    this.inputTextBox.Width = this.Width - (this.inputTextBox.Left * 2) - this.iconPictureBox.Width - (this.iconPictureBox.Left - this.inputTextBox.Right);
                }
                else
                {
                    this.inputTextBox.Width = this.Width - (this.inputTextBox.Left * 2);
                }
            }
        }

        /// <summary>
        /// Sets and gets the background color of the textbox.
        /// </summary>
        public Color BackgroundColor
        {
            get => this.BackColor;
            set
            {
                this.BackColor = value;
                this.inputTextBox.BackColor = value;
                this.iconPictureBox.BackColor = value;
                this.loaderControl.Color = value;
            }
        }

        /// <summary>
        /// Sets the maximum input length of the textbox.
        /// </summary>
        public int MaxLength
        {
            set => this.inputTextBox.MaxLength = value;
        }

        /// <summary>
        /// Sets and gets the ability to activates the loading animation whne finishing typing.
        /// </summary>
        public bool AllowLoad { get; set; } = false;

        public TextboxControl()
        {
            InitializeComponent();

            this.loaderControl = new LoaderControl()
            {
                Color = this.BackgroundColor,
                Bounds = this.iconPictureBox.Bounds
            };
            this.Controls.Add(loaderControl);
            this.loaderControl.BringToFront();
            this.inputDelay = new Timer
            {
                Interval = searchInterval
            };
            this.inputDelay.Tick += InputDelay_Tick;
        }

        private void InputTextBox_TextChanged(object sender, System.EventArgs e)
        {
            this.inputDelay.Stop();
            this.inputDelay.Start();
        }

        private void InputDelay_Tick(object sender, System.EventArgs e)
        {
            this.inputDelay.Stop();
            
            // Check if the loading animation is allowed.
            if (this.AllowLoad )
            {
                // Toggle the loading animation.
                this.ToggleLoading(true);
            }
        }

        /// <summary>
        /// Toggles the loading animation for the textbox.
        /// </summary>
        public void ToggleLoading(bool state)
        {
            this.inputTextBox.Enabled = !state;
            this.iconPictureBox.Visible = !state && this.ToggleIcon;
            this.loaderControl.Visible = state && this.ToggleIcon;

            this.Cursor = (state ? Cursors.WaitCursor : Cursors.Default);

            System.Threading.Thread.Sleep(3000);
        }
    }
}
