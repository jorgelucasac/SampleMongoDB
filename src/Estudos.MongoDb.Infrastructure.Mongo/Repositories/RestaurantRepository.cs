using AutoMapper;
using Estudos.MongoDb.Domain.Data;
using Estudos.MongoDb.Domain.Data.Interfaces;
using Estudos.MongoDb.Domain.Entities;
using Estudos.MongoDb.Domain.Enums;
using Estudos.MongoDb.Domain.ValueObjects;
using Estudos.MongoDb.Infrastructure.Mongo.Interfaces;
using Estudos.MongoDb.Infrastructure.Mongo.Schemas;
using MongoDB.Bson;
using MongoDB.Driver;
using MongoDB.Driver.Linq;
using System.Text.RegularExpressions;

namespace Estudos.MongoDb.Infrastructure.Mongo.Repositories;

public class RestaurantRepository : MongoRepositoryBase<RestaurantSchema>, IRestaurantRepository
{
    protected override string CollectionName => nameof(Restaurant);
    private readonly IMongoCollection<ReviewSchema> _reviewCollection;
    private readonly IMapper _mapper;

    public RestaurantRepository(IMongoClientDatabase mongoClientDatabase, IMapper mapper) :
        base(mongoClientDatabase)
    {
        _mapper = mapper;
        _reviewCollection = mongoClientDatabase.Database.GetCollection<ReviewSchema>(nameof(Review));
    }

    public async Task<string> CreateAsync(Restaurant restaurant, CancellationToken cancellationToken)
    {
        var restaurantSchema = _mapper.Map<RestaurantSchema>(restaurant);
        await Collection.InsertOneAsync(restaurantSchema, new InsertOneOptions(), cancellationToken);

        return restaurantSchema.Id;
    }

    public async Task<PagedResult<Restaurant>> GetAllAsync(IPagedQuery query, CancellationToken cancellationToken)
    {
        var resultCount = await Collection.CountDocumentsAsync(a => true, cancellationToken: cancellationToken);
        if (resultCount == 0) return PagedResult<Restaurant>.Empty();

        var filter = GetFilter(query.Filter);
        var pageFilter = PageQueryFilter.Of(query, (int)resultCount);

        var filterQuery = Collection.Find(filter)
            .Sort(GetSort(query.SortOrder, query.OrderBy))
            .Skip(pageFilter.Skip)
            .Limit(pageFilter.ResultCountPerPage);

        var schemas = await filterQuery.ToListAsync(cancellationToken);
        var restaurants = _mapper.Map<List<Restaurant>>(schemas);

        return PagedResult<Restaurant>.Create(restaurants, pageFilter.Page, pageFilter.ResultCountPerPage,
        pageFilter.PageCount, restaurants.Count, pageFilter.ResultCount);
    }

    public async Task<Restaurant> GetByIdAsync(string id, CancellationToken cancellationToken)
    {
        try
        {
            var restaurantSchema = await Collection
                .Find(a => a.Id == id)
                .FirstOrDefaultAsync(cancellationToken);

            return _mapper.Map<Restaurant>(restaurantSchema);
        }
        catch (Exception e)
        {
            return null;
        }
    }

    public async Task<bool> ExistsAsync(string id, CancellationToken cancellationToken)
    {
        try
        {
            return await Collection
                  .Find(a => a.Id == id)
                  .AnyAsync(cancellationToken);
        }
        catch (Exception e)
        {
            return false;
        }
    }

    public async Task<bool> UpdateAsync(Restaurant restaurant, CancellationToken cancellationToken)
    {
        try
        {
            var restaurantSchema = _mapper.Map<RestaurantSchema>(restaurant);
            var result = await Collection
                .ReplaceOneAsync(x => x.Id == restaurantSchema.Id, restaurantSchema, cancellationToken: cancellationToken);

            return result.ModifiedCount > 0;
        }
        catch (Exception e)
        {
            return false;
        }
    }

    public async Task<bool> UpdateCountryAndNameAsync(string id, Country? country, string name, CancellationToken cancellationToken)
    {
        try
        {
            if (country is not null)
            {
                var update = Builders<RestaurantSchema>.Update.Set(x => x.Country, country);
                var resultCountry = await Collection.UpdateOneAsync(x => x.Id == id, update, cancellationToken: cancellationToken);
            }

            if (!string.IsNullOrEmpty(name))
            {
                var update = Builders<RestaurantSchema>.Update.Set(x => x.Name, name);
                var resultName = await Collection.UpdateOneAsync(x => x.Id == id, update, cancellationToken: cancellationToken);
            }

            return true;
        }
        catch (Exception e)
        {
            return false;
        }
    }

    public async Task AddReviewAsync(Review review, CancellationToken cancellationToken)
    {
        var reviewSchema = _mapper.Map<ReviewSchema>(review);
        await _reviewCollection.InsertOneAsync(reviewSchema, new InsertOneOptions(), cancellationToken);
    }

    public async Task<PagedResult<Review>> GetReviewsAsync(string id, IPagedQuery query, CancellationToken cancellationToken)
    {
        var resultCount = await _reviewCollection.CountDocumentsAsync(a => a.RestaurantId == id, cancellationToken: cancellationToken);
        if (resultCount == 0) return PagedResult<Review>.Empty();

        var pageFilter = PageQueryFilter.Of(query, (int)resultCount);
        var sort = Builders<ReviewSchema>.Sort.Descending(a => a.Stars);

        var filterQuery = _reviewCollection.Find(x => x.RestaurantId == id)
            .Sort(sort)
            .Skip(pageFilter.Skip)
            .Limit(pageFilter.ResultCountPerPage);

        var schemas = await filterQuery.ToListAsync(cancellationToken);
        var reviews = _mapper.Map<List<Review>>(schemas);

        return PagedResult<Review>.Create(reviews, pageFilter.Page, pageFilter.ResultCountPerPage,
        pageFilter.PageCount, reviews.Count, pageFilter.ResultCount);
    }

    public async Task<Dictionary<Restaurant, double>> GetTopRatedRestaurantsWhithoutLookupAsync(int limit, CancellationToken cancellationToken)
    {
        var result = new Dictionary<Restaurant, double>();

        var topReviews = await _reviewCollection.Aggregate()
            .Group(x => x.RestaurantId, g => new { RestaurantId = g.Key, AverageStars = g.Average(a => a.Stars) })
            .SortByDescending(x => x.AverageStars)
            .Limit(limit)
            .ToListAsync(cancellationToken);

        foreach (var topReview in topReviews)
        {
            var restaurant = await GetByIdAsync(topReview.RestaurantId, cancellationToken);
            var reviewsSchema = await _reviewCollection
                                .Find(a => a.RestaurantId == topReview.RestaurantId)
                                .ToListAsync(cancellationToken);

            var reviews = _mapper.Map<List<Review>>(reviewsSchema);
            restaurant.AddReviews(reviews);
            result.Add(restaurant, topReview.AverageStars);
        }

        return result;
    }

    public async Task<Dictionary<Restaurant, double>> GetTopRatedRestaurantsAsync(int limit, CancellationToken cancellationToken)
    {
        var result = new Dictionary<Restaurant, double>();

        var topReviews = await _reviewCollection
           .Aggregate()
           .Group(x => x.RestaurantId, g => new { RestaurantId = g.Key, AverageStars = g.Average(a => a.Stars) })
           .SortByDescending(x => x.AverageStars)
           .Limit(limit)
           .Lookup<RestaurantSchema, RestaurantReviewSchema>(nameof(Restaurant), "RestaurantId", "Id", "Restaurants")
           .Lookup<ReviewSchema, RestaurantReviewSchema>(nameof(Review), "Id", "RestaurantId", "Reviews")
           .ToListAsync(cancellationToken);

        foreach (var topReview in topReviews)
        {
            if (!topReview.Restaurants.Any())
                continue;

            var restaurant = _mapper.Map<Restaurant>(topReview.Restaurants.First());
            var reviews = _mapper.Map<List<Review>>(topReview.Reviews);

            restaurant.AddReviews(reviews);
            result.Add(restaurant, topReview.AverageStars);
        }

        return result;
    }

    public async Task<bool> DeleteAsync(string id, CancellationToken cancellationToken)
    {
        try
        {
            var reviewResult = await _reviewCollection.DeleteManyAsync(x => x.RestaurantId == id, cancellationToken);
            var restaurantResult = await Collection.DeleteOneAsync(x => x.Id == id, cancellationToken);

            return (restaurantResult.DeletedCount > 0 && reviewResult.DeletedCount > 0);
        }
        catch (Exception e)
        {
        }
        return default;
    }

    public async Task<IEnumerable<Restaurant>> SearchWithIndex(string search, CancellationToken cancellationToken)
    {
        var filter = Builders<RestaurantSchema>.Filter.Text(search);

        var schemas = await Collection
             .AsQueryable()
             .Where(_ => filter.Inject())
             .ToListAsync(cancellationToken);

        var restaurants = _mapper.Map<List<Restaurant>>(schemas);

        return restaurants;
        //db.Restaurant.createIndex({ "$**": "text"},{ default_language: "portuguese"})
        //db.Restaurant.createIndex({ Name: "text"},{ default_language: "portuguese"})
    }

    private FilterDefinition<RestaurantSchema> GetFilter(string filter)
    {
        var regexFilter = Regex.Escape(filter);
        var bsonRegex = new BsonRegularExpression(regexFilter, "i");
        return new BsonDocument { { nameof(Restaurant.Name), bsonRegex } };

        //return new BsonDocument { { nameof(Restaurant.Name),
        //    new BsonDocument { { "$regex", filter }, { "$options", "i" } } } };
    }
}