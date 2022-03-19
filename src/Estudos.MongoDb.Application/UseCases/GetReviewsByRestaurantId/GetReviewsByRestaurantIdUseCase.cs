using AutoMapper;
using Estudos.MongoDb.Application.UseCases.Shared;
using Estudos.MongoDb.Domain.Data;
using Estudos.MongoDb.Domain.Data.Interfaces;
using Estudos.MongoDb.Domain.ValueObjects;

namespace Estudos.MongoDb.Application.UseCases.GetReviewsByRestaurantId;

public class GetReviewsByRestaurantIdUseCase : BaseUseCase<GetReviewsByRestaurantIdInput>
{
    private readonly IRestaurantRepository _repository;
    private readonly IMapper _mapper;

    public GetReviewsByRestaurantIdUseCase(IRestaurantRepository repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public override async Task<Output> Handle(GetReviewsByRestaurantIdInput request, CancellationToken cancellationToken)
    {
        var reviews = await _repository.GetReviewsAsync(request.Id, request, cancellationToken);

        return Success(GetPageListOutput(reviews));
    }

    private PageListOutput<GetReviewsByRestaurantIdOutput> GetPageListOutput(PagedResult<Review> pagedResult)
    {
        var getReviewsByRestaurants = _mapper.Map<IEnumerable<GetReviewsByRestaurantIdOutput>>(pagedResult.Items);

        return new PageListOutput<GetReviewsByRestaurantIdOutput>
        (getReviewsByRestaurants, (int)pagedResult.TotalItems, (int)pagedResult.Total, pagedResult.CurrentPage,
            pagedResult.ResultsPerPage);
    }
}