using Estudos.MongoDb.Domain.Enums;
using FluentValidation;

namespace Estudos.MongoDb.Application.UseCases.CreateRestaurant;

public class CreateRestaurantInputValidation : AbstractValidator<CreateRestaurantInput>
{
    public CreateRestaurantInputValidation()
    {
        ValidatePublicPlace();
        ValidateCity();
        ValidateState();
        ValidateZipCode();
        ValidateName();
        ValidateCountry();
    }

    private void ValidateName()
    {
        RuleFor(c => c.Name)
            .NotEmpty()
            .MaximumLength(30);
    }

    private void ValidateCountry()
    {
        RuleFor(c => c.Country)
            .Must(CountryIsInEnum).WithMessage("{PropertyValue} nãe é um valor válido para '{PropertyName}'")
            .NotEmpty();
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

    private bool CountryIsInEnum(int country)
    {
        return Enum.IsDefined(typeof(Country), country);
    }
}