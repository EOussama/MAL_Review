using System;
using System.Windows.Forms;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using MAL_Reviewer_UI.user_controls;
using MAL_Reviewer_UI.classes;
using MAL_Reviewer_API;
using MAL_Reviewer_API.models;

namespace MAL_Reviewer_UI.forms
{
    public partial class NewReviewForm : Form
    {
        private bool
            ready = true,
            allow = true,
            dataFetched = false;

        private byte type = 0;
        private int targetId = 0;
        private string lastSearch = string.Empty;
        private System.Windows.Forms.Timer inputDelay;
        private CancellationTokenSource cts;
        private LoaderControl previewLoader;

        public NewReviewForm()
        {
            InitializeComponent();
            this.ActiveControl = tbSearch;

            // Wiring up eventhandlers to the radio buttons
            rbAnime.CheckedChanged += RbAnime_CheckedChanged;
            rbScaleOther.CheckedChanged += RbScaleOther_CheckedChanged;

            // Disabeling horizontal scroll on pSearchCards.
            pSearchCards.HorizontalScroll.Maximum = 0;
            pSearchCards.AutoScroll = true;

            // Populating the pSearchCards panel with ucTargetSearchCard user controls.
            foreach (int i in Enumerable.Range(1, 10))
            {
                TargetSearchCardControl searchCard = new TargetSearchCardControl();
                int searchCardCount = pSearchCards.Controls.Count;

                if (searchCardCount < 5)
                    pSearchCards.Height = searchCard.Height * searchCardCount;

                searchCard.CardMouseClickEvent += SearchCard_CardMouseClickEvent;
                searchCard.Top = searchCard.Height * searchCardCount;
                searchCard.Visible = false;
                searchCard.Tag = false;
                pSearchCards.Controls.Add(searchCard);
            }

            // input delay timer setup.
            this.inputDelay = new System.Windows.Forms.Timer
            {
                Interval = 500
            };
            this.inputDelay.Tick += _inputDelay_Tick;

            // Create loaders
            previewLoader = new LoaderControl()
            {
                Color = System.Drawing.SystemColors.Control
            };

            cts = new CancellationTokenSource();
        }

        #region Manga/Anime labeling

        private void RbScaleOther_CheckedChanged(object sender, EventArgs e) => nupScaleOther.Enabled = rbScaleOther.Checked;

        private void RbAnime_CheckedChanged(object sender, EventArgs e)
        {
            lTitle.Text = $"{ (rbAnime.Checked ? rbAnime.Text : rbManga.Text) } title";
            lPreview.Text = $"{ (rbAnime.Checked ? rbAnime.Text : rbManga.Text) } preview";
            pbShow.Image = (rbAnime.Checked ? Properties.Resources.icon_anime : Properties.Resources.icon_manga);
            TargetNotFoundLabel.Text = $"Input the { (rbAnime.Checked ? rbAnime : rbManga).Text } title you want review on the text box above, meanwhile we will fetch any related data from MAL to help provide more information on the review target.";
            TbSearch_TextChanged(this, EventArgs.Empty);
        }

        #endregion

        #region Target Search

        private void TbSearch_TextChanged(object sender, EventArgs e)
        {
            string _currentSearch = tbSearch.Text.Trim().ToLower();

            // Check if the search request has already been sent or not.
            if (!this.ready || _currentSearch.Length < 3)
            {
                pSearchCards.Visible = false;
                TargetNotFoundLabel.Text = $"Input the { (rbAnime.Checked ? rbAnime : rbManga).Text } title you want review on the text box above, meanwhile we will fetch any related data from MAL to help provide more information on the review target.";

                return;
            }

            // Reset the input timer.
            this.inputDelay.Stop();
            this.inputDelay.Start();
        }

        private async void _inputDelay_Tick(object sender, EventArgs e)
        {
            this.inputDelay.Stop();

            try
            {
                string
                    searchTitle = tbSearch.Text.Trim().ToLower(),
                    searchType = rbAnime.Checked ? rbAnime.Text.ToLower() : rbManga.Text.ToLower();

                if (this.lastSearch == searchTitle && this.type == (rbAnime.Checked ? int.Parse(rbAnime.Tag.ToString()) : int.Parse(rbManga.Tag.ToString())))
                    return;

                // Get last search and type.
                this.lastSearch = searchTitle;
                this.type = (byte)(rbAnime.Checked ? int.Parse(rbAnime.Tag.ToString()) : int.Parse(rbManga.Tag.ToString()));

                ToggleSearchLoading(true);
                this.ready = false;

                SearchModel searchModel = await MALHelper.Search(searchType, searchTitle, cts.Token);

                if (searchModel != null && searchModel.Results != null)
                {
                    // Updating the ucTargetSearchCard usercontrolls in a separate thread.
                    int resultCount = searchModel.Results.Length;

                    await Task.Run(() =>
                    {
                        Parallel.For(0, pSearchCards.Controls.Count, i =>
                        {
                            TargetSearchCardControl searchCard = (TargetSearchCardControl)pSearchCards.Controls[i];

                            // Check if the current user control is withing the range of number of results, if yes, make it visible and update it.
                            if (i < resultCount)
                            {
                                SearchResultsModel resultsModel = searchModel.Results[i];

                                searchCard.Invoke((MethodInvoker)delegate
                                {
                                    searchCard.UpdateUI(resultsModel.Mal_id, resultsModel.Title, resultsModel.Type, resultsModel.Image_url, rbAnime.Checked ? rbAnime.Text : rbManga.Text);
                                    searchCard.Visible = true;
                                    searchCard.Tag = true;
                                });
                            }
                            else
                            {
                                searchCard.Invoke((MethodInvoker)delegate
                                {
                                    searchCard.Visible = false;
                                    searchCard.Tag = false;
                                });
                            }
                        });
                    });

                    if (resultCount < 4)
                    {
                        pSearchCards.Height = pSearchCards.Controls[0].Height * resultCount;
                    }
                    else
                    {
                        pSearchCards.Height = pSearchCards.Controls[0].Height * 4;
                    }

                    dataFetched = true;
                    pSearchCards.Visible = true;
                }
                else
                {
                    foreach (TargetSearchCardControl targetSearchCardControl in pSearchCards.Controls)
                    {
                        targetSearchCardControl.Visible = false;
                        targetSearchCardControl.Tag = false;
                    }

                    dataFetched = false;
                }
            }
            catch (Exception ex)
            {
                if (this.allow)
                    MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            finally
            {
                if (this.allow)
                {
                    ToggleSearchLoading(false);
                    this.ready = true;
                }
            }
        }

        private void SearchCard_CardMouseClickEvent(object sender, int targetId)
        {
            // Checking if the targetId isn't equal to the current previewed Anime/Manga's mal_id.
            if (this.targetId == targetId && this.type  == (rbAnime.Checked ? int.Parse(rbAnime.Tag.ToString()) : int.Parse(rbManga.Tag.ToString())))
                return;

            pPreview.ToggleLoad(true, previewLoader);

            if (rbAnime.Checked)
                PreviewAnime(targetId);
            else
                PreviewManga(targetId);
        }

        /// <summary>
        /// Toggles the loading animation for the search UI.
        /// </summary>
        /// <param name="state"></param>
        private void ToggleSearchLoading(bool state)
        {
            pbLoading.Visible = state;
            pSearchCards.Visible = !state && (bool)pSearchCards.Controls[0].Tag == true;
            pSearchCards.VerticalScroll.Value = 0;
            tbSearch.Enabled = !state;
            rbAnime.Enabled = !state;
            rbManga.Enabled = !state;

            if (!state)
            {
                if (dataFetched)
                {
                    TargetNotFoundLabel.Text = $"Input the { (rbAnime.Checked ? rbAnime : rbManga).Text } title you want review on the text box above, meanwhile we will fetch any related data from MAL to help provide more information on the review target.";
                }
                else
                {
                    TargetNotFoundLabel.Text = $"No { ((rbAnime.Checked) ? rbAnime : rbManga).Text } with that title was found on MAL.";
                }
            }
            
        }

        #region Search panel icon toggler

        private void TbSearch_MouseClick(object sender, MouseEventArgs e)
        {
            // pSearchCards.Controls.OfType<TargetSearchCardControl>().Count(control => (bool)control.Tag == true) > 0
            if (e.Button == MouseButtons.Left && tbSearch.Focused && tbSearch.Text.Trim().Length > 2 && (bool)pSearchCards.Controls[0].Tag == true && pSearchCards.Visible == false)
                pSearchCards.Visible = true;
        }

        private void PbShow_MouseClick(object sender, MouseEventArgs e)
        {
            pSearchCards.Visible = false;
            pbShow.Cursor = Cursors.Default;
            pbShow.Image = (rbAnime.Checked ? Properties.Resources.icon_anime : Properties.Resources.icon_manga);
        }

        private void PbShow_MouseEnter(object sender, EventArgs e)
        {
            if (tbSearch.Text.Trim().Length > 2 && pSearchCards.Controls.Count > 0 && pSearchCards.Controls[0]?.Visible == true && pSearchCards.Visible == true)
            {
                pbShow.Cursor = Cursors.Hand;
                pbShow.Image = Properties.Resources.icon_close;
            }
            else
            {
                pbShow.Cursor = Cursors.Default;
            }
        }

        private void PbShow_MouseLeave(object sender, EventArgs e) => pbShow.Image = (rbAnime.Checked ? Properties.Resources.icon_anime : Properties.Resources.icon_manga); 
        
        #endregion

        #endregion

        #region Preview section update

        private async void PreviewAnime(int animeId)
        {
            try
            {
                AnimeModel animeModel = await MALHelper.GetAnime(animeId);

                await Task.Run(() =>
                {
                    cts.Token.ThrowIfCancellationRequested();

                    if (!pPreview.IsDisposed)
                    {
                        pPreview.Invoke((MethodInvoker)delegate
                        {
                            lChapters.Visible = false;
                            lTargetChapters.Visible = false;
                            lVolumesEpisodes.Text = "Episodes";

                            lTargetScore.Text = animeModel.Score?.ToString("0.00");
                            lTargetRank.Text = animeModel.Rank.ToString();
                            lTargetType.Text = animeModel.type;
                            lTargetStatus.Text = animeModel.Airing ? "Airing" : "Finished";
                            lTargetVolumesEpisodes.Text = animeModel.Episodes != null ? animeModel.Episodes.ToString() : "?";
                            lTargetTitle.Text = animeModel.Title.Length > 55 ? animeModel.Title.Substring(0, 55) + "..." : animeModel.Title;
                            lTargetSynopsis.Text = animeModel.Synopsis?.Length > 215 ? animeModel.Synopsis?.Substring(0, 215) + "..." : animeModel.Synopsis;
                            pbTargetImage.Load(animeModel.Image_url);
                            MALPageButton.Tag = animeModel.Url;

                            lTargetChapters.Visible = false;
                            lChapters.Visible = false;

                            InfoTooltip.ToolTipTitle = $"{ animeModel.type } title";
                            InfoTooltip.SetToolTip(lTargetTitle, animeModel.Title);

                            this.targetId = animeModel.Mal_id;
                            this.type = 0;
                        });
                    }
                });
            }
            catch (Exception ex)
            {
                if (this.allow)
                    MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            finally
            {
                if (this.allow)
                {
                    pPreview.ToggleLoad(false, previewLoader);
                    pSearchCards.Visible = false;
                    lTargetChapters.Visible = false;
                    lChapters.Visible = false;
                }
            }
        }

        private async void PreviewManga(int mangaId)
        {
            try
            {
                MangaModel mangaModel = await MALHelper.GetManga(mangaId);

                await Task.Run(() =>
                {
                    cts.Token.ThrowIfCancellationRequested();

                    if (!pPreview.IsDisposed)
                    {
                        pPreview.Invoke((MethodInvoker)delegate
                        {
                            lChapters.Visible = true;
                            lTargetChapters.Visible = true;
                            lVolumesEpisodes.Text = "Volumes";

                            lTargetScore.Text = mangaModel.Score?.ToString("0.00");
                            lTargetRank.Text = mangaModel.Rank.ToString();
                            lTargetType.Text = mangaModel.type;
                            lTargetStatus.Text = mangaModel.Publishing ? "Publishing" : "Finished";
                            lTargetVolumesEpisodes.Text = mangaModel.Volumes != null ? mangaModel.Volumes.ToString() : "?";
                            lTargetChapters.Text = mangaModel.Chapters != null ? mangaModel.Chapters.ToString() : "?";
                            lTargetTitle.Text = mangaModel.Title.Length > 55 ? mangaModel.Title.Substring(0, 55) + "..." : mangaModel.Title;
                            lTargetSynopsis.Text = mangaModel.Synopsis?.Length > 215 ? mangaModel.Synopsis?.Substring(0, 215) + "..." : mangaModel.Synopsis;
                            pbTargetImage.Load(mangaModel.Image_url);
                            MALPageButton.Tag = mangaModel.Url;

                            InfoTooltip.ToolTipTitle = $"{ mangaModel.type } title";
                            InfoTooltip.SetToolTip(lTargetTitle, mangaModel.Title);

                            this.targetId = mangaModel.Mal_id;
                            this.type = 1;
                        });
                    }
                });
            }
            catch (Exception ex)
            {
                if (this.allow)
                    MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            finally
            {
                if (this.allow)
                {
                    pSearchCards.Visible = false;
                    pPreview.ToggleLoad(false, previewLoader);
                }
            }
        }

        private void BMAL_Click(object sender, EventArgs e) => System.Diagnostics.Process.Start(((Button)sender).Tag.ToString());

        #endregion

        private void NewReviewForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (!this.ready)
            {
                cts.Cancel();
                this.allow = false;
            }
        }
    }
}