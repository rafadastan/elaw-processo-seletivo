using elaw.Domain.Entities;
using elaw.Infra.Data.Repositories;
using Microsoft.EntityFrameworkCore;

public class CustomerRepository : BaseRepository<Customer>, ICustomerRepository
{
    public CustomerRepository(AppDbContext context) : base(context)
    {
    }

    public Task<bool> ExistsByEmailAsync(string email) =>
        _dbSet.AnyAsync(c => c.Email == email);

    public override async Task<Customer?> GetByIdAsync(Guid id)
    {
        return await _dbSet
            .Include(c => c.Address)
            .FirstOrDefaultAsync(c => c.Id == id);
    }

    public override async Task<IEnumerable<Customer>> GetAllAsync()
    {
        return await _dbSet
            .Include(c => c.Address)
            .ToListAsync();
    }
}
