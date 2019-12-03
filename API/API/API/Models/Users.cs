using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Models
{
    public class Users
    {
        string username { get; set; }
        string password { get; set; }
        string hint { get; set; }
        string firstName { get; set; }
        string lastName { get; set; }
        DateTime birthdate { get; set; }

        public Users(string username)
        {
            //constructor
            //todo: call out to db to grab user info
        }
        
        public bool login(string password)
        {
            //todo: returns true if login credentials are good
            if (this.password == password)
                return true;
            else
                return false;
        }

        public void logout()
        {
            //todo: destroys current session of given user
            throw new NotImplementedException();
        }

        public bool changePassword()
        {
            //todo: call out to stored proc to change password
            throw new NotImplementedException();
        }

        public string forgotPassword()
        {
            return this.hint;
        }
    }
}
