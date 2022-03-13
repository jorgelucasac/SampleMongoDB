using Estudos.MongoDb.Domain.ValueObjects;
using FluentValidation;

namespace Estudos.MongoDb.Domain.Validations;

internal class AddressValidation : AbstractValidator<Address>
{
    public AddressValidation()
    {
        ValidarLogradouro();
        ValidarCidade();
        ValidarUf();
        ValidarCep();
    }

    private void ValidarLogradouro()
    {
        RuleFor(c => c.PublicPlace)
            .NotEmpty().WithMessage("PublicPlace não pode ser vazio.")
            .MaximumLength(50).WithMessage("PublicPlace pode ter no maximo 50 caracteres.");
    }

    private void ValidarCidade()
    {
        RuleFor(c => c.City)
            .NotEmpty().WithMessage("City não pode ser vazio.")
            .MaximumLength(100).WithMessage("City pode ter no maximo 100 caracteres.");
    }

    private void ValidarUf()
    {
        RuleFor(c => c.State)
            .NotEmpty().WithMessage("State não pode ser vazio.")
            .Length(2).WithMessage("State deve ter 2 caracteres.");
    }

    private void ValidarCep()
    {
        RuleFor(c => c.ZipCode)
            .NotEmpty().WithMessage("ZipCode não pode ser vazio.")
            .Length(8).WithMessage("ZipCode deve ter 8 caracteres.");
    }
}