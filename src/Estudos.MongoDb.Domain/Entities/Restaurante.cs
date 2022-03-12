using Estudos.MongoDb.Domain.Enums;
using Estudos.MongoDb.Domain.Validations;
using Estudos.MongoDb.Domain.ValueObjects;
using FluentValidation.Results;

namespace Estudos.MongoDb.Domain.Entities;

public class Restaurante
{
    public Restaurante(string nome, Cozinha cozinha)
    {
        Nome = nome;
        Cozinha = cozinha;
    }

    public Restaurante(string id, string nome, Cozinha cozinha)
    {
        Id = id;
        Nome = nome;
        Cozinha = cozinha;
    }

    public string Id { get; private set; }
    public string Nome { get; private set; }
    public Cozinha Cozinha { get; private set; }
    public Endereco Endereco { get; private set; }

    public ValidationResult ValidationResult { get; private set; }

    public void AtribuirEndereco(Endereco endereco)
    {
        Endereco = endereco;
    }

    public virtual bool Validar()
    {
        ValidationResult =  new RestauranteValidation().Validate(this);

        ValidarEndereco();

        return ValidationResult.IsValid;
    }

    private void ValidarEndereco()
    {
        if (Endereco.Validar())
            return;

        foreach (var erro in Endereco.ValidationResult.Errors)
            ValidationResult.Errors.Add(erro);
    }
}