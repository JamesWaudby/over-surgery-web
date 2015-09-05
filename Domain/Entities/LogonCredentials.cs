using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class LogonCredentials
    {
        public string Username { get; set; }
        public string Password { get; set; }
        public int EmployeeID { get; set; }
    }
}
