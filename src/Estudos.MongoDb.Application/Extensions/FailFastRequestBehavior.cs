using Estudos.MongoDb.Application.UseCases.Shared;
using FluentValidation;
using FluentValidation.Results;
using MediatR;

namespace Estudos.MongoDb.Application.Extensions;

public sealed class FailFastValidationBehavior<TRequest, TOutput> : IPipelineBehavior<TRequest, TOutput>
    where TRequest : IRequest<TOutput> where TOutput : Output, new()
{
    private readonly IEnumerable<IValidator<TRequest>> _validators;

    public FailFastValidationBehavior(IEnumerable<IValidator<TRequest>> validator)
    {
        _validators = validator;
    }

    public async Task<TOutput> Handle(TRequest request, CancellationToken cancellationToken, RequestHandlerDelegate<TOutput> next)
    {
        var validationResults = ProcessValidations(request);

        var result = CreateResult(validationResults);

        return await VerifyNextStepAsync(result, next);
    }

    private IEnumerable<ValidationResult> ProcessValidations(TRequest request)
    {
        return _validators.Select(validator => validator.Validate(request));
    }

    public static TOutput CreateResult(IEnumerable<ValidationResult> validationResults)
    {
        var output = new TOutput();
        var errors = validationResults
            .SelectMany(a => a.Errors)
            .Select(a => a.ErrorMessage);

        output.AddErros(errors.ToList());
        return output;
    }

    private async Task<TOutput> VerifyNextStepAsync(Output output, RequestHandlerDelegate<TOutput> proceedToCommandHandler)
    {
        if (output.IsValid)
            return await proceedToCommandHandler();

        var nextStep = output as TOutput;

        return nextStep;
    }
}