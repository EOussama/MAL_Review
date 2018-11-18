using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using MAL_Reviewer_UI.extensions;
using MAL_Reviewer_UI.forms.sub_forms;

namespace MAL_Reviewer_UI.forms
{
    public partial class SettingsForm : Form
    {
        #region Fields

        private Form
            UserSubForm,
            ThemeSubForm,
            ReviewTemplateSubForm,
            SearchSubForm,
            InfoSubForm;

        #endregion

        #region Constructors

        /// <summary>
        /// Parameterless constructor.
        /// </summary>
        public SettingsForm()
        {
            InitializeComponent();

            // Instanciating the sub forms.
            UserSubForm = new SettingsUserForm()
            {
                TopLevel = false,
                Dock = DockStyle.Fill
            };
            ThemeSubForm = new SettingsThemeForm()
            {
                TopLevel = false,
                Dock = DockStyle.Fill
            };
            ReviewTemplateSubForm = new SettingsTemplateForm()
            {
                TopLevel = false,
                Dock = DockStyle.Fill
            };
            SearchSubForm = new SettingsSearchForm()
            {
                TopLevel = false,
                Dock = DockStyle.Fill
            };
            InfoSubForm = new SettingsInfoForm()
            {
                TopLevel = false,
                Dock = DockStyle.Fill
            };

            // Adding the sub forms to the content panel.
            contentPanel.Controls.AddRange(new Form[] {
                UserSubForm,
                ThemeSubForm,
                ReviewTemplateSubForm,
                SearchSubForm,
                InfoSubForm
            });
        }

        #endregion

        #region Private methods

        /// <summary>
        /// Opens the “User”'s settings sub form.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void UserButton_Click(object sender, EventArgs e) => UserSubForm.ToggleSubForm((Button)sender, contentPanel, sidePanel);

        /// <summary>
        /// Opens the “Theme”'s settings sub form.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ThemeButton_Click(object sender, EventArgs e) => ThemeSubForm.ToggleSubForm((Button)sender, contentPanel, sidePanel);

        /// <summary>
        /// Opens the “Review Templates”'s settings sub form.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TemplateButton_Click(object sender, EventArgs e) => ReviewTemplateSubForm.ToggleSubForm((Button)sender, contentPanel, sidePanel);

        /// <summary>
        /// Opens the “Search”'s settings sub form.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SearchButton_Click(object sender, EventArgs e) => SearchSubForm.ToggleSubForm((Button)sender, contentPanel, sidePanel);

        /// <summary>
        /// Opens the “Info”'s settings sub form.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void InfoButton_Click(object sender, EventArgs e) => InfoSubForm.ToggleSubForm((Button)sender, contentPanel, sidePanel);

        #endregion
    }
}
