using System;
using System.Collections.Generic;
using System.Text;

namespace Krungsri.DataAccess.Models
{
    public class AdminTransactionAccess : BaseModel
    {
        public int Id { get; set; }
        public int AdminId { get; set; }
        public int UserId { get; set; }
        public decimal MoneyAmount { get; set; }
        public string Ref { get; set; }
        public UserAccess User { get; set; }
        public AdminAccess Admin { get; set; }
    }
}
