using System.Windows.Forms;
using System.Drawing;

namespace MAL_Reviewer_UI.user_controls
{
    /// <summary>
    /// A mini control that serves as a category lable.
    /// </summary>
    public partial class CigControl : UserControl
    {
        /// <summary>
        /// Constructor.
        /// </summary>
        public CigControl()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="label"></param>
        public CigControl(string label) : this()
        {
            this.cigLabel.Text = label;
        }

        /// <summary>
        /// Gets the label content.
        /// </summary>
        public string Label
        {
            get => this.cigLabel.Text;
        }

        private void CloseLabel_MouseEnter(object sender, System.EventArgs e)
        {
            this.closeLabel.Font = new Font(this.closeLabel.Font.FontFamily, this.closeLabel.Font.Size, FontStyle.Bold);
        }

        private void CloseLabel_MouseLeave(object sender, System.EventArgs e)
        {
            this.closeLabel.Font = new Font(this.closeLabel.Font.FontFamily, this.closeLabel.Font.Size, FontStyle.Regular);
        }

        private void closeLabel_Click(object sender, System.EventArgs e)
        {
            this.Dispose();
        }
    }
}
