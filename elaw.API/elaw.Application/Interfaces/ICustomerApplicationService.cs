using elaw.Application.DTOs;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace elaw.Application.Interfaces
{
    public interface ICustomerApplicationService
    {
        Task<CustomerDto?> GetByIdAsync(Guid id);
        Task<IEnumerable<CustomerDto>> GetAllAsync();
        Task<CustomerDto> AddAsync(CustomerDto customerDto);
        Task<CustomerDto> UpdateAsync(Guid Id, CustomerDto customerDto);
        Task DeleteAsync(Guid id);
    }
}