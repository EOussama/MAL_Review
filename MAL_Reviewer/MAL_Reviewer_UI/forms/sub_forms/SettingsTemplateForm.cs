using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using MAL_Reviewer_Core;
using MAL_Reviewer_Core.controllers;
using MAL_Reviewer_Core.exceptions;
using MAL_Reviewer_Core.models;
using MAL_Reviewer_UI.user_controls;

namespace MAL_Reviewer_UI.forms.sub_forms
{
    public partial class SettingsTemplateForm : Form
    {
        private short lastIndex = -1;

        /// <summary>
        /// Parameterless constructor.
        /// </summary>
        public SettingsTemplateForm()
        {
            InitializeComponent();

            LoadReviewTemplates();
            StyleAspectAdd();
        }

        private void TemplateListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            DisplayReviewTemplateInfo();
        }

        #region CRUD management

        private void TemplateDefaultButton_Click(object sender, EventArgs e)
        {
            DisplayReviewTemplateInfo();
        }

        private void TemplateUpdateButton_Click(object sender, EventArgs e)
        {
            string newName = this.templatePreviewRichTextBox.Text.Trim();

            try
            {
                if (newName.Length == 0) throw new Exception("Input a valid name for the review template.");

                ReviewTemplateModel reviewTemplateModel = Core.Settings.ReviewTemplatesSettings.GetReviewTemplate((short)this.templateListBox.SelectedIndex);
                string oldName = reviewTemplateModel.TemplateName;

                reviewTemplateModel.TemplateName = newName;

                reviewTemplateModel.TemplateAspects.Clear();
                templateAspectsFlowPanel.Controls.OfType<CigControl>().ToList().ForEach(aspect => reviewTemplateModel.TemplateAspects.Add(new ReviewAspectModel(aspect.Label, "", 0)));

                reviewTemplateModel.UseIntro = templateIntroCheckBox.Checked;
                reviewTemplateModel.AddTLDR = templateTLDRCheckBox.Checked;

                reviewTemplateModel.LastModified = DateTime.Now;

                Core.Settings.ReviewTemplatesSettings.UpdateReviewTemplate((short)this.templateListBox.SelectedIndex, reviewTemplateModel);
                LoadReviewTemplates();

                MessageBox.Show($"The review template “{ oldName }” was successfully updated!", "Notice", MessageBoxButtons.OK, MessageBoxIcon.Information);

                // Update the tooltips
                this.reviewTemplateTooltip.SetToolTip(this.creationDateLabel, reviewTemplateModel.CreationDate.ToLongTimeString());
                this.reviewTemplateTooltip.SetToolTip(this.editDateLabel, reviewTemplateModel.LastModified.ToLongTimeString());
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message, "Notice", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void TemplateDeleteButton_Click(object sender, EventArgs e)
        {
            string reviewTemplateName = this.templateListBox.Text;

            if (DialogResult.Yes == MessageBox.Show($"Do you really want to delete the “{ reviewTemplateName }” review template?", "Notice", MessageBoxButtons.YesNo, MessageBoxIcon.Question))
            {
                try
                {
                    Core.Settings.ReviewTemplatesSettings.DeleteReviewTemplate((short)this.templateListBox.SelectedIndex);
                }
                catch (Exception ex)
                {
                    
                    MessageBox.Show(ex.Message, "Notice", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }

                LoadReviewTemplates();
                MessageBox.Show($"The review template { reviewTemplateName } was successfully removed!", "Notice", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button2);
            }
        }

        private void TemplateCreateButton_Click(object sender, EventArgs e)
        {
            try
            {
                // Getting the appropriate review template name.
                string reviewTemplateName = Core.Settings.ReviewTemplatesSettings.GetDuplicateName();

                // Creating a new empty review template.
                Core.Settings.ReviewTemplatesSettings.AddReviewTemplate(new ReviewTemplateModel(reviewTemplateName, "", false, false, DateTime.Now, DateTime.Now, new List<ReviewAspectModel>()));

                // Refreshing the UI.
                LoadReviewTemplates();

                // Setting the last selected index to the review that we've just created.
                this.lastIndex = (short)(templateListBox.Items.Count - 1);
                ResetLastSelectedItem();

                MessageBox.Show("A new review template was successfully created!", "Notice", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (MaximumReviewTemplatesException ex)
            {
                MessageBox.Show(ex.ToString(), "Notice", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        #endregion

        #region UI control

        /// <summary>
        /// Loads the review templates from the memory and updates the UI of the form.
        /// </summary>
        private void LoadReviewTemplates()
        {
            this.templateLabel.Text = $"Review templates [{ Core.Settings.ReviewTemplatesSettings.ReviewTemplates.Count } / { ReviewTemplatesController.MaxReviewTemplates }]";

            this.lastIndex = (short)this.templateListBox.SelectedIndex;
            this.templateListBox.DataSource = null;
            this.templateListBox.DataSource = Core.Settings.ReviewTemplatesSettings.ReviewTemplates;
            this.templateListBox.DisplayMember = "TemplateName";

            ResetLastSelectedItem();

            // Toggle the review template management buttons.
            this.templateDeleteButton.Enabled = this.templateListBox.Items.Count > 0;
            this.templateUpdateButton.Enabled = this.templateListBox.Items.Count > 0;
            this.templateDefaultButton.Enabled = this.templateListBox.Items.Count > 0;

            DisplayEmptyUI();
        }

        /// <summary>
        /// Updates the preview UI with the selected review template's information.
        /// </summary>
        private void DisplayReviewTemplateInfo()
        {
            if (this.templateListBox.DataSource != null)
            {
                // Fetching the selected review template.
                ReviewTemplateModel reviewTemplateModel = Core.Settings.ReviewTemplatesSettings.GetReviewTemplate((short)this.templateListBox.SelectedIndex);

                // Updating the title.
                this.templatePreviewRichTextBox.Text = reviewTemplateModel.TemplateName;

                // Updating the aspects.
                this.templateAspectsFlowPanel.Controls.Clear();
                reviewTemplateModel.TemplateAspects.ForEach(aspect => SubmitAspect(aspect.AspectName));

                // Updating the checkboxes.
                this.templateIntroCheckBox.Checked = reviewTemplateModel.UseIntro;
                this.templateTLDRCheckBox.Checked = reviewTemplateModel.AddTLDR;

                // Updating the dates.
                this.creationDateLabel.Text = $"Created on {reviewTemplateModel.CreationDate.ToLongDateString()}";
                this.editDateLabel.Text = $"Last modified on {reviewTemplateModel.LastModified.ToLongDateString()}";
                this.reviewTemplateTooltip.SetToolTip(this.creationDateLabel, reviewTemplateModel.CreationDate.ToLongTimeString());
                this.reviewTemplateTooltip.SetToolTip(this.editDateLabel, reviewTemplateModel.LastModified.ToLongTimeString());

                //Aligning the richtextbox content.
                this.templatePreviewRichTextBox.SelectAll();
                this.templatePreviewRichTextBox.SelectionAlignment = HorizontalAlignment.Center;
            }
        }

        /// <summary>
        /// Displays an appropriate UI when there are no review templates created.
        /// </summary>
        private void DisplayEmptyUI()
        {
            if (Core.Settings.ReviewTemplatesSettings.ReviewTemplates.Count > 0 && this.noPreviewLabel.Visible == true)
            {
                // Showing all the preview panel's children but the noPreview label.
                foreach (Control control in this.templatePreviewPanel.Controls)
                {
                    control.Visible = (control != this.noPreviewLabel);
                }

                // Hidding the noPreview label.
                this.noPreviewLabel.Visible = false;
                
            }
            else if (Core.Settings.ReviewTemplatesSettings.ReviewTemplates.Count == 0 && this.noPreviewLabel.Visible == false)
            {
                // Hiding all the preview panel's children but the noPreview label.
                foreach (Control control in this.templatePreviewPanel.Controls)
                {
                    control.Visible = !(control != this.noPreviewLabel);
                }

                // Showing the noPreview label.
                this.noPreviewLabel.Visible = true;

                // Centering the noPreview label.
                this.noPreviewLabel.Location = new Point((this.templatePreviewPanel.Width / 2) - (this.noPreviewLabel.Width / 2), (this.templatePreviewPanel.Height / 2) - (this.noPreviewLabel.Height / 2));
            }
        }

        /// <summary>
        /// Selects the last selcted listbox item.
        /// </summary>
        private void ResetLastSelectedItem()
        {
            if (this.templateListBox.Items.Count > 0)
            {
                if (this.lastIndex >= this.templateListBox.Items.Count)
                {
                    this.templateListBox.SelectedIndex = this.lastIndex - 1;
                }
                else
                {
                    if (this.lastIndex < 0)
                    {
                        this.lastIndex = 0;
                    }

                    this.templateListBox.SelectedIndex = this.lastIndex;
                }
            }
            else
            {
                this.lastIndex = -1;
                this.templateListBox.SelectedIndex = this.lastIndex;
            }
        }

        #endregion

        #region Aspect management

        /// <summary>
        /// Adds visual updates to the add button of the aspects
        /// and assigns a submit event.
        /// </summary>
        private void StyleAspectAdd()
        {
            // Add the hand cursor.
            aspectsTextBox.Controls["iconPictureBox"].Cursor = Cursors.Hand;

            // Click event.
            aspectsTextBox.Controls["iconPictureBox"].MouseClick += AspectsAdd_MouseClick;

            // Key event.
            aspectsTextBox.Controls["inputTextBox"].KeyDown += AspectsAdd_KeyDown;
        }

        /// <summary>
        /// Creates an aspect label and submits it.
        /// </summary>
        /// <param name="label"></param>
        private void SubmitAspect(string label)
        {
            this.templateAspectsFlowPanel.Controls.Add(new CigControl(label));
            this.aspectsTextBox.Clear();
        }

        private void AspectsAdd_KeyDown(object sender, KeyEventArgs e)
        {
            string label = this.aspectsTextBox.InnerText.Trim();

            if (e.KeyCode == Keys.Return && label.Length > 0)
            {
                SubmitAspect(label);
            }
        }

        private void AspectsAdd_MouseClick(object sender, MouseEventArgs e)
        {
            string label = this.aspectsTextBox.InnerText.Trim();

            if (e.Button == MouseButtons.Left && label.Length > 0)
            {
                SubmitAspect(label);
            }
        }

        #endregion
    }
}
