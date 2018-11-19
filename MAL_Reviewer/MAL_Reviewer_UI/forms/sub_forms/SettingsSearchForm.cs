using System.Windows.Forms;
using MAL_Reviewer_UI.interfaces;

namespace MAL_Reviewer_UI.forms.sub_forms
{
    public partial class SettingsSearchForm : Form, ISubForm
    {
        #region Constructors

        /// <summary>
        /// Parameterless constructor.
        /// </summary>
        public SettingsSearchForm()
        {
            InitializeComponent();

            this.VisibleChanged += SettingsSearchForm_VisibleChanged;
        }

        #endregion

        #region Private methods

        /// <summary>
        /// Handles the sub form's visibility change.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SettingsSearchForm_VisibleChanged(object sender, System.EventArgs e)
        {
            if (this.Visible)
            {
                InitDisplay();
            }
        }

        #endregion

        #region Public methods

        // Displays initial information on the sub form.
        public void InitDisplay() { }

        #endregion
    }
}
