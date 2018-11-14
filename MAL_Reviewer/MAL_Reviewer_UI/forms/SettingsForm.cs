using System;
using System.Windows.Forms;
using MAL_Reviewer_UI.forms.sub_forms;

namespace MAL_Reviewer_UI.forms
{
    public partial class SettingsForm : Form
    {
        private Form
            template;

        /// <summary>
        /// Constructor.
        /// </summary>
        public SettingsForm()
        {
            InitializeComponent();

            // Instanciating the sub forms.
            template = new SettingsTemplateForm()
            {
                TopLevel = false,
                Dock = DockStyle.Fill
            };

            // Adding the sub forms to the content panel.
            contentPanel.Controls.AddRange(new Form[] {
                template
            });
        }

        private void TemplateButton_Click(object sender, EventArgs e)
        {
            if (!template.Visible)
            {
                template.Show();
                HideAllExcept(template);
                Console.WriteLine("shown");
            }
        }

        /// <summary>
        /// Hides all of the sub forms except for the passed one.
        /// </summary>
        /// <param name="exceptionForm"></param>
        private void HideAllExcept(Form exceptionForm)
        {
            foreach (Form form in contentPanel.Controls)
            {
                if (form != exceptionForm)
                {
                    form.Hide();
                }
            }
        }
    }
}
