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

        public int getUserTypeId()
        {
            string sql = "SELECT * FROM tbkusertype WHERE type = " + type;
            List<Dictionary<string, string>> results = new List<Dictionary<string, string>>();
            Data data = new Data();
            
            results = data.runSql(sql);

            return int.Parse(results[0]["userTypeId"]);
        }
        List<Equipment> toolbox { get; set; }
    }
}
