using OpTime_Saas.Repository;
using OpTime_Saas.Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpTime_Saas.Service.Implimentation.Implementation
{
    public class UserCreditService : IUserCreditService
    {
        public readonly IUnitOfWOrk _unitOfWOrk;

        public Task<string> GetRoute()
        {
            throw new NotImplementedException();
        }

        public Task<string> GetDistance()
        {
            throw new NotImplementedException();
        }

        public Task<string> GetDuration()
        {
            throw new NotImplementedException();
        }
    }
}
