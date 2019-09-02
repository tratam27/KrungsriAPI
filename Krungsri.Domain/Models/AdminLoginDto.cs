using System;
using System.Collections.Generic;
using System.Text;

namespace Krungsri.Domain.Models
{
    public class AdminLoginDto
    {
        public string UserName { get; set; }
        public string Password { get; set; }
        public int AdminId { get; set; }
    }
}
