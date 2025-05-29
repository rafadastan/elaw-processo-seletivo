using elaw.Domain.Entities;
using elaw.Domain.Interfaces.Infra;
using elaw.Infra.Data.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace elaw.Infra.Repositories
{
    public class AddressRepository : BaseRepository<Address>, IAddressRepository
    {
        public AddressRepository(AppDbContext context) : base(context)
        {
            
        }
    }
}
