using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PostgresLibsTesting.Models
{
    public class User
    {
        public int id { get; set; }
        public string first_name { get; set; }
        public string last_name { get; set; }
        public string user_name { get; set; }
        public string created_at { get; set; }
        public string created_by { get; set; }
        public string updated_at { get; set; }
        public string updated_by { get; set; }
    }
}
