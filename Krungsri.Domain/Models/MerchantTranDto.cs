using System;
using System.Collections.Generic;
using System.Text;

namespace Krungsri.Domain.Models
{
    public class MerchantTranDto
    {
        public int Id { get; set; }
        public int MerchantId { get; set; }
        public int UserId { get; set; }
        public decimal MoneyAmount { get; set; }
        public string Ref { get; set; }
    }
}
