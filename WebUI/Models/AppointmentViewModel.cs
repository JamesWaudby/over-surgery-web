using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebUI.Models
{
    public class AppointmentViewModel
    {
        public Appointment Appointment { get; set; }
        public string Message { get; set; }
    }
}