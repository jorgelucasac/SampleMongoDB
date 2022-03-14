using Estudos.MongoDb.Domain.ValueObjects;
using FluentValidation;

namespace Estudos.MongoDb.Domain.Validations;

internal class ReviewValidation : AbstractValidator<Review>
{
    public ReviewValidation()
    {
        ValidateStar();
        ValidateComment();
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