using Service.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Service.Messages.Requests;
using Service.Messages.Responses;
using Repository.Concrete;
using Repository.Abstract;
using Domain.Entities;

namespace Service.Services
{
    public class LogonService : ILogonService
    {
        private ILogonRepository logonRepository;
        private IEmployeeRepository employeeRepository;

        public LogonService(ILogonRepository logon, IEmployeeRepository employee)
        {
            logonRepository = logon;
            employeeRepository = employee;
        }

        public LogonResponse Logon(LogonRequest request)
        {
            LogonCredentials credentials = logonRepository.GetLogonCredentials(request.Username, request.Password);

            LogonResponse response = new LogonResponse();
            response.Employee = employeeRepository.GetEmployeeByID(credentials.EmployeeID);

            if (response.Employee != null)
            {
                response.Success = true;
            }
            else
            {
                response.Success = false;
                response.Message = "Cannot find that employee";
            }

            return response;
        }
    }
}
