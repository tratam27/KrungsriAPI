using System;
using System.Collections.Generic;
using System.Text;

namespace Krungsri.DataAccess.Models
{
    public class UserAccess : BaseModel
    {
        public int UserId { get; set; }
        public string FirstName { get; set; }
        public string Email { get; set; }
        public string LastName { get; set; }
        public string Gender { get; set; }
        public DateTime Birthdate { get; set; }
        public decimal Balance { get; set; }
        public string BookBank { get; set; }        
        public string Password { get; set; }
        public string Salt { get; set; }
        public string PhoneNumber { get; set; }
        public TokenAccess Token { get; set; }
        public ICollection<AdminTransactionAccess> AdminTransactions { get; set; }
        public ICollection<MerchantTransactionAccess> MerchantTransactions { get; set; }
        public ICollection<OtpAccess> Otps { get; set; }
    }
}
