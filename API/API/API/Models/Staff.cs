using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Models
{
    public class Staff : IUserType
    {
        public string Id { get; set; }
        public string type = "Staff";

        public void checkHistory()
        {
            //todo grab logs
        }

        public void accessRecords()
        {
            //todo access records
        }
    }
}
