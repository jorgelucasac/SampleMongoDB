namespace Estudos.MongoDb.Api.Transports.Responses;

public class ApiErrorResponse
{
    public ApiErrorResponse(List<string> errors)
    {
        Errors = errors;
    }

    public List<string> Errors { get; }
}