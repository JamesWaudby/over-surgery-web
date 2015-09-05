using Repository.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Entities;

namespace Repository.Concrete
{
    public class AppointmentRepository : IAppointmentRepository
    {
        private IList<Appointment> appointments { get; set; }

        public AppointmentRepository()
        {
            appointments = new List<Appointment>();
        }

        public AppointmentRepository(IList<Appointment> appointmentsList)
        {
            appointments = appointmentsList;
        }

        public Appointment GetByID(int id)
        {
            if (!appointments.Any(a => a.ID == id))
                throw new ApplicationException("No Appointment with that ID exists.");

            return appointments.FirstOrDefault(a => a.ID == id);
        }

        public IEnumerable<Appointment> GetAll()
        {
            return appointments;
        }

        public Appointment Create(Appointment appointment)
        {
            if (appointment == null)
                throw new ApplicationException();

            appointment.ID = appointments.Count() + 1;

            appointments.Add(appointment);

            return appointments.Last();
        }
    }
}
