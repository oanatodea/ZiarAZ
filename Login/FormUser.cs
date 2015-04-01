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
    public partial class FormUser : Form
    {
        AdService adService;
        String username;

        public FormUser(String username)
        {
            this.username = username;
            adService = new AdService();
            
            InitializeComponent();
            List<String> titlesList;
            titlesList = adService.getUserTitles(username);
            addtextbox(titlesList);

            this.Text = "User: " + username;
        }

        private void addtextbox(List<String> titlesList)
        {
            Label lblId = new Label();
            Label lblTitle = new Label ();
            lblId.Text = "No.";
            lblTitle.Text = "Title";
            adTable.Controls.Add(lblId, 0, 0);
            adTable.Controls.Add(lblTitle, 1, 0);

            foreach (String title in titlesList)
            {
                int rowIndex = AddTableRow();
                this.adTable.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
                lblId = new Label();
                lblTitle = new Label();
                lblId.Text = rowIndex.ToString();
                lblTitle.Text = title;
                lblTitle.Click += new System.EventHandler(this.titleLabel_Click);
                adTable.Controls.Add(lblId, 0, rowIndex);
                adTable.Controls.Add(lblTitle, 1, rowIndex);
            }


        }
        private int AddTableRow()
        {
            int index = this.adTable.RowCount++;
            RowStyle style = new RowStyle(SizeType.AutoSize);
            adTable.RowStyles.Add(style);
            return index;
        }

        private void titleLabel_Click(object sender, EventArgs e)
        {
            String title = ((Label)sender).Text;
            String description = adService.getAd(title).getDescription();
            String picturePath = adService.getAd(title).getPicturePath();
            FormAd formAd = new FormAd(title,description,username,picturePath,false);
            formAd.Show();
            this.Close();
        }

        private void newButton_Click(object sender, EventArgs e)
        {
            FormAd formAd = new FormAd("","", username,"",true);
            formAd.Show();
            this.Close();
        }

        private void logoutButton_Click(object sender, EventArgs e)
        { 
            this.Close();
        }
    }
}
