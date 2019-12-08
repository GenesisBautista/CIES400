using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Models
{
    public class Supervisor : IUserType
    {
        public string id { get; set; }
        public string type
        {
            get { return "Supervisor"; }
            set { }
        }

        public Supervisor(string id)
        {
            this.id = id;
        }

        public void terminateEmployee(string username)
        {
            //todo: mark employee account as terminated
        }
    }
}
