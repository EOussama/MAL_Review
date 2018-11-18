using System;
using System.Windows.Forms;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using MAL_Reviewer_UI.user_controls;
using MAL_Reviewer_UI.extensions;
using MAL_Reviewer_API;
using MAL_Reviewer_API.models;
using MAL_Reviewer_Core;
using MAL_Reviewer_Core.models;
using MAL_Reviewer_Core.controllers;

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
        private CancellationTokenSource cts;
        private LoaderControl previewLoader;

        /// <summary>
        /// Constructor.
        /// </summary>
        public NewReviewForm()
        {
            InitializeComponent();

            // Wiring up eventhandlers to the radio buttons.
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

            // Create loaders.
            previewLoader = new LoaderControl()
            {
                Color = System.Drawing.SystemColors.Control
            };

            // Wiring the text input events.
            searchControl.Tag = this.type;
            this.searchControl.TextboxSubmitEvent += SearchControl_TextboxSubmitEvent;
            this.searchControl.Controls["inputTextBox"].MouseClick += SearchControl_MouseClick;
            this.searchControl.Controls["inputTextBox"].TextChanged += SearchControl_TextChanged;
            this.searchControl.Controls["iconPictureBox"].MouseClick += PbShow_MouseClick;
            this.searchControl.Controls["iconPictureBox"].MouseEnter += PbShow_MouseEnter;
            this.searchControl.Controls["iconPictureBox"].MouseLeave += PbShow_MouseLeave;

            // Loading the review templates.
            LoadReviewTemplates();

            cts = new CancellationTokenSource();
            string target = (rbAnime.Checked ? rbAnime : rbManga).Text;

            this.ActiveControl = this.searchControl.Controls["inputTextBox"];
            this.searchControl.Placeholder = $"{ target } title...";
            TargetNotFoundLabel.Text = $"Input the { target } title you want review on the text box above, meanwhile we will fetch any related data from MAL to help provide more information on the review target.";
        }        

        #region UI Updates

        private void RbScaleOther_CheckedChanged(object sender, EventArgs e) => nupScaleOther.Enabled = rbScaleOther.Checked;

        private void RbAnime_CheckedChanged(object sender, EventArgs e)
        {
            string target = (rbAnime.Checked ? rbAnime : rbManga).Text;

            this.lTitle.Text = $"{ target } title";
            this.lPreview.Text = $"{ target } preview";
            this.TargetNotFoundLabel.Text = $"Input the { target } title you want review on the text box above, meanwhile we will fetch any related data from MAL to help provide more information on the review target.";

            this.searchControl.Placeholder = $"{ target } title...";
            this.searchControl.Icon = (rbAnime.Checked ? Properties.Resources.icon_anime : Properties.Resources.icon_manga);
            this.searchControl.Tag = (byte)(rbAnime.Checked ? int.Parse(rbAnime.Tag.ToString()) : int.Parse(rbManga.Tag.ToString()));
            this.searchControl.Submit();
        }

        private void ReviewTemplateCard_ControlCheckedEventHandler(object sender, EventArgs e)
        {
            // Unchecking all other review template cards.
            reviewTemplatesFlowPanel.Controls
                                    .OfType<ReviewTemplatePreviewCardControl>()
                                    .Where(control => control != (ReviewTemplatePreviewCardControl)sender)
                                    .ToList().ForEach(control => control.Check(false));
        }

        /// <summary>
        /// Loads the review templates and displays them in the preview panel.
        /// </summary>
        private void LoadReviewTemplates()
        {
            foreach (ReviewTemplateModel reviewTemplateModel in Core.Settings.ReviewTemplatesSettings.ReviewTemplates)
            {
                ReviewTemplatePreviewCardControl control = new ReviewTemplatePreviewCardControl(reviewTemplateModel);

                control.ControlCheckedEventHandler += ReviewTemplateCard_ControlCheckedEventHandler;
                reviewTemplatesFlowPanel.Controls.Add(control);
            }

            // Update the template count on the group box title.
            reviewTemplatesGroupBox.Text = $"Review templates [{ reviewTemplatesFlowPanel.Controls.Count } / { ReviewTemplatesController.MaxReviewTemplates }]";
        }

        #endregion

        #region Target Search

        private async void SearchControl_TextboxSubmitEvent(object sender, string e)
        {
            try
            {
                string searchType = rbAnime.Checked ? rbAnime.Text.ToLower() : rbManga.Text.ToLower();

                ToggleSearchLoading(true);
                this.searchControl.Tag = this.type;
                this.ready = false;

                SearchModel searchModel = await MALHelper.Search(searchType, searchControl.InnerText.Trim(), cts.Token);

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
                    this.ActiveControl = this.searchControl.Controls["inputTextBox"];
                    this.ready = true;
                }
            }
        }

        private void SearchCard_CardMouseClickEvent(object sender, int targetId)
        {
            var x = (rbAnime.Checked ? int.Parse(rbAnime.Tag.ToString()) : int.Parse(rbManga.Tag.ToString()));

            // Checking if the targetId isn't equal to the current previewed Anime/Manga's mal_id.
            if (this.targetId == targetId && this.type == (rbAnime.Checked ? int.Parse(rbAnime.Tag.ToString()) : int.Parse(rbManga.Tag.ToString())) && pPreview.Visible)
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
            searchControl.ToggleLoading(state);
            pSearchCards.Visible = !state && (bool)pSearchCards.Controls[0].Tag == true;
            rbAnime.Enabled = !state;
            rbManga.Enabled = !state;

            // Reseting the vertical scrolling.
            pSearchCards.VerticalScroll.Value = 0;
            // TODO scroll synopsis to top.

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

        private void SearchControl_TextChanged(object sender, EventArgs e)
        {
            if (searchControl.InnerText.Trim().Length < 3)
            {
                pSearchCards.Visible = false;
            }
        }

        private void SearchControl_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left && searchControl.Controls["inputTextBox"].Focused && searchControl.InnerText.Trim().Length > 2 && (bool)pSearchCards.Controls[0].Tag == true && pSearchCards.Visible == false)
            {
                pSearchCards.Visible = true;
            }
        }

        private void PbShow_MouseClick(object sender, MouseEventArgs e)
        {
            pSearchCards.Visible = false;
            searchControl.Controls["iconPictureBox"].Cursor = Cursors.Default;
            searchControl.Icon = (rbAnime.Checked ? Properties.Resources.icon_anime : Properties.Resources.icon_manga);
        }

        private void PbShow_MouseEnter(object sender, EventArgs e)
        {
            if (searchControl.InnerText.Trim().Length > 2 && pSearchCards.Controls.Count > 0 && pSearchCards.Controls[0]?.Visible == true && pSearchCards.Visible == true)
            {
                searchControl.Controls["iconPictureBox"].Cursor = Cursors.Hand;
                searchControl.Icon = Properties.Resources.icon_close;
            }
            else
            {
                searchControl.Controls["iconPictureBox"].Cursor = Cursors.Default;
            }
        }

        private void PbShow_MouseLeave(object sender, EventArgs e) => searchControl.Icon = (rbAnime.Checked ? Properties.Resources.icon_anime : Properties.Resources.icon_manga); 
        
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
                            lTargetType.Text = animeModel.Type;
                            lTargetStatus.Text = animeModel.Airing ? "Airing" : "Finished";
                            lTargetVolumesEpisodes.Text = animeModel.Episodes != null ? animeModel.Episodes.ToString() : "?";
                            lTargetTitle.Text = animeModel.Title;
                            lTargetSynopsis.Text = animeModel.Synopsis;
                            pbTargetImage.Load(animeModel.Image_url);
                            MALPageButton.Tag = animeModel.Url;

                            lTargetChapters.Visible = false;
                            lChapters.Visible = false;

                            InfoTooltip.ToolTipTitle = $"{ animeModel.Type } title";
                            InfoTooltip.SetToolTip(lTargetTitle, animeModel.Title);

                            this.targetId = animeModel.Mal_id;
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
                            lTargetType.Text = mangaModel.Type;
                            lTargetStatus.Text = mangaModel.Publishing ? "Publishing" : "Finished";
                            lTargetVolumesEpisodes.Text = mangaModel.Volumes != null ? mangaModel.Volumes.ToString() : "?";
                            lTargetChapters.Text = mangaModel.Chapters != null ? mangaModel.Chapters.ToString() : "?";
                            lTargetTitle.Text = mangaModel.Title;
                            lTargetSynopsis.Text = mangaModel.Synopsis;
                            pbTargetImage.Load(mangaModel.Image_url);
                            MALPageButton.Tag = mangaModel.Url;

                            InfoTooltip.ToolTipTitle = $"{ mangaModel.Type } title";
                            InfoTooltip.SetToolTip(lTargetTitle, mangaModel.Title);

                            this.targetId = mangaModel.Mal_id;
                            this.type = 2;
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

        #region Form submition

        private void ReviewButton_Click(object sender, EventArgs e)
        {

        }

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
