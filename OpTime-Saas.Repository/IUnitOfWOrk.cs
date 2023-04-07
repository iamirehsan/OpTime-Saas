using OpTime_Saas.Repository.interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpTime_Saas.Repository
{
    public interface IUnitOfWOrk : IDisposable
    {
        Task CommitAsync();
        void Commit();
        public IUserCreditRepository UserCreditRepository { get; }
    }
}
