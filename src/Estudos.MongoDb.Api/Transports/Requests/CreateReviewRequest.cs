namespace Estudos.MongoDb.Api.Transports.Requests;

public class CreateReviewRequest
{
    public int Stars { get; set; }
    public string Comment { get; set; }
}