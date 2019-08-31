using System;
using System.Collections.Generic;
using System.Text;

namespace Krungsri.DataAccess.Models
{
    public class AdminTokenAccess : BaseModel
    {
        public int Id { get; set; }
        public string RefreshToken { get; set; }
        public int AdminId { get; set; }
        public AdminAccess Admin { get; set; }
    }
}
