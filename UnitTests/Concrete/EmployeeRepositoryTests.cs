using Domain.Entities;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Repository.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Concrete.Tests
{
    [TestClass()]
    public class EmployeeRepositoryTests
    {
        [TestMethod()]
        public void GetEmployeeByIDTest()
        {
            // Arrange
            int employeeID = 1;
            List<Employee> employees = new List<Employee>()
            {
                new Employee { ID = employeeID, FirstName = "Test", LastName = "Test" }
            };

            EmployeeRepository repository = new EmployeeRepository(employees);

            // Act
            Employee result = repository.GetEmployeeByID(employeeID);

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(employees[0], result);
        }

        [TestMethod()]
        public void GetEmployeeByIDInvalidIDTest()
        {
            // Arrange
            int employeeID = 2;
            List<Employee> employees = new List<Employee>()
            {
                new Employee { ID = 1, FirstName = "Test", LastName = "Test" }
            };

            EmployeeRepository repository = new EmployeeRepository(employees);

            // Act
            Employee result = repository.GetEmployeeByID(employeeID);

            // Assert
            Assert.IsNull(result);
        }
    }
}