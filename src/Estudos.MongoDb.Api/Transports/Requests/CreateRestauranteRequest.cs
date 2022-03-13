namespace Estudos.MongoDb.Api.Transports.Requests;

public class CreateRestauranteRequest
{
    public string Nome { get; set; } = string.Empty;
    public int Cozinha { get; set; }
    public string Logradouro { get; set; } = string.Empty;
    public string Numero { get; set; } = string.Empty;
    public string Cidade { get; set; } = string.Empty;
    public string UF { get; set; } = string.Empty;
    public string Cep { get; set; } = string.Empty;
}