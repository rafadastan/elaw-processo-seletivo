using elaw.Domain.Entities;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace elaw.Domain.Validators
{
    public class AddressValidator : AbstractValidator<Address>
    {
        public AddressValidator()
        {
            RuleFor(address => address.Street)
            .NotEmpty().WithMessage("Rua é obrigatória.")
            .Length(3, 100).WithMessage("Rua deve ter entre 3 e 100 caracteres.");

            RuleFor(address => address.City)
                .NotEmpty().WithMessage("Cidade é obrigatória.")
                .Length(2, 50).WithMessage("Cidade deve ter entre 2 e 50 caracteres.");

            RuleFor(address => address.State)
                .NotEmpty().WithMessage("Estado é obrigatório.")
                .Length(2).WithMessage("Estado deve ter 2 caracteres (ex: SP).")
                .Must(BeValidState).WithMessage("Estado inválido.");

            RuleFor(address => address.PostalCode)
                .NotEmpty().WithMessage("CEP é obrigatório.")
                .Matches(@"^\d{5}-?\d{3}$")
                .WithMessage("CEP inválido (formato: 12345-678 ou 1234567");
        }

        private bool BeValidState(string state)
        {
            var validStates = new[]
            {
                "AC", "AL", "AP", "AM", "BA",
                "CE", "DF", "ES", "GO", "MA",
                "MT", "MS", "MG", "PA", "PB",
                "PR", "PE", "PI", "RJ", "RN",
                "RS", "RO", "RR", "SC", "SP",
                "SE", "TO"
            };

            return validStates.Contains(state?.ToUpper());
        }
    }
}
