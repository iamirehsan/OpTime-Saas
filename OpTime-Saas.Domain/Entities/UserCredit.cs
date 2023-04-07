using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpTime_Saas.Domain.Entities
{
    public class UserCredit : BaseEntity
    {
        public int Credit { get; set; }
        public DateTime ExpirationDate { get; set; }
        public bool IsExpired { get; set; }
        public User User { get; set; }

        public UserCredit(int credit, DateTime expirationDate , User user ):base()
        {
            Credit = credit;
            ExpirationDate = expirationDate;
            IsExpired = false;
            User = user;
        }
    }
}
