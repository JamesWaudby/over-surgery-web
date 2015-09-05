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
    public class AppointmentServiceTests
    {
        [TestMethod()]
        public void GetAppointmentTest()
        {
            // Arrange
            IList<Appointment> appointments = new List<Appointment>
            {
                new Appointment() { ID = 1 }
            };

            // Arrange
            IAppointmentRepository repository = new AppointmentRepository(appointments);
            IAppointmentService service = new AppointmentService(repository);

            // Arrange
            AppointmentRequest request = new AppointmentRequest() { AppointmentID = 1 };

            // Act
            AppointmentResponse result = service.GetAppointment(request);

            // Assert
            Assert.AreEqual(appointments[0], result.Appointment);
            Assert.IsTrue(result.Success);
        }

        [TestMethod()]
        public void GetAppointmentTestFail()
        {
            // Arrange
            IList<Appointment> appointments = new List<Appointment>
            {
                new Appointment() { ID = 1 }
            };

            // Arrange
            IAppointmentRepository repository = new AppointmentRepository(appointments);
            IAppointmentService service = new AppointmentService(repository);

            // Arrange
            AppointmentRequest request = new AppointmentRequest() { AppointmentID = 2 };

            // Act
            AppointmentResponse result = service.GetAppointment(request);

            // Assert
            Assert.IsFalse(result.Success);
        }

        [TestMethod()]
        public void CreateAppointmentTest()
        {
            // Arrange
            IAppointmentRepository repository = new AppointmentRepository();
            IAppointmentService service = new AppointmentService(repository);
            
            // Arrange
            Appointment appointment = new Appointment()
            {
                Patient = new Patient { FirstName = "Test", LastName = "Test" }
            };

            // Arrange
            CreateAppointmentRequest request = new CreateAppointmentRequest() { Appointment = appointment };

            // Act
            AppointmentResponse result = service.CreateAppointment(request);

            // Assert
            Assert.AreEqual(appointment.ID, result.Appointment.ID);
            Assert.AreEqual(appointment.Patient, result.Appointment.Patient);
            Assert.IsTrue(result.Success);
        }

        [TestMethod()]
        public void CreateAppointmentWithInvalidRequestTest()
        {
            // Arrange
            IAppointmentRepository repository = new AppointmentRepository();
            IAppointmentService service = new AppointmentService(repository);

            // Arrange
            CreateAppointmentRequest request = new CreateAppointmentRequest();

            // Act
            AppointmentResponse result = service.CreateAppointment(request);

            // Assert
            Assert.IsNull(result.Appointment);
            Assert.IsFalse(result.Success);
        }
    }
}