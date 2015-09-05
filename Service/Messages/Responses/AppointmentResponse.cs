using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Messages.Responses
{
    public class AppointmentResponse : ResponseBase
    {
        public Appointment Appointment { get; set; }
    }
}
