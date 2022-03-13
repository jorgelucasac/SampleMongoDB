using FluentValidation;

namespace Estudos.MongoDb.Application.UseCases.GetRestaurantById;

public class GetRestaurantByIdInputValidation : AbstractValidator<GetRestaurantByIdInput>
{
    public const int IdLength = 24;

    public GetRestaurantByIdInputValidation()
    {
        ValidateId();
    }

    private void ValidateId()
    {
        RuleFor(a => a.Id)
            .NotEmpty()
            .Length(IdLength).WithMessage("'{PropertyName}' deve ter {MaxLength} caracteres. Você digitou {TotalLength} caracteres.");
    }
}