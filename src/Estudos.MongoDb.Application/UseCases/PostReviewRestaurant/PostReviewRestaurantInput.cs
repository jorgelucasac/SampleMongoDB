using Estudos.MongoDb.Application.UseCases.Shared;

namespace Estudos.MongoDb.Application.UseCases.PostReviewRestaurant;

public class PostReviewRestaurantInput : BaseInput
{
    public PostReviewRestaurantInput(int stars, string comment)
    {
        Stars = stars;
        Comment = comment;
    }

    public string RestaurantId { get; private set; }
    public int Stars { get; private set; }
    public string Comment { get; private set; }

    public void SetRestaurantId(string restaurantId)
    {
        RestaurantId = restaurantId;
    }
}