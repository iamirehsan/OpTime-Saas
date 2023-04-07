using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using OpTime_Saas.Domain.Entities;
using OpTime_Saas.Infrastructure.Base;
using OpTime_Saas.Messages.Commands;
using OpTime_Saas.Repository;
using OpTime_Saas.Service.Interfaces;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
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
            if (cmd.Credit == 0)
                cmd.Credit = 1000000;
            var user = new User(cmd.UserName, cmd.FirstName, cmd.LastName, cmd.Email, cmd.PhoneNumber);

            var result = await _userManager.CreateAsync(user, cmd.Password);

            if (!result.Succeeded)
            {
                throw new ManagedException("متاسفانه مشکلی در ساخت کاربر وجود دارد. ");
            }
            var userCredit = new UserCredit(cmd.Credit, cmd.ExpirationDate);
            userCredit.User = user;
            await _unitOfWOrk.UserCreditRepository.AddAsync(userCredit);
            _unitOfWOrk.CommitAsync();




        }

        public async Task<string> Login(LoginCommand cmd)
        {
            var user = await _userManager.FindByNameAsync(cmd.UserName);
            if(user.IsBanned)
                throw new ManagedException("کاربر مسدود شده است. ");

            if (user is null)
                throw new ManagedException("نام کاربری یا رمز عبور اشتباه است");
            if (await _userManager.CheckPasswordAsync(user, cmd.Password) == false)
                throw new ManagedException("نام کاربری یا رمز عبور اشتباه است");
            return (CreateToken(user));
 


        }

        private string CreateToken(User user)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes("key");
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
            new Claim(user.UserName, "username"),
            new Claim(user.Id, "userid"),
                    // Add additional claims as desired
                }),
                Expires = DateTime.UtcNow.AddDays(7),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor).ToString();
            return token ;
        }
    }
}
