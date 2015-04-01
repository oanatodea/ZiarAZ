using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Security.Cryptography;
using Entities;
using DAL;

namespace BL
{
    public class UserService
    {
        public string login(string username, string password)
        {
            UsersDAL usersDAL = new UsersDAL();
            User user;
            user =  usersDAL.getUser(username, getMd5Hash(password));
            if (user == null)
                return null;
            if (user.isAdmin())
                return "admin";
            return "user";
        }

        private string getMd5Hash(string input)
        {
            // Create a new instance of the MD5CryptoServiceProvider object.
            MD5 md5Hasher = MD5.Create();

            // Convert the input string to a byte array and compute the hash.
            byte[] data = md5Hasher.ComputeHash(Encoding.Default.GetBytes(input));

            // Create a new Stringbuilder to collect the bytes
            // and create a string.
            StringBuilder sBuilder = new StringBuilder();

            // Loop through each byte of the hashed data 
            // and format each one as a hexadecimal string.
            for (int i = 0; i < data.Length; i++)
            {
                sBuilder.Append(data[i].ToString("x2"));
            }

            // Return the hexadecimal string.
            return sBuilder.ToString();
        }

        public String resetPassword(String username)
        {
            string password;
            password = getRandomPassword();
            string encryptedPassword = getMd5Hash(password);
            UsersDAL usersDal = new UsersDAL();
            if (usersDal.changePassword(username, encryptedPassword))
                return "fail";
            return password;
        }

        private string getRandomPassword()
        {
            Random random = new Random();
            StringBuilder sBuilder = new StringBuilder();

            char newChar;

            for (int i = 0; i < 5; i++)
            {
                newChar = (char)random.Next(97, 122);
                sBuilder.Append(newChar);
            }

            return sBuilder.ToString();
        }

        public List<String> getAllUsers()
        {
            UsersDAL usersDAL = new UsersDAL();
            return usersDAL.getAllUsers();
        }

        public String getUserReports(String username)
        {
            UsersDAL usersDAL = new UsersDAL();
            return usersDAL.getUserReport(username);
        }

        public void deleteUser(String username)
        {
            UsersDAL usersDAL = new UsersDAL();
            usersDAL.deleteUser(username);
        }

        public void addUser(String username)
        {
            UsersDAL usersDAL = new UsersDAL();
            String password = getMd5Hash(passwordForNewUser());
            usersDAL.addUser(username, password, "user");
        }

        private String passwordForNewUser()
        {
            return "0000";
        }
    }
}
