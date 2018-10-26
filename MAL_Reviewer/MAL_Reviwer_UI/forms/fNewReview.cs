using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MAL_Reviwer_UI.user_controls;

namespace MAL_Reviwer_UI.forms
{
    public partial class fNewReview : Form
    {
        public fNewReview()
        {
            InitializeComponent();

            rbAnime.CheckedChanged += RbAnime_CheckedChanged;
            rbScaleOther.CheckedChanged += RbScaleOther_CheckedChanged;
        }

        private void RbScaleOther_CheckedChanged(object sender, EventArgs e)
        {
            nupScaleOther.Enabled = rbScaleOther.Checked;
        }

        private void RbAnime_CheckedChanged(object sender, EventArgs e)
        {
            lTitle.Text = $"{ (rbAnime.Checked ? "Anime" : "Manga") } title";
            pbShow.Image = (rbAnime.Checked ? Properties.Resources.icon_anime : Properties.Resources.icon_manga);
        }

        private void tbSearch_TextChanged(object sender, EventArgs e)
        {
            pSearchCards.Visible = tbSearch.Text.Length > 0;
        }
    }
}
