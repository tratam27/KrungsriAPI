using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Krungsri.API.Models
{
    public class ConfirmOtpModel
    {
        public string Email { get; set; }
        public string Otp { get; set; }
    }
}
