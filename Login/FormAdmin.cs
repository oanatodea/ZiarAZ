using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using BL;
using Entities;

namespace Login
{
    public partial class FormAdmin : Form
    {
        UserService userService;
        String username;

        public FormAdmin(string username)
        {
            this.username = username;
            userService = new UserService();

            InitializeComponent();
            List<String> usersList;
            usersList = userService.getAllUsers();
            addtextbox(usersList);

            this.Text = "Admin: " + username;
        }

        private void addtextbox(List<String> usersList)
        {
            Label lblId = new Label();
            Label lblUsername = new Label();
            Label lblNoOfADs = new Label();
            lblId.Text = "No.";
            lblUsername.Text = "User";
            lblNoOfADs.Text = "No. of Ads";
            userTable.Controls.Add(lblId, 0, 0);
            userTable.Controls.Add(lblUsername, 1, 0);
            userTable.Controls.Add(lblNoOfADs, 2, 0);

            foreach (String user in usersList)
            {
                int rowIndex = AddTableRow();
                this.userTable.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
                lblId = new Label();
                lblUsername = new Label();
                lblNoOfADs = new Label();
                lblId.Text = rowIndex.ToString();
                lblUsername.Text = user;
                lblNoOfADs.Text = userService.getUserReports(user);
                lblUsername.Click += new System.EventHandler(this.usernameLabel_Click);
                userTable.Controls.Add(lblId, 0, rowIndex);
                userTable.Controls.Add(lblUsername, 1, rowIndex);
                userTable.Controls.Add(lblNoOfADs, 2, rowIndex);
            }
        }
        private int AddTableRow()
        {
            int index = this.userTable.RowCount++;
            RowStyle style = new RowStyle(SizeType.AutoSize);
            userTable.RowStyles.Add(style);
            return index;
        }

        private void usernameLabel_Click(object sender, EventArgs e)
        {
            String user = ((Label)sender).Text;
            String noOfAds = userService.getUserReports(user);
            FormNewUser newUser = new FormNewUser(username,user, noOfAds, false);
            newUser.Show();
            this.Close();
        }
        private void logoutButton_Click(object sender, EventArgs e)
        {
            
            this.Close();
        }

        private void newButton_Click(object sender, EventArgs e)
        {
            
            FormNewUser newUser = new FormNewUser(username,"","0",true);
            newUser.Show();
            this.Close();
        }
    }
}
