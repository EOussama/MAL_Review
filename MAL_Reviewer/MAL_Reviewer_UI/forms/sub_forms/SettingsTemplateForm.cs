using System;
using System.Linq;
using System.Windows.Forms;
using MAL_Reviewer_Review;
using MAL_Reviewer_Review.models;
using MAL_Reviewer_UI.user_controls;

namespace MAL_Reviewer_UI.forms.sub_forms
{
    public partial class SettingsTemplateForm : Form
    {
        /// <summary>
        /// Constructor.
        /// </summary>
        public SettingsTemplateForm()
        {
            InitializeComponent();

            LoadReviewTemplates();
            StyleAspectAdd();
        }

        /// <summary>
        /// Loads the review templates from the memory and updates the UI of the form.
        /// </summary>
        private void LoadReviewTemplates()
        {
            this.templateLabel.Text = $"Review templates [{ Review.ReviewTemplates.Count }]";

            this.templateListBox.DataSource = Review.ReviewTemplates;
            this.templateListBox.DisplayMember = "TemplateName";

            if (this.templateListBox.Items.Count > 0)
            {
                this.templateListBox.SelectedIndex = 0;
            }
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

        private void TemplateListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            DisplayReviewTemplateInfo();
        }

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

                ReviewTemplateModel reviewTemplateModel = Review.ReviewTemplates[this.templateListBox.SelectedIndex];

                reviewTemplateModel.TemplateName = newName;

                reviewTemplateModel.TemplateAspects.Clear();
                templateAspectsFlowPanel.Controls.OfType<CigControl>().ToList().ForEach(aspect => reviewTemplateModel.TemplateAspects.Add(new ReviewAspectModel(aspect.Label, "", 0)));

                reviewTemplateModel.UseIntro = templateIntroCheckBox.Checked;
                reviewTemplateModel.AddTLDR = templateTLDRCheckBox.Checked;

                reviewTemplateModel.LastModified = DateTime.Now;

                Review.ReviewTemplates[this.templateListBox.SelectedIndex] = reviewTemplateModel;

                MessageBox.Show($"The review template “{ reviewTemplateModel.TemplateName }” was successfully updated!", "Notice", MessageBoxButtons.OK, MessageBoxIcon.Information);

                // Update the tooltips
                this.reviewTemplateTooltip.SetToolTip(this.creationDateLabel, reviewTemplateModel.CreationDate.ToLongTimeString());
                this.reviewTemplateTooltip.SetToolTip(this.editDateLabel, reviewTemplateModel.LastModified.ToLongTimeString());
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message, "Notice", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

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

        /// <summary>
        /// Updates the preview UI with the selected review template's information.
        /// </summary>
        private void DisplayReviewTemplateInfo()
        {
            // Fetching the selected review template.
            ReviewTemplateModel reviewTemplateModel = Review.ReviewTemplates[this.templateListBox.SelectedIndex];

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
}
