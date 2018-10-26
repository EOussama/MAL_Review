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

namespace MAL_Reviwer_UI.forms
{
    public partial class fNewReview : Form
    {
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

        private async void tbSearch_TextChanged(object sender, EventArgs e)
        {
            string
                searchTitle = tbSearch.Text.Trim(),
                searchType = rbAnime.Checked ? rbAnime.Text.ToLower() : rbManga.Text.ToLower();

            if(searchTitle.Length > 2)
            {
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

                pSearchCards.Visible = true;
            }
            else
            {
                pSearchCards.Visible = false;
            }
        }

        #endregion
    }
}