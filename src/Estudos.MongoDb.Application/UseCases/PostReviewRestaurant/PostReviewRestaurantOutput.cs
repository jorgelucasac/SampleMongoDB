namespace Estudos.MongoDb.Application.UseCases.PostReviewRestaurant;

public class PostReviewRestaurantOutput
{
    public string RestaurantId { get; set; }
    public int Stars { get; set; }
    public string Comment { get; set; }
}