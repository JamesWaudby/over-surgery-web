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
    public class LogonRepositoryTests
    {
        [TestMethod()]
        public void GetLogonCredentialsTest()
        {
            // Arrange
            List<LogonCredentials> credentials = new List<LogonCredentials>()
            {
                new LogonCredentials { Username = "Test", Password = "Test", EmployeeID = 1 }
            };

            LogonRepository repository = new LogonRepository(credentials);

            // Act
            LogonCredentials result = repository.GetLogonCredentials("Test", "Test");

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual("Test", result.Username);
            Assert.AreEqual("Test", result.Password);
            Assert.AreEqual(1, result.EmployeeID);
        }

        [TestMethod()]
        public void GetLogonCredentialsFailTest()
        {
            // Arrange
            List<LogonCredentials> credentials = new List<LogonCredentials>()
            {
                new LogonCredentials { Username = "Test", Password = "Test" }
            };

            LogonRepository repository = new LogonRepository(credentials);

            // Act
            LogonCredentials result = repository.GetLogonCredentials("Bad", "Bad");

            // Assert
            Assert.IsNull(result);
        }
    }
}