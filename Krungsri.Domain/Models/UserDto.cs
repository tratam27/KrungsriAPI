using System;
using System.Collections.Generic;
using System.Text;

namespace Krungsri.Domain.Models
{
    public class UserDto
    {
        public int UserId { get; set; }
        public string FirstName { get; set; }
        public string Email { get; set; }
        public string LastName { get; set; }
        public string Gender { get; set; }
        public string Birthdate { get; set; }
        public decimal Balance { get; set; }
        public string BookBank { get; set; }
        public string Password { get; set; }
        public string Pin { get; set; }
        public string Salt { get; set; }
        public string PhoneNumber { get; set; }
    }
}
