﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class MedicalStaff : Employee
    {
        public IList<Appointment> Appointments { get; set; }
    }
}
