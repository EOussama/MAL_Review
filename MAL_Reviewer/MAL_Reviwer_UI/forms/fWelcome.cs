using System;
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
            (new fLoadUser()).ShowDialog();
            /*MALUserModel user = await MALHelper.GetUser("EOussama");

            lUserUsername.Text = user.username;
            lUserGender.Text = user.gender;
            lUserJoinDate.Text = user.joined.ToShortDateString();
            lUserBirthday.Text = user.birthday.ToShortDateString();
            lUserLocation.Text = user.location;
            bMALProfile.Tag = user.url;
            pbUserImage.Load(user.image_url);

            ttExtendedInfo.SetToolTip(lUserUsername, user.username);
            ttExtendedInfo.SetToolTip(lUserGender, user.gender);
            ttExtendedInfo.SetToolTip(lUserJoinDate, user.joined.ToShortDateString());
            ttExtendedInfo.SetToolTip(lUserBirthday, user.birthday.ToShortDateString());
            ttExtendedInfo.SetToolTip(lUserLocation, user.location);*/
        }

        private void bMALProfile_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start(((Button)sender).Tag.ToString());
        }
    }
}
