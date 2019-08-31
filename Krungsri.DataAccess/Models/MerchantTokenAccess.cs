using System;
using System.Collections.Generic;
using System.Text;

namespace Krungsri.DataAccess.Models
{
    public class MerchantTokenAccess : BaseModel
    {
        public int Id { get; set; }
        public string RefreshToken { get; set; }
        public int MerchantId { get; set; }
        public MerchantAccess Merchant { get; set; }
    }
}
