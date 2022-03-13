using Estudos.MongoDb.Application.UseCases.CreateRestaurant;
using FluentValidation;

namespace Estudos.MongoDb.Application.UseCases.GetAllRestaurants;

public class GetAllRestaurantsInputValidation : AbstractValidator<GetAllRestaurantsInput>
{
    public GetAllRestaurantsInputValidation()
    {
        ValidatePage();
        ValidateResults();
        ValidateOrderBy();
        ValidateSortOrder();
    }

    private void ValidatePage()
    {
        RuleFor(p => p.Page)
            .GreaterThanOrEqualTo(0);
    }

    private void ValidateResults()
    {
        RuleFor(p => p.Results)
            .GreaterThanOrEqualTo(0);
    }

    private void ValidateOrderBy()
    {
        RuleFor(p => p.OrderBy)
            .Must(IsValidOrderByAndFilter)
            .WithMessage("campo de ordenação inválido");
    }

    private void ValidateSortOrder()
    {
        RuleFor(p => p.SortOrder)
            .IsInEnum();
    }

    private bool IsValidOrderByAndFilter(string property)
    {
        if (string.IsNullOrEmpty(property))
            return true;

        var properties = typeof(CreateRestaurantOutput).GetProperties();
        return properties.Select(a => a.Name.ToLower())
            .Contains(property.ToLower());
    }
}