using System;
using System.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Windows.Forms;
using MAL_Reviwer_UI.user_controls;
using MAL_Reviewer_API;
using MAL_Reviewer_API.models;
using MAL_Reviewer_API.models.ListEntryModel;
using System.Threading;

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

            CreateLists();
            MALHelper.Init();
        }

        #region User Data Load

        private void BUser_Click(object sender, EventArgs e)
        {
            fLoadUser fLoadUser = new fLoadUser();

            fLoadUser.UserLoadedEvent += FLoadUser_UserLoadedEvent;
            fLoadUser.ShowDialog();
        }

        private async void FLoadUser_UserLoadedEvent(object sender, MALUserModel user)
        {
            this._loaded = 0;
            LoadingUI();

            await Task.Run(async () => { 
                await Task.WhenAll(
                    new Task[] 
                    {
                        ProfileUpdateUIAsync(user),
                        AnimeStatsUpdateUIAsync(user),
                        MangaStatsUpdateUIAsync(user),
                        FavoritesUpdateUIAsync(user),
                        AnimelistUpdateIU(user.animeList, user),
                        MangalistUpdateIU(user.mangaList, user),
                    });
            });
        }

        #endregion

        #region Dashboard management

        private void BMALProfile_Click(object sender, EventArgs e) => System.Diagnostics.Process.Start(((Button)sender).Tag.ToString());

        #endregion

        #region Visual updates

        /// <summary>
        /// UI Update for the profile information and MAL page button.
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        private async Task ProfileUpdateUIAsync(MALUserModel user)
        {
            await Task.Run(() =>
            {
                tcDashboard.Invoke((MethodInvoker)delegate
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
                    LoadingUI(false);
                });
            });
        }

        /// <summary>
        /// UI Update for the anime stats card.
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        private async Task AnimeStatsUpdateUIAsync(MALUserModel user)
        {
            await Task.Run(() =>
            {
                tcDashboard.Invoke((MethodInvoker)delegate
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
                    LoadingUI(false);
                });
            });
        }

        /// <summary>
        /// UI Update for the manga stats card.
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        private async Task MangaStatsUpdateUIAsync(MALUserModel user)
        {
            await Task.Run(() =>
            {
                tcDashboard.Invoke((MethodInvoker)delegate
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
                    LoadingUI(false);
                });
            });
        }

        /// <summary>
        /// UI Update for the favorites list.
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        private async Task FavoritesUpdateUIAsync(MALUserModel user)
        {
            await Task.Run(() =>
            {
                tcDashboard.Invoke((MethodInvoker)async delegate
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
                                ucFavoriteThumb ucFavThumb = new ucFavoriteThumb(favAnimeModel.name, favAnimeModel.image_url, "Anime")
                                {
                                    Tag = favAnimeModel.url,
                                    Dock = DockStyle.Top
                                };

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
                                ucFavoriteThumb ucFavThumb = new ucFavoriteThumb(favMangaModel.name, favMangaModel.image_url, "Manga")
                                {
                                    Tag = favMangaModel.url,
                                    Dock = DockStyle.Top
                                };

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
                                ucFavoriteThumb ucFavThumb = new ucFavoriteThumb(favCharacterModel.name, favCharacterModel.image_url, "Character")
                                {
                                    Tag = favCharacterModel.url,
                                    Dock = DockStyle.Top
                                };

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
                                ucFavoriteThumb ucFavThumb = new ucFavoriteThumb(favPeopleModel.name, favPeopleModel.image_url, "Person")
                                {
                                    Tag = favPeopleModel.url,
                                    Dock = DockStyle.Top
                                };

                                pChildPeople.Controls.Add(ucFavThumb);
                            });
                        });
                    }

                    lFavAnimeCount.Text = user.favorites.anime.Length.ToString();
                    lFavMangaCount.Text = user.favorites.manga.Length.ToString();
                    lFavCharactersCount.Text = user.favorites.characters.Length.ToString();
                    lFavPeopleCount.Text = user.favorites.people.Length.ToString();

                    this._loaded++;
                    LoadingUI(false);
                });
            });
        }

        /// <summary>
        /// UI Update for the user's anime list.
        /// </summary>
        /// <param name="animeList"></param>
        /// <param name="user"></param>
        /// <returns></returns>
        private async Task AnimelistUpdateIU(List<AnimelistEntryModel> animeList, MALUserModel user)
        {
            if (user.anime_stats.total_entries > 0)
            {
                await Task.Run(() =>
                {
                    if (tcDashboard.InvokeRequired)
                    {
                        tcDashboard.Invoke((MethodInvoker)delegate
                        {
                            RefreshLists();

                            ((UcEntryList)tlpAnimelistMain.Controls[0]).UpdateList(animeList.Where(a => a.watching_status == 1).ToList());
                            ((UcEntryList)tlpAnimelistMain.Controls[1]).UpdateList(animeList.Where(a => a.watching_status == 2).ToList());
                            ((UcEntryList)tlpAnimelistMain.Controls[2]).UpdateList(animeList.Where(a => a.watching_status == 3).ToList());
                            ((UcEntryList)tlpAnimelistMain.Controls[3]).UpdateList(animeList.Where(a => a.watching_status == 4).ToList());
                            ((UcEntryList)tlpAnimelistMain.Controls[4]).UpdateList(animeList.Where(a => a.watching_status == 6).ToList());

                            ResizeTable();
                        });
                    }
                    else
                    {
                        RefreshLists();

                        ((UcEntryList)tlpAnimelistMain.Controls[0]).UpdateList(animeList.Where(a => a.watching_status == 1).ToList());
                        ((UcEntryList)tlpAnimelistMain.Controls[1]).UpdateList(animeList.Where(a => a.watching_status == 2).ToList());
                        ((UcEntryList)tlpAnimelistMain.Controls[2]).UpdateList(animeList.Where(a => a.watching_status == 3).ToList());
                        ((UcEntryList)tlpAnimelistMain.Controls[3]).UpdateList(animeList.Where(a => a.watching_status == 4).ToList());
                        ((UcEntryList)tlpAnimelistMain.Controls[4]).UpdateList(animeList.Where(a => a.watching_status == 6).ToList());

                        ResizeTable();
                    }
                });
            }
            else
            {
                if (tcDashboard.InvokeRequired)
                {
                    tcDashboard.Invoke((MethodInvoker)delegate
                    {
                        RefreshLists();

                        foreach (UcEntryList entryList in tlpAnimelistMain.Controls)
                            entryList.ClearList();

                        ResizeTable();
                    });
                }
                else
                {
                    RefreshLists();

                    foreach (UcEntryList entryList in tlpAnimelistMain.Controls)
                        entryList.ClearList();

                    ResizeTable();
                }
            }

            this._loaded++;
            LoadingUI(false);
        }

        /// <summary>
        /// UI Update for the user's anime list.
        /// </summary>
        /// <param name="mangaList"></param>
        /// <param name="user"></param>
        /// <returns></returns>
        private async Task MangalistUpdateIU(List<MangalistEntryModel> mangaList, MALUserModel user)
        {
            if (user.manga_stats.total_entries > 0)
            {
                await Task.Run(() =>
                {
                    if (tcDashboard.InvokeRequired)
                    {
                        tcDashboard.Invoke((MethodInvoker)delegate
                        {
                            RefreshLists();

                            /*((UcEntryList)tlpMangalistMain.Controls[0]).UpdateList(mangaList.Where(a => a.reading_status == 1).ToList());
                            ((UcEntryList)tlpMangalistMain.Controls[1]).UpdateList(mangaList.Where(a => a.reading_status == 2).ToList());
                            ((UcEntryList)tlpMangalistMain.Controls[2]).UpdateList(mangaList.Where(a => a.reading_status == 3).ToList());
                            ((UcEntryList)tlpMangalistMain.Controls[3]).UpdateList(mangaList.Where(a => a.reading_status == 4).ToList());
                            ((UcEntryList)tlpMangalistMain.Controls[4]).UpdateList(mangaList.Where(a => a.reading_status == 6).ToList());*/

                            ResizeTable();
                        });
                    }
                    else
                    {
                        RefreshLists();

                        /*((UcEntryList)tlpMangalistMain.Controls[0]).UpdateList(mangaList.Where(a => a.reading_status == 1).ToList());
                        ((UcEntryList)tlpMangalistMain.Controls[1]).UpdateList(mangaList.Where(a => a.reading_status == 2).ToList());
                        ((UcEntryList)tlpMangalistMain.Controls[2]).UpdateList(mangaList.Where(a => a.reading_status == 3).ToList());
                        ((UcEntryList)tlpMangalistMain.Controls[3]).UpdateList(mangaList.Where(a => a.reading_status == 4).ToList());
                        ((UcEntryList)tlpMangalistMain.Controls[4]).UpdateList(mangaList.Where(a => a.reading_status == 6).ToList());*/

                        ResizeTable();
                    }
                });
            }
            else
            {
                if (tcDashboard.InvokeRequired)
                {
                    tcDashboard.Invoke((MethodInvoker)delegate
                    {
                        RefreshLists();

                        foreach (UcEntryList entryList in tlpMangalistMain.Controls)
                            entryList.ClearList();

                        ResizeTable();
                    });
                }
                else
                {
                    RefreshLists();

                    foreach (UcEntryList entryList in tlpMangalistMain.Controls)
                        entryList.ClearList();

                    ResizeTable();
                }
            }

            this._loaded++;
            LoadingUI(false);
        }

        /// <summary>
        /// Creates all the manga/anime lists.
        /// </summary>
        private void CreateLists()
        {
            tlpAnimelistMain.Controls.AddRange(new UcEntryList[] {
                new UcEntryList("Watching") { Dock = DockStyle.Fill },
                new UcEntryList("Completed") { Dock = DockStyle.Fill },
                new UcEntryList("On Hold") { Dock = DockStyle.Fill },
                new UcEntryList("Dropped") { Dock = DockStyle.Fill },
                new UcEntryList("Plan to Watch") { Dock = DockStyle.Fill }
            });

            tlpMangalistMain.Controls.AddRange(new UcEntryList[] {
                new UcEntryList("Reading") { Dock = DockStyle.Fill },
                new UcEntryList("Completed") { Dock = DockStyle.Fill },
                new UcEntryList("On Hold") { Dock = DockStyle.Fill },
                new UcEntryList("Dropped") { Dock = DockStyle.Fill },
                new UcEntryList("Plan to Read") { Dock = DockStyle.Fill }
            });
        }

        /// <summary>
        /// Refreshes the lists' UI.
        /// </summary>
        private void RefreshLists()
        {
            #region Animelist creation

            this.tlpAnimelistMain.AutoScroll = false;

            tlpAnimelistMain.Controls.Clear();
            tlpAnimelistMain.RowStyles.Clear();

            this.tlpAnimelistMain.RowCount = 6;
            this.tlpAnimelistMain.RowStyles.Add(new RowStyle(SizeType.Absolute, 0F));
            this.tlpAnimelistMain.RowStyles.Add(new RowStyle(SizeType.Absolute, 0F));
            this.tlpAnimelistMain.RowStyles.Add(new RowStyle(SizeType.Absolute, 0F));
            this.tlpAnimelistMain.RowStyles.Add(new RowStyle(SizeType.Absolute, 0F));
            this.tlpAnimelistMain.RowStyles.Add(new RowStyle(SizeType.Absolute, 0F));
            this.tlpAnimelistMain.RowStyles.Add(new RowStyle(SizeType.Absolute, 0F));

            this.tlpAnimelistMain.AutoScroll = true;

            #endregion

            #region Animelist creation

            this.tlpMangalistMain.AutoScroll = false;

            tlpMangalistMain.Controls.Clear();
            tlpMangalistMain.RowStyles.Clear();

            this.tlpMangalistMain.RowCount = 6;
            this.tlpMangalistMain.RowStyles.Add(new RowStyle(SizeType.Absolute, 0F));
            this.tlpMangalistMain.RowStyles.Add(new RowStyle(SizeType.Absolute, 0F));
            this.tlpMangalistMain.RowStyles.Add(new RowStyle(SizeType.Absolute, 0F));
            this.tlpMangalistMain.RowStyles.Add(new RowStyle(SizeType.Absolute, 0F));
            this.tlpMangalistMain.RowStyles.Add(new RowStyle(SizeType.Absolute, 0F));
            this.tlpMangalistMain.RowStyles.Add(new RowStyle(SizeType.Absolute, 0F));

            this.tlpMangalistMain.AutoScroll = true;

            #endregion

            CreateLists();
        }

        /// <summary>
        /// Resizes the table to fit the content.
        /// </summary>
        private void ResizeTable()
        {
            // Anime list table resize.
            for (int i = 0; i < tlpAnimelistMain.RowCount; i++)
            {
                if (i != 5)
                {
                    tlpAnimelistMain.RowStyles[i] = new  RowStyle(SizeType.Absolute, ((UcEntryList)tlpAnimelistMain.Controls[i]).ListHeight);
                }
                else
                {
                    tlpAnimelistMain.RowStyles[i] = new RowStyle(SizeType.Absolute, 0F);
                }
            }

            //Manga list table resize.
            for (int i = 0; i < tlpMangalistMain.RowCount; i++)
            {
                if (i != 5)
                {
                    tlpMangalistMain.RowStyles[i] = new RowStyle(SizeType.Absolute, ((UcEntryList)tlpMangalistMain.Controls[i]).ListHeight);
                }
                else
                {
                    tlpMangalistMain.RowStyles[i] = new RowStyle(SizeType.Absolute, 0F);
                }
            }
        }

        /// <summary>
        /// Toggles the loading UI.
        /// </summary>
        /// <param name="mode"></param>
        private void LoadingUI(bool mode = true)
        {
            tlpDashboardMain.VerticalScroll.Value = 0;
            tlpAnimelistMain.VerticalScroll.Value = 0;

            if (mode)
            {
                tcDashboard.SelectedIndex = 0;
                tcDashboard.TabPages.Remove(tpAnimelist);
                tcDashboard.TabPages.Remove(tpMangalist);

                tlpDashboardMain.Visible = false;
                lMALAccPreview.Visible = false;
                pbDashBoardLoad.Visible = true;
                bUser.Enabled = false;
            }
            else if (mode == false && this._loaded == 6)
            {
                tcDashboard.TabPages.Add(tpAnimelist);
                tcDashboard.TabPages.Add(tpMangalist);

                bUser.Text = "Unload this MAL account";
                pbDashBoardLoad.Visible = false;
                lMALAccPreview.Visible = false;
                tlpDashboardMain.Visible = true;
                bUser.Enabled = true;
            }
        }

        #endregion

        private void BNew_Click(object sender, EventArgs e) => (new fNewReview()).ShowDialog();
    }
}
