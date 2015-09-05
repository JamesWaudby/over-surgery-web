using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Messages.Requests
{
    public class AppointmentRequest : RequestBase
    {
        public int AppointmentID { get; set; }
    }
}
