using System;
using System.Collections.Generic;
using System.Windows.Forms;
using MAL_Reviewer_API;
using MAL_Reviewer_API.models;
using MAL_Reviewer_API.models.ListEntryModel;

namespace MAL_Reviwer_UI.forms
{
    public partial class fLoadUser : Form
    {
        public event EventHandler<MALUserModel> UserLoadedEvent;

        public fLoadUser()
        {
            InitializeComponent();

            this.ActiveControl = tbMALUsername;
        }

        private async void bLoad_Click(object sender, EventArgs e)
        {
            string username = tbMALUsername.Text.Trim();

            bLoad.Enabled = false;
            pbLoading.Visible = true;

            try
            {
                if (username.Length < 3) throw new Exception("Please input a valid username!");

                // Get the data of the user.
                MALUserModel userModel = await MALHelper.GetUser(username);
                List<AnimelistEntryModel> animeList = await MALHelper.GetAnimeList(username, (int)userModel.anime_stats.total_entries);

                if (userModel == null) throw new Exception($"No user under the username “{ username }” was found!");
                else
                {
                    this.Close();
                    userModel.animeList = animeList;
                    UserLoadedEvent?.Invoke(this, userModel);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Notice", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            finally
            {
                pbLoading.Visible = false;
                bLoad.Enabled = true;
                this.ActiveControl = tbMALUsername;
            }
        }

        private void llNoAcc_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start("https://myanimelist.net/register.php");
        }
    }
}
