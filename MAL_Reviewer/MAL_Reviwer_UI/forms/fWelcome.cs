using System;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using MAL_Reviewer_API;
using MAL_Reviewer_API.models;

namespace MAL_Reviwer_UI.forms
{
    public partial class fWelcome : Form
    {
        public fWelcome()
        {
            InitializeComponent();

            // Fetching application info.
            lTitle.Text = Properties.Settings.Default["title"].ToString();
            lVersion.Text = Properties.Settings.Default["version"].ToString();

            // Temporarely removing Animelist and Mangalist tab pages.
            tcDashboard.TabPages.Remove(tpAnimelist);
            tcDashboard.TabPages.Remove(tpMangalist);

            MALHelper.Init();
        }

        #region User Data Load

        private void bUser_Click(object sender, EventArgs e)
        {
            fLoadUser fLoadUser = new fLoadUser();

            fLoadUser.UserLoadedEvent += FLoadUser_UserLoadedEvent;
            fLoadUser.ShowDialog();
        }

        private async void FLoadUser_UserLoadedEvent(object sender, MALUserModel user)
        {
            LoadingUI();

            // Updating the UI.
            await Task.Run(() =>
            {
                Thread.Sleep(500);
                pDashBoardMain.Invoke((MethodInvoker)delegate
                {
                    #region Dashboard UI update

                    // Profile
                    lUserUsername.Text = user.username;
                    lUserGender.Text = user.gender;
                    lUserJoinDate.Text = user.joined?.ToShortDateString();
                    lUserBirthday.Text = user.birthday?.ToShortDateString();
                    lUserLocation.Text = user.location;
                    bMALProfile.Tag = user.url;

                    if (user.image_url != null && user.image_url != "")
                        pbUserImage.Load(user.image_url);
                    else
                        pbUserImage.Image = Properties.Resources.icon_user;

                    ttExtendedInfo.SetToolTip(lUserUsername, user.username);
                    ttExtendedInfo.SetToolTip(lUserGender, user.gender);
                    ttExtendedInfo.SetToolTip(lUserJoinDate, user.joined?.ToShortDateString());
                    ttExtendedInfo.SetToolTip(lUserBirthday, user.birthday?.ToShortDateString());
                    ttExtendedInfo.SetToolTip(lUserLocation, user.location);

                    // Anime stats
                    lvDashAnimeWatching.Text = user.anime_stats.watching.ToString();
                    lvDashAnimeCompleted.Text = user.anime_stats.completed.ToString();
                    lvDashAnimeOnHold.Text = user.anime_stats.on_hold.ToString();
                    lvDashAnimeDropped.Text = user.anime_stats.dropped.ToString();
                    lvDashAnimePTW.Text = user.anime_stats.plan_to_watch.ToString();
                    lvDashAnimeEpisodes.Text = user.anime_stats.episodes_watched.ToString();
                    lvDashAnimeRewatches.Text = user.anime_stats.rewatched.ToString();

                    lvDashAnimeDaysWatched.Text = user.anime_stats.days_watched.ToString();
                    lvDashAnimeMeanScore.Text = user.anime_stats.mean_score.ToString();

                    // Manga stats
                    lvDashMangaReading.Text = user.manga_stats.reading.ToString();
                    lvDashMangaCompleted.Text = user.manga_stats.completed.ToString();
                    lvDashMangaOnHold.Text = user.manga_stats.on_hold.ToString();
                    lvDashMangaDropped.Text = user.manga_stats.dropped.ToString();
                    lvDashMangaPTR.Text = user.manga_stats.plan_to_read.ToString();
                    lvDashMangaVolumes.Text = user.manga_stats.volumes_read.ToString();
                    lvDashMangaChapters.Text = user.manga_stats.chapters_read.ToString();
                    lvDashMangaReread.Text = user.manga_stats.reread.ToString();

                    lvDashMangaDaysRead.Text = user.manga_stats.days_read.ToString();
                    lvDashMangaMeanScore.Text = user.manga_stats.mean_score.ToString();

                    #endregion

                    #region Animelist UI update

                    #endregion

                    #region Mangalist UI update

                    #endregion
                });
            });

            LoadingUI(false);
        }

        /// <summary>
        /// Toggles the loading UI.
        /// </summary>
        /// <param name="mode"></param>
        private void LoadingUI(bool mode = true)
        {
            if (mode)
            {
                tcDashboard.SelectedIndex = 0;
                tcDashboard.TabPages.Remove(tpAnimelist);
                tcDashboard.TabPages.Remove(tpMangalist);

                pDashBoardMain.Visible = false;
                lMALAccPreview.Visible = false;
                pbDashBoardLoad.Visible = true;
            }
            else
            {
                tcDashboard.TabPages.Add(tpAnimelist);
                tcDashboard.TabPages.Add(tpMangalist);

                bUser.Text = "Unload this MAL account";
                pbDashBoardLoad.Visible = false;
                lMALAccPreview.Visible = false;
                pDashBoardMain.Visible = true;
            }
        }

        #endregion

        #region Dashboard management

        private void bMALProfile_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start(((Button)sender).Tag.ToString());
        }

        #endregion

        private void bNew_Click(object sender, EventArgs e)
        {
            (new fNewReview()).ShowDialog();
        }
    }
}
