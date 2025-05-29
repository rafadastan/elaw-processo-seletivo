using elaw.Application.Dto;
using System;

namespace elaw.Application.DTOs
{
    public class CustomerDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = null!;
        public string Email { get; set; } = null!;
        public string? Phone { get; set; }
        public AddressDto Address { get; set; } = null!;
    }
}