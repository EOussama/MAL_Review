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

            this.templateListBox.Items.Clear();
            Review.ReviewTemplates.ForEach(revTemp => this.templateListBox.Items.Add(revTemp.TemplateName));

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

        private void TemplateListBox_SelectedIndexChanged(object sender, System.EventArgs e)
        {
            DisplayReviewTemplateInfo();
        }

        private void TemplateDefaultButton_Click(object sender, System.EventArgs e)
        {
            DisplayReviewTemplateInfo();
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
            this.templatePreviewLabel.Text = reviewTemplateModel.TemplateName;
            this.reviewTemplateTitleTooltip.SetToolTip(this.templatePreviewLabel, reviewTemplateModel.TemplateName);

            // Updating the aspects.
            templateAspectsFlowPanel.Controls.Clear();
            reviewTemplateModel.TemplateAspects.ForEach(aspect => SubmitAspect(aspect.AspectName));

            // Updating the checkboxes.
            this.templateIntroCheckBox.Checked = reviewTemplateModel.UseIntro;
            this.templateTLDRCheckBox.Checked = reviewTemplateModel.AddTLDR;

            // Updating the dates.
            this.creationDateLabel.Text = $"Created on {reviewTemplateModel.CreationDate.ToShortDateString()}";
            this.editDateLabel.Text = $"Last modified on {reviewTemplateModel.LastModified.ToShortDateString()}";
        }
    }
}
