using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using BL;
namespace Login
{
    public partial class FormNewUser : Form
    {
        String user;
        String admin;
        bool isNewUser;
        public FormNewUser(String admin, String user, String noOfAds, bool isNewUser)
        {
            this.isNewUser = isNewUser;
            this.admin = admin;
            this.user = user;
            InitializeComponent();
            this.usernameText.Text = user;
            this.noOfAdsText.Text = noOfAds;
            if (isNewUser)
            {
                this.usernameText.Enabled = true;
                this.deleteButton.Enabled = false;
            }
        }

        private void okButton_Click(object sender, EventArgs e)
        {
            if (isNewUser)
            {
                user = usernameText.Text;
                if (user.Equals(""))
                {
                    MessageBox.Show("Add username!");
                }
                else
                {
                    UserService userService = new UserService();
                    userService.addUser(user);
                }
            }
            this.Close();
            FormAdmin formAdmin = new FormAdmin(admin);
            formAdmin.Show();
        }

        private void deleteButton_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Are you sure?", "Confirmation", MessageBoxButtons.YesNo);
            if (result.Equals(DialogResult.Yes))
            {
                UserService userService = new UserService();
                userService.deleteUser(user);
                this.Close();
                FormAdmin formAdmin = new FormAdmin(admin);
                formAdmin.Show();
            }
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            this.Close();
            FormAdmin formAdmin = new FormAdmin(admin);
            formAdmin.Show();
        }
    }
}
