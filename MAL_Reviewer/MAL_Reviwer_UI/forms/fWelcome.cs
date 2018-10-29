﻿using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Windows.Forms;
using MAL_Reviwer_UI.user_controls;
using MAL_Reviewer_API;
using MAL_Reviewer_API.models;

namespace MAL_Reviwer_UI.forms
{
    public partial class fWelcome : Form
    {
        private short _loaded = 0;

        public fWelcome()
        {
            InitializeComponent();

            // Fetching application info.
            lTitle.Text = Properties.Settings.Default["title"].ToString();
            lVersion.Text = Properties.Settings.Default["version"].ToString();

            // Temporarely removing Animelist and Mangalist tab pages.
            tcDashboard.TabPages.Remove(tpAnimelist);
            tcDashboard.TabPages.Remove(tpMangalist);

            // Horizontal scroll disable
            pChildAnime.HorizontalScroll.Maximum = 0;
            pChildManga.HorizontalScroll.Maximum = 0;
            pChildCharacters.HorizontalScroll.Maximum = 0;
            pChildPeople.HorizontalScroll.Maximum = 0;

            pChildAnime.AutoScroll = true;
            pChildManga.AutoScroll = true;
            pChildCharacters.AutoScroll = true;
            pChildPeople.AutoScroll = true;

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
            this._loaded = 0;
            await LoadingUIAsync();

            #region Dashboard UI update

            await Task.Run(async () => { 
                await Task.WhenAll(new Task[] { ProfileUpdateUIAsync(user), AnimeStatsUpdateUIAsync(user), MangaStatsUpdateUIAsync(user), FavoritesUpdateUIAsync(user) });
            });

            #endregion

            #region Animelist UI update

            #endregion

            #region Mangalist UI update

            #endregion

            //LoadingUI(false);
        }

        private async Task ProfileUpdateUIAsync(MALUserModel user)
        {
            await Task.Run(() =>
            {
                pDashboard.Invoke((MethodInvoker)async delegate
                {
                    lUserUsername.Text = user.username;
                    lUserGender.Text = user.gender;
                    lUserJoinDate.Text = user.joined?.ToLongDateString();
                    lUserBirthday.Text = user.birthday?.ToLongDateString();
                    lUserLocation.Text = user.location;
                    bMALProfile.Tag = user.url;
                    rtbAbout.Text = (user.about == "" || user.about == null) ? "Such empty!" : user.about;

                    if (user.image_url != null && user.image_url != "")
                        pbUserImage.Load(user.image_url);
                    else
                        pbUserImage.Image = Properties.Resources.icon_user;

                    ttExtendedInfo.SetToolTip(lUserUsername, user.username);
                    ttExtendedInfo.SetToolTip(lUserGender, user.gender);
                    ttExtendedInfo.SetToolTip(lUserJoinDate, user.joined?.ToLongDateString());
                    ttExtendedInfo.SetToolTip(lUserBirthday, user.birthday?.ToLongDateString());
                    ttExtendedInfo.SetToolTip(lUserLocation, user.location);

                    this._loaded++;
                    await LoadingUIAsync(false);
                });
            });
        }

        private async Task AnimeStatsUpdateUIAsync(MALUserModel user)
        {
            await Task.Run(() =>
            {
                pDashboard.Invoke((MethodInvoker)async delegate
                {
                    lvDashAnimeWatching.Text = user.anime_stats.watching.ToString();
                    lvDashAnimeCompleted.Text = user.anime_stats.completed.ToString();
                    lvDashAnimeOnHold.Text = user.anime_stats.on_hold.ToString();
                    lvDashAnimeDropped.Text = user.anime_stats.dropped.ToString();
                    lvDashAnimePTW.Text = user.anime_stats.plan_to_watch.ToString();
                    lvDashAnimeEpisodes.Text = user.anime_stats.episodes_watched.ToString();
                    lvDashAnimeRewatches.Text = user.anime_stats.rewatched.ToString();

                    lvDashAnimeDaysWatched.Text = user.anime_stats.days_watched?.ToString("0.00");
                    lvDashAnimeMeanScore.Text = user.anime_stats.mean_score?.ToString("0.00");

                    this._loaded++;
                    await LoadingUIAsync(false);
                });
            });
        }

        private async Task MangaStatsUpdateUIAsync(MALUserModel user)
        {
            await Task.Run(() =>
            {
                pDashboard.Invoke((MethodInvoker)async delegate
                {
                    lvDashMangaReading.Text = user.manga_stats.reading.ToString();
                    lvDashMangaCompleted.Text = user.manga_stats.completed.ToString();
                    lvDashMangaOnHold.Text = user.manga_stats.on_hold.ToString();
                    lvDashMangaDropped.Text = user.manga_stats.dropped.ToString();
                    lvDashMangaPTR.Text = user.manga_stats.plan_to_read.ToString();
                    lvDashMangaVolumes.Text = user.manga_stats.volumes_read.ToString();
                    lvDashMangaChapters.Text = user.manga_stats.chapters_read.ToString();
                    lvDashMangaReread.Text = user.manga_stats.reread.ToString();

                    lvDashMangaDaysRead.Text = user.manga_stats.days_read?.ToString("0.00");
                    lvDashMangaMeanScore.Text = user.manga_stats.mean_score?.ToString("0.00");

                    this._loaded++;
                    await LoadingUIAsync(false);
                });
            });
        }

        private async Task FavoritesUpdateUIAsync(MALUserModel user)
        {
            await Task.Run(() =>
            {
                pDashboard.Invoke((MethodInvoker)async delegate
                {
                    if (pChildAnime.Controls.Count > 0) pChildAnime.Controls.Clear();
                    if (pChildManga.Controls.Count > 0) pChildManga.Controls.Clear();
                    if (pChildCharacters.Controls.Count > 0) pChildCharacters.Controls.Clear();
                    if (pChildPeople.Controls.Count > 0) pChildPeople.Controls.Clear();

                    List<Task> tasks = new List<Task>();

                    // Anime
                    foreach (FavAnimeModel favAnimeModel in user.favorites.anime)
                    {
                        await Task.Run(() =>
                        {
                            pDashboard.Invoke((MethodInvoker)delegate
                            {
                                ucFavoriteThumb ucFavThumb = new ucFavoriteThumb(favAnimeModel.name, favAnimeModel.image_url, "Anime");

                                ucFavThumb.Tag = favAnimeModel.url;
                                ucFavThumb.Dock = DockStyle.Top;
                                pChildAnime.Controls.Add(ucFavThumb);
                            });
                        });
                    }
 
                    // Manga
                    foreach (FavMangaModel favMangaModel in user.favorites.manga)
                    {
                        await Task.Run(() =>
                        {
                            pDashboard.Invoke((MethodInvoker)delegate
                            {
                                ucFavoriteThumb ucFavThumb = new ucFavoriteThumb(favMangaModel.name, favMangaModel.image_url, "Manga");

                                ucFavThumb.Tag = favMangaModel.url;
                                ucFavThumb.Dock = DockStyle.Top;
                                pChildManga.Controls.Add(ucFavThumb);
                            });
                        });
                    }

                    // Characters
                    foreach (FavCharactersModel favCharacterModel in user.favorites.characters)
                    {
                        await Task.Run(() =>
                        {
                            pDashboard.Invoke((MethodInvoker)delegate
                            {
                                ucFavoriteThumb ucFavThumb = new ucFavoriteThumb(favCharacterModel.name, favCharacterModel.image_url, "Character");

                                ucFavThumb.Tag = favCharacterModel.url;
                                ucFavThumb.Dock = DockStyle.Top;
                                pChildCharacters.Controls.Add(ucFavThumb);
                            });
                        });
                    }

                    // People
                    foreach (FavPeopleModel favPeopleModel in user.favorites.people)
                    {
                        await Task.Run(() =>
                        {
                            pDashboard.Invoke((MethodInvoker)delegate
                            {
                                ucFavoriteThumb ucFavThumb = new ucFavoriteThumb(favPeopleModel.name, favPeopleModel.image_url, "Person");

                                ucFavThumb.Tag = favPeopleModel.url;
                                ucFavThumb.Dock = DockStyle.Top;
                                pChildPeople.Controls.Add(ucFavThumb);
                            });
                        });
                    }

                    lFavAnimeCount.Text = user.favorites.anime.Length.ToString();
                    lFavMangaCount.Text = user.favorites.manga.Length.ToString();
                    lFavCharactersCount.Text = user.favorites.characters.Length.ToString();
                    lFavPeopleCount.Text = user.favorites.people.Length.ToString();

                    this._loaded++;
                    await LoadingUIAsync(false);
                });
            });
        }

        /// <summary>
        /// Toggles the loading UI.
        /// </summary>
        /// <param name="mode"></param>
        private async Task LoadingUIAsync(bool mode = true)
        {
            await Task.Run(() =>
            {
                pDashBoardMain.Invoke((MethodInvoker)delegate
                {
                    pDashBoardMain.VerticalScroll.Value = 0;

                    if (mode)
                    {
                        tcDashboard.SelectedIndex = 0;
                        tcDashboard.TabPages.Remove(tpAnimelist);
                        tcDashboard.TabPages.Remove(tpMangalist);

                        pDashBoardMain.Visible = false;
                        lMALAccPreview.Visible = false;
                        pbDashBoardLoad.Visible = true;
                        bUser.Enabled = false;
                    }
                    else if (mode == false && this._loaded == 4)
                    {
                        tcDashboard.TabPages.Add(tpAnimelist);
                        tcDashboard.TabPages.Add(tpMangalist);

                        bUser.Text = "Unload this MAL account";
                        pbDashBoardLoad.Visible = false;
                        lMALAccPreview.Visible = false;
                        pDashBoardMain.Visible = true;
                        bUser.Enabled = true;
                    }
                });
            });
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
