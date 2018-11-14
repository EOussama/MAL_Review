using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using MAL_Reviewer_UI.classes;
using MAL_Reviewer_UI.forms.sub_forms;

namespace MAL_Reviewer_UI.forms
{
    public partial class SettingsForm : Form
    {
        private Form
            userSubForm,
            themeSubForm,
            templateSubForm,
            searchSubForm,
            infoSubForm;

        /// <summary>
        /// Constructor.
        /// </summary>
        public SettingsForm()
        {
            InitializeComponent();

            // Instanciating the sub forms.
            userSubForm = new Form()
            {
                TopLevel = false,
                Dock = DockStyle.Fill
            };
            themeSubForm = new Form()
            {
                TopLevel = false,
                Dock = DockStyle.Fill
            };
            templateSubForm = new SettingsTemplateForm()
            {
                TopLevel = false,
                Dock = DockStyle.Fill
            };
            searchSubForm = new Form()
            {
                TopLevel = false,
                Dock = DockStyle.Fill
            };
            infoSubForm = new Form()
            {
                TopLevel = false,
                Dock = DockStyle.Fill
            };

            // Adding the sub forms to the content panel.
            contentPanel.Controls.AddRange(new Form[] {
                userSubForm,
                themeSubForm,
                templateSubForm,
                searchSubForm,
                infoSubForm
            });
        }

        private void UserButton_Click(object sender, EventArgs e)
        {
            if (!userSubForm.Visible)
            {
                this.userSubForm.Show();
                this.HideAllExcept(userSubForm);
                ((Button)sender).Highlight(Color.LightGray, Color.Transparent, sidePanel.Controls.OfType<Button>().Where(btn => btn != (Button)sender).ToArray());
            }
        }

        private void ThemeButton_Click(object sender, EventArgs e)
        {
            if (!themeSubForm.Visible)
            {
                this.themeSubForm.Show();
                this.HideAllExcept(themeSubForm);
                ((Button)sender).Highlight(Color.LightGray, Color.Transparent, sidePanel.Controls.OfType<Button>().Where(btn => btn != (Button)sender).ToArray());
            }
        }

        private void TemplateButton_Click(object sender, EventArgs e)
        {
            if (!templateSubForm.Visible)
            {
                this.templateSubForm.Show();
                this.HideAllExcept(templateSubForm);
                ((Button)sender).Highlight(Color.LightGray, Color.Transparent, sidePanel.Controls.OfType<Button>().Where(btn => btn != (Button)sender).ToArray());
            }
        }

        private void SearchButton_Click(object sender, EventArgs e)
        {
            if (!searchSubForm.Visible)
            {
                this.searchSubForm.Show();
                this.HideAllExcept(searchSubForm);
                ((Button)sender).Highlight(Color.LightGray, Color.Transparent, sidePanel.Controls.OfType<Button>().Where(btn => btn != (Button)sender).ToArray());
            }
        }

        private void InfoButton_Click(object sender, EventArgs e)
        {
            if (!infoSubForm.Visible)
            {
                this.infoSubForm.Show();
                this.HideAllExcept(infoSubForm);
                ((Button)sender).Highlight(Color.LightGray, Color.Transparent, sidePanel.Controls.OfType<Button>().Where(btn => btn != (Button)sender).ToArray());
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
