using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Models;

namespace API
{
    public class MockData
    {
        public List<Users> mockedUsers = new List<Users>()
        {
            new Users("123456", "Mickey.Mouse", "disney420", "My daddy and my b-day", "Mickey", "Mouse", new DateTime(2000, 4, 20)),
            new Users("123457", "Donald.Duck", "$scrooge$", "My uncle surrounded by his passion", "Donald", "Duck", new DateTime(1980, 1, 1)),
            new Users("123458", "Steve.Rogers", "cptAmerica", "My real job", "Steve", "Rogers", new DateTime(1920, 8, 5))
        };
    }
}
