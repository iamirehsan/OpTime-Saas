using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpTime_Saas.Service.Interfaces
{
    public interface IUserCreditService
    {
        public   Task<string> GetRoute(string userId);
        public   Task<string> GetDistance(string userId);
        public   Task<string> GetDuration(string userId);

    }
}
