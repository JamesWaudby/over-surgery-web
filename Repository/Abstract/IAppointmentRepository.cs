using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Abstract
{
    public interface IAppointmentRepository
    {
        Appointment GetByID(int id);
        IEnumerable<Appointment> GetAll();

        Appointment Create(Appointment appointment);
    }
}
