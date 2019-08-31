using System;
using System.Collections.Generic;
using System.Text;

namespace Krungsri.DataAccess.Models
{
    public class MerchantAccess : BaseModel
    {
        public int MerchantId { get; set; }
        public string Name { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string BookBank { get; set; }
        public string Salt { get; set; }
        public MerchantTokenAccess MerchantToken { get; set; }
        public ICollection<MerchantTransactionAccess> MerchantTransactions { get; set; }
    }
}
