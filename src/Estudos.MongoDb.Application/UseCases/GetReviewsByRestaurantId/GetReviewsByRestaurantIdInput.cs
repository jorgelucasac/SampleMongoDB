using Estudos.MongoDb.Application.UseCases.Shared;
using Estudos.MongoDb.Domain.Data.Interfaces;
using Estudos.MongoDb.Domain.Enums;

namespace Estudos.MongoDb.Application.UseCases.GetReviewsByRestaurantId;

public class GetReviewsByRestaurantIdInput : BaseInput, IPagedQuery
{
    public string Id { get; }
    public int Page { get; }
    public int Results { get; }
    public string OrderBy { get; } = nameof(GetReviewsByRestaurantIdOutput.Stars);
    public string Filter { get; } = string.Empty;
    public SortOrder SortOrder => SortOrder.Desc;

    public GetReviewsByRestaurantIdInput(string id, int page, int results)
    {
        Id = id;
        Page = page;
        Results = results;
    }
}