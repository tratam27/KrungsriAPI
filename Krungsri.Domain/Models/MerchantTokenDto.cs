using System;
using System.Collections.Generic;
using System.Text;

namespace Krungsri.Domain.Models
{
    public class MerchantTokenDto
    {
        public string RefreshToken { get; set; }
        public int MerchantId { get; set; }
    }
}
