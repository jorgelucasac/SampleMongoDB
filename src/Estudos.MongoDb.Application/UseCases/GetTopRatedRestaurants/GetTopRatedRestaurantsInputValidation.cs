using FluentValidation;

namespace Estudos.MongoDb.Application.UseCases.GetTopRatedRestaurants;

public class GetTopRatedRestaurantsInputValidation : AbstractValidator<GetTopRatedRestaurantsInput>
{
    public GetTopRatedRestaurantsInputValidation()
    {
        ValidateLimit();
    }

    private void ValidateLimit()
    {
        RuleFor(a => a.Limit)
            .GreaterThan(0);
    }
}