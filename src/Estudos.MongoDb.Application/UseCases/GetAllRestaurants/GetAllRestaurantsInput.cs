using Estudos.MongoDb.Application.UseCases.Shared;
using Estudos.MongoDb.Domain.Data.Interfaces;
using Estudos.MongoDb.Domain.Enums;
using MediatR;

namespace Estudos.MongoDb.Application.UseCases.GetAllRestaurants;

public class GetAllRestaurantsInput : IRequest<Output>, IPagedQuery
{
    public GetAllRestaurantsInput(int page, int results, string orderBy, string filter, string sortOrder)
    {
        Page = page;
        Results = results;
        OrderBy = orderBy;
        Filter = filter;
        if (!string.IsNullOrEmpty(sortOrder))
            SortOrder = Enum.Parse<SortOrder>(sortOrder);
    }

    public int Page { get; }
    public int Results { get; }
    public string OrderBy { get; }
    public string Filter { get; }
    public SortOrder SortOrder { get; }
}