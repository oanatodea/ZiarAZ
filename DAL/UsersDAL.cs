using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

using MySql.Data;
using MySql.Data.MySqlClient;
using Entities;

namespace DAL
{
    public class UsersDAL
    {
        private static UsersDAL usersDAL = null;  
        private String connectionString = @"Data Source=MASTER-PC\SQLEXPRESS;Initial Catalog=ps;User ID=sa;Password=cevaparola";    
        MySqlConnection conn = null;

        public UsersDAL()    
        {       
            connectionString = String.Format("server={0};user id={1}; password={2}; database={3}; pooling=false", "localhost", "root", "", "ziaraz");     
            conn = new MySqlConnection(connectionString);  
        } 
        public User getUser(String username, String password)  
            {   
                User u = null;     
                String query = "SELECT * FROM user WHERE username= '" + username + "' AND password= '" + password + "'";

                MySqlDataReader reader = sqlQuery(query);
            reader.Read();
                    if (reader.HasRows) 
                    {             
                        u = new User(reader["username"].ToString(), reader["password"].ToString(), reader["role"].ToString());    
                    }        
                    else      
                    {    
                        u = null;      
                    }           
                    conn.Close();    
                return u;    
            }

        public bool changePassword(string username,string newPassword){
            string query = "UPDATE user set password = '" + newPassword+ "' where username = '" + username + "'";

                MySqlDataReader reader = sqlQuery(query);
                if (reader.HasRows)
                {
                    conn.Close();
                    return true;
                }
                conn.Close();
            return false; 
            }


        public List<String> getAllUsers()
        {
            List<String> users = new List<String>();
            String query = "SELECT * FROM user where role = 'user'";

            MySqlDataReader reader = null;
            reader = sqlQuery(query);

            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    String username = reader["username"].ToString();
                    users.Add(username);
                }

            }

            conn.Close();
            return users;
        }

        public String getUserReport(String username)
        {
            String query = "SELECT COUNT(*) FROM ad WHERE username = '" + username + "'";

            MySqlDataReader reader = null;
            reader = sqlQuery(query);
            reader.Read();
            String n = reader[0].ToString();
            conn.Close();
            return n;
        }

        public bool addUser(String username, String password, String role)
        {
            String query = "INSERT INTO `user`(`username`, `password`,`role`) VALUES ('" + username + "','" + password + "','" + role + "')";

            MySqlDataReader reader = sqlQuery(query);
            reader.Read();
            if (reader.HasRows)
            {
                conn.Close();
                return true;
            }
            conn.Close();
            return false;
        }

        public void deleteUser(String username)
        {
            String query = "DELETE FROM `user` WHERE username = '" + username + "'";
            MySqlDataReader reader = sqlQuery(query);
            conn.Close();
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
