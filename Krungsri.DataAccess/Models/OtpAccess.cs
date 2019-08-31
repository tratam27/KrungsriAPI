using System;
using System.Collections.Generic;
using System.Text;

namespace Krungsri.DataAccess.Models
{
    public class OtpAccess : BaseModel
    {
        public int Id { get; set; }
        public string Otp { get; set; }
        public string Ref { get; set; }
        public string Email { get; set; }
        public UserAccess User { get; set; }
    }
}
