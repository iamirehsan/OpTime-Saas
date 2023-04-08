using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using OpTime_Saas.Domain.Entities;
using OpTime_Saas.Repository;
using OpTime_Saas.Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpTime_Saas.Service.Implimentation.Implementation
{
    public class ServiceHolder : IServiceHolder
    {
        private UserFunctionsService _userFunctionsService;
        private readonly IConfiguration _configuration;
        private UserCreditService _userCreditService;
        private UserManager<User> _userManager;
        private IUnitOfWOrk _unitOfWok;

        public ServiceHolder(IUnitOfWOrk unitOfWok,  UserManager<User> userManager , IConfiguration configuration)
        {
            _unitOfWok = unitOfWok;
            _userManager = userManager;
            _configuration = configuration;
        }

        public IUserFunctionsService UserFunctionsService => _userFunctionsService = _userFunctionsService ?? new UserFunctionsService(_userManager , _unitOfWok ,_configuration);

        public IUserCreditService UserCreditService => _userCreditService = _userCreditService ?? new UserCreditService(_unitOfWok);
    }
}
