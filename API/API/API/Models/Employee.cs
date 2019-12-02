using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Models
{
    public class Employee
    {
        string Id { get; set; }
        string skillType { get; set; }
        List<Equipment> toolbox { get; set; }
    }
}
