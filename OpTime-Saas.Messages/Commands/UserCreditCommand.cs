using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace OpTime_Saas.Messages.Commands
{
    public class UserCreditCommand
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Password { get; set; }
        public string? PhoneNumber { get; set; }
        public string Email { get; set; }
        public string UserName { get; set; }

        public int Credit { get; set; }
        public DateTime ExpirationDate{ get; set; }




    }
}
