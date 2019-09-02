using System;
using System.Collections.Generic;
using System.Text;

namespace Krungsri.Domain.Models
{
    public class AdminTranDto
    {
        public int Id { get; set; }
        public int AdminId { get; set; }
        public int UserId { get; set; }
        public string MoneyAmount { get; set; }
        public string Ref { get; set; }
    }
}
