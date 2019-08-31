using System;
using System.Collections.Generic;
using System.Text;

namespace Krungsri.Domain.Models
{
    public class UserLoginDto
    {
        public string Email { get; set; }
        public string Password { get; set; }
        public int UserId { get; set; }
    }
}
