using Estudos.MongoDb.Domain.Validations;
using FluentValidation.Results;

namespace Estudos.MongoDb.Domain.ValueObjects
{
    public class Endereco
    {
        public Endereco(string logradouro, string numero, string cidade, string uf, string cep)
        {
            Logradouro = logradouro;
            Numero = numero;
            Cidade = cidade;
            UF = uf;
            Cep = cep;
        }

        public string Logradouro { get; private set; }
        public string Numero { get; private set; }
        public string Cidade { get; private set; }
        public string UF { get; private set; }
        public string Cep { get; private set; }
        public ValidationResult ValidationResult { get; private set; }

        public bool Validar()
        {
            ValidationResult = new EnderecoValidation().Validate(this);
            return ValidationResult.IsValid;
        }
    }
}