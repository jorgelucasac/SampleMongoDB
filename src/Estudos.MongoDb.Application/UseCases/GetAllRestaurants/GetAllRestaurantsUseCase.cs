﻿using AutoMapper;
using Estudos.MongoDb.Application.UseCases.Shared;
using Estudos.MongoDb.Domain.Data;
using Estudos.MongoDb.Domain.Data.Interfaces;
using Estudos.MongoDb.Domain.Entities;

namespace Estudos.MongoDb.Application.UseCases.GetAllRestaurants;

public class GetAllRestaurantsUseCase : IGetAllRestaurantsUseCase
{
    private readonly IRestaurantRepository _repository;
    private readonly IMapper _mapper;

    public GetAllRestaurantsUseCase(IRestaurantRepository repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public async Task<Output> Handle(GetAllRestaurantsInput request, CancellationToken cancellationToken)
    {
        var restaurants = await _repository.GetAll(request, cancellationToken);

        return GetAllRestaurantsSuccessfully(restaurants);
    }

    public Output GetAllRestaurantsSuccessfully(PagedResult<Restaurant> pagedResult)
    {
        return new Output(GetPageListOutput(pagedResult));
    }

    private PageListOutput<GetAllRestaurantsOutput> GetPageListOutput(PagedResult<Restaurant> pagedResult)
    {
        var getAllRestaurantsOutput = _mapper.Map<IEnumerable<GetAllRestaurantsOutput>>(pagedResult.Items);

        return new PageListOutput<GetAllRestaurantsOutput>
            (getAllRestaurantsOutput, (int)pagedResult.TotalResults, pagedResult.CurrentPage, pagedResult.ResultsPerPage);
    }
}