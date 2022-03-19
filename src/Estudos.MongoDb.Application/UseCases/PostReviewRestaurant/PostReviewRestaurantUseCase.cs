using AutoMapper;
using Estudos.MongoDb.Application.UseCases.Shared;
using Estudos.MongoDb.Domain.Data.Interfaces;
using Estudos.MongoDb.Domain.ValueObjects;

namespace Estudos.MongoDb.Application.UseCases.PostReviewRestaurant;

public class PostReviewRestaurantUseCase : BaseUseCase<PostReviewRestaurantInput>
{
    private readonly IRestaurantRepository _restaurantRepository;
    private readonly IMapper _mapper;

    public PostReviewRestaurantUseCase(IRestaurantRepository restaurantRepository, IMapper mapper)
    {
        _restaurantRepository = restaurantRepository;
        _mapper = mapper;
    }

    public override async Task<Output> Handle(PostReviewRestaurantInput request, CancellationToken cancellationToken)
    {
        var review = _mapper.Map<Review>(request);
        await _restaurantRepository.AddReviewAsync(review, cancellationToken);

        var output = _mapper.Map<PostReviewRestaurantOutput>(review);
        return Success(output);
    }
}