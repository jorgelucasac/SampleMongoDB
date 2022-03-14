using Microsoft.AspNetCore.Mvc;

namespace Estudos.MongoDb.Api.Transports.Requests;

public class GetAllRestaurantsRequest
{
    [BindProperty(Name = "page")] public int Page { get; set; }

    [BindProperty(Name = "page-size")] public int PageSize { get; set; }

    [BindProperty(Name = "name")] public string Name { get; set; } = string.Empty;

    [BindProperty(Name = "order-by")] public string OrderBy { get; set; } = string.Empty;

    [BindProperty(Name = "sort-order")] public string SortOrder { get; set; } = string.Empty;
}