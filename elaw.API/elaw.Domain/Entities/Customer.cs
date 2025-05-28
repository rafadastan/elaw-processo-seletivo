﻿namespace elaw.Domain.Entities
{
    public class Customer
    {
        public Guid Id { get; private set; }
        public string? Name { get; private set; }
        public string? Email { get; private set; }
        public string? Phone { get; private set; }
    }
}
