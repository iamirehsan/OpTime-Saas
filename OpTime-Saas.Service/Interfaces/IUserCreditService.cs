using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpTime_Saas.Service.Interfaces
{
    public interface IUserCreditService
    {
        public Task<string> GetRoute();
        public Task<string> GetDistance();
        public Task<string> GetDuration();

    }
}
