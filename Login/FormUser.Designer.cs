namespace Login
{
    partial class FormUser
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
            this.logoutButton = new System.Windows.Forms.Button();
            this.adTable = new System.Windows.Forms.TableLayoutPanel();
            this.newButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // logoutButton
            // 
            this.logoutButton.Location = new System.Drawing.Point(223, 216);
            this.logoutButton.Name = "logoutButton";
            this.logoutButton.Size = new System.Drawing.Size(75, 23);
            this.logoutButton.TabIndex = 2;
            this.logoutButton.Text = "Logout";
            this.logoutButton.UseVisualStyleBackColor = true;
            this.logoutButton.Click += new System.EventHandler(this.logoutButton_Click);
            // 
            // adTable
            // 
            this.adTable.AutoScroll = true;
            this.adTable.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.Inset;
            this.adTable.ColumnCount = 2;
            this.adTable.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.adTable.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.adTable.Location = new System.Drawing.Point(12, 12);
            this.adTable.Name = "adTable";
            this.adTable.RowCount = 1;
            this.adTable.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.adTable.Size = new System.Drawing.Size(286, 198);
            this.adTable.TabIndex = 3;
            // 
            // newButton
            // 
            this.newButton.Location = new System.Drawing.Point(12, 216);
            this.newButton.Name = "newButton";
            this.newButton.Size = new System.Drawing.Size(75, 23);
            this.newButton.TabIndex = 4;
            this.newButton.Text = "New";
            this.newButton.UseVisualStyleBackColor = true;
            this.newButton.Click += new System.EventHandler(this.newButton_Click);
            // 
            // FormUser
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(314, 244);
            this.Controls.Add(this.newButton);
            this.Controls.Add(this.adTable);
            this.Controls.Add(this.logoutButton);
            this.Name = "FormUser";
            this.Text = "FormUser";
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button logoutButton;
        private System.Windows.Forms.TableLayoutPanel adTable;
        private System.Windows.Forms.Button newButton;
    }
}