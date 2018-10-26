using System;
using System.Windows.Forms;

namespace MAL_Reviwer_UI.forms
{
    public partial class fWelcome : Form
    {
        public fWelcome()
        {
            InitializeComponent();
            
            MAL_Reviewer_API.MALHelper.Init();
        }

        private void bNew_Click(object sender, EventArgs e)
        {
            (new fNewReview()).ShowDialog();
        }
    }
}
