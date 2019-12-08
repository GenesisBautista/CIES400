using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Models
{
    public class Employee : IUserType
    {
        public string Id { get; set; }
        public string type = "Employee";
        public string skillType { get; set; }
        List<Equipment> toolbox { get; set; }
    }
}
