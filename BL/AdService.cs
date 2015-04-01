using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Entities;
using DAL;

namespace BL
{
    public class AdService
    {
        AdDAL adDAL;

        public AdService()
        {
            adDAL = new AdDAL();
        }
        public List<String> getAllTitles()
        {
            List<String> titlesList;
            titlesList = adDAL.getAllTitles();
            return titlesList;
        }

        public List<String> getUserTitles(String username)
        {
            List<String> titlesList;
            titlesList = adDAL.getUserTitles(username);
            return titlesList;
        }

        public Ad getAd(String title)
        {
            Ad ad = adDAL.getAd(title);
            String path = retransformPicturePath(ad.getPicturePath());
            ad.setPicturePath(path);
            return ad;
        }

        public void deleteAd(String title)
        {
            adDAL.deleteAd(title);
        }

        public void updateAd(String oldTitle, String newTitle, String newDescription,String username,String newPicturePath)
        {
            String path = transformPicturePath(newPicturePath);
            if (oldTitle.Equals(newTitle))
            {
                adDAL.updateAd(oldTitle, newDescription, path);
            }
            else
            {
                adDAL.deleteAd(oldTitle);
                adDAL.addAd(newTitle, newDescription,username,path);
            }
        }

        private String transformPicturePath(String picturePath)
        {
            StringBuilder path = new StringBuilder();

            for (int i = 0; i < picturePath.Length; i++)
            {
                if (picturePath[i].Equals('\\'))
                {
                    path.Append("@");
                }
                else
                {
                    path.Append(picturePath[i]);
                }
            }
            return path.ToString();
        }

        private String retransformPicturePath(String picturePath)
        {
            StringBuilder path = new StringBuilder();

            for (int i = 0; i < picturePath.Length; i++)
            {
                if (picturePath[i].Equals('@'))
                {
                    path.Append("\\");
                }
                else
                {
                    path.Append(picturePath[i]);
                }
            }
            return path.ToString();
        }
    }
}
