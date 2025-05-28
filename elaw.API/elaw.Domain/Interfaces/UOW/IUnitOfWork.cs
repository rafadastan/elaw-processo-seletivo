using System;
using System.Threading.Tasks;

namespace elaw.Domain.Interfaces.Infra
{
    public interface IUnitOfWork : IDisposable
    {
        ICustomerRepository Customers { get; }
        IAddressRepository Addresses { get; }

        Task BeginTransactionAsync();
        Task CommitTransactionAsync();
        Task RollbackTransactionAsync();

        Task<int> CommitAsync();
    }
}
