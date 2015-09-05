using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Messages.Requests
{
    public class CreateAppointmentRequest : RequestBase
    {
        public Appointment Appointment { get; set; }

    }
}
