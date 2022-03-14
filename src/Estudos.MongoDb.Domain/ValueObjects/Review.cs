using Estudos.MongoDb.Domain.Validations;
using FluentValidation.Results;

namespace Estudos.MongoDb.Domain.ValueObjects;

public class Review
{
    public Review(string restaurantId, int stars, string comment)
    {
        RestaurantId=restaurantId;
        Stars=stars;
        Comment=comment;
    }

    public string RestaurantId { get; private set; }
    public int Stars { get; private set; }
    public string Comment { get; private set; }

    public ValidationResult ValidationResult { get; set; }

    public virtual bool Validar()
    {
        ValidationResult = new ReviewValidation().Validate(this);

        return ValidationResult.IsValid;
    }
}