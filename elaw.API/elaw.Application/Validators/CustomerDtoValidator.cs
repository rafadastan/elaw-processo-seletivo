using elaw.Application.Dto;
using elaw.Application.DTOs;
using elaw.Domain.Interfaces.Infra;
using FluentValidation;

public class CustomerDtoValidator : AbstractValidator<CustomerDto>
{
    public CustomerDtoValidator(ICustomerRepository repo)
    {
        RuleFor(x => x.Name)
            .NotEmpty().WithMessage("Nome é obrigatório.");

        RuleFor(x => x.Email)
            .NotEmpty().WithMessage("Email é obrigatório.")
            .EmailAddress().WithMessage("Formato de email inválido.")
            .MustAsync(async (dto, email, ct) =>
            {
                var exists = await repo.ExistsByEmailAsync(email);
                return !exists || (dto.Id != Guid.Empty &&
                    (await repo.GetByIdAsync(dto.Id))?.Email == email);
            })
            .WithMessage("Já existe um cliente com esse email.");

        RuleFor(x => x.Address).SetValidator(new AddressDtoValidator());
    }
}

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
