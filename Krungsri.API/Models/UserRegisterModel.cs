using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Krungsri.API.Models
{
    public class UserRegisterModel
    {        
        public string FirstName { get; set; }
        public string Email { get; set; }
        public string LastName { get; set; }
        public string Gender { get; set; }
        public string Birthdate { get; set; }        
        public string BookBank { get; set; }
        public string Pin { get; set; }        
        public string PhoneNumber { get; set; }
    }
}
