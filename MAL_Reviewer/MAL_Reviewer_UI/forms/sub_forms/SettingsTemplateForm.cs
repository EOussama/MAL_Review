using System.Windows.Forms;
using System.Drawing;
using MAL_Reviewer_Review;

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
            templateLabel.Text = $"Review templates [{ Review.ReviewTemplates.Count }]";

            templateListBox.Items.Clear();
            Review.ReviewTemplates.ForEach(revTemp => templateListBox.Items.Add(revTemp.TemplateName));
        }

        /// <summary>
        /// Adds visual updates to the add button of the aspects.
        /// </summary>
        private void StyleAspectAdd()
        {
            // Add the hand cursor.
            aspectsTextBox.Controls["iconPictureBox"].Cursor = Cursors.Hand;
        }
    }
}
