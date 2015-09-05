using Domain.Entities;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Repository.Abstract;
using Repository.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Concrete.Tests
{
    [TestClass()]
    public class AppointmentRepositoryTests
    {
        [TestMethod()]
        public void GetByIDTest()
        {
            // Arrange
            IList<Appointment> appointments = new List<Appointment>
            {
                new Appointment() { ID = 1 }
            };

            IAppointmentRepository repository = new AppointmentRepository(appointments);

            // Act
            Appointment result = repository.GetByID(1);

            // Assert
            Assert.AreEqual(1, result.ID);
        }

        [TestMethod()]
        [ExpectedException(typeof(ApplicationException), "No Appointment with that ID exists.")]
        public void GetByIDExceptionTest()
        {
            // Arrange
            IList<Appointment> appointments = new List<Appointment>
            {
                new Appointment() { ID = 1 }
            };

            IAppointmentRepository repository = new AppointmentRepository(appointments);

            // Act
            Appointment result = repository.GetByID(2);
        }

        [TestMethod()]
        public void GetAllTest()
        {
            // Arrange
            IList<Appointment> appointments = new List<Appointment>
            {
                new Appointment { ID = 1 },
                new Appointment { ID = 2 }
            };

            IAppointmentRepository repository = new AppointmentRepository(appointments);

            // Act
            IList<Appointment> result = repository.GetAll().ToList();

            // Assert
            Assert.AreEqual(1, result[0].ID);
            Assert.AreEqual(2, result[1].ID);
        }

        [TestMethod()]
        public void CreateTest()
        {
            // Arrange
            IAppointmentRepository repository = new AppointmentRepository();

            // Arrange
            Appointment appointment = new Appointment()
            {
                Patient = new Patient { FirstName = "Test", LastName = "Test" }
            };

            // Act
            Appointment result = repository.Create(appointment);

            // Assert
            Assert.AreEqual(appointment, result);
            Assert.AreEqual(1, appointment.ID);
        }

        [TestMethod()]
        [ExpectedException(typeof(ApplicationException))]
        public void CreateFailTest()
        {
            // Arrange
            IAppointmentRepository repository = new AppointmentRepository();

            // Act
            Appointment result = repository.Create(null);
        }
    }
}