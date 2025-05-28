using elaw.Domain.Interfaces.Infra;
using elaw.Infra.Data;
using Microsoft.EntityFrameworkCore.Storage;
using System;
using System.Threading.Tasks;

namespace elaw.Infra.UOW
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly AppDbContext _context;
        private readonly ICustomerRepository _customerRepository;
        private readonly IAddressRepository _addressRepository;

        private IDbContextTransaction? _transaction;

        public UnitOfWork(AppDbContext context,
                          ICustomerRepository customerRepository,
                          IAddressRepository addressRepository)
        {
            _context = context;
            _customerRepository = customerRepository;
            _addressRepository = addressRepository;
        }

        public ICustomerRepository Customers => _customerRepository;
        public IAddressRepository Addresses => _addressRepository;

        public async Task BeginTransactionAsync()
        {
            if (_transaction == null)
            {
                _transaction = await _context.Database.BeginTransactionAsync();
            }
        }

        public async Task CommitTransactionAsync()
        {
            if (_transaction != null)
            {
                await _transaction.CommitAsync();
                await _transaction.DisposeAsync();
                _transaction = null;
            }
        }

        public async Task RollbackTransactionAsync()
        {
            if (_transaction != null)
            {
                await _transaction.RollbackAsync();
                await _transaction.DisposeAsync();
                _transaction = null;
            }
        }

        public async Task<int> CommitAsync()
        {
            return await _context.SaveChangesAsync();
        }

        public void Dispose()
        {
            _context.Dispose();
            _transaction?.Dispose();
        }
    }
}
