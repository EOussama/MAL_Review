using System;
using System.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Windows.Forms;
using MAL_Reviewer_UI.user_controls;
using MAL_Reviewer_API;
using MAL_Reviewer_API.models;
using MAL_Reviewer_API.models.ListEntryModel;
using MAL_Reviewer_Review.enumerations;

namespace MAL_Reviewer_UI.forms
{
    public partial class Welcome : Form
    {
        private short loaded = 0;

        private bool
            animePublic = true,
            mangaPublic = true;

        public Welcome()
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

            CreateCards();
            CreateLists(EntryType.Anime);
            CreateLists(EntryType.Manga);

            MALHelper.Init();
        }

        #region User Data Load

        private void BUser_Click(object sender, EventArgs e)
        {
            LoadUser fLoadUser = new LoadUser();

            fLoadUser.UserLoadedEvent += FLoadUser_UserLoadedEvent;
            fLoadUser.ShowDialog();
        }

        private async void FLoadUser_UserLoadedEvent(object sender, MALUserModel user)
        {
            this.loaded = 0;
            LoadingUI();

            await Task.Run(async () => { 
                await Task.WhenAll(
                    new Task[] 
                    {
                        ProfileUpdateUIAsync(user),
                        AnimeStatsUpdateUIAsync(user),
                        MangaStatsUpdateUIAsync(user),
                        FavoritesUpdateUIAsync(user),
                        AnimelistUpdateIU(user.AnimeList, user),
                        MangalistUpdateIU(user.MangaList, user)
                    });
            });
        }

        #endregion

        #region Dashboard management

        private void BMALProfile_Click(object sender, EventArgs e) => System.Diagnostics.Process.Start(((Button)sender).Tag.ToString());

        private void BMALFriends_Click(object sender, EventArgs e) => System.Diagnostics.Process.Start(((Button)sender).Tag.ToString());

        private void BMALAnimelist_Click(object sender, EventArgs e) => System.Diagnostics.Process.Start(((Button)sender).Tag.ToString());

        private void BMALMangalist_Click(object sender, EventArgs e) => System.Diagnostics.Process.Start(((Button)sender).Tag.ToString());

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
                    lUserUsername.Text = user.Username;
                    lUserGender.Text = user.Gender;
                    lUserJoinDate.Text = user.Joined?.ToLongDateString();
                    lUserBirthday.Text = user.Birthday?.ToLongDateString();
                    lUserLocation.Text = user.Location;
                    rtbAbout.Text = (user.About == "" || user.About == null) ? "Such empty!" : user.About;

                    if (user.Image_url != null && user.Image_url != "")
                        pbUserImage.Load(user.Image_url);
                    else
                        pbUserImage.Image = Properties.Resources.icon_user;

                    ttExtendedInfo.SetToolTip(lUserUsername, user.Username);
                    ttExtendedInfo.SetToolTip(lUserGender, user.Gender);
                    ttExtendedInfo.SetToolTip(lUserJoinDate, user.Joined?.ToLongDateString());
                    ttExtendedInfo.SetToolTip(lUserBirthday, user.Birthday?.ToLongDateString());
                    ttExtendedInfo.SetToolTip(lUserLocation, user.Location);

                    bMALProfile.Tag = user.Url;
                    bMALFriends.Tag = $"https://myanimelist.net/profile/{user.Username}/friends";
                    bMALAnimelist.Tag = $"https://myanimelist.net/animelist/{user.Username}";
                    bMALMangalist.Tag = $"https://myanimelist.net/mangalist/{user.Username}";

                    ((Card)tlpAnimeMangaCards.Controls[0]).UpdateTooltip(user.Username);
                    ((Card)tlpAnimeMangaCards.Controls[1]).UpdateTooltip(user.Username);

                    this.loaded++;
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
                    lvDashAnimeWatching.Text = user.Anime_stats.Watching.ToString();
                    lvDashAnimeCompleted.Text = user.Anime_stats.Completed.ToString();
                    lvDashAnimeOnHold.Text = user.Anime_stats.On_hold.ToString();
                    lvDashAnimeDropped.Text = user.Anime_stats.Dropped.ToString();
                    lvDashAnimePTW.Text = user.Anime_stats.Plan_to_watch.ToString();
                    lvDashAnimeEpisodes.Text = user.Anime_stats.Episodes_watched.ToString();
                    lvDashAnimeRewatches.Text = user.Anime_stats.Rewatched.ToString();

                    lvDashAnimeDaysWatched.Text = user.Anime_stats.Days_watched?.ToString("0.00");
                    lvDashAnimeMeanScore.Text = user.Anime_stats.Mean_score?.ToString("0.00");

                    this.loaded++;
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
                    lvDashMangaReading.Text = user.Manga_stats.Reading.ToString();
                    lvDashMangaCompleted.Text = user.Manga_stats.Completed.ToString();
                    lvDashMangaOnHold.Text = user.Manga_stats.On_hold.ToString();
                    lvDashMangaDropped.Text = user.Manga_stats.Dropped.ToString();
                    lvDashMangaPTR.Text = user.Manga_stats.Plan_to_read.ToString();
                    lvDashMangaVolumes.Text = user.Manga_stats.Volumes_read.ToString();
                    lvDashMangaChapters.Text = user.Manga_stats.Chapters_read.ToString();
                    lvDashMangaReread.Text = user.Manga_stats.Reread.ToString();

                    lvDashMangaDaysRead.Text = user.Manga_stats.Days_read?.ToString("0.00");
                    lvDashMangaMeanScore.Text = user.Manga_stats.Mean_score?.ToString("0.00");

                    this.loaded++;
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
                    foreach (FavAnimeModel favAnimeModel in user.Favorites.Anime)
                    {
                        await Task.Run(() =>
                        {
                            pDashboard.Invoke((MethodInvoker)delegate
                            {
                                FavoriteThumb ucFavThumb = new FavoriteThumb(favAnimeModel.Name, favAnimeModel.Image_url, "Anime")
                                {
                                    Tag = favAnimeModel.Url,
                                    Dock = DockStyle.Top
                                };

                                pChildAnime.Controls.Add(ucFavThumb);
                            });
                        });
                    }

                    // Manga
                    foreach (FavMangaModel favMangaModel in user.Favorites.Manga)
                    {
                        await Task.Run(() =>
                        {
                            pDashboard.Invoke((MethodInvoker)delegate
                            {
                                FavoriteThumb ucFavThumb = new FavoriteThumb(favMangaModel.Name, favMangaModel.Image_url, "Manga")
                                {
                                    Tag = favMangaModel.Url,
                                    Dock = DockStyle.Top
                                };

                                pChildManga.Controls.Add(ucFavThumb);
                            });
                        });
                    }

                    // Characters
                    foreach (FavCharactersModel favCharacterModel in user.Favorites.Characters)
                    {
                        await Task.Run(() =>
                        {
                            pDashboard.Invoke((MethodInvoker)delegate
                            {
                                FavoriteThumb ucFavThumb = new FavoriteThumb(favCharacterModel.Name, favCharacterModel.Image_url, "Character")
                                {
                                    Tag = favCharacterModel.Url,
                                    Dock = DockStyle.Top
                                };

                                pChildCharacters.Controls.Add(ucFavThumb);
                            });
                        });
                    }

                    // People
                    foreach (FavPeopleModel favPeopleModel in user.Favorites.People)
                    {
                        await Task.Run(() =>
                        {
                            pDashboard.Invoke((MethodInvoker)delegate
                            {
                                FavoriteThumb ucFavThumb = new FavoriteThumb(favPeopleModel.Name, favPeopleModel.Image_url, "Person")
                                {
                                    Tag = favPeopleModel.Url,
                                    Dock = DockStyle.Top
                                };

                                pChildPeople.Controls.Add(ucFavThumb);
                            });
                        });
                    }

                    lFavAnimeCount.Text = user.Favorites.Anime.Length.ToString();
                    lFavMangaCount.Text = user.Favorites.Manga.Length.ToString();
                    lFavCharactersCount.Text = user.Favorites.Characters.Length.ToString();
                    lFavPeopleCount.Text = user.Favorites.People.Length.ToString();

                    this.loaded++;
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
            if (animeList != null)
            {
                if (user.Anime_stats.Total_entries > 0)
                {
                    await Task.Run(() =>
                    {
                        if (tcDashboard.InvokeRequired)
                        {
                            tcDashboard.Invoke((MethodInvoker)delegate
                            {
                                ((Card)tlpAnimeMangaCards.Controls[0]).LabelText = "Public";
                                RefreshLists(EntryType.Anime);

                                ((EntryList)tlpAnimelistMain.Controls[0]).UpdateList(animeList.Where(a => a.Watching_status == 1).ToList());
                                ((EntryList)tlpAnimelistMain.Controls[1]).UpdateList(animeList.Where(a => a.Watching_status == 2).ToList());
                                ((EntryList)tlpAnimelistMain.Controls[2]).UpdateList(animeList.Where(a => a.Watching_status == 3).ToList());
                                ((EntryList)tlpAnimelistMain.Controls[3]).UpdateList(animeList.Where(a => a.Watching_status == 4).ToList());
                                ((EntryList)tlpAnimelistMain.Controls[4]).UpdateList(animeList.Where(a => a.Watching_status == 6).ToList());

                                ResizeTable(EntryType.Anime);
                            });
                        }
                        else
                        {
                            ((Card)tlpAnimeMangaCards.Controls[0]).LabelText = "Public";
                            RefreshLists(EntryType.Anime);

                            ((EntryList)tlpAnimelistMain.Controls[0]).UpdateList(animeList.Where(a => a.Watching_status == 1).ToList());
                            ((EntryList)tlpAnimelistMain.Controls[1]).UpdateList(animeList.Where(a => a.Watching_status == 2).ToList());
                            ((EntryList)tlpAnimelistMain.Controls[2]).UpdateList(animeList.Where(a => a.Watching_status == 3).ToList());
                            ((EntryList)tlpAnimelistMain.Controls[3]).UpdateList(animeList.Where(a => a.Watching_status == 4).ToList());
                            ((EntryList)tlpAnimelistMain.Controls[4]).UpdateList(animeList.Where(a => a.Watching_status == 6).ToList());

                            ResizeTable(EntryType.Anime);
                        }
                    });
                }
                else
                {
                    if (tcDashboard.InvokeRequired)
                    {
                        tcDashboard.Invoke((MethodInvoker)delegate
                        {
                            RefreshLists(EntryType.Anime);

                            foreach (EntryList entryList in tlpAnimelistMain.Controls)
                                entryList.ClearList();

                            ResizeTable(EntryType.Anime);
                        });
                    }
                    else
                    {
                        RefreshLists(EntryType.Anime);

                        foreach (EntryList entryList in tlpAnimelistMain.Controls)
                            entryList.ClearList();

                        ResizeTable(EntryType.Anime);
                    }
                }
            }
            else
            {
                if (tcDashboard.InvokeRequired)
                {
                    tcDashboard.Invoke((MethodInvoker)delegate
                    {
                        ((Card)tlpAnimeMangaCards.Controls[0]).LabelText = "Private";
                    });
                }
                else
                {
                    ((Card)tlpAnimeMangaCards.Controls[0]).LabelText = "Private";
                }
            }

            animePublic = animeList != null;
            this.loaded++;
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
            if (mangaList != null)
            {
                if (user.Manga_stats.Total_entries > 0)
                {
                    await Task.Run(() =>
                    {
                        if (tcDashboard.InvokeRequired)
                        {
                            tcDashboard.Invoke((MethodInvoker)delegate
                            {
                                ((Card)tlpAnimeMangaCards.Controls[1]).LabelText = "Public";
                                RefreshLists(EntryType.Manga);

                                ((EntryList)tlpMangalistMain.Controls[0]).UpdateList(mangaList.Where(a => a.Reading_status == 1).ToList());
                                ((EntryList)tlpMangalistMain.Controls[1]).UpdateList(mangaList.Where(a => a.Reading_status == 2).ToList());
                                ((EntryList)tlpMangalistMain.Controls[2]).UpdateList(mangaList.Where(a => a.Reading_status == 3).ToList());
                                ((EntryList)tlpMangalistMain.Controls[3]).UpdateList(mangaList.Where(a => a.Reading_status == 4).ToList());
                                ((EntryList)tlpMangalistMain.Controls[4]).UpdateList(mangaList.Where(a => a.Reading_status == 6).ToList());

                                ResizeTable(EntryType.Manga);
                            });
                        }
                        else
                        {
                            ((Card)tlpAnimeMangaCards.Controls[1]).LabelText = "Public";
                            RefreshLists(EntryType.Manga);

                            ((EntryList)tlpMangalistMain.Controls[0]).UpdateList(mangaList.Where(a => a.Reading_status == 1).ToList());
                            ((EntryList)tlpMangalistMain.Controls[1]).UpdateList(mangaList.Where(a => a.Reading_status == 2).ToList());
                            ((EntryList)tlpMangalistMain.Controls[2]).UpdateList(mangaList.Where(a => a.Reading_status == 3).ToList());
                            ((EntryList)tlpMangalistMain.Controls[3]).UpdateList(mangaList.Where(a => a.Reading_status == 4).ToList());
                            ((EntryList)tlpMangalistMain.Controls[4]).UpdateList(mangaList.Where(a => a.Reading_status == 6).ToList());

                            ResizeTable(EntryType.Manga);
                        }
                    });
                }
                else
                {
                    if (tcDashboard.InvokeRequired)
                    {
                        tcDashboard.Invoke((MethodInvoker)delegate
                        {
                            RefreshLists(EntryType.Manga);

                            foreach (EntryList entryList in tlpMangalistMain.Controls)
                                entryList.ClearList();

                            ResizeTable(EntryType.Manga);
                        });
                    }
                    else
                    {
                        RefreshLists(EntryType.Manga);

                        foreach (EntryList entryList in tlpMangalistMain.Controls)
                            entryList.ClearList();

                        ResizeTable(EntryType.Manga);
                    }
                }
            }
            else
            {
                if (tcDashboard.InvokeRequired)
                {
                    tcDashboard.Invoke((MethodInvoker)delegate
                    {
                        ((Card)tlpAnimeMangaCards.Controls[1]).LabelText = "Private";
                    });
                }
                else
                {
                    ((Card)tlpAnimeMangaCards.Controls[1]).LabelText = "Private";
                }
            }

            mangaPublic = mangaList != null;
            this.loaded++;
            LoadingUI(false);
        }

        /// <summary>
        /// Creates all the manga/anime lists.
        /// </summary>
        private void CreateLists(EntryType type)
        {
            if (type == EntryType.Anime)
            {
                tlpAnimelistMain.Controls.AddRange(new EntryList[] {
                    new EntryList("Watching", EntryType.Anime) { Dock = DockStyle.Fill },
                    new EntryList("Completed", EntryType.Anime) { Dock = DockStyle.Fill },
                    new EntryList("On Hold", EntryType.Anime) { Dock = DockStyle.Fill },
                    new EntryList("Dropped", EntryType.Anime) { Dock = DockStyle.Fill },
                    new EntryList("Plan to Watch", EntryType.Anime) { Dock = DockStyle.Fill }
                });
            }
            else
            {
                tlpMangalistMain.Controls.AddRange(new EntryList[] {
                new EntryList("Reading", EntryType.Manga) { Dock = DockStyle.Fill },
                new EntryList("Completed", EntryType.Manga) { Dock = DockStyle.Fill },
                new EntryList("On Hold", EntryType.Manga) { Dock = DockStyle.Fill },
                new EntryList("Dropped", EntryType.Manga) { Dock = DockStyle.Fill },
                new EntryList("Plan to Read", EntryType.Manga) { Dock = DockStyle.Fill }
                });
            }
        }

        /// <summary>
        /// Refreshes the lists' UI.
        /// </summary>
        private void RefreshLists(EntryType type)
        {
            if (type == EntryType.Anime)
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
            }
            else
            {
                #region Mangalist creation

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
            }

            CreateLists(type);
        }

        /// <summary>
        /// Resizes the table to fit the content.
        /// </summary>
        private void ResizeTable(EntryType type)
        {
            if (type == EntryType.Anime)
            {
                for (int i = 0; i < tlpAnimelistMain.RowCount; i++)
                {
                    if (i != 5)
                    {
                        tlpAnimelistMain.RowStyles[i] = new RowStyle(SizeType.Absolute, ((EntryList)tlpAnimelistMain.Controls[i]).ListHeight + ((EntryList)tlpAnimelistMain.Controls[i]).Margin.Bottom);
                    }
                    else
                    {
                        tlpAnimelistMain.RowStyles[i] = new RowStyle(SizeType.Absolute, 0F);
                    }
                }
            }
            else
            {
                for (int i = 0; i < tlpMangalistMain.RowCount; i++)
                {
                    if (i != 5)
                    {
                        tlpMangalistMain.RowStyles[i] = new RowStyle(SizeType.Absolute, ((EntryList)tlpMangalistMain.Controls[i]).ListHeight + ((EntryList)tlpMangalistMain.Controls[i]).Margin.Bottom);
                    }
                    else
                    {
                        tlpMangalistMain.RowStyles[i] = new RowStyle(SizeType.Absolute, 0F);
                    }
                } 
            }
        }

        /// <summary>
        /// Toggles the loading UI.
        /// </summary>
        /// <param name="mode"></param>
        private void LoadingUI(bool mode = true)
        {
            if (pDashboard.InvokeRequired)
            {
                pDashboard.Invoke((MethodInvoker)delegate
                {
                    tlpDashboardMain.VerticalScroll.Value = 0;
                    tlpAnimelistMain.VerticalScroll.Value = 0;
                    tlpMangalistMain.VerticalScroll.Value = 0;

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
                    else if (mode == false && this.loaded == 6)
                    {
                        if (animePublic)
                        {
                            tcDashboard.TabPages.Add(tpAnimelist);
                        }

                        if (mangaPublic)
                        {
                            tcDashboard.TabPages.Add(tpMangalist);
                        }

                        bUser.Text = "Unload this MAL account";
                        pbDashBoardLoad.Visible = false;
                        lMALAccPreview.Visible = false;
                        tlpDashboardMain.Visible = true;
                        bUser.Enabled = true;
                    }
                });
            }
            else
            {
                tlpDashboardMain.VerticalScroll.Value = 0;
                tlpAnimelistMain.VerticalScroll.Value = 0;
                tlpMangalistMain.VerticalScroll.Value = 0;

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
                else if (mode == false && this.loaded == 6)
                {
                    if (animePublic)
                    {
                        tcDashboard.TabPages.Add(tpAnimelist);
                    }

                    if (mangaPublic)
                    {
                        tcDashboard.TabPages.Add(tpMangalist);
                    }

                    bUser.Text = "Unload this MAL account";
                    pbDashBoardLoad.Visible = false;
                    lMALAccPreview.Visible = false;
                    tlpDashboardMain.Visible = true;
                    bUser.Enabled = true;
                }
            }
        }

        /// <summary>
        /// Creates the UI cards.
        /// </summary>
        private void CreateCards()
        {
            #region Profile card

            Card profileInfoCard = new Card()
            {
                Dock = DockStyle.Fill,
                Icon = Properties.Resources.icon_user,
                Margin = new Padding(0, 0, 19, 0),
                Title = "User information"
            };

            profileInfoCard.Content.Controls.Add(pCardProfileInfo);
            tlpUserInfo.Controls.Add(profileInfoCard);

            #endregion

            #region Redirect card

            Card redirectCard = new Card()
            {
                Dock = DockStyle.Fill,
                Icon = Properties.Resources.icon_link,
                Margin = new Padding(19, 0, 0, 0),
                Title = "Redirects"
            };

            redirectCard.Content.Controls.Add(pRedirectCard);
            tlpUserInfo.Controls.Add(redirectCard);

            #endregion

            #region Anime stats card

            Card animeStatsCard = new Card()
            {
                Dock = DockStyle.Fill,
                Icon = Properties.Resources.icon_anime,
                LabelVisibility = true,
                Margin = new Padding(0, 0, 19, 0),
                Title = "Anime Stats"
            };

            animeStatsCard.Content.Controls.Add(pDashAnimeCard);
            tlpAnimeMangaCards.Controls.Add(animeStatsCard);

            #endregion

            #region Manga stats card

            Card mangaStatsCard = new Card()
            {
                Dock = DockStyle.Fill,
                Icon = Properties.Resources.icon_manga,
                LabelVisibility = true,
                Margin = new Padding(19, 0, 0, 0),
                Title = "Manga Stats"
            };

            mangaStatsCard.Content.Controls.Add(pDashMangaCard);
            tlpAnimeMangaCards.Controls.Add(mangaStatsCard);

            #endregion

            #region Favorites card

            Card favoritesCard = new Card()
            {
                Dock = DockStyle.Fill,
                Icon = Properties.Resources.icon_favorite,
                Margin = new Padding(0, 0, 0, 19),
                Title = "Favorites"
            };

            favoritesCard.Content.Controls.Add(tlpFavorites);
            pDashFavorites.Controls.Add(favoritesCard);

            #endregion

            #region About card

            Card aboutCard = new Card()
            {
                Dock = DockStyle.Fill,
                Icon = Properties.Resources.icon_info,
                Margin = new Padding(0, 19, 0, 0),
                Title = "About"
            };

            aboutCard.Content.Controls.Add(pDashAbout);
            tlpDashboardMain.Controls.Add(aboutCard);

            #endregion
        }

        #endregion

        private void bMALProfile_Click_1(object sender, EventArgs e)
        {

        }

        private void BNew_Click(object sender, EventArgs e) => (new NewReview()).ShowDialog();
    }
}
