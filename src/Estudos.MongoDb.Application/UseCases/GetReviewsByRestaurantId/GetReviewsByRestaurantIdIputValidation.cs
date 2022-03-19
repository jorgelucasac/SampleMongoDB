using FluentValidation;

namespace Estudos.MongoDb.Application.UseCases.GetReviewsByRestaurantId;

public class GetReviewsByRestaurantIdIputValidation : AbstractValidator<GetReviewsByRestaurantIdInput>
{
    public const int IdLength = 24;

    public GetReviewsByRestaurantIdIputValidation()
    {
        ValidateId();
    }

    private void ValidateId()
    {
        RuleFor(a => a.Id)
            .NotEmpty()
            .Length(IdLength)
            .WithMessage("'{PropertyName}' deve ter {MaxLength} caracteres. Você digitou {TotalLength} caracteres.");
    }
}