using Domain.Entities;
using Repository.Abstract;
using Repository.Concrete;
using Service.Abstract;
using Service.Messages.Requests;
using Service.Messages.Responses;
using Service.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebUI.Models;

namespace WebUI.Controllers
{
    public class LogonController : Controller
    {
        ILogonService logonService;

        public LogonController()
        {
            IList<LogonCredentials> credentials = new List<LogonCredentials>()
            {
                new LogonCredentials { EmployeeID = 1, Username = "Test", Password = "Test" }
            };

            IList<Employee> employees = new List<Employee>()
            {
                new Employee { ID = 1, FirstName = "Employee", LastName = "Test" }
            };

            ILogonRepository logonRepository = new LogonRepository(credentials);
            IEmployeeRepository employeeRepository = new EmployeeRepository(employees);

            logonService = new LogonService(logonRepository, employeeRepository);
        }

        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(LogonViewModel logonViewModel)
        {
            LogonRequest request = new LogonRequest()
            {
                Username = logonViewModel.Username,
                Password = logonViewModel.Password
            };

            LogonResponse response = logonService.Logon(request);
            return View();
        }
    }
}