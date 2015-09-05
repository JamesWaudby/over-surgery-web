using Domain.Entities;
using Repository.Abstract;
using Repository.Concrete;
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
    public class HomeController : Controller
    {
        AppointmentService appointmentService;

        public HomeController()
        {
            IList<Appointment> appointment = new List<Appointment>
            {
                new Appointment { ID = 1, Patient = new Patient { FirstName = "James", LastName = "Waudby" } }
            };

            IAppointmentRepository repository = new AppointmentRepository(appointment);

            appointmentService = new AppointmentService(repository);
        }

        // GET: Home
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(AppointmentViewModel model)
        {
            AppointmentRequest request = new AppointmentRequest { AppointmentID = model.Appointment.ID };
            AppointmentResponse response = appointmentService.GetAppointment(request);

            model = new AppointmentViewModel
            {
                Appointment = response.Appointment,
                Message = response.Message
            };

            return View(model);
        }
    }
}