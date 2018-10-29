using System;
using System.Windows.Forms;
using MAL_Reviewer_API;
using MAL_Reviewer_API.models;

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

            pbLoading.Visible = true;

            try
            {
                if (username.Length < 3) throw new Exception("Please input a valid username!");

                MALUserModel userModel = await MALHelper.GetUser(username);

                if (userModel == null) throw new Exception($"No user under the username “{ username }” was found!");
                else
                {
                    this.Close();
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
                this.ActiveControl = tbMALUsername;
            }
        }

        private void llNoAcc_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start("https://myanimelist.net/register.php");
        }
    }
}
