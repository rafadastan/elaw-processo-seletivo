using elaw.Domain.Entities;
using elaw.Domain.Interfaces.Infra;

public interface ICustomerRepository : IBaseRepository<Customer>
{
    Task<bool> ExistsByEmailAsync(string email);
}
