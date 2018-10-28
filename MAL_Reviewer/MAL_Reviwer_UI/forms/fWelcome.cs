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

        private void bNew_Click(object sender, EventArgs e)
        {
            (new fNewReview()).ShowDialog();
        }

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
                });
            });

            LoadingUI(false);
        }

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

        private void bMALProfile_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start(((Button)sender).Tag.ToString());
        }
    }
}
