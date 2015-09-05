using Domain.Entities;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Repository.Abstract;
using Repository.Concrete;
using Service.Abstract;
using Service.Messages.Requests;
using Service.Messages.Responses;
using Service.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Services.Tests
{
    [TestClass()]
    public class LogonServiceTests
    {
        [TestMethod()]
        public void LogonTest()
        {
            // Arrange
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

            ILogonService logonService = new LogonService(logonRepository, employeeRepository);

            LogonRequest request = new LogonRequest { Username = "Test", Password = "Test" };

            // Act
            LogonResponse response = logonService.Logon(request);

            // Assert
            Assert.IsNotNull(response.Employee);
            Assert.IsTrue(response.Success);
            Assert.AreEqual(1, response.Employee.ID);
        }
    }
}