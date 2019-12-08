using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Models
{
    public interface IUserType
    {
        string Id { get; set; }
        string type { get; set; }
    }
}
