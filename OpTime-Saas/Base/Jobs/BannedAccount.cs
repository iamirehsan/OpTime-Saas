using OpTime_Saas.Repository;

namespace OpTime_Saas.Base.Jobs
{
    public class BannedAccount : IBannedAccount
    {
        private readonly IUnitOfWOrk _unitOfWOrk;

        public BannedAccount(IUnitOfWOrk unitOfWOrk)
        {
            _unitOfWOrk = unitOfWOrk;
        }

        public async Task BannedAccounts()
        {
            var mustBeBannedUsers = await _unitOfWOrk.UserRepository.FindAsync(x => x.UserCredit.Credit < 10 && x.IsBanned == false);
            foreach (var item in mustBeBannedUsers)
            {
                item.IsBanned = true;
            }
            await _unitOfWOrk.CommitAsync();


        }
    }
}
