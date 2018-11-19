﻿using System;
using System.Windows.Forms;
using MAL_Reviewer_Core;
using MAL_Reviewer_UI.interfaces;

namespace MAL_Reviewer_UI.forms.sub_forms
{
    /// <summary>
    /// The general settings sub form.
    /// </summary>
    public partial class SettingsGeneralForm : Form, ISubForm
    {
        #region Constructors

        /// <summary>
        /// Parameterless constructor.
        /// </summary>
        public SettingsGeneralForm()
        {
            InitializeComponent();

            this.VisibleChanged += SettingsGeneralForm_VisibleChanged;
        }

        #endregion

        #region Private methods

        /// <summary>
        /// Handles the sub form's visibility change
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SettingsGeneralForm_VisibleChanged(object sender, EventArgs e)
        {
            if (this.Visible)
            {
                InitDisplay();
            }
        }

        /// <summary>
        /// Handles the reset all button click.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void GeneralSettingsResetButton_Click(object sender, EventArgs e)
        {
            if (DialogResult.Yes == MessageBox.Show($"Are you sure you want to reset all the application's settings?\nAll current configurations will be permanently lost.", "Notice", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2))
            {
                // Resetting the application's settings.
                Core.Settings.ResetSettings();

                MessageBox.Show("Application's settings have been successfully reset.", "Notice", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        #endregion

        #region Public methods

        // Displays initial information on the sub form.
        public void InitDisplay() { }

        #endregion
    }
}
