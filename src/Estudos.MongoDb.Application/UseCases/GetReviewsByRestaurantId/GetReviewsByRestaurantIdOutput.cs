namespace Estudos.MongoDb.Application.UseCases.GetReviewsByRestaurantId;

public class GetReviewsByRestaurantIdOutput
{
    public string RestaurantId { get; set; }
    public int Stars { get; set; }
    public string Comment { get; set; }
}