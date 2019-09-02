using System;
using System.Collections.Generic;
using System.Text;

namespace Krungsri.Domain.Models
{
    public class AdminTranExpireDate
    {
        public int Id { get; set; }
        public int AdminId { get; set; }
        public string ExpiryDate { get; set; }
        public string MoneyAmount { get; set; }
        public string Ref { get; set; }
    }
}
