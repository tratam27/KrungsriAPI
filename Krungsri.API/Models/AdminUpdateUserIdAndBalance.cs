using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Krungsri.API.Models
{
    public class AdminUpdateUserIdAndBalance
    {
        public int UserId { get; set; }
        public decimal TopUpMoney { get; set; }
        public string Ref { get; set; }
    }
}
