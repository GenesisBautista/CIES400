using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Models
{
    public class Employee : IUserType
    {
        public string id { get; set; }
        public string type
        {
            get { return "Employee"; }
            set { }
        }

        public Employee(string id)
        {
            this.id = id;
        }

        public string skillType { get; set; }
        List<Equipment> toolbox { get; set; }
    }
}
