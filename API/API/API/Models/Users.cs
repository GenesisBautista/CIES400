using MySql.Data.MySqlClient;
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
        public string sessionId { get; set; }

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
        
        public bool login(string username, string password)
        {
            string procedureName = "procUserLogin";
            Dictionary<string, string> inputs = new Dictionary<string, string>()
            {
                { "@givenUsername", username },
                { "@givenPassword", password }
            };
            Dictionary<string, MySqlDbType> outputs = new Dictionary<string, MySqlDbType>()
            {
                { "@result", MySqlDbType.VarChar },
                { "@sessionId", MySqlDbType.VarChar }
            };
            Dictionary<string, string> result = data.runStoredProcedure(procedureName, inputs, outputs);

            if (result["@result"].Contains("Error"))
            {
                return false;
            }
            else
            {
                findByUsername(username);
                sessionId = result["@sessionId"];
                return true;
            }
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
                        userType = new Staff(id);
                        break;
                    case "employee":
                        userType = new Employee(id);
                        break;
                    case "supervisor":
                        userType = new Supervisor(id);
                        break;
                }
            }
        }

        public void findByUsername(string username)
        {
            string sql = @"SELECT * FROM ceis400.vwuserinfo WHERE username = " + username;
            List<Dictionary<string, string>> result = data.runSql(sql); ;

            if (result.Count == 1)
            {
                id = result[0]["id"];
                this.username = result[0]["username"];
                password = "";
                hint = result[0]["hint"];
                firstName = result[0]["firstName"];
                lastName = result[0]["lastName"];
                switch (result[0]["type"].ToLower())
                {
                    case "staff":
                        userType = new Staff(id);
                        break;
                    case "employee":
                        userType = new Employee(id);
                        break;
                    case "supervisor":
                        userType = new Supervisor(id);
                        break;
                }
            }
        }
    }
}
