using Estudos.MongoDb.Api.Transports.Responses;
using Estudos.MongoDb.Application.UseCases.Shared;

namespace Estudos.MongoDb.Api.Extensions.Outputs;

public static class OutputExtension
{
    public static ApiErrorResponse MapToApiErrorResponse(this Output output)
    {
        return new ApiErrorResponse(output.Erros.ToList());
    }
}