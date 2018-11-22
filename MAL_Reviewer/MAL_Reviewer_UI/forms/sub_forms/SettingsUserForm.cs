using System;
using System.Windows.Forms;
using MAL_Reviewer_Core;
using MAL_Reviewer_Core.models.UserModels;
using MAL_Reviewer_UI.interfaces;

namespace MAL_Reviewer_UI.forms.sub_forms
{
    public partial class SettingsUserForm : Form, ISubForm
    {
        #region Constructors

        /// <summary>
        /// Parameterless constructor.
        /// </summary>
        public SettingsUserForm()
        {
            InitializeComponent();

            this.VisibleChanged += SettingsUserForm_VisibleChanged;
        }

        #endregion

        #region Private methods

        /// <summary>
        /// Handles the sub form's visibility change.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SettingsUserForm_VisibleChanged(object sender, EventArgs e)
        {
            if (this.Visible)
            {
                InitDisplay();
            }
        }

        /// <summary>
        /// Handles setting the default user.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SetDefaultUserButton_Click(object sender, EventArgs e)
        {
            string username = DefaultUserTextboxControl.InnerText.Trim();

            try
            {
                if (username.Length < 3) throw new Exception("Input a valid username.");
                if (username == Core.Settings.UserSettings.DefaultUser?.Username) throw new Exception($"The default user is already “{ username }”.");

                Core.Settings.UserSettings.DefaultUser = new UserModel(username);

                MessageBox.Show($"Default user set to “{ username }”.", "Notice", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Notice", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        #endregion

        #region Public methods

        /// <summary>
        /// Displays initial information on the sub form.
        /// </summary>
        public void InitDisplay()
        {
            DefaultUserTextboxControl.InnerText = Core.Settings.UserSettings.DefaultUser?.Username ?? "";
        }

        #endregion
    }
}
