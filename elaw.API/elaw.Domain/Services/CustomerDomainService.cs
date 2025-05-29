using elaw.Domain.Notifications;
using elaw.Domain.Entities;
using elaw.Domain.Interfaces.Infra;
using elaw.Domain.Interfaces.Services;
using FluentValidation;

namespace elaw.Domain.Services
{
    public class CustomerDomainService : BaseDomainService<Customer>, ICustomerDomainService
    {
        private readonly ICustomerRepository _customerRepository;
        public CustomerDomainService(
            IBaseRepository<Customer> baseRepository,
            NotificationContext notificationContext,
            IValidator<Customer> customerValidator, 
            ICustomerRepository customerRepository)
            : base(baseRepository, notificationContext, customerValidator)
        {
            _customerRepository = customerRepository;
        }

        public override Task<Customer?> GetByIdAsync(Guid id)
        {
            return _customerRepository.GetByIdAsync(id);
        }

        public override Task<IEnumerable<Customer>> GetAllAsync()
        {
            return _customerRepository.GetAllAsync();
        }
    }
}
