using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Microsoft.Win32;

using Entities;
using BL;

namespace Login
{
    public partial class FormAd : Form
    {
        AdService adService;
        String username;
        String title;
        String picturePath;
        public FormAd(String title, String description, String username,String picturePath, bool isNewAd)
        {
            this.picturePath = picturePath;
            this.username = username;
            this.title = title;
            adService = new AdService();
            InitializeComponent();

            if (isNewAd)
                this.deleteButton.Enabled = false;
            titleText.Text = title;
            descriptionText.Text = description;

            try {
                Image image = Image.FromFile(picturePath);
                Size newSize = new Size(pictureBox.Width, pictureBox.Height);
                Image resizedImage = new Bitmap(image,newSize);
                
                pictureBox.Image = resizedImage;
            }
            catch(System.IO.FileNotFoundException e)
            {

            }
            catch(System.ArgumentException e)
            {

            }
        }

        private void deleteButton_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Are you sure?","Confirmation", MessageBoxButtons.YesNo);
            if (result.Equals(DialogResult.Yes))
            {
                adService.deleteAd(title);
                FormUser formUser = new FormUser(username);
                formUser.Show();
                this.Close();
            }
            
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            FormUser formUser = new FormUser(username);
            formUser.Show();
            this.Close();
        }

        private void saveButton_Click(object sender, EventArgs e)
        {
            String newTitle = this.titleText.Text;
            if (newTitle.Equals(""))
            {
                MessageBox.Show("Please add title!");
            }
            else
            {
                String newDescription = this.descriptionText.Text;
                adService.updateAd(title, newTitle, newDescription,username,picturePath);
                FormUser formUser = new FormUser(username);
                formUser.Show();
                this.Close();
            }
        }

        private void pictureBox_Click(object sender, EventArgs e)
        {
            OpenFileDialog dlg = new OpenFileDialog();
            DialogResult result =  dlg.ShowDialog();

           if(result == DialogResult.OK)
            {
                picturePath = dlg.FileName;
                this.pictureBox.Image = Image.FromFile(picturePath);
            }
        }
    }
}
