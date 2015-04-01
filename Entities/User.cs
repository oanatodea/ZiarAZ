using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Entities
{
    public class User
    {
        private string username;
        private string password;
        private string role;

        public User(string username, string password, string role)
        {
            this.username = username;
            this.password = password;
            this.role = role;
        }

        public Boolean isAdmin()
        {
            if (role.Equals("admin"))
                return true;
            return false;
        }
    }
}
