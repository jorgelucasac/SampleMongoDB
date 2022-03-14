using Estudos.MongoDb.Application.UseCases.Shared;
using MediatR;

namespace Estudos.MongoDb.Application.UseCases.PostReviewRestaurant;

public interface IPostReviewRestaurantUseCase : IRequestHandler<PostReviewRestaurantInput, Output>
{
}
