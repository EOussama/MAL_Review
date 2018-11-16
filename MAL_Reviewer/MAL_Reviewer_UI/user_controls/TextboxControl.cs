using System;
using System.Drawing;
using System.Windows.Forms;

namespace MAL_Reviewer_UI.user_controls
{
    /// <summary>
    /// Custom textbox control.
    /// </summary>
    public partial class TextboxControl : UserControl
    {
        public event EventHandler<string> TextboxSubmitEvent;

        private bool toggleIcon = true;
        private byte extra = 0;
        private string lastSub = "";

        private int subMin = 3;
        private const int searchInterval = 500;

        LoaderControl loaderControl;
        private Timer inputDelay;

        /// <summary>
        /// Gets and sets the text in inputTextBox.
        /// </summary>
        public string InnerText
        {
            get => this.inputTextBox.Text;
            set => this.inputTextBox.Text = value;
        }

        /// <summary>
        /// Gets and sets the icon of the iconPictureBox.
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
                    this.placeholderLabel.Width = this.inputTextBox.Width;
                }
                else
                {
                    this.inputTextBox.Width = this.Width - (this.inputTextBox.Left * 2);
                    this.placeholderLabel.Width = this.inputTextBox.Width;
                }
            }
        }

        /// <summary>
        /// Gets and sets the background color of the textbox.
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
        /// Gets and sets the minimum length required to submit the textbox.
        /// </summary>
        public int SubmitMin
        {
            get => this.subMin;
            set => this.subMin = value;
        }

        /// <summary>
        /// Gets and sets the ability to activates the loading animation whne finishing typing.
        /// </summary>
        public bool AllowLoad { get; set; } = false;

        /// <summary>
        /// Gets and sets the ability to auto submit the textbox when finished typing.
        /// </summary>
        public bool AutoSubmit { get; set; } = false;

        /// <summary>
        /// Gets and sets the control's placeholder.
        /// </summary>
        public string Placeholder
        {
            get => this.placeholderLabel.Text;
            set => this.placeholderLabel.Text = value;
        }

        /// <summary>
        /// Gets and sets the control's placeholder's forecolor.
        /// </summary>
        public Color PlaceholderColor
        {
            get => this.placeholderLabel.ForeColor;
            set => this.placeholderLabel.ForeColor = value;
        }

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

            TextboxControl_Leave(this, EventArgs.Empty);
        }

        private void InputTextBox_TextChanged(object sender, System.EventArgs e)
        {
            this.inputDelay.Stop();
            this.inputDelay.Start();
        }

        private void InputDelay_Tick(object sender, System.EventArgs e)
        {
            this.inputDelay.Stop();

            // Check if the ability to submit the textbox when finished typing is on.
            if (this.AutoSubmit)
            {
                this.Submit();
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
        }

        /// <summary>
        /// Submit the textbox.
        /// </summary>
        public void Submit()
        {
            // Check if the length of the textbox's value is bigger or equal to the minimum allowed and if the
            // value about to be submited isn't the same as the last one.
            if (this.inputTextBox.Text.Trim().Length >= this.SubmitMin && (this.lastSub != this.inputTextBox.Text.Trim() || byte.Parse(this.Tag.ToString()) != this.extra))
            {
                this.TextboxSubmitEvent?.Invoke(this, inputTextBox.Text);
                this.lastSub = this.inputTextBox.Text.Trim();
                this.extra = byte.Parse(this.Tag.ToString());

                // Check if the loading animation is allowed.
                if (this.AllowLoad)
                {
                    // Toggle the loading animation.
                    this.ToggleLoading(true);
                }
            }
        }

        /// <summary>
        /// Clear the textbox.
        /// </summary>
        public void Clear() => this.inputTextBox.Clear();

        private void PlaceholderLabel_Click(object sender, EventArgs e)
        {
            this.placeholderLabel.Visible = false;
            this.ActiveControl = this.inputTextBox;
        }

        private void TextboxControl_Enter(object sender, EventArgs e)
        {
            this.placeholderLabel.Visible = false;
        }

        private void TextboxControl_Leave(object sender, EventArgs e)
        {
            if (this.inputTextBox.Text.Length == 0)
                this.placeholderLabel.Visible = true;
        }
    }
}
