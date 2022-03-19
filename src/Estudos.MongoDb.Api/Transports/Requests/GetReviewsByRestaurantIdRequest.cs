using Microsoft.AspNetCore.Mvc;

namespace Estudos.MongoDb.Api.Transports.Requests;

public class GetReviewsByRestaurantIdRequest
{
    [BindProperty(Name = "page")]
    public int Page { get; set; }

    [BindProperty(Name = "page-size")]
    public int PageSize { get; set; }
}