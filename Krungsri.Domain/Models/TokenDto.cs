using System;
using System.Collections.Generic;
using System.Text;

namespace Krungsri.Domain.Models
{
    public class TokenDto
    {
        public string RefreshToken { get; set; }
        public int UserId { get; set; }
    }
}
