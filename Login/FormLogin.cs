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
    public partial class LoginForm : Form
    {
        UserService userService;

        public LoginForm()
        {
            userService = new UserService();
            InitializeComponent();
        }

        private void okButton_Click(object sender, EventArgs e)
        {

             string username = usernameText.Text;
             string password = passwordText.Text;
             if (username == "" || password == "") MessageBox.Show("Introduceti username si parola");
             else
             {
                 String role = userService.login(username, password);
                 if (role == null)
                     MessageBox.Show("Username sau parola incorecta");
                 else
                 {
                     if (role.Equals("admin"))
                     {
                        FormAdmin admin = new FormAdmin(username);
                         admin.Show();
                    }
                     else
                     {
                        FormUser user = new FormUser(username);
                        
                        user.Show();


                    }
                    
                }
             }

        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void forgotPasswordLabel_Click(object sender, EventArgs e)
        {
            string username = usernameText.Text;
            if (username == "") MessageBox.Show("Insert an username ! ");
            else
            {

                string password = userService.resetPassword(username);
                if (password.Equals("fail"))
                    MessageBox.Show("Fail!");
                else MessageBox.Show(password);
            }
        }
    }
}
