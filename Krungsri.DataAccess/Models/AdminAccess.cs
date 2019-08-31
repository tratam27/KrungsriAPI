using System;
using System.Collections.Generic;
using System.Text;

namespace Krungsri.DataAccess.Models
{
    public class AdminAccess : BaseModel
    {
        public int AdminId { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string Name { get; set; }
        public string BookBank { get; set; }
        public string Salt { get; set; }
        public AdminTokenAccess AdminToken { get; set; }
        public ICollection<AdminTransactionAccess> AdminTransactions { get; set; }
    }
}
