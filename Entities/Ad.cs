using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Entities
{
    public class Ad
    {
        private String title;
        private String description;
        private String username;
        private String picturePath;
        
        public Ad(String title, String description,String username,String picturePath)
        {
            this.title = title;
            this.description = description;
            this.username = username;
            this.picturePath = picturePath;
        }

        public String getTitle()
        {
            return this.title;
        }

        public String getDescription()
        {
            return this.description;
        }

        public string getUsername()
        {
            return this.username;
        }

        public String getPicturePath()
        {
            return this.picturePath;
        }

        public void setPicturePath(String picturePath)
        {
            this.picturePath = picturePath;
        }
    }
}
