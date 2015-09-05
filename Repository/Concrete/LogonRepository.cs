using Domain.Entities;
using Repository.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Concrete
{
    public class LogonRepository : ILogonRepository
    {
        private IList<LogonCredentials> logonCredentials;

        public LogonRepository()
        {
            logonCredentials = new List<LogonCredentials>();
        }

        public LogonRepository(IList<LogonCredentials> credentials)
        {
            logonCredentials = credentials;
        }

        public LogonCredentials GetLogonCredentials(string username, string password)
        {
            return logonCredentials.FirstOrDefault(l => l.Username == username && l.Password == password);
        }
    }
}
