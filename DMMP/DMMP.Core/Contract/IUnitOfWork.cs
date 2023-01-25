using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DMMP.Core.Contract
{
    public interface IUnitOfWork : IDisposable
    {
        IJobRepository JobRepository { get; }
        IJobTypeRepository JobTypeRepository { get; }
        IPropertyRepository PropertyRepository { get; }
        IUserRepository UserRepository { get; }

        Task<int> SaveChangesAsync();
        Task DeleteDatabaseAsync();
        Task MigrateDatabaseAsync();
        Task CreateDatabaseAsync();
    }
}
