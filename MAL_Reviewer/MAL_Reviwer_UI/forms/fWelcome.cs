using System;
using System.Windows.Forms;
using MAL_Reviewer_API;

namespace MAL_Reviwer_UI.forms
{
    public partial class fWelcome : Form
    {
        public fWelcome()
        {
            InitializeComponent();

            lTitle.Text = Properties.Settings.Default["title"].ToString();
            lVersion.Text = Properties.Settings.Default["version"].ToString();
            
            MALHelper.Init();
        }

        private void bNew_Click(object sender, EventArgs e)
        {
            (new fNewReview()).ShowDialog();
        }
    }
}
