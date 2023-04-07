using OpTime_Saas.Domain.Entities;
using OpTime_Saas.Repository.interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpTime_Saas.Repository.Implimentation.Implementations
{
    public class UserCreditRepository : Repository<UserCredit>, IUserCreditRepository
    {
        public UserCreditRepository(ApplicationDbContext context) : base(context)
        {
        }
    }
}
