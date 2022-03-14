using Estudos.MongoDb.Application.Helper;
using FluentValidation;

namespace Estudos.MongoDb.Application.UseCases.PatchRestaurant;

public class PatchRestaurantInputValidation : AbstractValidator<PatchRestaurantInput>
{
    public const int IdLength = 24;

    public PatchRestaurantInputValidation()
    {
        ValidateId();
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
            .MaximumLength(30);
    }

    private void ValidateCountry()
    {
        When(a => a.Country.HasValue, () =>
        {
            RuleFor(c => c.Country.Value)
                .Must(EnumHelper.IsInCountryEnum)
                .WithMessage("{PropertyValue} não é um valor válido para '{PropertyName}'");
        });
    }
}