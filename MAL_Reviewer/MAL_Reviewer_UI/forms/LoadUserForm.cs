using System;
using System.Collections.Generic;
using System.Threading;
using System.Windows.Forms;
using MAL_Reviewer_API;
using MAL_Reviewer_API.models.ListEntryModels;
using MAL_Reviewer_API.models.UserModels;

namespace MAL_Reviewer_UI.forms
{
    public partial class LoadUserForm : Form
    {
        public event EventHandler<MALUserModel> UserLoadedEvent;

        private bool
            ready = true,
            allow = true;

        private CancellationTokenSource cts;

        public LoadUserForm()
        {
            InitializeComponent();

            this.ActiveControl = searchControl.Controls["inputTextBox"];
            cts = new CancellationTokenSource();
        }

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
                    List<AnimelistEntryModel> animeList = await MALHelper.GetAnimeList(username, (int)userModel?.Anime_stats.Total_entries, cts.Token);
                    List<MangalistEntryModel> mangaList = await MALHelper.GetMangaList(username, (int)userModel?.Manga_stats.Total_entries, cts.Token);

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
                Console.WriteLine(ex.ToString());
                if (this.allow)
                    MessageBox.Show(ex.Message, "Notice", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
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

        private void LlNoAcc_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e) => System.Diagnostics.Process.Start("https://myanimelist.net/register.php");

        private void FLoadUser_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (!this.ready)
            {
                cts.Cancel();
                this.allow = false;
            }
        }
    }
}
