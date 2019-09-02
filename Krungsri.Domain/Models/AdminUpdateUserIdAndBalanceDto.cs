using System;
using System.Collections.Generic;
using System.Text;

namespace Krungsri.Domain.Models
{
    public class AdminUpdateUserIdAndBalanceDto
    {
        public int UserId { get; set; }
        public decimal TopUpMoney { get; set; }
        public string Ref { get; set; }
    }
}
