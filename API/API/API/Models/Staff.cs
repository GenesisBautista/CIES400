using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Models
{
    public class Staff : IUserType
    {
        public string id { get; set; }
        public string type
        {
            get { return "Staff"; }
            set { }
        }

        public Staff(string id)
        {
            this.id = id;
        }

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
