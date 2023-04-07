using Microsoft.AspNetCore.Identity;
using OpTime_Saas.Domain.Entities;
using OpTime_Saas.Infrastructure.Base;
using OpTime_Saas.Messages.Commands;
using OpTime_Saas.Repository;
using OpTime_Saas.Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpTime_Saas.Service.Implimentation.Implementation
{
    public class UserFunctionsService : IUserFunctionsService
    {
        private readonly UserManager<User> _userManager;
        private readonly IUnitOfWOrk _unitOfWOrk;

        public UserFunctionsService(UserManager<User> userManager, IUnitOfWOrk unitOfWOrk)
        {
            _userManager = userManager;
            _unitOfWOrk = unitOfWOrk;
        }

        public async Task CreateUser(UserCreditCommand cmd)
        {
            var user = new User(cmd.UserName , cmd.FirstName , cmd.LastName , cmd.Email , cmd.PhoneNumber);

            var result = await _userManager.CreateAsync(user, cmd.Password);
            
            if (!result.Succeeded)
            {
                throw new ManagedException("متاسفانه مشکلی در ساخت کاربر وجود دارد. ");
            }
            var userCredit = new UserCredit(cmd.Credit, cmd.ExpirationDate,user);
           


        }
    }
}
