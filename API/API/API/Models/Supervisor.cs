using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Models
{
    public class Supervisor : IUserType
    {
        public string Id { get; set; }
        public string type = "Supervisor";

        public void terminateEmployee(string username)
        {
            //todo: mark employee account as terminated
        }
    }
}
