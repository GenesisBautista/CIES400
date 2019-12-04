using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Models
{
    public class Users
    {
        public string id { get; set; }
        public string username { get; set; }
        public string password { get; set; }
        public string hint { get; set; }
        public string firstName { get; set; }
        public string lastName { get; set; }
        public DateTime birthDate { get; set; }

        public Users()
        {
        }

        public Users(string id, string username, string password, string hint, string firstName, string lastName, DateTime birthDate)
        {
            //constructor
            this.id = id;
            this.username = username;
            this.password = password;
            this.hint = hint;
            this.firstName = firstName;
            this.lastName = lastName;
            this.birthDate = birthDate;
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

        public void findById(string id)
        {
            MockData data = new MockData();
            Users foundUser = data.mockedUsers.FirstOrDefault(users => users.id == id);
            this.id = id;
            username = foundUser.username;
            password = foundUser.password;
            hint = foundUser.hint;
            firstName = foundUser.firstName;
            lastName = foundUser.lastName;
            birthDate = foundUser.birthDate;
        }

        public void findByUsername(string username)
        {
            MockData data = new MockData();
            Users foundUser = data.mockedUsers.FirstOrDefault(users => users.username == username);
            this.username = username;
            id = foundUser.id;
            password = foundUser.password;
            hint = foundUser.hint;
            firstName = foundUser.firstName;
            lastName = foundUser.lastName;
            birthDate = foundUser.birthDate;
        }
    }
}
