using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpTime_Saas.Domain.Entities
{
    public class User : IdentityUser
    {
        public UserCredit UserCredit { get; set; }
        public string FirstName{ get; set; }
        public string LastName { get; set; }
        public bool IsBanned { get; set; }
        public User(string userName , string firstName , string lastName , string email , string phoneNumber   )
        {
            UserName = userName;
            FirstName = firstName;
            LastName = lastName;
            Email = email;
            PhoneNumber = phoneNumber;
            Id = Guid.NewGuid().ToString();
            
            
        }
    }
}
