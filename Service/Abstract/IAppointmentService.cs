using Service.Messages;
using Service.Messages.Requests;
using Service.Messages.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Abstract
{
    public interface IAppointmentService
    {
        AppointmentResponse GetAppointment(AppointmentRequest appointmentRequest);

        AppointmentResponse CreateAppointment(CreateAppointmentRequest appointmentRequest);
    }
}
