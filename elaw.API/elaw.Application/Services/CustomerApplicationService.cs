using AutoMapper;
using elaw.Domain.Notifications;
using elaw.Application.DTOs;
using elaw.Application.Interfaces;
using elaw.Domain.Entities;
using elaw.Domain.Interfaces.Services;

namespace elaw.Application.Services
{
    public class CustomerApplicationService : ICustomerApplicationService
    {
        private readonly ICustomerDomainService _customerDomainService;
        private readonly IMapper _mapper;
        private readonly NotificationContext _notificationContext;

        public CustomerApplicationService(
            ICustomerDomainService customerDomainService,
            IMapper mapper,
            NotificationContext notificationContext)
        {
            _customerDomainService = customerDomainService;
            _mapper = mapper;
            _notificationContext = notificationContext;
        }

        public async Task<IEnumerable<CustomerDto>> GetAllAsync()
        {
            var customers = await _customerDomainService.GetAllAsync();

            if (_notificationContext.HasNotifications) return null;

            return _mapper.Map<IEnumerable<CustomerDto>>(customers);
        }

        public async Task<CustomerDto?> GetByIdAsync(Guid id)
        {
            var customer = await _customerDomainService.GetByIdAsync(id);

            if (_notificationContext.HasNotifications) return null;

            return _mapper.Map<CustomerDto>(customer);
        }

        public async Task<CustomerDto> AddAsync(CustomerDto customerDto)
        {
            var customer = _mapper.Map<Customer>(customerDto);

            await _customerDomainService.AddAsync(customer);

            if (_notificationContext.HasNotifications) return null;

            return _mapper.Map<CustomerDto>(customer);
        }

        public async Task<CustomerDto> UpdateAsync(Guid id, CustomerDto dto)
        {
            var customer = await _customerDomainService.GetByIdAsync(id);
            
            if (customer == null)
            {
                _notificationContext.AddNotification("NotFound", $"Cliente '{id}' não encontrado.");
                return null;
            }

            _mapper.Map(dto, customer);

            await _customerDomainService.UpdateAsync(customer);

            if (_notificationContext.HasNotifications) return null;

            return _mapper.Map<CustomerDto>(customer);
        }


        public async Task DeleteAsync(Guid id)
        {
            await _customerDomainService.DeleteAsync(id);

            if (_notificationContext.HasNotifications) return;
        }
    }
}