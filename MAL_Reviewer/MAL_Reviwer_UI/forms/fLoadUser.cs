using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MAL_Reviwer_UI.forms
{
    public partial class fLoadUser : Form
    {
        public fLoadUser()
        {
            InitializeComponent();
        }

        private void bLoad_Click(object sender, EventArgs e)
        {
            try
            {
                if (!IsValidUsername()) throw new Exception("Please input a valid username!");
                // if () throw new Exception();

                pbLoading.Visible = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Notice", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            finally
            {
                pbLoading.Visible = false;
            }
        }

        private void llNoAcc_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start("https://myanimelist.net/register.php");
        }

        private bool IsValidUsername()
        {
            string username = tbMALUsername.Text.Trim();

            return username.Length > 2;
        }
    }
}
