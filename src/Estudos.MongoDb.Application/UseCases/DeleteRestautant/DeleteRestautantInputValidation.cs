using Estudos.MongoDb.Application.UseCases.DeleteRestautant;
using FluentValidation;

public class DeleteRestautantInputValidation : AbstractValidator<DeleteRestautantInput>
{
    public const int IdLength = 24;

    public DeleteRestautantInputValidation()
    {
        ValidateId();
       
    }

    private void ValidateId()
    {
        RuleFor(a => a.Id)
            .NotEmpty()
            .Length(IdLength)
            .WithMessage("'{PropertyName}' deve ter {MaxLength} caracteres. Você digitou {TotalLength} caracteres.");
    }
}