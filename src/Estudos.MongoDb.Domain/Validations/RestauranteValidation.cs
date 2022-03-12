using Estudos.MongoDb.Domain.Entities;
using FluentValidation;

namespace Estudos.MongoDb.Domain.Validations
{
    internal class RestauranteValidation : AbstractValidator<Restaurante>
    {
        public RestauranteValidation()
        {
            ValidarNome();
            ValidarNome();
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
    }
}