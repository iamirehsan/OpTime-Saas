

using OpTime_Saas.Repository.Implimentation.Implementations;
using OpTime_Saas.Repository.interfaces;

namespace OpTime_Saas.Repository.Implimentation
{
    public class UnitOfWork : IUnitOfWOrk
    {
        private  UserCreditRepository _userCreditRepository;
        private UserRepository _userRepository;
        private ApplicationDbContext _context;

        public UnitOfWork(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task CommitAsync()
        {
             await _context.SaveChangesAsync();
        }

        public void Commit()
        {
            _context.SaveChanges();
        }

        public IUserCreditRepository UserCreditRepository => _userCreditRepository = _userCreditRepository ?? new UserCreditRepository(_context) ;

        public IUserRepository UserRepository => _userRepository = _userRepository ?? new UserRepository(_context);

        public void Dispose()
        {
            _context.Dispose(); 
        }

    }
}
