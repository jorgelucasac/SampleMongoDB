using Estudos.MongoDb.Application.Helper;
using FluentValidation;

namespace Estudos.MongoDb.Application.UseCases.UpdateRestaurant;

public class UpdateRestaurantInputValidation : AbstractValidator<UpdateRestaurantInput>
{
    public const int IdLength = 24;

    public UpdateRestaurantInputValidation()
    {
        ValidatePublicPlace();
        ValidateId();
        ValidateCity();
        ValidateState();
        ValidateZipCode();
        ValidateName();
        ValidateCountry();
    }

    private void ValidateId()
    {
        RuleFor(a => a.Id)
            .NotEmpty()
            .Length(IdLength)
            .WithMessage("'{PropertyName}' deve ter {MaxLength} caracteres. Você digitou {TotalLength} caracteres.");
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
            .Must(EnumHelper.IsInCountryEnum).WithMessage("{PropertyValue} não é um valor válido para '{PropertyName}'")
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
}