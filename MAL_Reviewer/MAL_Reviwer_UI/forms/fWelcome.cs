using System;
using System.Drawing;
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

            lTitle.Text = Properties.Settings.Default["title"].ToString();
            lVersion.Text = Properties.Settings.Default["version"].ToString();
            
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

        private void FLoadUser_UserLoadedEvent(object sender, MALUserModel user)
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

            bUser.Text = "Unload this MAL account";
        }

        private void bMALProfile_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start(((Button)sender).Tag.ToString());
        }
    }
}
