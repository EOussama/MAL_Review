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
using MAL_Reviewer_API;
using MAL_Reviewer_API.models;
using System.Threading;

namespace MAL_Reviwer_UI.forms
{
    public partial class fNewReview : Form
    {
        private bool ready = true;
        public fNewReview()
        {
            InitializeComponent();

            pSearchCards.HorizontalScroll.Maximum = 0;
            pSearchCards.AutoScroll = true;

            rbAnime.CheckedChanged += RbAnime_CheckedChanged;
            rbScaleOther.CheckedChanged += RbScaleOther_CheckedChanged;
        }

        #region Manga/Anime labeling

        private void RbScaleOther_CheckedChanged(object sender, EventArgs e)
        {
            nupScaleOther.Enabled = rbScaleOther.Checked;
        }

        private void RbAnime_CheckedChanged(object sender, EventArgs e)
        {
            lTitle.Text = $"{ (rbAnime.Checked ? rbAnime.Text : rbManga.Text) } title";
            ttSearchCard.ToolTipTitle = lTitle.Text;
            pbShow.Image = (rbAnime.Checked ? Properties.Resources.icon_anime : Properties.Resources.icon_manga);
            tbSearch_TextChanged(this, EventArgs.Empty);
        }

        #endregion

        #region Target Search

        // TODO - Add usercontrols in another thread.
        private async void tbSearch_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (!this.ready)
                    return;

                string
                    searchTitle = tbSearch.Text.Trim(),
                    searchType = rbAnime.Checked ? rbAnime.Text.ToLower() : rbManga.Text.ToLower();

                if (searchTitle.Length > 2)
                {
                    pbLoading.Visible = true;
                    pSearchCards.Visible = false;
                    this.ready = false;

                    SearchModel searchModel = await MALHelper.Search(searchType, searchTitle);
                    pSearchCards.Controls.Clear();

                    foreach (SearchResultsModel resultsModel in searchModel.results)
                    {
                        ucTargetSearchCard searchCard = new ucTargetSearchCard(resultsModel.mal_id, resultsModel.title, resultsModel.type, resultsModel.image_url);
                        int searchCardCount = pSearchCards.Controls.Count;

                        if (searchCardCount < 5)
                            pSearchCards.Height = searchCard.Height * searchCardCount;

                        searchCard.Top = searchCard.Height * searchCardCount;
                        ttSearchCard.SetToolTip(searchCard, resultsModel.title);
                        pSearchCards.Controls.Add(searchCard);
                    }

                    pbLoading.Visible = false;
                    pSearchCards.Visible = true;
                    this.ready = true;
                }
                else
                {
                    pSearchCards.Visible = false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        #endregion
    }
}