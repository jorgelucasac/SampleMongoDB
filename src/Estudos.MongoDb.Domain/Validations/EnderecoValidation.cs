using Estudos.MongoDb.Domain.ValueObjects;
using FluentValidation;

namespace Estudos.MongoDb.Domain.Validations;

internal class EnderecoValidation : AbstractValidator<Endereco>
{
    public EnderecoValidation()
    {
        ValidarLogradouro();
        ValidarCidade();
        ValidarUf();
        ValidarCep();
    }

    private void ValidarLogradouro()
    {
        RuleFor(c => c.Logradouro)
            .NotEmpty().WithMessage("Logradouro não pode ser vazio.")
            .MaximumLength(50).WithMessage("Logradouro pode ter no maximo 50 caracteres.");
    }

    private void ValidarCidade()
    {
        RuleFor(c => c.Cidade)
            .NotEmpty().WithMessage("Cidade não pode ser vazio.")
            .MaximumLength(100).WithMessage("Cidade pode ter no maximo 100 caracteres.");
    }

    private void ValidarUf()
    {
        RuleFor(c => c.UF)
            .NotEmpty().WithMessage("UF não pode ser vazio.")
            .Length(2).WithMessage("UF deve ter 2 caracteres.");
    }

    private void ValidarCep()
    {
        RuleFor(c => c.Cep)
            .NotEmpty().WithMessage("Cep não pode ser vazio.")
            .Length(8).WithMessage("Cep deve ter 8 caracteres.");
    }
}