using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Krungsri.API.Models
{
    public class AdminExpireModel
    {        
        public int AdminId { get; set; }
        public string ExpiryDate { get; set; }
        public string MoneyAmount { get; set; }
        public string Ref { get; set; }
    }
}
