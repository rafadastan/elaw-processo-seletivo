using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace elaw.Application.Dto
{
    public class AddressDto
    {
        public Guid Id { get; set; }
        public string Street { get; set; } = null!;
        public string Number { get; set; } = null!;
        public string City { get; set; } = null!;
        public string State { get; set; } = null!;
        public string PostalCode { get; set; } = null!;
    }
}
