using OpTime_Saas.Domain.Entities;
using OpTime_Saas.Infrastructure.Base;
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

        public UserCreditService(IUnitOfWOrk unitOfWOrk)
        {
            _unitOfWOrk = unitOfWOrk;
        }

        public async Task<string> GetRoute(string userId)
        {
            var userCredit = await _unitOfWOrk.UserCreditRepository.FirstOrDefaultAsync(x => x.User.Id == userId && !x.IsExpired);
            if (userCredit.Credit < 100)
                throw new ManagedException("برای درخواست انتخابی باید اعتبار بیشتر از 100 ریال باشد.");
            userCredit.Credit -= 100;
            await _unitOfWOrk.CommitAsync();
            return "Route is 100";

        }

        public async Task<string> GetDistance(string userId)
        {
            var userCredit = await _unitOfWOrk.UserCreditRepository.FirstOrDefaultAsync(x => x.User.Id == userId && !x.IsExpired);
            if (userCredit.Credit < 10)
                throw new ManagedException("برای درخواست انتخابی باید اعتبار بیشتر از 10 ریال باشد.");
            userCredit.Credit -= 10;
            await _unitOfWOrk.CommitAsync();
            return "Distance is 10";
        }

        public async Task<string> GetDuration(string userId)
        {
            var userCredit = await _unitOfWOrk.UserCreditRepository.FirstOrDefaultAsync(x => x.User.Id == userId && !x.IsExpired);
            if (userCredit.Credit < 15)
                throw new ManagedException("برای درخواست انتخابی باید اعتبار بیشتر از 15 ریال باشد.");
            userCredit.Credit -= 15;
            await _unitOfWOrk.CommitAsync();
            return "Distance is 15";
        }
    }
}
