using System;
using System.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Windows.Forms;
using MAL_Reviewer_UI.user_controls;
using MAL_Reviewer_API.models.ListEntryModels;
using MAL_Reviewer_API.models.UserModels;
using MAL_Reviewer_Core;
using MAL_Reviewer_Core.enumerations;

namespace MAL_Reviewer_UI.forms
{
    /// <summary>
    /// The application's initial form.
    /// The home of the dashboard and the bridge to other parts of the application.
    /// </summary>
    public partial class WelcomeForm : Form
    {
        #region Fields

        private bool
            // Whether the Anime list is public or private.
            animePublic = true,

            // Whether the Manga list is public or private.
            mangaPublic = true;

        /// <summary>
        /// The number of loaded entries.
        /// </summary>
        private short loaded = 0;

        #endregion

        #region Constructors

        /// <summary>
        /// Parameterless constructor.
        /// </summary>
        public WelcomeForm()
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

            // Creating the card UI.
            CreateCards();
            CreateLists(TargetType.Anime);
            CreateLists(TargetType.Manga);
        }

        #endregion

        #region User Data Load

        /// <summary>
        /// Handles the click that opens the user's data loading form.
        /// </summary>
        /// <param name="sender"> The sender. </param>
        /// <param name="e"> The event's arguments. </param>
        private void BUser_Click(object sender, EventArgs e)
        {
            // Check if the current user is null, (Meaning no user is connected),
            // if yes, opening the LoadUserForm.
            if (Core.User == null)
            {
                LoadUserForm fLoadUser = new LoadUserForm();

                fLoadUser.UserLoadedEvent += FLoadUser_UserLoadedEvent;
                fLoadUser.ShowDialog();
            }
            // If not, informing the user of the loaded MAL account
            // before loading another one.
            else
            {
                if (DialogResult.Yes == MessageBox.Show("A MAL user is already loaded, are you sure you want to load another one?", "Notice", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2))
                {
                    LoadUserForm fLoadUser = new LoadUserForm();

                    fLoadUser.UserLoadedEvent += FLoadUser_UserLoadedEvent;
                    fLoadUser.ShowDialog();
                }
            }
        }

        /// <summary>
        /// Handles the event of when the user's data is loaded.
        /// </summary>
        /// <param name="sender"> The sender. </param>
        /// <param name="e"> The event's arguments. </param>
        private async void FLoadUser_UserLoadedEvent(object sender, MALUserModel user)
        {
            // Resetting the loading state.
            this.loaded = 0;

            // Toggling the loading UI ON.
            LoadingUI();

            //Updating the UI from another thread.
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

        /// <summary>
        /// Triggers when the form is loaded.
        /// </summary>
        /// <param name="sender"> The sender. </param>
        /// <param name="e"> The event's arguments. </param>
        private void WelcomeForm_Load(object sender, EventArgs e)
        {
            // Loading the user's data.
            LoadDefaultUser();
        }

        /// <summary>
        /// Loads the default user.
        /// </summary>
        public void LoadDefaultUser()
        {
            // Getting the default user's name.
            string defaultUsername = Core.Settings.UserSettings.DefaultUser?.Username ?? "";

            // Checking if the username is valid.
            // If yes, automatically loading their data.
            if (defaultUsername.Trim().Length > 0)
            {
                LoadUserForm loadUserForm = new LoadUserForm(defaultUsername);

                loadUserForm.UserLoadedEvent += FLoadUser_UserLoadedEvent;
                loadUserForm.ShowDialog();
            }
        }

        #endregion

        #region Dashboard management

        /// <summary>
        /// Redirects to the user's MAL profile page.
        /// </summary>
        /// <param name="sender"> The sender. </param>
        /// <param name="e"> The event's arguments. </param>
        private void BMALProfile_Click(object sender, EventArgs e) => System.Diagnostics.Process.Start(((Button)sender).Tag.ToString());

        /// <summary>
        /// Redirects to the user's MAL friends page.
        /// </summary>
        /// <param name="sender"> The sender. </param>
        /// <param name="e"> The event's arguments. </param>
        private void BMALFriends_Click(object sender, EventArgs e) => System.Diagnostics.Process.Start(((Button)sender).Tag.ToString());

        /// <summary>
        /// Redirects to the user's Anime list on MAL.
        /// </summary>
        /// <param name="sender"> The sender. </param>
        /// <param name="e"> The event's arguments. </param>
        private void BMALAnimelist_Click(object sender, EventArgs e) => System.Diagnostics.Process.Start(((Button)sender).Tag.ToString());

        /// <summary>
        /// Redirects to the user's Manga list on MAL.
        /// </summary>
        /// <param name="sender"> The sender. </param>
        /// <param name="e"> The event's arguments. </param>
        private void BMALMangalist_Click(object sender, EventArgs e) => System.Diagnostics.Process.Start(((Button)sender).Tag.ToString());

        #endregion

        #region Visual updates

        /// <summary>
        /// Updates the UI with the user's information.
        /// </summary>
        /// <param name="user"> The user's information object. </param>
        /// <returns> The task it run on. </returns>
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
                    {
                        pbUserImage.Load(user.Image_url);
                    }
                    else
                    {
                        pbUserImage.Image = Properties.Resources.icon_user;
                    }

                    ttExtendedInfo.SetToolTip(lUserUsername, user.Username);
                    ttExtendedInfo.SetToolTip(lUserGender, user.Gender);
                    ttExtendedInfo.SetToolTip(lUserJoinDate, user.Joined?.ToLongDateString());
                    ttExtendedInfo.SetToolTip(lUserBirthday, user.Birthday?.ToLongDateString());
                    ttExtendedInfo.SetToolTip(lUserLocation, user.Location);

                    bMALProfile.Tag = user.Url;
                    bMALFriends.Tag = $"https://myanimelist.net/profile/{ user.Username }/friends";
                    bMALAnimelist.Tag = $"https://myanimelist.net/animelist/{ user.Username }";
                    bMALMangalist.Tag = $"https://myanimelist.net/mangalist/{ user.Username }";

                    this.loaded++;
                    LoadingUI(false);
                });
            });
        }

        /// <summary>
        /// Updates the UI of Anime stats.
        /// </summary>
        /// <param name="user"> The user's information object. </param>
        /// <returns> The task it run on. </returns>
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
        /// Updates the UI of Manga stats.
        /// </summary>
        /// <param name="user"> The user's information object. </param>
        /// <returns> The task it run on. </returns>
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
        /// Updates the UI of favorite lists.
        /// </summary>
        /// <param name="user"> The user's information object. </param>
        /// <returns> The task it run on. </returns>
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

                    // Favourite Anime update.
                    foreach (FavAnimeModel favAnimeModel in user.Favorites.Anime)
                    {
                        await Task.Run(() =>
                        {
                            pDashboard.Invoke((MethodInvoker)delegate
                            {
                                FavoriteThumbControl ucFavThumb = new FavoriteThumbControl(favAnimeModel.Name, favAnimeModel.Image_url, "Anime")
                                {
                                    Tag = favAnimeModel.Url,
                                    Dock = DockStyle.Top
                                };

                                pChildAnime.Controls.Add(ucFavThumb);
                            });
                        });
                    }

                    // Favourite Manga update.
                    foreach (FavMangaModel favMangaModel in user.Favorites.Manga)
                    {
                        await Task.Run(() =>
                        {
                            pDashboard.Invoke((MethodInvoker)delegate
                            {
                                FavoriteThumbControl ucFavThumb = new FavoriteThumbControl(favMangaModel.Name, favMangaModel.Image_url, "Manga")
                                {
                                    Tag = favMangaModel.Url,
                                    Dock = DockStyle.Top
                                };

                                pChildManga.Controls.Add(ucFavThumb);
                            });
                        });
                    }

                    // Favourite characters update.
                    foreach (FavCharactersModel favCharacterModel in user.Favorites.Characters)
                    {
                        await Task.Run(() =>
                        {
                            pDashboard.Invoke((MethodInvoker)delegate
                            {
                                FavoriteThumbControl ucFavThumb = new FavoriteThumbControl(favCharacterModel.Name, favCharacterModel.Image_url, "Character")
                                {
                                    Tag = favCharacterModel.Url,
                                    Dock = DockStyle.Top
                                };

                                pChildCharacters.Controls.Add(ucFavThumb);
                            });
                        });
                    }

                    // Favourite people update.
                    foreach (FavPeopleModel favPeopleModel in user.Favorites.People)
                    {
                        await Task.Run(() =>
                        {
                            pDashboard.Invoke((MethodInvoker)delegate
                            {
                                FavoriteThumbControl ucFavThumb = new FavoriteThumbControl(favPeopleModel.Name, favPeopleModel.Image_url, "Person")
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
        /// Updates the UI of Anime list.
        /// </summary>
        /// <param name="animeList"> The user's Anime list. </param>
        /// <param name="user"> The user's information object. </param>
        /// <returns> The task it run on. </returns>
        private async Task AnimelistUpdateIU(IEnumerable<AnimelistEntryModel> animeList, MALUserModel user)
        {
            // Checking if the Anime list is public or private.
            animePublic = animeList != null;

            if (animeList != null)
            {
                if (user.Anime_stats.Total_entries > 0)
                {
                    await Task.Run(() =>
                    {
                        void UpdateAnimeState()
                        {
                            ((CardControl)tlpAnimeMangaCards.Controls[0]).LabelText = "Public";
                            ((CardControl)tlpAnimeMangaCards.Controls[0]).UpdateTooltip(user.Username);
                            bMALAnimelist.Enabled = animePublic;

                            RefreshLists(TargetType.Anime);

                            ((EntryListControl)tlpAnimelistMain.Controls[0]).UpdateList(animeList.Where(a => a.Watching_status == 1).ToList());
                            ((EntryListControl)tlpAnimelistMain.Controls[1]).UpdateList(animeList.Where(a => a.Watching_status == 2).ToList());
                            ((EntryListControl)tlpAnimelistMain.Controls[2]).UpdateList(animeList.Where(a => a.Watching_status == 3).ToList());
                            ((EntryListControl)tlpAnimelistMain.Controls[3]).UpdateList(animeList.Where(a => a.Watching_status == 4).ToList());
                            ((EntryListControl)tlpAnimelistMain.Controls[4]).UpdateList(animeList.Where(a => a.Watching_status == 6).ToList());

                            ResizeTable(TargetType.Anime);
                        }

                        if (tcDashboard.InvokeRequired)
                        {
                            tcDashboard.Invoke((MethodInvoker)delegate
                            {
                                UpdateAnimeState();
                            });
                        }
                        else
                        {
                            UpdateAnimeState();
                        }
                    });
                }
                else
                {
                    void UpdateAnimeState()
                    {
                        ((CardControl)tlpAnimeMangaCards.Controls[0]).LabelText = "Public";
                        ((CardControl)tlpAnimeMangaCards.Controls[0]).UpdateTooltip(user.Username);
                        bMALAnimelist.Enabled = animePublic;

                        RefreshLists(TargetType.Anime);

                        foreach (EntryListControl entryList in tlpAnimelistMain.Controls)
                        {
                            entryList.ClearList();
                        }

                        ResizeTable(TargetType.Anime);
                    }

                    if (tcDashboard.InvokeRequired)
                    {
                        tcDashboard.Invoke((MethodInvoker)delegate
                        {
                            UpdateAnimeState();
                        });
                    }
                    else
                    {
                        UpdateAnimeState();
                    }
                }
            }
            else
            {
                void UpdatingAnimeState()
                {
                    ((CardControl)tlpAnimeMangaCards.Controls[0]).LabelText = "Private";
                    ((CardControl)tlpAnimeMangaCards.Controls[0]).UpdateTooltip(user.Username);
                    bMALAnimelist.Enabled = animePublic;
                };

                if (tcDashboard.InvokeRequired)
                {
                    tcDashboard.Invoke((MethodInvoker)delegate
                    {
                        UpdatingAnimeState();
                    });
                }
                else
                {
                    UpdatingAnimeState();
                }
            }

            this.loaded++;
            LoadingUI(false);
        }

        /// <summary>
        /// Updates the UI of Anime list.
        /// </summary>
        /// <param name="mangaList"> The user's Manga list. </param>
        /// <param name="user"> The user's information object. </param>
        /// <returns> The task it run on. </returns>
        private async Task MangalistUpdateIU(IEnumerable<MangalistEntryModel> mangaList, MALUserModel user)
        {
            // Checking if the Manga list is public or private.
            mangaPublic = mangaList != null;

            if (mangaList != null)
            {
                if (user.Manga_stats.Total_entries > 0)
                {
                    await Task.Run(() =>
                    {
                        void UpdateMangaState()
                        {
                            ((CardControl)tlpAnimeMangaCards.Controls[1]).LabelText = "Public";
                            ((CardControl)tlpAnimeMangaCards.Controls[1]).UpdateTooltip(user.Username);
                            bMALMangalist.Enabled = mangaPublic;

                            RefreshLists(TargetType.Manga);

                            ((EntryListControl)tlpMangalistMain.Controls[0]).UpdateList(mangaList.Where(a => a.Reading_status == 1).ToList());
                            ((EntryListControl)tlpMangalistMain.Controls[1]).UpdateList(mangaList.Where(a => a.Reading_status == 2).ToList());
                            ((EntryListControl)tlpMangalistMain.Controls[2]).UpdateList(mangaList.Where(a => a.Reading_status == 3).ToList());
                            ((EntryListControl)tlpMangalistMain.Controls[3]).UpdateList(mangaList.Where(a => a.Reading_status == 4).ToList());
                            ((EntryListControl)tlpMangalistMain.Controls[4]).UpdateList(mangaList.Where(a => a.Reading_status == 6).ToList());

                            ResizeTable(TargetType.Manga);
                        }

                        if (tcDashboard.InvokeRequired)
                        {
                            tcDashboard.Invoke((MethodInvoker)delegate
                            {
                                UpdateMangaState();
                            });
                        }
                        else
                        {
                            UpdateMangaState();
                        }
                    });
                }
                else
                {
                    void UpdateMangaState()
                    {
                        ((CardControl)tlpAnimeMangaCards.Controls[1]).LabelText = "Public";
                        ((CardControl)tlpAnimeMangaCards.Controls[1]).UpdateTooltip(user.Username);
                        bMALMangalist.Enabled = mangaPublic;

                        RefreshLists(TargetType.Manga);

                        foreach (EntryListControl entryList in tlpMangalistMain.Controls)
                            entryList.ClearList();

                        ResizeTable(TargetType.Manga);
                    }

                    if (tcDashboard.InvokeRequired)
                    {
                        tcDashboard.Invoke((MethodInvoker)delegate
                        {
                            UpdateMangaState();
                        });
                    }
                    else
                    {
                        UpdateMangaState();
                    }
                }
            }
            else
            {
                void UpdatingMangaState()
                {
                    ((CardControl)tlpAnimeMangaCards.Controls[1]).LabelText = "Private";
                    ((CardControl)tlpAnimeMangaCards.Controls[1]).UpdateTooltip(user.Username);
                    bMALMangalist.Enabled = mangaPublic;
                }

                if (tcDashboard.InvokeRequired)
                {
                    tcDashboard.Invoke((MethodInvoker)delegate
                    {
                        UpdatingMangaState();
                    });
                }
                else
                {
                    UpdatingMangaState();
                }
            }

            this.loaded++;
            LoadingUI(false);
        }

        /// <summary>
        /// Creates all the Manga and Anime lists.
        /// </summary>
        /// <param name="type"> The type of entry (Anime or Manga). </param>
        private void CreateLists(TargetType type)
        {
            if (type == TargetType.Anime)
            {
                tlpAnimelistMain.Controls.AddRange(new EntryListControl[] {
                    new EntryListControl("Watching", TargetType.Anime) { Dock = DockStyle.Fill },
                    new EntryListControl("Completed", TargetType.Anime) { Dock = DockStyle.Fill },
                    new EntryListControl("On Hold", TargetType.Anime) { Dock = DockStyle.Fill },
                    new EntryListControl("Dropped", TargetType.Anime) { Dock = DockStyle.Fill },
                    new EntryListControl("Plan to Watch", TargetType.Anime) { Dock = DockStyle.Fill }
                });
            }
            else
            {
                tlpMangalistMain.Controls.AddRange(new EntryListControl[] {
                new EntryListControl("Reading", TargetType.Manga) { Dock = DockStyle.Fill },
                new EntryListControl("Completed", TargetType.Manga) { Dock = DockStyle.Fill },
                new EntryListControl("On Hold", TargetType.Manga) { Dock = DockStyle.Fill },
                new EntryListControl("Dropped", TargetType.Manga) { Dock = DockStyle.Fill },
                new EntryListControl("Plan to Read", TargetType.Manga) { Dock = DockStyle.Fill }
                });
            }
        }

        /// <summary>
        /// Refreshes the lists' UI.
        /// </summary>
        /// <param name="type"> The type of entry (Anime or Manga). </param>
        private void RefreshLists(TargetType type)
        {
            if (type == TargetType.Anime)
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
        /// <param name="type"> The type of entry (Anime or Manga). </param>
        private void ResizeTable(TargetType type)
        {
            if (type == TargetType.Anime)
            {
                for (int i = 0; i < tlpAnimelistMain.RowCount; i++)
                {
                    if (i != 5)
                    {
                        tlpAnimelistMain.RowStyles[i] = new RowStyle(SizeType.Absolute, ((EntryListControl)tlpAnimelistMain.Controls[i]).ListHeight + ((EntryListControl)tlpAnimelistMain.Controls[i]).Margin.Bottom);
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
                        tlpMangalistMain.RowStyles[i] = new RowStyle(SizeType.Absolute, ((EntryListControl)tlpMangalistMain.Controls[i]).ListHeight + ((EntryListControl)tlpMangalistMain.Controls[i]).Margin.Bottom);
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
            void loadingAction()
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

            if (pDashboard.InvokeRequired)
            {
                pDashboard.Invoke((MethodInvoker)delegate
                {
                    loadingAction();
                });
            }
            else
            {
                loadingAction();
            }
        }

        /// <summary>
        /// Creates the UI cards.
        /// </summary>
        private void CreateCards()
        {
            #region Profile card

            CardControl profileInfoCard = new CardControl()
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

            CardControl redirectCard = new CardControl()
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

            CardControl animeStatsCard = new CardControl()
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

            CardControl mangaStatsCard = new CardControl()
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

            CardControl favoritesCard = new CardControl()
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

            CardControl aboutCard = new CardControl()
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

        /// <summary>
        /// Handles the click on the settings button, which opens the settings' panel.
        /// </summary>
        /// <param name="sender"> The sender. </param>
        /// <param name="e"> The event's arguments. </param>
        private void BSettings_Click(object sender, EventArgs e) => (new SettingsForm()).ShowDialog();

        /// <summary>
        /// Handles the click on the new button, which opens a form for creating a new review.
        /// </summary>
        /// <param name="sender"> The sender. </param>
        /// <param name="e"> The event's arguments. </param>
        private void BNew_Click(object sender, EventArgs e) => (new NewReviewForm()).ShowDialog();
    }
}
