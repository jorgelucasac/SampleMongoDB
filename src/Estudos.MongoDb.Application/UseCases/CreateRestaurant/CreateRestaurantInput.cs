using Estudos.MongoDb.Application.UseCases.Shared;
using MediatR;

namespace Estudos.MongoDb.Application.UseCases.CreateRestaurant;

public class CreateRestaurantInput : IRequest<Output>
{
    public string Name { get; set; } = string.Empty;
    public int Country { get; set; }
    public string PublicPlace { get; set; } = string.Empty;
    public string Number { get; set; } = string.Empty;
    public string City { get; set; } = string.Empty;
    public string State { get; set; } = string.Empty;
    public string ZipCode { get; set; } = string.Empty;
}