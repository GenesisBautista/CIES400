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
        public IUserType userType { get; set; }
        private Data data;

        public Users()
        {
            data = new Data();
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
            string sql = @"SELECT * FROM ceis400.vwuserinfo WHERE id = " + id;
            List<Dictionary<string, string>> result = data.runSql(sql); ;
            
            if(result.Count == 1)
            {
                this.id = id;
                username = result[0]["username"];
                password = "";
                hint = result[0]["hint"];
                firstName = result[0]["firstName"];
                lastName = result[0]["lastName"];
                switch (result[0]["type"].ToLower())
                {
                    case "staff":
                        userType = new Staff();
                        break;
                    case "employee":
                        userType = new Employee();
                        break;
                    case "supervisor":
                        userType = new Supervisor();
                        break;
                }
            }

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
