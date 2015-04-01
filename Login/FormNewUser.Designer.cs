namespace Login
{
    partial class FormNewUser
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.usernameLabel = new System.Windows.Forms.Label();
            this.noOfAdsLabel = new System.Windows.Forms.Label();
            this.usernameText = new System.Windows.Forms.TextBox();
            this.noOfAdsText = new System.Windows.Forms.TextBox();
            this.deleteButton = new System.Windows.Forms.Button();
            this.okButton = new System.Windows.Forms.Button();
            this.cancelButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // usernameLabel
            // 
            this.usernameLabel.AutoSize = true;
            this.usernameLabel.Location = new System.Drawing.Point(12, 20);
            this.usernameLabel.Name = "usernameLabel";
            this.usernameLabel.Size = new System.Drawing.Size(61, 13);
            this.usernameLabel.TabIndex = 0;
            this.usernameLabel.Text = "Username :";
            // 
            // noOfAdsLabel
            // 
            this.noOfAdsLabel.AutoSize = true;
            this.noOfAdsLabel.Location = new System.Drawing.Point(12, 46);
            this.noOfAdsLabel.Name = "noOfAdsLabel";
            this.noOfAdsLabel.Size = new System.Drawing.Size(68, 13);
            this.noOfAdsLabel.TabIndex = 1;
            this.noOfAdsLabel.Text = "No. Of Ads : ";
            // 
            // usernameText
            // 
            this.usernameText.Enabled = false;
            this.usernameText.Location = new System.Drawing.Point(92, 13);
            this.usernameText.Name = "usernameText";
            this.usernameText.Size = new System.Drawing.Size(100, 20);
            this.usernameText.TabIndex = 2;
            // 
            // noOfAdsText
            // 
            this.noOfAdsText.Enabled = false;
            this.noOfAdsText.Location = new System.Drawing.Point(92, 43);
            this.noOfAdsText.Name = "noOfAdsText";
            this.noOfAdsText.Size = new System.Drawing.Size(100, 20);
            this.noOfAdsText.TabIndex = 3;
            // 
            // deleteButton
            // 
            this.deleteButton.Location = new System.Drawing.Point(214, 15);
            this.deleteButton.Name = "deleteButton";
            this.deleteButton.Size = new System.Drawing.Size(75, 23);
            this.deleteButton.TabIndex = 4;
            this.deleteButton.Text = "Delete";
            this.deleteButton.UseVisualStyleBackColor = true;
            this.deleteButton.Click += new System.EventHandler(this.deleteButton_Click);
            // 
            // okButton
            // 
            this.okButton.Location = new System.Drawing.Point(5, 75);
            this.okButton.Name = "okButton";
            this.okButton.Size = new System.Drawing.Size(75, 23);
            this.okButton.TabIndex = 5;
            this.okButton.Text = "Ok";
            this.okButton.UseVisualStyleBackColor = true;
            this.okButton.Click += new System.EventHandler(this.okButton_Click);
            // 
            // cancelButton
            // 
            this.cancelButton.Location = new System.Drawing.Point(117, 75);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Size = new System.Drawing.Size(75, 23);
            this.cancelButton.TabIndex = 6;
            this.cancelButton.Text = "Cancel";
            this.cancelButton.UseVisualStyleBackColor = true;
            this.cancelButton.Click += new System.EventHandler(this.cancelButton_Click);
            // 
            // FormNewUser
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(292, 103);
            this.Controls.Add(this.cancelButton);
            this.Controls.Add(this.okButton);
            this.Controls.Add(this.deleteButton);
            this.Controls.Add(this.noOfAdsText);
            this.Controls.Add(this.usernameText);
            this.Controls.Add(this.noOfAdsLabel);
            this.Controls.Add(this.usernameLabel);
            this.Name = "FormNewUser";
            this.Text = "FormNewUser";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label usernameLabel;
        private System.Windows.Forms.Label noOfAdsLabel;
        private System.Windows.Forms.TextBox usernameText;
        private System.Windows.Forms.TextBox noOfAdsText;
        private System.Windows.Forms.Button deleteButton;
        private System.Windows.Forms.Button okButton;
        private System.Windows.Forms.Button cancelButton;
    }
}