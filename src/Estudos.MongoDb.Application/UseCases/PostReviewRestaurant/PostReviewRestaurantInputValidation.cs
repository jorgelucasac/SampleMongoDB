using FluentValidation;

namespace Estudos.MongoDb.Application.UseCases.PostReviewRestaurant;

public class PostReviewRestaurantInputValidation : AbstractValidator<PostReviewRestaurantInput>
{
    public const int IdLength = 24;

    public PostReviewRestaurantInputValidation()
    {
        ValidateStar();
        ValidateComment();
        ValidateRestaurantId();
    }

    private void ValidateRestaurantId()
    {
        RuleFor(a => a.RestaurantId)
            .NotEmpty()
            .Length(IdLength)
            .WithMessage("'{PropertyName}' deve ter {MaxLength} caracteres. Você digitou {TotalLength} caracteres.");
    }

    private void ValidateStar()
    {
        RuleFor(c => c.Stars)
            .GreaterThan(0)
            .LessThanOrEqualTo(5);
    }

    private void ValidateComment()
    {
        RuleFor(c => c.Comment)
            .NotEmpty()
            .MaximumLength(100);
    }
}