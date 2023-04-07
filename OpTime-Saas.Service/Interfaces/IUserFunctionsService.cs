using OpTime_Saas.Messages.Commands;

namespace OpTime_Saas.Service.Interfaces
{
    public interface IUserFunctionsService
    {
        public Task CreateUser(UserCreditCommand cmd);
        public Task<string> Login(LoginCommand cmd);
    }
}
