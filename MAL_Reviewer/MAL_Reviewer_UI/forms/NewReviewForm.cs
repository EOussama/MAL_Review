using System;
using System.Linq;
using System.Windows.Forms;
using System.Threading;
using System.Threading.Tasks;
using MAL_Reviewer_UI.user_controls;
using MAL_Reviewer_UI.extensions;
using MAL_Reviewer_Core;
using MAL_Reviewer_Core.controllers;
using MAL_Reviewer_Core.models.ReviewTemplateModels;
using MAL_Reviewer_API;
using MAL_Reviewer_API.models.SearchModels;
using MAL_Reviewer_API.models.TargetModels;

namespace MAL_Reviewer_UI.forms
{
    /// <summary>
    /// The form that debuts a review.
    /// </summary>
    public partial class NewReviewForm : Form
    {
        #region Fields

        private bool
            // Whether or not the form is ready to accept input or not.
            ready = true,

            // Whether or not the form is ready to be closed or not.
            allow = true,

            // Whether or not the data has been fetched.
            dataFetched = false;

        /// <summary>
        /// The type of the search (Anime = 1, Manga = 2).
        /// </summary>
        private byte type = 0;

        /// <summary>
        /// The MAL id of the last previewed target.
        /// </summary>
        private int targetId = 0;

        /// <summary>
        /// The cancellation object.
        /// </summary>
        private CancellationTokenSource cts;

        /// <summary>
        /// The loader control.
        /// </summary>
        private LoaderControl previewLoader;

        #endregion

        #region Constructor

        /// <summary>
        /// Parameterless constructor.
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

            // Populating the search panel with search cards.
            PopulateSearchCards();

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

        #endregion

        #region UI Updates

        /// <summary>
        /// Handles the enable toggle of the free scaling picker.
        /// </summary>
        /// <param name="sender"> The sender. </param>
        /// <param name="e"> The event's arguments. </param>
        private void RbScaleOther_CheckedChanged(object sender, EventArgs e) => nupScaleOther.Enabled = rbScaleOther.Checked;

        /// <summary>
        /// Handles the check state change of the Anime radio button.
        /// </summary>
        /// <param name="sender"> The sender. </param>
        /// <param name="e"> The event's arguments. </param>
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

        /// <summary>
        /// Unchecking all other review template cards.
        /// </summary>
        /// <param name="sender"> The sender. </param>
        /// <param name="e"> The event's arguments. </param>
        private void ReviewTemplateCard_ControlCheckedEventHandler(object sender, EventArgs e)
        {
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
        
        /// <summary>
        /// Populating the pSearchCards panel with ucTargetSearchCard user controls.
        /// </summary>
        private void PopulateSearchCards()
        {
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
        }

        #endregion

        #region Target Search

        /// <summary>
        /// The submission of the search query.
        /// </summary>
        /// <param name="sender"> The sender. </param>
        /// <param name="e"> The event's arguments. </param>
        private async void SearchControl_TextboxSubmitEvent(object sender, string e)
        {
            try
            {
                string searchType = rbAnime.Checked ? rbAnime.Text.ToLower() : rbManga.Text.ToLower();

                ToggleSearchLoading(true);
                this.searchControl.Tag = this.type;
                this.ready = false;

                SearchResultsModel[] searchModel = await MALHelper.Search(searchType, searchControl.InnerText.Trim(), cts.Token);

                if (searchModel != null && searchModel?.Length > 0)
                {
                    int resultCount = searchModel.Length;

                    await Task.Run(() =>
                    {
                        Parallel.For(0, pSearchCards.Controls.Count, i =>
                        {
                            TargetSearchCardControl searchCard = (TargetSearchCardControl)pSearchCards.Controls[i];

                            // Check if the current user control is withing the range of number of results,
                            // if yes, make it visible and update it.
                            if (i < resultCount)
                            {
                                SearchResultsModel resultsModel = searchModel[i];

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
                {
                    MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
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

        /// <summary>
        /// The click on a search entry that allows previewing a target.
        /// </summary>
        /// <param name="sender"> The sender. </param>
        /// <param name="e"> The event's arguments. </param>
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
        /// <param name="state"> The state of the loading; (ON = true, OFF = false). </param>
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

        /// <summary>
        /// Handles closing the search panel when the input length is lower than 3 characters.
        /// </summary>
        /// <param name="sender"> The sender. </param>
        /// <param name="e"> The event's arguments. </param>
        private void SearchControl_TextChanged(object sender, EventArgs e)
        {
            if (searchControl.InnerText.Trim().Length < 3)
            {
                pSearchCards.Visible = false;
            }
        }

        /// <summary>
        /// Handles showing the search panel when the textbox is clicked.
        /// </summary>
        /// <param name="sender"> The sender. </param>
        /// <param name="e"> The event's arguments. </param>
        private void SearchControl_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left && searchControl.Controls["inputTextBox"].Focused && searchControl.InnerText.Trim().Length > 2 && (bool)pSearchCards.Controls[0].Tag == true && pSearchCards.Visible == false)
            {
                pSearchCards.Visible = true;
            }
        }

        /// <summary>
        /// Handles closing the search panel.
        /// </summary>
        /// <param name="sender"> The sender. </param>
        /// <param name="e"> The event's arguments. </param>
        private void PbShow_MouseClick(object sender, MouseEventArgs e)
        {
            pSearchCards.Visible = false;
            searchControl.Controls["iconPictureBox"].Cursor = Cursors.Default;
            searchControl.Icon = (rbAnime.Checked ? Properties.Resources.icon_anime : Properties.Resources.icon_manga);
        }

        /// <summary>
        /// Handles changing the icon of the textbox depending on the mouse's state (On the icon).
        /// </summary>
        /// <param name="sender"> The sender. </param>
        /// <param name="e"> The event's arguments. </param>
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

        /// <summary>
        /// Handles chaning the icon of the textbox depending on the mouse's state (Not on the icon).
        /// </summary>
        /// <param name="sender"> The sender. </param>
        /// <param name="e"> The event's arguments. </param>
        private void PbShow_MouseLeave(object sender, EventArgs e) => searchControl.Icon = (rbAnime.Checked ? Properties.Resources.icon_anime : Properties.Resources.icon_manga); 
        
        #endregion

        #endregion

        #region Preview section update

        /// <summary>
        /// Previewing the clicked Anime.
        /// </summary>
        /// <param name="animeId"> The MAL id of the Anime. </param>
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
                {
                    MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
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

        /// <summary>
        /// Previewing the clicked Manga.
        /// </summary>
        /// <param name="mangaId"> The MAL id of the Manga. </param>
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
                {
                    MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
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

        /// <summary>
        /// Redirects to the target's MAL page.
        /// </summary>
        /// <param name="sender"> The sender. </param>
        /// <param name="e"> The event's arguments. </param>
        private void BMAL_Click(object sender, EventArgs e) => System.Diagnostics.Process.Start(((Button)sender).Tag.ToString());

        #endregion

        #region Form submition

        /// <summary>
        /// Opens the review's composition form.
        /// </summary>
        /// <param name="sender"> The sender. </param>
        /// <param name="e"> The event's arguments. </param>
        private void ReviewButton_Click(object sender, EventArgs e)
        {

        }

        #endregion

        /// <summary>
        /// Handles the closing of the form.
        /// </summary>
        /// <param name="sender"> The sender. </param>
        /// <param name="e"> The event's arguments. </param>
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
