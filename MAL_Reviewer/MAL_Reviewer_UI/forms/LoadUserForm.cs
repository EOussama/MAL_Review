using System;
using System.Collections.Generic;
using System.Threading;
using System.Windows.Forms;
using MAL_Reviewer_API;
using MAL_Reviewer_API.models.ListEntryModels;
using MAL_Reviewer_API.models.UserModels;
using MAL_Reviewer_Core;

namespace MAL_Reviewer_UI.forms
{
    public partial class LoadUserForm : Form
    {
        #region Events

        /// <summary>
        /// The event that's invoked when a user is loaded.
        /// </summary>
        public event EventHandler<MALUserModel> UserLoadedEvent;

        #endregion

        #region Fields

        private bool
            // Whether the form is ready for input or not.
            ready = true,

            // Whether closing the form is allowed or not.
            allow = true,

            // Whether or not the form was automatically opened or not.
            auto = false;

        /// <summary>
        /// The optional username passed.
        /// </summary>
        private string username = string.Empty;

        /// <summary>
        /// The cancellation token.
        /// </summary>
        private CancellationTokenSource cts;

        #endregion

        #region Constructors

        /// <summary>
        /// Parameterless constructor.
        /// </summary>
        public LoadUserForm()
        {
            InitializeComponent();

            this.ActiveControl = searchControl.Controls["inputTextBox"];
            cts = new CancellationTokenSource();
        }

        /// <summary>
        /// Constructor with username.
        /// </summary>
        /// <param name="username"></param>
        public LoadUserForm(string username) : this()
        {
            this.auto = true;
            this.username = username;
        }

        #endregion

        #region Private methods

        /// <summary>
        /// Handles the user's data loading.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private async void BLoad_Click(object sender, EventArgs e)
        {
            string username = searchControl.InnerText.Trim();

            this.bLoad.Enabled = false;
            this.searchControl.ToggleLoading(true);
            this.ready = false;

            try
            {
                if (username.Length < 3) throw new Exception("Please input a valid username!");
                
                // Get the data of the user.
                MALUserModel userModel = await MALHelper.GetUser(username, cts.Token);

                if (userModel == null) throw new Exception($"No user under the username “{ username }” was found!");
                else
                {
                    IEnumerable<AnimelistEntryModel> animeList = await MALHelper.GetAnimeList(username, (int)userModel?.Anime_stats.Total_entries, cts.Token);
                    IEnumerable<MangalistEntryModel> mangaList = await MALHelper.GetMangaList(username, (int)userModel?.Manga_stats.Total_entries, cts.Token);

                    if (this.allow)
                    {
                        this.ready = true;
                        this.Close();

                        userModel.AnimeList = animeList;
                        userModel.MangaList = mangaList;
                        UserLoadedEvent?.Invoke(this, userModel);
                    }
                }
            }
            catch (Exception ex)
            {
                if (this.allow)
                {
                    MessageBox.Show(ex.Message, "Notice", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }
            finally
            {
                if (this.allow)
                {
                    this.bLoad.Enabled = true;
                    this.searchControl.ToggleLoading(false);
                    this.ActiveControl = searchControl.Controls["inputTextBox"];
                    this.ready = true;
                }
            }
        }

        /// <summary>
        /// Handles the event of when the form is first shown.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void LoadUserForm_Shown(object sender, EventArgs e)
        {
            if (this.auto)
            {
                searchControl.InnerText = this.username;
                BLoad_Click(sender, e);
            }
        }

        /// <summary>
        /// Redirects to the MAL account creation.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void LlNoAcc_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e) => System.Diagnostics.Process.Start("https://myanimelist.net/register.php");

        /// <summary>
        /// Handles the closing of the form.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FLoadUser_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (!this.ready)
            {
                cts.Cancel();
                this.allow = false;
            }
        }

        #endregion
    }
}
