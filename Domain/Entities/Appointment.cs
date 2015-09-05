using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Appointment
    {
        public int  ID { get; set; }
        public DateTime Time { get; set; }
        public Patient Patient { get; set; }
        public MedicalStaff Staff { get; set; }
    }
}
