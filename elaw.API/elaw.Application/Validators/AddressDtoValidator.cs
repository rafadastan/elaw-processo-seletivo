using elaw.Application.Dto;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace elaw.Application.Validators
{
    public class AddressDtoValidator : AbstractValidator<AddressDto>
    {
        public AddressDtoValidator()
        {
            RuleFor(a => a.Street).NotEmpty().WithMessage("Rua é obrigatória.");
            RuleFor(a => a.Number).NotEmpty().WithMessage("Número é obrigatório.");
            RuleFor(a => a.City).NotEmpty().WithMessage("Cidade é obrigatória.");
            RuleFor(a => a.State).NotEmpty().WithMessage("Estado é obrigatório.");
            RuleFor(a => a.PostalCode)
                .NotEmpty().WithMessage("CEP é obrigatório.")
                .Length(8).WithMessage("CEP deve ter 8 dígitos.");
        }
    }
}
