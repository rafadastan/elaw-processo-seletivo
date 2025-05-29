using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace elaw.Domain.Entities
{
    public class Address
    {
        public Guid Id { get; private set; }
        public string? Number { get; private set; }
        public string? Street { get; private set; }
        public string? City { get; private set; }
        public string? State { get; private set; }
        public string? PostalCode { get; private set; }

        public Customer? Customer { get; set; }
    }
}
