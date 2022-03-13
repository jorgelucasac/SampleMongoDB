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
        ValidateFilter();
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
            .Must(IsValidOrderByAndFilter);
    }

    private void ValidateFilter()
    {
        RuleFor(p => p.Filter)
            .Must(IsValidOrderByAndFilter);
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

        var properties = typeof(CreateRestauranteOutput).GetProperties();
        return properties.Select(a => a.Name)
            .Contains(property);
    }
}