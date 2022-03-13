using FluentValidation;

namespace Estudos.MongoDb.Application.UseCases.CreateRestaurant;

public class CreateRestauranteInputValidation : AbstractValidator<CreateRestauranteInput>
{
    public CreateRestauranteInputValidation()
    {
        ValidarLogradouro();
        ValidarCidade();
        ValidarUf();
        ValidarCep();
        ValidarNome();
        ValidarCozinha();
    }

    private void ValidarNome()
    {
        RuleFor(c => c.Nome)
            .NotEmpty().WithMessage("Nome não pode ser vazio.")
            .MaximumLength(30).WithMessage("Nome pode ter no maximo 30 caracteres.");
    }

    private void ValidarCozinha()
    {
        RuleFor(c => c.Cozinha)
            .NotEmpty().WithMessage("Cozinha não pode ser vazio.");
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