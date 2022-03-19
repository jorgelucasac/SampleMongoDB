using AutoMapper;
using Estudos.MongoDb.Api.Filters;
using Estudos.MongoDb.Application.UseCases.PostReviewRestaurant;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Estudos.MongoDb.Api.Controllers.V1
{
    public class ReviewsController : MainController
    {
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;

        public ReviewsController(IMediator mediator, IMapper mapper)
        {
            _mediator = mediator;
            _mapper = mapper;
        }

        [HttpGet]
        [ProducesResponseType(typeof(PostReviewRestaurantOutput), StatusCodes.Status201Created)]
        [ProducesResponseNotFound]
        [ProducesResponseBadRequest]
        [ProducesResponseInternalServerError]
        public async Task<IActionResult> GetReviewAsync(CancellationToken cancellationToken)
        {
            return Ok();
        }
    }
}