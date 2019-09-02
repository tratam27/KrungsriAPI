using System;
using System.Collections.Generic;
using System.Text;

namespace Krungsri.Domain.Models
{
    public class AdminTokenDto
    {
        public string RefreshToken { get; set; }
        public int AdminId { get; set; }
    }
}
