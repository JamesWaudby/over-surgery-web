using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebUI.Models
{
    public class LogonViewModel
    {
        public string Message { get; }
        public string Username { get; set; }
        public string Password { get; set; }
    }
}