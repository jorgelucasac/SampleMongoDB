using Estudos.MongoDb.Domain.ValueObjects;
using FluentValidation;

namespace Estudos.MongoDb.Domain.Validations;

internal class AddressValidation : AbstractValidator<Address>
{
    public AddressValidation()
    {
        ValidatePublicPlace();
        ValidateCity();
        ValidateState();
        ValidateZipCode();
    }

    private void ValidatePublicPlace()
    {
        RuleFor(c => c.PublicPlace)
            .NotEmpty()
            .MaximumLength(50);
    }

    private void ValidateCity()
    {
        RuleFor(c => c.City)
            .NotEmpty()
            .MaximumLength(100);
    }

    private void ValidateState()
    {
        RuleFor(c => c.State)
            .NotEmpty()
            .Length(2);
    }

    private void ValidateZipCode()
    {
        RuleFor(c => c.ZipCode)
            .NotEmpty()
            .Length(8);
    }
}