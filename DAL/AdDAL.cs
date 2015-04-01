using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using MySql.Data;
using MySql.Data.MySqlClient;

using Entities;

namespace DAL
{
    public class AdDAL
    {
        private static UsersDAL usersDAL = null;
        private String connectionString = @"Data Source=MASTER-PC\SQLEXPRESS;Initial Catalog=ps;User ID=sa;Password=cevaparola";
        MySqlConnection conn = null;

        public AdDAL()
        {
            connectionString = String.Format("server={0};user id={1}; password={2}; database={3}; pooling=false", "localhost", "root", "", "ziaraz");
            conn = new MySqlConnection(connectionString);
        }

        public Ad getAd(String title)
        {
            Ad ad = null;
            String query = "SELECT * FROM ad WHERE title= '" + title + "'";

            MySqlDataReader reader = sqlQuery(query);
            
            reader.Read();
            if (reader.HasRows)
            {
                ad = new Ad(reader["title"].ToString(), reader["description"].ToString(), reader["username"].ToString(), reader["picturePath"].ToString());
            }
            conn.Close();
            return ad;
        }

        public void deleteAd(String title)
        {
            String query = "DELETE FROM `ad` WHERE title = '" + title+ "'";
            MySqlDataReader reader = sqlQuery(query);
            conn.Close();
        }

        public void updateAd(String title, String newDescription,String newPicturePath)
        {
            String query = "UPDATE ad set description = '" + newDescription + "', picturePath = '"+ newPicturePath +"' where title = '" + title + "'";

            MySqlDataReader reader = sqlQuery(query);
            conn.Close();
        }

        public void addAd(String title, String description,String username,String picturePath)
        {
            String query = "INSERT INTO `ad`(`title`, `description`,`username`,`picturePath`) VALUES ('" + title +"','"+ description +"','" +username +"','"+ picturePath + "')";

            MySqlDataReader reader = sqlQuery(query);
            reader.Read();
            conn.Close();
        }

        public List<String> getAllTitles()
        {
            List<String> titlesList = new List<String>();
            String query = "SELECT * FROM ad ";

            MySqlDataReader reader = null;
            reader = sqlQuery(query);

            if (reader.HasRows)
            {
               while (reader.Read())
               {
                   String title = reader["title"].ToString();
                   titlesList.Add(title);
                }

            }

            conn.Close();     
            return titlesList;
        }

        public List<String> getUserTitles(String username)
        {
            List<String> titlesList = new List<String>();
            String query = "SELECT * FROM ad ";

            MySqlDataReader reader = null;
            reader = sqlQuery(query);

            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    String thisUsername = reader["username"].ToString();
                    if (thisUsername.Equals(username))
                    {
                        String title = reader["title"].ToString();
                        titlesList.Add(title);
                    }
                }

            }

            conn.Close();
            return titlesList;
        }

        private MySqlDataReader sqlQuery(String query)
        {
            MySqlDataReader reader = null;
            conn.Open();
            try
            {
                
                MySqlCommand cmd = new MySqlCommand(query, conn);
                reader = cmd.ExecuteReader();
            }
            catch (MySqlException e)
            {
                Console.WriteLine(e.Message);
            }
            return reader;
        }
    }
}
