using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Models
{
    public class Equipment
    {
        string name { get; set; }
        int Id { get; set; }
        string requiredSKill { get; set; }

        public void checkIn()
        {
            //todo: check this tool in
            throw new NotImplementedException();
        }

        public void checkOut()
        {
            //todo: check this tool out
            throw new NotImplementedException();
        }
    }
}
