using System;
using System.Collections.Generic;
using System.Text;

namespace Krungsri.DataAccess.Models
{
    public class MerchantTransactionAccess : BaseModel
    {
        public int Id { get; set; }
        public int MerchantId { get; set; }
        public int UserId { get; set; }
        public decimal MoneyAmount { get; set; }
        public string Ref { get; set; }
        public UserAccess User { get; set; }
        public MerchantAccess Merchant { get; set; }
    }
}
