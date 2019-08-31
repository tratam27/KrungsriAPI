using System;
using System.Collections.Generic;
using System.Text;

namespace Krungsri.DataAccess.Models
{
    public class TokenAccess : BaseModel
    {
        public int Id { get; set; }
        public string RefreshToken { get; set; }
        public int UserId { get; set; }
        public UserAccess User { get; set; }
    }
}
