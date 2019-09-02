using System;
using System.Collections.Generic;
using System.Text;

namespace Krungsri.Domain.Models
{
    public class MerchantLoginDto
    {
        public string UserName { get; set; }
        public string Password { get; set; }
        public int MerchantId { get; set; }
    }
}
