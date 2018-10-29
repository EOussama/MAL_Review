using System;
using System.Windows.Forms;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MAL_Reviwer_UI.user_controls;
using MAL_Reviewer_API;
using MAL_Reviewer_API.models;

namespace MAL_Reviwer_UI.forms
{
    public partial class fNewReview : Form
    {
        private bool _ready = true;
        private int _targetId = 0;
        private byte _type = 0;
        private string _lastSearch = string.Empty;
        private Timer _inputDelay;

        public fNewReview()
        {
            InitializeComponent();

            // Wiring up eventhandlers to the radio buttons
            rbAnime.CheckedChanged += RbAnime_CheckedChanged;
            rbScaleOther.CheckedChanged += RbScaleOther_CheckedChanged;

            // Disabeling horizontal scroll on pSearchCards.
            pSearchCards.HorizontalScroll.Maximum = 0;
            pSearchCards.AutoScroll = true;

            // Populating the pSearchCards panel with ucTargetSearchCard user controls.
            foreach (int i in Enumerable.Range(1, 10))
            {
                ucTargetSearchCard searchCard = new ucTargetSearchCard();
                int searchCardCount = pSearchCards.Controls.Count;

                if (searchCardCount < 5)
                    pSearchCards.Height = searchCard.Height * searchCardCount;

                searchCard.CardMouseClickEvent += SearchCard_CardMouseClickEvent;
                searchCard.Top = searchCard.Height * searchCardCount;
                pSearchCards.Controls.Add(searchCard);
            }

            // input delay timer setup.
            this._inputDelay = new Timer();
            this._inputDelay.Interval = 500;
            this._inputDelay.Tick += _inputDelay_Tick;
        }

        #region Manga/Anime labeling

        private void RbScaleOther_CheckedChanged(object sender, EventArgs e)
        {
            nupScaleOther.Enabled = rbScaleOther.Checked;
        }

        private void RbAnime_CheckedChanged(object sender, EventArgs e)
        {
            lTitle.Text = $"{ (rbAnime.Checked ? rbAnime.Text : rbManga.Text) } title";
            lPreview.Text = $"{ (rbAnime.Checked ? rbAnime.Text : rbManga.Text) } preview";
            pbShow.Image = (rbAnime.Checked ? Properties.Resources.icon_anime : Properties.Resources.icon_manga);
            tbSearch_TextChanged(this, EventArgs.Empty);
        }

        #endregion

        #region Target Search

        private void tbSearch_TextChanged(object sender, EventArgs e)
        {
            string _currentSearch = tbSearch.Text.Trim().ToLower();

            // Check if the search request has already been sent or not.
           if (!this._ready || _currentSearch.Length < 3)
            {
                pSearchCards.Visible = false;
                return;
            }

            // Reset the input timer.
            this._inputDelay.Stop();
            this._inputDelay.Start();
        }

        private async void _inputDelay_Tick(object sender, EventArgs e)
        {
            this._inputDelay.Stop();
            tbSearch.Enabled = false;

            try
            {
                string
                    searchTitle = tbSearch.Text.Trim().ToLower(),
                    searchType = rbAnime.Checked ? rbAnime.Text.ToLower() : rbManga.Text.ToLower();

                if (this._lastSearch == searchTitle)
                    return;

                this._lastSearch = searchTitle;
                pbLoading.Visible = true;
                pSearchCards.Visible = false;
                this._ready = false;

                SearchModel searchModel = await MALHelper.Search(searchType, searchTitle);

                if (searchModel != null && searchModel.results != null)
                {
                    // Updating the ucTargetSearchCard usercontrolls in a separate thread.
                    int resultCount = searchModel.results.Length;
                    List<Task> tasks = new List<Task>();

                    for (int i = 0; i < pSearchCards.Controls.Count; i++)
                    {
                        ucTargetSearchCard searchCard = (ucTargetSearchCard)pSearchCards.Controls[i];

                        if (i < resultCount)
                        {
                            SearchResultsModel resultsModel = searchModel.results[i];
                            tasks.Add(
                                Task.Run(() =>
                                {
                                    searchCard.Invoke((MethodInvoker)delegate
                                    {
                                        searchCard.UpdateUI(resultsModel.mal_id, resultsModel.title, resultsModel.type, resultsModel.image_url, rbAnime.Checked ? rbAnime.Text : rbManga.Text);
                                        searchCard.Visible = true;
                                    });
                                })
                            );
                        }
                        else
                        {
                            searchCard.Invoke((MethodInvoker)delegate
                            {
                                searchCard.Visible = false;
                            });
                        }
                    }

                    await Task.WhenAll(tasks);
                    pSearchCards.Visible = true;
                }

                pbLoading.Visible = false;
                this._ready = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            finally
            {
                tbSearch.Enabled = true;
            }
        }

        private void SearchCard_CardMouseClickEvent(object sender, int targetId)
        {
            // Checking if the targetId isn't equal to the current previewed Anime/Manga's mal_id.
            if (this._targetId == targetId && this._type  == (rbAnime.Checked ? int.Parse(rbAnime.Tag.ToString()) : int.Parse(rbManga.Tag.ToString())))
                return;

            pPreview.Visible = false;
            pbLoadingPreview.Visible = true;

            if (rbAnime.Checked)
                PreviewAnime(targetId);
            else
                PreviewManga(targetId);
        }

        private void tbSearch_MouseClick(object sender, MouseEventArgs e)
        {
            if (tbSearch.Focused && tbSearch.Text.Trim().Length > 2 && pSearchCards.Controls.Count > 0 && pSearchCards.Visible == false)
                pSearchCards.Visible = true;
        }

        private void pbShow_MouseClick(object sender, MouseEventArgs e)
        {
            pSearchCards.Visible = false;
            pbShow.Cursor = Cursors.Default;
            pbShow.Image = (rbAnime.Checked ? Properties.Resources.icon_anime : Properties.Resources.icon_manga);
        }

        private void pbShow_MouseEnter(object sender, EventArgs e)
        {
            if (tbSearch.Text.Trim().Length > 2 && pSearchCards.Controls.Count > 0 && pSearchCards.Visible == true)
            {
                pbShow.Cursor = Cursors.Hand;
                pbShow.Image = Properties.Resources.icon_close;
            }
            else
            {
                pbShow.Cursor = Cursors.Default;
            }
        }

        private void pbShow_MouseLeave(object sender, EventArgs e)
        {
            pbShow.Image = (rbAnime.Checked ? Properties.Resources.icon_anime : Properties.Resources.icon_manga);
        }

        #endregion

        #region Preview section update

        private async void PreviewAnime(int animeId)
        {
            try
            {
                AnimeModel animeModel = await MALHelper.GetAnime(animeId);
                
                // Updating the preview UI in a separate thread.
                await Task.Run(() =>
                {
                    pPreview.Invoke((MethodInvoker)delegate
                    {
                        lChapters.Visible = false;
                        lTargetChapters.Visible = false;
                        lVolumesEpisodes.Text = "Episodes";

                        lTargetScore.Text = animeModel.score?.ToString("0.00");
                        lTargetRank.Text = animeModel.rank.ToString();
                        lTargetType.Text = animeModel.type;
                        lTargetStatus.Text = animeModel.airing ? "Airing" : "Finished";
                        lTargetVolumesEpisodes.Text = animeModel.episodes != null ? animeModel.episodes.ToString() : "?";
                        lTargetTitle.Text = animeModel.title.Length > 55 ? animeModel.title.Substring(0, 55) + "..." : animeModel.title;
                        lTargetSynopsis.Text = animeModel.synopsis?.Length > 215 ? animeModel.synopsis?.Substring(0, 215) + "..." : animeModel.synopsis;
                        pbTargetImage.Load(animeModel.image_url);
                        bMAL.Tag = animeModel.url;

                        this._targetId = animeModel.mal_id;
                        this._type = 0;
                    });
                });
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            finally
            {
                pSearchCards.Visible = false;
                pbLoadingPreview.Visible = false;
                pPreview.Visible = true;
            }
        }

        private async void PreviewManga(int mangaId)
        {
            try
            {
                MangaModel mangaModel = await MALHelper.GetManga(mangaId);

                // Updating the preview UI in a separate thread.
                await Task.Run(() =>
                {
                    pPreview.Invoke((MethodInvoker)delegate
                    {
                        lChapters.Visible = true;
                        lTargetChapters.Visible = true;
                        lVolumesEpisodes.Text = "Volumes";

                        lTargetScore.Text = mangaModel.score?.ToString("0.00");
                        lTargetRank.Text = mangaModel.rank.ToString();
                        lTargetType.Text = mangaModel.type;
                        lTargetStatus.Text = mangaModel.publishing ? "Publishing" : "Finished";
                        lTargetVolumesEpisodes.Text = mangaModel.volumes != null ? mangaModel.volumes.ToString() : "?";
                        lTargetChapters.Text = mangaModel.chapters != null ? mangaModel.chapters.ToString() : "?";
                        lTargetTitle.Text = mangaModel.title.Length > 55 ? mangaModel.title.Substring(0, 55) + "..." : mangaModel.title;
                        lTargetSynopsis.Text = mangaModel.synopsis?.Length > 215 ? mangaModel.synopsis?.Substring(0, 215) + "..." : mangaModel.synopsis;
                        pbTargetImage.Load(mangaModel.image_url);
                        bMAL.Tag = mangaModel.url;

                        this._targetId = mangaModel.mal_id;
                        this._type = 1;
                    });
                });
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            finally
            {
                pSearchCards.Visible = false;
                pbLoadingPreview.Visible = false;
                pPreview.Visible = true;
            }
        }

        private void bMAL_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start(((Button)sender).Tag.ToString());
        }

        #endregion
    }
}